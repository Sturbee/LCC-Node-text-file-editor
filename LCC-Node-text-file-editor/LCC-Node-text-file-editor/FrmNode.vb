Imports System.IO

Public Class FrmNode

    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml


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

        Dim nodeRow As ExportXml.NodeRow = Me.MyExportXml.Node.Item(0)

        Me.LblFileName.Text = Me.MyFileName

        Dim row As Rpt.NodeTypeRow = dsRpt.NodeType.FindByvalue(nodeRow.nodeType)
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
            Dim nodeRow As ExportXml.NodeRow = MyExportXml.Node.Item(0)
            nodeRow.Name = Me.TxtNodeName.Text
            nodeRow.Description = Me.TxtNodeDescription.Text

            Me.MyExportXml.WriteXml(Me.MyFilePath)
            MsgBox("Saved changes to node values")

            ' need to reload after save
            MyExportXml = New ExportXml
            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save node values")
        End Try

    End Sub

End Class