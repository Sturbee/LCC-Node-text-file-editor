Imports System.IO

Public Class FrmPowerMonitor
    Public Property MyFileName As String
    Public Property MyFilePath
    Private Property MyImport As New ExportXml
    Private Property MyPowerMonitorRow As ExportXml.PowerMonitorRow
    Private Property SavePowerOK As String
    Private Property SavePowerNotOK As String


    Private Sub FrmPowerMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        Dim rowPower As Titles.PowerMonitorTitlesRow = dsTitles.PowerMonitorTitles.Item(0)
        Me.Text = rowPower.header
        Me.LblOptions.Text = rowPower.options
        Me.LblPowerOK.Text = rowPower.powerOK
        Me.LblPowerNotOK.Text = rowPower.powerNotOK


        ' read the attribute xml file
        Dim clsR As New ClsReport
        Dim dsRpt As Rpt = clsR.MyReport

        ' fill combobox
        Try
            Me.CmbOption.BeginUpdate()
            For I = 0 To dsRpt.MessageOption.Count - 1
                Dim rowOption As Rpt.MessageOptionRow = dsRpt.MessageOption.Item(I)
                Me.CmbOption.Items.Add(rowOption.text)
            Next
            Me.CmbOption.EndUpdate()
        Catch ex As Exception
            MsgBox("Failed to fill Message Option values")
            Exit Sub
        End Try

        ' read the file to read and edit
        Try
            Me.MyImport.ReadXml(Me.MyFilePath)
        Catch ex As Exception
            MsgBox("Failed to read file " + Me.MyFileName)
            Exit Sub
        End Try


        Me.MyPowerMonitorRow = Me.MyImport.PowerMonitor.Item(0)

        Me.CmbOption.SelectedIndex = Me.MyPowerMonitorRow.powerOptionID

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
            Me.MyPowerMonitorRow.powerOptionID = Me.CmbOption.SelectedIndex

            Me.MyImport.WriteXml(Me.MyFilePath)

            MsgBox("Saved changes to file " + Me.MyFileName)

        Catch ex As Exception
            MsgBox("Failed to save file " + Me.MyFileName)
        End Try

    End Sub

End Class