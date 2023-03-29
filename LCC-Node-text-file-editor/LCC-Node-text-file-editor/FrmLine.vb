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

        Dim rowDelay As Titles.PortDelayTitlesRow = dsTitles.PortDelayTitles.Item(0)
        Me.LblTime.Text = rowDelay.time
        Me.LblUnit.Text = rowDelay.unit

        Me.LblRetrigger.Text = rowDelay.retrigger

        Me.LblInterval1.Text = rowDelay.interval

        rowDelay = dsTitles.PortDelayTitles.Item(1)
        Me.LblInterval2.Text = rowDelay.interval


        ' read the attribute xml file
        Dim dsRpt As New Rpt
        Try
            dsRpt.ReadXml(cls.SavedReportFile)
        Catch ex As Exception
            MsgBox("Failed to import attributes")
            Exit Sub
        End Try

        ' fill list box items
        Try

            Me.LstUnits1.BeginUpdate()
            Me.LstUnits2.BeginUpdate()
            For I = 0 To dsRpt.DelayUnit.Count - 1
                Dim row As Rpt.DelayUnitRow = dsRpt.DelayUnit.Item(I)
                Me.LstUnits1.Items.Add(row.text)
                Me.LstUnits2.Items.Add(row.text)
            Next
            Me.LstUnits1.EndUpdate()
            Me.LstUnits2.EndUpdate()

            Me.LstRetrigger1.BeginUpdate()
            Me.LstRetrigger2.BeginUpdate()
            For I = 0 To dsRpt.DelayRetrigger.Count - 1
                Dim row As Rpt.DelayRetriggerRow = dsRpt.DelayRetrigger.Item(I)
                Me.LstRetrigger1.Items.Add(row.text)
                Me.LstRetrigger2.Items.Add(row.text)
            Next
            Me.LstRetrigger1.EndUpdate()
            Me.LstRetrigger2.EndUpdate()

        Catch ex As Exception
            MsgBox("Failed to add Message Option values")
        End Try


        Dim myFileName As String = "EventTest.xml"

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

        For count = 1 To 2
            Dim row As ExportXml.PortDelayRow = Me.MyImport.PortDelay.FindByLineIDDelayID(lineID, count)

            Select Case count
                Case 1
                    Me.TxtTime1.Text = row.time
                    Me.LstUnits1.SelectedIndex = row.timeUnitID
                    Me.LstRetrigger1.SelectedIndex = row.retriggerID
                Case 2
                    Me.TxtTime2.Text = row.time
                    Me.LstUnits2.SelectedIndex = row.timeUnitID
                    Me.LstRetrigger2.SelectedIndex = row.retriggerID
            End Select

        Next

    End Sub

End Class