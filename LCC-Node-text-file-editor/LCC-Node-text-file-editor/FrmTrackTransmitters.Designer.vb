﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrackTransmitters
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
        Me.TabControlTransmitters = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LblSubHeader = New System.Windows.Forms.Label()
        Me.LblHelp = New System.Windows.Forms.Label()
        Me.TabControlTransmitters.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlTransmitters
        '
        Me.TabControlTransmitters.Controls.Add(Me.TabPage1)
        Me.TabControlTransmitters.Controls.Add(Me.TabPage2)
        Me.TabControlTransmitters.Location = New System.Drawing.Point(10, 55)
        Me.TabControlTransmitters.Multiline = True
        Me.TabControlTransmitters.Name = "TabControlTransmitters"
        Me.TabControlTransmitters.SelectedIndex = 0
        Me.TabControlTransmitters.Size = New System.Drawing.Size(889, 502)
        Me.TabControlTransmitters.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(881, 473)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(881, 473)
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
        Me.LblHelp.TabIndex = 9
        Me.LblHelp.Text = "lblHelp"
        '
        'FrmTrackTransmitters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 583)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.LblSubHeader)
        Me.Controls.Add(Me.TabControlTransmitters)
        Me.Name = "FrmTrackTransmitters"
        Me.Text = "FrmTrackTransmitters"
        Me.TabControlTransmitters.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControlTransmitters As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents LblSubHeader As Label
    Friend WithEvents LblHelp As Label
End Class
