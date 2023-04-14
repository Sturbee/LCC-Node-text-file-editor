Imports System.IO

Public Class FrmPortLine

    Private Property MyFilePath As String

    REM Private Property MyFileName As String
    Private Property MyExport As New ClsExportXML

    Private Sub FrmLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag
        REM Me.MyFileName = Path.GetFileName(Me.Owner.Tag)

        ' read the export xml file
        MyExport.DbExportReadFile(MyFilePath)

        ' read the titles xml file set labels
        Dim clsT As New ClsTitles

        Dim rowTitle As Titles.PortTitlesRow = clsT.Titles.PortTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblLine.Text = rowTitle.subHeader
        Me.LblDescription.Text = rowTitle.description

        Dim rowTitleDelay As Titles.PortDelayTitlesRow = clsT.Titles.PortDelayTitles.Item(0)
        Me.LblInterval1.Text = rowTitleDelay.interval1
        Me.LblInterval2.Text = rowTitleDelay.interval2

        Dim rowTitleEvent As Titles.PortEventTitlesRow = clsT.Titles.PortEventTitles.Item(0)
        Me.GroupBoxConsumer.Text = rowTitleEvent.consumer
        Me.LblOutFunc.Text = rowTitleEvent.outputFunction
        Me.LblOutCommd.Text = rowTitleEvent.outputCommand
        Me.GroupBoxProducer.Text = rowTitleEvent.producer
        Me.LblInFunc.Text = rowTitleEvent.inputFunction
        Me.LblInCommd.Text = rowTitleEvent.inputCommand

        ' read the attribute xml file
        Dim clsR As New ClsReport

        ' fill combo box items
        Try

            Me.CmbUnits1.BeginUpdate()
            Me.CmbUnits2.BeginUpdate()
            For I = 0 To clsR.Rpt.DelayUnit.Count - 1
                Dim row As Rpt.DelayUnitRow = clsR.Rpt.DelayUnit.Item(I)
                Me.CmbUnits1.Items.Add(row.text)
                Me.CmbUnits2.Items.Add(row.text)
            Next
            Me.CmbUnits1.EndUpdate()
            Me.CmbUnits2.EndUpdate()

            Me.CmbRetrigger1.BeginUpdate()
            Me.CmbRetrigger2.BeginUpdate()
            For I = 0 To clsR.Rpt.DelayRetrigger.Count - 1
                Dim row As Rpt.DelayRetriggerRow = clsR.Rpt.DelayRetrigger.Item(I)
                Me.CmbRetrigger1.Items.Add(row.text)
                Me.CmbRetrigger2.Items.Add(row.text)
            Next
            Me.CmbRetrigger1.EndUpdate()
            Me.CmbRetrigger2.EndUpdate()

            Me.CmbOutFunc.BeginUpdate()
            For I = 0 To clsR.Rpt.PortOutFunc.Count - 1
                Dim row As Rpt.PortOutFuncRow = clsR.Rpt.PortOutFunc.Item(I)
                Me.CmbOutFunc.Items.Add(row.text)
            Next
            Me.CmbOutFunc.EndUpdate()

            Me.CmbOutCommd.BeginUpdate()
            For I = 0 To clsR.Rpt.PortOutCommd.Count - 1
                Dim row As Rpt.PortOutCommdRow = clsR.Rpt.PortOutCommd.Item(I)
                Me.CmbOutCommd.Items.Add(row.text)
            Next
            Me.CmbOutCommd.EndUpdate()

            Me.CmbEventOutCommd1.BeginUpdate()
            For I = 0 To clsR.Rpt.PortEventCons.Count - 1
                Dim row As Rpt.PortEventConsRow = clsR.Rpt.PortEventCons.Item(I)
                Me.CmbEventOutCommd1.Items.Add(row.text)
            Next
            Me.CmbEventOutCommd1.EndUpdate()

            Me.CmbInFunc.BeginUpdate()
            For I = 0 To clsR.Rpt.PortInFunc.Count - 1
                Dim row As Rpt.PortInFuncRow = clsR.Rpt.PortInFunc.Item(I)
                Me.CmbInFunc.Items.Add(row.text)
            Next
            Me.CmbInFunc.EndUpdate()

            Me.CmbInCommd.BeginUpdate()
            For I = 0 To clsR.Rpt.PortInCommd.Count - 1
                Dim row As Rpt.PortInCommdRow = clsR.Rpt.PortInCommd.Item(I)
                Me.CmbInCommd.Items.Add(row.text)
            Next
            Me.CmbInCommd.EndUpdate()

            Me.CmbEventInCommd1.BeginUpdate()
            For I = 0 To clsR.Rpt.PortEventProd.Count - 1
                Dim row As Rpt.PortEventProdRow = clsR.Rpt.PortEventProd.Item(I)
                Me.CmbEventInCommd1.Items.Add(row.text)
            Next
            Me.CmbEventInCommd1.EndUpdate()

        Catch ex As Exception
            MsgBox("Failed to add combo box values")
            Exit Sub
        End Try

        ' line numbers are 1 to 16
        Dim lineID As Integer = 1
        Dim rowPort As ExportXml.PortRow = MyExport.DbExport.Port.FindByLineID(lineID)
        If rowPort Is Nothing Then
            MsgBox("Failed to import port row " + lineID.ToString)
            Exit Sub
        End If

        Me.LblLineNumber.Text = rowPort.LineID.ToString
        Me.TxtDescription.Text = rowPort.Description

        ' set consumer/producer combo box selected items
        Me.CmbOutFunc.SelectedIndex = rowPort.outputFunctionID
        Me.CmbOutCommd.SelectedIndex = rowPort.OutPutCommand
        Me.CmbInFunc.SelectedIndex = rowPort.inputFunctionID
        Me.CmbInCommd.SelectedIndex = rowPort.InputCommand


        For count = 1 To 2
            Dim row As ExportXml.PortDelayRow = MyExport.DbExport.PortDelay.FindByLineIDDelayID(lineID, count)

            Select Case count
                Case 1
                    Me.TxtTime1.Text = row.time
                    Me.CmbUnits1.SelectedIndex = row.timeUnitID
                    Me.CmbRetrigger1.SelectedIndex = row.retriggerID
                Case 2
                    Me.TxtTime2.Text = row.time
                    Me.CmbUnits2.SelectedIndex = row.timeUnitID
                    Me.CmbRetrigger2.SelectedIndex = row.retriggerID
            End Select

        Next

        For count = 1 To 6
            Dim row As ExportXml.PortEventRow = MyExport.DbExport.PortEvent.FindByLineIDEventID(lineID, count)
            Select Case count
                Case 1
                    Me.TxtEventOut1.Text = row.eventConsumer
                    Me.CmbEventOutCommd1.SelectedIndex = row.producerActionID
                    Me.CmbEventInCommd1.SelectedIndex = row.consumerActionID
                    Me.TxtEventIn1.Text = row.eventProducer
            End Select

        Next

    End Sub

End Class