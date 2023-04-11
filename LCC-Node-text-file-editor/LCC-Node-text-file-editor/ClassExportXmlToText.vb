Imports System.IO

Public Class ClassExportXmlToText


    Private Property MyClsImport As New ClsImportCDI

    Private Property MyExportXml As New ExportXml

    Public Sub MyExportXmlToTextFile(filePath As String)

        If File.Exists(filePath) = False Then
            File.Delete(filePath)
            MsgBox(filePath + " does not exit")
            Exit Sub
        End If

        Try
            MyExportXml.ReadXml(filePath)
        Catch ex As Exception
            MsgBox("Failed to import the export xml file " + filePath)
            Exit Sub
        End Try

        Try
            Dim nodeRow As ExportXml.NodeRow = MyExportXml.Node.Item(0)
            Dim sourcePath As String = nodeRow.sourceFile
            If File.Exists(sourcePath) = False Then
                File.Delete(sourcePath)
                MsgBox(sourcePath + " does not exit")
                Exit Sub
            End If

            Dim outputPath As String = String.Empty
            Try
                Dim clsU As New ClsUserPrefs
                Dim row As UserPrefs.UserJMRIRow = clsU.MyUserPrefs.UserJMRI.FindByvalue(2)

                outputPath = row.path + "\" + Path.GetFileName(sourcePath)

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
                Dim row As ImportCDI.MatchLevel1Row = MyClsImport.MatchLevel1(lineNum, myText)

                Select Case row.level1

                    Case -1 ' unknown segment
                        Stop

                    Case 0 ' segment node ID
                        Call Me.RowNode(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 1 ' segment power monitor
                        Call Me.RowPowerMonitor(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 2 ' segment port
                        Call Me.RowPort(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 3 ' segment conditional
                        Call Me.RowLogic(lineNum, myText, row.level1, row.resultText, writeText)

                    Case 4 ' segment track circuit receiver
                        REM Call Me.AddRowTrackCircuitRec(level1, resultText)

                    Case 5 ' segment track circuit transmitter
                        REM Call Me.AddRowTrackCircuitTran(level1, resultText)

                    Case 6 ' segment rule to aspect
                        REM Call Me.AddRowRuleToAspect(level1, resultText)

                    Case 7 ' segment Direct Lamp Control
                        REM Call Me.AddRowLampDirectControl(level1, resultText)

                    Case 8 ' 
                        REM Call Me.UpDateRowLampDirectControl(resultText)

                End Select

                If myText = writeText Then
                    ' do nothing
                Else
                    srOut.WriteLine(writeText)
                End If

                REM Console.WriteLine(MyLineNum.ToString + Space(1) + myText)

            End While

            srIn.Close()
            srOut.Close()

        Catch ex As Exception
            MsgBox("Failed to create new text file")
        End Try

    End Sub

    Private Sub RowNode(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowNode As ExportXml.NodeRow = MyExportXml.Node.FindByNodeID(rowLevel2.level2)
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

            Dim rowlevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Dim rowPowerMonitor As ExportXml.PowerMonitorRow = Me.MyExportXml.PowerMonitor.FindByPowerMonitorID(rowlevel2.level2)
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

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TablePort(lineNum, myText, rowLevel2.level3, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 1
                    Call Me.TablePortDelay(lineNum, myText, rowLevel2.level1, rowLevel2.level3, rowLevel2.resultText, writeText)

                Case 2
                    Call Me.TablePortEvent(lineNum, myText, rowLevel2.level1, rowLevel2.level3, rowLevel2.resultText, writeText)

                Case Else
                    MsgBox("Level2 value unknown")

            End Select

        Catch ex As Exception

            MsgBox("Failed to read process port")

        End Try

    End Sub


    Private Sub TablePort(lineNum As Integer, myText As String, level3 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowPort As ExportXml.PortRow = Me.MyExportXml.Port.FindByLineID(level3)
            Dim newResultText = rowPort.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + level3.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port row")

        End Try

    End Sub

    Private Sub TablePortDelay(lineNum As Integer, myText As String, level1 As Integer, level3 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowlevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowPortDelay As ExportXml.PortDelayRow = Me.MyExportXml.PortDelay.FindByLineIDDelayID(level3, rowlevel3.level4)

            Dim newResultText = rowPortDelay.Item(rowlevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowlevel3.text) + Len(rowlevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + level3.ToString + ") - Delay(" + rowlevel3.level4.ToString + ") - " + rowlevel3.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port Delay row")

        End Try

    End Sub

    Private Sub TablePortEvent(lineNum As Integer, myText As String, level1 As Integer, level3 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowPortEvent As ExportXml.PortEventRow = Me.MyExportXml.PortEvent.FindByLineIDEventID(level3, rowLevel3.level4)

            Dim newResultText = rowPortEvent.Item(rowLevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowLevel3.text) + Len(rowLevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - Line(" + level3.ToString + ") - " + "Event(" + rowLevel3.level4.ToString + ") - " + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port Event")

        End Try

    End Sub

    Private Sub RowLogic(lineNum As Integer, myText As String, level1 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, inputText)

            Select Case rowLevel2.level2
                Case 0 ' Logic section
                    Call Me.TableLogic(lineNum, myText, rowLevel2.level3, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 1 ' Logic Operation section
                    Call Me.TableLogicOperation(lineNum, myText, rowLevel2.level3, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 2 ' Logic Action
                    Call Me.TableLogicAction(lineNum, myText, rowLevel2.level3, rowLevel2.columnID, rowLevel2.text, writeText)

                Case 3
                    Call Me.TableLogicProducer(lineNum, myText, rowLevel2.level1, rowLevel2.level3, rowLevel2.resultText, writeText)

                Case Else
                    MsgBox("Logic Section unknown - " + rowLevel2.level2)

            End Select

            Me.MyExportXml.AcceptChanges()

        Catch ex As Exception

            MsgBox("Failed Add Row Logic")

        End Try

    End Sub

    Private Sub TableLogic(lineNum As Integer, myText As String, level3 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLogic As ExportXml.LogicRow = Me.MyExportXml.Logic.FindByLogicID(level3)
            Dim newResultText = rowLogic.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + level3.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process Logic row")

        End Try

    End Sub

    Private Sub TableLogicOperation(lineNum As Integer, myText As String, level3 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLogicOP As ExportXml.LogicOperationRow = Me.MyExportXml.LogicOperation.FindByLogicID(level3)
            Dim newResultText = rowLogicOP.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + level3.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Logic Operation row")

        End Try

    End Sub

    Private Sub TableLogicAction(lineNum As Integer, myText As String, level3 As Integer, columnID As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLogicAction As ExportXml.LogicActionRow = Me.MyExportXml.LogicAction.FindByLogicID(level3)
            Dim newResultText = rowLogicAction.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, inputText) + Len(inputText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - " + "Logic(" + level3.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Logic Action row")

        End Try

    End Sub

    Private Sub TableLogicProducer(lineNum As Integer, myText As String, level1 As Integer, level3 As Integer, inputText As String, ByRef writeText As String)

        Try

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, inputText)

            Dim rowLogicProducer As ExportXml.LogicProducerRow = Me.MyExportXml.LogicProducer.FindByLogicIDActionID(level3, rowLevel3.level4)
            Dim newResultText = rowLogicProducer.Item(rowLevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowLevel3.text) + Len(rowLevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Conditional - Logic(" + level3.ToString + ") - Action(" + rowLevel3.level4.ToString + ") - " + inputText + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed to process table Logic Producer row")

        End Try

    End Sub


End Class
