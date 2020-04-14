<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OracleCPENew
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OracleCPENew))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.srcWFADO_Eastern1 = New AxSmartRumba.AxSmartRumbaControl()
        Me.srcWFADO_Western1 = New AxSmartRumba.AxSmartRumbaControl()
        Me.srcWFADO_Central = New AxSmartRumba.AxSmartRumbaControl()
        CType(Me.srcWFADO_Eastern1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.srcWFADO_Western1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.srcWFADO_Central, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "EASTERN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(370, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "WESTERN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 300)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "CENTRAL"
        '
        'srcWFADO_Eastern1
        '
        Me.srcWFADO_Eastern1.Enabled = True
        Me.srcWFADO_Eastern1.Location = New System.Drawing.Point(12, 25)
        Me.srcWFADO_Eastern1.Name = "srcWFADO_Eastern1"
        Me.srcWFADO_Eastern1.OcxState = CType(resources.GetObject("srcWFADO_Eastern1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.srcWFADO_Eastern1.Size = New System.Drawing.Size(295, 262)
        Me.srcWFADO_Eastern1.TabIndex = 6
        '
        'srcWFADO_Western1
        '
        Me.srcWFADO_Western1.Enabled = True
        Me.srcWFADO_Western1.Location = New System.Drawing.Point(363, 34)
        Me.srcWFADO_Western1.Name = "srcWFADO_Western1"
        Me.srcWFADO_Western1.OcxState = CType(resources.GetObject("srcWFADO_Western1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.srcWFADO_Western1.Size = New System.Drawing.Size(304, 253)
        Me.srcWFADO_Western1.TabIndex = 7
        '
        'srcWFADO_Central
        '
        Me.srcWFADO_Central.Enabled = True
        Me.srcWFADO_Central.Location = New System.Drawing.Point(12, 316)
        Me.srcWFADO_Central.Name = "srcWFADO_Central"
        Me.srcWFADO_Central.OcxState = CType(resources.GetObject("srcWFADO_Central.OcxState"), System.Windows.Forms.AxHost.State)
        Me.srcWFADO_Central.Size = New System.Drawing.Size(295, 234)
        Me.srcWFADO_Central.TabIndex = 8
        '
        'OracleCPENew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 557)
        Me.Controls.Add(Me.srcWFADO_Central)
        Me.Controls.Add(Me.srcWFADO_Western1)
        Me.Controls.Add(Me.srcWFADO_Eastern1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "OracleCPENew"
        Me.Text = "OracleCPENew"
        CType(Me.srcWFADO_Eastern1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.srcWFADO_Western1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.srcWFADO_Central, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents srcWFADO_Eastern1 As AxSmartRumba.AxSmartRumbaControl
    Friend WithEvents srcWFADO_Western1 As AxSmartRumba.AxSmartRumbaControl
    Friend WithEvents srcWFADO_Central As AxSmartRumba.AxSmartRumbaControl
End Class
