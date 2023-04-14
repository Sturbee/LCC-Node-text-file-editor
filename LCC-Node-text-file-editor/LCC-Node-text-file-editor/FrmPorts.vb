Imports System.IO

Public Class FrmPorts

    Public Property MyLines As Integer
    Private Property MyFilePath As String
    REM Private Property MyFileName As String
    Private Property MyExport As New ClsExportXML

    Private Sub FrmPorts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub


    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        REM Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        ' read the export xml file
        MyExport.DbExportReadFile(MyFilePath)

        ' read the titles xml file set labels
        Dim MyClsTitles As New ClsTitles
        Dim rowTitle As Titles.PortTitlesRow = MyClsTitles.Titles.PortTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp.Text = rowTitle.help

        ' read the attributes xml file
        REM Dim MyClsReport As New ClsReport

        ' populate tab control

        Try

            Me.TabControlLines.Controls.Clear()

            For count = 1 To Me.MyLines

                Dim row As ExportXml.PortRow = MyExport.DbExport.Port.FindByLineID(count)

                Dim MyTabPage As New TabPage With {
                    .Text = count.ToString + " - " + row.Description
                }

                Me.TabControlLines.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception

            MsgBox("Failed to populate tab control")
            Exit Sub

        End Try

    End Sub

    Private Sub TabControlLines_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlLines.Selected

        Dim item1 As Integer

        If e.TabPageIndex = -1 Then
            item1 = 1
        Else
            item1 = e.TabPageIndex + 1
        End If
        ' fill in row values



    End Sub

End Class