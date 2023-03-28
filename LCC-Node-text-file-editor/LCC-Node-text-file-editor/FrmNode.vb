Public Class FrmNode

    Public Property MyFileName As String
    Public Property MySaveFile
    Private Property MyImport As New ExportXml
    Private Property MyNodeRow As ExportXml.NodeRow

    Private Sub FrmNode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' get App Config values
        Dim clsAppConfig As New ClassAppConfigValues
        Try
            clsAppConfig.AppConfigFileRead()
        Catch ex As Exception
            MsgBox("Failed to get config values")
            Exit Sub
        End Try

        ' read the titles xml file
        Dim dsTitles As New Titles
        Try
            dsTitles.ReadXml(clsAppConfig.SavedTitlesFile)
        Catch ex As Exception
            MsgBox("Failed to import titles")
            Exit Sub
        End Try

        ' set labels
        Dim rowTitle As Titles.NodeTitlesRow = dsTitles.NodeTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblName.Text = rowTitle.name
        Me.LblDecription.Text = rowTitle.description
        Me.LblNodeType.Text = rowTitle.nodeType
        Me.LblEventBase.Text = rowTitle.eventBase

        ' read the attribute xml file
        Dim dsRpt As New Rpt
        Try
            dsRpt.ReadXml(clsAppConfig.SavedReportFile)
        Catch ex As Exception
            MsgBox("Failed to import attributes")
            Exit Sub
        End Try


        ' temporary
        Me.MyFileName = clsAppConfig.SavedBlankSignalFile

        Me.MyFileName = "EditTest.xml"
        Me.MySaveFile = "EditTest.xml"

        ' read the file to read and edit
        REM Dim myImport As New ExportXml
        Try
            Me.MyImport.ReadXml(Me.MyFileName)
        Catch ex As Exception
            MsgBox("Failed to read file " + Me.MyFileName)
            Exit Sub
        End Try

        Me.MyNodeRow = Me.MyImport.Node.Item(0)

        Me.LblFileName.Text = Me.MyFileName

        Dim row As Rpt.NodeTypeRow = dsRpt.NodeType.FindByvalue(Me.MyNodeRow.NodeType)
        If row Is Nothing Then
            Me.LblType.Text = "Unknown"
        Else
            Me.LblType.Text = row.text
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

            Me.MyImport.WriteXml(Me.MySaveFile)

            MsgBox("Saved changes to file " + Me.MySaveFile)

        Catch ex As Exception
            MsgBox("Failed to save file " + Me.MySaveFile)
        End Try

    End Sub

End Class