Public Class FrmControlArray

    Dim lblValues(7) As Label

    Dim txtValues(7) As TextBox

    Dim intCount As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' populate fornm labels

        For intCount = 0 To 7

            Dim MyLabel As New Label

            MyLabel.Left = 10
            MyLabel.Top = 10 + (25 * intCount)
            MyLabel.Width = 50

            MyLabel.Text = intCount.ToString

            Me.lblValues(intCount) = MyLabel

            Me.Controls.Add(lblValues(intCount))

        Next

        ' populate form text boxes

        For intCount = 0 To 7

            Dim MyTextBox As New TextBox

            MyTextBox.Left = 100
            MyTextBox.Top = 10 + (25 * intCount)
            MyTextBox.Width = 100

            MyTextBox.Text = intCount.ToString

            Me.txtValues(intCount) = MyTextBox

            Me.Controls.Add(txtValues(intCount))

        Next

    End Sub

End Class