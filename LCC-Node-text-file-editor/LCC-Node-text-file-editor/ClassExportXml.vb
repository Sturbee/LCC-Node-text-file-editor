
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ClassExportXml

    Private Property MyClsImport As New ClsImportCDI
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

            ' export needs all track circuit data
            Try

                For rowCount = 0 To MyClsImport.MyImportCDI.TrackReceiver.Count - 1
                    Dim rowInRec As ImportCDI.TrackReceiverRow = MyClsImport.MyImportCDI.TrackReceiver.Item(rowCount)
                    MyExportXml.TrackReceiver.AddTrackReceiverRow(rowInRec.value, rowInRec.text, String.Empty)
                Next

                For rowCount = 0 To MyClsImport.MyImportCDI.TrackTransmitter.Count - 1
                    Dim rowInTran As ImportCDI.TrackTransmitterRow = MyClsImport.MyImportCDI.TrackTransmitter.Item(rowCount)
                    MyExportXml.TrackTransmitter.AddTrackTransmitterRow(rowInTran.value, rowInTran.text, String.Empty)
                Next

            Catch ex As Exception
                MsgBox("Failed to import Track Circuit values")
            End Try


            Dim lineNum As Integer = 0
            Dim sr As New StreamReader(filePath)
            Dim myText As String = String.Empty

            While Not sr.EndOfStream

                lineNum += 1

                myText = sr.ReadLine

                Dim row As ImportCDI.MatchLevel1Row = MyClsImport.MatchLevel1(lineNum, myText)

                Select Case row.level1

                    Case 0 ' segment node ID
                        Call Me.AddRowNode(lineNum, row.level1, row.resultText)

                    Case 1 ' segment power monitor
                        Call Me.AddRowPowerMonitor(lineNum, row.level1, row.resultText)

                    Case 2 ' segment port
                        Call Me.AddRowPort(lineNum, row.level1, row.resultText)

                    Case 3 ' segment conditional
                        Call Me.AddRowLogic(lineNum, row.level1, row.resultText)

                    Case 4 ' segment track circuit receiver
                        Call Me.AddRowTrackReceiver(lineNum, row.level1, row.resultText)

                    Case 5 ' segment track circuit transmitter
                        Call Me.AddRowTrackTransmitter(lineNum, row.level1, row.resultText)

                    Case 6 ' segment rule to aspect
                        Call Me.AddRowRuleToAspect(lineNum, row.level1, row.resultText)

                    Case 7 ' segment Direct Lamp Control
                        Call Me.AddRowLampDirectControl(lineNum, row.level1, row.resultText)

                    Case 8 ' 
                        Call Me.UpDateRowLampDirectControl(lineNum, row.resultText)

                    Case 9 ' Rules, ignore

                    Case Else
                        Stop

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
                    Dim rowI As ImportCDI.LampNameRow = MyClsImport.MyImportCDI.LampName.Item(count)
                    Dim rowE As ExportXml.LampRow = MyExportXml.Lamp.Item(count - 1)
                    If rowE.description = String.Empty Then
                        REM rowE.description = rowI.text
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

    Private Sub AddRowNode(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowNode As ExportXml.NodeRow = MyExportXml.Node.FindByNodeID(rowLevel2.item1)
            Try
                If rowNode Is Nothing Then
                    Me.MyExportXml.Node.AddNodeRow(rowLevel2.item1, String.Empty, String.Empty, 0, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowNode = Me.MyExportXml.Node.FindByNodeID(rowLevel2.item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Node row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + Space(1) + "Node ID - " + rowLevel2.text + Space(1) + rowLevel2.resultText)
            rowNode.Item(rowLevel2.columnID - 1) = rowLevel2.resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed add table Node row")

        End Try

    End Sub

    Private Sub AddRowPowerMonitor(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowlevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowPowerMonitor As ExportXml.PowerMonitorRow = Me.MyExportXml.PowerMonitor.FindByPowerMonitorID(rowlevel2.item1)
            Try
                If rowPowerMonitor Is Nothing Then
                    Me.MyExportXml.PowerMonitor.AddPowerMonitorRow(rowlevel2.item1, 0, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowPowerMonitor = Me.MyExportXml.PowerMonitor.FindByPowerMonitorID(rowlevel2.item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table PowerMonitor row")
            End Try

            Console.WriteLine(lineNum.ToString + Space(1) + "Node Power Monitor - " + rowlevel2.text + Space(1) + rowlevel2.resultText)
            rowPowerMonitor.Item(rowlevel2.columnID - 1) = rowlevel2.resultText
            If rowlevel2.columnID = 3 Then
                Me.MyNodeEventBase = Left(rowlevel2.resultText, 17)
            End If

            Me.MyExportXml.AcceptChanges()
        Catch ex As Exception

            MsgBox("Failed to add Power Monitor row")

        End Try

    End Sub

    Private Sub AddRowPort(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TablePort(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

                Case 1
                    Call Me.TablePortDelay(lineNum, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText)

                Case 2
                    Call Me.TablePortEvent(lineNum, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText)

                Case Else
                    Stop

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to Add Row Port")

        End Try

    End Sub


    Private Sub TablePort(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Try

            Select Case item1
                Case 8
                    Me.MyNodeType = 1 ' Signal-LCC
                Case 16
                    Me.MyNodeType = 2 ' Tower-LCC
            End Select

            Dim rowPort As ExportXml.PortRow = Me.MyExportXml.Port.FindByLineID(item1)
            Try
                If rowPort Is Nothing Then
                    Me.MyExportXml.Port.AddPortRow(item1, String.Empty, 0, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowPort = Me.MyExportXml.Port.FindByLineID(item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Port row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
            rowPort.Item(columnID - 2) = resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port row")

        End Try

    End Sub

    Private Sub TablePortDelay(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Try

            Dim rowlevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowPortDelay As ExportXml.PortDelayRow = Me.MyExportXml.PortDelay.FindByLineIDDelayID(item1, rowlevel3.item2)
            If rowPortDelay Is Nothing Then
                Try
                    Me.MyExportXml.PortDelay.AddPortDelayRow(item1, rowlevel3.item2, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowPortDelay = Me.MyExportXml.PortDelay.FindByLineIDDelayID(item1, rowlevel3.item2)
                Catch ex As Exception
                    MsgBox("Failed to create table Port Delay row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + item1.ToString + ") - Delay(" + rowlevel3.item2.ToString + ") - " + rowlevel3.text + Space(1) + rowlevel3.resultText)
            rowPortDelay.Item(rowlevel3.columnID - 2) = rowlevel3.resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port Delay row")

        End Try

    End Sub

    Private Sub TablePortEvent(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowPortEvent As ExportXml.PortEventRow = Me.MyExportXml.PortEvent.FindByLineIDEventID(item1, rowLevel3.item2)
            If rowPortEvent Is Nothing Then
                Try
                    Me.MyExportXml.PortEvent.AddPortEventRow(item1, rowLevel3.item2, String.Empty, 0, 0, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowPortEvent = Me.MyExportXml.PortEvent.FindByLineIDEventID(item1, rowLevel3.item2)
                Catch ex As Exception
                    MsgBox("Failed to create table Port Event row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(lineNum.ToString + " Port I/O - Line(" + item1.ToString + ") - " + "Event(" + rowLevel3.item2.ToString + ") - " + rowLevel3.resultText)
            rowPortEvent.Item(rowLevel3.columnID - 2) = rowLevel3.resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Port Event")

        End Try

    End Sub


    Private Sub AddRowLogic(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0 ' Logic section
                    Call Me.TableLogic(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

                Case 1 ' Logic Operation section
                    Call Me.TableLogicOperation(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

                Case 2 ' Logic Action
                    Call Me.TableLogicAction(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

                Case 3
                    Call Me.TableLogicProducer(lineNum, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText)

                Case Else
                    MsgBox("Logic Section unknown - " + rowLevel2.level2)

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Logic")

        End Try

    End Sub

    Private Sub TableLogic(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Try

            Dim rowLogic As ExportXml.LogicRow = Me.MyExportXml.Logic.FindByLogicID(item1)
            Try
                If rowLogic Is Nothing Then
                    Me.MyExportXml.Logic.AddLogicRow(item1, String.Empty, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLogic = Me.MyExportXml.Logic.FindByLogicID(item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
            rowLogic.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add Logic row")

        End Try

    End Sub

    Private Sub TableLogicOperation(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Try

            Dim rowLogicOP As ExportXml.LogicOperationRow = Me.MyExportXml.LogicOperation.FindByLogicID(item1)
            Try
                If rowLogicOP Is Nothing Then
                    Me.MyExportXml.LogicOperation.AddLogicOperationRow(item1, 0, 0, 0, String.Empty, String.Empty, 0, 0, 0, 0, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowLogicOP = Me.MyExportXml.LogicOperation.FindByLogicID(item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic Operation row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
            rowLogicOP.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Operation row")

        End Try

    End Sub

    Private Sub TableLogicAction(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Try

            Dim rowLogicAction As ExportXml.LogicActionRow = Me.MyExportXml.LogicAction.FindByLogicID(item1)
            Try
                If rowLogicAction Is Nothing Then
                    Me.MyExportXml.LogicAction.AddLogicActionRow(item1, 0, 0, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLogicAction = Me.MyExportXml.LogicAction.FindByLogicID(item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Logic Action row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
            rowLogicAction.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Action row")

        End Try

    End Sub

    Private Sub TableLogicProducer(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowLogicProducer As ExportXml.LogicProducerRow = Me.MyExportXml.LogicProducer.FindByLogicIDActionID(item1, rowLevel3.item2)
            If rowLogicProducer Is Nothing Then
                Try
                    Me.MyExportXml.LogicProducer.AddLogicProducerRow(item1, rowLevel3.item2, 0, 0, 0, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowLogicProducer = Me.MyExportXml.LogicProducer.FindByLogicIDActionID(item1, rowLevel3.item2)
                Catch ex As Exception
                    MsgBox("Failed to create table Logic Producer row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(lineNum.ToString + " Conditional - Logic(" + item1.ToString + ") - Action(" + rowLevel3.item2.ToString + ") - " + rowLevel3.text + Space(1) + rowLevel3.resultText)
            rowLogicProducer.Item(rowLevel3.columnID - 2) = rowLevel3.resultText

        Catch ex As Exception

            MsgBox("Failed to add table Logic Producer row")

        End Try

    End Sub


    Private Sub AddRowTrackReceiver(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowCircuit As ExportXml.TrackReceiverRow = Me.MyExportXml.TrackReceiver.FindByCircuitID(rowLevel2.item1)
            Try
                If rowCircuit Is Nothing Then
                    Me.MyExportXml.TrackReceiver.AddTrackReceiverRow(rowLevel2.item1, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowCircuit = Me.MyExportXml.TrackReceiver.FindByCircuitID(rowLevel2.item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Track Circuit Receiver row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Track Circuit Receiver - Circuit(" + rowLevel2.item1.ToString + ") - " + rowLevel2.text + Space(1) + rowLevel2.resultText)
            rowCircuit.Item(rowLevel2.columnID) = rowLevel2.resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Track Circuit Receiver row")

        End Try

    End Sub

    Private Sub AddRowTrackTransmitter(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowCircuit As ExportXml.TrackTransmitterRow = Me.MyExportXml.TrackTransmitter.FindByCircuitID(rowLevel2.item1)
            Try
                If rowCircuit Is Nothing Then
                    Me.MyExportXml.TrackTransmitter.AddTrackTransmitterRow(rowLevel2.item1, String.Empty, String.Empty)
                    Me.MyExportXml.AcceptChanges()
                    rowCircuit = Me.MyExportXml.TrackTransmitter.FindByCircuitID(rowLevel2.item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Track Circuit Transmitter row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Track Circuit Transmitter - Circuit(" + rowLevel2.item1.ToString + ") - " + rowLevel2.text + Space(1) + rowLevel2.resultText)
            rowCircuit.Item(rowLevel2.columnID) = rowLevel2.resultText

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed to add table Track Circuit Transmitter row")

        End Try

    End Sub


    Private Sub AddRowRuleToAspect(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TableMast(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

                Case 1
                    Call Me.TableMastRule(lineNum, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText)

                Case Else
                    Stop

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Rule To Aspect")

        End Try

    End Sub

    Private Sub TableMast(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Try

            Dim rowLogic As ExportXml.MastRow = Me.MyExportXml.Mast.FindByMastID(item1)
            Try
                If rowLogic Is Nothing Then
                    Me.MyExportXml.Mast.AddMastRow(item1, 0, String.Empty, String.Empty, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLogic = Me.MyExportXml.Mast.FindByMastID(item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Mast row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Mast(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
            rowLogic.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Mast row")

        End Try

    End Sub


    Private Sub TableMastRule(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, inputText)

            Select Case rowLevel3.level2
                Case 1

                    Dim rowMastRule As ExportXml.MastRuleRow = Me.MyExportXml.MastRule.FindByMastIDRuleID(item1, rowLevel3.item2)
                    If rowMastRule Is Nothing Then
                        Try
                            Me.MyExportXml.MastRule.AddMastRuleRow(item1, rowLevel3.item2, 0, 0, String.Empty, String.Empty, String.Empty, 0, 0)
                            Me.MyExportXml.AcceptChanges()
                            rowMastRule = Me.MyExportXml.MastRule.FindByMastIDRuleID(item1, rowLevel3.item2)
                        Catch ex As Exception
                            MsgBox("Failed to create table Mast Rule row")
                            Exit Sub
                        End Try
                    End If

                    Console.WriteLine(lineNum.ToString + " Mast - Mast(" + item1.ToString + ") " + " - Rule(" + rowLevel3.item2.ToString + ") - " + rowLevel3.text + Space(1) + rowLevel3.resultText)
                    rowMastRule.Item(rowLevel3.columnID - 2) = rowLevel3.resultText

                Case 2

                    Call Me.TableMastAppearance(lineNum, rowLevel3.level1, item1, rowLevel3.item2, rowLevel3.resultText)

                Case Else

                    Stop

            End Select


        Catch ex As Exception

            MsgBox("Failed to add table Mast Rule row")

        End Try

    End Sub


    Private Sub TableMastAppearance(lineNum As Integer, level1 As Integer, item1 As Integer, item2 As Integer, inputText As String)

        Try

            Dim rowLevel4 As ImportCDI.MatchLevel4Row = MyClsImport.MatchLevel4(lineNum, level1, inputText)

            Dim rowMastRuleAppear As ExportXml.MastRuleAppearRow = Me.MyExportXml.MastRuleAppear.FindByMastIDRuleIDAppearanceID(item1, item2, rowLevel4.item3)
            If rowMastRuleAppear Is Nothing Then
                Try
                    Me.MyExportXml.MastRuleAppear.AddMastRuleAppearRow(item1, item2, rowLevel4.item3, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowMastRuleAppear = Me.MyExportXml.MastRuleAppear.FindByMastIDRuleIDAppearanceID(item1, item2, rowLevel4.item3)
                Catch ex As Exception
                    MsgBox("Failed to create table Mast Rule Apperance row")
                    Exit Sub
                End Try
            End If

            Console.WriteLine(lineNum.ToString + " Mast - " + "Mast(" + item1.ToString + ") - Rule(" + item2.ToString + ") - Appearance(" + rowLevel4.item3.ToString + ") - " + rowLevel4.text + Space(1) + rowLevel4.resultText)
            rowMastRuleAppear.Item(rowLevel4.columnID - 2) = rowLevel4.resultText

        Catch ex As Exception

            MsgBox("Failed to add table Mast Rule Appearance row")

        End Try

    End Sub


    Private Sub AddRowLampDirectControl(lineNum As Integer, level1 As Integer, inputText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TableLamp(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

                Case Else
                    Stop

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Lamp Direct Control")

        End Try

    End Sub


    Private Sub TableLamp(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Try

            Dim rowLamp As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(item1)
            Try
                If rowLamp Is Nothing Then
                    Me.MyExportXml.Lamp.AddLampRow(item1, String.Empty, String.Empty, String.Empty, 0, 0, 0, 0)
                    Me.MyExportXml.AcceptChanges()
                    rowLamp = Me.MyExportXml.Lamp.FindByLampID(item1)
                End If
            Catch ex As Exception
                MsgBox("Failed to create table Lamp row")
                Exit Sub
            End Try

            Console.WriteLine(lineNum.ToString + " Lamp(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
            rowLamp.Item(columnID - 2) = resultText

        Catch ex As Exception

            MsgBox("Failed to add table Lamp row")

        End Try

    End Sub


    Private Sub UpDateRowLampDirectControl(lineNum As Integer, inputText As String)

        Try

            Dim item1 As Integer = Val(inputText)

            Dim startInt As Integer = 0
            Dim myMatch As String = "="
            Dim resultInt As Integer = 0
            Dim resultText As String = String.Empty

            startInt = InStr(inputText, myMatch)
            If startInt > 0 Then
                resultInt = startInt + Len(myMatch)
                resultText = Mid(inputText, resultInt)
            End If

            Dim rowLamp As ExportXml.LampRow = Me.MyExportXml.Lamp.FindByLampID(item1)
            If rowLamp Is Nothing Then
                MsgBox("Failed to find Lamp row " + item1.ToString)
            Else
                rowLamp.brightness = resultText
                Console.WriteLine(lineNum.ToString + " Lamp(" + item1.ToString + ") - Brightness= " + resultText)
            End If

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed UpDate Row Lamp Direct Control")

        End Try

    End Sub

End Class
