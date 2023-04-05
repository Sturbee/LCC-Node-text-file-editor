<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPowerMonitor
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
        Me.LblOptions = New System.Windows.Forms.Label()
        Me.LblPowerOK = New System.Windows.Forms.Label()
        Me.LblPowerNotOK = New System.Windows.Forms.Label()
        Me.TxtPowerOK = New System.Windows.Forms.TextBox()
        Me.TxtPowerNotOK = New System.Windows.Forms.TextBox()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbOption = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LblOptions
        '
        Me.LblOptions.AutoSize = True
        Me.LblOptions.Location = New System.Drawing.Point(163, 33)
        Me.LblOptions.Name = "LblOptions"
        Me.LblOptions.Size = New System.Drawing.Size(71, 16)
        Me.LblOptions.TabIndex = 0
        Me.LblOptions.Text = "LblOptions"
        '
        'LblPowerOK
        '
        Me.LblPowerOK.AutoSize = True
        Me.LblPowerOK.Location = New System.Drawing.Point(153, 80)
        Me.LblPowerOK.Name = "LblPowerOK"
        Me.LblPowerOK.Size = New System.Drawing.Size(81, 16)
        Me.LblPowerOK.TabIndex = 1
        Me.LblPowerOK.Text = "LblPowerOK"
        '
        'LblPowerNotOK
        '
        Me.LblPowerNotOK.AutoSize = True
        Me.LblPowerNotOK.Location = New System.Drawing.Point(41, 117)
        Me.LblPowerNotOK.Name = "LblPowerNotOK"
        Me.LblPowerNotOK.Size = New System.Drawing.Size(102, 16)
        Me.LblPowerNotOK.TabIndex = 2
        Me.LblPowerNotOK.Text = "LblPowerNotOK"
        '
        'TxtPowerOK
        '
        Me.TxtPowerOK.Location = New System.Drawing.Point(296, 74)
        Me.TxtPowerOK.Name = "TxtPowerOK"
        Me.TxtPowerOK.Size = New System.Drawing.Size(181, 22)
        Me.TxtPowerOK.TabIndex = 4
        '
        'TxtPowerNotOK
        '
        Me.TxtPowerNotOK.Location = New System.Drawing.Point(296, 117)
        Me.TxtPowerNotOK.Name = "TxtPowerNotOK"
        Me.TxtPowerNotOK.Size = New System.Drawing.Size(181, 22)
        Me.TxtPowerNotOK.TabIndex = 5
        '
        'ButSave
        '
        Me.ButSave.Location = New System.Drawing.Point(296, 160)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(75, 23)
        Me.ButSave.TabIndex = 6
        Me.ButSave.Text = "Save"
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(177, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Save Changes"
        '
        'CmbOption
        '
        Me.CmbOption.FormattingEnabled = True
        Me.CmbOption.Location = New System.Drawing.Point(296, 30)
        Me.CmbOption.Name = "CmbOption"
        Me.CmbOption.Size = New System.Drawing.Size(290, 24)
        Me.CmbOption.TabIndex = 8
        '
        'FrmPowerMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 222)
        Me.Controls.Add(Me.CmbOption)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButSave)
        Me.Controls.Add(Me.TxtPowerNotOK)
        Me.Controls.Add(Me.TxtPowerOK)
        Me.Controls.Add(Me.LblPowerNotOK)
        Me.Controls.Add(Me.LblPowerOK)
        Me.Controls.Add(Me.LblOptions)
        Me.Name = "FrmPowerMonitor"
        Me.Text = "FrmPowerMonitor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblOptions As Label
    Friend WithEvents LblPowerOK As Label
    Friend WithEvents LblPowerNotOK As Label
    Friend WithEvents TxtPowerOK As TextBox
    Friend WithEvents TxtPowerNotOK As TextBox
    Friend WithEvents ButSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents CmbOption As ComboBox
End Class
