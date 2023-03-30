<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserPrefs
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
        Me.CmbPath = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPath = New System.Windows.Forms.TextBox()
        Me.TxtExtension = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CmbPath
        '
        Me.CmbPath.FormattingEnabled = True
        Me.CmbPath.Location = New System.Drawing.Point(121, 23)
        Me.CmbPath.Name = "CmbPath"
        Me.CmbPath.Size = New System.Drawing.Size(328, 24)
        Me.CmbPath.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select user path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Path"
        '
        'TxtPath
        '
        Me.TxtPath.Enabled = False
        Me.TxtPath.Location = New System.Drawing.Point(121, 72)
        Me.TxtPath.Name = "TxtPath"
        Me.TxtPath.Size = New System.Drawing.Size(847, 22)
        Me.TxtPath.TabIndex = 3
        '
        'TxtExtension
        '
        Me.TxtExtension.Enabled = False
        Me.TxtExtension.Location = New System.Drawing.Point(121, 112)
        Me.TxtExtension.Name = "TxtExtension"
        Me.TxtExtension.Size = New System.Drawing.Size(100, 22)
        Me.TxtExtension.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Extension"
        '
        'CmdEdit
        '
        Me.CmdEdit.Location = New System.Drawing.Point(488, 23)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 6
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = True
        '
        'FrmUserPrefs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 450)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtExtension)
        Me.Controls.Add(Me.TxtPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbPath)
        Me.Name = "FrmUserPrefs"
        Me.Text = "User Preferences"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmbPath As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPath As TextBox
    Friend WithEvents TxtExtension As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CmdEdit As Button
End Class
