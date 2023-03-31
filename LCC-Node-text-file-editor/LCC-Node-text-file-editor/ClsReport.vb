Public Class ClsReport

    Private Property ReportFileName As String = "Report.xml"
    Public Property MyReport As New Rpt
    Public Sub New()

        Call Me.ReportXmlRead()

    End Sub

    Private Sub ReportXmlRead()

        ' import report xml file
        Try
            MyReport.ReadXml(Me.ReportFileName)
        Catch ex As Exception
            MsgBox("Failed to import file " + Me.ReportFileName)
            Exit Sub
        End Try

    End Sub


End Class
