<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFileRestore
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
        Me.FilesListBox = New System.Windows.Forms.ListBox()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxFileExtension = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'FilesListBox
        '
        Me.FilesListBox.FormattingEnabled = True
        Me.FilesListBox.HorizontalScrollbar = True
        Me.FilesListBox.ItemHeight = 16
        Me.FilesListBox.Location = New System.Drawing.Point(23, 12)
        Me.FilesListBox.Name = "FilesListBox"
        Me.FilesListBox.Size = New System.Drawing.Size(838, 372)
        Me.FilesListBox.TabIndex = 1
        '
        'BrowseButton
        '
        Me.BrowseButton.Location = New System.Drawing.Point(902, 12)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton.TabIndex = 2
        Me.BrowseButton.Text = "Browse"
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 408)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Search by File Extension"
        '
        'TextBoxFileExtension
        '
        Me.TextBoxFileExtension.Location = New System.Drawing.Point(199, 405)
        Me.TextBoxFileExtension.Name = "TextBoxFileExtension"
        Me.TextBoxFileExtension.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxFileExtension.TabIndex = 7
        '
        'FrmFileRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxFileExtension)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.FilesListBox)
        Me.Name = "FrmFileRestore"
        Me.Text = "Restore Files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FilesListBox As ListBox
    Friend WithEvents BrowseButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxFileExtension As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
