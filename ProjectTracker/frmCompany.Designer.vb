<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompany
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 1")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 10")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 11")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 12")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 13")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 14")
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 15")
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 2")
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 3")
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 4")
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 5")
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 6")
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 7")
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 8")
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("user 9")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompany))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BillToAdd4 = New System.Windows.Forms.TextBox()
        Me.BillToAdd3 = New System.Windows.Forms.TextBox()
        Me.BillToAdd2 = New System.Windows.Forms.TextBox()
        Me.BillToAdd1 = New System.Windows.Forms.TextBox()
        Me.BillToName = New System.Windows.Forms.TextBox()
        Me.ContactPhone = New System.Windows.Forms.TextBox()
        Me.ContactEmail = New System.Windows.Forms.TextBox()
        Me.ContactName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BillToCountry = New System.Windows.Forms.TextBox()
        Me.BillToCity = New System.Windows.Forms.TextBox()
        Me.BillToZip = New System.Windows.Forms.TextBox()
        Me.BillToPhone = New System.Windows.Forms.TextBox()
        Me.Company_Name = New System.Windows.Forms.TextBox()
        Me.BillToState = New ProjectTracker.StatePicker()
        Me.lvAllowedUsers = New System.Windows.Forms.ListView()
        Me.colUsername = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFirstName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLastName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCompany = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUserType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLastLogin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnNewUser = New System.Windows.Forms.Button()
        Me.btnEditUser = New System.Windows.Forms.Button()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 565)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(369, 49)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(178, 43)
        Me.OK_Button.TabIndex = 18
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(187, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(179, 43)
        Me.Cancel_Button.TabIndex = 19
        Me.Cancel_Button.Text = "Cancel"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.60825!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.39175!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 0, 25)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 0, 23)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 0, 22)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 0, 21)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 0, 20)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 19)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToAdd4, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToAdd3, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToAdd2, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToAdd1, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToName, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.ContactPhone, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ContactEmail, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ContactName, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToCountry, 1, 19)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToCity, 1, 20)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToZip, 1, 22)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToPhone, 1, 23)
        Me.TableLayoutPanel2.Controls.Add(Me.Company_Name, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BillToState, 1, 21)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(5, 5)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.RowCount = 26
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(382, 387)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Location = New System.Drawing.Point(5, 367)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(102, 18)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "Allowed Users "
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Location = New System.Drawing.Point(5, 341)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(102, 26)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Bill To Phone"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Location = New System.Drawing.Point(5, 315)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 26)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Bill To Zip"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Location = New System.Drawing.Point(5, 288)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 27)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Bill To State"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Location = New System.Drawing.Point(5, 262)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 26)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Bill To City"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(5, 236)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 26)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Bill To Country"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BillToAdd4
        '
        Me.BillToAdd4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToAdd4.Location = New System.Drawing.Point(113, 213)
        Me.BillToAdd4.MaxLength = 50
        Me.BillToAdd4.Name = "BillToAdd4"
        Me.BillToAdd4.Size = New System.Drawing.Size(264, 20)
        Me.BillToAdd4.TabIndex = 9
        '
        'BillToAdd3
        '
        Me.BillToAdd3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToAdd3.Location = New System.Drawing.Point(113, 187)
        Me.BillToAdd3.MaxLength = 50
        Me.BillToAdd3.Name = "BillToAdd3"
        Me.BillToAdd3.Size = New System.Drawing.Size(264, 20)
        Me.BillToAdd3.TabIndex = 8
        '
        'BillToAdd2
        '
        Me.BillToAdd2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToAdd2.Location = New System.Drawing.Point(113, 161)
        Me.BillToAdd2.MaxLength = 50
        Me.BillToAdd2.Name = "BillToAdd2"
        Me.BillToAdd2.Size = New System.Drawing.Size(264, 20)
        Me.BillToAdd2.TabIndex = 7
        '
        'BillToAdd1
        '
        Me.BillToAdd1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToAdd1.Location = New System.Drawing.Point(113, 135)
        Me.BillToAdd1.MaxLength = 50
        Me.BillToAdd1.Name = "BillToAdd1"
        Me.BillToAdd1.Size = New System.Drawing.Size(264, 20)
        Me.BillToAdd1.TabIndex = 6
        '
        'BillToName
        '
        Me.BillToName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToName.Location = New System.Drawing.Point(113, 109)
        Me.BillToName.MaxLength = 50
        Me.BillToName.Name = "BillToName"
        Me.BillToName.Size = New System.Drawing.Size(264, 20)
        Me.BillToName.TabIndex = 5
        '
        'ContactPhone
        '
        Me.ContactPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContactPhone.Location = New System.Drawing.Point(113, 83)
        Me.ContactPhone.MaxLength = 50
        Me.ContactPhone.Name = "ContactPhone"
        Me.ContactPhone.Size = New System.Drawing.Size(264, 20)
        Me.ContactPhone.TabIndex = 4
        '
        'ContactEmail
        '
        Me.ContactEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContactEmail.Location = New System.Drawing.Point(113, 57)
        Me.ContactEmail.MaxLength = 50
        Me.ContactEmail.Name = "ContactEmail"
        Me.ContactEmail.Size = New System.Drawing.Size(264, 20)
        Me.ContactEmail.TabIndex = 3
        '
        'ContactName
        '
        Me.ContactName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContactName.Location = New System.Drawing.Point(113, 31)
        Me.ContactName.MaxLength = 50
        Me.ContactName.Name = "ContactName"
        Me.ContactName.Size = New System.Drawing.Size(264, 20)
        Me.ContactName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(5, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(5, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 26)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Contact Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(5, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 26)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Contact Email"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(5, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 26)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Contact Phone"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(5, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 26)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Bill To Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(5, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 26)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Bill To Address 1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(5, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 26)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Bill To Address 2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(5, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 26)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Bill To Address 3"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(5, 210)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 26)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Bill To Address 4"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BillToCountry
        '
        Me.BillToCountry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToCountry.Location = New System.Drawing.Point(113, 239)
        Me.BillToCountry.MaxLength = 50
        Me.BillToCountry.Name = "BillToCountry"
        Me.BillToCountry.Size = New System.Drawing.Size(264, 20)
        Me.BillToCountry.TabIndex = 10
        '
        'BillToCity
        '
        Me.BillToCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToCity.Location = New System.Drawing.Point(113, 265)
        Me.BillToCity.MaxLength = 50
        Me.BillToCity.Name = "BillToCity"
        Me.BillToCity.Size = New System.Drawing.Size(264, 20)
        Me.BillToCity.TabIndex = 11
        '
        'BillToZip
        '
        Me.BillToZip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToZip.Location = New System.Drawing.Point(113, 318)
        Me.BillToZip.MaxLength = 50
        Me.BillToZip.Name = "BillToZip"
        Me.BillToZip.Size = New System.Drawing.Size(264, 20)
        Me.BillToZip.TabIndex = 13
        '
        'BillToPhone
        '
        Me.BillToPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToPhone.Location = New System.Drawing.Point(113, 344)
        Me.BillToPhone.MaxLength = 50
        Me.BillToPhone.Name = "BillToPhone"
        Me.BillToPhone.Size = New System.Drawing.Size(264, 20)
        Me.BillToPhone.TabIndex = 14
        '
        'Company_Name
        '
        Me.Company_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Company_Name.Location = New System.Drawing.Point(113, 5)
        Me.Company_Name.MaxLength = 50
        Me.Company_Name.Name = "Company_Name"
        Me.Company_Name.Size = New System.Drawing.Size(264, 20)
        Me.Company_Name.TabIndex = 1
        '
        'BillToState
        '
        Me.BillToState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BillToState.Location = New System.Drawing.Point(113, 291)
        Me.BillToState.Name = "BillToState"
        Me.BillToState.Size = New System.Drawing.Size(264, 21)
        Me.BillToState.TabIndex = 40
        '
        'lvAllowedUsers
        '
        Me.lvAllowedUsers.CheckBoxes = True
        Me.lvAllowedUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colUsername, Me.colFirstName, Me.colLastName, Me.colCompany, Me.colUserType, Me.colLastLogin})
        Me.lvAllowedUsers.Dock = System.Windows.Forms.DockStyle.Top
        Me.lvAllowedUsers.FullRowSelect = True
        Me.lvAllowedUsers.HideSelection = False
        ListViewItem1.Checked = True
        ListViewItem1.StateImageIndex = 1
        ListViewItem2.StateImageIndex = 0
        ListViewItem3.StateImageIndex = 0
        ListViewItem4.StateImageIndex = 0
        ListViewItem5.StateImageIndex = 0
        ListViewItem6.StateImageIndex = 0
        ListViewItem7.StateImageIndex = 0
        ListViewItem8.StateImageIndex = 0
        ListViewItem9.Checked = True
        ListViewItem9.StateImageIndex = 1
        ListViewItem10.StateImageIndex = 0
        ListViewItem11.StateImageIndex = 0
        ListViewItem12.StateImageIndex = 0
        ListViewItem13.StateImageIndex = 0
        ListViewItem14.StateImageIndex = 0
        ListViewItem15.StateImageIndex = 0
        Me.lvAllowedUsers.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15})
        Me.lvAllowedUsers.Location = New System.Drawing.Point(5, 392)
        Me.lvAllowedUsers.MultiSelect = False
        Me.lvAllowedUsers.Name = "lvAllowedUsers"
        Me.lvAllowedUsers.Size = New System.Drawing.Size(382, 136)
        Me.lvAllowedUsers.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvAllowedUsers.TabIndex = 15
        Me.lvAllowedUsers.UseCompatibleStateImageBehavior = False
        Me.lvAllowedUsers.View = System.Windows.Forms.View.Details
        '
        'colUsername
        '
        Me.colUsername.Text = "Username"
        Me.colUsername.Width = 131
        '
        'colFirstName
        '
        Me.colFirstName.Text = "First Name"
        Me.colFirstName.Width = 74
        '
        'colLastName
        '
        Me.colLastName.Text = "Last Name"
        Me.colLastName.Width = 80
        '
        'colCompany
        '
        Me.colCompany.Text = "Customer"
        Me.colCompany.Width = 76
        '
        'colUserType
        '
        Me.colUserType.Text = "Type"
        Me.colUserType.Width = 0
        '
        'colLastLogin
        '
        Me.colLastLogin.Text = "Last Login"
        '
        'btnNewUser
        '
        Me.btnNewUser.Enabled = False
        Me.btnNewUser.Location = New System.Drawing.Point(5, 538)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(71, 22)
        Me.btnNewUser.TabIndex = 16
        Me.btnNewUser.Text = "New User"
        Me.btnNewUser.UseVisualStyleBackColor = True
        '
        'btnEditUser
        '
        Me.btnEditUser.Enabled = False
        Me.btnEditUser.Location = New System.Drawing.Point(77, 538)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(71, 22)
        Me.btnEditUser.TabIndex = 17
        Me.btnEditUser.Text = "Edit User"
        Me.btnEditUser.UseVisualStyleBackColor = True
        '
        'frmCompany
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(392, 620)
        Me.Controls.Add(Me.lvAllowedUsers)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnEditUser)
        Me.Controls.Add(Me.btnNewUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompany"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Customer Information"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BillToAdd4 As System.Windows.Forms.TextBox
    Friend WithEvents BillToAdd3 As System.Windows.Forms.TextBox
    Friend WithEvents BillToAdd2 As System.Windows.Forms.TextBox
    Friend WithEvents BillToAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents BillToName As System.Windows.Forms.TextBox
    Friend WithEvents ContactPhone As System.Windows.Forms.TextBox
    Friend WithEvents ContactEmail As System.Windows.Forms.TextBox
    Friend WithEvents ContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Company_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BillToCountry As System.Windows.Forms.TextBox
    Friend WithEvents BillToCity As System.Windows.Forms.TextBox
    Friend WithEvents BillToZip As System.Windows.Forms.TextBox
    Friend WithEvents BillToPhone As System.Windows.Forms.TextBox
    Friend WithEvents lvAllowedUsers As System.Windows.Forms.ListView
    Friend WithEvents colLastName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFirstName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUsername As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCompany As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnNewUser As System.Windows.Forms.Button
    Friend WithEvents btnEditUser As System.Windows.Forms.Button
    Friend WithEvents colUserType As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillToState As ProjectTracker.StatePicker
    Friend WithEvents colLastLogin As System.Windows.Forms.ColumnHeader

End Class
