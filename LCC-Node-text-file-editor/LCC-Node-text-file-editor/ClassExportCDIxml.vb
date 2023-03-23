Imports System.Collections.Specialized.BitVector32
Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Devices

Public Class ClassExportCDIxml

    Private lineNum As Integer = 0

    Private dsImport As ImportCDI
    Private dsExport As ExportCDI
    REM Private dsEvent As Events

    Private Property MyNodeEventBase As String
    Private Property MyNodeType As String


    Public Sub MyReadTextFile(filePath As String)

        Me.dsImport = New ImportCDI
        Me.dsExport = New ExportCDI
        REM Me.dsEvent = New Events
        Me.MyNodeEventBase = String.Empty
        Me.MyNodeType = "Unknown"

        ' get App Config values
        Dim clsAppConfig As New ClassAppConfigValues
        clsAppConfig.AppConfigFileRead()


        Try

            If File.Exists(filePath) = False Then
                File.Delete(filePath)
                MsgBox(filePath + " does not exit")
                Exit Sub
            End If


            Try
                Me.dsImport.ReadXml(clsAppConfig.SavedImportCDIfile)
            Catch ex As Exception
                MsgBox("Failed to import " + clsAppConfig.SavedImportCDIfile)
                Exit Sub
            End Try

            ' import user selections
            Try

                Dim dsUser As New UserPref

                dsUser.ReadXml(clsAppConfig.SavedUserFile)
                dsUser.AcceptChanges()

                dsImport.Process.Merge(dsUser.Process)
                dsImport.SegmentReport.Merge(dsUser.SegmentReport)
                dsImport.AcceptChanges()

                Dim rowProcess As ImportCDI.ProcessRow = dsImport.Process.FindByprocessID(1)
                If rowProcess Is Nothing Then
                    ' do nothing
                ElseIf Not rowProcess.action Then
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox("Failed to import xml " + clsAppConfig.SavedUserFile)
            End Try


            ' export needs all track circuit data
            Try

                For rowCount = 0 To dsImport.TrackCircuitRec.Count - 1
                    Dim rowInRec As ImportCDI.TrackCircuitRecRow = dsImport.TrackCircuitRec.Item(rowCount)
                    dsExport.TrackCircuitRec.AddTrackCircuitRecRow(rowInRec.value, rowInRec.text, String.Empty)
                Next

                For rowCount = 0 To dsImport.TrackCircuitTran.Count - 1
                    Dim rowInTran As ImportCDI.TrackCircuitTranRow = dsImport.TrackCircuitTran.Item(rowCount)
                    dsExport.TrackCircuitTran.AddTrackCircuitTranRow(rowInTran.value, rowInTran.text, String.Empty)
                Next

            Catch ex As Exception
                MsgBox("Failed to import Track Circuit values")
            End Try


            Dim sr As New StreamReader(filePath)
            Dim myText As String = String.Empty
            Dim resultText As String = String.Empty

            While Not sr.EndOfStream

                myText = sr.ReadLine

                Me.lineNum += 1

                Dim segID As Integer = Me.MatchSegment(myText, resultText)

                Select Case segID

                    Case -1 ' unknown segment
                        Stop

                    Case 0 ' segment node ID
                        Call Me.AddRowNode(segID, resultText)

                    Case 1 ' segment power monitor
                        Call Me.AddRowPowerMonitor(segID, resultText)

                    Case 2 ' segment port
                        Call Me.AddRowPort(segID, resultText)

                    Case 3 ' segment conditional
                        Call Me.AddRowLogic(segID, resultText)

                    Case 4 ' segment track circuit receiver
                        Call Me.AddRowTrackCircuitRec(segID, resultText)

                    Case 5 ' segment track circuit transmitter
                        Call Me.AddRowTrackCircuitTran(segID, resultText)

                    Case 6 ' segment rule to aspect
                        Call Me.AddRowRuleToAspect(segID, resultText)

                    Case 7 ' segment Direct Lamp Control
                        Call Me.AddRowLampDirectControl(segID, resultText)

                    Case 8 ' 
                        Call Me.UpDateRowLampDirectControl(segID, resultText)

                End Select

            End While ' read the next text line

            ' update values after process is done
            Dim rowNode As ExportCDI.NodeRow = Me.dsExport.Node.FindBysegIDsectionID(0, 0)
            If rowNode Is Nothing Then
                ' do nothing
            Else
                rowNode.eventBase = Me.MyNodeEventBase
                rowNode.NodeType = Me.MyNodeType
            End If

            Me.dsExport.AcceptChanges()

            Try

                Dim nodesFilePath As String = filePath + ".xml"
                Me.dsExport.WriteXml(nodesFilePath)
                MsgBox("Xml file has been created for " + filePath)

            Catch ex As Exception

                MsgBox("failed to save xml file")

            End Try

        Catch ex As Exception

            MsgBox("Failed to read " + filePath)

        End Try

    End Sub

    Private Function MatchSegment(text As String, ByRef resultText As String) As Integer

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim segID As Integer = -1 ' default value

        Try

            ' find the match segment record
            For count = 0 To Me.dsImport.MatchSegment.Count - 1

                Dim row As ImportCDI.MatchSegmentRow = Me.dsImport.MatchSegment.Rows.Item(count)

                ' find match text
                Dim myMatch = row.text

                startInt = InStr(text, myMatch)
                If startInt > 0 Then

                    ' Ok, found a known segment row
                    ' return resultTxt and segID
                    ' then exit count and read next line

                    resultInt = startInt + Len(myMatch)
                    resultText = Mid(text, resultInt)

                    segID = row.segID

                    Exit For

                End If

            Next

            If segID = -1 Then
                Console.WriteLine(lineNum.ToString + " Segment not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return segID

    End Function


    Private Function MatchSection(segID As Integer, text As String, ByRef lineID As Integer, ByRef resultText As String) As ImportCDI.MatchSectionRow

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim rowSection As ImportCDI.MatchSectionRow = Nothing

        Try

            ' find the match segment record
            For count = 0 To Me.dsImport.MatchSection.Count - 1

                Dim row As ImportCDI.MatchSectionRow = Me.dsImport.MatchSection.Rows.Item(count)

                If row.segID = segID Then

                    ' find match text
                    Dim myMatch = row.text

                    startInt = InStr(text, myMatch)
                    If startInt > 0 Then

                        ' Ok, found a known section row
                        ' return resultTxt and segID
                        ' then exit count and read next line

                        ' need to check for line and return lineID and reformatted resultText
                        lineID = Me.GetMyIDvalue(text)

                        If lineID > 0 Then
                            resultInt = InStr(text, ").") + 2
                            resultText = Mid(text, resultInt)
                        End If

                        resultInt = startInt + Len(myMatch)
                        resultText = Mid(text, resultInt)

                        rowSection = row

                        Exit For

                    End If

                End If

            Next

            If IsNothing(rowSection) Then
                Console.WriteLine(lineNum.ToString + " Section not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return rowSection

    End Function


    Private Function MatchItem(segID As Integer, text As String, ByRef itemID As Integer, ByRef resultText As String) As ImportCDI.MatchItemRow

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim rowItem As ImportCDI.MatchItemRow = Nothing

        Try

            ' find the match segment record
            For count = 0 To Me.dsImport.MatchItem.Count - 1

                Dim row As ImportCDI.MatchItemRow = Me.dsImport.MatchItem.Rows.Item(count)

                If row.segID = segID Then

                    ' find match text
                    Dim myMatch = row.text

                    startInt = InStr(text, myMatch)
                    If startInt > 0 Then

                        ' need to check for line and return lineID and reformatted resultText
                        itemID = Me.GetMyIDvalue(text)

                        If itemID = 0 Then Stop

                        If itemID > 0 Then
                            resultInt = InStr(text, ").") + 2
                            resultText = Mid(text, resultInt)
                        End If

                        resultInt = startInt + Len(myMatch)
                        resultText = Mid(text, resultInt)

                        rowItem = row

                        Exit For

                    End If

                End If

            Next

            If IsNothing(rowItem) Then
                Console.WriteLine(lineNum.ToString + " Item not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return rowItem

    End Function


    Private Function MatchLevel4(segID As Integer, text As String, ByRef level4ID As Integer, ByRef resultText As String) As ImportCDI.MatchLevel4Row

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim rowLevel4 As ImportCDI.MatchLevel4Row = Nothing

        Try

            ' find the match segment record
            For count = 0 To Me.dsImport.MatchLevel4.Count - 1

                Dim row As ImportCDI.MatchLevel4Row = Me.dsImport.MatchLevel4.Rows.Item(count)

                If row.segID = segID Then

                    ' find match text
                    Dim myMatch = row.text

                    startInt = InStr(text, myMatch)
                    If startInt > 0 Then

                        ' need to check for line and return lineID and reformatted resultText
                        level4ID = Me.GetMyIDvalue(text)

                        If level4ID = 0 Then Stop

                        If level4ID > 0 Then
                            resultInt = InStr(text, ").") + 2
                            resultText = Mid(text, resultInt)
                        End If

                        resultInt = startInt + Len(myMatch)
                        resultText = Mid(text, resultInt)

                        rowLevel4 = row

                        Exit For

                    End If

                End If

            Next

            If IsNothing(rowLevel4) Then
                Console.WriteLine(lineNum.ToString + " Level4 not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return rowLevel4

    End Function

    Private Sub AddRowNode(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim lineID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, lineID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Dim rowNode As ExportCDI.NodeRow = Me.dsExport.Node.FindBysegIDsectionID(segID, rowSection.sectionID)
            Try
                If rowNode Is Nothing Then
                    Me.dsExport.Node.AddNodeRow(segID, rowSection.sectionID, String.Empty, String.Empty, String.Empty, String.Empty)
                    Me.dsExport.AcceptChanges()
                    rowNode = Me.dsExport.Node.FindBysegIDsectionID(segID, rowSection.sectionID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Node row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + Space(1) + "Node ID" + " - " + rowSection.text + Space(1) + resultText)
            rowNode.Item(rowSection.columnID) = resultText

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed add table Node row")

        End Try

    End Sub

    Private Sub AddRowPowerMonitor(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim lineID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, lineID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Dim rowPowerMonitor As ExportCDI.PowerMonitorRow = Me.dsExport.PowerMonitor.FindBysegIDsectionID(segID, rowSection.sectionID)
            Try
                If rowPowerMonitor Is Nothing Then
                    Me.dsExport.PowerMonitor.AddPowerMonitorRow(segID, rowSection.sectionID, 0, String.Empty, String.Empty)
                    Me.dsExport.AcceptChanges()
                    rowPowerMonitor = Me.dsExport.PowerMonitor.FindBysegIDsectionID(segID, rowSection.sectionID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table PowerMonitor row")
            End Try

            Console.WriteLine(Me.lineNum.ToString + Space(1) + "Node Power Monitor" + " - " + rowSection.text + Space(1) + resultText)
            rowPowerMonitor.Item(rowSection.columnID) = resultText
            If rowSection.columnID = 3 Then
                Me.MyNodeEventBase = Left(resultText, 17)
            End If

            Me.dsExport.AcceptChanges()
        Catch ex As Exception

            MsgBox("Failed to add Power Monitor row")

        End Try

    End Sub

    Private Sub AddRowPort(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim lineID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, lineID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Select Case rowSection.sectionID
                Case 0
                    Call Me.TablePort(rowSection.segID, rowSection.sectionID, lineID, rowSection.columnID, rowSection.text, resultText)

                Case 1
                    Call Me.TablePortDelay(rowSection.segID, lineID, resultText)

                Case 2
                    Call Me.TablePortEvent(rowSection.segID, lineID, resultText)

                Case Else
                    Stop

            End Select

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to Add Row Port")

        End Try

    End Sub


    Private Sub TablePort(segID As Integer, sectionID As Integer, lineID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Select Case lineID
                Case 8
                    Me.MyNodeType = "Signal-LCC"
                Case 16
                    Me.MyNodeType = "Tower-LCC"
            End Select

            Dim rowPort As ExportCDI.PortRow = Me.dsExport.Port.FindBysegIDsectionIDlineID(segID, sectionID, lineID)
            Try
                If rowPort Is Nothing Then
                    Me.dsExport.Port.AddPortRow(segID, sectionID, lineID, String.Empty, 0, 0, 0, 0)
                    Me.dsExport.AcceptChanges()
                    rowPort = Me.dsExport.Port.FindBysegIDsectionIDlineID(segID, sectionID, lineID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Port row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Port I/O - " + "Line(" + lineID.ToString + ") - " + matchText + Space(1) + resultText)
            rowPort.Item(columnID) = resultText

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port row")

        End Try

    End Sub

    Private Sub TablePortDelay(segID As Integer, lineID As Integer, text As String)

        Try

            Dim itemID As Integer
            Dim resultText As String = String.Empty

            Dim rowItem As ImportCDI.MatchItemRow = Me.MatchItem(segID, text, itemID, resultText)
            If rowItem Is Nothing Then
                Stop
            End If

            Dim rowPortDelay As ExportCDI.PortDelayRow = Me.dsExport.PortDelay.FindBysegIDsectionIDlineIDitemID(segID, rowItem.sectionID, lineID, itemID)
            If rowPortDelay Is Nothing Then
                Try
                    Me.dsExport.PortDelay.AddPortDelayRow(rowItem.segID, rowItem.sectionID, lineID, itemID, 0, 0, 0)
                    Me.dsExport.AcceptChanges()
                    rowPortDelay = Me.dsExport.PortDelay.FindBysegIDsectionIDlineIDitemID(rowItem.segID, rowItem.sectionID, lineID, itemID)
                Catch ex As Exception
                    MsgBox("Failed to create table Port Delay row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(Me.lineNum.ToString + " Port I/O - " + "Line(" + lineID.ToString + ") - " + "Delay(" + itemID.ToString + ") - " + rowItem.text + Space(1) + resultText)
            rowPortDelay.Item(rowItem.columnID) = resultText

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port Delay row")

        End Try

    End Sub

    Private Sub TablePortEvent(segID As Integer, lineID As Integer, text As String)

        Try

            Dim itemID As Integer
            Dim resultText As String = String.Empty

            Dim rowItem As ImportCDI.MatchItemRow = Me.MatchItem(segID, text, itemID, resultText)
            If rowItem Is Nothing Then
                Stop
            End If

            Dim rowPortEvent As ExportCDI.PortEventRow = Me.dsExport.PortEvent.FindBysegIDsectionIDlineIDitemID(segID, rowItem.sectionID, lineID, itemID)
            If rowPortEvent Is Nothing Then
                Try
                    Me.dsExport.PortEvent.AddPortEventRow(segID, rowItem.sectionID, lineID, itemID, String.Empty, 0, 0, String.Empty)
                    Me.dsExport.AcceptChanges()
                    rowPortEvent = Me.dsExport.PortEvent.FindBysegIDsectionIDlineIDitemID(segID, rowItem.sectionID, lineID, itemID)
                Catch ex As Exception
                    MsgBox("Failed to create table Port Event row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(Me.lineNum.ToString + " Port I/O - " + "Line(" + lineID.ToString + ") - " + "Event(" + itemID.ToString + ") - " + resultText)
            rowPortEvent.Item(rowItem.columnID) = resultText

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port Event")

        End Try

    End Sub


    Private Sub AddRowLogic(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim LogicID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, LogicID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Select Case rowSection.sectionID
                Case 0 ' Logic section
                    Call Me.TableLogic(LogicID, rowSection.columnID, rowSection.text, resultText)

                Case 1 ' Logic Operation section
                    Call Me.TableLogicOperation(LogicID, rowSection.columnID, rowSection.text, resultText)

                Case 2 ' Logic Action
                    Call Me.TableLogicAction(LogicID, rowSection.columnID, rowSection.text, resultText)

                Case 3
                    Call Me.TableLogicProducer(rowSection.segID, LogicID, resultText)

                Case Else
                    MsgBox("Logic Section unknown - " + rowSection.sectionID)

            End Select

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Logic")

        End Try

    End Sub

    Private Sub TableLogic(LogicID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogic As ExportCDI.LogicRow = Me.dsExport.Logic.FindByLogicID(LogicID)
            Try
                If rowLogic Is Nothing Then
                    Me.dsExport.Logic.AddLogicRow(LogicID, String.Empty, 0)
                    Me.dsExport.AcceptChanges()
                    rowLogic = Me.dsExport.Logic.FindByLogicID(LogicID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Conditional - " + "Logic(" + LogicID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogic.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add Logic row")

        End Try

    End Sub

    Private Sub TableLogicOperation(LogicID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogicOP As ExportCDI.LogicOperationRow = Me.dsExport.LogicOperation.FindByLogicID(LogicID)
            Try
                If rowLogicOP Is Nothing Then
                    Me.dsExport.LogicOperation.AddLogicOperationRow(LogicID, 0, 0, 0, String.Empty, String.Empty, 0, 0, 0, 0, String.Empty, String.Empty)
                    Me.dsExport.AcceptChanges()
                    rowLogicOP = Me.dsExport.LogicOperation.FindByLogicID(LogicID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic Operation row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Conditional - " + "Logic(" + LogicID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogicOP.Item(columnID) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Operation row")

        End Try

    End Sub

    Private Sub TableLogicAction(LogicID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogicAction As ExportCDI.LogicActionRow = Me.dsExport.LogicAction.FindByLogicID(LogicID)
            Try
                If rowLogicAction Is Nothing Then
                    Me.dsExport.LogicAction.AddLogicActionRow(LogicID, 0, 0, 0, 0, 0)
                    Me.dsExport.AcceptChanges()
                    rowLogicAction = Me.dsExport.LogicAction.FindByLogicID(LogicID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic Action row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Conditional - " + "Logic(" + LogicID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogicAction.Item(columnID) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Action row")

        End Try

    End Sub

    Private Sub TableLogicProducer(segID As Integer, lineID As Integer, text As String)

        Try

            Dim itemID As Integer
            Dim resultText As String = String.Empty

            Dim rowItem As ImportCDI.MatchItemRow = Me.MatchItem(segID, text, itemID, resultText)
            If rowItem Is Nothing Then
                Stop
            End If

            Dim rowLogicProducer As ExportCDI.LogicProducerRow = Me.dsExport.LogicProducer.FindBysegIDsectionIDlineIDitemID(rowItem.segID, rowItem.sectionID, lineID, itemID)
            If rowLogicProducer Is Nothing Then
                Try
                    Me.dsExport.LogicProducer.AddLogicProducerRow(rowItem.segID, rowItem.sectionID, lineID, itemID, 0, 0, 0, String.Empty)
                    Me.dsExport.AcceptChanges()
                    rowLogicProducer = Me.dsExport.LogicProducer.FindBysegIDsectionIDlineIDitemID(rowItem.segID, rowItem.sectionID, lineID, itemID)
                Catch ex As Exception
                    MsgBox("Failed to create table Logic Producer row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(Me.lineNum.ToString + " Conditional - " + "Logic(" + lineID.ToString + ") - Event - " + "Item(" + itemID.ToString + ") - " + rowItem.text + Space(1) + resultText)
            rowLogicProducer.Item(rowItem.columnID) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Producer row")

        End Try

    End Sub


    Private Sub AddRowTrackCircuitRec(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim CircuitID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, CircuitID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Dim rowCircuit As ExportCDI.TrackCircuitRecRow = Me.dsExport.TrackCircuitRec.FindByCircuitID(CircuitID)
            Try
                If rowCircuit Is Nothing Then
                    Me.dsExport.TrackCircuitRec.AddTrackCircuitRecRow(CircuitID, String.Empty, String.Empty)
                    Me.dsExport.AcceptChanges()
                    rowCircuit = Me.dsExport.TrackCircuitRec.FindByCircuitID(CircuitID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Track Circuit Receiver row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Track Circuit Receiver - Circuit(" + CircuitID.ToString + ") - " + rowSection.text + Space(1) + resultText)
            rowCircuit.Item(rowSection.columnID) = resultText

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Track Circuit Receiver row")

        End Try

    End Sub

    Private Sub AddRowTrackCircuitTran(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim CircuitID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, CircuitID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Dim rowCircuit As ExportCDI.TrackCircuitTranRow = Me.dsExport.TrackCircuitTran.FindByCircuitID(CircuitID)
            Try
                If rowCircuit Is Nothing Then
                    Me.dsExport.TrackCircuitTran.AddTrackCircuitTranRow(CircuitID, String.Empty, String.Empty)
                    Me.dsExport.AcceptChanges()
                    rowCircuit = Me.dsExport.TrackCircuitTran.FindByCircuitID(CircuitID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Track Circuit Transmitter row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Track Circuit Transmitter - Circuit(" + CircuitID.ToString + ") - " + rowSection.text + Space(1) + resultText)
            rowCircuit.Item(rowSection.columnID) = resultText

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Track Circuit Transmitter row")

        End Try

    End Sub


    Private Sub AddRowRuleToAspect(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim MastID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, MastID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Select Case rowSection.sectionID
                Case 0
                    Call Me.TableMast(MastID, rowSection.columnID, rowSection.text, resultText)

                Case 1
                    Call Me.TableMastRule(rowSection.segID, MastID, resultText)

                Case Else
                    Stop

            End Select

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Rule To Aspect")

        End Try

    End Sub

    Private Sub TableMast(MastID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogic As ExportCDI.MastRow = Me.dsExport.Mast.FindByMastID(MastID)
            Try
                If rowLogic Is Nothing Then
                    Me.dsExport.Mast.AddMastRow(MastID, 0, String.Empty, String.Empty, 0)
                    Me.dsExport.AcceptChanges()
                    rowLogic = Me.dsExport.Mast.FindByMastID(MastID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Mast row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Mast(" + MastID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogic.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Mast row")

        End Try

    End Sub


    Private Sub TableMastRule(segID As Integer, MastID As Integer, text As String)

        Try

            Dim RuleID As Integer
            Dim resultText As String = String.Empty

            Dim rowItem As ImportCDI.MatchItemRow = Me.MatchItem(segID, text, RuleID, resultText)
            If rowItem Is Nothing Then
                Stop
            End If


            Select Case rowItem.sectionID
                Case 1

                    Dim rowMastRule As ExportCDI.MastRuleRow = Me.dsExport.MastRule.FindByMastIDRuleID(MastID, RuleID)
                    If rowMastRule Is Nothing Then
                        Try
                            Me.dsExport.MastRule.AddMastRuleRow(MastID, RuleID, 0, 0, String.Empty, String.Empty, String.Empty, 0, 0)
                            Me.dsExport.AcceptChanges()
                            rowMastRule = Me.dsExport.MastRule.FindByMastIDRuleID(MastID, RuleID)
                        Catch ex As Exception
                            MsgBox("Failed to create table Mast Rule row")
                            Exit Sub
                        End Try
                    End If

                    Console.WriteLine(Me.lineNum.ToString + " Mast - Mast(" + MastID.ToString + ") " + " - Rule(" + RuleID.ToString + ") - " + rowItem.text + Space(1) + resultText)
                    rowMastRule.Item(rowItem.columnID - 2) = resultText

                Case 2

                    Call Me.TableMastAppearance(rowItem.segID, MastID, RuleID, resultText)

                Case Else

                    Stop

            End Select


        Catch ex As Exception

            MsgBox("Failed to add table Mast Rule row")

        End Try

    End Sub


    Private Sub TableMastAppearance(segID As Integer, MastID As Integer, RuleID As Integer, text As String)

        Try

            Dim AppearanceID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel4 As ImportCDI.MatchLevel4Row = Me.MatchLevel4(segID, text, AppearanceID, resultText)
            If rowLevel4 Is Nothing Then
                Stop
            End If

            Dim rowMastRuleAppear As ExportCDI.MastRuleAppearRow = Me.dsExport.MastRuleAppear.FindByMastIDRuleIDAppearanceID(MastID, RuleID, AppearanceID)
            If rowMastRuleAppear Is Nothing Then
                Try
                    Me.dsExport.MastRuleAppear.AddMastRuleAppearRow(MastID, RuleID, AppearanceID, 0, 0)
                    Me.dsExport.AcceptChanges()
                    rowMastRuleAppear = Me.dsExport.MastRuleAppear.FindByMastIDRuleIDAppearanceID(MastID, RuleID, AppearanceID)
                Catch ex As Exception
                    MsgBox("Failed to create table Mast Rule Apperance row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(Me.lineNum.ToString + " Mast - " + "Mast(" + MastID.ToString + ") - Rule(" + RuleID.ToString + ") - Appearance(" + AppearanceID.ToString + ") - " + rowLevel4.text + Space(1) + resultText)
            rowMastRuleAppear.Item(rowLevel4.columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Mast Rule Appearance row")

        End Try

    End Sub


    Private Sub AddRowLampDirectControl(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim lineID As Integer
            Dim resultText As String = String.Empty

            Dim rowSection As ImportCDI.MatchSectionRow = Me.MatchSection(segID, text, lineID, resultText)
            If rowSection Is Nothing Then
                Stop
            End If

            Select Case rowSection.sectionID
                Case 0
                    Call Me.TableLamp(lineID, rowSection.columnID, rowSection.text, resultText)

                Case Else
                    Stop

            End Select

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Lamp Direct Control")

        End Try

    End Sub


    Private Sub TableLamp(LampID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLamp As ExportCDI.LampRow = Me.dsExport.Lamp.FindByLampID(LampID)
            Try
                If rowLamp Is Nothing Then
                    Me.dsExport.Lamp.AddLampRow(LampID, String.Empty, String.Empty, String.Empty, 0, 0, 0, 0)
                    Me.dsExport.AcceptChanges()
                    rowLamp = Me.dsExport.Lamp.FindByLampID(LampID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Lamp row")
                Exit Sub
            End Try

            Console.WriteLine(Me.lineNum.ToString + " Lamp(" + LampID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLamp.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Lamp row")

        End Try

    End Sub


    Private Sub UpDateRowLampDirectControl(segID As Integer, text As String)

        Try

            If Not Me.SegmentReport(segID) Then Exit Sub

            Dim LampID As Integer = Val(text)

            Dim startInt As Integer = 0
            Dim myMatch As String = "="
            Dim resultInt As Integer = 0
            Dim resultText As String = String.Empty

            startInt = InStr(text, myMatch)
            If startInt > 0 Then
                resultInt = startInt + Len(myMatch)
                resultText = Mid(text, resultInt)
            End If

            Dim rowLamp As ExportCDI.LampRow = Me.dsExport.Lamp.FindByLampID(LampID)
            If rowLamp Is Nothing Then
                MsgBox("Failed to find Lamp row " + LampID.ToString)
            Else
                rowLamp.brightness = resultText
                Console.WriteLine(Me.lineNum.ToString + " Lamp(" + LampID.ToString + ") - Brightness= " + resultText)
            End If

            Me.dsExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed UpDate Row Lamp Direct Control")

        End Try

    End Sub


    Private Function GetMyIDvalue(resultText As String) As Integer

        Dim valueInt As Integer
        Dim valueText As String
        Dim testText As String = ")"
        Dim itemID As Integer = 0

        Try

            valueInt = InStr(resultText, testText)
            If valueInt > 0 Then
                valueText = Mid(resultText, Len(valueInt.ToString), valueInt - 1)
                itemID = Val(valueText) + 1
            End If

        Catch ex As Exception

            Stop

        End Try

        Return itemID

    End Function

    Private Function SegmentReport(segID As Integer) As Boolean

        Dim rowSegReport As ImportCDI.SegmentReportRow = Me.dsImport.SegmentReport.FindBysegID(segID)
        If rowSegReport Is Nothing Then
            Return True
        End If

        Return rowSegReport.action

    End Function

End Class
