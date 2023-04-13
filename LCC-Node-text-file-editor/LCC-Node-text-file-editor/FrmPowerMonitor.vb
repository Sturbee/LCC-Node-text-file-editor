﻿Imports System.IO

Public Class FrmPowerMonitor
    Public Property MyFileName As String
    Public Property MyFilePath
    Private Property MyExport As New ClsExportXML

    Private Sub FrmPowerMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim rowPower As Titles.PowerMonitorTitlesRow = clsT.Titles.PowerMonitorTitles.Item(0)
        Me.Text = rowPower.header
        Me.LblOptions.Text = rowPower.options
        Me.LblPowerOK.Text = rowPower.powerOK
        Me.LblPowerNotOK.Text = rowPower.powerNotOK

        ' read the attribute xml file
        Dim clsR As New ClsReport

        ' read the export xml file
        MyExport.ExportXmlRead(MyFilePath)

        ' fill combobox
        Try
            Me.CmbOption.BeginUpdate()
            For I = 0 To clsR.Rpt.MessageOption.Count - 1
                Dim rowOption As Rpt.MessageOptionRow = clsR.Rpt.MessageOption.Item(I)
                Me.CmbOption.Items.Add(rowOption.text)
            Next
            Me.CmbOption.EndUpdate()
        Catch ex As Exception
            MsgBox("Failed to fill Message Option values")
            Exit Sub
        End Try


        Dim powerMonitorRow = MyExport.ExportXML.PowerMonitor.Item(0)

        Me.CmbOption.SelectedIndex = powerMonitorRow.powerOptionID

        Me.TxtPowerOK.Text = powerMonitorRow.eventPowerOK
        Me.TxtPowerNotOK.Text = powerMonitorRow.eventPowerNotOK

    End Sub


    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click

        Try
            Dim pwrRow As ExportXml.PowerMonitorRow = MyExport.ExportXML.PowerMonitor.Item(0)
            pwrRow.powerOptionID = Me.CmbOption.SelectedIndex
            pwrRow.eventPowerOK = Me.TxtPowerOK.Text
            pwrRow.eventPowerNotOK = Me.TxtPowerNotOK.Text

            MyExport.ExportXML.WriteXml(MyFilePath)
            MsgBox("Saved changes to power monitor values")

            ' need to reload after save
            MyExport.ExportXmlRead(MyFilePath)
            Call Me.DisplayValues()

            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save power monitor values")
        End Try

    End Sub

End Class