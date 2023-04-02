Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar

Public Class FrmTrackSpeed

    Private Property ClsI As New ClsImportCDI
    Private Property ClsU As New ClsUserPrefs

#Disable Warning IDE0044 ' Add readonly modifier
    Dim LblValues(7) As Label
    Dim TxtValues(7) As TextBox
#Enable Warning IDE0044 ' Add readonly modifier




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' populate labels with CDI values

        Try

            For count = 0 To ClsI.MyImportCDI.TrackSpeed.Count - 1

                Dim MyLabel As New Label With {
                    .Left = 10,
                    .Top = 10 + (25 * count),
                    .Width = 120
                }

                Dim row As ImportCDI.TrackSpeedRow = ClsI.MyImportCDI.TrackSpeed.Item(count)
                MyLabel.Text = row.text

                Me.LblValues(count) = MyLabel

                Me.Controls.Add(LblValues(count))

            Next

        Catch ex As Exception
            MsgBox("Failed to display track speeds")
            Exit Sub
        End Try

        ' populate text boxes with user track speeds

        Try
            For count = 0 To ClsU.MyUserPrefs.TrackSpeed.Count - 1

                Dim MyTextBox As New TextBox With {
                    .Left = 150,
                    .Top = 10 + (25 * count),
                    .Width = 120
                }

                Dim row As UserPrefs.TrackSpeedRow = ClsU.MyUserPrefs.TrackSpeed.Item(count)
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

            For count = 0 To ClsU.MyUserPrefs.TrackSpeed.Count - 1
                ClsU.TrackSpeedRowChange(count, Me.TxtValues(count).Text)
            Next

            ClsU.UserPrefsXmlSave()

            MsgBox("Saved your track speeds")

        Catch ex As Exception

            MsgBox("Failed to save your track speeds")

        End Try

    End Sub

End Class