Public Class FrmTrackSpeed

    Private Property ClsI As New ClsImportCDI
    Private Property ClsU As New ClsUserPrefs

    Private Sub FrmTrackSpeed_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayTrackSpeeds()

    End Sub

    Private Sub DisplayTrackSpeeds()

        ' populate labels with CDI values

        Try

            For count = 0 To clsI.MyImportCDI.TrackSpeed.Count - 1
                Dim row As ImportCDI.TrackSpeedRow = clsI.MyImportCDI.TrackSpeed.Item(count)
                Select Case count
                    Case 0
                        Me.Label1.Text = row.text
                    Case 1
                        Me.Label2.Text = row.text
                    Case 2
                        Me.Label3.Text = row.text
                    Case 3
                        Me.Label4.Text = row.text
                    Case 4
                        Me.Label5.Text = row.text
                    Case 5
                        Me.Label6.Text = row.text
                    Case 6
                        Me.Label7.Text = row.text
                    Case 7
                        Me.Label8.Text = row.text
                    Case Else
                        Stop
                End Select
            Next

        Catch ex As Exception
            MsgBox("Failed to display track speeds")
            Exit Sub
        End Try

        ' populate text boxes with user track speeds

        Try
            For count = 0 To ClsU.MyUserPrefs.TrackSpeed.Count - 1
                Dim row As UserPrefs.TrackSpeedRow = ClsU.MyUserPrefs.TrackSpeed.Item(count)
                Select Case count
                    Case 0
                        Me.TextBox1.Text = row.text
                    Case 1
                        Me.TextBox2.Text = row.text
                    Case 2
                        Me.TextBox3.Text = row.text
                    Case 3
                        Me.TextBox4.Text = row.text
                    Case 4
                        Me.TextBox5.Text = row.text
                    Case 5
                        Me.TextBox6.Text = row.text
                    Case 6
                        Me.TextBox7.Text = row.text
                    Case 7
                        Me.TextBox8.Text = row.text
                    Case Else
                        Stop
                End Select
            Next

        Catch ex As Exception
            MsgBox("Failed to display user track speeds")
            Exit Sub
        End Try

    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click

        Try

            For count = 0 To ClsU.MyUserPrefs.TrackSpeed.Count - 1
                Dim row As UserPrefs.TrackSpeedRow = ClsU.MyUserPrefs.TrackSpeed.Item(count)
                Select Case count
                    Case 0
                        row.text = Me.TextBox1.Text
                    Case 1
                        row.text = Me.TextBox2.Text
                    Case 2
                        row.text = Me.TextBox3.Text
                    Case 3
                        row.text = Me.TextBox4.Text
                    Case 4
                        row.text = Me.TextBox5.Text
                    Case 5
                        row.text = Me.TextBox6.Text
                    Case 6
                        row.text = Me.TextBox7.Text
                    Case 7
                        row.text = Me.TextBox8.Text
                    Case Else
                        Stop
                End Select

                ClsU.TrackSpeedRowChange(row.value, row.text)

            Next

            ClsU.UserPrefsXmlSave()

            MsgBox("Saved your track speeds")

        Catch ex As Exception

            MsgBox("Failed to save your track speeds")

        End Try

    End Sub

End Class