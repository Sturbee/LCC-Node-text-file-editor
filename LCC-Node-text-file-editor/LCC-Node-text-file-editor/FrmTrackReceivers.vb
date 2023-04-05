Public Class FrmTrackReceivers

    Public Property MyTrackCircuits As Integer

    Private Sub FrmTrackReceivers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.TrackRecTitlesRow = dsTitles.TrackRecTitles.Item(0)
        Me.Text = rowTitle.header

    End Sub

End Class