Public Class FrmUserTrackSpeed

#Disable Warning IDE0044 ' Add readonly modifier
    Dim LblValues(7) As Label
    Dim TxtValues(7) As TextBox
#Enable Warning IDE0044 ' Add readonly modifier
    Private Property MyUser As New ClsUserPrefs

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' populate labels with CDI values

        Dim clsI As New ClsImportCDI

        Try

            For count = 0 To clsI.ImportCDI.TrackSpeed.Count - 1

                Dim MyLabel As New Label With {
                    .Left = 10,
                    .Top = 10 + (25 * count),
                    .Width = 120
                }

                Dim row As ImportCDI.TrackSpeedRow = clsI.ImportCDI.TrackSpeed.Item(count)
                MyLabel.Text = row.text

                Me.LblValues(count) = MyLabel

                Me.Controls.Add(LblValues(count))

            Next

        Catch ex As Exception
            MsgBox("Failed to display track speeds")
            Exit Sub
        End Try

        MyUser.UserPrefsXmlRead()

        ' populate text boxes with user track speeds

        Try
            For count = 0 To MyUser.UserPrefs.TrackSpeed.Count - 1

                Dim MyTextBox As New TextBox With {
                    .Left = 150,
                    .Top = 10 + (25 * count),
                    .Width = 120
                }

                Dim row As UserPrefs.TrackSpeedRow = MyUser.UserPrefs.TrackSpeed.Item(count)
                MyTextBox.Text = row.text

                Me.TxtValues(count) = MyTextBox

                Me.Controls.Add(TxtValues(count))

            Next

        Catch ex As Exception
            MsgBox("Failed to display user track speeds")
            Exit Sub
        End Try

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try

            For count = 0 To MyUser.UserPrefs.TrackSpeed.Count - 1
                Dim row As UserPrefs.TrackSpeedRow = MyUser.UserPrefs.TrackSpeed.FindByvalue(count)
                row.text = Me.TxtValues(count).Text
            Next

            MyUser.UserPrefsXmlWrite()
            MsgBox("Saved your track speed values")

            ' need to reload after save
            MyUser.UserPrefsXmlRead()

            Call Me.DisplayValues()

        Catch ex As Exception

            MsgBox("Failed to save your track speed values")

        End Try

    End Sub

End Class