<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNode
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
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblDecription = New System.Windows.Forms.Label()
        Me.LblNodeType = New System.Windows.Forms.Label()
        Me.LblEventBase = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNodeName = New System.Windows.Forms.TextBox()
        Me.TxtNodeDescription = New System.Windows.Forms.TextBox()
        Me.LblFileName = New System.Windows.Forms.Label()
        Me.LblType = New System.Windows.Forms.Label()
        Me.LblBaseAddress = New System.Windows.Forms.Label()
        Me.ButSaveChanges = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(100, 146)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(62, 16)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "LblName"
        '
        'LblDecription
        '
        Me.LblDecription.AutoSize = True
        Me.LblDecription.Location = New System.Drawing.Point(69, 188)
        Me.LblDecription.Name = "LblDecription"
        Me.LblDecription.Size = New System.Drawing.Size(93, 16)
        Me.LblDecription.TabIndex = 1
        Me.LblDecription.Text = "LblDescription"
        '
        'LblNodeType
        '
        Me.LblNodeType.AutoSize = True
        Me.LblNodeType.Location = New System.Drawing.Point(105, 68)
        Me.LblNodeType.Name = "LblNodeType"
        Me.LblNodeType.Size = New System.Drawing.Size(91, 16)
        Me.LblNodeType.TabIndex = 2
        Me.LblNodeType.Text = "LblNodeType"
        '
        'LblEventBase
        '
        Me.LblEventBase.AutoSize = True
        Me.LblEventBase.Location = New System.Drawing.Point(88, 109)
        Me.LblEventBase.Name = "LblEventBase"
        Me.LblEventBase.Size = New System.Drawing.Size(91, 16)
        Me.LblEventBase.TabIndex = 3
        Me.LblEventBase.Text = "LblEventBase"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(117, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "File Name"
        '
        'TxtNodeName
        '
        Me.TxtNodeName.Location = New System.Drawing.Point(209, 146)
        Me.TxtNodeName.Name = "TxtNodeName"
        Me.TxtNodeName.Size = New System.Drawing.Size(282, 22)
        Me.TxtNodeName.TabIndex = 5
        Me.MyToolTip.SetToolTip(Me.TxtNodeName, "Node name should be short")
        '
        'TxtNodeDescription
        '
        Me.TxtNodeDescription.Location = New System.Drawing.Point(209, 188)
        Me.TxtNodeDescription.Name = "TxtNodeDescription"
        Me.TxtNodeDescription.Size = New System.Drawing.Size(282, 22)
        Me.TxtNodeDescription.TabIndex = 6
        Me.MyToolTip.SetToolTip(Me.TxtNodeDescription, "Describe what this node does")
        '
        'LblFileName
        '
        Me.LblFileName.AutoSize = True
        Me.LblFileName.Location = New System.Drawing.Point(206, 29)
        Me.LblFileName.Name = "LblFileName"
        Me.LblFileName.Size = New System.Drawing.Size(84, 16)
        Me.LblFileName.TabIndex = 7
        Me.LblFileName.Text = "LblFileName"
        '
        'LblType
        '
        Me.LblType.AutoSize = True
        Me.LblType.Location = New System.Drawing.Point(206, 68)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(57, 16)
        Me.LblType.TabIndex = 8
        Me.LblType.Text = "LblType"
        '
        'LblBaseAddress
        '
        Me.LblBaseAddress.AutoSize = True
        Me.LblBaseAddress.Location = New System.Drawing.Point(206, 109)
        Me.LblBaseAddress.Name = "LblBaseAddress"
        Me.LblBaseAddress.Size = New System.Drawing.Size(108, 16)
        Me.LblBaseAddress.TabIndex = 9
        Me.LblBaseAddress.Text = "LblBaseAddress"
        '
        'ButSaveChanges
        '
        Me.ButSaveChanges.Location = New System.Drawing.Point(209, 231)
        Me.ButSaveChanges.Name = "ButSaveChanges"
        Me.ButSaveChanges.Size = New System.Drawing.Size(75, 23)
        Me.ButSaveChanges.TabIndex = 10
        Me.ButSaveChanges.Text = "Save"
        Me.MyToolTip.SetToolTip(Me.ButSaveChanges, "Will save changes and reload the values")
        Me.ButSaveChanges.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(85, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Save Changes"
        '
        'FrmNode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 315)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButSaveChanges)
        Me.Controls.Add(Me.LblBaseAddress)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.LblFileName)
        Me.Controls.Add(Me.TxtNodeDescription)
        Me.Controls.Add(Me.TxtNodeName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblEventBase)
        Me.Controls.Add(Me.LblNodeType)
        Me.Controls.Add(Me.LblDecription)
        Me.Controls.Add(Me.LblName)
        Me.Name = "FrmNode"
        Me.Text = "FrmNode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblName As Label
    Friend WithEvents LblDecription As Label
    Friend WithEvents LblNodeType As Label
    Friend WithEvents LblEventBase As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNodeName As TextBox
    Friend WithEvents TxtNodeDescription As TextBox
    Friend WithEvents LblFileName As Label
    Friend WithEvents LblType As Label
    Friend WithEvents LblBaseAddress As Label
    Friend WithEvents ButSaveChanges As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents MyToolTip As ToolTip
End Class
