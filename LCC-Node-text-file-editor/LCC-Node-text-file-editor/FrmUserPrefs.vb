Public Class FrmUserPrefs

    Private Property MyUserPrefs As New UserPrefs
    Private Sub FrmUserPrefs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayUserPathSelection()

    End Sub

    Private Sub DisplayUserPathSelection()

        Try

            Dim cls As New ClassAppConfigValues
            MyUserPrefs.ReadXml(cls.SavedUserFile)

            Me.CmbPath.BeginUpdate()
            For count = 0 To MyUserPrefs.UserJMRI.Count - 1
                Dim row As UserPrefs.UserJMRIRow = MyUserPrefs.UserJMRI.Item(count)
                Me.CmbPath.Items.Add(row.comment)
            Next
            Me.CmbPath.EndUpdate()

            Me.CmbPath.SelectedIndex = 0

        Catch ex As Exception

            MsgBox("Failed to populate combo box")
            Exit Sub

        End Try

    End Sub

    Private Sub CmbPath_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPath.SelectedIndexChanged

        Dim cls As New ClassAppConfigValues

        Dim row As UserPrefs.UserJMRIRow = MyUserPrefs.UserJMRI.FindByvalue(Me.CmbPath.SelectedIndex)

        Me.TxtPath.Text = cls.ReadAppKey(row.path)
        Me.TxtExtension.Text = cls.ReadAppKey(row.extension)

    End Sub

End Class