Imports System.IO

Public Class ClassExportXmlToText
    Private Property MyImport As New ClsImportCDI
    Private Property MyExport As New ClsExportXML

    Public Sub MyExportXmlToTextFile(filePath As String)

        If File.Exists(filePath) = False Then
            File.Delete(filePath)
            MsgBox(filePath + " does not exit")
            Exit Sub
        End If

        MyExport.DbExportReadFile(filePath)

        Try
            Dim nodeRow As ExportXml.NodeRow = MyExport.DbExport.Node.Item(0)
            Dim sourcePath As String = nodeRow.sourceFile
            If File.Exists(sourcePath) = False Then
                File.Delete(sourcePath)
                MsgBox(sourcePath + " does not exit")
                Exit Sub
            End If

            Dim outputPath As String = String.Empty
            Try
                Dim clsU As New ClsUserPrefs
                Dim row As UserPrefs.UserJMRIRow = clsU.UserPrefs.UserJMRI.FindByvalue(2)

                outputPath = row.path + "\" + Path.GetFileName(sourcePath) + ".xml.txt"

            Catch ex As Exception
                MsgBox("Failed to get restore file name")
                Exit Sub
            End Try

            Dim lineNum As Integer = 0
            Dim srIn As New StreamReader(sourcePath)
            Dim myText As String = String.Empty
            Dim writeText As String = String.Empty

            Dim srOut As New StreamWriter(outputPath)

            While Not srIn.EndOfStream

                lineNum += 1

                myText = srIn.ReadLine
                writeText = String.Empty

                ' process read line
                Dim row As ImportCDI.MatchLevel1Row = MyImport.MatchLevel1(lineNum, myText)

                Select Case row.level1

                    Case 0 ' segment node ID
                        Call Me.RowNode(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 1 ' segment power monitor
                        Call Me.RowPowerMonitor(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 2 ' segment port
                        Call Me.RowPort(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 3 ' segment conditional
                        Call Me.RowLogic(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 4 ' segment track circuit receiver
                        Call Me.RowTrackReceiver(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 5 ' segment track circuit transmitter
                        Call Me.RowTrackTransmitter(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 6 ' segment rule to aspect
                        Call Me.RowRuleToAspect(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 7 ' segment Direct Lamp Control
                        Call Me.RowLampDirectControl(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 8 ' 
                        Call Me.UpDateRowLampDirectControl(lineNum, myText, row.resultText, writeText)

                    Case 9 ' Rules, ignore
                        writeText = myText

                    Case Else
                        Stop

                End Select

                If myText = writeText Then
                    ' do nothing
                Else
                    ' output text lines that are different from input to output
                    ' Stop
                End If

                srOut.WriteLine(writeText)

            End While

            srIn.Close()
            srOut.Close()

            MsgBox("Finished creating restore file " + outputPath)

        Catch ex As Exception
            MsgBox("Failed to create new text file")
        End Try

    End Sub

    Private Sub RowNode(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowNode As ExportXml.NodeRow = MyExport.DbExport.Node.FindByNodeID(rowLevel2.level2)
            Dim newResultText = rowNode.Item(rowLevel2.columnID - 1).ToString

            Dim cut As Integer = InStr(myText, rowLevel2.resultText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + Space(1) + "Node ID - " + rowLevel2.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed process table Node row")

        End Try

    End Sub

    Private Sub RowPowerMonitor(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowlevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowPowerMonitor As ExportXml.PowerMonitorRow = Me.MyExport.DbExport.PowerMonitor.FindByPowerMonitorID(rowlevel2.level2)
            Dim newResultText = rowPowerMonitor.Item(rowlevel2.columnID - 1).ToString

            Dim cut As Integer = InStr(myText, rowlevel2.resultText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + Space(1) + "Node Power Monitor - " + rowlevel2.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Power Monitor row")

        End Try

    End Sub

    Private Sub RowPort(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TablePort(lineNum, myText, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 1
                    Call Me.TablePortDelay(lineNum, myText, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText, writeText)

                Case 2
                    Call Me.TablePortEvent(lineNum, myText, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText, writeText)

                Case Else
                    MsgBox("Level2 value unknown")

            End Select

        Catch ex As Exception

            MsgBox("Failed to read process port")

        End Try

    End Sub


    Private Sub TablePort(lineNum As Integer, myText As String, item1 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowPort As ExportXml.PortRow = Me.MyExport.DbExport.Port.FindByLineID(item1)
            Dim newResultText = rowPort.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + item1.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port row")

        End Try

    End Sub

    Private Sub TablePortDelay(lineNum As Integer, myText As String, level1 As Integer, item1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowlevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowPortDelay As ExportXml.PortDelayRow = Me.MyExport.DbExport.PortDelay.FindByLineIDDelayID(item1, rowlevel3.item2)

            Dim newResultText = rowPortDelay.Item(rowlevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowlevel3.text) + Len(rowlevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + item1.ToString + ") - Delay(" + rowlevel3.item2.ToString + ") - " + rowlevel3.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port Delay row")

        End Try

    End Sub

    Private Sub TablePortEvent(lineNum As Integer, myText As String, level1 As Integer, item1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowPortEvent As ExportXml.PortEventRow = Me.MyExport.DbExport.PortEvent.FindByLineIDEventID(item1, rowLevel3.item2)

            Dim newResultText = rowPortEvent.Item(rowLevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowLevel3.text) + Len(rowLevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - Line(" + item1.ToString + ") - " + "Event(" + rowLevel3.item2.ToString + ") - " + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port Event")

        End Try

    End Sub

    Private Sub RowLogic(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0 ' Logic section
                    Call Me.TableLogic(lineNum, myText, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 1 ' Logic Operation section
                    Call Me.TableLogicOperation(lineNum, myText, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 2 ' Logic Action
                    Call Me.TableLogicAction(lineNum, myText, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 3
                    Call Me.TableLogicProducer(lineNum, myText, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText, writeText)

                Case Else
                    MsgBox("Logic Section unknown - " + rowLevel2.level2)

            End Select

            Me.MyExport.DbExport.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Logic")

        End Try

    End Sub

    Private Sub TableLogic(lineNum As Integer, myText As String, item1 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLogic As ExportXml.LogicRow = Me.MyExport.DbExport.Logic.FindByLogicID(item1)
            Dim newResultText = rowLogic.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process Logic row")

        End Try

    End Sub

    Private Sub TableLogicOperation(lineNum As Integer, myText As String, item1 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLogicOP As ExportXml.LogicOperationRow = Me.MyExport.DbExport.LogicOperation.FindByLogicID(item1)
            Dim newResultText = rowLogicOP.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Logic Operation row")

        End Try

    End Sub

    Private Sub TableLogicAction(lineNum As Integer, myText As String, item1 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLogicAction As ExportXml.LogicActionRow = Me.MyExport.DbExport.LogicAction.FindByLogicID(item1)
            Dim newResultText = rowLogicAction.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + item1.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Logic Action row")

        End Try

    End Sub

    Private Sub TableLogicProducer(lineNum As Integer, myText As String, level1 As Integer, item1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowLogicProducer As ExportXml.LogicProducerRow = Me.MyExport.DbExport.LogicProducer.FindByLogicIDActionID(item1, rowLevel3.item2)
            Dim newResultText = rowLogicProducer.Item(rowLevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowLevel3.text) + Len(rowLevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - Logic(" + item1.ToString + ") - Action(" + rowLevel3.item2.ToString + ") - " + rowLevel3.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Logic Producer row")

        End Try

    End Sub

    Private Sub RowRuleToAspect(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TableMast(lineNum, myText, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 1
                    Call Me.TableMastRule(lineNum, myText, rowLevel2.level1, rowLevel2.item1, rowLevel2.resultText, writeText)

                Case Else

                    Stop

            End Select

        Catch ex As Exception

            MsgBox("Failed to process Row Rule To Aspect")

        End Try

    End Sub

    Private Sub TableMast(lineNum As Integer, myText As String, item1 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowMast As ExportXml.MastRow = Me.MyExport.DbExport.Mast.FindByMastID(item1)
            Dim newResultText = rowMast.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Mast(" + item1.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Mast row")

        End Try

    End Sub


    Private Sub TableMastRule(lineNum As Integer, myText As String, level1 As Integer, item1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyImport.MatchLevel3(lineNum, level1, inputText)

            Select Case rowLevel3.level2
                Case 1

                    Dim rowMastRule As ExportXml.MastRuleRow = Me.MyExport.DbExport.MastRule.FindByMastIDRuleID(item1, rowLevel3.item2)
                    Dim newResultText = rowMastRule.Item(rowLevel3.columnID - 2).ToString

                    Dim cut As Integer = InStr(myText, rowLevel3.text) + Len(rowLevel3.text) - 1
                    writeText = Mid(myText, 1, cut) + newResultText

                    Console.WriteLine(lineNum.ToString + " Mast - Mast(" + item1.ToString + ") " + " - Rule(" + rowLevel3.item2.ToString + ") - " + rowLevel3.text + Space(1) + newResultText)

                Case 2

                    Call Me.TableMastAppearance(lineNum, myText, level1, item1, rowLevel3.item2, rowLevel3.resultText, writeText)

                Case Else

                    Stop

            End Select


        Catch ex As Exception

            MsgBox("Failed to process table Mast Rule row")

        End Try

    End Sub


    Private Sub TableMastAppearance(lineNum As Integer, myText As String, level1 As Integer, item1 As Integer, item2 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel4 As ImportCDI.MatchLevel4Row = MyImport.MatchLevel4(lineNum, level1, inputText)

            Dim rowMastRuleAppear As ExportXml.MastRuleAppearRow = Me.MyExport.DbExport.MastRuleAppear.FindByMastIDRuleIDAppearanceID(item1, item2, rowLevel4.item3)
            Dim newResultText = rowMastRuleAppear.Item(rowLevel4.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowLevel4.text) + Len(rowLevel4.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Mast - " + "Mast(" + item1.ToString + ") - Rule(" + item2.ToString + ") - Appearance(" + rowLevel4.item3.ToString + ") - " + rowLevel4.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Mast Rule Appearance row")

        End Try

    End Sub

    Private Sub RowLampDirectControl(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TableLamp(lineNum, myText, rowLevel2.item1, rowLevel2.columnID, rowLevel2.text, writeText)

                Case Else
                    Stop

            End Select

        Catch ex As Exception

            MsgBox("Failed process Row Lamp Direct Control")

        End Try

    End Sub


    Private Sub TableLamp(lineNum As Integer, myText As String, item1 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLamp As ExportXml.LampRow = Me.MyExport.DbExport.Lamp.FindByLampID(item1)
            Dim newResultText = rowLamp.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Lamp(" + item1.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Lamp row")

        End Try

    End Sub


    Private Sub RowTrackReceiver(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowCircuit As ExportXml.TrackReceiverRow = Me.MyExport.DbExport.TrackReceiver.FindByCircuitID(rowLevel2.item1)
            Dim newResultText = rowCircuit.Item(rowLevel2.columnID).ToString

            Dim cut As Integer = InStr(myText, rowLevel2.text) + Len(rowLevel2.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Track Circuit Receiver - Circuit(" + rowLevel2.item1.ToString + ") - " + rowLevel2.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Track Receiver row")

        End Try

    End Sub

    Private Sub RowTrackTransmitter(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowCircuit As ExportXml.TrackTransmitterRow = Me.MyExport.DbExport.TrackTransmitter.FindByCircuitID(rowLevel2.item1)
            Dim newResultText = rowCircuit.Item(rowLevel2.columnID).ToString

            Dim cut As Integer = InStr(myText, rowLevel2.text) + Len(rowLevel2.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Track Circuit Receiver - Circuit(" + rowLevel2.item1.ToString + ") - " + rowLevel2.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Track Transmitter row")

        End Try

    End Sub



    Private Sub UpDateRowLampDirectControl(lineNum As Integer, myText As String, inputText As String, ByRef writeText As String)

        Try

            Dim LampID As Integer = Val(inputText)
            Dim rowLamp As ExportXml.LampRow = Me.MyExport.DbExport.Lamp.FindByLampID(LampID)

            If rowLamp Is Nothing Then
                MsgBox("Failed to find Lamp row " + LampID.ToString)
            Else

                Dim cut As Integer = InStr(myText, "=")
                writeText = Mid(myText, 1, cut) + rowLamp.brightness.ToString

                Console.WriteLine(lineNum.ToString + " Lamp(" + LampID.ToString + ") - Brightness= " + rowLamp.brightness.ToString)

            End If

        Catch ex As Exception

            MsgBox("Failed to process UpDate Row Lamp Direct Control")

        End Try

    End Sub

End Class
