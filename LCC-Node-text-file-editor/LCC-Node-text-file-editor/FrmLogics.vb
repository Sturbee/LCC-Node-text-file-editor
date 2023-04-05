Imports System.IO

Public Class FrmLogics

    Public Property MyLogicCells As Integer
    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml

    Private Sub FrmLogicCells_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.LogicTitlesRow = dsTitles.LogicTitles.Item(0)
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

            Me.TabControlCells.Controls.Clear()

            For count = 1 To Me.MyLogicCells

                Dim row As ExportXml.LogicRow = Me.MyExportXml.Logic.FindByLogicID(count)

                Dim MyTabPage As New TabPage With {
                .Text = rowTitle.subHeader + " (" + count.ToString + ") " + row.Description
                }

                Me.TabControlCells.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception

            MsgBox("Failed to populate tab control")
            Exit Sub

        End Try

    End Sub

    Private Sub TabControlCells_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlCells.Selected

        ' Stop

    End Sub

End Class