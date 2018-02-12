<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob))
        Me.pnlOKCancel = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.pnlAdmin = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboCompany = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboApprUser = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboReqUser = New System.Windows.Forms.ComboBox()
        Me.dtpOpenedOn = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblClosedOn = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlQuote = New System.Windows.Forms.Panel()
        Me.txtQuotedCost = New System.Windows.Forms.TextBox()
        Me.txtQuotedHours = New System.Windows.Forms.TextBox()
        Me.rbQuoteCost = New System.Windows.Forms.RadioButton()
        Me.rbQuoteHours = New System.Windows.Forms.RadioButton()
        Me.pnlRevQuote = New System.Windows.Forms.Panel()
        Me.btnRejectClose = New System.Windows.Forms.Button()
        Me.btnRejectModify = New System.Windows.Forms.Button()
        Me.btnAcceptQuote = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlEmail = New System.Windows.Forms.Panel()
        Me.lvEmails = New ProjectTracker.EnhancedListView()
        Me.colEmailID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFrom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSubject = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colReceived = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.clbNotify = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtAccountingID = New System.Windows.Forms.TextBox()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.lblAccounting = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkQuote = New System.Windows.Forms.CheckBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbNotBillable = New System.Windows.Forms.RadioButton()
        Me.rbBillable = New System.Windows.Forms.RadioButton()
        Me.rbSplitBillable = New System.Windows.Forms.RadioButton()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboCatID = New System.Windows.Forms.ComboBox()
        Me.pnlOKCancel.SuspendLayout()
        Me.pnlAdmin.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnlQuote.SuspendLayout()
        Me.pnlRevQuote.SuspendLayout()
        Me.pnlEmail.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlOKCancel
        '
        Me.pnlOKCancel.ColumnCount = 3
        Me.pnlOKCancel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375.0!))
        Me.pnlOKCancel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.18727!))
        Me.pnlOKCancel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.81273!))
        Me.pnlOKCancel.Controls.Add(Me.Cancel_Button, 2, 0)
        Me.pnlOKCancel.Controls.Add(Me.OK_Button, 1, 0)
        Me.pnlOKCancel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlOKCancel.Location = New System.Drawing.Point(5, 640)
        Me.pnlOKCancel.Name = "pnlOKCancel"
        Me.pnlOKCancel.RowCount = 1
        Me.pnlOKCancel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlOKCancel.Size = New System.Drawing.Size(544, 29)
        Me.pnlOKCancel.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(467, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(68, 23)
        Me.Cancel_Button.TabIndex = 19
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(379, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 18
        Me.OK_Button.Text = "OK"
        '
        'pnlAdmin
        '
        Me.pnlAdmin.Controls.Add(Me.TableLayoutPanel2)
        Me.pnlAdmin.Controls.Add(Me.Label9)
        Me.pnlAdmin.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAdmin.Location = New System.Drawing.Point(5, 515)
        Me.pnlAdmin.Name = "pnlAdmin"
        Me.pnlAdmin.Size = New System.Drawing.Size(544, 125)
        Me.pnlAdmin.TabIndex = 47
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.12583!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.87417!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 244.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cboCompany, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cboApprUser, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboStatus, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboReqUser, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpOpenedOn, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblClosedOn, 3, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(544, 107)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'cboCompany
        '
        Me.cboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(74, 3)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(152, 21)
        Me.cboCompany.Sorted = True
        Me.cboCompany.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 29)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Approved By"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 26)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Customer"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 26)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Requested By"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboApprUser
        '
        Me.cboApprUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboApprUser.FormattingEnabled = True
        Me.cboApprUser.Location = New System.Drawing.Point(74, 81)
        Me.cboApprUser.Name = "cboApprUser"
        Me.cboApprUser.Size = New System.Drawing.Size(152, 21)
        Me.cboApprUser.Sorted = True
        Me.cboApprUser.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 26)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Awaiting Approval", "Awaiting Quote", "Complete", "On Hold", "Open"})
        Me.cboStatus.Location = New System.Drawing.Point(74, 29)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(152, 21)
        Me.cboStatus.Sorted = True
        Me.cboStatus.TabIndex = 15
        '
        'cboReqUser
        '
        Me.cboReqUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboReqUser.FormattingEnabled = True
        Me.cboReqUser.Location = New System.Drawing.Point(74, 55)
        Me.cboReqUser.Name = "cboReqUser"
        Me.cboReqUser.Size = New System.Drawing.Size(152, 21)
        Me.cboReqUser.Sorted = True
        Me.cboReqUser.TabIndex = 16
        '
        'dtpOpenedOn
        '
        Me.dtpOpenedOn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpOpenedOn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOpenedOn.Location = New System.Drawing.Point(302, 3)
        Me.dtpOpenedOn.Name = "dtpOpenedOn"
        Me.dtpOpenedOn.Size = New System.Drawing.Size(239, 20)
        Me.dtpOpenedOn.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(232, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 23)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Opened On"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(232, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 23)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Closed On"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClosedOn
        '
        Me.lblClosedOn.Location = New System.Drawing.Point(302, 26)
        Me.lblClosedOn.Name = "lblClosedOn"
        Me.lblClosedOn.Size = New System.Drawing.Size(100, 23)
        Me.lblClosedOn.TabIndex = 22
        Me.lblClosedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(544, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Administrator Settings"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlQuote
        '
        Me.pnlQuote.Controls.Add(Me.txtQuotedCost)
        Me.pnlQuote.Controls.Add(Me.txtQuotedHours)
        Me.pnlQuote.Controls.Add(Me.rbQuoteCost)
        Me.pnlQuote.Controls.Add(Me.rbQuoteHours)
        Me.pnlQuote.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlQuote.Location = New System.Drawing.Point(5, 435)
        Me.pnlQuote.Name = "pnlQuote"
        Me.pnlQuote.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlQuote.Size = New System.Drawing.Size(544, 28)
        Me.pnlQuote.TabIndex = 48
        '
        'txtQuotedCost
        '
        Me.txtQuotedCost.Enabled = False
        Me.txtQuotedCost.Location = New System.Drawing.Point(363, 5)
        Me.txtQuotedCost.MaxLength = 10
        Me.txtQuotedCost.Name = "txtQuotedCost"
        Me.txtQuotedCost.Size = New System.Drawing.Size(53, 20)
        Me.txtQuotedCost.TabIndex = 12
        '
        'txtQuotedHours
        '
        Me.txtQuotedHours.Location = New System.Drawing.Point(114, 4)
        Me.txtQuotedHours.MaxLength = 10
        Me.txtQuotedHours.Name = "txtQuotedHours"
        Me.txtQuotedHours.Size = New System.Drawing.Size(52, 20)
        Me.txtQuotedHours.TabIndex = 11
        '
        'rbQuoteCost
        '
        Me.rbQuoteCost.Location = New System.Drawing.Point(279, 6)
        Me.rbQuoteCost.Name = "rbQuoteCost"
        Me.rbQuoteCost.Size = New System.Drawing.Size(95, 20)
        Me.rbQuoteCost.TabIndex = 9
        Me.rbQuoteCost.Text = "Quote Cost $"
        Me.rbQuoteCost.UseVisualStyleBackColor = True
        '
        'rbQuoteHours
        '
        Me.rbQuoteHours.Checked = True
        Me.rbQuoteHours.Location = New System.Drawing.Point(24, 4)
        Me.rbQuoteHours.Name = "rbQuoteHours"
        Me.rbQuoteHours.Size = New System.Drawing.Size(92, 20)
        Me.rbQuoteHours.TabIndex = 7
        Me.rbQuoteHours.TabStop = True
        Me.rbQuoteHours.Text = "Quote Hours"
        Me.rbQuoteHours.UseVisualStyleBackColor = True
        '
        'pnlRevQuote
        '
        Me.pnlRevQuote.Controls.Add(Me.btnRejectClose)
        Me.pnlRevQuote.Controls.Add(Me.btnRejectModify)
        Me.pnlRevQuote.Controls.Add(Me.btnAcceptQuote)
        Me.pnlRevQuote.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlRevQuote.Location = New System.Drawing.Point(5, 463)
        Me.pnlRevQuote.Name = "pnlRevQuote"
        Me.pnlRevQuote.Size = New System.Drawing.Size(544, 52)
        Me.pnlRevQuote.TabIndex = 49
        '
        'btnRejectClose
        '
        Me.btnRejectClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRejectClose.Location = New System.Drawing.Point(177, 0)
        Me.btnRejectClose.Name = "btnRejectClose"
        Me.btnRejectClose.Size = New System.Drawing.Size(191, 52)
        Me.btnRejectClose.TabIndex = 12
        Me.btnRejectClose.Text = "Reject and Close"
        Me.btnRejectClose.UseVisualStyleBackColor = True
        '
        'btnRejectModify
        '
        Me.btnRejectModify.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnRejectModify.Enabled = False
        Me.btnRejectModify.Location = New System.Drawing.Point(368, 0)
        Me.btnRejectModify.Name = "btnRejectModify"
        Me.btnRejectModify.Size = New System.Drawing.Size(176, 52)
        Me.btnRejectModify.TabIndex = 13
        Me.btnRejectModify.Text = "Reject and Modify"
        Me.btnRejectModify.UseVisualStyleBackColor = True
        '
        'btnAcceptQuote
        '
        Me.btnAcceptQuote.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAcceptQuote.Location = New System.Drawing.Point(0, 0)
        Me.btnAcceptQuote.Name = "btnAcceptQuote"
        Me.btnAcceptQuote.Size = New System.Drawing.Size(177, 52)
        Me.btnAcceptQuote.TabIndex = 11
        Me.btnAcceptQuote.Text = "Accept Quote"
        Me.btnAcceptQuote.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "clip.bmp")
        '
        'pnlEmail
        '
        Me.pnlEmail.Controls.Add(Me.lvEmails)
        Me.pnlEmail.Controls.Add(Me.Label11)
        Me.pnlEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmail.Location = New System.Drawing.Point(5, 262)
        Me.pnlEmail.Name = "pnlEmail"
        Me.pnlEmail.Size = New System.Drawing.Size(544, 173)
        Me.pnlEmail.TabIndex = 51
        '
        'lvEmails
        '
        Me.lvEmails.AllowDrop = True
        Me.lvEmails.BlanksFirst = False
        Me.lvEmails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colEmailID, Me.colFrom, Me.colSubject, Me.colReceived})
        Me.lvEmails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvEmails.FillColumn = 0
        Me.lvEmails.FullRowSelect = True
        Me.lvEmails.HideSelection = False
        Me.lvEmails.Location = New System.Drawing.Point(0, 21)
        Me.lvEmails.Name = "lvEmails"
        Me.lvEmails.Size = New System.Drawing.Size(544, 152)
        Me.lvEmails.SmallImageList = Me.ImageList1
        Me.lvEmails.SortByTag = False
        Me.lvEmails.SortColumn = 5
        Me.lvEmails.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvEmails.SortOnColumnClick = True
        Me.lvEmails.TabIndex = 47
        Me.lvEmails.UseCompatibleStateImageBehavior = False
        Me.lvEmails.View = System.Windows.Forms.View.Details
        '
        'colEmailID
        '
        Me.colEmailID.Text = "ID"
        Me.colEmailID.Width = 49
        '
        'colFrom
        '
        Me.colFrom.Text = "From"
        Me.colFrom.Width = 157
        '
        'colSubject
        '
        Me.colSubject.Text = "Subject"
        Me.colSubject.Width = 247
        '
        'colReceived
        '
        Me.colReceived.Text = "Received"
        Me.colReceived.Width = 87
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(544, 21)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Related Emails"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(324, 47)
        Me.txtNotes.MaxLength = 255
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(214, 199)
        Me.txtNotes.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(321, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Other Notes"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(37, 5)
        Me.txtDescr.MaxLength = 255
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(326, 20)
        Me.txtDescr.TabIndex = 5
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.clbNotify)
        Me.pnlMain.Controls.Add(Me.GroupBox2)
        Me.pnlMain.Controls.Add(Me.GroupBox1)
        Me.pnlMain.Controls.Add(Me.cboCategory)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.txtDescr)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.Label14)
        Me.pnlMain.Controls.Add(Me.txtNotes)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.cboCatID)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(5, 5)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlMain.Size = New System.Drawing.Size(544, 257)
        Me.pnlMain.TabIndex = 48
        '
        'clbNotify
        '
        Me.clbNotify.CheckOnClick = True
        Me.clbNotify.FormattingEnabled = True
        Me.clbNotify.Location = New System.Drawing.Point(189, 47)
        Me.clbNotify.Name = "clbNotify"
        Me.clbNotify.Size = New System.Drawing.Size(129, 199)
        Me.clbNotify.TabIndex = 53
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtAccountingID)
        Me.GroupBox2.Controls.Add(Me.cboPriority)
        Me.GroupBox2.Controls.Add(Me.lblAccounting)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.chkQuote)
        Me.GroupBox2.Controls.Add(Me.dtpEndDate)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(178, 168)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'txtAccountingID
        '
        Me.txtAccountingID.Location = New System.Drawing.Point(74, 13)
        Me.txtAccountingID.Name = "txtAccountingID"
        Me.txtAccountingID.Size = New System.Drawing.Size(98, 20)
        Me.txtAccountingID.TabIndex = 52
        '
        'cboPriority
        '
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboPriority.Location = New System.Drawing.Point(74, 39)
        Me.cboPriority.MaxDropDownItems = 10
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(98, 21)
        Me.cboPriority.TabIndex = 42
        '
        'lblAccounting
        '
        Me.lblAccounting.AutoSize = True
        Me.lblAccounting.Location = New System.Drawing.Point(6, 16)
        Me.lblAccounting.Name = "lblAccounting"
        Me.lblAccounting.Size = New System.Drawing.Size(68, 13)
        Me.lblAccounting.TabIndex = 51
        Me.lblAccounting.Text = "Accounting#"
        Me.lblAccounting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(14, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Priority"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkQuote
        '
        Me.chkQuote.Checked = True
        Me.chkQuote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkQuote.Location = New System.Drawing.Point(67, 145)
        Me.chkQuote.Name = "chkQuote"
        Me.chkQuote.Size = New System.Drawing.Size(105, 17)
        Me.chkQuote.TabIndex = 3
        Me.chkQuote.Text = "Request Quote"
        Me.chkQuote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkQuote.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(74, 68)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(98, 20)
        Me.dtpEndDate.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 20)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Finish By"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbNotBillable)
        Me.GroupBox1.Controls.Add(Me.rbBillable)
        Me.GroupBox1.Controls.Add(Me.rbSplitBillable)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(177, 40)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Billable"
        '
        'rbNotBillable
        '
        Me.rbNotBillable.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbNotBillable.AutoSize = True
        Me.rbNotBillable.Checked = True
        Me.rbNotBillable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbNotBillable.Location = New System.Drawing.Point(53, 16)
        Me.rbNotBillable.Name = "rbNotBillable"
        Me.rbNotBillable.Size = New System.Drawing.Size(84, 21)
        Me.rbNotBillable.TabIndex = 1
        Me.rbNotBillable.TabStop = True
        Me.rbNotBillable.Text = "Not Billable"
        Me.rbNotBillable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbNotBillable.UseVisualStyleBackColor = True
        '
        'rbBillable
        '
        Me.rbBillable.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbBillable.AutoSize = True
        Me.rbBillable.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbBillable.Location = New System.Drawing.Point(3, 16)
        Me.rbBillable.Name = "rbBillable"
        Me.rbBillable.Size = New System.Drawing.Size(50, 21)
        Me.rbBillable.TabIndex = 0
        Me.rbBillable.Text = "Billable"
        Me.rbBillable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbBillable.UseVisualStyleBackColor = True
        '
        'rbSplitBillable
        '
        Me.rbSplitBillable.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbSplitBillable.AutoSize = True
        Me.rbSplitBillable.Dock = System.Windows.Forms.DockStyle.Right
        Me.rbSplitBillable.Location = New System.Drawing.Point(137, 16)
        Me.rbSplitBillable.Name = "rbSplitBillable"
        Me.rbSplitBillable.Size = New System.Drawing.Size(37, 21)
        Me.rbSplitBillable.TabIndex = 2
        Me.rbSplitBillable.Text = "Split"
        Me.rbSplitBillable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbSplitBillable.UseVisualStyleBackColor = True
        '
        'cboCategory
        '
        Me.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCategory.DropDownWidth = 200
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(417, 6)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(120, 21)
        Me.cboCategory.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(360, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 21)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Project"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 20)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Title"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(188, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Notify These Users"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCatID
        '
        Me.cboCatID.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cboCatID.FormattingEnabled = True
        Me.cboCatID.Location = New System.Drawing.Point(444, 6)
        Me.cboCatID.Name = "cboCatID"
        Me.cboCatID.Size = New System.Drawing.Size(32, 21)
        Me.cboCatID.TabIndex = 45
        Me.cboCatID.Visible = False
        '
        'frmJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(554, 674)
        Me.Controls.Add(Me.pnlEmail)
        Me.Controls.Add(Me.pnlQuote)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlRevQuote)
        Me.Controls.Add(Me.pnlAdmin)
        Me.Controls.Add(Me.pnlOKCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Task"
        Me.pnlOKCancel.ResumeLayout(False)
        Me.pnlAdmin.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnlQuote.ResumeLayout(False)
        Me.pnlQuote.PerformLayout()
        Me.pnlRevQuote.ResumeLayout(False)
        Me.pnlEmail.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlOKCancel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents pnlAdmin As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboApprUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboReqUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlQuote As System.Windows.Forms.Panel
    Friend WithEvents rbQuoteCost As System.Windows.Forms.RadioButton
    Friend WithEvents rbQuoteHours As System.Windows.Forms.RadioButton
    Friend WithEvents pnlRevQuote As System.Windows.Forms.Panel
    Friend WithEvents btnRejectModify As System.Windows.Forms.Button
    Friend WithEvents btnRejectClose As System.Windows.Forms.Button
    Friend WithEvents btnAcceptQuote As System.Windows.Forms.Button
    Friend WithEvents txtQuotedCost As System.Windows.Forms.TextBox
    Friend WithEvents txtQuotedHours As System.Windows.Forms.TextBox
    Friend WithEvents lvEmails As ProjectTracker.EnhancedListView
    Friend WithEvents colEmailID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFrom As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSubject As System.Windows.Forms.ColumnHeader
    Friend WithEvents colReceived As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dtpOpenedOn As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblClosedOn As System.Windows.Forms.Label
    Friend WithEvents pnlEmail As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbSplitBillable As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotBillable As System.Windows.Forms.RadioButton
    Friend WithEvents rbBillable As System.Windows.Forms.RadioButton
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkQuote As System.Windows.Forms.CheckBox
    Friend WithEvents cboCatID As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAccountingID As System.Windows.Forms.TextBox
    Friend WithEvents lblAccounting As System.Windows.Forms.Label
    Friend WithEvents clbNotify As System.Windows.Forms.CheckedListBox

End Class
