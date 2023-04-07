﻿Imports System.IO

Public Class FrmTrackReceivers

    Public Property MyTrackCircuits As Integer
    Private Property MyFilePath As String
    Private Property MyFileName As String
    Private Property MyExportXml As New ExportXml

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
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp1.Text = rowTitle.help1
        Me.LblHelp2.Text = rowTitle.help2

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

            Me.TabControlReceivers.Controls.Clear()

            For count = 1 To Me.MyTrackCircuits

                Dim row As ExportXml.TrackReceiverRow = Me.MyExportXml.TrackReceiver.FindByCircuitID(count)

                Dim circuit As String = String.Empty
                If row.description.Length = 0 Then
                    circuit = rowTitle.subHeader
                Else
                    circuit = row.description
                End If

                Dim MyTabPage As New TabPage With {
                .Text = count.ToString + " - " + circuit
                }

                Me.TabControlReceivers.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception
            MsgBox("Failed to populate tab control")
            Exit Sub
        End Try

    End Sub

    Private Sub TabControlReceivers_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlReceivers.Selected

        Dim circuitID As Integer

        If e.TabPageIndex = -1 Then
            circuitID = 1
        Else
            circuitID = e.TabPageIndex + 1
        End If
        ' fill in row values
        Dim row As ExportXml.TrackReceiverRow = Me.MyExportXml.TrackReceiver.FindByCircuitID(circuitID)
        Me.TxtDescription.Text = row.description
        Me.TxtLinkEvent.Text = row.eventAddress

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try
            Dim row As ExportXml.TrackReceiverRow = MyExportXml.TrackReceiver.FindByCircuitID(Me.TabControlReceivers.SelectedIndex + 1)
            row.description = Me.TxtDescription.Text
            row.eventAddress = Me.TxtLinkEvent.Text

            Me.MyExportXml.WriteXml(Me.MyFilePath)
            MsgBox("Saved changes to track receiver values")

            ' need to reload after save
            MyExportXml = New ExportXml
            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save track receiver circuit values")
            Exit Sub
        End Try

    End Sub

End Class