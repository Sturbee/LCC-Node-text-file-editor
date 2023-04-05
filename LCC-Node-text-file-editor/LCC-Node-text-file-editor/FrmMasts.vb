Imports System.IO

Public Class FrmMasts

    Public Property MyMasts As Integer
    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml

    Private Sub FrmMasts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.MastTitlesRow = dsTitles.MastTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader

        ' read the attribute xml file
        Dim clsR As New ClsReport
        Dim dsRpt As Rpt = clsR.MyReport

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        Try
            Me.MyExportXml.ReadXml(Me.MyFilePath)
        Catch ex As Exception
            MsgBox("Failed to read file " + Me.MyFileName)
            Exit Sub
        End Try

        ' populate tab control

        Try

            Me.TabControlMasts.Controls.Clear()

            For count = 1 To Me.MyMasts

                Dim row As ExportXml.MastRow = Me.MyExportXml.Mast.FindByMastID(count)

                Dim mast As String = String.Empty
                If row.description.Length = 0 Then
                    mast = rowTitle.subHeader + Space(1) + count.ToString
                Else
                    mast = row.description
                End If

                Dim MyTabPage As New TabPage With {
                .Text = mast
                }

                Me.TabControlMasts.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception

            MsgBox("Failed to populate tab control")
            Exit Sub

        End Try

    End Sub

    Private Sub TabControlMasts_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlMasts.Selected

        ' Stop

    End Sub

End Class