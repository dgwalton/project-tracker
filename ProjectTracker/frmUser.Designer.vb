<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.LastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FirstName = New System.Windows.Forms.TextBox()
        Me.cboCompany = New System.Windows.Forms.ComboBox()
        Me.User_Type = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MailtoCity = New System.Windows.Forms.TextBox()
        Me.MailtoAdd2 = New System.Windows.Forms.TextBox()
        Me.MailtoAdd1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.HomePhone = New System.Windows.Forms.MaskedTextBox()
        Me.WorkPhone = New System.Windows.Forms.MaskedTextBox()
        Me.MobilePhone = New System.Windows.Forms.MaskedTextBox()
        Me.MailToZip = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.MailToState = New ProjectTracker.StatePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkIsContractor = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 256)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(400, 42)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(194, 36)
        Me.OK_Button.TabIndex = 16
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(203, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(194, 36)
        Me.Cancel_Button.TabIndex = 17
        Me.Cancel_Button.Text = "Cancel"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.52096!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.47904!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Email, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtPassword, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtUsername, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LastName, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.FirstName, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboCompany, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.User_Type, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.chkIsContractor, 1, 7)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(171, 212)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(5, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 24)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Contractor"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(5, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 26)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Email"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Email
        '
        Me.Email.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Email.Location = New System.Drawing.Point(71, 136)
        Me.Email.MaxLength = 50
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(95, 20)
        Me.Email.TabIndex = 40
        Me.Email.WordWrap = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Location = New System.Drawing.Point(5, 159)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 27)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "User Type"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword
        '
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPassword.Location = New System.Drawing.Point(71, 110)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(95, 20)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.UseSystemPasswordChar = True
        Me.txtPassword.WordWrap = False
        '
        'txtUsername
        '
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsername.Location = New System.Drawing.Point(71, 84)
        Me.txtUsername.MaxLength = 50
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(95, 20)
        Me.txtUsername.TabIndex = 4
        Me.txtUsername.WordWrap = False
        '
        'LastName
        '
        Me.LastName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LastName.Location = New System.Drawing.Point(71, 31)
        Me.LastName.MaxLength = 50
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(95, 20)
        Me.LastName.TabIndex = 2
        Me.LastName.WordWrap = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(5, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(5, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 26)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(5, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 27)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Company"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(5, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 26)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Username"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(5, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 26)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Password"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FirstName
        '
        Me.FirstName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FirstName.Location = New System.Drawing.Point(71, 5)
        Me.FirstName.MaxLength = 50
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(95, 20)
        Me.FirstName.TabIndex = 1
        Me.FirstName.WordWrap = False
        '
        'cboCompany
        '
        Me.cboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(71, 57)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(95, 21)
        Me.cboCompany.Sorted = True
        Me.cboCompany.TabIndex = 3
        '
        'User_Type
        '
        Me.User_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.User_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.User_Type.Dock = System.Windows.Forms.DockStyle.Fill
        Me.User_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.User_Type.FormattingEnabled = True
        Me.User_Type.Items.AddRange(New Object() {"Administrator", "Customer", "Employee"})
        Me.User_Type.Location = New System.Drawing.Point(71, 162)
        Me.User_Type.Name = "User_Type"
        Me.User_Type.Size = New System.Drawing.Size(95, 21)
        Me.User_Type.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Location = New System.Drawing.Point(5, 185)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 26)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Mobile"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Location = New System.Drawing.Point(5, 159)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 26)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Work"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Location = New System.Drawing.Point(5, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 26)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Home"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Location = New System.Drawing.Point(5, 107)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 26)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Zip"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(5, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 27)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "State"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MailtoCity
        '
        Me.MailtoCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MailtoCity.Location = New System.Drawing.Point(66, 57)
        Me.MailtoCity.MaxLength = 50
        Me.MailtoCity.Name = "MailtoCity"
        Me.MailtoCity.Size = New System.Drawing.Size(115, 20)
        Me.MailtoCity.TabIndex = 9
        Me.MailtoCity.WordWrap = False
        '
        'MailtoAdd2
        '
        Me.MailtoAdd2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MailtoAdd2.Location = New System.Drawing.Point(66, 31)
        Me.MailtoAdd2.MaxLength = 50
        Me.MailtoAdd2.Name = "MailtoAdd2"
        Me.MailtoAdd2.Size = New System.Drawing.Size(115, 20)
        Me.MailtoAdd2.TabIndex = 7
        Me.MailtoAdd2.WordWrap = False
        '
        'MailtoAdd1
        '
        Me.MailtoAdd1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MailtoAdd1.Location = New System.Drawing.Point(66, 5)
        Me.MailtoAdd1.MaxLength = 50
        Me.MailtoAdd1.Name = "MailtoAdd1"
        Me.MailtoAdd1.Size = New System.Drawing.Size(115, 20)
        Me.MailtoAdd1.TabIndex = 6
        Me.MailtoAdd1.WordWrap = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(5, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 26)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Address 1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(5, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 26)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Address 2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(5, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 26)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "City"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HomePhone
        '
        Me.HomePhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HomePhone.Location = New System.Drawing.Point(66, 136)
        Me.HomePhone.Mask = "(999) 000-0000"
        Me.HomePhone.Name = "HomePhone"
        Me.HomePhone.Size = New System.Drawing.Size(115, 20)
        Me.HomePhone.TabIndex = 42
        '
        'WorkPhone
        '
        Me.WorkPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkPhone.Location = New System.Drawing.Point(66, 162)
        Me.WorkPhone.Mask = "(999) 000-0000"
        Me.WorkPhone.Name = "WorkPhone"
        Me.WorkPhone.Size = New System.Drawing.Size(115, 20)
        Me.WorkPhone.TabIndex = 43
        '
        'MobilePhone
        '
        Me.MobilePhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MobilePhone.Location = New System.Drawing.Point(66, 188)
        Me.MobilePhone.Mask = "(999) 000-0000"
        Me.MobilePhone.Name = "MobilePhone"
        Me.MobilePhone.Size = New System.Drawing.Size(115, 20)
        Me.MobilePhone.TabIndex = 44
        '
        'MailToZip
        '
        Me.MailToZip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MailToZip.Location = New System.Drawing.Point(66, 110)
        Me.MailToZip.Mask = "00000-9999"
        Me.MailToZip.Name = "MailToZip"
        Me.MailToZip.Size = New System.Drawing.Size(115, 20)
        Me.MailToZip.TabIndex = 45
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(177, 231)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Required Information"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.85214!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.14786!))
        Me.TableLayoutPanel3.Controls.Add(Me.MailToState, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.MailtoAdd1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.MailtoAdd2, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label18, 0, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.Label19, 0, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.MailtoCity, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label16, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.MailToZip, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.HomePhone, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.WorkPhone, 1, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.MobilePhone, 1, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.Padding = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.RowCount = 8
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(186, 212)
        Me.TableLayoutPanel3.TabIndex = 5
        '
        'MailToState
        '
        Me.MailToState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MailToState.Location = New System.Drawing.Point(66, 83)
        Me.MailToState.Name = "MailToState"
        Me.MailToState.Size = New System.Drawing.Size(115, 21)
        Me.MailToState.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox2.Location = New System.Drawing.Point(195, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 231)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact Information"
        '
        'chkIsContractor
        '
        Me.chkIsContractor.AutoSize = True
        Me.chkIsContractor.Location = New System.Drawing.Point(73, 191)
        Me.chkIsContractor.Margin = New System.Windows.Forms.Padding(5)
        Me.chkIsContractor.Name = "chkIsContractor"
        Me.chkIsContractor.Size = New System.Drawing.Size(15, 14)
        Me.chkIsContractor.TabIndex = 43
        Me.chkIsContractor.UseVisualStyleBackColor = True
        '
        'frmUser
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(400, 298)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit User Information"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MailtoCity As System.Windows.Forms.TextBox
    Friend WithEvents MailtoAdd2 As System.Windows.Forms.TextBox
    Friend WithEvents MailtoAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents LastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents FirstName As System.Windows.Forms.TextBox
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents User_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Email As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MailToState As ProjectTracker.StatePicker
    Friend WithEvents HomePhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents WorkPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MobilePhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MailToZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkIsContractor As System.Windows.Forms.CheckBox

End Class
