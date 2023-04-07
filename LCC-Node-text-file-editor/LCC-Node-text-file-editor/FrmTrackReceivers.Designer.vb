<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrackReceivers
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
        Me.components = New System.ComponentModel.Container()
        Me.TabControlReceivers = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LblSubHeader = New System.Windows.Forms.Label()
        Me.LblHelp1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtLinkEvent = New System.Windows.Forms.TextBox()
        Me.LblHelp2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControlReceivers.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlReceivers
        '
        Me.TabControlReceivers.Controls.Add(Me.TabPage1)
        Me.TabControlReceivers.Controls.Add(Me.TabPage2)
        Me.TabControlReceivers.Location = New System.Drawing.Point(10, 55)
        Me.TabControlReceivers.Multiline = True
        Me.TabControlReceivers.Name = "TabControlReceivers"
        Me.TabControlReceivers.SelectedIndex = 0
        Me.TabControlReceivers.Size = New System.Drawing.Size(693, 38)
        Me.TabControlReceivers.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(685, 9)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(685, 9)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LblSubHeader
        '
        Me.LblSubHeader.AutoSize = True
        Me.LblSubHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubHeader.Location = New System.Drawing.Point(10, 10)
        Me.LblSubHeader.Name = "LblSubHeader"
        Me.LblSubHeader.Size = New System.Drawing.Size(107, 16)
        Me.LblSubHeader.TabIndex = 5
        Me.LblSubHeader.Text = "LblSubHeader"
        '
        'LblHelp1
        '
        Me.LblHelp1.AutoSize = True
        Me.LblHelp1.Location = New System.Drawing.Point(10, 35)
        Me.LblHelp1.Name = "LblHelp1"
        Me.LblHelp1.Size = New System.Drawing.Size(57, 16)
        Me.LblHelp1.TabIndex = 8
        Me.LblHelp1.Text = "lblHelp1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDescription)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Remote Mast Description"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(34, 33)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(351, 22)
        Me.TxtDescription.TabIndex = 0
        Me.MyToolTip.SetToolTip(Me.TxtDescription, "Mast name to receive track speed from")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtLinkEvent)
        Me.GroupBox2.Controls.Add(Me.LblHelp2)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 186)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(689, 96)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Link Address"
        '
        'TxtLinkEvent
        '
        Me.TxtLinkEvent.Enabled = False
        Me.TxtLinkEvent.Location = New System.Drawing.Point(37, 54)
        Me.TxtLinkEvent.Name = "TxtLinkEvent"
        Me.TxtLinkEvent.Size = New System.Drawing.Size(348, 22)
        Me.TxtLinkEvent.TabIndex = 1
        Me.MyToolTip.SetToolTip(Me.TxtLinkEvent, "Event address of remote mast to receive track speed from")
        '
        'LblHelp2
        '
        Me.LblHelp2.AutoSize = True
        Me.LblHelp2.Location = New System.Drawing.Point(34, 22)
        Me.LblHelp2.Name = "LblHelp2"
        Me.LblHelp2.Size = New System.Drawing.Size(57, 16)
        Me.LblHelp2.TabIndex = 0
        Me.LblHelp2.Text = "lblHelp2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(505, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Save Changes"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(624, 12)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 13
        Me.BtnSave.Text = "Save"
        Me.MyToolTip.SetToolTip(Me.BtnSave, "Save changes and reload values")
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'FrmTrackReceivers
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(722, 303)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblHelp1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblSubHeader)
        Me.Controls.Add(Me.TabControlReceivers)
        Me.Name = "FrmTrackReceivers"
        Me.Text = "FrmTrackReceivers"
        Me.TabControlReceivers.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControlReceivers As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents LblSubHeader As Label
    Friend WithEvents LblHelp1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtLinkEvent As TextBox
    Friend WithEvents LblHelp2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnSave As Button
    Friend WithEvents MyToolTip As ToolTip
End Class
