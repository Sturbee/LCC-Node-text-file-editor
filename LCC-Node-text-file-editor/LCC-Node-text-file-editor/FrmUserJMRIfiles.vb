Public Class FrmUserJMRIfiles

    Private Property MyUser As New ClsUserPrefs

    Private Sub FrmUserPrefs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayUserPathSelection()

    End Sub

    Private Sub DisplayUserPathSelection()

        Try
            Me.CmbPath.Items.Clear()
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

        Try
            Dim row As UserPrefs.UserJMRIRow = MyUser.UserPrefs.UserJMRI.FindByvalue(Me.CmbPath.SelectedIndex)
            Me.TxtPath.Text = row.path
            Me.TxtExtension.Text = row.extension
            Call Me.ListFiles(Me.TxtPath.Text, Me.TxtExtension.Text)
        Catch ex As Exception
            MsgBox("Failed path selected index change")
        End Try

    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click

        Call Me.BrowseDirectories()

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click

        Dim row As UserPrefs.UserJMRIRow = MyUser.UserPrefs.UserJMRI.FindByvalue(Me.CmbPath.SelectedIndex)

        If MyUser.JMRIfileRowWrite(Me.CmbPath.SelectedIndex, Me.TxtPath.Text, Me.TxtExtension.Text) = True Then
            MsgBox("JMRI LCC file directory and extension updated")
        Else
            MsgBox("Faile to update JMRI LCC file directory and extension")
        End If

        MyUser.UserPrefsXmlRead()

        Call Me.ListFiles(Me.TxtPath.Text, Me.TxtExtension.Text)

    End Sub

    Private Sub TxtPath_TextChanged(sender As Object, e As EventArgs) Handles TxtPath.TextChanged

        REM Call Me.ListFiles(Me.TxtPath.Text, Me.TxtExtension.Text)

    End Sub

    Private Sub TxtExtension_TextChanged(sender As Object, e As EventArgs) Handles TxtExtension.TextChanged

        REM Call Me.ListFiles(Me.TxtPath.Text, Me.TxtExtension.Text)

    End Sub

    Private Sub BrowseDirectories()

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            Me.TxtPath.Text = FolderBrowserDialog1.SelectedPath
            ListFiles(Me.TxtPath.Text, Me.TxtExtension.Text)
        End If

    End Sub

    Private Sub ListFiles(ByVal path As String, ext As String)

        Try

            FilesListBox.Items.Clear()

            Dim fileNames = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly, ext)

            For Each fileName As String In fileNames
                FilesListBox.Items.Add(fileName)
            Next

        Catch ex As Exception

            Call Me.BrowseDirectories()

        End Try

    End Sub



End Class