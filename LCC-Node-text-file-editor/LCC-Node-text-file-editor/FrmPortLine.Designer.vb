<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPortLine
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
        Me.LblLine = New System.Windows.Forms.Label()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.LblLineNumber = New System.Windows.Forms.Label()
        Me.LblDescription = New System.Windows.Forms.Label()
        Me.TxtTime2 = New System.Windows.Forms.TextBox()
        Me.TxtTime1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblInterval2 = New System.Windows.Forms.Label()
        Me.LblInterval1 = New System.Windows.Forms.Label()
        Me.CmbUnits1 = New System.Windows.Forms.ComboBox()
        Me.CmbRetrigger1 = New System.Windows.Forms.ComboBox()
        Me.CmbUnits2 = New System.Windows.Forms.ComboBox()
        Me.CmbRetrigger2 = New System.Windows.Forms.ComboBox()
        Me.GroupBoxDelay = New System.Windows.Forms.GroupBox()
        Me.GroupBoxConsumer = New System.Windows.Forms.GroupBox()
        Me.CmbEventOutCommd1 = New System.Windows.Forms.ComboBox()
        Me.TxtEventOut1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblOutCommd = New System.Windows.Forms.Label()
        Me.LblOutFunc = New System.Windows.Forms.Label()
        Me.CmbOutCommd = New System.Windows.Forms.ComboBox()
        Me.CmbOutFunc = New System.Windows.Forms.ComboBox()
        Me.GroupBoxProducer = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtEventIn1 = New System.Windows.Forms.TextBox()
        Me.CmbEventInCommd1 = New System.Windows.Forms.ComboBox()
        Me.LblInCommd = New System.Windows.Forms.Label()
        Me.LblInFunc = New System.Windows.Forms.Label()
        Me.CmbInCommd = New System.Windows.Forms.ComboBox()
        Me.CmbInFunc = New System.Windows.Forms.ComboBox()
        Me.GroupBoxDelay.SuspendLayout()
        Me.GroupBoxConsumer.SuspendLayout()
        Me.GroupBoxProducer.SuspendLayout()
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
        'TxtTime2
        '
        Me.TxtTime2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTime2.Location = New System.Drawing.Point(188, 93)
        Me.TxtTime2.Name = "TxtTime2"
        Me.TxtTime2.Size = New System.Drawing.Size(100, 22)
        Me.TxtTime2.TabIndex = 7
        '
        'TxtTime1
        '
        Me.TxtTime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTime1.Location = New System.Drawing.Point(188, 51)
        Me.TxtTime1.Name = "TxtTime1"
        Me.TxtTime1.Size = New System.Drawing.Size(100, 22)
        Me.TxtTime1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(464, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Retrigger"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(314, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Unit of Time"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(185, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Time"
        '
        'LblInterval2
        '
        Me.LblInterval2.AutoSize = True
        Me.LblInterval2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInterval2.Location = New System.Drawing.Point(45, 91)
        Me.LblInterval2.Name = "LblInterval2"
        Me.LblInterval2.Size = New System.Drawing.Size(60, 16)
        Me.LblInterval2.TabIndex = 1
        Me.LblInterval2.Text = "Interval 2"
        '
        'LblInterval1
        '
        Me.LblInterval1.AutoSize = True
        Me.LblInterval1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInterval1.Location = New System.Drawing.Point(45, 54)
        Me.LblInterval1.Name = "LblInterval1"
        Me.LblInterval1.Size = New System.Drawing.Size(60, 16)
        Me.LblInterval1.TabIndex = 0
        Me.LblInterval1.Text = "Interval 1"
        '
        'CmbUnits1
        '
        Me.CmbUnits1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbUnits1.FormattingEnabled = True
        Me.CmbUnits1.Location = New System.Drawing.Point(317, 51)
        Me.CmbUnits1.Name = "CmbUnits1"
        Me.CmbUnits1.Size = New System.Drawing.Size(121, 24)
        Me.CmbUnits1.TabIndex = 6
        '
        'CmbRetrigger1
        '
        Me.CmbRetrigger1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbRetrigger1.FormattingEnabled = True
        Me.CmbRetrigger1.Location = New System.Drawing.Point(467, 51)
        Me.CmbRetrigger1.Name = "CmbRetrigger1"
        Me.CmbRetrigger1.Size = New System.Drawing.Size(121, 24)
        Me.CmbRetrigger1.TabIndex = 7
        '
        'CmbUnits2
        '
        Me.CmbUnits2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbUnits2.FormattingEnabled = True
        Me.CmbUnits2.Location = New System.Drawing.Point(317, 93)
        Me.CmbUnits2.Name = "CmbUnits2"
        Me.CmbUnits2.Size = New System.Drawing.Size(121, 24)
        Me.CmbUnits2.TabIndex = 8
        '
        'CmbRetrigger2
        '
        Me.CmbRetrigger2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbRetrigger2.FormattingEnabled = True
        Me.CmbRetrigger2.Location = New System.Drawing.Point(467, 93)
        Me.CmbRetrigger2.Name = "CmbRetrigger2"
        Me.CmbRetrigger2.Size = New System.Drawing.Size(121, 24)
        Me.CmbRetrigger2.TabIndex = 9
        '
        'GroupBoxDelay
        '
        Me.GroupBoxDelay.Controls.Add(Me.CmbRetrigger2)
        Me.GroupBoxDelay.Controls.Add(Me.LblInterval2)
        Me.GroupBoxDelay.Controls.Add(Me.TxtTime2)
        Me.GroupBoxDelay.Controls.Add(Me.LblInterval1)
        Me.GroupBoxDelay.Controls.Add(Me.CmbUnits2)
        Me.GroupBoxDelay.Controls.Add(Me.TxtTime1)
        Me.GroupBoxDelay.Controls.Add(Me.CmbUnits1)
        Me.GroupBoxDelay.Controls.Add(Me.Label1)
        Me.GroupBoxDelay.Controls.Add(Me.CmbRetrigger1)
        Me.GroupBoxDelay.Controls.Add(Me.Label2)
        Me.GroupBoxDelay.Controls.Add(Me.Label3)
        Me.GroupBoxDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxDelay.Location = New System.Drawing.Point(76, 67)
        Me.GroupBoxDelay.Name = "GroupBoxDelay"
        Me.GroupBoxDelay.Size = New System.Drawing.Size(648, 133)
        Me.GroupBoxDelay.TabIndex = 6
        Me.GroupBoxDelay.TabStop = False
        Me.GroupBoxDelay.Text = "Delay"
        '
        'GroupBoxConsumer
        '
        Me.GroupBoxConsumer.Controls.Add(Me.CmbEventOutCommd1)
        Me.GroupBoxConsumer.Controls.Add(Me.TxtEventOut1)
        Me.GroupBoxConsumer.Controls.Add(Me.Label4)
        Me.GroupBoxConsumer.Controls.Add(Me.LblOutCommd)
        Me.GroupBoxConsumer.Controls.Add(Me.LblOutFunc)
        Me.GroupBoxConsumer.Controls.Add(Me.CmbOutCommd)
        Me.GroupBoxConsumer.Controls.Add(Me.CmbOutFunc)
        Me.GroupBoxConsumer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxConsumer.Location = New System.Drawing.Point(76, 223)
        Me.GroupBoxConsumer.Name = "GroupBoxConsumer"
        Me.GroupBoxConsumer.Size = New System.Drawing.Size(648, 169)
        Me.GroupBoxConsumer.TabIndex = 7
        Me.GroupBoxConsumer.TabStop = False
        Me.GroupBoxConsumer.Text = "Consumer"
        '
        'CmbEventOutCommd1
        '
        Me.CmbEventOutCommd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbEventOutCommd1.FormattingEnabled = True
        Me.CmbEventOutCommd1.Location = New System.Drawing.Point(85, 100)
        Me.CmbEventOutCommd1.Name = "CmbEventOutCommd1"
        Me.CmbEventOutCommd1.Size = New System.Drawing.Size(203, 24)
        Me.CmbEventOutCommd1.TabIndex = 6
        '
        'TxtEventOut1
        '
        Me.TxtEventOut1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEventOut1.Location = New System.Drawing.Point(85, 72)
        Me.TxtEventOut1.Name = "TxtEventOut1"
        Me.TxtEventOut1.Size = New System.Drawing.Size(203, 22)
        Me.TxtEventOut1.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Events"
        '
        'LblOutCommd
        '
        Me.LblOutCommd.AutoSize = True
        Me.LblOutCommd.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOutCommd.Location = New System.Drawing.Point(300, 29)
        Me.LblOutCommd.Name = "LblOutCommd"
        Me.LblOutCommd.Size = New System.Drawing.Size(77, 16)
        Me.LblOutCommd.TabIndex = 3
        Me.LblOutCommd.Text = "Out Commd"
        '
        'LblOutFunc
        '
        Me.LblOutFunc.AutoSize = True
        Me.LblOutFunc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOutFunc.Location = New System.Drawing.Point(45, 29)
        Me.LblOutFunc.Name = "LblOutFunc"
        Me.LblOutFunc.Size = New System.Drawing.Size(80, 16)
        Me.LblOutFunc.TabIndex = 2
        Me.LblOutFunc.Text = "Out Function"
        '
        'CmbOutCommd
        '
        Me.CmbOutCommd.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbOutCommd.FormattingEnabled = True
        Me.CmbOutCommd.Location = New System.Drawing.Point(361, 26)
        Me.CmbOutCommd.Name = "CmbOutCommd"
        Me.CmbOutCommd.Size = New System.Drawing.Size(131, 24)
        Me.CmbOutCommd.TabIndex = 1
        '
        'CmbOutFunc
        '
        Me.CmbOutFunc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbOutFunc.FormattingEnabled = True
        Me.CmbOutFunc.Location = New System.Drawing.Point(167, 26)
        Me.CmbOutFunc.Name = "CmbOutFunc"
        Me.CmbOutFunc.Size = New System.Drawing.Size(121, 24)
        Me.CmbOutFunc.TabIndex = 0
        '
        'GroupBoxProducer
        '
        Me.GroupBoxProducer.Controls.Add(Me.Label5)
        Me.GroupBoxProducer.Controls.Add(Me.TxtEventIn1)
        Me.GroupBoxProducer.Controls.Add(Me.CmbEventInCommd1)
        Me.GroupBoxProducer.Controls.Add(Me.LblInCommd)
        Me.GroupBoxProducer.Controls.Add(Me.LblInFunc)
        Me.GroupBoxProducer.Controls.Add(Me.CmbInCommd)
        Me.GroupBoxProducer.Controls.Add(Me.CmbInFunc)
        Me.GroupBoxProducer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxProducer.Location = New System.Drawing.Point(76, 408)
        Me.GroupBoxProducer.Name = "GroupBoxProducer"
        Me.GroupBoxProducer.Size = New System.Drawing.Size(648, 132)
        Me.GroupBoxProducer.TabIndex = 8
        Me.GroupBoxProducer.TabStop = False
        Me.GroupBoxProducer.Text = "Producer"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Events"
        '
        'TxtEventIn1
        '
        Me.TxtEventIn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEventIn1.Location = New System.Drawing.Point(85, 103)
        Me.TxtEventIn1.Name = "TxtEventIn1"
        Me.TxtEventIn1.Size = New System.Drawing.Size(203, 22)
        Me.TxtEventIn1.TabIndex = 5
        '
        'CmbEventInCommd1
        '
        Me.CmbEventInCommd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbEventInCommd1.FormattingEnabled = True
        Me.CmbEventInCommd1.Location = New System.Drawing.Point(85, 72)
        Me.CmbEventInCommd1.Name = "CmbEventInCommd1"
        Me.CmbEventInCommd1.Size = New System.Drawing.Size(203, 24)
        Me.CmbEventInCommd1.TabIndex = 4
        '
        'LblInCommd
        '
        Me.LblInCommd.AutoSize = True
        Me.LblInCommd.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInCommd.Location = New System.Drawing.Point(300, 32)
        Me.LblInCommd.Name = "LblInCommd"
        Me.LblInCommd.Size = New System.Drawing.Size(82, 16)
        Me.LblInCommd.TabIndex = 3
        Me.LblInCommd.Text = "In Command"
        '
        'LblInFunc
        '
        Me.LblInFunc.AutoSize = True
        Me.LblInFunc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInFunc.Location = New System.Drawing.Point(55, 32)
        Me.LblInFunc.Name = "LblInFunc"
        Me.LblInFunc.Size = New System.Drawing.Size(70, 16)
        Me.LblInFunc.TabIndex = 2
        Me.LblInFunc.Text = "In Function"
        '
        'CmbInCommd
        '
        Me.CmbInCommd.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbInCommd.FormattingEnabled = True
        Me.CmbInCommd.Location = New System.Drawing.Point(361, 29)
        Me.CmbInCommd.Name = "CmbInCommd"
        Me.CmbInCommd.Size = New System.Drawing.Size(131, 24)
        Me.CmbInCommd.TabIndex = 1
        '
        'CmbInFunc
        '
        Me.CmbInFunc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbInFunc.FormattingEnabled = True
        Me.CmbInFunc.Location = New System.Drawing.Point(167, 29)
        Me.CmbInFunc.Name = "CmbInFunc"
        Me.CmbInFunc.Size = New System.Drawing.Size(121, 24)
        Me.CmbInFunc.TabIndex = 0
        '
        'FrmLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(800, 548)
        Me.Controls.Add(Me.GroupBoxProducer)
        Me.Controls.Add(Me.GroupBoxConsumer)
        Me.Controls.Add(Me.GroupBoxDelay)
        Me.Controls.Add(Me.LblDescription)
        Me.Controls.Add(Me.LblLineNumber)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblLine)
        Me.Name = "FrmLine"
        Me.Text = "FrmLine"
        Me.GroupBoxDelay.ResumeLayout(False)
        Me.GroupBoxDelay.PerformLayout()
        Me.GroupBoxConsumer.ResumeLayout(False)
        Me.GroupBoxConsumer.PerformLayout()
        Me.GroupBoxProducer.ResumeLayout(False)
        Me.GroupBoxProducer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblLine As Label
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents LblLineNumber As Label
    Friend WithEvents LblDescription As Label
    Friend WithEvents LblInterval2 As Label
    Friend WithEvents LblInterval1 As Label
    Friend WithEvents TxtTime2 As TextBox
    Friend WithEvents TxtTime1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbUnits1 As ComboBox
    Friend WithEvents CmbRetrigger1 As ComboBox
    Friend WithEvents CmbUnits2 As ComboBox
    Friend WithEvents CmbRetrigger2 As ComboBox
    Friend WithEvents GroupBoxDelay As GroupBox
    Friend WithEvents GroupBoxConsumer As GroupBox
    Friend WithEvents GroupBoxProducer As GroupBox
    Friend WithEvents CmbOutCommd As ComboBox
    Friend WithEvents CmbOutFunc As ComboBox
    Friend WithEvents CmbInCommd As ComboBox
    Friend WithEvents CmbInFunc As ComboBox
    Friend WithEvents LblOutCommd As Label
    Friend WithEvents LblOutFunc As Label
    Friend WithEvents LblInCommd As Label
    Friend WithEvents LblInFunc As Label
    Friend WithEvents TxtEventOut1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CmbEventOutCommd1 As ComboBox
    Friend WithEvents TxtEventIn1 As TextBox
    Friend WithEvents CmbEventInCommd1 As ComboBox
    Friend WithEvents Label5 As Label
End Class
