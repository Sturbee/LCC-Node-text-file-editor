Imports System.Configuration

Public Class ClassAppConfigValues

    Public Property FileFolderBackup As String
    Public Property FileExtensionBackup As String
    Public Property FileFolderExportXml As String
    Public Property FileExtensionExportXml As String
    Public Property FileFolderRestore As String
    Public Property FileExtensionRestore As String
    Public Property SavedImportCDIfile As String
    Public Property SavedUserFile As String
    Public Property SavedReportFile As String
    Public Property SavedTitlesFile As String
    Public Property SavedBlankTowerFile As String
    Public Property SavedBlankSignalFile As String

    Public Sub New()

        Call Me.AppConfigFileRead()

    End Sub

    Private Sub AppConfigFileRead()

        Me.FileFolderBackup = My.Computer.FileSystem.CurrentDirectory
        Me.FileExtensionBackup = "*.*"
        Me.FileFolderExportXml = My.Computer.FileSystem.CurrentDirectory
        Me.FileExtensionExportXml = "*.*"
        Me.FileFolderRestore = My.Computer.FileSystem.CurrentDirectory
        Me.FileExtensionRestore = "*.*"

        Me.SavedImportCDIfile = "ImportCDI.xml"
        Me.SavedUserFile = "UserPrefs.xml"
        Me.SavedReportFile = "Report.xml"
        Me.SavedTitlesFile = "Titles.xml"
        Me.SavedBlankTowerFile = "Tower.xml"
        Me.SavedBlankSignalFile = "Signal.xml"


        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        Dim appSettings As System.Configuration.AppSettingsSection = config.AppSettings

        For Each keyName As KeyValueConfigurationElement In appSettings.Settings

            Select Case keyName.Key

                Case "fileFolderBackup"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.FileFolderBackup = keyName.Value
                    End If

                Case "fileExtensionBackup"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.FileExtensionBackup = keyName.Value
                    End If

                Case "fileFolderExportXml"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.FileFolderExportXml = keyName.Value
                    End If

                Case "fileExtensionExportXml"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.FileExtensionExportXml = keyName.Value
                    End If

                Case "fileFolderRestore"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.FileFolderRestore = keyName.Value
                    End If

                Case "fileExtensionRestore"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.FileExtensionRestore = keyName.Value
                    End If

            End Select

        Next

    End Sub


    Public Function AppConfigFileWriteBackup(selectedPath As String, fileExtension As String) As Boolean

        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        ' Add the key/value pair to the appSettings 
        ' section.
        ' config.AppSettings.Settings.Add(keyName, value);
        Dim appSettings As System.Configuration.AppSettingsSection = config.AppSettings

        Try

            Dim tempPath As String = selectedPath

            appSettings.Settings.Remove("fileFolderBackup")

            config.Save(ConfigurationSaveMode.Modified)

            appSettings.Settings.Add("fileFolderBackup", tempPath)

            config.Save(ConfigurationSaveMode.Modified)

            ' Force a reload in memory of the changed section.
            ' This to read the section with the
            ' updated values.
            ConfigurationManager.RefreshSection("appSettings")

        Catch

            MsgBox("Failed to save file folder location")
            Return False

        End Try

        Try

            Dim tempExt As String = fileExtension

            appSettings.Settings.Remove("fileExtensionBackup")

            config.Save(ConfigurationSaveMode.Modified)

            appSettings.Settings.Add("fileExtensionBackup", tempExt)

            config.Save(ConfigurationSaveMode.Modified)

            ' Force a reload in memory of the changed section.
            ' This to read the section with the
            ' updated values.
            ConfigurationManager.RefreshSection("appSettings")

        Catch

            MsgBox("Failed to save file extension")
            Return False

        End Try

        Return True

    End Function


    Public Function ReadAppKey(key As String) As String

        Dim result As String = String.Empty

        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        Dim appSettings As System.Configuration.AppSettingsSection = config.AppSettings

        For Each keyName As KeyValueConfigurationElement In appSettings.Settings

            If keyName.Key = key Then
                result = keyName.Value
                Exit For
            End If

        Next

        Return result

    End Function

End Class
