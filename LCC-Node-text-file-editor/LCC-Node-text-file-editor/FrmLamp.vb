Imports System.IO

Public Class FrmLamp

    Public Property MyLampID As Integer
    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml

    Private Sub FrmLamp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayControls()

    End Sub

    Private Sub DisplayControls()

        ' read the file to read and edit
        Me.Tag = Me.Owner.Tag
        Me.MyFilePath = Me.Tag
        Me.MyFileName = Path.GetFileName(Me.Tag)

        Try
            Me.MyExportXml.ReadXml(Me.MyFilePath)
        Catch ex As Exception
            MsgBox("Failed to read file " + Me.MyFileName)
            Exit Sub
        End Try

        ' fill in labels
        Try
            Dim clsT As New ClsTitles
            Dim rowT As Titles.LampTitlesRow = clsT.MyTitles.LampTitles.Item(0)
            Me.Text = rowT.header
            Me.LblLampOn.Text = rowT.lampOn
            Me.LblLampOff.Text = rowT.lampOn
            Me.LblBrightness.Text = rowT.brightness

        Catch ex As Exception
            MsgBox("Failed to read titles")
            Exit Sub
        End Try

        Try
            Dim clsR As New ClsReport
            Me.CmbLampFade.BeginUpdate()
            For I = 0 To clsR.MyReport.LampFade.Count - 1
                Dim row As Rpt.LampFadeRow = clsR.MyReport.LampFade.Item(I)
                Me.CmbLampFade.Items.Add(row.text)
            Next
            Me.CmbLampFade.EndUpdate()

            Me.CmbLampPhase.BeginUpdate()
            For I = 0 To clsR.MyReport.LampPhase.Count - 1
                Dim row As Rpt.LampPhaseRow = clsR.MyReport.LampPhase.Item(I)
                Me.CmbLampPhase.Items.Add(row.text)
            Next
            Me.CmbLampPhase.EndUpdate()

            Dim rowName As Rpt.LampSelectionRow = clsR.MyReport.LampSelection.FindByvalue(Me.MyLampID)
            Me.LblLampID.Text = "Lamp " + rowName.text

        Catch ex As Exception
            MsgBox("Failed to read attributes")
            Exit Sub
        End Try

        Try
            Dim row As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(Me.MyLampID)

            Me.TxtDescription.Text = row.description
            Me.TxtLampOn.Text = row.eventOn
            Me.TxtLampOff.Text = row.eventOff
            Me.TxtBrightness.Text = row.brightness

            Me.CmbLampFade.SelectedIndex = row.lampFadeID
            Me.CmbLampPhase.SelectedIndex = row.lampPhaseID

        Catch ex As Exception
            MsgBox("Failed to read lamp row")
            Exit sub
        End Try

    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click

        Try
            Dim row As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(Me.MyLampID)
            row.description = Me.TxtDescription.Text
            row.eventOn = Me.TxtLampOn.Text
            row.eventOff = Me.TxtLampOff.Text
            row.lampFadeID = Me.CmbLampFade.SelectedIndex
            row.lampPhaseID = Me.CmbLampPhase.SelectedIndex

            ' check for integer value
            Try
                row.brightness = Me.TxtBrightness.Text
                If (row.brightness > 255) Or (row.brightness < 0) Then
                    MsgBox("Brightness value out of range")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Brighness value is not a integer")
                Exit Sub
            End Try

            Me.MyExportXml.WriteXml(Me.MyFilePath)
            MsgBox("Saved changes to file " + Me.MyFileName)
        Catch ex As Exception
            MsgBox("Failed to save lamp changes")
            Exit Sub
        End Try

    End Sub

End Class