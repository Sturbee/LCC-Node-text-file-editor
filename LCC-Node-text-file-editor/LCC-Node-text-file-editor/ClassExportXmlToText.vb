Imports System.IO

Public Class ClassExportXmlToText

    Inherits ClsShared

    Private Property MyLineNum As Integer = 0
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

            Dim srIn As New StreamReader(sourcePath)
            Dim myText As String = String.Empty
            Dim resultText As String = String.Empty
            Dim writeText As String = String.Empty

            Dim srOut As New StreamWriter(outputPath)

            While Not srIn.EndOfStream

                MyLineNum += 1

                myText = srIn.ReadLine

                ' process read line
                Dim level1 As Integer = Me.MatchLevel1(MyLineNum, myText, resultText)

                Select Case level1

                    Case -1 ' unknown segment
                        Stop

                    Case 0 ' segment node ID
                        Call Me.RowNode(level1, myText, resultText, writeText)

                    Case 1 ' segment power monitor
                        Call Me.RowPowerMonitor(level1, myText, resultText, writeText)

                    Case 2 ' segment port
                        REM Call Me.AddRowPort(level1, resultText)

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

                srOut.WriteLine(writeText)

                REM Console.WriteLine(MyLineNum.ToString + Space(1) + myText)

            End While

            srIn.Close()
            srOut.Close()

        Catch ex As Exception
            MsgBox("Failed to create new text file")
        End Try

    End Sub

    Private Sub RowNode(level1 As Integer, myText As String, text As String, ByRef writeText As String)

        Try

            Dim NodeID As Integer
            Dim resultText As String = String.Empty

            Dim rowLevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(MyLineNum, level1, text, NodeID, resultText)
            If rowLevel2 Is Nothing Then
                Stop
            End If

            Dim rowNode As ExportXml.NodeRow = MyExportXml.Node.FindByNodeID(NodeID)
            Dim newResultText = rowNode.Item(rowLevel2.columnID - 1).ToString

            Dim cut As Integer = InStr(myText, resultText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(MyLineNum.ToString + Space(1) + "Node ID - " + rowLevel2.text + Space(1) + newResultText)

        Catch ex As Exception

            MsgBox("Failed read table Node row")

        End Try

    End Sub

    Private Sub RowPowerMonitor(level1 As Integer, myText As String, text As String, ByRef writeText As String)

        Try

            Dim PowerMonitorID As Integer
            Dim resultText As String = String.Empty

            Dim rowlevel2 As ImportCDI.MatchLevel2Row = Me.MatchLevel2(MyLineNum, level1, text, PowerMonitorID, resultText)
            If rowlevel2 Is Nothing Then
                Stop
            End If

            Dim rowPowerMonitor As ExportXml.PowerMonitorRow = Me.MyExportXml.PowerMonitor.FindByPowerMonitorID(PowerMonitorID)
            Dim newResultText = rowPowerMonitor.Item(rowlevel2.columnID - 1).ToString

            Dim cut As Integer = InStr(myText, resultText) - 1
            writeText = Mid(myText, 1, cut) + newResultText

            Console.WriteLine(MyLineNum.ToString + Space(1) + "Node Power Monitor - " + rowlevel2.text + Space(1) + resultText)

        Catch ex As Exception

            MsgBox("Failed to read table Power Monitor row")

        End Try

    End Sub


End Class
