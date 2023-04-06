Imports System.IO

Public Class ClassExportXmlToCsv

    Public Sub ExportToCvsFile(filePath As String)

        ' get the input file data

        Dim fileXML As String = filePath + ".xml"

        If My.Computer.FileSystem.FileExists(fileXML) = False Then
            MessageBox.Show("Input file Not Found: " & fileXML)
            Exit Sub
        End If

        Dim dsInput As New ExportXml

        Try
            dsInput.ReadXml(fileXML)
        Catch ex As Exception
            MsgBox("Failed to read input file " + fileXML)
            Exit Sub
        End Try

        ' get report xml file
        Dim clsR As New ClsReport
        Dim dsReport As Rpt = clsR.MyReport

        ' get titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        ' get importCDI xml file
        Dim clsI As New ClsImportCDI
        Dim dsImport As ImportCDI = clsI.MyImportCDI

        Try

            Dim clsU As New ClsUserPrefs
            Dim dsUser As UserPrefs = clsU.MyUserPrefs
            dsUser.AcceptChanges()

            dsImport.TrackSpeed.Merge(dsUser.TrackSpeed)
            dsImport.AcceptChanges()

        Catch ex As Exception
            MsgBox("Failed to merge import with user")
        End Try


        Dim writer As StreamWriter = File.CreateText(filePath + ".csv")


        ' output Node table
        Call Me.ReportNodeTable(dsInput, writer)

        ' output PowerMonitor table
        Call Me.ReportPowerMonitorTable(dsInput, writer)

        ' output Port I/O table
        Call Me.ReportPortTable(dsInput, writer)

        ' output Logic table
        Call Me.ReportLogicTable(dsInput, dsReport, dsTitles, writer)

        Try

            writer.Close()

            MsgBox("CSV file has been created for file " + filePath)

        Catch ex As Exception

            MsgBox("Failed to close csv writer")

        End Try

    End Sub

    Private Sub ReportNodeTable(dsInput As ExportXml, writer As StreamWriter)

        Dim comma As String = ","

        Try

            ' read Node table rows and export to cvs file

            For countTable = 0 To dsInput.Node.Count - 1

                Dim rowTable As ExportXml.NodeRow = dsInput.Node.Item(countTable)
                Dim lineReport As String = String.Empty
                Dim lineRow As String = String.Empty

                For countRow = 0 To rowTable.ItemArray.Count - 1

                    Dim formatType As Integer
                    Dim columnName As String = dsInput.Node.Columns(countRow).ColumnName
                    Dim columnValue As String = rowTable.Item(countRow).ToString
                    Dim reportTitle As String = String.Empty
                    Dim attributeText As String = String.Empty

                    Stop
                    Dim rowReport As Titles.PortTitlesRow = Nothing
                    If rowReport Is Nothing Then
                        formatType = 2
                        reportTitle = columnName
                    Else

                    End If

                    Stop
                    If IsNumeric(columnValue) Then
                        ' get the attribute values for each value in rowNode
                        Dim rowAttribute As String = String.Empty
                        If rowAttribute Is Nothing Then
                            attributeText = "<" + columnValue.ToString + ">"
                            If countRow > 1 Then Stop
                        Else
                            REM attributeText = rowAttribute.text
                        End If
                    End If

                    Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                Next

                Console.WriteLine(lineReport)
                Console.WriteLine(lineRow)

                writer.WriteLine(lineReport)
                writer.WriteLine(lineRow)
                writer.WriteLine(comma)

            Next ' node row

        Catch ex As Exception

            MsgBox("Failed to write csv text line")

        End Try

    End Sub


    Private Sub ReportPowerMonitorTable(dsInput As ExportXml, writer As StreamWriter)

        Dim comma As String = ","

        Try

            ' read Power Monitor table rows and export to cvs file

            For countTable = 0 To dsInput.PowerMonitor.Count - 1

                Dim rowTable As ExportXml.PowerMonitorRow = dsInput.PowerMonitor.Item(countTable)
                Dim lineReport As String = String.Empty
                Dim lineRow As String = String.Empty

                For countRow = 0 To rowTable.ItemArray.Count - 1

                    Dim formatType As Integer
                    Dim columnName As String = dsInput.PowerMonitor.Columns(countRow).ColumnName
                    Dim columnValue As String = rowTable.Item(countRow).ToString
                    Dim reportTitle As String = String.Empty
                    Dim attributeText As String = String.Empty

                    Stop
                    Dim rowReport As String = String.Empty
                    If rowReport Is Nothing Then
                        formatType = 2
                        reportTitle = columnName
                    Else
                        REM formatType = rowReport.formatType
                        REM reportTitle = rowReport.title
                    End If

                    If IsNumeric(columnValue) Then
                        ' get the attribute values for each value in rowNode
                        Stop
                        Dim rowAttribute As String = String.Empty
                        If rowAttribute Is Nothing Then
                            attributeText = "<" + columnValue.ToString + ">"
                            If countRow > 1 Then Stop
                        Else
                            REM attributeText = rowAttribute.text
                        End If
                    End If

                    Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                Next

                Console.WriteLine(lineReport)
                Console.WriteLine(lineRow)

                writer.WriteLine(lineReport)
                writer.WriteLine(lineRow)
                writer.WriteLine(comma)

            Next ' power monitor row

        Catch ex As Exception

            MsgBox("Failed to write csv text line")

        End Try

    End Sub

    Private Sub ReportPortTable(dsInput As ExportXml, writer As StreamWriter)

        Dim comma As String = ","

        Try

            ' read Port table rows and export to cvs file

            For countTable = 0 To dsInput.Port.Count - 1

                Dim rowTable As ExportXml.PortRow = dsInput.Port.Item(countTable)
                Dim lineReport As String = String.Empty
                Dim lineRow As String = String.Empty

                For countRow = 0 To rowTable.ItemArray.Count - 1

                    Dim formatType As Integer
                    Dim columnName As String = dsInput.Port.Columns(countRow).ColumnName
                    Dim columnValue As String = rowTable.Item(countRow).ToString
                    Dim reportTitle As String = String.Empty
                    Dim attributeText As String = String.Empty

                    Dim rowReport As String = String.Empty
                    If rowReport Is Nothing Then
                        formatType = 2
                        reportTitle = columnName
                    Else
                        REM formatType = rowReport.formatType
                        REM reportTitle = rowReport.title
                    End If

                    If IsNumeric(columnValue) Then
                        ' get the attribute values for each value in rowNode
                        Stop
                        Dim rowAttribute As String = String.Empty
                        If rowAttribute Is Nothing Then
                            attributeText = "<" + columnValue.ToString + ">"
                            If countRow > 2 Then Stop
                        Else
                            REM attributeText = rowAttribute.title
                        End If
                    End If

                    Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                Next

                Console.WriteLine(lineReport)
                Console.WriteLine(lineRow)

                writer.WriteLine(lineReport)
                writer.WriteLine(lineRow)
                writer.WriteLine(comma)

                ' write port delay info
                Call Me.ReportPortDelayTable(rowTable.LineID, dsInput, writer)
                writer.WriteLine(comma)

                Call Me.ReportPortEventTable(rowTable.LineID, dsInput, writer)
                writer.WriteLine(comma)

            Next ' port row

        Catch ex As Exception

            MsgBox("Failed to write Port line")

        End Try

    End Sub


    Private Sub ReportPortDelayTable(portID As Integer, dsInput As ExportXml, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read PortDelay table rows and export to cvs file

            For countTable = 0 To dsInput.PortDelay.Count - 1

                Dim rowTable As ExportXml.PortDelayRow = dsInput.PortDelay.Item(countTable)

                If rowTable.LineID = portID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = dsInput.PortDelay.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As String = String.Empty
                        If rowReport Is Nothing Then
                            formatType = 2
                            reportTitle = columnName
                        Else
                            REM formatType = rowReport.formatType
                            REM reportTitle = rowReport.title
                        End If

                        If IsNumeric(columnValue) Then
                            ' get the attribute values for each value in rowNode
                            Stop
                            Dim rowAttribute As String = String.Empty
                            If rowAttribute Is Nothing Then
                                attributeText = "<" + columnValue.ToString + ">"
                                If countRow > 4 Then Stop
                            Else
                                REM attributeText = rowAttribute.title
                            End If
                        End If

                        Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                    Next

                    Console.WriteLine(lineReport)
                    Console.WriteLine(lineRow)

                    If header Then
                        writer.WriteLine(lineReport)
                        header = False
                    End If

                    writer.WriteLine(lineRow)

                End If

            Next ' port delay row

        Catch ex As Exception

            MsgBox("Failed to write PortDelay line")

        End Try

    End Sub


    Private Sub ReportPortEventTable(portID As Integer, dsInput As ExportXml, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read PortEvent table rows and export to cvs file

            For countTable = 0 To dsInput.PortEvent.Count - 1

                Dim rowTable As ExportXml.PortEventRow = dsInput.PortEvent.Item(countTable)

                If rowTable.LineID = portID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = dsInput.PortEvent.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As String = String.Empty
                        If rowReport Is Nothing Then
                            formatType = 2
                            reportTitle = columnName
                        Else
                            REM formatType = rowReport.formatType
                            REM reportTitle = rowReport.title
                        End If

                        If IsNumeric(columnValue) Then
                            ' get the attribute values for each value in rowNode
                            Dim rowAttribute As String = String.Empty
                            If rowAttribute Is Nothing Then
                                attributeText = "<" + columnValue.ToString + ">"
                                If countRow > 3 Then Stop
                            Else
                                REM attributeText = rowAttribute.title
                            End If
                        End If

                        Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                    Next

                    Console.WriteLine(lineReport)
                    Console.WriteLine(lineRow)

                    If header Then
                        writer.WriteLine(lineReport)
                        header = False
                    End If

                    writer.WriteLine(lineRow)

                End If

            Next ' port event row

        Catch ex As Exception

            MsgBox("Failed to write Port Event line")

        End Try

    End Sub


    Private Sub ReportLogicTable(dsInput As ExportXml, dsReport As Rpt, dsTitles As Titles, writer As StreamWriter)

        Dim comma As String = ","

        Try

            ' read Logic table rows and export to cvs file

            For countTable = 0 To dsInput.Logic.Count - 1

                Dim rowTable As ExportXml.LogicRow = dsInput.Logic.Item(countTable)
                Dim lineReport As String = String.Empty
                Dim lineRow As String = String.Empty

                For countRow = 0 To rowTable.ItemArray.Count - 1

                    Dim formatType As Integer
                    Dim columnName As String = dsInput.Logic.Columns(countRow).ColumnName
                    Dim columnValue As String = rowTable.Item(countRow).ToString
                    Dim reportTitle As String = String.Empty
                    Dim attributeText As String = String.Empty

                    Dim rowReport As Titles.LogicTitleRow = dsTitles.LogicTitle(countRow)
                    If rowReport Is Nothing Then
                        formatType = 2
                        reportTitle = columnName
                    Else
                        formatType = rowReport.formatType
                        reportTitle = rowReport.title
                    End If

                    If IsNumeric(columnValue) Then
                        ' get the attribute values for each value in rowNode
                        Dim rowAttribute As Rpt.LogicFunctionRow = dsReport.LogicFunction.FindByvalue(columnValue)
                        If rowAttribute Is Nothing Then
                            attributeText = "<" + columnValue.ToString + ">"
                            If countRow > 2 Then Stop
                        Else
                            attributeText = rowAttribute.text
                        End If
                    End If

                    Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                Next

                Console.WriteLine(lineReport)
                Console.WriteLine(lineRow)

                writer.WriteLine(lineReport)
                writer.WriteLine(lineRow)
                writer.WriteLine(comma)

                ' write logic operation info
                Call Me.ReportLogicOperationTable(rowTable.LogicID, dsInput, dsTitles, writer)
                writer.WriteLine(comma)

                Call Me.ReportLogicActionTable(rowTable.LogicID, dsInput, dsReport, dsTitles, writer)
                writer.WriteLine(comma)

                Call Me.ReportLogicProducerTable(rowTable.LogicID, dsInput, dsTitles, writer)
                writer.WriteLine(comma)

            Next ' logic row

        Catch ex As Exception

            MsgBox("Failed to write Logic line")

        End Try

    End Sub

    Private Sub ReportLogicOperationTable(LogicID As Integer, dsInput As ExportXml, dsTitles As Titles, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read Logic Operation table rows and export to cvs file

            For countTable = 0 To dsInput.LogicOperation.Count - 1

                Dim rowTable As ExportXml.LogicOperationRow = dsInput.LogicOperation.Item(countTable)

                Dim destFlag1 As Integer = -1
                Dim destFlag2 As Integer = -1

                If rowTable.LogicID = LogicID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = dsInput.LogicOperation.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As Titles.LogicOperationTitleRow = dsTitles.LogicOperationTitle.FindBycolumnID(countRow)
                        If rowReport Is Nothing Then
                            formatType = 2
                            reportTitle = columnName
                        Else
                            formatType = rowReport.formatType
                            reportTitle = rowReport.title
                        End If

                        If IsNumeric(columnValue) Then
                            ' get the attribute values for each value in rowNode
                            Stop
                            Dim rowAttribute As Rpt.LogicProducerRow = Nothing
                            If rowAttribute Is Nothing Then
                                attributeText = "<" + columnValue.ToString + ">"

                                Select Case countRow
                                    Case 4, 10 ' source1, source2
                                        Dim rowTrackCircuit As ExportXml.TrackReceiverRow = dsInput.TrackReceiver.FindByCircuitID(columnValue)
                                        If rowTrackCircuit Is Nothing Then
                                            ' do nothing
                                            Stop
                                        Else
                                            attributeText = rowTrackCircuit.description
                                        End If

                                        If countRow = 4 Then
                                            destFlag1 = columnValue
                                        ElseIf countRow = 10 Then
                                            destFlag2 = columnValue
                                        End If

                                    Case 5, 11 ' trackSpeed1, trackSpeed2
                                        Dim rowTrackSpeed As ImportCDI.TrackSpeedRow = Nothing ' dsReport.TrackSpeed.FindByvalue(columnValue)
                                        If rowTrackSpeed Is Nothing Then
                                            ' do nothing
                                            Stop
                                        Else
                                            attributeText = rowTrackSpeed.text
                                        End If

                                End Select

                            Else
                                attributeText = rowAttribute.text
                            End If
                        End If

                        Select Case countRow
                            Case 5 ' track speed V1
                                If destFlag1 = 0 Then
                                    columnValue = String.Empty
                                    attributeText = String.Empty
                                End If

                            Case 6, 7 '  V1 set True, V1 set False
                                If destFlag1 > 0 Then
                                    columnValue = String.Empty
                                    attributeText = String.Empty
                                End If

                            Case 11 ' track speed V2
                                If destFlag2 = 0 Then
                                    columnValue = String.Empty
                                    attributeText = String.Empty
                                End If

                            Case 12, 13 ' V2 set True, V2 set False
                                If destFlag2 > 0 Then
                                    columnValue = String.Empty
                                    attributeText = String.Empty
                                End If

                        End Select

                        Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                    Next

                    Console.WriteLine(lineReport)
                    Console.WriteLine(lineRow)

                    If header Then
                        writer.WriteLine(lineReport)
                        header = False
                    End If

                    writer.WriteLine(lineRow)

                End If

            Next ' logic operation row

        Catch ex As Exception

            MsgBox("Failed to write Logic Operation line")

        End Try

    End Sub


    Private Sub ReportLogicActionTable(logicID As Integer, dsInput As ExportXml, dsReport As Rpt, dsTitles As Titles, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read Logic Action table rows and export to cvs file

            For countTable = 0 To dsInput.LogicAction.Count - 1

                Dim rowTable As ExportXml.LogicActionRow = dsInput.LogicAction.Item(countTable)

                If rowTable.LogicID = logicID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = dsInput.LogicAction.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As Titles.LogicTitleRow = dsTitles.LogicTitle.FindBycolumnID(countRow)
                        If rowReport Is Nothing Then
                            formatType = 2
                            reportTitle = columnName
                        Else
                            formatType = rowReport.formatType
                            reportTitle = rowReport.title
                        End If

                        If IsNumeric(columnValue) Then
                            ' get the attribute values for each value in rowNode
                            Dim rowAttribute As Rpt.LogicActionRow = dsReport.LogicAction.FindByvalue(columnValue)
                            If rowAttribute Is Nothing Then
                                attributeText = "<" + columnValue.ToString + ">"

                                Select Case countRow
                                    Case 3, 4 ' actionTrue, actionFalse
                                        Dim rowAction As Rpt.LogicActionRow = dsReport.LogicAction.FindByvalue(columnValue)
                                        If rowAction Is Nothing Then
                                            ' do nothing
                                            Stop
                                        Else
                                            attributeText = rowAction.text
                                        End If

                                End Select
                            Else
                                attributeText = rowAttribute.text
                            End If
                        End If

                        Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                    Next

                    Console.WriteLine(lineReport)
                    Console.WriteLine(lineRow)

                    If header Then
                        writer.WriteLine(lineReport)
                        header = False
                    End If

                    writer.WriteLine(lineRow)

                End If

            Next ' logic action row

        Catch ex As Exception

            MsgBox("Failed to write Logic Action line")

        End Try

    End Sub


    Private Sub ReportLogicProducerTable(logicID As Integer, dsInput As ExportXml, dsTitles As Titles, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read Logic Producer table rows and export to cvs file

            For countTable = 0 To dsInput.LogicProducer.Count - 1

                Dim rowTable As ExportXml.LogicProducerRow = dsInput.LogicProducer.Item(countTable)

                Dim destFlag As Integer = -1

                If rowTable.LogicID = logicID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = dsInput.LogicProducer.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As Titles.LogicTitleRow = dsTitles.LogicTitle.FindBycolumnID(countRow)
                        If rowReport Is Nothing Then
                            formatType = 2
                            reportTitle = columnName
                        Else
                            formatType = rowReport.formatType
                            reportTitle = rowReport.title
                        End If

                        If IsNumeric(columnValue) Then
                            ' get the attribute values for each value in rowNode
                            Stop
                            Dim rowAttribute As ImportCDI.TrackReceiverRow = Nothing ' dsReport.TrackCircuitRec.FindByvalue(columnValue)
                            If rowAttribute Is Nothing Then
                                attributeText = "<" + columnValue.ToString + ">"

                                Select Case countRow
                                    Case 5 ' destination
                                        Dim rowCircuit As ExportXml.TrackTransmitterRow = dsInput.TrackTransmitter.FindByCircuitID(columnValue)
                                        If rowCircuit Is Nothing Then
                                            ' do nothing
                                            Stop
                                        Else
                                            attributeText = rowCircuit.description
                                        End If

                                        destFlag = columnValue

                                    Case 6 ' track speed
                                        Dim rowSpeed As ImportCDI.TrackSpeedRow = Nothing ' dsReport.TrackSpeed.FindByvalue(columnValue)
                                        If rowSpeed Is Nothing Then
                                            ' do nothing
                                            Stop
                                        Else
                                            attributeText = rowSpeed.text
                                        End If

                                End Select

                            Else

                                attributeText = rowAttribute.text

                            End If
                        End If

                        Select Case countRow
                            Case 6 ' track speed
                                If destFlag = 0 Then
                                    columnValue = String.Empty
                                    attributeText = String.Empty
                                End If

                            Case 7 ' action 
                                If destFlag > 0 Then
                                    columnValue = String.Empty
                                    attributeText = String.Empty
                                End If

                        End Select

                        Call Me.FormatMyLine(formatType, columnName, columnValue, reportTitle, attributeText, lineReport, lineRow)

                    Next

                    Console.WriteLine(lineReport)
                    Console.WriteLine(lineRow)

                    If header Then
                        writer.WriteLine(lineReport)
                        header = False
                    End If

                    writer.WriteLine(lineRow)

                End If

            Next ' port event row

        Catch ex As Exception

            MsgBox("Failed to write Logic Producer line")

        End Try

    End Sub



    Private Sub FormatMyLine(formatType As Integer, columnName As String, columnValue As String, reportTitle As String, attributeText As String, ByRef lineReport As String, ByRef lineRow As String)

        Dim comma As String = ","

        Select Case formatType
            Case 0 ' add blank column
                lineReport += comma
                lineRow += comma

            Case 1 ' report title only
                lineReport = lineReport + reportTitle + comma
                lineRow += comma

            Case 2 ' report title and column value
                lineReport = lineReport + reportTitle + comma
                lineRow = lineRow + columnValue + comma

            Case 3 ' report title and attribute text
                lineReport = lineReport + reportTitle + comma
                lineRow = lineRow + attributeText + comma

            Case Else ' column info and attribute info
                Stop
                lineReport = lineReport + "<>" + columnName + comma + reportTitle + comma
                lineRow = lineRow + "<>" + columnValue + comma + attributeText + comma

        End Select

    End Sub

End Class
