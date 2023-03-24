
Public Class MyFileExplorer

    Private Sub MyFileExplorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the default directory of the folder browser to the current directory.

        Dim cls As New ClassAppConfigValues

        cls.AppConfigFileRead()

        FolderBrowserDialog1.SelectedPath = cls.SavedFileFolder

        Me.TextBoxFileExtension.Text = cls.SavedFileExtension

        ListFiles(FolderBrowserDialog1.SelectedPath)

        SetEnabled()

    End Sub


    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            ListFiles(FolderBrowserDialog1.SelectedPath)
        End If

        SetEnabled()

    End Sub

    Private Sub ListFiles(ByVal folderPath As String)

        FilesListBox.Items.Clear()

        REM Dim fileNames = My.Computer.FileSystem.GetFiles(folderPath, FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
        Dim fileNames = My.Computer.FileSystem.GetFiles(folderPath, FileIO.SearchOption.SearchTopLevelOnly, Me.TextBoxFileExtension.Text)

        For Each fileName As String In fileNames
            FilesListBox.Items.Add(fileName)
        Next

    End Sub


    Private Sub SetEnabled()

        Dim anySelected As Boolean = (FilesListBox.SelectedItem IsNot Nothing)

        Me.ButtonProcess.Enabled = anySelected

    End Sub

    Private Sub FilesListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilesListBox.SelectedIndexChanged

        SetEnabled()

    End Sub

    Private Sub ButtonSaveFileFolder_Click(sender As Object, e As EventArgs) Handles ButtonSaveSearch.Click

        Dim cls As New ClassAppConfigValues

        If cls.AppConfigFileWrite(Me.FolderBrowserDialog1.SelectedPath, Me.TextBoxFileExtension.Text) Then
            ' do nothing
        End If

    End Sub

    Private Sub TextBoxFileExtension_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFileExtension.TextChanged

        Call Me.ListFiles(Me.FolderBrowserDialog1.SelectedPath)

    End Sub

    Private Sub ButtonProcess_Click(sender As Object, e As EventArgs) Handles ButtonProcess.Click

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

        ' process LCC config file
        Dim clsXml As New ClassExportXml
        clsXml.MyExportToXmlFile(filePath)

        ' process xml file to .xsd file
        Dim clsXsd As New ClassExportXsd
        clsXsd.ExportToXsdFile(filePath)

        ' process xml file to .csv file
        Dim clsCvs As New ClassExportXmlToCsv
        clsCvs.ExportToCvsFile(filePath)

        Me.ListFiles(FolderBrowserDialog1.SelectedPath)

        FilesListBox.SelectedItem = filePath

    End Sub

End Class
