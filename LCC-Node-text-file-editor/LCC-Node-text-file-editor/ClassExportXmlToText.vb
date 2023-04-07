Imports System.IO

Public Class ClassExportXmlToText

    Private Property MyLineNum As Integer = 0
    Private Property MyImportCDI As New ImportCDI
    Private Property MyExportXml As New ExportXml

    Public Sub MyExportXmlToTextFile(filePath As String)

        If File.Exists(filePath) = False Then
            File.Delete(filePath)
            MsgBox(filePath + " does not exit")
            Exit Sub
        End If

        ' import cdi xml file file
        Try
            Dim clsImportCDI As New ClsImportCDI
            Me.MyImportCDI = clsImportCDI.MyImportCDI
            MyImportCDI.AcceptChanges()
        Catch ex As Exception
            MsgBox("Failed to import the import cdi xml file")
            Exit Sub
        End Try

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

            Dim srOut As New StreamWriter(outputPath)

            While Not srIn.EndOfStream

                MyLineNum += 1

                myText = srIn.ReadLine

                srOut.WriteLine(myText)

                Console.WriteLine(MyLineNum.ToString + Space(1) + myText)

            End While

            srIn.Close()
            srOut.Close()

        Catch ex As Exception
            MsgBox("Failed to create new text file")
        End Try

    End Sub

End Class
