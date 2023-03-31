Public Class FrmLineSelect

    Public Property MyFileName As String
    Public Property MySaveFile
    Private Property MyImport As New ExportXml
    REM Private Property MyPortRow As ExportXml.PortRow

    Private Sub FrmLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' read the titles xml file
        Dim clsT As New ClsTitles
        Dim dsTitles As Titles = clsT.MyTitles

        Dim rowPort As Titles.PortTitlesRow = dsTitles.PortTitles.Item(0)
        Me.Text = rowPort.header
        REM Me.LblOptions.Text = rowPower.options
        REM Me.LblPowerOK.Text = rowPower.powerOK
        REM Me.LblPowerNotOK.Text = rowPower.powerNotOK


        ' read the attribute xml file
        Dim clsR As New ClsReport
        Dim dsRpt As Rpt = clsR.MyReport

        ' temporary

        Me.MyFileName = "EditTest.xml"
        Me.MySaveFile = "EditTest.xml"

        ' read the file to read and edit
        Try
            Me.MyImport.ReadXml(Me.MyFileName)
        Catch ex As Exception
            MsgBox("Failed to read file " + Me.MyFileName)
            Exit Sub
        End Try

        ' check for node type
        Dim rowNode As ExportXml.NodeRow = Me.MyImport.Node.Item(0)
        If rowNode.NodeType = 1 Then
            Me.MenuStrip2.Visible = False
        End If

    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click

        MsgBox("Clicked on Line 1")

    End Sub

    Private Sub ToolStripTextBox9_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox9.Click

        MsgBox("Clicked on Line 9")

    End Sub


End Class