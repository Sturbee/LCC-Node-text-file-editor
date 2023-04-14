Imports System.IO

Public Class FrmFileXml
    Private Sub FrmEditXml_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.MyDisplayFiles()

    End Sub

    Private Sub MyDisplayFiles()


        ' Set the default directory to the user JMRI xml directory
        Dim cls As New ClsUserPrefs

        Dim filePath As String = String.Empty
        Dim fileExtension As String = String.Empty

        If cls.JMRIfileRowRead(ClsUserPrefs.JMRIfileDirectory.ExportXml, filePath, fileExtension) Then

            FolderBrowserDialog1.SelectedPath = filePath

            Me.TxtFileExtension.Text = fileExtension

            Me.ListFiles(FolderBrowserDialog1.SelectedPath)

        End If

        Me.SetEnabled()

    End Sub


    Private Sub ListFiles(ByVal folderPath As String)

        FilesListBox.Items.Clear()

        Dim fileNames = My.Computer.FileSystem.GetFiles(folderPath, FileIO.SearchOption.SearchTopLevelOnly, Me.TxtFileExtension.Text)

        For Each fileName As String In fileNames
            FilesListBox.Items.Add(fileName)
        Next

    End Sub

    Private Sub FilesListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilesListBox.SelectedIndexChanged, FilesListBox.DoubleClick, FilesListBox.Click

        Me.SetEnabled()

    End Sub

    Private Sub TxtFileExtension_TextChanged(sender As Object, e As EventArgs) Handles TxtFileExtension.TextChanged

        Call Me.ListFiles(Me.FolderBrowserDialog1.SelectedPath)

    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            ListFiles(FolderBrowserDialog1.SelectedPath)
        End If

        SetEnabled()

    End Sub

    Private Sub SetEnabled()

        Dim anySelected As Boolean = (FilesListBox.SelectedItem IsNot Nothing)

        Me.CmdEdit.Enabled = anySelected
        Me.CmdRestore.Enabled = anySelected

    End Sub

    Private Sub CmdEdit_Click(sender As Object, e As EventArgs) Handles CmdEdit.Click

        Me.Owner.Tag = Me.FilesListBox.SelectedItem.ToString

        Me.Close()

    End Sub

    Private Sub CmdRestore_Click(sender As Object, e As EventArgs) Handles CmdRestore.Click

        If FilesListBox.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a file.")
            Exit Sub
        End If

        ' Obtain the file path from the list box selection.
        Dim filePath = FilesListBox.SelectedItem.ToString

        ' Verify that the file was not removed since the
        ' Browse button was clicked.
        If My.Computer.FileSystem.FileExists(filePath) = False Then
            MessageBox.Show("File Not Found: " & filePath)
            Exit Sub
        End If

        ' process export xml file
        Dim clsTxt As New ClassExportXmlToText
        clsTxt.MyExportXmlToTextFile(filePath)

        Me.ListFiles(FolderBrowserDialog1.SelectedPath)

        FilesListBox.SelectedItem = filePath

    End Sub

End Class