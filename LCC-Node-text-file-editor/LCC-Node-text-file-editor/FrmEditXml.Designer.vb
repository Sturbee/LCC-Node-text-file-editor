﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditXml
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FilesListBox = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtFileExtension = New System.Windows.Forms.TextBox()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.CmdBrowse = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FilesListBox
        '
        Me.FilesListBox.FormattingEnabled = True
        Me.FilesListBox.ItemHeight = 16
        Me.FilesListBox.Location = New System.Drawing.Point(49, 23)
        Me.FilesListBox.Name = "FilesListBox"
        Me.FilesListBox.Size = New System.Drawing.Size(775, 372)
        Me.FilesListBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 414)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Search by File Extension"
        '
        'TxtFileExtension
        '
        Me.TxtFileExtension.Location = New System.Drawing.Point(225, 411)
        Me.TxtFileExtension.Name = "TxtFileExtension"
        Me.TxtFileExtension.Size = New System.Drawing.Size(100, 22)
        Me.TxtFileExtension.TabIndex = 7
        '
        'CmdEdit
        '
        Me.CmdEdit.Location = New System.Drawing.Point(851, 90)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 10
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = True
        '
        'CmdBrowse
        '
        Me.CmdBrowse.Location = New System.Drawing.Point(851, 30)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.CmdBrowse.TabIndex = 9
        Me.CmdBrowse.Text = "Browse"
        Me.CmdBrowse.UseVisualStyleBackColor = True
        '
        'FrmEditXml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(960, 450)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtFileExtension)
        Me.Controls.Add(Me.FilesListBox)
        Me.Name = "FrmEditXml"
        Me.Text = "File Xml Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FilesListBox As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtFileExtension As TextBox
    Friend WithEvents CmdEdit As Button
    Friend WithEvents CmdBrowse As Button
End Class
