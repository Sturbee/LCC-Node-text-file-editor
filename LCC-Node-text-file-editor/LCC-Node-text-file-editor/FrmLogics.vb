
Public Class FrmLogics

    Public Property MyLogicCells As Integer
    Private Property MyFilePath As String
    Private Property MyExport As New ClsExportXML

    Private Sub FrmLogicCells_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayValues()

    End Sub

    Private Sub DisplayValues()

        ' read the file to read and edit
        Me.MyFilePath = Me.Owner.Tag

        ' read the export xml file
        MyExport.DbExportReadFile(MyFilePath)

        ' read the titles xml file
        Dim clsT As New ClsTitles

        ' set labels
        Dim rowTitle As Titles.LogicTitlesRow = clsT.Titles.LogicTitles.Item(0)
        Me.Text = rowTitle.header
        Me.LblSubHeader.Text = rowTitle.subHeader

        ' read the attribute xml file
        REM Dim clsR As New ClsReport

        ' populate tab control

        Try

            Me.TabControlCells.Controls.Clear()

            For count = 1 To Me.MyLogicCells

                Dim row As ExportXml.LogicRow = MyExport.DbExport.Logic.FindByLogicID(count)

                Dim MyTabPage As New TabPage With {
                .Text = count.ToString + " - " + row.Description
                }

                Me.TabControlCells.Controls.Add(MyTabPage)

            Next

        Catch ex As Exception

            MsgBox("Failed to populate tab control")
            Exit Sub

        End Try

    End Sub

    Private Sub TabControlCells_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlCells.Selected

        ' Stop

    End Sub

End Class