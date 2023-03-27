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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNodeName = New System.Windows.Forms.TextBox()
        Me.TxtNodeDescription = New System.Windows.Forms.TextBox()
        Me.LblFileName = New System.Windows.Forms.Label()
        Me.LblNodeTYpe = New System.Windows.Forms.Label()
        Me.LblBaseAddress = New System.Windows.Forms.Label()
        Me.ButSaveChanges = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Node Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Node Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(105, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Node Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(88, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Base Address"
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
        '
        'TxtNodeDescription
        '
        Me.TxtNodeDescription.Location = New System.Drawing.Point(209, 188)
        Me.TxtNodeDescription.Name = "TxtNodeDescription"
        Me.TxtNodeDescription.Size = New System.Drawing.Size(282, 22)
        Me.TxtNodeDescription.TabIndex = 6
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
        'LblNodeTYpe
        '
        Me.LblNodeTYpe.AutoSize = True
        Me.LblNodeTYpe.Location = New System.Drawing.Point(206, 68)
        Me.LblNodeTYpe.Name = "LblNodeTYpe"
        Me.LblNodeTYpe.Size = New System.Drawing.Size(91, 16)
        Me.LblNodeTYpe.TabIndex = 8
        Me.LblNodeTYpe.Text = "LblNodeType"
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
        Me.ButSaveChanges.Location = New System.Drawing.Point(209, 259)
        Me.ButSaveChanges.Name = "ButSaveChanges"
        Me.ButSaveChanges.Size = New System.Drawing.Size(75, 23)
        Me.ButSaveChanges.TabIndex = 10
        Me.ButSaveChanges.Text = "Save"
        Me.ButSaveChanges.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(85, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Save Changes"
        '
        'FrmNode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButSaveChanges)
        Me.Controls.Add(Me.LblBaseAddress)
        Me.Controls.Add(Me.LblNodeTYpe)
        Me.Controls.Add(Me.LblFileName)
        Me.Controls.Add(Me.TxtNodeDescription)
        Me.Controls.Add(Me.TxtNodeName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmNode"
        Me.Text = "SegmentID: Node ID"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNodeName As TextBox
    Friend WithEvents TxtNodeDescription As TextBox
    Friend WithEvents LblFileName As Label
    Friend WithEvents LblNodeTYpe As Label
    Friend WithEvents LblBaseAddress As Label
    Friend WithEvents ButSaveChanges As Button
    Friend WithEvents Label6 As Label
End Class
