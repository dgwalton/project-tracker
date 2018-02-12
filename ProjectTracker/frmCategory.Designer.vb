<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCategory))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Comments = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.Phone = New System.Windows.Forms.TextBox()
        Me.BillToZip = New System.Windows.Forms.TextBox()
        Me.BillToCity = New System.Windows.Forms.TextBox()
        Me.BillToAdd2 = New System.Windows.Forms.TextBox()
        Me.BillToAdd1 = New System.Windows.Forms.TextBox()
        Me.BillToName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CategoryName = New System.Windows.Forms.TextBox()
        Me.Company = New System.Windows.Forms.ComboBox()
        Me.BillToState = New ProjectTracker.StatePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(137, 267)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 12
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 13
        Me.Cancel_Button.Text = "Cancel"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.95131!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.04869!))
        Me.TableLayoutPanel2.Controls.Add(Me.Comments, 1, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Email, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Phone, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToZip, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToCity, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToAdd2, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToAdd1, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToName, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.CategoryName, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Company, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToState, 1, 6)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.RowCount = 11
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(283, 266)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Comments
        '
        Me.Comments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Comments.Location = New System.Drawing.Point(113, 235)
        Me.Comments.MaxLength = 50
        Me.Comments.Multiline = True
        Me.Comments.Name = "Comments"
        Me.Comments.Size = New System.Drawing.Size(165, 26)
        Me.Comments.TabIndex = 11
        '
        'Email
        '
        Me.Email.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Email.Location = New System.Drawing.Point(113, 212)
        Me.Email.MaxLength = 50
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(165, 20)
        Me.Email.TabIndex = 10
        '
        'Phone
        '
        Me.Phone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Phone.Location = New System.Drawing.Point(113, 189)
        Me.Phone.MaxLength = 50
        Me.Phone.Name = "Phone"
        Me.Phone.Size = New System.Drawing.Size(165, 20)
        Me.Phone.TabIndex = 9
        '
        'BillToZip
        '
        Me.BillToZip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToZip.Location = New System.Drawing.Point(113, 166)
        Me.BillToZip.MaxLength = 50
        Me.BillToZip.Name = "BillToZip"
        Me.BillToZip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.BillToZip.Size = New System.Drawing.Size(165, 20)
        Me.BillToZip.TabIndex = 8
        '
        'BillToCity
        '
        Me.BillToCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToCity.Location = New System.Drawing.Point(113, 120)
        Me.BillToCity.MaxLength = 50
        Me.BillToCity.Name = "BillToCity"
        Me.BillToCity.Size = New System.Drawing.Size(165, 20)
        Me.BillToCity.TabIndex = 6
        '
        'BillToAdd2
        '
        Me.BillToAdd2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToAdd2.Location = New System.Drawing.Point(113, 97)
        Me.BillToAdd2.MaxLength = 50
        Me.BillToAdd2.Name = "BillToAdd2"
        Me.BillToAdd2.Size = New System.Drawing.Size(165, 20)
        Me.BillToAdd2.TabIndex = 5
        '
        'BillToAdd1
        '
        Me.BillToAdd1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToAdd1.Location = New System.Drawing.Point(113, 74)
        Me.BillToAdd1.MaxLength = 50
        Me.BillToAdd1.Name = "BillToAdd1"
        Me.BillToAdd1.Size = New System.Drawing.Size(165, 20)
        Me.BillToAdd1.TabIndex = 4
        '
        'BillToName
        '
        Me.BillToName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToName.Location = New System.Drawing.Point(113, 51)
        Me.BillToName.MaxLength = 50
        Me.BillToName.Name = "BillToName"
        Me.BillToName.Size = New System.Drawing.Size(165, 20)
        Me.BillToName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project Title"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(5, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(5, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bill to Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(5, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Bill to Address 1"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(5, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Bill to Address 2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(5, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Bill to City"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(5, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Bill to State"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(5, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Bill to Zip"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(5, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 23)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Contact Phone"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(5, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 23)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Contact Email"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(5, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 32)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Comments"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CategoryName
        '
        Me.CategoryName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CategoryName.Location = New System.Drawing.Point(113, 5)
        Me.CategoryName.MaxLength = 50
        Me.CategoryName.Name = "CategoryName"
        Me.CategoryName.Size = New System.Drawing.Size(165, 20)
        Me.CategoryName.TabIndex = 1
        '
        'Company
        '
        Me.Company.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.Company.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Company.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Company.FormattingEnabled = True
        Me.Company.Location = New System.Drawing.Point(113, 28)
        Me.Company.Name = "Company"
        Me.Company.Size = New System.Drawing.Size(165, 21)
        Me.Company.TabIndex = 2
        '
        'BillToState
        '
        Me.BillToState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToState.Location = New System.Drawing.Point(113, 143)
        Me.BillToState.Name = "BillToState"
        Me.BillToState.Size = New System.Drawing.Size(165, 17)
        Me.BillToState.TabIndex = 12
        '
        'frmCategory
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(283, 298)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCategory"
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Project"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Comments As System.Windows.Forms.TextBox
    Friend WithEvents Email As System.Windows.Forms.TextBox
    Friend WithEvents Phone As System.Windows.Forms.TextBox
    Friend WithEvents BillToZip As System.Windows.Forms.TextBox
    Friend WithEvents BillToCity As System.Windows.Forms.TextBox
    Friend WithEvents BillToAdd2 As System.Windows.Forms.TextBox
    Friend WithEvents BillToAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents BillToName As System.Windows.Forms.TextBox
    Friend WithEvents CategoryName As System.Windows.Forms.TextBox
    Friend WithEvents Company As System.Windows.Forms.ComboBox
    Friend WithEvents BillToState As ProjectTracker.StatePicker

End Class
