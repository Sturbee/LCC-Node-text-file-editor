﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFileBackup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.FilesListBox = New System.Windows.Forms.ListBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TextBoxFileExtension = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdProcess = New System.Windows.Forms.Button()
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BrowseButton
        '
        Me.BrowseButton.Location = New System.Drawing.Point(759, 13)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton.TabIndex = 1
        Me.BrowseButton.Text = "Browse"
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'FilesListBox
        '
        Me.FilesListBox.FormattingEnabled = True
        Me.FilesListBox.HorizontalScrollbar = True
        Me.FilesListBox.ItemHeight = 16
        Me.FilesListBox.Location = New System.Drawing.Point(22, 12)
        Me.FilesListBox.Name = "FilesListBox"
        Me.FilesListBox.Size = New System.Drawing.Size(689, 372)
        Me.FilesListBox.TabIndex = 0
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.SelectedPath = "FilesListBox"
        '
        'TextBoxFileExtension
        '
        Me.TextBoxFileExtension.Location = New System.Drawing.Point(198, 409)
        Me.TextBoxFileExtension.Name = "TextBoxFileExtension"
        Me.TextBoxFileExtension.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxFileExtension.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 412)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Search by File Extension"
        '
        'CmdProcess
        '
        Me.CmdProcess.Location = New System.Drawing.Point(759, 73)
        Me.CmdProcess.Name = "CmdProcess"
        Me.CmdProcess.Size = New System.Drawing.Size(75, 23)
        Me.CmdProcess.TabIndex = 7
        Me.CmdProcess.Text = "Process"
        Me.MyToolTip.SetToolTip(Me.CmdProcess, "This creates a new xml file with same name as the selected text file")
        Me.CmdProcess.UseVisualStyleBackColor = True
        '
        'FrmFileBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 450)
        Me.Controls.Add(Me.CmdProcess)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxFileExtension)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.FilesListBox)
        Me.Name = "FrmFileBackup"
        Me.Text = "Select CDI text file to process"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FilesListBox As ListBox
    Friend WithEvents BrowseButton As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents TextBoxFileExtension As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CmdProcess As Button
    Friend WithEvents MyToolTip As ToolTip
End Class
