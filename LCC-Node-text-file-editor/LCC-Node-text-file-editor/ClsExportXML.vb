Public Class ClsExportXML

    Public Property MyExportXML As New ExportXml

    Public Sub New()

    End Sub

    Public Sub ExportXmlRead(fileName As String)

        ' import the importCDI xml file
        Try
            MyExportXML.ReadXml(fileName)
        Catch ex As Exception
            MsgBox("Failed to import file " + fileName)
            Exit Sub
        End Try

    End Sub

End Class
