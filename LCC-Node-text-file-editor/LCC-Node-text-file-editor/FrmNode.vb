Imports System.IO

Public Class FrmNode

    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml
    Private Property MyNodeRow As ExportXml.NodeRow

    Private Sub FrmNode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.NodeTitlesRow = dsTitles.NodeTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblName.Text = rowTitle.name
        Me.LblDecription.Text = rowTitle.description
        Me.LblNodeType.Text = rowTitle.nodeType
        Me.LblEventBase.Text = rowTitle.eventBase

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

        Me.MyNodeRow = Me.MyExportXml.Node.Item(0)

        Me.LblFileName.Text = Me.MyFileName

        Dim row As Rpt.NodeTypeRow = dsRpt.NodeType.FindByvalue(Me.MyNodeRow.NodeType)
        If row Is Nothing Then
            Me.LblType.Text = "Unknown"
        Else
            Me.LblType.Text = row.name
        End If

        Me.LblBaseAddress.Text = Me.MyNodeRow.eventBase.ToString
        Me.TxtNodeName.Text = Me.MyNodeRow.Name.ToString
        Me.TxtNodeDescription.Text = Me.MyNodeRow.Description.ToString

    End Sub

    Private Sub ButSaveChanges_Click(sender As Object, e As EventArgs) Handles ButSaveChanges.Click

        If Me.MyNodeRow Is Nothing Then
            MsgBox("Node data missing")
            Exit Sub
        End If

        Try
            Me.MyNodeRow.Name = Me.TxtNodeName.Text
            Me.MyNodeRow.Description = Me.TxtNodeDescription.Text

            Me.MyExportXml.WriteXml(Me.MyFilePath)

            MsgBox("Saved changes to file " + Me.MyFileName)

        Catch ex As Exception
            MsgBox("Failed to save file " + Me.MyFileName)
        End Try

    End Sub

End Class