<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLine
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
        Me.LblLine = New System.Windows.Forms.Label()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.LblLineNumber = New System.Windows.Forms.Label()
        Me.LblDescription = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblLine
        '
        Me.LblLine.AutoSize = True
        Me.LblLine.Location = New System.Drawing.Point(73, 28)
        Me.LblLine.Name = "LblLine"
        Me.LblLine.Size = New System.Drawing.Size(42, 16)
        Me.LblLine.TabIndex = 0
        Me.LblLine.Text = "Line #"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(260, 25)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(140, 22)
        Me.TxtDescription.TabIndex = 1
        Me.TxtDescription.Text = "Descript"
        '
        'LblLineNumber
        '
        Me.LblLineNumber.AutoSize = True
        Me.LblLineNumber.Location = New System.Drawing.Point(121, 28)
        Me.LblLineNumber.Name = "LblLineNumber"
        Me.LblLineNumber.Size = New System.Drawing.Size(21, 16)
        Me.LblLineNumber.TabIndex = 2
        Me.LblLineNumber.Text = "##"
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Location = New System.Drawing.Point(179, 28)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(75, 16)
        Me.LblDescription.TabIndex = 3
        Me.LblDescription.Text = "Description"
        '
        'FrmLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LblDescription)
        Me.Controls.Add(Me.LblLineNumber)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblLine)
        Me.Name = "FrmLine"
        Me.Text = "FrmLine"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblLine As Label
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents LblLineNumber As Label
    Friend WithEvents LblDescription As Label
End Class
