<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.ProcessFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PwrMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LampToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserPrefsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JMRIfilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrackSpeedsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcessFileToolStripMenuItem, Me.NodeToolStripMenuItem, Me.PwrMonitorToolStripMenuItem, Me.LampToolStripMenuItem, Me.UserPrefsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(904, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcessFileToolStripMenuItem
        '
        Me.ProcessFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcessToolStripMenuItem, Me.EditToolStripMenuItem, Me.RestoreToolStripMenuItem})
        Me.ProcessFileToolStripMenuItem.Name = "ProcessFileToolStripMenuItem"
        Me.ProcessFileToolStripMenuItem.Size = New System.Drawing.Size(52, 24)
        Me.ProcessFileToolStripMenuItem.Text = "Files"
        '
        'ProcessToolStripMenuItem
        '
        Me.ProcessToolStripMenuItem.Name = "ProcessToolStripMenuItem"
        Me.ProcessToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.ProcessToolStripMenuItem.Text = "Process"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'NodeToolStripMenuItem
        '
        Me.NodeToolStripMenuItem.Name = "NodeToolStripMenuItem"
        Me.NodeToolStripMenuItem.Size = New System.Drawing.Size(60, 24)
        Me.NodeToolStripMenuItem.Text = "Node"
        '
        'PwrMonitorToolStripMenuItem
        '
        Me.PwrMonitorToolStripMenuItem.Name = "PwrMonitorToolStripMenuItem"
        Me.PwrMonitorToolStripMenuItem.Size = New System.Drawing.Size(104, 24)
        Me.PwrMonitorToolStripMenuItem.Text = "Pwr Monitor"
        '
        'LampToolStripMenuItem
        '
        Me.LampToolStripMenuItem.Name = "LampToolStripMenuItem"
        Me.LampToolStripMenuItem.Size = New System.Drawing.Size(66, 24)
        Me.LampToolStripMenuItem.Text = "Lamps"
        '
        'UserPrefsToolStripMenuItem
        '
        Me.UserPrefsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JMRIfilesToolStripMenuItem, Me.TrackSpeedsToolStripMenuItem})
        Me.UserPrefsToolStripMenuItem.Name = "UserPrefsToolStripMenuItem"
        Me.UserPrefsToolStripMenuItem.Size = New System.Drawing.Size(132, 24)
        Me.UserPrefsToolStripMenuItem.Text = "User Preferences"
        '
        'JMRIfilesToolStripMenuItem
        '
        Me.JMRIfilesToolStripMenuItem.Name = "JMRIfilesToolStripMenuItem"
        Me.JMRIfilesToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.JMRIfilesToolStripMenuItem.Text = "JMRI File Location"
        '
        'TrackSpeedsToolStripMenuItem
        '
        Me.TrackSpeedsToolStripMenuItem.Name = "TrackSpeedsToolStripMenuItem"
        Me.TrackSpeedsToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.TrackSpeedsToolStripMenuItem.Text = "Track Speeds"
        '
        'FrmMenuMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 450)
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
    Friend WithEvents UserPrefsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JMRIfilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrackSpeedsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LampToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcessFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcessToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PwrMonitorToolStripMenuItem As ToolStripMenuItem
End Class
