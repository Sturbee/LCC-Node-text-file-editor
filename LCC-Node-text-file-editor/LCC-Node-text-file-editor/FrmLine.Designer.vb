﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.PanelDelay = New System.Windows.Forms.Panel()
        Me.LblInterval1 = New System.Windows.Forms.Label()
        Me.LblInterval2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTime = New System.Windows.Forms.Label()
        Me.LblUnit = New System.Windows.Forms.Label()
        Me.LblRetrigger = New System.Windows.Forms.Label()
        Me.TxtTime1 = New System.Windows.Forms.TextBox()
        Me.TxtTime2 = New System.Windows.Forms.TextBox()
        Me.LstUnits1 = New System.Windows.Forms.ListBox()
        Me.LstUnits2 = New System.Windows.Forms.ListBox()
        Me.LstRetrigger1 = New System.Windows.Forms.ListBox()
        Me.LstRetrigger2 = New System.Windows.Forms.ListBox()
        Me.PanelDelay.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblLine
        '
        Me.LblLine.AutoSize = True
        Me.LblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLine.Location = New System.Drawing.Point(73, 28)
        Me.LblLine.Name = "LblLine"
        Me.LblLine.Size = New System.Drawing.Size(48, 16)
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
        Me.LblLineNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLineNumber.Location = New System.Drawing.Point(121, 28)
        Me.LblLineNumber.Name = "LblLineNumber"
        Me.LblLineNumber.Size = New System.Drawing.Size(23, 16)
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
        'PanelDelay
        '
        Me.PanelDelay.Controls.Add(Me.LstRetrigger1)
        Me.PanelDelay.Controls.Add(Me.LstUnits2)
        Me.PanelDelay.Controls.Add(Me.LstUnits1)
        Me.PanelDelay.Controls.Add(Me.TxtTime2)
        Me.PanelDelay.Controls.Add(Me.TxtTime1)
        Me.PanelDelay.Controls.Add(Me.LblRetrigger)
        Me.PanelDelay.Controls.Add(Me.LblUnit)
        Me.PanelDelay.Controls.Add(Me.LblTime)
        Me.PanelDelay.Controls.Add(Me.Label1)
        Me.PanelDelay.Controls.Add(Me.LblInterval2)
        Me.PanelDelay.Controls.Add(Me.LblInterval1)
        Me.PanelDelay.Location = New System.Drawing.Point(76, 68)
        Me.PanelDelay.Name = "PanelDelay"
        Me.PanelDelay.Size = New System.Drawing.Size(648, 101)
        Me.PanelDelay.TabIndex = 5
        '
        'LblInterval1
        '
        Me.LblInterval1.AutoSize = True
        Me.LblInterval1.Location = New System.Drawing.Point(45, 37)
        Me.LblInterval1.Name = "LblInterval1"
        Me.LblInterval1.Size = New System.Drawing.Size(60, 16)
        Me.LblInterval1.TabIndex = 0
        Me.LblInterval1.Text = "Interval 1"
        '
        'LblInterval2
        '
        Me.LblInterval2.AutoSize = True
        Me.LblInterval2.Location = New System.Drawing.Point(45, 67)
        Me.LblInterval2.Name = "LblInterval2"
        Me.LblInterval2.Size = New System.Drawing.Size(60, 16)
        Me.LblInterval2.TabIndex = 1
        Me.LblInterval2.Text = "Interval 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Delay"
        '
        'LblTime
        '
        Me.LblTime.AutoSize = True
        Me.LblTime.Location = New System.Drawing.Point(198, 9)
        Me.LblTime.Name = "LblTime"
        Me.LblTime.Size = New System.Drawing.Size(38, 16)
        Me.LblTime.TabIndex = 3
        Me.LblTime.Text = "Time"
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Location = New System.Drawing.Point(343, 9)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(30, 16)
        Me.LblUnit.TabIndex = 4
        Me.LblUnit.Text = "Unit"
        '
        'LblRetrigger
        '
        Me.LblRetrigger.AutoSize = True
        Me.LblRetrigger.Location = New System.Drawing.Point(486, 9)
        Me.LblRetrigger.Name = "LblRetrigger"
        Me.LblRetrigger.Size = New System.Drawing.Size(63, 16)
        Me.LblRetrigger.TabIndex = 5
        Me.LblRetrigger.Text = "Retrigger"
        '
        'TxtTime1
        '
        Me.TxtTime1.Location = New System.Drawing.Point(172, 37)
        Me.TxtTime1.Name = "TxtTime1"
        Me.TxtTime1.Size = New System.Drawing.Size(100, 22)
        Me.TxtTime1.TabIndex = 6
        '
        'TxtTime2
        '
        Me.TxtTime2.Location = New System.Drawing.Point(172, 67)
        Me.TxtTime2.Name = "TxtTime2"
        Me.TxtTime2.Size = New System.Drawing.Size(100, 22)
        Me.TxtTime2.TabIndex = 7
        '
        'LstUnits1
        '
        Me.LstUnits1.FormattingEnabled = True
        Me.LstUnits1.ItemHeight = 16
        Me.LstUnits1.Location = New System.Drawing.Point(313, 37)
        Me.LstUnits1.Name = "LstUnits1"
        Me.LstUnits1.Size = New System.Drawing.Size(120, 20)
        Me.LstUnits1.TabIndex = 8
        '
        'LstUnits2
        '
        Me.LstUnits2.FormattingEnabled = True
        Me.LstUnits2.ItemHeight = 16
        Me.LstUnits2.Location = New System.Drawing.Point(313, 67)
        Me.LstUnits2.Name = "LstUnits2"
        Me.LstUnits2.Size = New System.Drawing.Size(120, 20)
        Me.LstUnits2.TabIndex = 9
        '
        'LstRetrigger1
        '
        Me.LstRetrigger1.FormattingEnabled = True
        Me.LstRetrigger1.ItemHeight = 16
        Me.LstRetrigger1.Location = New System.Drawing.Point(469, 37)
        Me.LstRetrigger1.Name = "LstRetrigger1"
        Me.LstRetrigger1.Size = New System.Drawing.Size(120, 20)
        Me.LstRetrigger1.TabIndex = 10
        '
        'LstRetrigger2
        '
        Me.LstRetrigger2.FormattingEnabled = True
        Me.LstRetrigger2.ItemHeight = 16
        Me.LstRetrigger2.Location = New System.Drawing.Point(545, 135)
        Me.LstRetrigger2.Name = "LstRetrigger2"
        Me.LstRetrigger2.Size = New System.Drawing.Size(120, 20)
        Me.LstRetrigger2.TabIndex = 11
        '
        'FrmLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LstRetrigger2)
        Me.Controls.Add(Me.PanelDelay)
        Me.Controls.Add(Me.LblDescription)
        Me.Controls.Add(Me.LblLineNumber)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblLine)
        Me.Name = "FrmLine"
        Me.Text = "FrmLine"
        Me.PanelDelay.ResumeLayout(False)
        Me.PanelDelay.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblLine As Label
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents LblLineNumber As Label
    Friend WithEvents LblDescription As Label
    Friend WithEvents PanelDelay As Panel
    Friend WithEvents LblInterval2 As Label
    Friend WithEvents LblInterval1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LstRetrigger1 As ListBox
    Friend WithEvents LstUnits2 As ListBox
    Friend WithEvents LstUnits1 As ListBox
    Friend WithEvents TxtTime2 As TextBox
    Friend WithEvents TxtTime1 As TextBox
    Friend WithEvents LblRetrigger As Label
    Friend WithEvents LblUnit As Label
    Friend WithEvents LblTime As Label
    Friend WithEvents LstRetrigger2 As ListBox
End Class
