Imports System.IO

Public Class ClassExportXmlToCsv

    Private Property MyImport As New ClsImportCDI
    Private Property MyExport As New ClsExportXML
    Private Property MyTitles As New ClsTitles
    Private Property MyReport As New ClsReport

    Public Enum RowFormatType As Integer
        BlankColumn = 1 ' add blank column
        TitleOnly = 2 ' report title only
        TitleAndColumn = 3 ' report title and column value
    End Enum

    Public Sub MyExportToCvsFile(filePath As String)

        Try

            If File.Exists(filePath) = False Then
                File.Delete(filePath)
                MsgBox(filePath + " does not exit")
                Exit Sub
            End If

            MyExport.DbExportReadFile(filePath)

            Dim nodeRow As ExportXml.NodeRow = MyExport.DbExport.Node.Item(0)
            Dim sourcePath As String = nodeRow.sourceFile
            If File.Exists(sourcePath) = False Then
                File.Delete(sourcePath)
                MsgBox(sourcePath + " does not exit")
                Exit Sub
            End If

            Try
                Dim clsU As New ClsUserPrefs
                MyImport.ImportCDI.TrackSpeed.Merge(clsU.UserPrefs.TrackSpeed)
                MyImport.ImportCDI.AcceptChanges()
            Catch ex As Exception
                MsgBox("Failed import user track speed values")
                Exit Sub
            End Try


            Dim writer As StreamWriter = File.CreateText(filePath + ".csv")

            ' output Node table
            Call Me.ReportNodeTable(writer)

            ' output PowerMonitor table
            Call Me.ReportPowerMonitorTable(writer)

            ' output Port I/O table
            REM Call Me.ReportPortTable(writer)

            ' output Logic table
            REM Call Me.ReportLogicTable(writer)

            writer.Close()

            MsgBox("CSV file has been created for file " + filePath)

        Catch ex As MyException

            MsgBox(ex.Message)

        Catch ex As Exception


            MsgBox(ex.StackTrace)

        End Try

    End Sub

    Private Sub ReportNodeTable(writer As StreamWriter)

        Dim comma As String = ","

        ' read Node table rows and export to cvs file
        For countTable = 0 To MyExport.DbExport.Node.Count - 1

            Dim rowTitle As Titles.NodeTitlesRow = MyTitles.Titles.NodeTitles.Item(0)
            Dim lineTitle As String = String.Empty

            Dim rowExport As ExportXml.NodeRow = MyExport.DbExport.Node.Item(countTable)
            Dim lineExport As String = String.Empty

            For countRow = 0 To rowExport.ItemArray.Count - 1

                Dim formatType As Integer
                Dim reportTitle As String
                Dim columnName As String = MyExport.DbExport.Node.Columns(countRow).ColumnName
                Dim columnValue As String = rowExport.Item(countRow)

                Try
                    reportTitle = rowTitle.Item(countRow).ToString
                Catch ex As Exception
                    reportTitle = columnName
                End Try

                Select Case countRow
                    Case 0 ' Node ID
                        formatType = RowFormatType.TitleOnly
                    Case 3 ' Node Type
                        formatType = RowFormatType.TitleAndColumn
                        Dim row As Rpt.NodeTypeRow = MyReport.Rpt.NodeType.FindByvalue(columnValue)
                        If row Is Nothing Then
                            columnValue = "<" + columnValue.ToString + ">"
                        Else
                            columnValue = row.name
                        End If
                    Case Else
                        formatType = RowFormatType.TitleAndColumn
                End Select

                Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineTitle, lineExport)

            Next

            Console.WriteLine(lineTitle)
            Console.WriteLine(lineExport)

            writer.WriteLine(lineTitle)
            writer.WriteLine(lineExport)
            writer.WriteLine(comma)

        Next ' node row

    End Sub


    Private Sub ReportPowerMonitorTable(writer As StreamWriter)

        Dim comma As String = ","

        ' read Power Monitor table rows and export to cvs file
        For countTable = 0 To MyExport.DbExport.PowerMonitor.Count - 1

            Dim rowTitle As Titles.PowerMonitorTitlesRow = MyTitles.Titles.PowerMonitorTitles.Item(0)
            Dim lineTitle As String = String.Empty

            Dim rowExport As ExportXml.PowerMonitorRow = MyExport.DbExport.PowerMonitor.Item(countTable)
            Dim lineExport As String = String.Empty

            For countRow = 0 To rowExport.ItemArray.Count - 1

                Dim formatType As Integer
                Dim reportTitle As String
                Dim columnName As String = MyExport.DbExport.PowerMonitor.Columns(countRow).ColumnName
                Dim columnValue As String = rowExport.Item(countRow).ToString

                Try
                    reportTitle = rowTitle.Item(countRow).ToString
                Catch ex As Exception
                    reportTitle = columnName
                End Try

                Select Case countRow
                    Case 0 ' Power Monitor ID
                        formatType = RowFormatType.TitleOnly
                    Case 1 ' Power Option
                        formatType = RowFormatType.TitleAndColumn
                        Dim row As Rpt.MessageOptionRow = MyReport.Rpt.MessageOption.FindByvalue(columnValue)
                        If row Is Nothing Then
                            columnValue = "<" + columnValue.ToString + ">"
                        Else
                            columnValue = row.text
                        End If
                    Case Else
                        formatType = RowFormatType.TitleAndColumn
                End Select

                Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineTitle, lineExport)

            Next

            Console.WriteLine(lineTitle)
            Console.WriteLine(lineExport)

            writer.WriteLine(lineTitle)
            writer.WriteLine(lineExport)
            writer.WriteLine(comma)

        Next ' power monitor row

    End Sub

    Private Sub ReportPortTable(writer As StreamWriter)

        Dim comma As String = ","

        Try

            ' read Port table rows and export to cvs file

            For countTable = 0 To MyExport.DbExport.Port.Count - 1

                Dim rowTable As ExportXml.PortRow = MyExport.DbExport.Port.Item(countTable)
                Dim lineReport As String = String.Empty
                Dim lineRow As String = String.Empty

                For countRow = 0 To rowTable.ItemArray.Count - 1

                    Dim formatType As Integer
                    Dim columnName As String = MyExport.DbExport.Port.Columns(countRow).ColumnName
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

                    Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineReport, lineRow)

                Next

                Console.WriteLine(lineReport)
                Console.WriteLine(lineRow)

                writer.WriteLine(lineReport)
                writer.WriteLine(lineRow)
                writer.WriteLine(comma)

                ' write port delay info
                Call Me.ReportPortDelayTable(rowTable.LineID, writer)
                writer.WriteLine(comma)

                Call Me.ReportPortEventTable(rowTable.LineID, writer)
                writer.WriteLine(comma)

            Next ' port row

        Catch ex As Exception

            MsgBox("Failed to write Port line")

        End Try

    End Sub


    Private Sub ReportPortDelayTable(portID As Integer, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read PortDelay table rows and export to cvs file

            For countTable = 0 To MyExport.DbExport.PortDelay.Count - 1

                Dim rowTable As ExportXml.PortDelayRow = MyExport.DbExport.PortDelay.Item(countTable)

                If rowTable.LineID = portID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = MyExport.DbExport.PortDelay.Columns(countRow).ColumnName
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

                        Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineReport, lineRow)

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


    Private Sub ReportPortEventTable(portID As Integer, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read PortEvent table rows and export to cvs file

            For countTable = 0 To MyExport.DbExport.PortEvent.Count - 1

                Dim rowTable As ExportXml.PortEventRow = MyExport.DbExport.PortEvent.Item(countTable)

                If rowTable.LineID = portID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = MyExport.DbExport.PortEvent.Columns(countRow).ColumnName
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

                        Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineReport, lineRow)

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


    Private Sub ReportLogicTable(writer As StreamWriter)

        Dim comma As String = ","

        Try

            ' read Logic table rows and export to cvs file

            For countTable = 0 To MyExport.DbExport.Logic.Count - 1

                Dim rowTable As ExportXml.LogicRow = MyExport.DbExport.Logic.Item(countTable)
                Dim lineReport As String = String.Empty
                Dim lineRow As String = String.Empty

                For countRow = 0 To rowTable.ItemArray.Count - 1

                    Dim formatType As Integer
                    Dim columnName As String = MyExport.DbExport.Logic.Columns(countRow).ColumnName
                    Dim columnValue As String = rowTable.Item(countRow).ToString
                    Dim reportTitle As String = String.Empty
                    Dim attributeText As String = String.Empty

                    Dim rowReport As Titles.LogicTitleRow = MyTitles.Titles.LogicTitle(countRow)
                    If rowReport Is Nothing Then
                        formatType = 2
                        reportTitle = columnName
                    Else
                        formatType = rowReport.formatType
                        reportTitle = rowReport.title
                    End If

                    If IsNumeric(columnValue) Then
                        ' get the attribute values for each value in rowNode
                        Dim rowAttribute As Rpt.LogicFunctionRow = MyReport.Rpt.LogicFunction.FindByvalue(columnValue)
                        If rowAttribute Is Nothing Then
                            attributeText = "<" + columnValue.ToString + ">"
                            If countRow > 2 Then Stop
                        Else
                            attributeText = rowAttribute.text
                        End If
                    End If

                    Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineReport, lineRow)

                Next

                Console.WriteLine(lineReport)
                Console.WriteLine(lineRow)

                writer.WriteLine(lineReport)
                writer.WriteLine(lineRow)
                writer.WriteLine(comma)

                ' write logic operation info
                Call Me.ReportLogicOperationTable(rowTable.LogicID, writer)
                writer.WriteLine(comma)

                Call Me.ReportLogicActionTable(rowTable.LogicID, writer)
                writer.WriteLine(comma)

                Call Me.ReportLogicProducerTable(rowTable.LogicID, writer)
                writer.WriteLine(comma)

            Next ' logic row

        Catch ex As Exception

            MsgBox("Failed to write Logic line")

        End Try

    End Sub

    Private Sub ReportLogicOperationTable(LogicID As Integer, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read Logic Operation table rows and export to cvs file

            For countTable = 0 To MyExport.DbExport.LogicOperation.Count - 1

                Dim rowTable As ExportXml.LogicOperationRow = MyExport.DbExport.LogicOperation.Item(countTable)

                Dim destFlag1 As Integer = -1
                Dim destFlag2 As Integer = -1

                If rowTable.LogicID = LogicID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = MyExport.DbExport.LogicOperation.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As Titles.LogicOperationTitleRow = MyTitles.Titles.LogicOperationTitle.FindBycolumnID(countRow)
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
                                        Dim rowTrackCircuit As ExportXml.TrackReceiverRow = MyExport.DbExport.TrackReceiver.FindByCircuitID(columnValue)
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

                        Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineReport, lineRow)

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


    Private Sub ReportLogicActionTable(logicID As Integer, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read Logic Action table rows and export to cvs file

            For countTable = 0 To MyExport.DbExport.LogicAction.Count - 1

                Dim rowTable As ExportXml.LogicActionRow = MyExport.DbExport.LogicAction.Item(countTable)

                If rowTable.LogicID = logicID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = MyExport.DbExport.LogicAction.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As Titles.LogicTitleRow = MyTitles.Titles.LogicTitle.FindBycolumnID(countRow)
                        If rowReport Is Nothing Then
                            formatType = 2
                            reportTitle = columnName
                        Else
                            formatType = rowReport.formatType
                            reportTitle = rowReport.title
                        End If

                        If IsNumeric(columnValue) Then
                            ' get the attribute values for each value in rowNode
                            Dim rowAttribute As Rpt.LogicActionRow = MyReport.Rpt.LogicAction.FindByvalue(columnValue)
                            If rowAttribute Is Nothing Then
                                attributeText = "<" + columnValue.ToString + ">"

                                Select Case countRow
                                    Case 3, 4 ' actionTrue, actionFalse
                                        Dim rowAction As Rpt.LogicActionRow = MyReport.Rpt.LogicAction.FindByvalue(columnValue)
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

                        Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineReport, lineRow)

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


    Private Sub ReportLogicProducerTable(logicID As Integer, writer As StreamWriter)

        Dim header As Boolean = True

        Try

            ' read Logic Producer table rows and export to cvs file

            For countTable = 0 To MyExport.DbExport.LogicProducer.Count - 1

                Dim rowTable As ExportXml.LogicProducerRow = MyExport.DbExport.LogicProducer.Item(countTable)

                Dim destFlag As Integer = -1

                If rowTable.LogicID = logicID Then ' process

                    Dim lineReport As String = String.Empty
                    Dim lineRow As String = String.Empty

                    For countRow = 0 To rowTable.ItemArray.Count - 1

                        Dim formatType As Integer
                        Dim columnName As String = MyExport.DbExport.LogicProducer.Columns(countRow).ColumnName
                        Dim columnValue As String = rowTable.Item(countRow).ToString
                        Dim reportTitle As String = String.Empty
                        Dim attributeText As String = String.Empty

                        Dim rowReport As Titles.LogicTitleRow = MyTitles.Titles.LogicTitle.FindBycolumnID(countRow)
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
                                        Dim rowCircuit As ExportXml.TrackTransmitterRow = MyExport.DbExport.TrackTransmitter.FindByCircuitID(columnValue)
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

                        Call Me.FormatMyLine(formatType, reportTitle, columnValue, lineReport, lineRow)

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

    Private Sub FormatMyLine(formatType As Integer, reportTitle As String, columnValue As String, ByRef lineTitle As String, ByRef lineExport As String)

        Dim comma As String = ","

        Select Case formatType
            Case RowFormatType.BlankColumn ' add blank column
                lineTitle += comma
                lineExport += comma

            Case RowFormatType.TitleOnly ' report title only
                lineTitle = lineTitle + reportTitle + comma
                lineExport += comma

            Case RowFormatType.TitleAndColumn ' report title and column value
                lineTitle = lineTitle + reportTitle + comma
                lineExport = lineExport + columnValue + comma

            Case Else ' column info and attribute info
                Stop
                lineTitle = lineTitle + "<>" + reportTitle + comma
                lineExport = lineExport + "<>" + columnValue + comma

        End Select

    End Sub

End Class
