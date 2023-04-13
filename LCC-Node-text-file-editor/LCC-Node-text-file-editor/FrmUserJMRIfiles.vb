Public Class FrmUserJMRIfiles

    Private Property MyUser As New ClsUserPrefs

    Private Sub FrmUserPrefs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayUserPathSelection()

    End Sub

    Private Sub DisplayUserPathSelection()

        Try

            Me.CmbPath.BeginUpdate()
            For count = 0 To MyUser.UserPrefs.UserJMRI.Count - 1
                Dim row As UserPrefs.UserJMRIRow = MyUser.UserPrefs.UserJMRI.Item(count)
                Me.CmbPath.Items.Add(row.title)
            Next
            Me.CmbPath.EndUpdate()

        Catch ex As Exception

            MsgBox("Failed to populate combo box")
            Exit Sub

        End Try

        Dim result As Integer = MyUser.CheckUserFileDirectories

        If result = -1 Then
            Me.CmbPath.SelectedIndex = 0
        Else
            Me.CmbPath.SelectedIndex = result
        End If


    End Sub

    Private Sub CmbPath_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPath.SelectedIndexChanged

        Dim row As UserPrefs.UserJMRIRow = MyUser.UserPrefs.UserJMRI.FindByvalue(Me.CmbPath.SelectedIndex)

        If row.path = Nothing Then
            Me.TxtPath.Text = FolderBrowserDialog1.SelectedPath
        Else
            Me.TxtPath.Text = row.path
        End If

        Me.TxtExtension.Text = row.extension

        Call Me.ListFiles(row.path)

    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            ListFiles(FolderBrowserDialog1.SelectedPath)
        End If

        Me.TxtPath.Text = FolderBrowserDialog1.SelectedPath

    End Sub

    Private Sub TxtExtension_TextChanged(sender As Object, e As EventArgs) Handles TxtExtension.TextChanged

        Call Me.ListFiles(FolderBrowserDialog1.SelectedPath)

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click

        Dim row As UserPrefs.UserJMRIRow = MyUser.UserPrefs.UserJMRI.FindByvalue(Me.CmbPath.SelectedIndex)

        If MyUser.JMRIfileRowWrite(Me.CmbPath.SelectedIndex, Me.TxtPath.Text, Me.TxtExtension.Text) = True Then
            MsgBox("JMRI LCC file directory and extension updated")
        Else
            MsgBox("Faile to update JMRI LCC file directory and extension")
        End If

    End Sub

    Private Sub ListFiles(ByVal folderPath As String)

        FilesListBox.Items.Clear()

        Try
            Dim fileNames = My.Computer.FileSystem.GetFiles(folderPath, FileIO.SearchOption.SearchTopLevelOnly, Me.TxtExtension.Text)

            For Each fileName As String In fileNames
                FilesListBox.Items.Add(fileName)
            Next

        Catch ex As Exception
            ' ignore

        End Try

    End Sub

End Class