<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Show Details")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Daily Report", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Show Details")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Task Report", New System.Windows.Forms.TreeNode() {TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Show Details")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Project Report", New System.Windows.Forms.TreeNode() {TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Show Details")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Report", New System.Windows.Forms.TreeNode() {TreeNode7})
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.btnNewCo = New System.Windows.Forms.Button()
        Me.btnEditCo = New System.Windows.Forms.Button()
        Me.lvCompanies = New ProjectTracker.EnhancedListView()
        Me.ColCompany_Company = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkShowAllCat = New System.Windows.Forms.CheckBox()
        Me.btnEditCat = New System.Windows.Forms.Button()
        Me.btnNewCat = New System.Windows.Forms.Button()
        Me.lvCategories = New ProjectTracker.EnhancedListView()
        Me.ColCategory_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCategory_Company = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clbStatus = New System.Windows.Forms.CheckedListBox()
        Me.btnViewJob = New System.Windows.Forms.Button()
        Me.btnReopenJob = New System.Windows.Forms.Button()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.ilStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCloseJob = New System.Windows.Forms.Button()
        Me.btnChangeJob = New System.Windows.Forms.Button()
        Me.btnEditJob = New System.Windows.Forms.Button()
        Me.btnNewJob = New System.Windows.Forms.Button()
        Me.btnRevQuote = New System.Windows.Forms.Button()
        Me.btnQuote = New System.Windows.Forms.Button()
        Me.btnAddRecord = New System.Windows.Forms.Button()
        Me.lvJobs = New ProjectTracker.EnhancedListView()
        Me.ColJobs_Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColJobs_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColJobs_Priority = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColJobs_Billing = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColJobs_Company = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColJobs_Category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColJobs_AccountingID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlPrintOptions = New System.Windows.Forms.Panel()
        Me.tvReport = New System.Windows.Forms.TreeView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnHideOptions = New System.Windows.Forms.Button()
        Me.btnGenReport = New System.Windows.Forms.Button()
        Me.pnlEditRecord = New System.Windows.Forms.Panel()
        Me.txtWorkPerf = New System.Windows.Forms.TextBox()
        Me.flpEditRec = New System.Windows.Forms.FlowLayoutPanel()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.cboStartTime = New System.Windows.Forms.ComboBox()
        Me.cboStopTime = New System.Windows.Forms.ComboBox()
        Me.cboTimeWorked = New System.Windows.Forms.ComboBox()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblJobDescr = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelRec = New System.Windows.Forms.Button()
        Me.lvRecords = New ProjectTracker.EnhancedListView()
        Me.ColDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColEmployee = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColStart = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColStop = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColHours = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBillHours = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCompany = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCategory = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColJob = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColWorkDescr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpLogDateBegin = New System.Windows.Forms.DateTimePicker()
        Me.dtpLogDateEnd = New System.Windows.Forms.DateTimePicker()
        Me.cboLogEmp = New System.Windows.Forms.ComboBox()
        Me.chkSummaries = New System.Windows.Forms.CheckBox()
        Me.btnSendUpdates = New System.Windows.Forms.Button()
        Me.btnChangePW = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrFlashButton = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.pnlPrintOptions.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlEditRecord.SuspendLayout()
        Me.flpEditRec.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlPrintOptions)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlEditRecord)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvRecords)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.FlowLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1131, 732)
        Me.SplitContainer1.SplitterDistance = 412
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer5)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.clbStatus)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnViewJob)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnReopenJob)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnStatus)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnCloseJob)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnChangeJob)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnEditJob)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnNewJob)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnRevQuote)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnQuote)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnAddRecord)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lvJobs)
        Me.SplitContainer3.Size = New System.Drawing.Size(412, 732)
        Me.SplitContainer3.SplitterDistance = 392
        Me.SplitContainer3.TabIndex = 0
        Me.SplitContainer3.TabStop = False
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.btnNewCo)
        Me.SplitContainer5.Panel1.Controls.Add(Me.btnEditCo)
        Me.SplitContainer5.Panel1.Controls.Add(Me.lvCompanies)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.chkShowAllCat)
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnEditCat)
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnNewCat)
        Me.SplitContainer5.Panel2.Controls.Add(Me.lvCategories)
        Me.SplitContainer5.Size = New System.Drawing.Size(412, 392)
        Me.SplitContainer5.SplitterDistance = 109
        Me.SplitContainer5.TabIndex = 56
        Me.SplitContainer5.TabStop = False
        '
        'btnNewCo
        '
        Me.btnNewCo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnNewCo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnNewCo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnNewCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewCo.Location = New System.Drawing.Point(59, 2)
        Me.btnNewCo.Name = "btnNewCo"
        Me.btnNewCo.Size = New System.Drawing.Size(40, 21)
        Me.btnNewCo.TabIndex = 56
        Me.btnNewCo.TabStop = False
        Me.btnNewCo.Text = "New"
        Me.btnNewCo.UseVisualStyleBackColor = True
        '
        'btnEditCo
        '
        Me.btnEditCo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnEditCo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEditCo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnEditCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditCo.Location = New System.Drawing.Point(59, 41)
        Me.btnEditCo.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEditCo.Name = "btnEditCo"
        Me.btnEditCo.Size = New System.Drawing.Size(40, 21)
        Me.btnEditCo.TabIndex = 57
        Me.btnEditCo.TabStop = False
        Me.btnEditCo.Text = "Edit"
        Me.btnEditCo.UseVisualStyleBackColor = True
        '
        'lvCompanies
        '
        Me.lvCompanies.BlanksFirst = False
        Me.lvCompanies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCompany_Company})
        Me.lvCompanies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCompanies.FillColumn = 0
        Me.lvCompanies.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCompanies.FullRowSelect = True
        Me.lvCompanies.HideSelection = False
        Me.lvCompanies.LabelWrap = False
        Me.lvCompanies.Location = New System.Drawing.Point(0, 0)
        Me.lvCompanies.Name = "lvCompanies"
        Me.lvCompanies.ShowGroups = False
        Me.lvCompanies.Size = New System.Drawing.Size(109, 392)
        Me.lvCompanies.SortByTag = False
        Me.lvCompanies.SortColumn = 0
        Me.lvCompanies.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvCompanies.SortOnColumnClick = False
        Me.lvCompanies.TabIndex = 20
        Me.lvCompanies.Tag = ""
        Me.lvCompanies.UseCompatibleStateImageBehavior = False
        Me.lvCompanies.View = System.Windows.Forms.View.Details
        '
        'ColCompany_Company
        '
        Me.ColCompany_Company.Text = "Customer"
        Me.ColCompany_Company.Width = 105
        '
        'chkShowAllCat
        '
        Me.chkShowAllCat.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkShowAllCat.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.chkShowAllCat.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.chkShowAllCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkShowAllCat.Location = New System.Drawing.Point(82, 2)
        Me.chkShowAllCat.Name = "chkShowAllCat"
        Me.chkShowAllCat.Size = New System.Drawing.Size(66, 21)
        Me.chkShowAllCat.TabIndex = 57
        Me.chkShowAllCat.Text = "Show All"
        Me.chkShowAllCat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.chkShowAllCat, "Shows all categories, including those that have no jobs")
        Me.chkShowAllCat.UseVisualStyleBackColor = True
        '
        'btnEditCat
        '
        Me.btnEditCat.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnEditCat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEditCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnEditCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditCat.Location = New System.Drawing.Point(150, 37)
        Me.btnEditCat.Name = "btnEditCat"
        Me.btnEditCat.Size = New System.Drawing.Size(40, 21)
        Me.btnEditCat.TabIndex = 56
        Me.btnEditCat.TabStop = False
        Me.btnEditCat.Text = "Edit"
        Me.btnEditCat.UseVisualStyleBackColor = True
        '
        'btnNewCat
        '
        Me.btnNewCat.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnNewCat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnNewCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnNewCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewCat.Location = New System.Drawing.Point(150, 2)
        Me.btnNewCat.Name = "btnNewCat"
        Me.btnNewCat.Size = New System.Drawing.Size(39, 21)
        Me.btnNewCat.TabIndex = 55
        Me.btnNewCat.TabStop = False
        Me.btnNewCat.Text = "New"
        Me.btnNewCat.UseVisualStyleBackColor = True
        '
        'lvCategories
        '
        Me.lvCategories.BlanksFirst = False
        Me.lvCategories.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCategory_Name, Me.ColCategory_Company})
        Me.lvCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCategories.FillColumn = 0
        Me.lvCategories.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCategories.FullRowSelect = True
        Me.lvCategories.HideSelection = False
        Me.lvCategories.LabelWrap = False
        Me.lvCategories.Location = New System.Drawing.Point(0, 0)
        Me.lvCategories.Name = "lvCategories"
        Me.lvCategories.ShowGroups = False
        Me.lvCategories.Size = New System.Drawing.Size(299, 392)
        Me.lvCategories.SortByTag = False
        Me.lvCategories.SortColumn = 0
        Me.lvCategories.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvCategories.SortOnColumnClick = False
        Me.lvCategories.TabIndex = 21
        Me.lvCategories.Tag = ""
        Me.lvCategories.UseCompatibleStateImageBehavior = False
        Me.lvCategories.View = System.Windows.Forms.View.Details
        '
        'ColCategory_Name
        '
        Me.ColCategory_Name.Text = "Project"
        Me.ColCategory_Name.Width = 207
        '
        'ColCategory_Company
        '
        Me.ColCategory_Company.Text = "Customer"
        Me.ColCategory_Company.Width = 88
        '
        'clbStatus
        '
        Me.clbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbStatus.CheckOnClick = True
        Me.clbStatus.FormattingEnabled = True
        Me.clbStatus.Items.AddRange(New Object() {"Open", "Complete", "Awaiting Quote", "Awaiting Approval", "On Hold"})
        Me.clbStatus.Location = New System.Drawing.Point(4, 83)
        Me.clbStatus.Name = "clbStatus"
        Me.clbStatus.Size = New System.Drawing.Size(119, 77)
        Me.clbStatus.TabIndex = 20
        Me.clbStatus.TabStop = False
        Me.clbStatus.Visible = False
        '
        'btnViewJob
        '
        Me.btnViewJob.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnViewJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnViewJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnViewJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewJob.Location = New System.Drawing.Point(156, 177)
        Me.btnViewJob.Name = "btnViewJob"
        Me.btnViewJob.Size = New System.Drawing.Size(40, 21)
        Me.btnViewJob.TabIndex = 23
        Me.btnViewJob.TabStop = False
        Me.btnViewJob.Text = "View"
        Me.btnViewJob.UseVisualStyleBackColor = True
        Me.btnViewJob.Visible = False
        '
        'btnReopenJob
        '
        Me.btnReopenJob.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnReopenJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnReopenJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReopenJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReopenJob.Location = New System.Drawing.Point(156, 155)
        Me.btnReopenJob.Name = "btnReopenJob"
        Me.btnReopenJob.Size = New System.Drawing.Size(55, 21)
        Me.btnReopenJob.TabIndex = 22
        Me.btnReopenJob.TabStop = False
        Me.btnReopenJob.Text = "Reopen"
        Me.btnReopenJob.UseVisualStyleBackColor = True
        Me.btnReopenJob.Visible = False
        '
        'btnStatus
        '
        Me.btnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStatus.ImageIndex = 0
        Me.btnStatus.ImageList = Me.ilStatus
        Me.btnStatus.Location = New System.Drawing.Point(156, 3)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(23, 19)
        Me.btnStatus.TabIndex = 21
        Me.btnStatus.TabStop = False
        Me.btnStatus.UseVisualStyleBackColor = True
        '
        'ilStatus
        '
        Me.ilStatus.ImageStream = CType(resources.GetObject("ilStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilStatus.TransparentColor = System.Drawing.Color.White
        Me.ilStatus.Images.SetKeyName(0, "down.bmp")
        Me.ilStatus.Images.SetKeyName(1, "up.bmp")
        '
        'btnCloseJob
        '
        Me.btnCloseJob.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnCloseJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCloseJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCloseJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseJob.Location = New System.Drawing.Point(156, 133)
        Me.btnCloseJob.Name = "btnCloseJob"
        Me.btnCloseJob.Size = New System.Drawing.Size(49, 21)
        Me.btnCloseJob.TabIndex = 19
        Me.btnCloseJob.TabStop = False
        Me.btnCloseJob.Text = "Close"
        Me.btnCloseJob.UseVisualStyleBackColor = True
        Me.btnCloseJob.Visible = False
        '
        'btnChangeJob
        '
        Me.btnChangeJob.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnChangeJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnChangeJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnChangeJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeJob.Location = New System.Drawing.Point(156, 111)
        Me.btnChangeJob.Name = "btnChangeJob"
        Me.btnChangeJob.Size = New System.Drawing.Size(75, 21)
        Me.btnChangeJob.TabIndex = 18
        Me.btnChangeJob.TabStop = False
        Me.btnChangeJob.Text = "Update ->"
        Me.btnChangeJob.UseVisualStyleBackColor = True
        Me.btnChangeJob.Visible = False
        '
        'btnEditJob
        '
        Me.btnEditJob.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnEditJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEditJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnEditJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditJob.Location = New System.Drawing.Point(156, 89)
        Me.btnEditJob.Name = "btnEditJob"
        Me.btnEditJob.Size = New System.Drawing.Size(40, 21)
        Me.btnEditJob.TabIndex = 17
        Me.btnEditJob.TabStop = False
        Me.btnEditJob.Text = "Edit"
        Me.btnEditJob.UseVisualStyleBackColor = True
        Me.btnEditJob.Visible = False
        '
        'btnNewJob
        '
        Me.btnNewJob.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnNewJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnNewJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnNewJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewJob.Location = New System.Drawing.Point(76, 2)
        Me.btnNewJob.Name = "btnNewJob"
        Me.btnNewJob.Size = New System.Drawing.Size(39, 21)
        Me.btnNewJob.TabIndex = 16
        Me.btnNewJob.TabStop = False
        Me.btnNewJob.Text = "New"
        Me.btnNewJob.UseVisualStyleBackColor = True
        '
        'btnRevQuote
        '
        Me.btnRevQuote.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnRevQuote.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnRevQuote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRevQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRevQuote.Location = New System.Drawing.Point(156, 67)
        Me.btnRevQuote.Name = "btnRevQuote"
        Me.btnRevQuote.Size = New System.Drawing.Size(75, 21)
        Me.btnRevQuote.TabIndex = 15
        Me.btnRevQuote.TabStop = False
        Me.btnRevQuote.Text = "View Quote"
        Me.btnRevQuote.UseVisualStyleBackColor = True
        Me.btnRevQuote.Visible = False
        '
        'btnQuote
        '
        Me.btnQuote.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnQuote.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnQuote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuote.Location = New System.Drawing.Point(156, 45)
        Me.btnQuote.Name = "btnQuote"
        Me.btnQuote.Size = New System.Drawing.Size(75, 21)
        Me.btnQuote.TabIndex = 14
        Me.btnQuote.TabStop = False
        Me.btnQuote.Text = "Quote"
        Me.btnQuote.UseVisualStyleBackColor = True
        Me.btnQuote.Visible = False
        '
        'btnAddRecord
        '
        Me.btnAddRecord.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnAddRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAddRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnAddRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRecord.Location = New System.Drawing.Point(156, 23)
        Me.btnAddRecord.Name = "btnAddRecord"
        Me.btnAddRecord.Size = New System.Drawing.Size(75, 21)
        Me.btnAddRecord.TabIndex = 13
        Me.btnAddRecord.TabStop = False
        Me.btnAddRecord.Text = "Add Work"
        Me.btnAddRecord.UseVisualStyleBackColor = True
        Me.btnAddRecord.Visible = False
        '
        'lvJobs
        '
        Me.lvJobs.BlanksFirst = False
        Me.lvJobs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColJobs_Description, Me.ColJobs_Status, Me.ColJobs_Priority, Me.ColJobs_Billing, Me.ColJobs_Company, Me.ColJobs_Category, Me.ColJobs_AccountingID})
        Me.lvJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvJobs.FillColumn = 0
        Me.lvJobs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvJobs.FullRowSelect = True
        Me.lvJobs.HideSelection = False
        Me.lvJobs.LabelWrap = False
        Me.lvJobs.Location = New System.Drawing.Point(0, 0)
        Me.lvJobs.Name = "lvJobs"
        Me.lvJobs.ShowGroups = False
        Me.lvJobs.Size = New System.Drawing.Size(412, 336)
        Me.lvJobs.SortByTag = False
        Me.lvJobs.SortColumn = 0
        Me.lvJobs.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvJobs.SortOnColumnClick = False
        Me.lvJobs.TabIndex = 3
        Me.lvJobs.Tag = ""
        Me.lvJobs.UseCompatibleStateImageBehavior = False
        Me.lvJobs.View = System.Windows.Forms.View.Details
        '
        'ColJobs_Description
        '
        Me.ColJobs_Description.Text = "Task"
        Me.ColJobs_Description.Width = 139
        '
        'ColJobs_Status
        '
        Me.ColJobs_Status.Text = "Status"
        Me.ColJobs_Status.Width = 63
        '
        'ColJobs_Priority
        '
        Me.ColJobs_Priority.DisplayIndex = 4
        Me.ColJobs_Priority.Text = "Priority"
        Me.ColJobs_Priority.Width = 44
        '
        'ColJobs_Billing
        '
        Me.ColJobs_Billing.DisplayIndex = 5
        Me.ColJobs_Billing.Text = "Bill"
        Me.ColJobs_Billing.Width = 26
        '
        'ColJobs_Company
        '
        Me.ColJobs_Company.DisplayIndex = 2
        Me.ColJobs_Company.Text = "Customer"
        Me.ColJobs_Company.Width = 62
        '
        'ColJobs_Category
        '
        Me.ColJobs_Category.DisplayIndex = 3
        Me.ColJobs_Category.Text = "Project"
        Me.ColJobs_Category.Width = 74
        '
        'ColJobs_AccountingID
        '
        Me.ColJobs_AccountingID.Text = "Accounting#"
        Me.ColJobs_AccountingID.Width = 0
        '
        'pnlPrintOptions
        '
        Me.pnlPrintOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPrintOptions.Controls.Add(Me.tvReport)
        Me.pnlPrintOptions.Controls.Add(Me.Panel3)
        Me.pnlPrintOptions.Location = New System.Drawing.Point(29, 382)
        Me.pnlPrintOptions.Name = "pnlPrintOptions"
        Me.pnlPrintOptions.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlPrintOptions.Size = New System.Drawing.Size(139, 168)
        Me.pnlPrintOptions.TabIndex = 74
        Me.pnlPrintOptions.Tag = "168,216"
        Me.pnlPrintOptions.Visible = False
        '
        'tvReport
        '
        Me.tvReport.CheckBoxes = True
        Me.tvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvReport.Location = New System.Drawing.Point(2, 2)
        Me.tvReport.Name = "tvReport"
        TreeNode1.Name = "Node2"
        TreeNode1.Text = "Show Details"
        TreeNode2.Name = "Date"
        TreeNode2.Text = "Daily Report"
        TreeNode3.Name = "Node3"
        TreeNode3.Text = "Show Details"
        TreeNode4.Name = "JobID"
        TreeNode4.Text = "Task Report"
        TreeNode5.Name = "Node1"
        TreeNode5.Text = "Show Details"
        TreeNode6.Name = "Project"
        TreeNode6.Text = "Project Report"
        TreeNode7.Name = "Node1"
        TreeNode7.Text = "Show Details"
        TreeNode8.Name = "User"
        TreeNode8.Text = "Employee Report"
        Me.tvReport.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode4, TreeNode6, TreeNode8})
        Me.tvReport.Scrollable = False
        Me.tvReport.Size = New System.Drawing.Size(133, 131)
        Me.tvReport.TabIndex = 4
        Me.tvReport.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnHideOptions)
        Me.Panel3.Controls.Add(Me.btnGenReport)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(2, 133)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel3.Size = New System.Drawing.Size(133, 31)
        Me.Panel3.TabIndex = 5
        '
        'btnHideOptions
        '
        Me.btnHideOptions.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnHideOptions.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnHideOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnHideOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnHideOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHideOptions.Location = New System.Drawing.Point(2, 2)
        Me.btnHideOptions.Name = "btnHideOptions"
        Me.btnHideOptions.Padding = New System.Windows.Forms.Padding(1)
        Me.btnHideOptions.Size = New System.Drawing.Size(56, 27)
        Me.btnHideOptions.TabIndex = 2
        Me.btnHideOptions.TabStop = False
        Me.btnHideOptions.Text = "Cancel"
        '
        'btnGenReport
        '
        Me.btnGenReport.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnGenReport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGenReport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnGenReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnGenReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnGenReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenReport.Location = New System.Drawing.Point(62, 2)
        Me.btnGenReport.Name = "btnGenReport"
        Me.btnGenReport.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGenReport.Size = New System.Drawing.Size(69, 27)
        Me.btnGenReport.TabIndex = 1
        Me.btnGenReport.TabStop = False
        Me.btnGenReport.Text = "Create >>"
        '
        'pnlEditRecord
        '
        Me.pnlEditRecord.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlEditRecord.Controls.Add(Me.txtWorkPerf)
        Me.pnlEditRecord.Controls.Add(Me.flpEditRec)
        Me.pnlEditRecord.Controls.Add(Me.Panel2)
        Me.pnlEditRecord.Location = New System.Drawing.Point(9, 197)
        Me.pnlEditRecord.Name = "pnlEditRecord"
        Me.pnlEditRecord.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlEditRecord.Size = New System.Drawing.Size(627, 159)
        Me.pnlEditRecord.TabIndex = 76
        Me.pnlEditRecord.Tag = "-1"
        Me.pnlEditRecord.Visible = False
        '
        'txtWorkPerf
        '
        Me.txtWorkPerf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkPerf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWorkPerf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkPerf.Location = New System.Drawing.Point(2, 52)
        Me.txtWorkPerf.MaxLength = 255
        Me.txtWorkPerf.Multiline = True
        Me.txtWorkPerf.Name = "txtWorkPerf"
        Me.txtWorkPerf.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtWorkPerf.Size = New System.Drawing.Size(623, 73)
        Me.txtWorkPerf.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtWorkPerf, "Enter a description of the work performed here")
        '
        'flpEditRec
        '
        Me.flpEditRec.Controls.Add(Me.dtpDate)
        Me.flpEditRec.Controls.Add(Me.cboUser)
        Me.flpEditRec.Controls.Add(Me.cboStartTime)
        Me.flpEditRec.Controls.Add(Me.cboStopTime)
        Me.flpEditRec.Controls.Add(Me.cboTimeWorked)
        Me.flpEditRec.Controls.Add(Me.lblCompany)
        Me.flpEditRec.Controls.Add(Me.Label3)
        Me.flpEditRec.Controls.Add(Me.lblCategory)
        Me.flpEditRec.Controls.Add(Me.Label5)
        Me.flpEditRec.Controls.Add(Me.lblJobDescr)
        Me.flpEditRec.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpEditRec.Location = New System.Drawing.Point(2, 2)
        Me.flpEditRec.Name = "flpEditRec"
        Me.flpEditRec.Padding = New System.Windows.Forms.Padding(2)
        Me.flpEditRec.Size = New System.Drawing.Size(623, 50)
        Me.flpEditRec.TabIndex = 17
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "MM/dd/yy"
        Me.dtpDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(5, 5)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(65, 20)
        Me.dtpDate.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.dtpDate, "The date of the work")
        '
        'cboUser
        '
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(76, 5)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(120, 21)
        Me.cboUser.TabIndex = 2
        '
        'cboStartTime
        '
        Me.cboStartTime.BackColor = System.Drawing.SystemColors.Window
        Me.cboStartTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboStartTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStartTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboStartTime.Location = New System.Drawing.Point(202, 5)
        Me.cboStartTime.Name = "cboStartTime"
        Me.cboStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboStartTime.Size = New System.Drawing.Size(65, 22)
        Me.cboStartTime.TabIndex = 3
        Me.cboStartTime.Text = "8:00 am"
        Me.ToolTip1.SetToolTip(Me.cboStartTime, "Start time of the work")
        '
        'cboStopTime
        '
        Me.cboStopTime.BackColor = System.Drawing.SystemColors.Window
        Me.cboStopTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboStopTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStopTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboStopTime.Location = New System.Drawing.Point(273, 5)
        Me.cboStopTime.Name = "cboStopTime"
        Me.cboStopTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboStopTime.Size = New System.Drawing.Size(65, 22)
        Me.cboStopTime.TabIndex = 4
        Me.cboStopTime.Text = "9:00 am"
        Me.ToolTip1.SetToolTip(Me.cboStopTime, "Stop time of the work")
        '
        'cboTimeWorked
        '
        Me.cboTimeWorked.BackColor = System.Drawing.SystemColors.Window
        Me.cboTimeWorked.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboTimeWorked.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTimeWorked.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTimeWorked.Location = New System.Drawing.Point(344, 5)
        Me.cboTimeWorked.Name = "cboTimeWorked"
        Me.cboTimeWorked.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboTimeWorked.Size = New System.Drawing.Size(50, 22)
        Me.cboTimeWorked.TabIndex = 5
        Me.cboTimeWorked.Text = "1"
        Me.ToolTip1.SetToolTip(Me.cboTimeWorked, "Number of hours of work")
        '
        'lblCompany
        '
        Me.lblCompany.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCompany.AutoEllipsis = True
        Me.lblCompany.AutoSize = True
        Me.lblCompany.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblCompany.Location = New System.Drawing.Point(400, 9)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(51, 13)
        Me.lblCompany.TabIndex = 8
        Me.lblCompany.Text = "Customer"
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblCompany, "Customer name (to change, use lists to the left)")
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoEllipsis = True
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(457, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "::"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCategory
        '
        Me.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCategory.AutoEllipsis = True
        Me.lblCategory.AutoSize = True
        Me.lblCategory.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblCategory.Location = New System.Drawing.Point(476, 9)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(40, 13)
        Me.lblCategory.TabIndex = 9
        Me.lblCategory.Text = "Project"
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblCategory, "Project name (to change, use lists to the left)")
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoEllipsis = True
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label5.Location = New System.Drawing.Point(522, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "::"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblJobDescr
        '
        Me.lblJobDescr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblJobDescr.AutoEllipsis = True
        Me.lblJobDescr.AutoSize = True
        Me.lblJobDescr.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblJobDescr.Location = New System.Drawing.Point(541, 9)
        Me.lblJobDescr.Name = "lblJobDescr"
        Me.lblJobDescr.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.lblJobDescr.Size = New System.Drawing.Size(33, 13)
        Me.lblJobDescr.TabIndex = 11
        Me.lblJobDescr.Text = "Task"
        Me.lblJobDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblJobDescr, "Task Description (to change, use lists to the left)")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnDelRec)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(2, 125)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(623, 32)
        Me.Panel2.TabIndex = 16
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue
        Me.btnOK.Location = New System.Drawing.Point(447, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(58, 30)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "Add"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon
        Me.btnCancel.Location = New System.Drawing.Point(505, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 30)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnDelRec
        '
        Me.btnDelRec.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDelRec.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelRec.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick
        Me.btnDelRec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.btnDelRec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon
        Me.btnDelRec.Location = New System.Drawing.Point(564, 2)
        Me.btnDelRec.Name = "btnDelRec"
        Me.btnDelRec.Size = New System.Drawing.Size(59, 30)
        Me.btnDelRec.TabIndex = 9
        Me.btnDelRec.Text = "Delete"
        Me.btnDelRec.UseVisualStyleBackColor = False
        '
        'lvRecords
        '
        Me.lvRecords.BlanksFirst = False
        Me.lvRecords.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColDate, Me.ColEmployee, Me.ColStart, Me.ColStop, Me.ColHours, Me.colBillHours, Me.ColCompany, Me.ColCategory, Me.ColJob, Me.ColWorkDescr})
        Me.lvRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvRecords.FillColumn = 9
        Me.lvRecords.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRecords.FullRowSelect = True
        Me.lvRecords.HideSelection = False
        Me.lvRecords.LabelWrap = False
        Me.lvRecords.Location = New System.Drawing.Point(0, 35)
        Me.lvRecords.MultiSelect = False
        Me.lvRecords.Name = "lvRecords"
        Me.lvRecords.Size = New System.Drawing.Size(715, 697)
        Me.lvRecords.SortByTag = True
        Me.lvRecords.SortColumn = 1
        Me.lvRecords.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvRecords.SortOnColumnClick = False
        Me.lvRecords.TabIndex = 9
        Me.lvRecords.TabStop = False
        Me.lvRecords.Tag = ""
        Me.lvRecords.UseCompatibleStateImageBehavior = False
        Me.lvRecords.View = System.Windows.Forms.View.Details
        '
        'ColDate
        '
        Me.ColDate.Text = "Date"
        Me.ColDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColDate.Width = 70
        '
        'ColEmployee
        '
        Me.ColEmployee.Text = "Employee"
        Me.ColEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColEmployee.Width = 80
        '
        'ColStart
        '
        Me.ColStart.Text = "Start"
        Me.ColStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColStart.Width = 40
        '
        'ColStop
        '
        Me.ColStop.Text = "End"
        Me.ColStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColStop.Width = 40
        '
        'ColHours
        '
        Me.ColHours.Text = "Hours"
        Me.ColHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColHours.Width = 30
        '
        'colBillHours
        '
        Me.colBillHours.Text = "Billable Hours"
        Me.colBillHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colBillHours.Width = 30
        '
        'ColCompany
        '
        Me.ColCompany.Text = "Customer"
        Me.ColCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColCompany.Width = 67
        '
        'ColCategory
        '
        Me.ColCategory.Text = "Project"
        '
        'ColJob
        '
        Me.ColJob.Text = "Task Descr."
        Me.ColJob.Width = 142
        '
        'ColWorkDescr
        '
        Me.ColWorkDescr.Text = "Work Performed"
        Me.ColWorkDescr.Width = 152
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(0, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(715, 697)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Updating records ... Please wait"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpLogDateBegin)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpLogDateEnd)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboLogEmp)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkSummaries)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSendUpdates)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnChangePW)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnExcel)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(715, 35)
        Me.FlowLayoutPanel1.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 23)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Records"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLogDateBegin
        '
        Me.dtpLogDateBegin.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLogDateBegin.CustomFormat = "M/d/yy"
        Me.dtpLogDateBegin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLogDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLogDateBegin.Location = New System.Drawing.Point(72, 6)
        Me.dtpLogDateBegin.Name = "dtpLogDateBegin"
        Me.dtpLogDateBegin.Size = New System.Drawing.Size(70, 21)
        Me.dtpLogDateBegin.TabIndex = 4
        Me.dtpLogDateBegin.TabStop = False
        Me.ToolTip1.SetToolTip(Me.dtpLogDateBegin, "Viewing work records beginning on this date")
        Me.dtpLogDateBegin.Value = New Date(2005, 1, 1, 0, 0, 0, 0)
        '
        'dtpLogDateEnd
        '
        Me.dtpLogDateEnd.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLogDateEnd.CustomFormat = "M/d/yy"
        Me.dtpLogDateEnd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLogDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLogDateEnd.Location = New System.Drawing.Point(148, 6)
        Me.dtpLogDateEnd.Name = "dtpLogDateEnd"
        Me.dtpLogDateEnd.Size = New System.Drawing.Size(71, 21)
        Me.dtpLogDateEnd.TabIndex = 5
        Me.dtpLogDateEnd.TabStop = False
        Me.ToolTip1.SetToolTip(Me.dtpLogDateEnd, "Viewing work records ending on this date")
        Me.dtpLogDateEnd.Value = New Date(2005, 1, 1, 0, 0, 0, 0)
        '
        'cboLogEmp
        '
        Me.cboLogEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLogEmp.DropDownWidth = 120
        Me.cboLogEmp.Location = New System.Drawing.Point(225, 6)
        Me.cboLogEmp.MaxDropDownItems = 10
        Me.cboLogEmp.Name = "cboLogEmp"
        Me.cboLogEmp.Size = New System.Drawing.Size(129, 21)
        Me.cboLogEmp.TabIndex = 6
        Me.cboLogEmp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.cboLogEmp, "Viewing work records for this employee")
        '
        'chkSummaries
        '
        Me.chkSummaries.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkSummaries.Checked = True
        Me.chkSummaries.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSummaries.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkSummaries.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSummaries.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime
        Me.chkSummaries.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkSummaries.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSummaries.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSummaries.Location = New System.Drawing.Point(360, 6)
        Me.chkSummaries.Name = "chkSummaries"
        Me.chkSummaries.Size = New System.Drawing.Size(52, 23)
        Me.chkSummaries.TabIndex = 7
        Me.chkSummaries.TabStop = False
        Me.chkSummaries.Text = "Group"
        Me.chkSummaries.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.chkSummaries, "Cluster records by the selected column heading")
        '
        'btnSendUpdates
        '
        Me.btnSendUpdates.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSendUpdates.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSendUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime
        Me.btnSendUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSendUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendUpdates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSendUpdates.Location = New System.Drawing.Point(418, 6)
        Me.btnSendUpdates.Name = "btnSendUpdates"
        Me.btnSendUpdates.Size = New System.Drawing.Size(92, 23)
        Me.btnSendUpdates.TabIndex = 75
        Me.btnSendUpdates.TabStop = False
        Me.btnSendUpdates.Text = "Send Updates"
        Me.ToolTip1.SetToolTip(Me.btnSendUpdates, "You have added or changed data locally. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click to send these updates to the web." & _
                "")
        '
        'btnChangePW
        '
        Me.btnChangePW.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnChangePW.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChangePW.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime
        Me.btnChangePW.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnChangePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangePW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnChangePW.Location = New System.Drawing.Point(516, 6)
        Me.btnChangePW.Name = "btnChangePW"
        Me.btnChangePW.Size = New System.Drawing.Size(72, 23)
        Me.btnChangePW.TabIndex = 76
        Me.btnChangePW.TabStop = False
        Me.btnChangePW.Text = "Password"
        Me.ToolTip1.SetToolTip(Me.btnChangePW, "Change your password")
        '
        'btnExcel
        '
        Me.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnExcel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime
        Me.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExcel.Location = New System.Drawing.Point(594, 6)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(53, 23)
        Me.btnExcel.TabIndex = 74
        Me.btnExcel.TabStop = False
        Me.btnExcel.Text = "Excel"
        Me.ToolTip1.SetToolTip(Me.btnExcel, "Create an Excel report of work records currently being viewed")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        '
        'tmrFlashButton
        '
        Me.tmrFlashButton.Interval = 500
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 732)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Tracker"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.ResumeLayout(False)
        Me.pnlPrintOptions.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlEditRecord.ResumeLayout(False)
        Me.pnlEditRecord.PerformLayout()
        Me.flpEditRec.ResumeLayout(False)
        Me.flpEditRec.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents cboLogEmp As System.Windows.Forms.ComboBox
    Friend WithEvents dtpLogDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpLogDateBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSummaries As System.Windows.Forms.CheckBox
    Friend WithEvents ColDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColEmployee As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColStart As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColStop As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColHours As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColCompany As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColJob As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColWorkDescr As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColJobs_Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColJobs_Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlPrintOptions As System.Windows.Forms.Panel
    Friend WithEvents tvReport As System.Windows.Forms.TreeView
    Friend WithEvents btnHideOptions As System.Windows.Forms.Button
    Friend WithEvents btnGenReport As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Public WithEvents cboStartTime As System.Windows.Forms.ComboBox
    Public WithEvents cboStopTime As System.Windows.Forms.ComboBox
    Public WithEvents cboTimeWorked As System.Windows.Forms.ComboBox
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents lvCompanies As ProjectTracker.EnhancedListView
    Friend WithEvents ColCategory_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColCategory_Company As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRecords As ProjectTracker.EnhancedListView
    Friend WithEvents lvJobs As ProjectTracker.EnhancedListView
    Friend WithEvents lvCategories As ProjectTracker.EnhancedListView
    Friend WithEvents ColCategory As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlEditRecord As System.Windows.Forms.Panel
    Friend WithEvents lblJobDescr As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents txtWorkPerf As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnAddRecord As System.Windows.Forms.Button
    Friend WithEvents ColJobs_Company As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColJobs_Category As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnDelRec As System.Windows.Forms.Button
    Friend WithEvents btnRevQuote As System.Windows.Forms.Button
    Friend WithEvents btnQuote As System.Windows.Forms.Button
    Friend WithEvents btnEditJob As System.Windows.Forms.Button
    Friend WithEvents btnNewJob As System.Windows.Forms.Button
    Friend WithEvents btnEditCo As System.Windows.Forms.Button
    Friend WithEvents btnNewCo As System.Windows.Forms.Button
    Friend WithEvents btnEditCat As System.Windows.Forms.Button
    Friend WithEvents btnNewCat As System.Windows.Forms.Button
    Friend WithEvents ColCompany_Company As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnChangeJob As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ColJobs_Priority As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboUser As System.Windows.Forms.ComboBox
    Friend WithEvents btnCloseJob As System.Windows.Forms.Button
    Friend WithEvents clbStatus As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnStatus As System.Windows.Forms.Button
    Friend WithEvents ilStatus As System.Windows.Forms.ImageList
    Friend WithEvents btnReopenJob As System.Windows.Forms.Button
    Friend WithEvents btnViewJob As System.Windows.Forms.Button
    Friend WithEvents ColJobs_Billing As System.Windows.Forms.ColumnHeader
    Friend WithEvents flpEditRec As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ColJobs_AccountingID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkShowAllCat As System.Windows.Forms.CheckBox
    Friend WithEvents colBillHours As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnSendUpdates As System.Windows.Forms.Button
    Friend WithEvents tmrFlashButton As System.Windows.Forms.Timer
    Friend WithEvents btnChangePW As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
End Class
