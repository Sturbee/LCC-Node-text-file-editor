
Public Class FrmUserTrackSpeed


#Disable Warning IDE0044 ' Add readonly modifier
    Dim LblValues(7) As Label
    Dim TxtValues(7) As TextBox
#Enable Warning IDE0044 ' Add readonly modifier

    Private Property MyUserPrefsFilePath As String
    Private Property MyUserPrefs As New UserPrefs


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' populate labels with CDI values

        Dim clsI As New ClsImportCDI

        Try

            For count = 0 To clsI.MyImportCDI.TrackSpeed.Count - 1

                Dim MyLabel As New Label With {
                    .Left = 10,
                    .Top = 10 + (25 * count),
                    .Width = 120
                }

                Dim row As ImportCDI.TrackSpeedRow = clsI.MyImportCDI.TrackSpeed.Item(count)
                MyLabel.Text = row.text

                Me.LblValues(count) = MyLabel

                Me.Controls.Add(LblValues(count))

            Next

        Catch ex As Exception
            MsgBox("Failed to display track speeds")
            Exit Sub
        End Try


        ' populate text boxes with user track speeds

        Dim clsU As New ClsUserPrefs
        MyUserPrefsFilePath = clsU.UserPrefsFileName
        MyUserPrefs = clsU.MyUserPrefs

        Try
            For count = 0 To MyUserPrefs.TrackSpeed.Count - 1

                Dim MyTextBox As New TextBox With {
                    .Left = 150,
                    .Top = 10 + (25 * count),
                    .Width = 120
                }

                Dim row As UserPrefs.TrackSpeedRow = MyUserPrefs.TrackSpeed.Item(count)
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

            For count = 0 To MyUserPrefs.TrackSpeed.Count - 1
                Dim row As UserPrefs.TrackSpeedRow = MyUserPrefs.TrackSpeed.FindByvalue(count)
                row.text = Me.TxtValues(count).Text
            Next

            Me.MyUserPrefs.WriteXml(Me.MyUserPrefsFilePath)
            MsgBox("Saved your track speed values")

            ' need to reload after save
            MyUserPrefs = New UserPrefs
            Call Me.DisplayValues()

        Catch ex As Exception

            MsgBox("Failed to save your track speed values")

        End Try

    End Sub

End Class