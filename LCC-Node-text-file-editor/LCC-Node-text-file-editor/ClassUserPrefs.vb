Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar

Public Class ClassUserPrefs

    Public Property UserPrefsFileName As String = "UserPrefs.xml"

    Public Property MyUserPrefs As New UserPrefs

    Public Sub New()

        Call Me.ReadUserPrefsXml()

    End Sub

    Private Sub ReadUserPrefsXml()

        ' import userprefs xml file
        Try
            MyUserPrefs.ReadXml(Me.UserPrefsFileName)
        Catch ex As Exception
            MsgBox("Failed to read " + Me.UserPrefsFileName)
            Exit Sub
        End Try

        ' check for valid file directorys
        Try
            For count = 0 To Me.MyUserPrefs.UserJMRI.Count - 1
                Dim filePath As String = String.Empty
                Dim fileExtension As String = String.Empty
                Call Me.ReadJMRIfileInfo(count, filePath, fileExtension)
            Next
        Catch ex As Exception
            MsgBox("JMRI file directory check failed")
            Exit Sub
        End Try

    End Sub

    Public Sub ReadJMRIfileInfo(userJMRIvalue As Integer, ByRef filePath As String, ByRef fileExtension As String)

        Dim row As UserPrefs.UserJMRIRow = MyUserPrefs.UserJMRI.FindByvalue(userJMRIvalue)

        If Me.CheckJMRIfileInfo(row.path, row.extension) = False Then
            Call Me.WriteJMRIfileInfo(row.value, row.path, row.extension)
        End If

        filePath = row.path
        fileExtension = row.extension

    End Sub

    Public Function WriteJMRIfileInfo(userJMRIvalue As Integer, filePath As String, fileExtension As String) As Boolean

        Dim result As Boolean = False

        If Me.CheckJMRIfileInfo(filePath, fileExtension) = False Then
            Return False
        End If

        Dim row As UserPrefs.UserJMRIRow = MyUserPrefs.UserJMRI.FindByvalue(userJMRIvalue)

        row.path = filePath
        row.extension = fileExtension

        MyUserPrefs.AcceptChanges()

        ' write to userprefs xml file
        Try
            MyUserPrefs.WriteXml(Me.UserPrefsFileName)
            result = True
        Catch ex As Exception
            MsgBox("Failed to write values to " + Me.UserPrefsFileName)
        End Try

        Return result

    End Function

    Private Function CheckJMRIfileInfo(ByRef filePath As String, ByRef fileExtension As String) As Boolean

        Dim result As Boolean = False

        Try
            Dim fileNames = My.Computer.FileSystem.GetFiles(filePath, FileIO.SearchOption.SearchTopLevelOnly, fileExtension)
            result = True
        Catch ex As Exception
            filePath = My.Computer.FileSystem.CurrentDirectory
            fileExtension = "*.*"
        End Try

        Return result

    End Function


End Class
