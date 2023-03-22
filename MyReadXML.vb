Imports System.Configuration

Public Class MyReadXML

    Private Sub MyReadXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.DisplayData()

    End Sub


    Private Sub DisplayData()

        Dim cls As New ClassAppConfigValues
        cls.AppConfigFileRead()

        Dim filePath As String = cls.SavedFileFolder + "\" + cls.SavedImportCDIfile


        If My.Computer.FileSystem.FileExists(filePath) = False Then
            MessageBox.Show("File Not Found: " & filePath)
            Exit Sub
        End If

        Try

            Me.MyDataSet.ReadXml(filePath)

            Me.DataGridView1.DataSource = Me.MyDataSet

            Me.DataGridView1.DataMember = "TrackSpeed"

        Catch ex As Exception

            MsgBox("Failed to find DataMember")

        End Try


        Try

            Me.MyDataSet.WriteXmlSchema(filePath + ".xsd")
            MsgBox("Created XmlSchema file for " + filePath)

        Catch ex As Exception

            MsgBox("Failed to create " + filePath + ".xsd file")
            Exit Sub

        End Try

    End Sub


End Class