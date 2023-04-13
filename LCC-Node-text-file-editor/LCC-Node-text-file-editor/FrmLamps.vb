Imports System.IO

Public Class FrmLamps

    Public Property MyLamps As Integer
    Private Property MyFilePath As String

    REM Private Property MyFileName As String
    Private Property MyReport As New ClsReport
    Private Property MyExport As New ClsExportXML

    Private Sub FrmLamps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.Tag = Me.Owner.Tag
        Me.MyFilePath = Me.Tag
        REM Me.MyFileName = Path.GetFileName(Me.Tag)

        ' read the titles xml file
        Dim clsT As New ClsTitles

        ' set labels
        Dim rowTitle As Titles.LampsTitlesRow = clsT.Titles.LampsTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp.Text = rowTitle.help
        Me.LblLampOn.Text = rowTitle.lampOn
        Me.LblLampOff.Text = rowTitle.lampOff
        Me.LblBrightness.Text = rowTitle.brightness

        ' read the attribute xml file

        Me.CmbLampFade.BeginUpdate()
        For I = 0 To MyReport.Rpt.LampFade.Count - 1
            Dim row As Rpt.LampFadeRow = MyReport.Rpt.LampFade.Item(I)
            Me.CmbLampFade.Items.Add(row.text)
        Next
        Me.CmbLampFade.EndUpdate()

        Me.CmbLampPhase.BeginUpdate()
        For I = 0 To MyReport.Rpt.LampPhase.Count - 1
            Dim row As Rpt.LampPhaseRow = MyReport.Rpt.LampPhase.Item(I)
            Me.CmbLampPhase.Items.Add(row.text)
        Next
        Me.CmbLampPhase.EndUpdate()

        ' populate tab control
        Try

            Me.TabControlLamps.Controls.Clear()

            For count = 1 To Me.MyLamps

                Dim row As ExportXml.LampRow = MyExport.ExportXML.Lamp.FindByLampID(count)

                Dim MyTabPage As New TabPage With {
                .Text = count.ToString + " - " + row.description
                }

                Me.TabControlLamps.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception
            MsgBox("Failed to populate tab control")
            Exit Sub
        End Try

    End Sub

    Private Sub TabControlLamps_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlLamps.Selected

        Dim lampID As Integer

        If e.TabPageIndex = -1 Then
            lampID = 1
        Else
            lampID = e.TabPageIndex + 1
        End If
        ' fill in row values

        Dim rowName As Rpt.LampSelectionRow = MyReport.Rpt.LampSelection.FindByvalue(lampID)
        Me.LblLampID.Text = "Lamp " + rowName.text

        Dim row As ExportXml.LampRow = MyExport.ExportXML.Lamp.FindByLampID(lampID)

        Me.TxtDescription.Text = row.description
        Me.TxtLampOn.Text = row.eventOn
        Me.TxtLampOff.Text = row.eventOff
        Me.TxtBrightness.Text = row.brightness

        Me.CmbLampFade.SelectedIndex = row.lampFadeID
        Me.CmbLampPhase.SelectedIndex = row.lampPhaseID

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try
            Dim row As ExportXml.LampRow = MyExport.ExportXML.Lamp.FindByLampID(Me.TabControlLamps.SelectedIndex + 1)
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

            MyExport.ExportXML.WriteXml(Me.MyFilePath)
            MsgBox("Saved changes to lamp values")

            ' need to reload after save
            MyExport.ExportXmlRead(MyFilePath)

            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save lamp values")
            Exit Sub
        End Try

    End Sub

End Class