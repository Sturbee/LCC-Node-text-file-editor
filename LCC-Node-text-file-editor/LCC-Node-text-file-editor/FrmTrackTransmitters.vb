Imports System.IO

Public Class FrmTrackTransmitters

    Public Property MyTrackCircuits As Integer
    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml

    Private Sub FrmTrackTransmitters_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.TrackTranTitlesRow = dsTitles.TrackTranTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp.Text = rowTitle.help

        ' read the attribute xml file
        Dim clsR As New ClsReport
        Dim dsRpt As Rpt = clsR.MyReport

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        Try
            Me.MyExportXml.ReadXml(Me.MyFilePath)
        Catch ex As Exception
            MsgBox("Failed to read file " + Me.MyFileName)
            Exit Sub
        End Try

        ' populate tab control
        Try

            Me.TabControlTransmitters.Controls.Clear()

            For count = 1 To Me.MyTrackCircuits

                Dim row As ExportXml.TrackCircuitTranRow = Me.MyExportXml.TrackCircuitTran.FindByCircuitID(count)

                Dim circuit As String = String.Empty
                If row.description.Length = 0 Then
                    circuit = rowTitle.subHeader + Space(1) + count.ToString
                Else
                    circuit = row.description
                End If

                Dim MyTabPage As New TabPage With {
                .Text = circuit
                }

                Me.TabControlTransmitters.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception
            MsgBox("Failed to populate tab control")
            Exit Sub
        End Try

    End Sub

    Private Sub TabControlTransmitters_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlTransmitters.Selected

        ' Stop

    End Sub

End Class