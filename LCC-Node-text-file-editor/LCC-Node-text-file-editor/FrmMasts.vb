Imports System.IO

Public Class FrmMasts

    Public Property MyMasts As Integer
    Private Property MyFilePath As String
    REM Private Property MyFileName As String
    Private Property MyExport As New ClsExportXML

    Private Sub FrmMasts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        REM Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        ' read the titles xml file
        Dim clsT As New ClsTitles

        ' set labels
        Dim rowTitle As Titles.MastTitlesRow = clsT.Titles.MastTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader

        ' read the attribute xml file
        REM Dim clsR As New ClsReport

        ' read the export xml file
        MyExport.ExportXmlRead(MyFilePath)

        ' populate tab control

        Try

            Me.TabControlMasts.Controls.Clear()

            For count = 1 To Me.MyMasts

                Dim row As ExportXml.MastRow = MyExport.ExportXML.Mast.FindByMastID(count)

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