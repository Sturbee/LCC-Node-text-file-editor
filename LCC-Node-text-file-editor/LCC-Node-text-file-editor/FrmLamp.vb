Imports System.IO

Public Class FrmLamp

    Public Property MyLampID As Integer
    Private Property MyFilePath As String
    Private Property MyImport As New ExportXml
    Private Property MyLampRow As ExportXml.LampRow

    Private Sub FrmLamp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayControls()

    End Sub

    Private Sub DisplayControls()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag

        ' fill in labels
        Me.LblLampID.Text = "Lamp #" + Me.MyLampID.ToString

        Try
            Dim clsT As New ClsTitles
            Dim rowT As Titles.LampTitlesRow = clsT.MyTitles.LampTitles.Item(0)
            Me.LblHeader.Text = rowT.header
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

            Me.CmbLampSelection.BeginUpdate()
            For I = 0 To clsR.MyReport.LampSelection.Count - 1
                Dim row As Rpt.LampSelectionRow = clsR.MyReport.LampSelection.Item(I)
                Me.CmbLampSelection.Items.Add(row.text)
            Next
            Me.CmbLampSelection.EndUpdate()

            Me.CmbLampPhase.BeginUpdate()
            For I = 0 To clsR.MyReport.LampPhase.Count - 1
                Dim row As Rpt.LampPhaseRow = clsR.MyReport.LampPhase.Item(I)
                Me.CmbLampPhase.Items.Add(row.text)
            Next
            Me.CmbLampPhase.EndUpdate()

        Catch ex As Exception
            MsgBox("Failed to read attributes")
            Exit Sub
        End Try

        ' fill in row values
        Try
            Me.MyImport.ReadXml(Me.MyFilePath)
            Me.MyLampRow = Me.MyImport.Lamp.FindByLampID(Me.MyLampID)
        Catch ex As Exception
            MsgBox("Failed to read xml file")
            Exit Sub
        End Try

        Me.TxtDescription.Text = Me.MyLampRow.description
        Me.TxtLampOn.Text = Me.MyLampRow.eventOn
        Me.TxtLampOff.Text = Me.MyLampRow.eventOff
        Me.TxtBrightness.Text = Me.MyLampRow.brightness

        Me.CmbLampFade.SelectedIndex = Me.MyLampRow.lampFadeID
        Me.CmbLampSelection.SelectedIndex = Me.MyLampRow.lampSelectionID
        Me.CmbLampPhase.SelectedIndex = Me.MyLampRow.lampPhaseID

    End Sub

End Class