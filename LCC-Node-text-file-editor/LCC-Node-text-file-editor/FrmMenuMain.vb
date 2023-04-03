Public Class FrmMenuMain
    Private Sub FrmMenuMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.CheckUserPreferences()

    End Sub

    Private Sub CheckUserPreferences()

        Dim clsU As New ClsUserPrefs

        If clsU.CheckUserFileDirectories > -1 Then

            Dim frm As New FrmUserPrefs
            Me.AddOwnedForm(frm)

            frm.Show()

        End If

    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        ' form userprefs
        MsgBox("Clicked on form UserPrefs")

    End Sub

    Private Sub TrackSpeedsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrackSpeedsToolStripMenuItem.Click

        ' form track speeds
        MsgBox("Clicked on form Track Speeds")

    End Sub

End Class