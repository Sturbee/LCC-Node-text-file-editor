﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenuMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileProcessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileRestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PwrMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrackReceiversToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrackTransmittersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LampToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserTrackSpeedsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.NodeToolStripMenuItem, Me.PwrMonitorToolStripMenuItem, Me.PortToolStripMenuItem, Me.LogicToolStripMenuItem, Me.MastToolStripMenuItem, Me.TrackReceiversToolStripMenuItem, Me.TrackTransmittersToolStripMenuItem, Me.LampToolStripMenuItem, Me.UserToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1124, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileProcessToolStripMenuItem, Me.FileEditToolStripMenuItem, Me.FileRestoreToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(52, 24)
        Me.FileToolStripMenuItem.Text = "Files"
        '
        'FileProcessToolStripMenuItem
        '
        Me.FileProcessToolStripMenuItem.Name = "FileProcessToolStripMenuItem"
        Me.FileProcessToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.FileProcessToolStripMenuItem.Text = "Process"
        '
        'FileEditToolStripMenuItem
        '
        Me.FileEditToolStripMenuItem.Name = "FileEditToolStripMenuItem"
        Me.FileEditToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.FileEditToolStripMenuItem.Text = "Edit"
        '
        'FileRestoreToolStripMenuItem
        '
        Me.FileRestoreToolStripMenuItem.Name = "FileRestoreToolStripMenuItem"
        Me.FileRestoreToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.FileRestoreToolStripMenuItem.Text = "Restore"
        '
        'NodeToolStripMenuItem
        '
        Me.NodeToolStripMenuItem.Name = "NodeToolStripMenuItem"
        Me.NodeToolStripMenuItem.Size = New System.Drawing.Size(79, 24)
        Me.NodeToolStripMenuItem.Text = "Node ID"
        '
        'PwrMonitorToolStripMenuItem
        '
        Me.PwrMonitorToolStripMenuItem.Name = "PwrMonitorToolStripMenuItem"
        Me.PwrMonitorToolStripMenuItem.Size = New System.Drawing.Size(120, 24)
        Me.PwrMonitorToolStripMenuItem.Text = "Power Monitor"
        '
        'PortToolStripMenuItem
        '
        Me.PortToolStripMenuItem.Name = "PortToolStripMenuItem"
        Me.PortToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.PortToolStripMenuItem.Text = "Port I/O"
        '
        'LogicToolStripMenuItem
        '
        Me.LogicToolStripMenuItem.Name = "LogicToolStripMenuItem"
        Me.LogicToolStripMenuItem.Size = New System.Drawing.Size(106, 24)
        Me.LogicToolStripMenuItem.Text = "Conditionals"
        '
        'MastToolStripMenuItem
        '
        Me.MastToolStripMenuItem.Name = "MastToolStripMenuItem"
        Me.MastToolStripMenuItem.Size = New System.Drawing.Size(121, 24)
        Me.MastToolStripMenuItem.Text = "Rule To Aspect"
        '
        'TrackReceiversToolStripMenuItem
        '
        Me.TrackReceiversToolStripMenuItem.Name = "TrackReceiversToolStripMenuItem"
        Me.TrackReceiversToolStripMenuItem.Size = New System.Drawing.Size(117, 24)
        Me.TrackReceiversToolStripMenuItem.Text = "Track Receiver"
        '
        'TrackTransmittersToolStripMenuItem
        '
        Me.TrackTransmittersToolStripMenuItem.Name = "TrackTransmittersToolStripMenuItem"
        Me.TrackTransmittersToolStripMenuItem.Size = New System.Drawing.Size(135, 24)
        Me.TrackTransmittersToolStripMenuItem.Text = "Track Transmitter"
        '
        'LampToolStripMenuItem
        '
        Me.LampToolStripMenuItem.Name = "LampToolStripMenuItem"
        Me.LampToolStripMenuItem.Size = New System.Drawing.Size(66, 24)
        Me.LampToolStripMenuItem.Text = "Lamps"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserFilesToolStripMenuItem, Me.UserTrackSpeedsToolStripMenuItem})
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(132, 24)
        Me.UserToolStripMenuItem.Text = "User Preferences"
        '
        'UserFilesToolStripMenuItem
        '
        Me.UserFilesToolStripMenuItem.Name = "UserFilesToolStripMenuItem"
        Me.UserFilesToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.UserFilesToolStripMenuItem.Text = "JMRI File Locations"
        '
        'UserTrackSpeedsToolStripMenuItem
        '
        Me.UserTrackSpeedsToolStripMenuItem.Name = "UserTrackSpeedsToolStripMenuItem"
        Me.UserTrackSpeedsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.UserTrackSpeedsToolStripMenuItem.Text = "Track Speeds"
        '
        'FrmMenuMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMenuMain"
        Me.Text = "Main Menu > Files"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserTrackSpeedsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LampToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileProcessToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileEditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileRestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PwrMonitorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MastToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrackReceiversToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrackTransmittersToolStripMenuItem As ToolStripMenuItem
End Class
