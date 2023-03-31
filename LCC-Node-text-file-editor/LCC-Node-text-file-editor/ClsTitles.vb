Public Class ClsTitles

    Private Property TitlesFileName As String = "Titles.xml"
    Public Property MyTitles As New Titles

    Public Sub New()

        Call Me.TitlesXmlRead()

    End Sub

    Private Sub TitlesXmlRead()

        ' import the titles xml file
        Try
            MyTitles.ReadXml(Me.TitlesFileName)
        Catch ex As Exception
            MsgBox("Failed to import file " + Me.TitlesFileName)
            Exit Sub
        End Try

    End Sub


End Class
