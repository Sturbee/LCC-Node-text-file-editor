﻿
Imports System.IO

Public Class ClassExportXml

    Private Property MyLineNum As Integer = 0
    Private Property MyImportCDI As New ImportCDI
    Private Property MyExportXml As New ExportXml
    Private Property MyNodeEventBase As String
    Private Property MyNodeType As Integer


    Public Sub MyExportToXmlFile(filePath As String)

        Me.MyNodeEventBase = String.Empty
        Me.MyNodeType = 0 ' Unknown

        Try

            If File.Exists(filePath) = False Then
                File.Delete(filePath)
                MsgBox(filePath + " does not exit")
                Exit Sub
            End If

            ' import cdi xml file file
            Try
                Dim clsImportCDI As New ClsImportCDI
                Me.MyImportCDI = clsImportCDI.MyImportCDI
            Catch ex As Exception
                MsgBox("Failed to import the import cdi xml file")
                Exit Sub
            End Try

            ' export needs all track circuit data
            Try

                For rowCount = 0 To MyImportCDI.TrackReceiver.Count - 1
                    Dim rowInRec As ImportCDI.TrackReceiverRow = MyImportCDI.TrackReceiver.Item(rowCount)
                    MyExportXml.TrackReceiver.AddTrackReceiverRow(rowInRec.value, rowInRec.text, String.Empty)
                Next

                For rowCount = 0 To MyImportCDI.TrackTransmitter.Count - 1
                    Dim rowInTran As ImportCDI.TrackTransmitterRow = MyImportCDI.TrackTransmitter.Item(rowCount)
                    MyExportXml.TrackTransmitter.AddTrackTransmitterRow(rowInTran.value, rowInTran.text, String.Empty)
                Next

            Catch ex As Exception
                MsgBox("Failed to import Track Circuit values")
            End Try


            Dim sr As New StreamReader(filePath)
            Dim myText As String = String.Empty
            Dim resultText As String = String.Empty

            While Not sr.EndOfStream

                myText = sr.ReadLine

                MyLineNum += 1

                Dim level1 As Integer = Me.MatchLevel1(myText, resultText)

                Select Case level1

                    Case -1 ' unknown segment
                        Stop

                    Case 0 ' segment node ID
                        Call Me.AddRowNode(level1, resultText)

                    Case 1 ' segment power monitor
                        Call Me.AddRowPowerMonitor(level1, resultText)

                    Case 2 ' segment port
                        Call Me.AddRowPort(level1, resultText)

                    Case 3 ' segment conditional
                        Call Me.AddRowLogic(level1, resultText)

                    Case 4 ' segment track circuit receiver
                        Call Me.AddRowTrackCircuitRec(level1, resultText)

                    Case 5 ' segment track circuit transmitter
                        Call Me.AddRowTrackCircuitTran(level1, resultText)

                    Case 6 ' segment rule to aspect
                        Call Me.AddRowRuleToAspect(level1, resultText)

                    Case 7 ' segment Direct Lamp Control
                        Call Me.AddRowLampDirectControl(level1, resultText)

                    Case 8 ' 
                        Call Me.UpDateRowLampDirectControl(resultText)

                End Select

            End While ' read the next text line

            sr.Close()

            ' update values after process is done
            Dim rowNode As ExportXml.NodeRow = Me.MyExportXml.Node.FindByNodeID(0)
            If rowNode Is Nothing Then
                ' do nothing
            Else
                rowNode.eventBase = Me.MyNodeEventBase
                rowNode.nodeType = Me.MyNodeType
                rowNode.sourceFile = filePath
            End If

            ' check for Lamp table
            Try
                For count = 1 To MyExportXml.Lamp.Count
                    Dim rowI As ImportCDI.LampNameRow = MyImportCDI.LampName.Item(count)
                    Dim rowE As ExportXml.LampRow = MyExportXml.Lamp.Item(count - 1)
                    If rowE.description = String.Empty Then
                        rowE.description = rowI.text
                    End If
                Next
            Catch ex As Exception
                ' do nothing as table does not exsit
            End Try


            Me.MyExportXml.AcceptChanges()

            Try

                Dim clsU As New ClsUserPrefs
                Dim row As UserPrefs.UserJMRIRow = clsU.MyUserPrefs.UserJMRI.FindByvalue(1)

                Dim filePathXml As String = row.path + "\" + Path.GetFileName(filePath) + ".xml"
                Me.MyExportXml.WriteXml(filePathXml)
                MsgBox("Xml file has been created for " + filePathXml)

            Catch ex As Exception

                MsgBox("failed to save xml file")

            End Try

        Catch ex As Exception

            MsgBox("Failed to read " + filePath)

        End Try

    End Sub

    Private Function MatchLevel1(text As String, ByRef resultText As String) As Integer

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim level1 As Integer = -1 ' default value

        Try

            ' find the match segment record
            For count = 0 To Me.MyImportCDI.MatchLevel1.Count - 1

                Dim row As ImportCDI.MatchLevel1Row = Me.MyImportCDI.MatchLevel1.Rows.Item(count)

                ' find match text
                Dim myMatch = row.text

                startInt = InStr(text, myMatch)
                If startInt > 0 Then

                    ' Ok, found a known segment row
                    ' return resultTxt and level1
                    ' then exit count and read next line

                    resultInt = startInt + Len(myMatch)
                    resultText = Mid(text, resultInt)

                    level1 = row.level1

                    Exit For

                End If

            Next

            If level1 = -1 Then
                Console.WriteLine(MyLineNum.ToString + " Level1 not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return level1

    End Function


    Private Function MatchLevel2(level1 As Integer, text As String, ByRef level2 As Integer, ByRef resultText As String) As ImportCDI.MatchLevel2Row

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim rowLevel2 As ImportCDI.MatchLevel2Row = Nothing

        Try

            ' find the match segment record
            For count = 0 To Me.MyImportCDI.MatchLevel2.Count - 1

                Dim row As ImportCDI.MatchLevel2Row = Me.MyImportCDI.MatchLevel2.Rows.Item(count)

                If row.level1 = level1 Then

                    ' find match text
                    Dim myMatch = row.text

                    startInt = InStr(text, myMatch)
                    If startInt > 0 Then

                        ' Ok, found a known section row
                        ' return resultTxt and level1
                        ' then exit count and read next line

                        ' need to check for line and return lineID and reformatted resultText
                        level2 = Me.GetMyIDvalue(text)

                        If level2 > 0 Then
                            resultInt = InStr(text, ").") + 2
                            resultText = Mid(text, resultInt)
                        End If

                        resultInt = startInt + Len(myMatch)
                        resultText = Mid(text, resultInt)

                        rowLevel2 = row

                        Exit For

                    End If

                End If

            Next

            If IsNothing(rowLevel2) Then
                Console.WriteLine(MyLineNum.ToString + " Section not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return rowLevel2

    End Function


    Private Function MatchLevel3(level1 As Integer, text As String, ByRef level3 As Integer, ByRef resultText As String) As ImportCDI.MatchLevel3Row

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim rowLevel3 As ImportCDI.MatchLevel3Row = Nothing

        Try

            ' find the match segment record
            For count = 0 To Me.MyImportCDI.MatchLevel3.Count - 1

                Dim row As ImportCDI.MatchLevel3Row = Me.MyImportCDI.MatchLevel3.Rows.Item(count)

                If row.level1 = level1 Then

                    ' find match text
                    Dim myMatch = row.text

                    startInt = InStr(text, myMatch)
                    If startInt > 0 Then

                        ' need to check for line and return lineID and reformatted resultText
                        level3 = Me.GetMyIDvalue(text)

                        If level3 = 0 Then Stop

                        If level3 > 0 Then
                            resultInt = InStr(text, ").") + 2
                            resultText = Mid(text, resultInt)
                        End If

                        resultInt = startInt + Len(myMatch)
                        resultText = Mid(text, resultInt)

                        rowLevel3 = row

                        Exit For

                    End If

                End If

            Next

            If IsNothing(rowLevel3) Then
                Console.WriteLine(MyLineNum.ToString + " Level3 not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return rowLevel3

    End Function


    Private Function MatchLevel4(level1 As Integer, text As String, ByRef level4 As Integer, ByRef resultText As String) As ImportCDI.MatchLevel4Row

        Dim startInt As Integer
        Dim resultInt As Integer
        resultText = String.Empty
        Dim rowLevel4 As ImportCDI.MatchLevel4Row = Nothing

        Try

            ' find the match segment record
            For count = 0 To Me.MyImportCDI.MatchLevel4.Count - 1

                Dim row As ImportCDI.MatchLevel4Row = Me.MyImportCDI.MatchLevel4.Rows.Item(count)

                If row.level1 = level1 Then

                    ' find match text
                    Dim myMatch = row.text

                    startInt = InStr(text, myMatch)
                    If startInt > 0 Then

                        ' need to check for line and return lineID and reformatted resultText
                        level4 = Me.GetMyIDvalue(text)

                        If level4 = 0 Then Stop

                        If level4 > 0 Then
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
                Console.WriteLine(MyLineNum.ToString + " Level4 not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return rowLevel4

    End Function

    Private Sub AddRowNode(level1 As Integer, text As String)

        Try

            Dim NodeID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, NodeID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Dim rowNode As ExportXml.NodeRow = MyExportXml.Node.FindByNodeID(NodeID)
            Try
                If rowNode Is Nothing Then
                    Me.MyExportXml.Node.AddNodeRow(NodeID, String.Empty, String.Empty, 0, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowNode = Me.MyExportXml.Node.FindByNodeID(NodeID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Node row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + Space(1) + "Node ID - " + rowLevel2.text + Space(1) + resultText)
            rowNode.Item(rowLevel2.columnID - 1) = resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed add table Node row")

        End Try

    End Sub

    Private Sub AddRowPowerMonitor(level1 As Integer, text As String)

        Try

            Dim PowerMonitorID As Integer
            Dim resultText As String = String.Empty

            Dim rowlevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, PowerMonitorID, resultText)
            If rowlevel2 Is Nothing Then
                Stop
            End If

            Dim rowPowerMonitor As ExportXml.PowerMonitorRow = Me.MyExportXml.PowerMonitor.FindByPowerMonitorID(PowerMonitorID)
            Try
                If rowPowerMonitor Is Nothing Then
                    Me.MyExportXml.PowerMonitor.AddPowerMonitorRow(PowerMonitorID, 0, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowPowerMonitor = Me.MyExportXml.PowerMonitor.FindByPowerMonitorID(PowerMonitorID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table PowerMonitor row")
            End Try

            Console.WriteLine(MyLineNum.ToString + Space(1) + "Node Power Monitor - " + rowlevel2.text + Space(1) + resultText)
            rowPowerMonitor.Item(rowlevel2.columnID - 1) = resultText
            If rowlevel2.columnID = 3 Then
                Me.MyNodeEventBase = Left(resultText, 17)
            End If

            Me.MyExportXml.AcceptChanges()
        Catch ex As Exception

            MsgBox("Failed to add Power Monitor row")

        End Try

    End Sub

    Private Sub AddRowPort(level1 As Integer, text As String)

        Try

            Dim LineID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, LineID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TablePort(LineID, rowLevel2.columnID, rowLevel2.text, resultText)

                Case 1
                    Call Me.TablePortDelay(rowLevel2.level1, LineID, resultText)

                Case 2
                    Call Me.TablePortEvent(rowLevel2.level1, LineID, resultText)

                Case Else
                    Stop

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to Add Row Port")

        End Try

    End Sub


    Private Sub TablePort(LineID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Select Case LineID
                Case 8
                    Me.MyNodeType = 1 ' Signal-LCC
                Case 16
                    Me.MyNodeType = 2 ' Tower-LCC
            End Select

            Dim rowPort As ExportXml.PortRow = Me.MyExportXml.Port.FindByLineID(LineID)
            Try
                If rowPort Is Nothing Then
                    Me.MyExportXml.Port.AddPortRow(LineID, String.Empty, 0, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowPort = Me.MyExportXml.Port.FindByLineID(LineID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Port row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Port I/O - " + "Line(" + LineID.ToString + ") - " + matchText + Space(1) + resultText)
            rowPort.Item(columnID - 2) = resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port row")

        End Try

    End Sub

    Private Sub TablePortDelay(level1 As Integer, LineID As Integer, text As String)

        Try

            Dim DelayID As Integer
            Dim resultText As String = String.Empty

            Dim rowlevel3 As ImportCDI.MatchLevel3Row = Me.MatchLevel3(level1, text, DelayID, resultText)
            If rowlevel3 Is Nothing Then
                Stop
            End If

            Dim rowPortDelay As ExportXml.PortDelayRow = Me.MyExportXml.PortDelay.FindByLineIDDelayID(LineID, DelayID)
            If rowPortDelay Is Nothing Then
                Try
                    Me.MyExportXml.PortDelay.AddPortDelayRow(LineID, DelayID, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowPortDelay = Me.MyExportXml.PortDelay.FindByLineIDDelayID(LineID, DelayID)
                Catch ex As Exception
                    MsgBox("Failed to create table Port Delay row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(MyLineNum.ToString + " Port I/O - " + "Line(" + LineID.ToString + ") - Delay(" + DelayID.ToString + ") - " + rowlevel3.text + Space(1) + resultText)
            rowPortDelay.Item(rowlevel3.columnID - 2) = resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port Delay row")

        End Try

    End Sub

    Private Sub TablePortEvent(level1 As Integer, LineID As Integer, text As String)

        Try

            Dim EventID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = Me.MatchLevel3(level1, text, EventID, resultText)
            If rowLevel3 Is Nothing Then
                Stop
            End If

            Dim rowPortEvent As ExportXml.PortEventRow = Me.MyExportXml.PortEvent.FindByLineIDEventID(LineID, EventID)
            If rowPortEvent Is Nothing Then
                Try
                    Me.MyExportXml.PortEvent.AddPortEventRow(LineID, EventID, String.Empty, 0, 0, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowPortEvent = Me.MyExportXml.PortEvent.FindByLineIDEventID(LineID, EventID)
                Catch ex As Exception
                    MsgBox("Failed to create table Port Event row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(MyLineNum.ToString + " Port I/O - Line(" + LineID.ToString + ") - " + "Event(" + EventID.ToString + ") - " + resultText)
            rowPortEvent.Item(rowLevel3.columnID - 2) = resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port Event")

        End Try

    End Sub


    Private Sub AddRowLogic(level1 As Integer, text As String)

        Try

            Dim LogicID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, LogicID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Select Case rowLevel2.level2
                Case 0 ' Logic section
                    Call Me.TableLogic(LogicID, rowLevel2.columnID, rowLevel2.text, resultText)

                Case 1 ' Logic Operation section
                    Call Me.TableLogicOperation(LogicID, rowLevel2.columnID, rowLevel2.text, resultText)

                Case 2 ' Logic Action
                    Call Me.TableLogicAction(LogicID, rowLevel2.columnID, rowLevel2.text, resultText)

                Case 3
                    Call Me.TableLogicProducer(rowLevel2.level1, LogicID, resultText)

                Case Else
                    MsgBox("Logic Section unknown - " + rowLevel2.level2)

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Logic")

        End Try

    End Sub

    Private Sub TableLogic(LogicID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogic As ExportXml.LogicRow = Me.MyExportXml.Logic.FindByLogicID(LogicID)
            Try
                If rowLogic Is Nothing Then
                    Me.MyExportXml.Logic.AddLogicRow(LogicID, String.Empty, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLogic = Me.MyExportXml.Logic.FindByLogicID(LogicID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Conditional - " + "Logic(" + LogicID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogic.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add Logic row")

        End Try

    End Sub

    Private Sub TableLogicOperation(LogicID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogicOP As ExportXml.LogicOperationRow = Me.MyExportXml.LogicOperation.FindByLogicID(LogicID)
            Try
                If rowLogicOP Is Nothing Then
                    Me.MyExportXml.LogicOperation.AddLogicOperationRow(LogicID, 0, 0, 0, String.Empty, String.Empty, 0, 0, 0, 0, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowLogicOP = Me.MyExportXml.LogicOperation.FindByLogicID(LogicID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic Operation row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Conditional - " + "Logic(" + LogicID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogicOP.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Operation row")

        End Try

    End Sub

    Private Sub TableLogicAction(LogicID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogicAction As ExportXml.LogicActionRow = Me.MyExportXml.LogicAction.FindByLogicID(LogicID)
            Try
                If rowLogicAction Is Nothing Then
                    Me.MyExportXml.LogicAction.AddLogicActionRow(LogicID, 0, 0, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLogicAction = Me.MyExportXml.LogicAction.FindByLogicID(LogicID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic Action row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Conditional - " + "Logic(" + LogicID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogicAction.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Action row")

        End Try

    End Sub

    Private Sub TableLogicProducer(level1 As Integer, LogicID As Integer, text As String)

        Try

            Dim ActionID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = Me.MatchLevel3(level1, text, ActionID, resultText)
            If rowLevel3 Is Nothing Then
                Stop
            End If

            Dim rowLogicProducer As ExportXml.LogicProducerRow = Me.MyExportXml.LogicProducer.FindByLogicIDActionID(LogicID, ActionID)
            If rowLogicProducer Is Nothing Then
                Try
                    Me.MyExportXml.LogicProducer.AddLogicProducerRow(LogicID, ActionID, 0, 0, 0, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowLogicProducer = Me.MyExportXml.LogicProducer.FindByLogicIDActionID(LogicID, ActionID)
                Catch ex As Exception
                    MsgBox("Failed to create table Logic Producer row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(MyLineNum.ToString + " Conditional - Logic(" + LogicID.ToString + ") - Action(" + ActionID.ToString + ") - " + rowLevel3.text + Space(1) + resultText)
            rowLogicProducer.Item(rowLevel3.columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Producer row")

        End Try

    End Sub


    Private Sub AddRowTrackCircuitRec(level1 As Integer, text As String)

        Try

            Dim CircuitID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, CircuitID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Dim rowCircuit As ExportXml.TrackReceiverRow = Me.MyExportXml.TrackReceiver.FindByCircuitID(CircuitID)
            Try
                If rowCircuit Is Nothing Then
                    Me.MyExportXml.TrackReceiver.AddTrackReceiverRow(CircuitID, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowCircuit = Me.MyExportXml.TrackReceiver.FindByCircuitID(CircuitID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Track Circuit Receiver row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Track Circuit Receiver - Circuit(" + CircuitID.ToString + ") - " + rowLevel2.text + Space(1) + resultText)
            rowCircuit.Item(rowLevel2.columnID) = resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Track Circuit Receiver row")

        End Try

    End Sub

    Private Sub AddRowTrackCircuitTran(level1 As Integer, text As String)

        Try

            Dim CircuitID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, CircuitID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Dim rowCircuit As ExportXml.TrackTransmitterRow = Me.MyExportXml.TrackTransmitter.FindByCircuitID(CircuitID)
            Try
                If rowCircuit Is Nothing Then
                    Me.MyExportXml.TrackTransmitter.AddTrackTransmitterRow(CircuitID, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowCircuit = Me.MyExportXml.TrackTransmitter.FindByCircuitID(CircuitID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Track Circuit Transmitter row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Track Circuit Transmitter - Circuit(" + CircuitID.ToString + ") - " + rowLevel2.text + Space(1) + resultText)
            rowCircuit.Item(rowLevel2.columnID) = resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Track Circuit Transmitter row")

        End Try

    End Sub


    Private Sub AddRowRuleToAspect(level1 As Integer, text As String)

        Try

            Dim MastID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, MastID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TableMast(MastID, rowLevel2.columnID, rowLevel2.text, resultText)

                Case 1
                    Call Me.TableMastRule(rowLevel2.level1, MastID, resultText)

                Case Else
                    Stop

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Rule To Aspect")

        End Try

    End Sub

    Private Sub TableMast(MastID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLogic As ExportXml.MastRow = Me.MyExportXml.Mast.FindByMastID(MastID)
            Try
                If rowLogic Is Nothing Then
                    Me.MyExportXml.Mast.AddMastRow(MastID, 0, String.Empty, String.Empty, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLogic = Me.MyExportXml.Mast.FindByMastID(MastID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Mast row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Mast(" + MastID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLogic.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Mast row")

        End Try

    End Sub


    Private Sub TableMastRule(level1 As Integer, MastID As Integer, text As String)

        Try

            Dim RuleID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = Me.MatchLevel3(level1, text, RuleID, resultText)
            If rowLevel3 Is Nothing Then
                Stop
            End If


            Select Case rowLevel3.level2
                Case 1

                    Dim rowMastRule As ExportXml.MastRuleRow = Me.MyExportXml.MastRule.FindByMastIDRuleID(MastID, RuleID)
                    If rowMastRule Is Nothing Then
                        Try
                            Me.MyExportXml.MastRule.AddMastRuleRow(MastID, RuleID, 0, 0, String.Empty, String.Empty, String.Empty, 0, 0)
                            Me.MyExportXml.AcceptChanges()
                            rowMastRule = Me.MyExportXml.MastRule.FindByMastIDRuleID(MastID, RuleID)
                        Catch ex As Exception
                            MsgBox("Failed to create table Mast Rule row")
                            Exit Sub
                        End Try
                    End If

                    Console.WriteLine(MyLineNum.ToString + " Mast - Mast(" + MastID.ToString + ") " + " - Rule(" + RuleID.ToString + ") - " + rowLevel3.text + Space(1) + resultText)
                    rowMastRule.Item(rowLevel3.columnID - 2) = resultText

                Case 2

                    Call Me.TableMastAppearance(rowLevel3.level1, MastID, RuleID, resultText)

                Case Else

                    Stop

            End Select


        Catch ex As Exception

            MsgBox("Failed to add table Mast Rule row")

        End Try

    End Sub


    Private Sub TableMastAppearance(level1 As Integer, MastID As Integer, RuleID As Integer, text As String)

        Try

            Dim AppearanceID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel4 As ImportCDI.MatchLevel4Row = Me.MatchLevel4(level1, text, AppearanceID, resultText)
            If rowLevel4 Is Nothing Then
                Stop
            End If

            Dim rowMastRuleAppear As ExportXml.MastRuleAppearRow = Me.MyExportXml.MastRuleAppear.FindByMastIDRuleIDAppearanceID(MastID, RuleID, AppearanceID)
            If rowMastRuleAppear Is Nothing Then
                Try
                    Me.MyExportXml.MastRuleAppear.AddMastRuleAppearRow(MastID, RuleID, AppearanceID, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowMastRuleAppear = Me.MyExportXml.MastRuleAppear.FindByMastIDRuleIDAppearanceID(MastID, RuleID, AppearanceID)
                Catch ex As Exception
                    MsgBox("Failed to create table Mast Rule Apperance row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(MyLineNum.ToString + " Mast - " + "Mast(" + MastID.ToString + ") - Rule(" + RuleID.ToString + ") - Appearance(" + AppearanceID.ToString + ") - " + rowLevel4.text + Space(1) + resultText)
            rowMastRuleAppear.Item(rowLevel4.columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Mast Rule Appearance row")

        End Try

    End Sub


    Private Sub AddRowLampDirectControl(level1 As Integer, text As String)

        Try

            Dim lineID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(level1, text, lineID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TableLamp(lineID, rowLevel2.columnID, rowLevel2.text, resultText)

                Case Else
                    Stop

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Lamp Direct Control")

        End Try

    End Sub


    Private Sub TableLamp(LampID As Integer, columnID As Integer, matchText As String, resultText As String)

        Try

            Dim rowLamp As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(LampID)
            Try
                If rowLamp Is Nothing Then
                    Me.MyExportXml.Lamp.AddLampRow(LampID, String.Empty, String.Empty, String.Empty, 0, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLamp = Me.MyExportXml.Lamp.FindByLampID(LampID)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Lamp row")
                Exit Sub
            End Try

            Console.WriteLine(MyLineNum.ToString + " Lamp(" + LampID.ToString + ") - " + matchText + Space(1) + resultText)
            rowLamp.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Lamp row")

        End Try

    End Sub


    Private Sub UpDateRowLampDirectControl(text As String)

        Try

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

            Dim rowLamp As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(LampID)
            If rowLamp Is Nothing Then
                MsgBox("Failed to find Lamp row " + LampID.ToString)
            Else
                rowLamp.brightness = resultText
                Console.WriteLine(MyLineNum.ToString + " Lamp(" + LampID.ToString + ") - Brightness= " + resultText)
            End If

            Me.MyExportXml.AcceptChanges()

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

End Class
