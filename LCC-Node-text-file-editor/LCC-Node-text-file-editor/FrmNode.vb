Imports System.IO

Public Class FrmNode

    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExport As New ClsExportXML

    Private Sub FrmNode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        ' read the export xml file
        MyExport.DbExportReadFile(MyFilePath)

        ' read the titles xml file
        Dim clsT As New ClsTitles

        ' set labels
        Dim rowTitle As Titles.NodeTitlesRow = clsT.Titles.NodeTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblName.Text = rowTitle.name
        Me.LblDecription.Text = rowTitle.description
        Me.LblNodeType.Text = rowTitle.nodeType
        Me.LblEventBase.Text = rowTitle.eventBase

        Me.LblFileName.Text = Me.MyFileName

        ' read the attribute xml file
        Dim clsR As New ClsReport

        Dim nodeRow As ExportXml.NodeRow = MyExport.DbExport.Node.Item(0)

        Dim row As Rpt.NodeTypeRow = clsR.Rpt.NodeType.FindByvalue(nodeRow.nodeType)
        If row Is Nothing Then
            Me.LblType.Text = "Unknown"
        Else
            Me.LblType.Text = row.name
        End If

        Me.LblBaseAddress.Text = nodeRow.eventBase.ToString
        Me.TxtNodeName.Text = nodeRow.Name.ToString
        Me.TxtNodeDescription.Text = nodeRow.Description.ToString

    End Sub

    Private Sub ButSaveChanges_Click(sender As Object, e As EventArgs) Handles ButSaveChanges.Click

        Try
            Dim nodeRow As ExportXml.NodeRow = MyExport.DbExport.Node.Item(0)
            nodeRow.Name = Me.TxtNodeName.Text
            nodeRow.Description = Me.TxtNodeDescription.Text

            MyExport.DbExport.WriteXml(Me.MyFilePath)
            MsgBox("Saved changes to node values")

            ' need to reload after save
            MyExport.DbExportReadFile(Me.MyFilePath)

            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save node values")
        End Try

    End Sub

End Class