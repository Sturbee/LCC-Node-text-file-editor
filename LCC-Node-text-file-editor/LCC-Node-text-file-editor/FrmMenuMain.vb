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


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        ' check to see if form already opened

        Dim frm As New FrmUserPrefs

        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub TrackSpeedsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrackSpeedsToolStripMenuItem.Click

        Dim frm As New FrmTrackSpeed

        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        Dim frm As New FrmLamp

        Call Me.CheckFormAndOpen(frm)

    End Sub

End Class