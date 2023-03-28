Imports System.Configuration

Public Class ClassAppConfigValues

    Public Property SavedFileFolder As String
    Public Property SavedFileExtension As String
    Public Property SavedImportCDIfile As String
    Public Property SavedUserFile As String
    Public Property SavedReportFile As String
    Public Property SavedTitlesFile As String
    Public Property SavedBlankTowerFile
    Public Property SavedBlankSignalFile



    Public Sub AppConfigFileRead()

        Me.SavedFileFolder = My.Computer.FileSystem.CurrentDirectory
        Me.SavedFileExtension = "*.*"
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

                Case "savedFileFolder"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.SavedFileFolder = keyName.Value
                    End If

                Case "savedFileExtension"
                    If keyName.Value = String.Empty Then
                        ' do nothing
                    Else
                        Me.SavedFileExtension = keyName.Value
                    End If

            End Select

        Next

    End Sub


    Public Function AppConfigFileWrite(selectedPath As String, fileExtension As String) As Boolean

        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        ' Add the key/value pair to the appSettings 
        ' section.
        ' config.AppSettings.Settings.Add(keyName, value);
        Dim appSettings As System.Configuration.AppSettingsSection = config.AppSettings

        Try

            Dim tempPath As String = selectedPath

            appSettings.Settings.Remove("savedFileFolder")

            config.Save(ConfigurationSaveMode.Modified)

            appSettings.Settings.Add("savedFileFolder", tempPath)

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

            appSettings.Settings.Remove("savedFileExtension")

            config.Save(ConfigurationSaveMode.Modified)

            appSettings.Settings.Add("savedFileExtension", tempExt)

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

End Class
