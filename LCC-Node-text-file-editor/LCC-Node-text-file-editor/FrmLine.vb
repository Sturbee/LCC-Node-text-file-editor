Public Class FrmLine
    Private Property MyImport As New ExportXml
    Private Sub FrmLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' get App Config values
        Dim cls As New ClassAppConfigValues

        ' read the titles xml file
        Dim dsTitles As New Titles
        Try
            dsTitles.ReadXml(cls.SavedTitlesFile)
        Catch ex As Exception
            MsgBox("Failed to import titles")
            Exit Sub
        End Try

        ' set labels
        Dim rowTitle As Titles.PortTitlesRow = dsTitles.PortTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblLine.Text = rowTitle.port
        Me.LblDescription.Text = rowTitle.description

        ' read the attribute xml file
        Dim dsRpt As New Rpt
        Try
            dsRpt.ReadXml(cls.SavedReportFile)
        Catch ex As Exception
            MsgBox("Failed to import attributes")
            Exit Sub
        End Try


        Dim myFileName As String = "EditTest.xml"

        ' reads the export xml file
        Try
            Me.MyImport.ReadXml(myFileName)
        Catch ex As Exception
            MsgBox("Failed to read file " + myFileName)
            Exit Sub
        End Try

        ' line numbers are 1 to 16
        Dim lineID As Integer = 1
        Dim rowPort As ExportXml.PortRow = Me.MyImport.Port.FindByLineID(lineID)
        If rowPort Is Nothing Then
            MsgBox("Failed to import port row " + lineID.ToString)
            Exit Sub
        End If

        Me.LblLineNumber.Text = rowPort.LineID.ToString
        Me.TxtDescription.Text = rowPort.Description


    End Sub
End Class