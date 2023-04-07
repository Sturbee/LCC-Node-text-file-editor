Public Class FrmFileRestore

    Private Sub FrmFileRestore_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Set the default directory to the user JMRI backup directory
        Dim cls As New ClsUserPrefs

        Dim filePath As String = String.Empty
        Dim fileExtension As String = String.Empty

        If cls.JMRIfileRowRead(2, filePath, fileExtension) Then

            FolderBrowserDialog1.SelectedPath = filePath

            Me.TextBoxFileExtension.Text = fileExtension

            ListFiles(FolderBrowserDialog1.SelectedPath)

        End If

    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            ListFiles(FolderBrowserDialog1.SelectedPath)
        End If

    End Sub

    Private Sub ListFiles(ByVal folderPath As String)

        FilesListBox.Items.Clear()

        Dim fileNames = My.Computer.FileSystem.GetFiles(folderPath, FileIO.SearchOption.SearchTopLevelOnly, Me.TextBoxFileExtension.Text)

        For Each fileName As String In fileNames
            FilesListBox.Items.Add(fileName)
        Next

    End Sub

    Private Sub TextBoxFileExtension_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFileExtension.TextChanged

        Call Me.ListFiles(Me.FolderBrowserDialog1.SelectedPath)

    End Sub

End Class