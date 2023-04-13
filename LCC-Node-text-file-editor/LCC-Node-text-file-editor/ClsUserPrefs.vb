
Public Class ClsUserPrefs

    Private Property MyUserPrefsFileName As String = "UserPrefs.xml"
    Private Property MyUserPrefsOrgFileName As String = "UserPrefs.org.xml"
    Public Property UserPrefs As New UserPrefs

    Public Sub New()

        Call Me.UserPrefsXmlRead()

    End Sub

    Public Sub UserPrefsXmlRead()

        ' import userprefs xml file
        Try
            UserPrefs.ReadXml(MyUserPrefsFileName)
        Catch ex As Exception
            ' file is not auto copied
            ' try to create a new userprefs xml file
            Try
                Stop
                UserPrefs.ReadXml(MyUserPrefsOrgFileName)
                UserPrefs.WriteXml(MyUserPrefsFileName)
            Catch ex1 As Exception
                MsgBox("Failed to create/read " + MyUserPrefsFileName)
                Exit Sub
            End Try
        End Try

    End Sub

    Public Sub UserPrefsXmlWrite()

        Try
            Stop
            UserPrefs.WriteXml(MyUserPrefsFileName)
        Catch ex As Exception
            MsgBox("Failed to write " + MyUserPrefsFileName)
        End Try

    End Sub

    Public Function CheckUserFileDirectories() As Integer

        ' check for valid file directorys, if valid return -1 else row value
        For count = 0 To Me.UserPrefs.UserJMRI.Count - 1
            Try
                Dim row As UserPrefs.UserJMRIRow = Me.UserPrefs.UserJMRI.Item(count)
                If Me.JMRIfileRowCheck(row.path, row.extension) Then
                    ' do nothing row OK
                Else
                    Return count
                End If
            Catch ex As Exception
                Return count
            End Try
        Next

        Return -1

    End Function

    Public Function JMRIfileRowRead(userJMRIvalue As Integer, ByRef filePath As String, ByRef fileExtension As String) As Boolean

        Try
            Dim row As UserPrefs.UserJMRIRow = UserPrefs.UserJMRI.FindByvalue(userJMRIvalue)
            filePath = row.path
            fileExtension = row.extension
            If Me.JMRIfileRowCheck(row.path, row.extension) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function JMRIfileRowWrite(userJMRIvalue As Integer, filePath As String, fileExtension As String) As Boolean

        If Me.JMRIfileRowCheck(filePath, fileExtension) = False Then
            Return False
        End If

        Dim row As UserPrefs.UserJMRIRow = UserPrefs.UserJMRI.FindByvalue(userJMRIvalue)

        row.path = filePath
        row.extension = fileExtension

        UserPrefs.AcceptChanges()

        ' write to userprefs xml file
        Try
            UserPrefs.WriteXml(MyUserPrefsFileName)
            Return True
        Catch ex As Exception
            MsgBox("Failed to write values to " + MyUserPrefsFileName)
            Return False
        End Try

    End Function

    Private Function JMRIfileRowCheck(filePath As String, fileExtension As String) As Boolean

        Try
            Dim fileNames = My.Computer.FileSystem.GetFiles(filePath, FileIO.SearchOption.SearchTopLevelOnly, fileExtension)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
