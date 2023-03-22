

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

    Private Sub ExamineButton_Click(sender As Object, e As EventArgs) Handles ExamineButton.Click

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

        ' Obtain file information in a string.
        Dim fileInfoText As String = GetTextForOutput(filePath)

        ' Show the file information.
        MessageBox.Show(fileInfoText)

        If SaveCheckBox.Checked = True Then
            ' Place the log file in the same folder as the examined file.
            Dim logFolder As String = My.Computer.FileSystem.GetFileInfo(filePath).DirectoryName
            Dim logFilePath = My.Computer.FileSystem.CombinePath(logFolder, "log.txt")

            Dim logText As String = "Logged: " & Date.Now.ToString &
                vbCrLf & fileInfoText & vbCrLf & vbCrLf

            ' Append text to the log file.
            My.Computer.FileSystem.WriteAllText(logFilePath, logText, append:=True)
        End If

    End Sub

    Private Function GetTextForOutput(ByVal filePath As String) As String

        ' Verify that the file exists.
        If My.Computer.FileSystem.FileExists(filePath) = False Then
            Throw New Exception("File Not Found: " & filePath)
        End If

        ' Create a new StringBuilder, which is used
        ' to efficiently build strings.
        Dim sb As New System.Text.StringBuilder()

        ' Obtain file information.
        Dim thisFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(filePath)

        ' Add file attributes.
        sb.Append("File: " & thisFile.FullName)
        sb.Append(vbCrLf)
        sb.Append("Modified: " & thisFile.LastWriteTime.ToString)
        sb.Append(vbCrLf)
        sb.Append("Size: " & thisFile.Length.ToString & " bytes")
        sb.Append(vbCrLf)

        ' Open the text file.
        Dim sr As System.IO.StreamReader =
            My.Computer.FileSystem.OpenTextFileReader(filePath)

        ' Add the first line from the file.
        If sr.Peek() >= 0 Then
            sb.Append("First Line: " & sr.ReadLine())
        End If
        sr.Close()

        Return sb.ToString

    End Function

    Private Sub SetEnabled()

        Dim anySelected As Boolean =
            (FilesListBox.SelectedItem IsNot Nothing)

        ExamineButton.Enabled = anySelected
        SaveCheckBox.Enabled = anySelected

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
        Dim clsXml As New ClassExportCDIxml
        clsXml.MyReadTextFile(filePath)

        ' process xml file to .xsd file
        Dim clsXsd As New ClassExportXsd
        clsXsd.ExportToXsdFile(filePath)

        ' process xml file to .csv file
        Dim clsCvs As New ClassExportXmlToCsv
        clsCvs.ExportToCvsFile(filePath)

        Me.ListFiles(FolderBrowserDialog1.SelectedPath)

        FilesListBox.SelectedItem = filePath

    End Sub


    Private Sub AppendLogFile(filePath As String)

        ' Create a new StringBuilder, which is used
        ' to efficiently build strings.
        Dim sb As New System.Text.StringBuilder()

        ' Obtain file information.
        Dim thisFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(filePath)

        ' Add file attributes.
        sb.Append("File: " & thisFile.FullName)
        sb.Append(vbCrLf)
        sb.Append("Modified: " & thisFile.LastWriteTime.ToString)
        sb.Append(vbCrLf)
        sb.Append("Size: " & thisFile.Length.ToString & " bytes")
        sb.Append(vbCrLf)

        ' Open the text file.
        Dim sr As System.IO.StreamReader =
            My.Computer.FileSystem.OpenTextFileReader(filePath)

        ' Add the first line from the file.
        If sr.Peek() >= 0 Then
            sb.Append("First Line: " & sr.ReadLine())
        End If
        sr.Close()

        ' Show the file information.
        MessageBox.Show(sb.ToString)

        ' Place the log file in the same folder as the examined file.
        Dim processFolder As String = My.Computer.FileSystem.GetFileInfo(filePath).DirectoryName
        Dim processFilePath = My.Computer.FileSystem.CombinePath(processFolder, thisFile.FullName + ".proc.txt")

        Dim processText As String = "Process: " & Date.Now.ToString & vbCrLf & thisFile.FullName & vbCrLf & vbCrLf

        ' Append text to the log file.
        My.Computer.FileSystem.WriteAllText(processFilePath, processText, append:=True)

    End Sub

End Class
