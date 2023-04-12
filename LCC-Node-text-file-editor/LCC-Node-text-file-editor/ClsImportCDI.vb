Public Class ClsImportCDI

    Private Property ImportCDIFileName As String = "ImportCDI.xml"
    Public Property MyImportCDI As New ImportCDI

    Public Sub New()

        Call Me.ImportCDIXmlRead()

    End Sub

    Private Sub ImportCDIXmlRead()

        ' import the importCDI xml file
        Try
            MyImportCDI.ReadXml(Me.ImportCDIFileName)
            MyImportCDI.AcceptChanges()
        Catch ex As Exception
            MsgBox("Failed to import file " + Me.ImportCDIFileName)
            Exit Sub
        End Try

    End Sub

    Public Function MatchLevel1(lineNum As Integer, inputText As String) As ImportCDI.MatchLevel1Row

        Dim startInt As Integer
        Dim resultInt As Integer
        Dim rowLevel1 As ImportCDI.MatchLevel1Row = Nothing

        ' find the match segment record
        For count = 0 To Me.MyImportCDI.MatchLevel1.Count - 1

            Dim row As ImportCDI.MatchLevel1Row = Me.MyImportCDI.MatchLevel1.Rows.Item(count)

            ' find match text
            Dim myMatch = row.text

            startInt = InStr(inputText, myMatch)
            If startInt > 0 Then

                ' Ok, found a known segment row
                ' return resultTxt and level1
                ' then exit count and read next line

                resultInt = startInt + Len(myMatch)
                row.resultText = Mid(inputText, resultInt)

                rowLevel1 = row

                Exit For

            End If

        Next

        If IsNothing(rowLevel1) Then
            Console.WriteLine(lineNum.ToString + " Level1 not found - " + inputText)
            Throw New System.Exception(lineNum.ToString + " Level1 not found - " + inputText)
        End If

        Return rowLevel1

    End Function

    Public Function MatchLevel2(lineNum As Integer, level1 As Integer, inputText As String) As ImportCDI.MatchLevel2Row

        Dim startInt As Integer
        Dim resultInt As Integer
        Dim resultText As String
        Dim rowLevel2 As ImportCDI.MatchLevel2Row = Nothing

        ' find the match segment record
        For count = 0 To Me.MyImportCDI.MatchLevel2.Count - 1

            Dim row As ImportCDI.MatchLevel2Row = Me.MyImportCDI.MatchLevel2.Rows.Item(count)

            If row.level1 = level1 Then

                ' find match text
                Dim myMatch = row.text

                startInt = InStr(inputText, myMatch)
                If startInt > 0 Then

                    ' Ok, found a known section row
                    ' return resultTxt and level1
                    ' then exit count and read next line

                    ' need to check for line and return lineID and reformatted resultText
                    row.item1 = Me.GetItemValue(inputText)

                    If row.item1 > 0 Then
                        resultInt = InStr(inputText, ").") + 2
                        resultText = Mid(inputText, resultInt)
                    End If

                    resultInt = startInt + Len(myMatch)
                    row.resultText = Mid(inputText, resultInt)

                    rowLevel2 = row

                    Exit For

                End If

            End If

        Next

        If IsNothing(rowLevel2) Then
            Console.WriteLine(lineNum.ToString + " Section not found - " + inputText)
            Throw New System.Exception(lineNum.ToString + " Level2 not found - " + inputText)
        End If

        Return rowLevel2

    End Function

    Public Function MatchLevel3(lineNum As Integer, level1 As Integer, inputText As String) As ImportCDI.MatchLevel3Row

        Dim startInt As Integer
        Dim resultInt As Integer
        Dim resultText As String
        Dim rowLevel3 As ImportCDI.MatchLevel3Row = Nothing

        ' find the match segment record
        For count = 0 To Me.MyImportCDI.MatchLevel3.Count - 1

            Dim row As ImportCDI.MatchLevel3Row = Me.MyImportCDI.MatchLevel3.Rows.Item(count)

            If row.level1 = level1 Then

                ' find match text
                Dim myMatch = row.text

                startInt = InStr(inputText, myMatch)
                If startInt > 0 Then

                    ' need to check for line and return lineID and reformatted resultText
                    row.item2 = Me.GetItemValue(inputText)

                    If row.item2 > 0 Then
                        resultInt = InStr(inputText, ").") + 2
                        resultText = Mid(inputText, resultInt)
                    End If

                    resultInt = startInt + Len(myMatch)
                    row.resultText = Mid(inputText, resultInt)

                    rowLevel3 = row

                    Exit For

                End If

            End If

        Next

        If IsNothing(rowLevel3) Then
            Console.WriteLine(lineNum.ToString + " Level3 not found - " + inputText)
            Throw New System.Exception(lineNum.ToString + " Level3 not found - " + inputText)
        End If

        Return rowLevel3

    End Function


    Public Function MatchLevel4(lineNum As Integer, level1 As Integer, inputText As String) As ImportCDI.MatchLevel4Row

        Dim startInt As Integer
        Dim resultInt As Integer
        Dim resultText As String
        Dim rowLevel4 As ImportCDI.MatchLevel4Row = Nothing

        ' find the match segment record
        For count = 0 To Me.MyImportCDI.MatchLevel4.Count - 1

            Dim row As ImportCDI.MatchLevel4Row = Me.MyImportCDI.MatchLevel4.Rows.Item(count)

            If row.level1 = level1 Then

                ' find match text
                Dim myMatch = row.text

                startInt = InStr(inputText, myMatch)
                If startInt > 0 Then

                    ' need to check for line and return lineID and reformatted resultText
                    row.item3 = Me.GetItemValue(inputText)

                    If row.item3 > 0 Then
                        resultInt = InStr(inputText, ").") + 2
                        resultText = Mid(inputText, resultInt)
                    End If

                    resultInt = startInt + Len(myMatch)
                    row.resultText = Mid(inputText, resultInt)

                    rowLevel4 = row

                    Exit For

                End If

            End If

        Next

        If IsNothing(rowLevel4) Then
            Console.WriteLine(lineNum.ToString + " Level4 not found - " + inputText)
            Throw New System.Exception(lineNum.ToString + " Level4 not found - " + inputText)
        End If

        Return rowLevel4

    End Function

    Private Function GetItemValue(resultText As String) As Integer

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

            Throw New System.Exception("GetItemValue failure for text " + resultText)

        End Try

        Return itemID

    End Function

End Class
