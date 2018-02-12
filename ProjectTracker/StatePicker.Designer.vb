<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Combo = New System.Windows.Forms.ComboBox
        Me.Label = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Combo
        '
        Me.Combo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Combo.FormattingEnabled = True
        Me.Combo.IntegralHeight = False
        Me.Combo.Location = New System.Drawing.Point(0, 0)
        Me.Combo.Name = "Combo"
        Me.Combo.Size = New System.Drawing.Size(46, 21)
        Me.Combo.TabIndex = 0
        '
        'Label
        '
        Me.Label.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label.Location = New System.Drawing.Point(46, 0)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(160, 21)
        Me.Label.TabIndex = 1
        Me.Label.Tag = ""
        Me.Label.Text = "Description"
        Me.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.Combo)
        Me.Name = "StatePicker"
        Me.Size = New System.Drawing.Size(206, 21)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Combo As System.Windows.Forms.ComboBox
    Friend WithEvents Label As System.Windows.Forms.Label

End Class
