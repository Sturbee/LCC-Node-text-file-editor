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
            Dim resultText As String = String.Empty
            Dim writeText As String = String.Empty

            Dim srOut As New StreamWriter(outputPath)

            While Not srIn.EndOfStream

                lineNum += 1

                myText = srIn.ReadLine
                writeText = String.Empty

                ' process read line
                Dim level1 As Integer = MyClsImport.MatchLevel1(lineNum, myText, resultText)

                Select Case level1

                    Case -1 ' unknown segment
                        Stop

                    Case 0 ' segment node ID
                        Call Me.RowNode(lineNum, myText, level1, resultText, writeText)

                    Case 1 ' segment power monitor
                        Call Me.RowPowerMonitor(lineNum, myText, level1, resultText, writeText)

                    Case 2 ' segment port
                        Call Me.RowPort(lineNum, myText, level1, resultText, writeText)

                    Case 3 ' segment conditional
                        REM Call Me.AddRowLogic(level1, resultText)

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

    Private Sub RowNode(lineNum As Integer, myText As String, level1 As Integer, text As String, ByRef writeText As String)

        Try

            Dim NodeID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, text, NodeID, resultText)

            Dim rowNode As ExportXml.NodeRow = MyExportXml.Node.FindByNodeID(NodeID)
            Dim newResultText = rowNode.Item(rowLevel2.columnID - 1).ToString

            Dim cut As Integer = InStr(myText, resultText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + Space(1) + "Node ID - " + rowLevel2.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed process table Node row")

        End Try

    End Sub

    Private Sub RowPowerMonitor(lineNum As Integer, myText As String, level1 As Integer, text As String, ByRef writeText As String)

        Try

            Dim PowerMonitorID As Integer
            Dim resultText As String = String.Empty

            Dim rowlevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, text, PowerMonitorID, resultText)

            Dim rowPowerMonitor As ExportXml.PowerMonitorRow = Me.MyExportXml.PowerMonitor.FindByPowerMonitorID(PowerMonitorID)
            Dim newResultText = rowPowerMonitor.Item(rowlevel2.columnID - 1).ToString

            Dim cut As Integer = InStr(myText, resultText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + Space(1) + "Node Power Monitor - " + rowlevel2.text + Space(1) + resultText)

        Catch ex As Exception

            MsgBox("Failed to process table Power Monitor row")

        End Try

    End Sub

    Private Sub RowPort(lineNum As Integer, myText As String, level1 As Integer, text As String, ByRef writeText As String)

        Try

            Dim LineID As Integer = 0
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = MyClsImport.MatchLevel2(lineNum, level1, text, LineID, resultText)

            Select Case rowLevel2.level2
                Case 0
                    Call Me.TablePort(lineNum, myText, LineID, rowLevel2.columnID, rowLevel2.text, resultText, writeText)

                Case 1
                    Call Me.TablePortDelay(lineNum, myText, LineID, rowLevel2.level1, resultText, writeText)

                Case 2
                    Call Me.TablePortEvent(lineNum, myText, LineID, rowLevel2.level1, resultText, writeText)

                Case Else
                    MsgBox("Level2 value unknown")

            End Select

        Catch ex As Exception

            MsgBox("Failed to read process port")

        End Try

    End Sub


    Private Sub TablePort(lineNum As Integer, myText As String, LineID As Integer, columnID As Integer, text As String, resultText As String, ByRef writeText As String)

        Try

            Dim rowPort As ExportXml.PortRow = Me.MyExportXml.Port.FindByLineID(LineID)
            Dim newResultText = rowPort.Item(columnID - 2).ToString

            Dim cut As Integer = InStr(myText, text) + Len(text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + LineID.ToString + ") - " + text + Space(1) + resultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port row")

        End Try

    End Sub

    Private Sub TablePortDelay(lineNum As Integer, myText As String, LineID As Integer, level1 As Integer, text As String, ByRef writeText As String)

        Try

            Dim DelayID As Integer = 0
            Dim resultText As String = String.Empty

            Dim rowlevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, text, DelayID, resultText)

            Dim rowPortDelay As ExportXml.PortDelayRow = Me.MyExportXml.PortDelay.FindByLineIDDelayID(LineID, DelayID)

            Dim newResultText = rowPortDelay.Item(rowlevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowlevel3.text) + Len(rowlevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - " + "Line(" + LineID.ToString + ") - Delay(" + DelayID.ToString + ") - " + rowlevel3.text + Space(1) + resultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port Delay row")

        End Try

    End Sub

    Private Sub TablePortEvent(lineNum As Integer, myText As String, LineID As Integer, level1 As Integer, text As String, ByRef writeText As String)

        Try

            Dim EventID As Integer = 0
            Dim resultText As String = String.Empty

            Dim rowLevel3 As ImportCDI.MatchLevel3Row = MyClsImport.MatchLevel3(lineNum, level1, text, EventID, resultText)

            Dim rowPortEvent As ExportXml.PortEventRow = Me.MyExportXml.PortEvent.FindByLineIDEventID(LineID, EventID)

            Dim newResultText = rowPortEvent.Item(rowLevel3.columnID - 2).ToString

            Dim cut As Integer = InStr(myText, rowLevel3.text) + Len(rowLevel3.text) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(lineNum.ToString + " Port I/O - Line(" + LineID.ToString + ") - " + "Event(" + EventID.ToString + ") - " + resultText)

        Catch ex As Exception

            MsgBox("Failed to process table Port Event")

        End Try

    End Sub



End Class
