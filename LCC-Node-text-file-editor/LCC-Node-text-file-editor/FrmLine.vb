Public Class FrmLine
    Private Property MyImport As New ExportXml
    Private Sub FrmLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' set labels
        Dim rowTitle As Titles.PortTitlesRow = dsTitles.PortTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblLine.Text = rowTitle.port
        Me.LblDescription.Text = rowTitle.description

        Dim rowTitleDelay As Titles.PortDelayTitlesRow = dsTitles.PortDelayTitles.Item(0)
        Me.LblInterval1.Text = rowTitleDelay.interval1
        Me.LblInterval2.Text = rowTitleDelay.interval2

        Dim rowTitleEvent As Titles.PortEventTitlesRow = dsTitles.PortEventTitles.Item(0)
        Me.GroupBoxConsumer.Text = rowTitleEvent.consumer
        Me.LblOutFunc.Text = rowTitleEvent.outputFunction
        Me.LblOutCommd.Text = rowTitleEvent.outputCommand
        Me.GroupBoxProducer.Text = rowTitleEvent.producer
        Me.LblInFunc.Text = rowTitleEvent.inputFunction
        Me.LblInCommd.Text = rowTitleEvent.inputCommand

        ' read the attribute xml file
        Dim clsR As New ClsReport
        Dim dsRpt As Rpt = clsR.MyReport

        ' fill combo box items
        Try

            Me.CmbUnits1.BeginUpdate()
            Me.CmbUnits2.BeginUpdate()
            For I = 0 To dsRpt.DelayUnit.Count - 1
                Dim row As Rpt.DelayUnitRow = dsRpt.DelayUnit.Item(I)
                Me.CmbUnits1.Items.Add(row.text)
                Me.CmbUnits2.Items.Add(row.text)
            Next
            Me.CmbUnits1.EndUpdate()
            Me.CmbUnits2.EndUpdate()

            Me.CmbRetrigger1.BeginUpdate()
            Me.CmbRetrigger2.BeginUpdate()
            For I = 0 To dsRpt.DelayRetrigger.Count - 1
                Dim row As Rpt.DelayRetriggerRow = dsRpt.DelayRetrigger.Item(I)
                Me.CmbRetrigger1.Items.Add(row.text)
                Me.CmbRetrigger2.Items.Add(row.text)
            Next
            Me.CmbRetrigger1.EndUpdate()
            Me.CmbRetrigger2.EndUpdate()

            Me.CmbOutFunc.BeginUpdate()
            For I = 0 To dsRpt.PortOutFunc.Count - 1
                Dim row As Rpt.PortOutFuncRow = dsRpt.PortOutFunc.Item(I)
                Me.CmbOutFunc.Items.Add(row.text)
            Next
            Me.CmbOutFunc.EndUpdate()

            Me.CmbOutCommd.BeginUpdate()
            For I = 0 To dsRpt.PortOutCommd.Count - 1
                Dim row As Rpt.PortOutCommdRow = dsRpt.PortOutCommd.Item(I)
                Me.CmbOutCommd.Items.Add(row.text)
            Next
            Me.CmbOutCommd.EndUpdate()

            Me.CmbEventOutCommd1.BeginUpdate()
            For I = 0 To dsRpt.PortEventCons.Count - 1
                Dim row As Rpt.PortEventConsRow = dsRpt.PortEventCons.Item(I)
                Me.CmbEventOutCommd1.Items.Add(row.text)
            Next
            Me.CmbEventOutCommd1.EndUpdate()

            Me.CmbInFunc.BeginUpdate()
            For I = 0 To dsRpt.PortInFunc.Count - 1
                Dim row As Rpt.PortInFuncRow = dsRpt.PortInFunc.Item(I)
                Me.CmbInFunc.Items.Add(row.text)
            Next
            Me.CmbInFunc.EndUpdate()

            Me.CmbInCommd.BeginUpdate()
            For I = 0 To dsRpt.PortInCommd.Count - 1
                Dim row As Rpt.PortInCommdRow = dsRpt.PortInCommd.Item(I)
                Me.CmbInCommd.Items.Add(row.text)
            Next
            Me.CmbInCommd.EndUpdate()

            Me.CmbEventInCommd1.BeginUpdate()
            For I = 0 To dsRpt.PortEventProd.Count - 1
                Dim row As Rpt.PortEventProdRow = dsRpt.PortEventProd.Item(I)
                Me.CmbEventInCommd1.Items.Add(row.text)
            Next
            Me.CmbEventInCommd1.EndUpdate()

        Catch ex As Exception
            MsgBox("Failed to add combo box values")
            Exit Sub
        End Try


        Dim myFileName As String = "EditTest.xml"

        ' reads the export xml file
        Try
            Me.MyImport.ReadXml(myFileName)
        Catch ex As Exception
            MsgBox("Failed to read file " + myFileName)
            Exit Sub
        End Try

        ' line numbers are 1 to 16
        Dim lineID As Integer = 1
        Dim rowPort As ExportXml.PortRow = Me.MyImport.Port.FindByLineID(lineID)
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
            Dim row As ExportXml.PortDelayRow = Me.MyImport.PortDelay.FindByLineIDDelayID(lineID, count)

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
            Dim row As ExportXml.PortEventRow = Me.MyImport.PortEvent.FindByLineIDEventID(lineID, count)
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