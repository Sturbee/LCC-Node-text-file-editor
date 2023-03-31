
Public Class ClsUserPrefs

    Private Property UserPrefsFileName As String = "UserPrefs.xml"
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

        ' check for valid file directorys
        Try
            For count = 0 To Me.MyUserPrefs.UserJMRI.Count - 1
                Dim filePath As String = String.Empty
                Dim fileExtension As String = String.Empty
                Call Me.JMRIfileRowRead(count, filePath, fileExtension)
            Next
        Catch ex As Exception
            MsgBox("JMRI file directory check failed")
            Exit Sub
        End Try

    End Sub

    Public Sub JMRIfileRowRead(userJMRIvalue As Integer, ByRef filePath As String, ByRef fileExtension As String)

        Dim row As UserPrefs.UserJMRIRow = MyUserPrefs.UserJMRI.FindByvalue(userJMRIvalue)

        If Me.JMRIfileRowCheck(row.path, row.extension) = False Then
            Call Me.JMRIfileRowWrite(row.value, row.path, row.extension)
        End If

        filePath = row.path
        fileExtension = row.extension

    End Sub

    Public Function JMRIfileRowWrite(userJMRIvalue As Integer, filePath As String, fileExtension As String) As Boolean

        Dim result As Boolean = False

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
            result = True
        Catch ex As Exception
            MsgBox("Failed to write values to " + Me.UserPrefsFileName)
        End Try

        Return result

    End Function

    Private Function JMRIfileRowCheck(ByRef filePath As String, ByRef fileExtension As String) As Boolean

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

    Public Sub TrackSpeedRowChange(value As Integer, text As String)

        Dim row As UserPrefs.TrackSpeedRow = MyUserPrefs.TrackSpeed.FindByvalue(value)
        row.text = text

    End Sub


    Public Sub UserPrefsXmlSave()

        MyUserPrefs.WriteXml(Me.UserPrefsFileName)

    End Sub

End Class
