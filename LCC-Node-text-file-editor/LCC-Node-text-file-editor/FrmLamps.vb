Imports System.IO

Public Class FrmLamps

    Public Property MyLamps As Integer
    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml

    Private Sub FrmLamps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.LampsTitlesRow = dsTitles.LampsTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp.Text = rowTitle.help

        ' read the attribute xml file
        Dim clsR As New ClsReport
        Dim dsRpt As Rpt = clsR.MyReport

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

        ' populate tab control
        Try

            Me.TabControlLamps.Controls.Clear()

            For count = 1 To Me.MyLamps

                Dim row As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(count)

                Dim MyTabPage As New TabPage With {
                .Text = rowTitle.subHeader + Space(1) + count.ToString + Space(1) + row.description
                }

                Me.TabControlLamps.Controls.Add(MyTabPage)

            Next

            Me.TabControlLamps.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("Failed to populate tab control")
            Exit Sub
        End Try

    End Sub

    Private Sub CheckFormAndOpen(frm As Form)

        If Me.OwnedForms.Length = 0 Then
            ' do nothing
        Else
            For count = 0 To Me.OwnedForms.Length - 1
                If Me.OwnedForms(count).Name = frm.Name Then
                    Beep()
                    Exit Sub
                End If
            Next
        End If

        Me.AddOwnedForm(frm)
        frm.Show()

    End Sub

    Private Sub TabControlLamps_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlLamps.Selected

        If e.TabPageIndex = -1 Then
            ' do nothing
        Else
            ' fill in row values
            Dim row As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(e.TabPageIndex + 1)

            Dim frm As New FrmLamp With {
                .MyLampID = e.TabPageIndex + 1
            }
            Call Me.CheckFormAndOpen(frm)

        End If

        Me.TabControlLamps.SelectedIndex = -1

    End Sub

End Class