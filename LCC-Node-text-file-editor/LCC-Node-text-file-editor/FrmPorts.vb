Public Class FrmPorts

    Public Property MyLines As Integer

    Private Sub FrmPorts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub


    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.PortTitlesRow = dsTitles.PortTitles.Item(0)
        Me.Text = rowTitle.header


        ' poulate tab control

        Try

            Me.TabControlLines.Controls.Clear()

            For count = 1 To Me.MyLines

                Dim MyTabPage As New TabPage With {
                    .Width = 90,
                    .AutoSize = False,
                    .Text = "Line" + count.ToString
                }

                Me.TabControlLines.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception

            MsgBox("Failed to populate menu strip")
            Exit Sub

        End Try

    End Sub

    Private Sub TabControlLines_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlLines.Selected

        Stop

    End Sub

End Class