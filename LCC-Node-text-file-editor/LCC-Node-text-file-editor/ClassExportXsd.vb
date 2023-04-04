
Public Class ClassExportXsd

    Public Sub ExportToXsdFile(filePath As String)

        Dim clsI As New ClsImportCDI
        Dim dsImport As ImportCDI = clsI.MyImportCDI


        Dim xmlFilePath As String = filePath + ".xml"

        If My.Computer.FileSystem.FileExists(xmlFilePath) = False Then
            MessageBox.Show("File Not Found: " & xmlFilePath)
            Exit Sub
        End If

        Dim ds As New ExportXml

        Try

            ds.ReadXml(xmlFilePath)

        Catch ex As Exception

            MsgBox(filePath + " is not a .xml file")
            Exit Sub

        End Try

        Try

            ds.WriteXmlSchema(xmlFilePath + ".xsd")
            MsgBox("Created XmlSchema file for " + xmlFilePath)

        Catch ex As Exception

            MsgBox("Failed to create " + xmlFilePath + ".xsd file")
            Exit Sub

        End Try

    End Sub

End Class
