
Imports System.IO

Public Class ClassExportXml

    Private Property MyImport As New ClsImportCDI
    Private Property MyExport As New ClsExportXML
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

            Dim filePathXml As String = String.Empty
            Try
                Dim clsU As New ClsUserPrefs
                Dim row As UserPrefs.UserJMRIRow = clsU.UserPrefs.UserJMRI.FindByvalue(ClsUserPrefs.JMRIfileDirectory.ExportXml)
                filePathXml = row.path + "\" + Path.GetFileName(filePath) + ".xml"
            Catch ex As Exception
                MsgBox("Failed to get export xml file path " + filePathXml)
                Exit Sub
            End Try

            MyExport.DbExport = New ExportXml

            ' export needs all track circuit data
            Try

                For rowCount = 0 To MyImport.ImportCDI.TrackReceiver.Count - 1
                    Dim rowInRec As ImportCDI.TrackReceiverRow = MyImport.ImportCDI.TrackReceiver.Item(rowCount)
                    MyExport.DbExport.TrackReceiver.AddTrackReceiverRow(rowInRec.value, rowInRec.text, String.Empty)
                Next

                For rowCount = 0 To MyImport.ImportCDI.TrackTransmitter.Count - 1
                    Dim rowInTran As ImportCDI.TrackTransmitterRow = MyImport.ImportCDI.TrackTransmitter.Item(rowCount)
                    MyExport.DbExport.TrackTransmitter.AddTrackTransmitterRow(rowInTran.value, rowInTran.text, String.Empty)
                Next

            Catch ex As Exception
                MsgBox("Failed to import Track Circuit values")
                Exit Sub
            End Try


            Dim lineNum As Integer = 0
            Dim sr As New StreamReader(filePath)
            Dim myText As String = String.Empty

            While Not sr.EndOfStream

                lineNum += 1

                myText = sr.ReadLine

                Dim row As ImportCDI.MatchLevel1Row = MyImport.MatchLevel1(lineNum, myText)

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
                        Call Me.AddRowLamp(lineNum, row.resultText)

                    Case 9 ' Rules, ignore

                    Case Else
                        Throw New MyException("MyExportToXmlFile Level1 value = " + row.level1.ToString + ", Line " + lineNum.ToString + Space(1) + row.resultText)

                End Select

            End While ' read the next text line

            sr.Close()

            ' update values after process is done
            Dim rowNode As ExportXml.NodeRow = Me.MyExport.DbExport.Node.FindByNodeID(0)
            If rowNode Is Nothing Then
                ' do nothing
            Else
                rowNode.eventBase = Me.MyNodeEventBase
                rowNode.nodeType = Me.MyNodeType
                rowNode.sourceFile = filePath
            End If

            Me.MyExport.DbExport.AcceptChanges()

            Try
                Me.MyExport.DbExport.WriteXml(filePathXml)
                MsgBox("Xml file has been created for " + filePathXml)
            Catch ex As Exception
                MsgBox("Failed to save xml file")
            End Try

        Catch ex As MyException

            MsgBox(ex.Message)

        Catch ex As Exception

            MsgBox(ex.StackTrace)

        End Try

    End Sub

    Private Sub AddRowNode(lineNum As Integer, level1 As Integer, inputText As String)

        Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

        Dim rowNode As ExportXml.NodeRow = MyExport.DbExport.Node.FindByNodeID(rowLevel2.item1)
        If rowNode Is Nothing Then
            Me.MyExport.DbExport.Node.AddNodeRow(rowLevel2.item1, String.Empty, String.Empty, 0, String.Empty, String.Empty)
            Me.MyExport.DbExport.AcceptChanges()
            rowNode = Me.MyExport.DbExport.Node.FindByNodeID(rowLevel2.item1)
        End If

        Console.WriteLine(lineNum.ToString + Space(1) + "Node ID - " + rowLevel2.text + Space(1) + rowLevel2.resultText)
        rowNode.Item(rowLevel2.columnID - 1) = rowLevel2.resultText

        Me.MyExport.DbExport.AcceptChanges()

    End Sub

    Private Sub AddRowPowerMonitor(lineNum As Integer, level1 As Integer, inputText As String)



        Dim rowlevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowPowerMonitor As ExportXml.PowerMonitorRow = Me.MyExport.DbExport.PowerMonitor.FindByPowerMonitorID(rowlevel2.item1)

        If rowPowerMonitor Is Nothing Then
            Me.MyExport.DbExport.PowerMonitor.AddPowerMonitorRow(rowlevel2.item1, 0, String.Empty, String.Empty)
            Me.MyExport.DbExport.AcceptChanges()
            rowPowerMonitor = Me.MyExport.DbExport.PowerMonitor.FindByPowerMonitorID(rowlevel2.item1)
        End If


        Console.WriteLine(lineNum.ToString + Space(1) + "Node Power Monitor - " + rowlevel2.text + Space(1) + rowlevel2.resultText)
        rowPowerMonitor.Item(rowlevel2.columnID - 1) = rowlevel2.resultText
        If rowlevel2.columnID = 3 Then
            Me.MyNodeEventBase = Left(rowlevel2.resultText, 17)
        End If

        Me.MyExport.DbExport.AcceptChanges()

    End Sub

    Private Sub AddRowPort(lineNum As Integer, level1 As Integer, inputText As String)

        Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

        Select Case rowLevel2.level2
            Case 0
                Call Me.TablePort(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

            Case 1
                Call Me.TablePortDelay(lineNum, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText)

            Case 2
                Call Me.TablePortEvent(lineNum, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText)

            Case Else
                Throw New MyException("AddRowPort Level2 value = " + rowLevel2.level2.ToString + ", Line " + lineNum.ToString + Space(1) + inputText)

        End Select

        Me.MyExport.DbExport.AcceptChanges()

    End Sub


    Private Sub TablePort(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Select Case item1
            Case 8
                Me.MyNodeType = 1 ' Signal-LCC
            Case 16
                Me.MyNodeType = 2 ' Tower-LCC
        End Select

        Dim rowPort As ExportXml.PortRow = Me.MyExport.DbExport.Port.FindByLineID(item1)

        If rowPort Is Nothing Then
            Me.MyExport.DbExport.Port.AddPortRow(item1, String.Empty, 0, 0, 0, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowPort = Me.MyExport.DbExport.Port.FindByLineID(item1)
        End If

        Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
        rowPort.Item(columnID - 2) = resultText

        Me.MyExport.DbExport.AcceptChanges()

    End Sub

    Private Sub TablePortDelay(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Dim rowlevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

        Dim rowPortDelay As ExportXml.PortDelayRow = Me.MyExport.DbExport.PortDelay.FindByLineIDDelayID(item1, rowlevel3.item2)
        If rowPortDelay Is Nothing Then
            Me.MyExport.DbExport.PortDelay.AddPortDelayRow(item1, rowlevel3.item2, 0, 0, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowPortDelay = Me.MyExport.DbExport.PortDelay.FindByLineIDDelayID(item1, rowlevel3.item2)
        End If

        Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + item1.ToString + ") - Delay(" + rowlevel3.item2.ToString + ") - " + rowlevel3.text + Space(1) + rowlevel3.resultText)
        rowPortDelay.Item(rowlevel3.columnID - 2) = rowlevel3.resultText

        Me.MyExport.DbExport.AcceptChanges()

    End Sub

    Private Sub TablePortEvent(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

        Dim rowPortEvent As ExportXml.PortEventRow = Me.MyExport.DbExport.PortEvent.FindByLineIDEventID(item1, rowLevel3.item2)
        If rowPortEvent Is Nothing Then
            Me.MyExport.DbExport.PortEvent.AddPortEventRow(item1, rowLevel3.item2, String.Empty, 0, 0, String.Empty)
            Me.MyExport.DbExport.AcceptChanges()
            rowPortEvent = Me.MyExport.DbExport.PortEvent.FindByLineIDEventID(item1, rowLevel3.item2)
        End If

        Console.WriteLine(lineNum.ToString + " Port I/O - Line(" + item1.ToString + ") - " + "Event(" + rowLevel3.item2.ToString + ") - " + rowLevel3.resultText)
        rowPortEvent.Item(rowLevel3.columnID - 2) = rowLevel3.resultText

        Me.MyExport.DbExport.AcceptChanges()

    End Sub


    Private Sub AddRowLogic(lineNum As Integer, level1 As Integer, inputText As String)

        Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

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
                Throw New MyException("AddRowLogic Level2 value = " + rowLevel2.level2.ToString + ", Line " + lineNum.ToString + Space(1) + inputText)

        End Select

        Me.MyExport.DbExport.AcceptChanges()

    End Sub

    Private Sub TableLogic(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Dim rowLogic As ExportXml.LogicRow = Me.MyExport.DbExport.Logic.FindByLogicID(item1)
        If rowLogic Is Nothing Then
            Me.MyExport.DbExport.Logic.AddLogicRow(item1, String.Empty, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowLogic = Me.MyExport.DbExport.Logic.FindByLogicID(item1)
        End If


        Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
        rowLogic.Item(columnID - 2) = resultText

    End Sub

    Private Sub TableLogicOperation(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Dim rowLogicOP As ExportXml.LogicOperationRow = Me.MyExport.DbExport.LogicOperation.FindByLogicID(item1)
        If rowLogicOP Is Nothing Then
            Me.MyExport.DbExport.LogicOperation.AddLogicOperationRow(item1, 0, 0, 0, String.Empty, String.Empty, 0, 0, 0, 0, String.Empty, String.Empty)
            Me.MyExport.DbExport.AcceptChanges()
            rowLogicOP = Me.MyExport.DbExport.LogicOperation.FindByLogicID(item1)
        End If

        Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
        rowLogicOP.Item(columnID - 2) = resultText

    End Sub

    Private Sub TableLogicAction(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Dim rowLogicAction As ExportXml.LogicActionRow = Me.MyExport.DbExport.LogicAction.FindByLogicID(item1)
        If rowLogicAction Is Nothing Then
            Me.MyExport.DbExport.LogicAction.AddLogicActionRow(item1, 0, 0, 0, 0, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowLogicAction = Me.MyExport.DbExport.LogicAction.FindByLogicID(item1)
        End If

        Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
        rowLogicAction.Item(columnID - 2) = resultText

    End Sub

    Private Sub TableLogicProducer(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

        Dim rowLogicProducer As ExportXml.LogicProducerRow = Me.MyExport.DbExport.LogicProducer.FindByLogicIDActionID(item1, rowLevel3.item2)
        If rowLogicProducer Is Nothing Then
            Me.MyExport.DbExport.LogicProducer.AddLogicProducerRow(item1, rowLevel3.item2, 0, 0, 0, String.Empty)
            Me.MyExport.DbExport.AcceptChanges()
            rowLogicProducer = Me.MyExport.DbExport.LogicProducer.FindByLogicIDActionID(item1, rowLevel3.item2)
        End If

        Console.WriteLine(lineNum.ToString + " Conditional - Logic(" + item1.ToString + ") - Action(" + rowLevel3.item2.ToString + ") - " + rowLevel3.text + Space(1) + rowLevel3.resultText)
        rowLogicProducer.Item(rowLevel3.columnID - 2) = rowLevel3.resultText

    End Sub


    Private Sub AddRowTrackReceiver(lineNum As Integer, level1 As Integer, inputText As String)

        Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

        Dim rowCircuit As ExportXml.TrackReceiverRow = Me.MyExport.DbExport.TrackReceiver.FindByCircuitID(rowLevel2.item1)
        If rowCircuit Is Nothing Then
            Me.MyExport.DbExport.TrackReceiver.AddTrackReceiverRow(rowLevel2.item1, String.Empty, String.Empty)
            Me.MyExport.DbExport.AcceptChanges()
            rowCircuit = Me.MyExport.DbExport.TrackReceiver.FindByCircuitID(rowLevel2.item1)
        End If

        Console.WriteLine(lineNum.ToString + " Track Circuit Receiver - Circuit(" + rowLevel2.item1.ToString + ") - " + rowLevel2.text + Space(1) + rowLevel2.resultText)
        rowCircuit.Item(rowLevel2.columnID) = rowLevel2.resultText

        Me.MyExport.DbExport.AcceptChanges()

    End Sub

    Private Sub AddRowTrackTransmitter(lineNum As Integer, level1 As Integer, inputText As String)

        Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

        Dim rowCircuit As ExportXml.TrackTransmitterRow = Me.MyExport.DbExport.TrackTransmitter.FindByCircuitID(rowLevel2.item1)
        If rowCircuit Is Nothing Then
            Me.MyExport.DbExport.TrackTransmitter.AddTrackTransmitterRow(rowLevel2.item1, String.Empty, String.Empty)
            Me.MyExport.DbExport.AcceptChanges()
            rowCircuit = Me.MyExport.DbExport.TrackTransmitter.FindByCircuitID(rowLevel2.item1)
        End If

        Console.WriteLine(lineNum.ToString + " Track Circuit Transmitter - Circuit(" + rowLevel2.item1.ToString + ") - " + rowLevel2.text + Space(1) + rowLevel2.resultText)
        rowCircuit.Item(rowLevel2.columnID) = rowLevel2.resultText

        Me.MyExport.DbExport.AcceptChanges()

    End Sub


    Private Sub AddRowRuleToAspect(lineNum As Integer, level1 As Integer, inputText As String)

        Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

        Select Case rowLevel2.level2
            Case 0
                Call Me.TableMast(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

            Case 1
                Call Me.TableMastRule(lineNum, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText)

            Case Else
                Throw New MyException("AddRowRuleToAspect Level2 value = " + rowLevel2.level2.ToString + ", Line " + lineNum.ToString + Space(1) + inputText)

        End Select

        Me.MyExport.DbExport.AcceptChanges()

    End Sub

    Private Sub TableMast(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Dim rowLogic As ExportXml.MastRow = Me.MyExport.DbExport.Mast.FindByMastID(item1)
        If rowLogic Is Nothing Then
            Me.MyExport.DbExport.Mast.AddMastRow(item1, 0, String.Empty, String.Empty, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowLogic = Me.MyExport.DbExport.Mast.FindByMastID(item1)
        End If

        Console.WriteLine(lineNum.ToString + " Mast(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
        rowLogic.Item(columnID - 2) = resultText

    End Sub


    Private Sub TableMastRule(lineNum As Integer, level1 As Integer, item1 As Integer, inputText As String)

        Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

        Select Case rowLevel3.level2
            Case 1
                Dim rowMastRule As ExportXml.MastRuleRow = Me.MyExport.DbExport.MastRule.FindByMastIDRuleID(item1, rowLevel3.item2)
                If rowMastRule Is Nothing Then
                    Me.MyExport.DbExport.MastRule.AddMastRuleRow(item1, rowLevel3.item2, 0, 0, String.Empty, String.Empty, String.Empty, 0, 0)
                    Me.MyExport.DbExport.AcceptChanges()
                    rowMastRule = Me.MyExport.DbExport.MastRule.FindByMastIDRuleID(item1, rowLevel3.item2)
                End If

                Console.WriteLine(lineNum.ToString + " Mast - Mast(" + item1.ToString + ") " + " - Rule(" + rowLevel3.item2.ToString + ") - " + rowLevel3.text + Space(1) + rowLevel3.resultText)
                rowMastRule.Item(rowLevel3.columnID - 2) = rowLevel3.resultText

            Case 2
                Call Me.TableMastAppearance(lineNum, rowLevel3.level1, item1, rowLevel3.item2, rowLevel3.resultText)

            Case Else
                Throw New MyException("AddRowPort Level2 value = " + rowLevel3.level2.ToString + ", Line " + lineNum.ToString + Space(1) + inputText)

        End Select

    End Sub


    Private Sub TableMastAppearance(lineNum As Integer, level1 As Integer, item1 As Integer, item2 As Integer, inputText As String)

        Dim rowLevel4 As ImportCDI.MatchLevel4Row = MyImport.MatchLevel4(lineNum, level1, inputText)

        Dim rowMastRuleAppear As ExportXml.MastRuleAppearRow = Me.MyExport.DbExport.MastRuleAppear.FindByMastIDRuleIDAppearanceID(item1, item2, rowLevel4.item3)
        If rowMastRuleAppear Is Nothing Then
            Me.MyExport.DbExport.MastRuleAppear.AddMastRuleAppearRow(item1, item2, rowLevel4.item3, 0, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowMastRuleAppear = Me.MyExport.DbExport.MastRuleAppear.FindByMastIDRuleIDAppearanceID(item1, item2, rowLevel4.item3)
        End If

        Console.WriteLine(lineNum.ToString + " Mast - " + "Mast(" + item1.ToString + ") - Rule(" + item2.ToString + ") - Appearance(" + rowLevel4.item3.ToString + ") - " + rowLevel4.text + Space(1) + rowLevel4.resultText)
        rowMastRuleAppear.Item(rowLevel4.columnID - 2) = rowLevel4.resultText

    End Sub


    Private Sub AddRowLampDirectControl(lineNum As Integer, level1 As Integer, inputText As String)

        Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

        Select Case rowLevel2.level2
            Case 0
                Call Me.TableLampDirect(lineNum, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, rowLevel2.resultText)

            Case Else
                Throw New MyException("AddRowLampDirectControl Level2 value = " + rowLevel2.level2.ToString + ", Line " + lineNum.ToString + Space(1) + inputText)

        End Select

        Me.MyExport.DbExport.AcceptChanges()

    End Sub


    Private Sub TableLampDirect(lineNum As Integer, item1 As Integer, columnID As Integer, inputText As String, resultText As String)

        Dim rowLampDirect As ExportXml.LampDirectRow = Me.MyExport.DbExport.LampDirect.FindByLampDirectID(item1)
        If rowLampDirect Is Nothing Then
            Me.MyExport.DbExport.LampDirect.AddLampDirectRow(item1, String.Empty, String.Empty, String.Empty, 0, 0, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowLampDirect = Me.MyExport.DbExport.LampDirect.FindByLampDirectID(item1)
        End If

        Console.WriteLine(lineNum.ToString + " LampDirect(" + item1.ToString + ") - " + inputText + Space(1) + resultText)
        rowLampDirect.Item(columnID - 2) = resultText

    End Sub

    Private Sub AddRowLamp(lineNum As Integer, inputText As String)

        Dim item1 As Integer = Val(inputText)

        Dim startInt As Integer
        Dim myMatch As String = "="
        Dim resultInt As Integer
        Dim resultText As String = String.Empty

        startInt = InStr(inputText, myMatch)
        If startInt > 0 Then
            resultInt = startInt + Len(myMatch)
            resultText = Mid(inputText, resultInt)
        End If

        Dim rowLamp As ExportXml.LampRow = Me.MyExport.DbExport.Lamp.FindByLampID(item1)
        If rowLamp Is Nothing Then
            Me.MyExport.DbExport.Lamp.AddLampRow(item1, 0)
            Me.MyExport.DbExport.AcceptChanges()
            rowLamp = Me.MyExport.DbExport.Lamp.FindByLampID(item1)
        End If

        rowLamp.brightness = resultText
        Console.WriteLine(lineNum.ToString + " Lamp(" + item1.ToString + ") - Brightness= " + resultText)

        MyExport.DbExport.AcceptChanges()

    End Sub

End Class
