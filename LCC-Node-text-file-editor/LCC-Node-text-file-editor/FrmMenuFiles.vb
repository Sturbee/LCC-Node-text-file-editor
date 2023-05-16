
Public Class FrmMenuFiles
    Private Sub FrmMenuFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.CheckUserPreferences()

    End Sub

    Private Sub CheckUserPreferences()

        Dim clsU As New ClsUserPrefs

        If clsU.CheckUserFileDirectories > -1 Then

            Dim frm As New FrmUserJMRIfiles

            Call Me.CheckFormAndOpen(frm)

        End If

    End Sub

    Private Sub CheckFormAndOpen(frm As Form)

        If Me.OwnedForms.Length = 0 Then
            ' do nothing
        Else
            For count = 0 To Me.OwnedForms.Length - 1
                If Me.OwnedForms(count).Name = frm.Name Then
                    Beep()
                    Exit Sub
                End If
            Next
        End If

        Me.AddOwnedForm(frm)
        frm.Show()

    End Sub

    Private Sub ProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessToolStripMenuItem.Click

        Dim frm As New FrmFileBackup
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        Dim frm As New FrmFileXml
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click

        Dim frm As New FrmFileRestore
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub FileLocationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileLocationsToolStripMenuItem.Click

        Dim frm As New FrmUserJMRIfiles
        Call Me.CheckFormAndOpen(frm)

    End Sub

End Class