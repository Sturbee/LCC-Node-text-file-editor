Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayMeunu()

    End Sub

    Private Sub DisplayMeunu()

        ' poulate menu strip

        Try

            For count = 1 To 6

                Dim MyToolStripItem As New ToolStripMenuItem With {
                    .Width = 90,
                    .AutoSize = False,
                    .CheckOnClick = True,
                    .Text = "Event (" + count.ToString + ")"
                }

                Me.MenuStrip1.Items.Add(MyToolStripItem)

            Next
        Catch ex As Exception

            MsgBox("Failed to populate menu strip")
            Exit Sub

        End Try

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

        MsgBox("Clicked on " + e.ClickedItem.Text)

    End Sub

End Class