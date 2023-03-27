<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPowerMonitor
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LstMessageOption = New System.Windows.Forms.ListBox()
        Me.TxtPowerOK = New System.Windows.Forms.TextBox()
        Me.TxtPowerNotOK = New System.Windows.Forms.TextBox()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(157, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Message Options"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Power OK EventID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(220, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Power Not OK EventID (may be lost)"
        '
        'LstMessageOption
        '
        Me.LstMessageOption.FormattingEnabled = True
        Me.LstMessageOption.ItemHeight = 16
        Me.LstMessageOption.Location = New System.Drawing.Point(299, 66)
        Me.LstMessageOption.Name = "LstMessageOption"
        Me.LstMessageOption.Size = New System.Drawing.Size(290, 52)
        Me.LstMessageOption.TabIndex = 3
        '
        'TxtPowerOK
        '
        Me.TxtPowerOK.Location = New System.Drawing.Point(290, 164)
        Me.TxtPowerOK.Name = "TxtPowerOK"
        Me.TxtPowerOK.Size = New System.Drawing.Size(181, 22)
        Me.TxtPowerOK.TabIndex = 4
        '
        'TxtPowerNotOK
        '
        Me.TxtPowerNotOK.Location = New System.Drawing.Point(290, 207)
        Me.TxtPowerNotOK.Name = "TxtPowerNotOK"
        Me.TxtPowerNotOK.Size = New System.Drawing.Size(181, 22)
        Me.TxtPowerNotOK.TabIndex = 5
        '
        'ButSave
        '
        Me.ButSave.Location = New System.Drawing.Point(290, 281)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(75, 23)
        Me.ButSave.TabIndex = 6
        Me.ButSave.Text = "Save"
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(174, 284)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Save Changes"
        '
        'FrmPowerMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButSave)
        Me.Controls.Add(Me.TxtPowerNotOK)
        Me.Controls.Add(Me.TxtPowerOK)
        Me.Controls.Add(Me.LstMessageOption)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPowerMonitor"
        Me.Text = "Segment: Node Power Monitor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LstMessageOption As ListBox
    Friend WithEvents TxtPowerOK As TextBox
    Friend WithEvents TxtPowerNotOK As TextBox
    Friend WithEvents ButSave As Button
    Friend WithEvents Label4 As Label
End Class
