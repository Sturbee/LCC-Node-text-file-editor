
Public Class ClsExportXML

    Public Property DbExport As ExportXml

    Public Sub New()

    End Sub

    Public Sub DbExportReadFile(fileName As String)

        ' import the importCDI xml file
        Try
            DbExport = New ExportXml
            Me.DbExport.ReadXml(fileName)
        Catch ex As Exception
            MsgBox("Failed to import file " + fileName)
            Exit Sub
        End Try

    End Sub

End Class
