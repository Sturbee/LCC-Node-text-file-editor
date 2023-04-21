<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLamps
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TxtBrightness = New System.Windows.Forms.TextBox()
        Me.LblBrightness = New System.Windows.Forms.Label()
        Me.LblLampID = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblHelp = New System.Windows.Forms.Label()
        Me.LblSubHeader = New System.Windows.Forms.Label()
        Me.TabControlLamps = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControlLamps.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(980, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Save Changes"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(1099, 44)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 31
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TxtBrightness)
        Me.GroupBox7.Controls.Add(Me.LblBrightness)
        Me.GroupBox7.Location = New System.Drawing.Point(71, 254)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(522, 58)
        Me.GroupBox7.TabIndex = 30
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Brightness"
        '
        'TxtBrightness
        '
        Me.TxtBrightness.Location = New System.Drawing.Point(374, 22)
        Me.TxtBrightness.Name = "TxtBrightness"
        Me.TxtBrightness.Size = New System.Drawing.Size(116, 22)
        Me.TxtBrightness.TabIndex = 1
        '
        'LblBrightness
        '
        Me.LblBrightness.AutoSize = True
        Me.LblBrightness.Location = New System.Drawing.Point(41, 25)
        Me.LblBrightness.Name = "LblBrightness"
        Me.LblBrightness.Size = New System.Drawing.Size(88, 16)
        Me.LblBrightness.TabIndex = 0
        Me.LblBrightness.Text = "LblBrightness"
        '
        'LblLampID
        '
        Me.LblLampID.AutoSize = True
        Me.LblLampID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLampID.Location = New System.Drawing.Point(68, 161)
        Me.LblLampID.Name = "LblLampID"
        Me.LblLampID.Size = New System.Drawing.Size(81, 16)
        Me.LblLampID.TabIndex = 29
        Me.LblLampID.Text = "LblLampID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDescription)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(71, 190)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(522, 58)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lamp Description"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(119, 21)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(292, 22)
        Me.TxtDescription.TabIndex = 1
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
        'LblHelp
        '
        Me.LblHelp.AutoSize = True
        Me.LblHelp.Location = New System.Drawing.Point(66, 51)
        Me.LblHelp.Name = "LblHelp"
        Me.LblHelp.Size = New System.Drawing.Size(50, 16)
        Me.LblHelp.TabIndex = 23
        Me.LblHelp.Text = "lblHelp"
        '
        'LblSubHeader
        '
        Me.LblSubHeader.AutoSize = True
        Me.LblSubHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubHeader.Location = New System.Drawing.Point(66, 26)
        Me.LblSubHeader.Name = "LblSubHeader"
        Me.LblSubHeader.Size = New System.Drawing.Size(107, 16)
        Me.LblSubHeader.TabIndex = 22
        Me.LblSubHeader.Text = "LblSubHeader"
        '
        'TabControlLamps
        '
        Me.TabControlLamps.Controls.Add(Me.TabPage1)
        Me.TabControlLamps.Controls.Add(Me.TabPage2)
        Me.TabControlLamps.Location = New System.Drawing.Point(66, 71)
        Me.TabControlLamps.Multiline = True
        Me.TabControlLamps.Name = "TabControlLamps"
        Me.TabControlLamps.SelectedIndex = 0
        Me.TabControlLamps.Size = New System.Drawing.Size(1112, 44)
        Me.TabControlLamps.TabIndex = 21
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
        'FrmLamps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 353)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.LblLampID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.LblSubHeader)
        Me.Controls.Add(Me.TabControlLamps)
        Me.Name = "FrmLamps"
        Me.Text = "FrmLamps"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControlLamps.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents BtnSave As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents TxtBrightness As TextBox
    Friend WithEvents LblBrightness As Label
    Friend WithEvents LblLampID As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblHelp As Label
    Friend WithEvents LblSubHeader As Label
    Friend WithEvents TabControlLamps As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents MyToolTip As ToolTip
End Class
