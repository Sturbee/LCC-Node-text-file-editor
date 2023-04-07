Public Class ClsShared

    Public Property MyImportCDI As New ImportCDI

    Public Sub New()

        ' import cdi xml file file
        Try
            Dim clsImportCDI As New ClsImportCDI
            Me.MyImportCDI = clsImportCDI.MyImportCDI
            MyImportCDI.AcceptChanges()
        Catch ex As Exception
            MsgBox("Failed to import the import cdi xml file")
            Exit Sub
        End Try

    End Sub

    Public Function MatchLevel1(lineNum As Integer, text As String, ByRef resultText As String) As Integer

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
                Console.WriteLine(lineNum.ToString + " Level1 not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return level1

    End Function

    Public Function MatchLevel2(lineNum As Integer, level1 As Integer, text As String, ByRef level2 As Integer, ByRef resultText As String) As ImportCDI.MatchLevel2Row

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
                Console.WriteLine(lineNum.ToString + " Section not found - " + text)
                Stop
            End If

        Catch ex As Exception

            Stop

        End Try

        Return rowLevel2

    End Function


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
