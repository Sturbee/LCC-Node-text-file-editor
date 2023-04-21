<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLampsDirect
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
        Me.TabControlLamps = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LblSubHeader = New System.Windows.Forms.Label()
        Me.LblHelp = New System.Windows.Forms.Label()
        Me.LblLampID = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CmbLampPhase = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CmbLampFade = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtLampOff = New System.Windows.Forms.TextBox()
        Me.LblLampOff = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtLampOn = New System.Windows.Forms.TextBox()
        Me.LblLampOn = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControlLamps.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlLamps
        '
        Me.TabControlLamps.Controls.Add(Me.TabPage1)
        Me.TabControlLamps.Controls.Add(Me.TabPage2)
        Me.TabControlLamps.Location = New System.Drawing.Point(10, 55)
        Me.TabControlLamps.Multiline = True
        Me.TabControlLamps.Name = "TabControlLamps"
        Me.TabControlLamps.SelectedIndex = 0
        Me.TabControlLamps.Size = New System.Drawing.Size(1112, 44)
        Me.TabControlLamps.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1104, 15)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1104, 15)
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
        Me.LblSubHeader.TabIndex = 6
        Me.LblSubHeader.Text = "LblSubHeader"
        '
        'LblHelp
        '
        Me.LblHelp.AutoSize = True
        Me.LblHelp.Location = New System.Drawing.Point(10, 35)
        Me.LblHelp.Name = "LblHelp"
        Me.LblHelp.Size = New System.Drawing.Size(50, 16)
        Me.LblHelp.TabIndex = 7
        Me.LblHelp.Text = "lblHelp"
        '
        'LblLampID
        '
        Me.LblLampID.AutoSize = True
        Me.LblLampID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLampID.Location = New System.Drawing.Point(12, 145)
        Me.LblLampID.Name = "LblLampID"
        Me.LblLampID.Size = New System.Drawing.Size(81, 16)
        Me.LblLampID.TabIndex = 16
        Me.LblLampID.Text = "LblLampID"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.CmbLampPhase)
        Me.GroupBox6.Location = New System.Drawing.Point(18, 491)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(519, 59)
        Me.GroupBox6.TabIndex = 15
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Lamp Phase (A-B) - Flash Rate"
        '
        'CmbLampPhase
        '
        Me.CmbLampPhase.FormattingEnabled = True
        Me.CmbLampPhase.Location = New System.Drawing.Point(41, 21)
        Me.CmbLampPhase.Name = "CmbLampPhase"
        Me.CmbLampPhase.Size = New System.Drawing.Size(190, 24)
        Me.CmbLampPhase.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CmbLampFade)
        Me.GroupBox4.Location = New System.Drawing.Point(18, 426)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(519, 59)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Lamp Fade"
        '
        'CmbLampFade
        '
        Me.CmbLampFade.FormattingEnabled = True
        Me.CmbLampFade.Location = New System.Drawing.Point(41, 21)
        Me.CmbLampFade.Name = "CmbLampFade"
        Me.CmbLampFade.Size = New System.Drawing.Size(190, 24)
        Me.CmbLampFade.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtLampOff)
        Me.GroupBox3.Controls.Add(Me.LblLampOff)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 334)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(519, 86)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lamp Off"
        '
        'TxtLampOff
        '
        Me.TxtLampOff.Enabled = False
        Me.TxtLampOff.Location = New System.Drawing.Point(41, 58)
        Me.TxtLampOff.Name = "TxtLampOff"
        Me.TxtLampOff.Size = New System.Drawing.Size(190, 22)
        Me.TxtLampOff.TabIndex = 1
        Me.MyToolTip.SetToolTip(Me.TxtLampOff, "Event address to turn lamp off")
        '
        'LblLampOff
        '
        Me.LblLampOff.AutoSize = True
        Me.LblLampOff.Location = New System.Drawing.Point(38, 29)
        Me.LblLampOff.Name = "LblLampOff"
        Me.LblLampOff.Size = New System.Drawing.Size(75, 16)
        Me.LblLampOff.TabIndex = 0
        Me.LblLampOff.Text = "LblLabelOff"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtLampOn)
        Me.GroupBox2.Controls.Add(Me.LblLampOn)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 238)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 89)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lamp On"
        '
        'TxtLampOn
        '
        Me.TxtLampOn.Enabled = False
        Me.TxtLampOn.Location = New System.Drawing.Point(44, 51)
        Me.TxtLampOn.Name = "TxtLampOn"
        Me.TxtLampOn.Size = New System.Drawing.Size(193, 22)
        Me.TxtLampOn.TabIndex = 1
        Me.MyToolTip.SetToolTip(Me.TxtLampOn, "Event address to turn lamp on")
        '
        'LblLampOn
        '
        Me.LblLampOn.AutoSize = True
        Me.LblLampOn.Location = New System.Drawing.Point(41, 22)
        Me.LblLampOn.Name = "LblLampOn"
        Me.LblLampOn.Size = New System.Drawing.Size(76, 16)
        Me.LblLampOn.TabIndex = 0
        Me.LblLampOn.Text = "LblLampOn"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDescription)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(522, 58)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lamp Description"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(119, 21)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(292, 22)
        Me.TxtDescription.TabIndex = 1
        Me.MyToolTip.SetToolTip(Me.TxtDescription, "Name of your lamp, ex: Mast 1 Head 1 Green")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(924, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Save Changes"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(1043, 28)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 19
        Me.BtnSave.Text = "Save"
        Me.MyToolTip.SetToolTip(Me.BtnSave, "Will save changes and reload values")
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'FrmLampsDirect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1134, 578)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LblLampID)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.LblSubHeader)
        Me.Controls.Add(Me.TabControlLamps)
        Me.Name = "FrmLampsDirect"
        Me.Text = "FrmLampsDirect"
        Me.TabControlLamps.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControlLamps As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents LblSubHeader As Label
    Friend WithEvents LblHelp As Label
    Friend WithEvents LblLampID As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents CmbLampPhase As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CmbLampFade As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TxtLampOff As TextBox
    Friend WithEvents LblLampOff As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtLampOn As TextBox
    Friend WithEvents LblLampOn As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnSave As Button
    Friend WithEvents MyToolTip As ToolTip
End Class
