Imports System.Diagnostics.Tracing
Imports System.IO

Public Class ClassExportXsd

    Inherits ClassAppConfigValues

    Public Sub ExportToXsdFile(filePath As String)

        Dim dsImport As New ImportCDI

        Try
            dsImport.ReadXml(Me.SavedImportCDIfile)
        Catch ex As Exception
            MsgBox("Failed to read import file " + Me.SavedImportCDIfile)
            Exit Sub
        End Try

        ' import user selections

        Try

            Dim dsUser As New UserPrefs

            dsUser.ReadXml(Me.SavedUserFile)
            dsUser.AcceptChanges()

            dsImport.Process.Merge(dsUser.Process)
            dsImport.AcceptChanges()

            Dim rowProcess As ImportCDI.ProcessRow = dsImport.Process.FindByprocessID(2)
            If rowProcess Is Nothing Then
                ' do nothing
            ElseIf Not rowProcess.action Then
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Failed to import xml " + Me.SavedUserFile)
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
