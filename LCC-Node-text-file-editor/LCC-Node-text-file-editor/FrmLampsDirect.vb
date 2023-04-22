Imports System.IO

Public Class FrmLampsDirect

    Public Property MyLamps As Integer
    Private Property MyFilePath As String

    REM Private Property MyFileName As String
    Private Property MyReport As New ClsReport
    Private Property MyExport As New ClsExportXML

    Private Sub FrmLampsDirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.Tag = Me.Owner.Tag
        Me.MyFilePath = Me.Tag
        REM Me.MyFileName = Path.GetFileName(Me.Tag)

        MyExport.DbExportReadFile(MyFilePath)

        ' read the titles xml file
        Dim clsT As New ClsTitles

        ' set labels
        Dim rowTitle As Titles.LampsDirectTitlesRow = clsT.Titles.LampsDirectTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp.Text = rowTitle.help
        Me.LblLampOn.Text = rowTitle.lampOn
        Me.LblLampOff.Text = rowTitle.lampOff


        ' read the attribute xml file

        Me.CmbLampFade.BeginUpdate()
        For I = 0 To MyReport.Rpt.LampFade.Count - 1
            Dim row As Rpt.LampFadeRow = MyReport.Rpt.LampFade.Item(I)
            Me.CmbLampFade.Items.Add(row.text)
        Next
        Me.CmbLampFade.EndUpdate()

        Me.CmbLampSelection.BeginUpdate()
        For I = 0 To MyReport.Rpt.LampSelection.Count - 1
            Dim row As Rpt.LampSelectionRow = MyReport.Rpt.LampSelection.Item(I)
            Me.CmbLampSelection.Items.Add(row.text)
        Next

        Me.CmbLampSelection.EndUpdate()

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

                Dim row As ExportXml.LampDirectRow = MyExport.DbExport.LampDirect.FindByLampDirectID(count)

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

        Dim lampDirectID As Integer

        If e.TabPageIndex = -1 Then
            lampDirectID = 1
        Else
            lampDirectID = e.TabPageIndex + 1
        End If
        ' fill in row values

        Me.LblLampID.Text = "Bulb " + lampDirectID.ToString

        Dim row As ExportXml.LampDirectRow = MyExport.DbExport.LampDirect.FindByLampDirectID(lampDirectID)

        Me.TxtDescription.Text = row.description
        Me.TxtLampOn.Text = row.eventOn
        Me.TxtLampOff.Text = row.eventOff

        Me.CmbLampFade.SelectedIndex = row.lampFadeID
        Me.CmbLampSelection.SelectedIndex = row.lampSelectionID
        Me.CmbLampPhase.SelectedIndex = row.lampPhaseID

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try
            Dim row As ExportXml.LampDirectRow = MyExport.DbExport.LampDirect.FindByLampDirectID(Me.TabControlLamps.SelectedIndex + 1)
            row.description = Me.TxtDescription.Text
            row.eventOn = Me.TxtLampOn.Text
            row.eventOff = Me.TxtLampOff.Text
            row.lampFadeID = Me.CmbLampFade.SelectedIndex
            row.lampSelectionID = Me.CmbLampSelection.SelectedIndex
            row.lampPhaseID = Me.CmbLampPhase.SelectedIndex

            MyExport.DbExport.WriteXml(Me.MyFilePath)
            MsgBox("Saved changes to lamp values")

            ' need to reload after save
            MyExport.DbExportReadFile(MyFilePath)

            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save lamp values")
            Exit Sub
        End Try

    End Sub

End Class