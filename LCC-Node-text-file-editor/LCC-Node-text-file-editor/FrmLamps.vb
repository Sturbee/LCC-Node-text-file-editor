Public Class FrmLamps

    Public Property MyLamps As Integer
    Private Property MyFilePath As String
    Private Property MyReport As New ClsReport
    Private Property MyExport As New ClsExportXML

    Private Sub FrmLamps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag

        MyExport.DbExportReadFile(MyFilePath)

        ' read the titles xml file
        Dim clsT As New ClsTitles

        ' set labels
        Dim rowTitle As Titles.LampsTitlesRow = clsT.Titles.LampsTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader
        Me.LblHelp.Text = rowTitle.help
        Me.LblBrightness.Text = rowTitle.brightness

        ' read the attribute xml file

        ' populate tab control
        Try

            Me.TabControlLamps.Controls.Clear()

            For count = 1 To Me.MyLamps

                Dim row As ExportXml.LampDirectRow = MyExport.DbExport.LampDirect.FindByLampDirectID(count)

                Dim MyTabPage As New TabPage With {
                .Text = count.ToString + " - " + row.description
                }

                Me.TabControlLamps.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception
            MsgBox("Failed to populate tab control")
            Exit Sub
        End Try

    End Sub

    Private Sub TabControlLamps_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlLamps.Selected

        Dim lampID As Integer

        If e.TabPageIndex = -1 Then
            lampID = 1
        Else
            lampID = e.TabPageIndex + 1
        End If
        ' fill in row values

        Dim rowName As Rpt.LampSelectionRow = MyReport.Rpt.LampSelection.FindByvalue(lampID)
        Me.LblLampID.Text = "Lamp " + rowName.text

        Dim rowLampDirect As ExportXml.LampDirectRow = MyExport.DbExport.LampDirect.FindByLampDirectID(lampID)
        Me.TxtDescription.Text = rowLampDirect.description

        Dim rowLamp As ExportXml.LampRow = MyExport.DbExport.Lamp.FindByLampID(lampID)
        Me.TxtBrightness.Text = rowLamp.brightness

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try

            Dim rowLampDirect As ExportXml.LampDirectRow = MyExport.DbExport.LampDirect.FindByLampDirectID(Me.TabControlLamps.SelectedIndex + 1)
            rowLampDirect.description = Me.TxtDescription.Text

            Dim rowLamp As ExportXml.LampRow = MyExport.DbExport.Lamp.FindByLampID(Me.TabControlLamps.SelectedIndex + 1)

            ' check for integer value
            Try
                rowLamp.brightness = Me.TxtBrightness.Text
                If (rowLamp.brightness > 255) Or (rowLamp.brightness < 0) Then
                    MsgBox("Brightness value out of range")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Brighness value is not a integer")
                Exit Sub
            End Try

            MyExport.DbExport.WriteXml(Me.MyFilePath)
            MsgBox("Saved changes to lamp values")

            ' need to reload after save
            MyExport.DbExportReadFile(MyFilePath)

            Call Me.DisplayValues()

        Catch ex As Exception
            MsgBox("Failed to save lamp values")
            Exit Sub
        End Try

    End Sub

End Class