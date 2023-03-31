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
        Catch ex As Exception
            MsgBox("Failed to import file " + Me.ImportCDIFileName)
            Exit Sub
        End Try

    End Sub
End Class
