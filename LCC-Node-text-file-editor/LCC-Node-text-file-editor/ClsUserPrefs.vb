
Public Class ClsUserPrefs

    Public Property UserPrefsFileName As String = "UserPrefs.xml"
    Private Property UserPrefsOrgFileName As String = "UserPrefs.org.xml"

    Public Property MyUserPrefs As New UserPrefs

    Public Sub New()

        Call Me.UserPrefsXmlRead()

    End Sub

    Private Sub UserPrefsXmlRead()

        ' import userprefs xml file
        Try
            MyUserPrefs.ReadXml(Me.UserPrefsFileName)
        Catch ex As Exception
            ' file is not auto copied
            ' try to create a new userprefs xml file
            Try
                MyUserPrefs.ReadXml(Me.UserPrefsOrgFileName)
                MyUserPrefs.WriteXml(Me.UserPrefsFileName)
            Catch ex1 As Exception
                MsgBox("Failed to create/read " + Me.UserPrefsFileName)
                Exit Sub
            End Try
        End Try

    End Sub

    Public Function CheckUserFileDirectories() As Integer

        ' check for valid file directorys, if valid return -1 else row value
        For count = 0 To Me.MyUserPrefs.UserJMRI.Count - 1
            Try
                Dim row As UserPrefs.UserJMRIRow = Me.MyUserPrefs.UserJMRI.Item(count)
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
            Dim row As UserPrefs.UserJMRIRow = MyUserPrefs.UserJMRI.FindByvalue(userJMRIvalue)
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

        Dim row As UserPrefs.UserJMRIRow = MyUserPrefs.UserJMRI.FindByvalue(userJMRIvalue)

        row.path = filePath
        row.extension = fileExtension

        MyUserPrefs.AcceptChanges()

        ' write to userprefs xml file
        Try
            MyUserPrefs.WriteXml(Me.UserPrefsFileName)
            Return True
        Catch ex As Exception
            MsgBox("Failed to write values to " + Me.UserPrefsFileName)
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
