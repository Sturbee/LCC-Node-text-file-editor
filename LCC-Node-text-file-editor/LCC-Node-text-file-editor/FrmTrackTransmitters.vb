Imports System.IO

Public Class FrmTrackTransmitters

    Public Property MyTrackCircuits As Integer
    Private Property MyFilePath As String
    REM Private Property MyFileName As String
    Private Property MyExport As New ClsExportXML

    Private Sub FrmTrackTransmitters_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        REM Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        ' read the titles xml file
        Dim clsT As New ClsTitles

        ' set labels
        Dim rowTitle As Titles.TrackTranTitlesRow = clsT.Titles.TrackTranTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp1.Text = rowTitle.help1
        Me.LblHelp2.Text = rowTitle.help2

        ' read the attribute xml file
        REM Dim clsR As New ClsReport

        ' read the export xml file
        MyExport.ExportXmlRead(MyFilePath)

        ' populate tab control
        Try

            Me.TabControlTransmitters.Controls.Clear()

            For count = 1 To Me.MyTrackCircuits

                Dim row As ExportXml.TrackTransmitterRow = MyExport.ExportXML.TrackTransmitter.FindByCircuitID(count)

                Dim circuit As String = String.Empty
                If row.description.Length = 0 Then
                    circuit = rowTitle.subHeader
                Else
                    circuit = row.description
                End If

                Dim MyTabPage As New TabPage With {
                .Text = count.ToString + " - " + circuit
                }

                Me.TabControlTransmitters.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception
            MsgBox("Failed to populate tab control")
            Exit Sub
        End Try

    End Sub

    Private Sub TabControlTransmitters_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlTransmitters.Selected

        Dim circuitID As Integer

        If e.TabPageIndex = -1 Then
            circuitID = 1
        Else
            circuitID = e.TabPageIndex + 1
        End If
        ' fill in row values
        Dim row As ExportXml.TrackTransmitterRow = MyExport.ExportXML.TrackTransmitter.FindByCircuitID(circuitID)
        Me.TxtDescription.Text = row.description
        Me.TxtLinkEvent.Text = row.eventAddress

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try
            Dim row As ExportXml.TrackTransmitterRow = MyExport.ExportXML.TrackTransmitter.FindByCircuitID(Me.TabControlTransmitters.SelectedIndex + 1)
            row.description = Me.TxtDescription.Text
            row.eventAddress = Me.TxtLinkEvent.Text

            MyExport.ExportXML.WriteXml(MyFilePath)
            MsgBox("Saved changes to track transmitter values")

            ' need to reload after save
            MyExport.ExportXmlRead(MyFilePath)

            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save track transmitter circuit values")
            Exit Sub
        End Try

    End Sub

End Class