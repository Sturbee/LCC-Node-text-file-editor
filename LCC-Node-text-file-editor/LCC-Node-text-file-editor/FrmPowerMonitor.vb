﻿Public Class FrmPowerMonitor

    Public Property MyFileName As String
    Public Property MySaveFile
    Private Property MyImport As New ExportXml
    Private Property MyPowerMonitorRow As ExportXml.PowerMonitorRow
    Private Property SavePowerOK As String
    Private Property SavePowerNotOK As String


    Private Sub FrmPowerMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' get App Config values
        Dim clsAppConfig As New ClassAppConfigValues
        Try
            clsAppConfig.AppConfigFileRead()
        Catch ex As Exception
            MsgBox("Failed to get config values")
            Exit Sub
        End Try

        ' read the titles xml file
        Dim dsTitles As New Titles
        Try
            dsTitles.ReadXml(clsAppConfig.SavedTitlesFile)
        Catch ex As Exception
            MsgBox("Failed to import titles")
            Exit Sub
        End Try

        Dim rowPower As Titles.PowerMonitorTitlesRow = dsTitles.PowerMonitorTitles.Item(0)
        Me.Text = rowPower.header
        Me.LblOptions.Text = rowPower.options
        Me.LblPowerOK.Text = rowPower.powerOK
        Me.LblPowerNotOK.Text = rowPower.powerNotOK


        ' read the attribute xml file
        Dim dsRpt As New Rpt
        Try
            dsRpt.ReadXml(clsAppConfig.SavedReportFile)
        Catch ex As Exception
            MsgBox("Failed to import attributes")
            Exit Sub
        End Try

        ' fill list box items
        Try
            Me.LstMessageOption.BeginUpdate()
            For I = 0 To dsRpt.MessageOption.Count - 1
                Dim rowOption As Rpt.MessageOptionRow = dsRpt.MessageOption.Item(I)
                Me.LstMessageOption.Items.Add(rowOption.text)
            Next
            Me.LstMessageOption.EndUpdate()
        Catch ex As Exception
            MsgBox("Failed to add Message Option values")
        End Try

        ' temporary
        Me.MyFileName = clsAppConfig.SavedBlankSignalFile

        Me.MyFileName = "EditTest.xml"
        Me.MySaveFile = "EditTest.xml"

        ' read the file to read and edit
        Try
            Me.MyImport.ReadXml(Me.MyFileName)
        Catch ex As Exception
            MsgBox("Failed to read file " + Me.MyFileName)
            Exit Sub
        End Try


        Me.MyPowerMonitorRow = Me.MyImport.PowerMonitor.Item(0)

        Me.LstMessageOption.SelectedIndex = Me.MyPowerMonitorRow.powerOptionID

        Me.SavePowerOK = Me.MyPowerMonitorRow.eventPowerOK
        Me.SavePowerNotOK = Me.MyPowerMonitorRow.eventPowerNotOK

        Me.TxtPowerOK.Text = Me.MyPowerMonitorRow.eventPowerOK.ToString
        Me.TxtPowerNotOK.Text = Me.MyPowerMonitorRow.eventPowerNotOK.ToString

    End Sub

    Private Sub TxtPowerOK_TextChanged(sender As Object, e As EventArgs) Handles TxtPowerOK.TextChanged

        If Me.TxtPowerOK.Text = Me.SavePowerOK Then
            ' do nothing
        Else
            MsgBox("Not recommended to change PowerOK eventID")
        End If

        Me.TxtPowerOK.Text = Me.SavePowerOK

    End Sub

    Private Sub TxtPowerNotOK_TextChanged(sender As Object, e As EventArgs) Handles TxtPowerNotOK.TextChanged

        If Me.TxtPowerNotOK.Text = Me.SavePowerNotOK Then
            ' do nothing
        Else
            MsgBox("Not recommended to change PowerNotOK eventID")
        End If

        Me.TxtPowerNotOK.Text = Me.SavePowerNotOK

    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click

        If Me.MyPowerMonitorRow Is Nothing Then
            MsgBox("Node Power Monior data missing")
            Exit Sub
        End If

        Try
            Me.MyPowerMonitorRow.powerOptionID = Me.LstMessageOption.SelectedIndex

            Me.MyImport.WriteXml(Me.MySaveFile)

            MsgBox("Saved changes to file " + Me.MySaveFile)

        Catch ex As Exception
            MsgBox("Failed to save file " + Me.MySaveFile)
        End Try

    End Sub
End Class