
Public Class ClassExportXsd

    Public Sub ExportToXsdFile(filePath As String)

        Dim clsI As New ClsImportCDI
        Dim dsImport As ImportCDI = clsI.MyImportCDI


        ' import user selections
        Try

            Dim clsU As New ClsUserPrefs
            Dim dsUser As UserPrefs = clsU.MyUserPrefs

            dsImport.Process.Merge(dsUser.Process)
            dsImport.AcceptChanges()

            Dim rowProcess As ImportCDI.ProcessRow = dsImport.Process.FindByprocessID(2)
            If rowProcess Is Nothing Then
                ' do nothing
            ElseIf Not rowProcess.action Then
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Failed to merge user xml")
        End Try


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
