<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLamp
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtLampOn = New System.Windows.Forms.TextBox()
        Me.LblLampOn = New System.Windows.Forms.Label()
        Me.LblHeader = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtLampOff = New System.Windows.Forms.TextBox()
        Me.LblLampOff = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CmbLampFade = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CmbLampSelection = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CmbLampPhase = New System.Windows.Forms.ComboBox()
        Me.LblLampID = New System.Windows.Forms.Label()
        Me.ExportXml1 = New LCC_Node_text_file_editor.ExportXml()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.LblBrightness = New System.Windows.Forms.Label()
        Me.TxtBrightness = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.ExportXml1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
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
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(119, 21)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(292, 22)
        Me.TxtDescription.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDescription)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(41, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(522, 58)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lamp Description"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtLampOn)
        Me.GroupBox2.Controls.Add(Me.LblLampOn)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 89)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lamp On"
        '
        'TxtLampOn
        '
        Me.TxtLampOn.Location = New System.Drawing.Point(44, 51)
        Me.TxtLampOn.Name = "TxtLampOn"
        Me.TxtLampOn.Size = New System.Drawing.Size(193, 22)
        Me.TxtLampOn.TabIndex = 1
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
        'LblHeader
        '
        Me.LblHeader.AutoSize = True
        Me.LblHeader.Location = New System.Drawing.Point(157, 18)
        Me.LblHeader.Name = "LblHeader"
        Me.LblHeader.Size = New System.Drawing.Size(71, 16)
        Me.LblHeader.TabIndex = 4
        Me.LblHeader.Text = "LblHeader"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtLampOff)
        Me.GroupBox3.Controls.Add(Me.LblLampOff)
        Me.GroupBox3.Location = New System.Drawing.Point(44, 207)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(519, 86)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lamp Off"
        '
        'TxtLampOff
        '
        Me.TxtLampOff.Location = New System.Drawing.Point(41, 58)
        Me.TxtLampOff.Name = "TxtLampOff"
        Me.TxtLampOff.Size = New System.Drawing.Size(190, 22)
        Me.TxtLampOff.TabIndex = 1
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CmbLampFade)
        Me.GroupBox4.Location = New System.Drawing.Point(44, 299)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(519, 59)
        Me.GroupBox4.TabIndex = 6
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CmbLampSelection)
        Me.GroupBox5.Location = New System.Drawing.Point(44, 365)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(519, 62)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Lamp Selection"
        '
        'CmbLampSelection
        '
        Me.CmbLampSelection.FormattingEnabled = True
        Me.CmbLampSelection.Location = New System.Drawing.Point(41, 21)
        Me.CmbLampSelection.Name = "CmbLampSelection"
        Me.CmbLampSelection.Size = New System.Drawing.Size(190, 24)
        Me.CmbLampSelection.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.CmbLampPhase)
        Me.GroupBox6.Location = New System.Drawing.Point(44, 434)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(519, 59)
        Me.GroupBox6.TabIndex = 8
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
        'LblLampID
        '
        Me.LblLampID.AutoSize = True
        Me.LblLampID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLampID.Location = New System.Drawing.Point(38, 18)
        Me.LblLampID.Name = "LblLampID"
        Me.LblLampID.Size = New System.Drawing.Size(81, 16)
        Me.LblLampID.TabIndex = 9
        Me.LblLampID.Text = "LblLampID"
        '
        'ExportXml1
        '
        Me.ExportXml1.DataSetName = "ExportXml"
        Me.ExportXml1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TxtBrightness)
        Me.GroupBox7.Controls.Add(Me.LblBrightness)
        Me.GroupBox7.Location = New System.Drawing.Point(41, 500)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(522, 58)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Brightness"
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
        'TxtBrightness
        '
        Me.TxtBrightness.Location = New System.Drawing.Point(374, 22)
        Me.TxtBrightness.Name = "TxtBrightness"
        Me.TxtBrightness.Size = New System.Drawing.Size(116, 22)
        Me.TxtBrightness.TabIndex = 1
        '
        'FrmLamp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(800, 589)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.LblLampID)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LblHeader)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmLamp"
        Me.Text = "Lamp Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.ExportXml1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtLampOn As TextBox
    Friend WithEvents LblLampOn As Label
    Friend WithEvents LblHeader As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TxtLampOff As TextBox
    Friend WithEvents LblLampOff As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CmbLampFade As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CmbLampSelection As ComboBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents CmbLampPhase As ComboBox
    Friend WithEvents LblLampID As Label
    Friend WithEvents ExportXml1 As ExportXml
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents TxtBrightness As TextBox
    Friend WithEvents LblBrightness As Label
End Class
