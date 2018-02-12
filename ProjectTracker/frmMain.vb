Option Strict On
Option Explicit On
Imports Microsoft.Office.Interop

Public Class frmMain

#Region " Declarations "

    Private Enum LineWeight
        None = 0
        SingleLine = 1
        DoubleLine = 2
        Asterisks = 3
        Dashes = 4
    End Enum
    Private Enum AsciiLineType
        TopofBox = 0
        MiddleofBox = 1
        BottomofBox = 2
    End Enum
    'Private Structure CompareTag
    '    Public Column As Integer
    '    Public Value As String
    'End Structure
    'Private Structure GroupTag
    '    Public CompareTag() As CompareTag
    '    Public Hours As Single
    'End Structure
    Private DontUpdateRecords As Boolean = False
    Private DontUpdateJobs As Boolean = False
    Private DontUpdateCategories As Boolean = False
    Private RecordBeingEdited As Integer = -1
    Private LastDateAdded As Date = Now
    Private LastStopTimeAdded As Single = 8.0F
    Private flashCount As Integer = 0

#End Region

#Region " Form Setup and Close Code "

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.Cursor = Cursors.WaitCursor

        If Not DBA Is Nothing Then
            e.Cancel = Not DBA.SendData()
        End If

        If Not e.Cancel AndAlso Me.WindowState <> FormWindowState.Minimized Then
            My.Settings.WindowState = Me.WindowState
            My.Settings.WindowTop = Me.Top
            My.Settings.WindowLeft = Me.Left
            My.Settings.WindowWidth = Me.Width
            My.Settings.WindowHeight = Me.Height
        End If
        My.Settings.Save()
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub frmMain_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) _
    Handles MyBase.Load

        'My.Forms.frmLogin.StartDate = Now.AddDays(-90)
        'If My.Forms.frmLogin.ShowDialog <> Windows.Forms.DialogResult.OK Then
        '    Me.Close()
        '    Exit Sub
        'End If

        btnNewCo.Visible = False
        btnNewCat.Visible = False
        btnNewJob.Visible = False

        'Adjust application settings for viewability
        If My.Settings.WindowHeight < 0 OrElse My.Settings.WindowTop + My.Settings.WindowHeight > _
                My.Computer.Screen.WorkingArea.Height Then
            My.Settings.WindowHeight = My.Computer.Screen.WorkingArea.Height
        End If
        If My.Settings.WindowWidth < 0 OrElse My.Settings.WindowLeft + My.Settings.WindowWidth > _
                My.Computer.Screen.WorkingArea.Width Then
            My.Settings.WindowWidth = My.Computer.Screen.WorkingArea.Width
        End If
        If My.Settings.WindowTop < 0 Then My.Settings.WindowTop = 0
        If My.Settings.WindowLeft < 0 Then My.Settings.WindowLeft = 0
        If My.Settings.WindowState = FormWindowState.Minimized Then My.Settings.WindowState = FormWindowState.Normal

        'Apply application view settings
        Me.WindowState = My.Settings.WindowState
        Me.Top = My.Settings.WindowTop
        Me.Left = My.Settings.WindowLeft
        Me.Width = My.Settings.WindowWidth
        Me.Height = My.Settings.WindowHeight

        Dim i As Integer
        For i = 0 To Me.clbStatus.Items.Count - 1
            If Me.clbStatus.Items(i).ToString <> "Complete" Then Me.clbStatus.SetItemChecked(i, True)
        Next
        Me.lvJobs.SortColumn = Me.ColJobs_Priority.Index

        Select Case DBA.UserType
            Case UserType.Administrator
                Me.Text = "Project Tracking : Admin Mode (" + DBA.User + ")"
                btnNewCo.Visible = True
                btnNewCat.Visible = True
                btnNewJob.Visible = True
            Case UserType.Employee
                Me.Text = "Project Tracking : Enter Records (" + DBA.User + ")"

                'Set status view options and hide controls
                'Me.btnStatus.Hide()

                Me.clbStatus.SetItemChecked(1, False) 'Complete
                Me.clbStatus.SetItemChecked(3, False) 'Awaiting Approval
                Me.clbStatus.SetItemChecked(4, False) 'On Hold
                'changed on 7/31/07 per BEZ request
                btnNewJob.Visible = True

            Case UserType.Customer
                Me.Text = "Project Tracking : " + DBA.UserCompany
                'lvCompanies.Enabled = False
                btnNewCat.Visible = True
                btnNewJob.Visible = True
        End Select
        clbStatus_MouseUp(Me, Nothing)


        UpdateEmployeeFilter()
        UpdateCompanyList()

        SetupTimeCombos()
        SetupTV()

        'lvRecords.Width += 1 'triggers resize event 

        Me.clbStatus.Top = Me.btnStatus.Top

    End Sub

    Private Sub SetupTimeCombos()

        Dim Hr As Short
        Dim Mn As Short
        Dim TimeDisp As String = ""

        For Hr = 0 To 23
            For Mn = 0 To 45 Step 15
                Select Case Hr
                    Case 0
                        TimeDisp = "12:" & Mn.ToString("00") & "am"
                    Case 1 To 11
                        TimeDisp = Hr & ":" & Mn.ToString("00") & " am"
                    Case 12
                        TimeDisp = "12:" & Mn.ToString("00") & " pm"
                    Case 13 To 23
                        TimeDisp = (Hr - 12) & ":" & Mn.ToString("00") & " pm"
                End Select
                cboStartTime.Items.Add(TimeDisp)
                cboStopTime.Items.Add(TimeDisp)
                cboTimeWorked.Items.Add((Hr + Mn / 60.0#).ToString("#0.00"))
            Next  'Minute
        Next  'Hour

        dtpDate.Value = Now
        Select Case Now.Day
            Case 1 To 15
                dtpLogDateBegin.Value = DateTime.Parse(Now.Month.ToString + "/01/" + Now.Year.ToString)
                dtpLogDateEnd.Value = DateTime.Parse(Now.Month.ToString + "/15/" + Now.Year.ToString)
            Case 15 To 31
                dtpLogDateBegin.Value = DateTime.Parse(Now.Month.ToString + "/16/" + Now.Year.ToString)
                dtpLogDateEnd.Value = DateTime.Parse(Now.Month.ToString + "/" + _
                     DateTime.DaysInMonth(Now.Year, Now.Month).ToString + "/" + Now.Year.ToString)

        End Select


    End Sub

    Private Sub SetupTV()
        Dim Nd As TreeNode

        For Each Nd In tvReport.Nodes
            Nd.Checked = True
        Next
        tvReport.ExpandAll()
        pnlPrintOptions.Tag = pnlPrintOptions.Width.ToString + "," + pnlPrintOptions.Height.ToString

    End Sub

    Private Sub UpdateEmployeeFilter()
        cboLogEmp.Items.Clear()
        cboUser.Enabled = False
        Select Case DBA.UserType
            Case UserType.Administrator 'Add all employees + "All" entry
                'cboLogEmp.Items.AddRange(DBA.GetItems("Users", "UserType=3", "{0} ({1} {2})", "Username", "FirstName", "LastName"))
                cboLogEmp.Items.AddRange(DBA.GetItems("Users", "UserType=1 OR UserType=3", "{0} ({1} {2})", "Username", "FirstName", "LastName"))
                cboLogEmp.Items.Insert(0, "* All *")
                cboUser.Items.AddRange(DBA.GetItems("Users", "UserType=1 OR UserType=3", "{0}", "Username"))
                cboUser.Enabled = True
            Case UserType.Customer 'Add all employees listed in company "AllowedUser" list + "All" entry
                Dim ExistingUsers() As String = DBA.GetItems("Users", "UserType=3", "{0}", "Username")
                Dim AllowedUsers() As String = DBA.GetDataRow("Companies", DBA.UserCompany).Item("AllowedUsers") _
                   .ToString.Replace(" ", "").Split(","c)
                Dim i, j As Integer
                For i = 0 To AllowedUsers.GetUpperBound(0)
                    For j = 0 To ExistingUsers.GetUpperBound(0)
                        If ExistingUsers(j).Trim.ToUpper = AllowedUsers(i).Trim.ToUpper Then
                            cboLogEmp.Items.AddRange(DBA.GetItems("Users", "Username='" + AllowedUsers(i) + "'", "{0} ({1} {2})", "Username", "FirstName", "LastName"))
                        End If
                    Next
                Next

                'Add administrators
                cboLogEmp.Items.AddRange(DBA.GetItems("Users", "UserType=1", "{0} ({1} {2})", "Username", "FirstName", "LastName"))
                cboLogEmp.Items.Insert(0, "* All *")
            Case UserType.Employee 'Add current username only

                cboLogEmp.Items.AddRange(DBA.GetItems("Users", "Username='" + DBA.User + "'", _
                   "{0} ({1} {2})", "Username", "FirstName", "LastName"))
        End Select
        cboLogEmp.Sorted = True
        cboLogEmp.SelectedIndex = 0
    End Sub

#End Region

#Region " Date/Time ComboBox Events "

    Private Sub cboStartTime_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboStartTime.Leave
        cboStartTime.Text = SngToTime(TimeToSng(cboStartTime.Text))
        cboStopTime.Text = SngToTime(TimeToSng(cboStartTime.Text) + CSng(cboTimeWorked.Text))
    End Sub

    Private Sub cboStopTime_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboStopTime.Leave
        Dim stoptime As Single = TimeToSng(cboStopTime.Text)
        Dim starttime As Single = TimeToSng(cboStartTime.Text)
        Dim hoursworked As Single = stoptime - starttime

        cboStopTime.Text = SngToTime(stoptime)
        If hoursworked > 0 Then
            cboTimeWorked.Text = (hoursworked).ToString("#0.00")
        Else
            cboTimeWorked.Text = ""
            MsgBox("Start time is greater than stop time, please correct.")
        End If
    End Sub

    Private Sub cboTimeWorked_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboTimeWorked.Leave
        cboStopTime.Text = SngToTime(TimeToSng(cboStartTime.Text) + CSng(Val(cboTimeWorked.Text)))
        Me.txtWorkPerf.Focus()
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        If Me.RecordBeingEdited = -1 Then
            cboStartTime.Text = SngToTime(8)
            cboStopTime.Text = SngToTime(9)
            cboTimeWorked.Text = (TimeToSng(cboStopTime.Text) - TimeToSng(cboStartTime.Text)).ToString("#0.00")
        End If

    End Sub

    Private Sub AddWorkRec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtWorkPerf.TextChanged, cboUser.TextChanged, dtpDate.ValueChanged, _
        cboTimeWorked.TextChanged, cboStartTime.TextChanged, cboStopTime.TextChanged


        Me.btnOK.Visible = Not (ControlIsBlank(txtWorkPerf) Or ControlIsBlank(cboUser) Or _
        ControlIsBlank(cboTimeWorked) Or ControlIsBlank(cboStartTime) Or ControlIsBlank(cboStopTime))

    End Sub

    Private Function ControlIsBlank(ByRef ctrl As TextBox) As Boolean
        Return ControlIsBlank(CType(ctrl, Control))
    End Function
    Private Function ControlIsBlank(ByRef ctrl As ComboBox) As Boolean
        Return ControlIsBlank(CType(ctrl, Control))
    End Function
    Private Function ControlIsBlank(ByRef ctrl As Control) As Boolean
        If ctrl.Text = "" Then
            ctrl.BackColor = Color.LightCoral
            Return True
        Else
            ctrl.BackColor = Color.White
            Return False
        End If
    End Function

#End Region

#Region " Listview Events "

#Region " Customer Listview Events "

    Private Sub lvCompanies_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCompanies.ColumnClick
        DontUpdateCategories = True
        lvCompanies.SuspendLayout()
        If lvCompanies.Items(0).Text = "* All *" Then
            lvCompanies.Items(0).Remove()
        End If
        lvCompanies.Sort()
        'lvCompanies.ListViewItemSorter = Nothing
        lvCompanies.Items.Insert(0, "* All *")
        DontUpdateCategories = False
        lvCompanies.ResumeLayout()
        lvCompanies.Items(0).Selected = True
    End Sub

    Private Sub lvCompanies_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lvCompanies.ColumnWidthChanged
        btnNewCo.Left = lvCompanies.Columns(0).Width - btnNewCo.Width - 1
        btnEditCo.Left = lvCompanies.Columns(0).Width - btnEditCo.Width - 1
    End Sub

    Private Sub lvCompanies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompanies.SelectedIndexChanged
        If Not (DontUpdateCategories Or My.Computer.Keyboard.ShiftKeyDown) Then
            UpdateCategoryList()
        End If

        btnEditCo.Hide()
        If lvRecords.Enabled Then
            If DBA.UserType = UserType.Administrator Or DBA.UserType = UserType.Customer Then
                If lvCompanies.SelectedItems.Count = 1 Then
                    If lvCompanies.SelectedItems(0).Text <> "* All *" Then
                        Dim Itm As ListViewItem = lvCompanies.SelectedItems(0)
                        Itm.EnsureVisible()
                        btnEditCo.Top = lvCompanies.Location.Y + Itm.Bounds.Y + (Itm.Bounds.Height - btnEditCo.Height) \ 2 + 1
                        btnEditCo.Show()
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub lvCompanies_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompanies.Resize

    '    Dim w As Integer = lvCompanies.Width
    '    If lvCompanies.Scrollable Then w -= 22
    '    lvCompanies.Columns(0).Width = w

    'End Sub

    Private Sub lvCompanies_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCompanies.KeyDown

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.A 'select all
                    DontUpdateCategories = True
                    lvCompanies.SelectedItems.Clear()
                    DontUpdateCategories = False
                    lvCompanies.Items(0).Selected = True
            End Select
        End If
    End Sub

    Private Sub lvCompanies_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCompanies.KeyUp
        If e.KeyCode = Keys.ShiftKey Then
            UpdateCategoryList()
        End If

    End Sub

    Private Sub lvCompanies_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCompanies.MouseWheel
        btnEditCo.Hide()
    End Sub

    Private Sub UpdateCompanyList()
        DontUpdateCategories = True
        lvCompanies.SelectedItems.Clear()
        DontUpdateCategories = False
        lvCompanies.Items.Clear()

        'Select Case DBA.UserType
        '    Case UserType.Administrator 'add all companies
        '        lvCompanies.Items.AddRange(DBA.GetListViewItems("Companies", "*", False, "Company"))
        '    Case UserType.Customer 'Add current user's company
        '        lvCompanies.Items.AddRange(DBA.GetListViewItems("Companies", "Company='" + DBA.UserCompany + "'", False, "Company"))
        '        lvCompanies.Items(0).Selected = True
        '        SplitContainer5.Panel1Collapsed = True
        '        Exit Sub
        '    Case UserType.Employee 'Add all companies which have the current user listed in their "AllowedUsers" field
        '        lvCompanies.Items.AddRange(DBA.GetUserListViewItems("Companies", DBA.User, "AllowedUsers", "*", "Company"))
        'End Select
        lvCompanies.Items.AddRange(DBA.GetListViewItems("Companies", "*", False, "Company"))

        lvCompanies.Sort()
        'lvCompanies.ListViewItemSorter = Nothing
        If lvCompanies.Items.Count > 1 Then
            lvCompanies.Items.Insert(0, "* All *")
        End If
        lvCompanies.Items(0).Selected = True
    End Sub

    Private Sub lvCompanies_OnScroll() Handles lvCompanies.OnHScroll, lvCompanies.OnVScroll
        btnEditCo.Hide()
    End Sub

#End Region

#Region " Project Listview Events "

    Private Sub lvCategories_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCategories.ColumnClick
        UpdateCategoryList()
    End Sub

    Private Sub lvCategories_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lvCategories.ColumnWidthChanged
        btnNewCat.Left = lvCategories.Columns(Me.ColCategory_Name.Index).Width - btnNewCat.Width - 1
        btnEditCat.Left = lvCategories.Columns(Me.ColCategory_Name.Index).Width - btnEditCat.Width - 1
    End Sub

    Private Sub lvCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCategories.SelectedIndexChanged
        If Not (DontUpdateJobs Or My.Computer.Keyboard.ShiftKeyDown) Then
            UpdateJobList()
        End If
        btnEditCat.Hide()
        If lvRecords.Enabled Then
            If lvCategories.SelectedItems.Count = 1 Then
                Dim Itm As ListViewItem = lvCategories.SelectedItems(0)
                Itm.EnsureVisible()
                If Itm.SubItems(Me.ColCategory_Name.Index).Text <> "* All *" Then
                    Select Case DBA.UserType
                        Case UserType.Administrator, UserType.Customer
                            btnEditCat.Top = lvCategories.Location.Y + Itm.Bounds.Y + _
                                    (Itm.Bounds.Height - btnEditCat.Height) \ 2 + 1
                            btnEditCat.Show()
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub lvCategories_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCategories.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.A 'select all
                    DontUpdateJobs = True
                    lvCategories.SelectedItems.Clear()
                    DontUpdateJobs = False
                    lvCategories.Items(0).Selected = True
            End Select
        End If
    End Sub

    Private Sub lvCategories_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCategories.KeyUp
        If e.KeyCode = Keys.ShiftKey Then
            UpdateJobList()
        End If
    End Sub

    Private Sub lvCategories_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCategories.MouseWheel
        btnEditCat.Hide()
    End Sub

    Private Sub lvCategories_OnScroll() Handles lvCategories.OnHScroll, lvCategories.OnVScroll
        btnEditCat.Hide()
    End Sub

    'Private Sub lvCategories_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCategories.Resize
    '    Dim w As Integer = lvCategories.Width
    '    If lvCategories.Scrollable Then w -= 22

    '    lvCategories.Columns(Me.ColCategory_Name.Index).Width = w - lvCategories.Columns(Me.ColCategory_Company.Index).Width
    'End Sub

    Private Sub UpdateCategoryList()
        DontUpdateJobs = True
        lvCategories.SelectedItems.Clear()
        If DontUpdateCategories Then Exit Sub
        DontUpdateJobs = False
        lvCategories.Items.Clear()

        If lvCompanies.SelectedItems.Count > 0 Then
            Dim FilterExp As String
            Dim i As Integer

            If lvCompanies.SelectedItems(0).Text = "* All *" Then
                'build filter from all listed companies
                FilterExp = String.Format("(Company IN ('{0}'", lvCompanies.Items(1).Text)
                For i = 2 To lvCompanies.Items.Count - 1
                    FilterExp += String.Format(",'{0}'", lvCompanies.Items(i).Text)
                Next
            Else
                'build filter from selected companies
                FilterExp = String.Format("(Company IN ('{0}'", lvCompanies.SelectedItems(0).Text)
                For i = 1 To lvCompanies.SelectedItems.Count - 1
                    FilterExp += String.Format(",'{0}'", lvCompanies.SelectedItems(i).Text)
                Next
            End If
            FilterExp += "))"

            lvCategories.Items.AddRange(DBA.GetListViewItems("Categories", FilterExp, True, "CategoryID", _
                  "CategoryName", "Company"))

            If Not Me.chkShowAllCat.Checked Then
                Dim cnt As Integer = lvCategories.Items.Count
                Dim filter As String = "Status IN (" + clbStatus.Tag.ToString + ")"
                For i = cnt - 1 To 0 Step -1
                    If DBA.GetJobCount(CInt(lvCategories.Items(i).Tag), filter) < 1 Then
                        lvCategories.Items.RemoveAt(i)
                    End If
                Next
            End If

        End If

        lvCategories.Sort()
        'lvCategories.ListViewItemSorter = Nothing

        If lvCategories.Items.Count = 0 Then
            UpdateJobList()
        Else
            lvCategories.Items.Insert(0, "* All *").SubItems.AddRange(New String() {""})
            Do While lvCategories.Items.Count > 0
                Try
                    lvCategories.Items(0).Selected = True
                    Exit Do
                Catch ex As Exception

                End Try
            Loop

        End If

    End Sub

#End Region

#Region " Task Listview Events "

    Private Sub lvJobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvJobs.Click
        If btnStatus.ImageIndex = 1 Then
            btnStatus.PerformClick()
        End If
    End Sub

    Private Sub lvJobs_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvJobs.ColumnClick
        UpdateJobList()
    End Sub

    Private Sub lvJobs_OnScroll() Handles lvJobs.OnHScroll, lvJobs.OnVScroll
        btnEditJob.Hide()
        btnAddRecord.Hide()
        btnCloseJob.Hide()
        btnQuote.Hide()
        btnRevQuote.Hide()
        btnChangeJob.Hide()
    End Sub

    Private Sub lvJobs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvJobs.KeyPress
        If My.Computer.Keyboard.CtrlKeyDown Then
            Select Case e.KeyChar
                Case "a"c, "A"c 'select all
                    DontUpdateRecords = True
                    lvJobs.SelectedItems.Clear()
                    DontUpdateRecords = False
                    lvJobs.Items(0).Selected = True
            End Select
        End If

    End Sub

    Private Sub lvJobs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvJobs.KeyUp
        If e.KeyCode = Keys.ShiftKey Then
            UpdateLog(True)
        End If
    End Sub

    Private Sub lvJobs_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvJobs.MouseWheel
        HideJobButtons()
    End Sub

    Private Sub lvJobs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvJobs.SelectedIndexChanged

        HideJobButtons()

        If lvJobs.SelectedItems.Count = 1 Then
            Dim Itm As ListViewItem = lvJobs.SelectedItems(0)
            Itm.EnsureVisible()
            If Itm.Text <> "* All *" Then
                Dim Stat As String = Itm.SubItems(Me.ColJobs_Status.Index).Text.ToUpper
                Dim y As Integer = lvJobs.Location.Y + Itm.SubItems(Me.ColJobs_Status.Index).Bounds.Y + _
                                  (Itm.Bounds.Height - btnAddRecord.Height) \ 2 + 1

                btnEditJob.Top = y
                btnRevQuote.Top = y
                btnAddRecord.Top = y
                btnCloseJob.Top = y
                btnReopenJob.Top = y
                btnChangeJob.Top = y
                btnQuote.Top = y
                'btnViewJob.Top = y

                Select Case DBA.UserType
                    Case UserType.Administrator
                        If lvRecords.Enabled Then
                            Select Case Stat
                                Case "AWAITING APPROVAL"
                                    If lvRecords.Enabled Then btnRevQuote.Show()
                                Case "COMPLETE"
                                    btnReopenJob.Show()
                                Case "OPEN", "AWAITING QUOTE", "ON HOLD"
                                    btnEditJob.Show()
                                    If Stat = "OPEN" Then
                                        btnAddRecord.Show()
                                    End If
                            End Select
                        Else
                            btnChangeJob.Show()
                        End If

                    Case UserType.Customer

                        If lvRecords.Enabled Then
                            Select Case Stat
                                Case "AWAITING APPROVAL"
                                    btnRevQuote.Show()
                                Case "COMPLETE"
                                    btnReopenJob.Show()
                                Case "OPEN", "AWAITING QUOTE", "ON HOLD"
                                    btnEditJob.Show()
                                    If Stat = "OPEN" Then
                                        btnCloseJob.Show()
                                    End If
                            End Select
                        Else
                            'Show no buttons 
                        End If

                    Case UserType.Employee
                        If lvRecords.Enabled Then
                            Select Case Stat
                                Case "OPEN"
                                    btnAddRecord.Show()

                                    'changed on 7/31/07 per BEZ request
                                    'btnViewJob.Show()
                                    btnEditJob.Show()

                                Case "AWAITING QUOTE"
                                    btnQuote.Show()
                                Case "AWAITING APPROVAL", "COMPLETE", "ON HOLD"

                            End Select
                        Else
                            btnChangeJob.Show()
                        End If
                End Select
            End If
        End If

        If Not (DontUpdateRecords Or My.Computer.Keyboard.ShiftKeyDown) Then
            If lvRecords.Enabled Then
                UpdateLog(True)
            End If

        End If
    End Sub

    'Private Sub lvJobs_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvJobs.Resize
    '    Dim w As Integer = lvJobs.Width
    '    If lvJobs.Scrollable Then w -= 22
    '    For i As Integer = 1 To lvJobs.Columns.Count - 1
    '        w -= lvJobs.Columns(i).Width
    '    Next
    '    lvJobs.Columns(Me.ColJobs_Description.Index).Width = w
    'End Sub

    Private Sub lvJobs_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lvJobs.ColumnWidthChanged
        Dim l As Integer = Me.ColJobs_Description.Width + 1
        Me.btnStatus.Left = l - 2 + Me.ColJobs_Status.Width - Me.btnStatus.Width
        Me.clbStatus.Left = Me.btnStatus.Right - Me.clbStatus.Width

        btnNewJob.Left = l - btnNewJob.Width - 2
        btnEditJob.Left = l
        'btnViewJob.Left = l
        btnReopenJob.Left = l
        btnChangeJob.Left = l
        btnQuote.Left = l
        btnEditJob.Left = l
        btnRevQuote.Left = l
        btnAddRecord.Left = l + btnEditJob.Width + 2
        btnCloseJob.Left = l + btnEditJob.Width + 2

    End Sub

    Public Sub UpdateJobList()
        DontUpdateRecords = True
        lvJobs.SelectedItems.Clear()
        If DontUpdateJobs Then Exit Sub
        DontUpdateRecords = False
        lvJobs.Items.Clear()
        If Me.clbStatus.CheckedItems.Count = 0 Then Exit Sub

        If lvCategories.SelectedItems.Count > 0 And lvCategories.Items.Count > 1 Then
            Dim FilterExp As String = ""
            Dim i As Integer

            FilterExp = "(CategoryID IN ("
            If lvCategories.SelectedItems(0).Text = "* All *" Then
                FilterExp += lvCategories.Items(1).Tag.ToString
                For i = 2 To lvCategories.Items.Count - 1
                    FilterExp += "," + lvCategories.Items(i).Tag.ToString
                Next
            Else
                FilterExp += lvCategories.SelectedItems(0).Tag.ToString
                For i = 1 To lvCategories.SelectedItems.Count - 1
                    FilterExp += "," + lvCategories.SelectedItems(i).Tag.ToString
                Next
            End If
            FilterExp += "))"

            'Include status filter settings
            FilterExp += String.Format(" AND (Status IN ({0}))", Me.clbStatus.Tag) 'Me.clbStatus.CheckedItems(0).ToString)
            'For i = 1 To Me.clbStatus.CheckedItems.Count - 1
            '    FilterExp += String.Format(",'{0}'", Me.clbStatus.CheckedItems(i).ToString)
            'Next
            'FilterExp += "))"

            'Select Case DBA.UserType
            '    Case UserType.None
            '        Exit Sub
            '    Case UserType.Administrator
            '        'do not filter
            '    Case UserType.Customer
            '        FilterExp += " AND Status<>'Complete'"
            '    Case UserType.Employee 'show only 'open' items
            '        FilterExp += " AND (Status='Open' OR Status='Awaiting Quote')"
            'End Select

            lvJobs.Items.AddRange(DBA.GetListViewItems("Jobs", FilterExp, True, "JobID", "Description", "Status", _
                                  "Priority", "Billable", "Categories.Company", "Categories.CategoryName", "AccountingID"))
        End If
        Application.DoEvents()
        lvJobs.Sort()
        'lvJobs.ListViewItemSorter = Nothing

        If lvJobs.Items.Count = 0 Then
            UpdateLog(True)
        Else
            lvJobs.Items.Insert(0, "* All *").SubItems.AddRange(New String() {"", "", "", "", "", ""})
            lvJobs.Items(0).Selected = True

        End If

        If lvCategories.SelectedItems.Count = 1 AndAlso lvCategories.SelectedItems(0).Text <> "* All *" Then
            Me.btnNewJob.Visible = True
        Else
            Me.btnNewJob.Visible = False
        End If
    End Sub

#End Region

#Region " Record Listview Events "

    Private Sub UpdateLog(ByVal RefetchData As Boolean)

        If Not lvRecords.Enabled Or DontUpdateRecords Then Exit Sub

        lvRecords.Hide()
        lvRecords.SuspendLayout()
        Me.Cursor = Cursors.WaitCursor
        lvRecords.Groups.Clear()

        Dim i As Integer
        Dim gname As String = ""
        Dim GroupByTag As Boolean = True
        Dim g As New ListViewGroup("", "")
        Dim Hrs As Single = 0.0F

        If RefetchData Then FetchWorkRecords()
        If lvRecords.SortColumn = ColDate.Index Then
            GroupByTag = False
        End If

        'Sort and group items, if needed
        If lvRecords.Items.Count > 0 Then
            'Sort Items
            lvRecords.Sort()
            If chkSummaries.Checked Then
                Select Case lvRecords.SortColumn
                    'only allow grouping on certain sortcolumns
                    Case ColDate.Index, ColEmployee.Index, ColJob.Index, ColCategory.Index, ColCompany.Index
                        For i = 0 To lvRecords.Items.Count - 1
                            gname = GetGroupName(i, GroupByTag)
                            If gname <> g.Name Then 'Create a new group
                                g.Header += " (" + Hrs.ToString("0.##") + " hours)"
                                g.Tag = Hrs
                                Hrs = 0.0F
                                g = lvRecords.Groups.Add(gname, gname)
                            End If
                            Hrs += CSng(lvRecords.Items(i).SubItems(Me.ColHours.Index).Text)
                            g.Items.Add(lvRecords.Items(i))
                        Next
                        g.Header += " (" + Hrs.ToString("0.##") + " hours)"
                        g.Tag = Hrs
                    Case Else
                End Select
            End If
        End If

        If Not DBA Is Nothing AndAlso DBA.Dirty = True Then
            If Me.btnSendUpdates.Enabled = False Then
                Me.flashCount = 0
                Me.tmrFlashButton.Start()
            End If
            Me.btnSendUpdates.Enabled = True
            Me.ToolTip1.SetToolTip(Me.btnSendUpdates, DBA.Changes)
        Else
            Me.btnSendUpdates.Enabled = False
        End If


        Me.Cursor = Cursors.Default
        lvRecords.ResumeLayout()
        lvRecords.Show()
    End Sub

    Private Function GetRecordFilter() As String
        Dim i As Integer
        Dim FilterExp As New System.Text.StringBuilder
        Dim Temp As String
        Dim TempDt As Date
        'Dim DR As DataRow
        TempDt = dtpLogDateBegin.Value
        Dim StartDt As Integer = CInt(TempDt.Year.ToString("0000") + TempDt.Month.ToString("00") + TempDt.Day.ToString("00"))
        TempDt = dtpLogDateEnd.Value
        Dim StopDt As Integer = CInt(TempDt.Year.ToString("0000") + TempDt.Month.ToString("00") + TempDt.Day.ToString("00"))
        FilterExp.Append("(DateWorked >= " + StartDt.ToString + ") AND (DateWorked <= " + StopDt.ToString + ")")
        If cboLogEmp.Text = "* All *" Then

            If cboLogEmp.Items.Count > 1 Then
                Temp = cboLogEmp.Items(1).ToString
                Temp = Temp.Substring(0, Temp.IndexOf(" "c))
            End If


            FilterExp.Append(" AND (UserName IN ('" + Temp + "'")
            For i = 2 To cboLogEmp.Items.Count - 1
                Temp = cboLogEmp.Items(i).ToString
                Temp = Temp.Substring(0, Temp.IndexOf(" "c))
                FilterExp.Append(",'" + Temp + "'")
            Next
            FilterExp.Append(")")
        Else
            Temp = cboLogEmp.Text
            Temp = Temp.Substring(0, Temp.IndexOf(" "c))
            FilterExp.Append(" AND (UserName='" + Temp + "'")
        End If
        FilterExp.Append(")")

        Dim Jobfilter As String = " AND (JobID IN ("

        If lvJobs.Items(0).Selected Then
            Jobfilter += lvJobs.Items(1).Tag.ToString
            For i = 2 To lvJobs.Items.Count - 1
                If IsNumeric(lvJobs.Items(i).Tag.ToString) Then
                    Jobfilter += "," + lvJobs.Items(i).Tag.ToString
                End If
            Next
        Else
            Jobfilter += lvJobs.SelectedItems(0).Tag.ToString
            For i = 1 To lvJobs.SelectedItems.Count - 1
                If IsNumeric(lvJobs.SelectedItems(i).Tag.ToString) Then
                    Jobfilter += "," + lvJobs.SelectedItems(i).Tag.ToString
                End If
            Next
        End If
        Jobfilter += "))"
        If Jobfilter.IndexOf("*") >= 0 Then
            Return ""
        End If

        FilterExp.Append(Jobfilter)

        Return FilterExp.ToString

    End Function

    Private Sub FetchWorkRecords()
        lvRecords.Items.Clear()

        If lvJobs.SelectedItems.Count <> 0 Then

            Dim LI As ListViewItem
            Dim Rec, User, Job, Cat As DataRow
            Dim Temp As String
            Dim BillableRatio As Single
            Dim RecRows As DataRow()

            Try
                RecRows = DBA.GetDataRows("Records", GetRecordFilter())

                For Each Rec In RecRows
                    User = DBA.GetDataRow("Users", Rec("Username"))
                    Job = DBA.GetDataRow("Jobs", CInt(Rec("JobID")))
                    Cat = DBA.GetDataRow("Categories", Job("CategoryID"))
                    LI = lvRecords.Items.Add("")
                    LI.Tag = Rec("ID").ToString
                    LI.SubItems.AddRange(New String() {"", "", "", "", "", "", "", "", ""})
                    'Date
                    Temp = Rec("DateWorked").ToString + CInt(Rec("StartTime")).ToString("0000")
                    LI.SubItems(Me.ColDate.Index).Text = Strings.Mid(Temp, 5, 2) + "/" + Strings.Mid(Temp, 7, 2) + "/" + Strings.Mid(Temp, 1, 4) 'Formatted Date mm/dd/yy
                    LI.SubItems(Me.ColDate.Index).Tag = Temp

                    'Reformat Start Time
                    Temp = CInt(Rec("StartTime")).ToString("0000")
                    LI.SubItems(Me.ColStart.Index).Tag = Temp '24 hr
                    LI.SubItems(Me.ColStart.Index).Text = Strings.Left(Temp, 2) + ":" + Strings.Right(Temp, 2) '12 hr

                    'Reformat Stop Time
                    Temp = CInt(Rec("StopTime")).ToString("0000")
                    LI.SubItems(Me.ColStop.Index).Tag = Temp '24 hr
                    LI.SubItems(Me.ColStop.Index).Text = Strings.Left(Temp, 2) + ":" + Strings.Right(Temp, 2) '12 hr

                    'Hours
                    LI.SubItems(Me.ColHours.Index).Text = CSng(Rec("HoursWorked")).ToString("0.##")
                    LI.SubItems(Me.ColHours.Index).Tag = CSng(Rec("HoursWorked")).ToString("0.##")

                    'Format Employee
                    LI.SubItems(Me.ColEmployee.Index).Text = String.Format("{0} {1}", User("FirstName"), User("LastName"))
                    LI.SubItems(Me.ColEmployee.Index).Tag = String.Format("{0} {1} ({2})", User("FirstName"), User("LastName"), Rec("Username"))

                    'Set Company
                    LI.SubItems(Me.ColCompany.Index).Text = String.Format("{0}", Cat("Company")) 'Company
                    LI.SubItems(Me.ColCompany.Index).Tag = String.Format("{0}", Cat("Company")) 'Company

                    'Set Project
                    LI.SubItems(Me.ColCategory.Index).Text = String.Format("{0}", Cat("CategoryName")) 'CategoryName
                    LI.SubItems(Me.ColCategory.Index).Tag = String.Format("{0} :: {1}-{2}", Cat("Company"), Cat("CategoryID"), Cat("CategoryName")) 'Company :: CategoryName

                    'Set Job
                    BillableRatio = 0.0F
                    LI.SubItems(Me.ColJob.Index).Text = String.Format("{0}", Job("Description"))
                    Dim jobstring As String = String.Format("{0} :: {1}-{2} :: {3}-{4}", Cat("Company"), _
                        Cat("CategoryID"), Cat("CategoryName"), Rec("JobID"), Job("Description")) 'Company :: CategoryName :: Job
                    If Not Job("AccountingID") Is DBNull.Value AndAlso CStr(Job("AccountingID")).Trim <> "" Then
                        jobstring += ", ID#" + CStr(Job("AccountingID")).Trim
                    End If
                    If Job("Billable") Is DBNull.Value Then
                        jobstring += " - Billable?"

                    Else
                        Select Case CStr(Job("Billable"))
                            Case "S"
                                jobstring += " - Split Billing"
                                BillableRatio = 0.5F
                            Case "B"
                                jobstring += " - Billable"
                                BillableRatio = 1.0F
                            Case "N"
                                jobstring += " - Not Billable"
                            Case Else
                                jobstring += " - Billable?"
                        End Select
                    End If

                    LI.SubItems(Me.ColJob.Index).Tag = jobstring

                    'Hours
                    LI.SubItems(Me.colBillHours.Index).Text = (CSng(Rec("HoursWorked")) * BillableRatio).ToString("0.##")
                    LI.SubItems(Me.colBillHours.Index).Tag = (CSng(Rec("HoursWorked")) * BillableRatio).ToString("0.##")

                    'Set Work Description
                    LI.SubItems(Me.ColWorkDescr.Index).Text = Rec("WorkDescription").ToString
                    LI.SubItems(Me.ColWorkDescr.Index).Tag = Rec("WorkDescription").ToString

                Next 'RecRow In DBA.GetDataRows("Records", GetRecordFilter)

            Catch ex As Exception
                MessageBox.Show("There was a problem fetching work records: " + vbCrLf + ex.Message)
            End Try

        End If 'lvJobs.SelectedItems.Count <> 0
    End Sub

    Private Sub lvRecords_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) _
    Handles lvRecords.ColumnClick
        'If e.Column = ColDate.Index And lvRecords.SortColumn = ColLongDate.Index Then
        '    If lvRecords.Sorting = SortOrder.Ascending Then
        '        lvRecords.Sorting = SortOrder.Descending
        '    Else
        '        lvRecords.Sorting = SortOrder.Ascending
        '    End If
        'End If
        UpdateLog(False)
    End Sub

    Private Sub ChangeFilterSettings(ByVal sender As Object, ByVal e As EventArgs) _
    Handles dtpLogDateBegin.ValueChanged, dtpLogDateEnd.ValueChanged, cboLogEmp.SelectedIndexChanged, chkSummaries.CheckedChanged
        UpdateLog(True)
    End Sub

    Private Sub lvRecords_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lvRecords.ColumnWidthChanged
        'If e.ColumnIndex <> lvRecords.Columns.Count - 1 Then
        Dim w As Integer = lvRecords.Width - 21
        pnlEditRecord.Width = w
        'For i As Integer = 0 To lvRecords.Columns.Count - 2 '-3
        '    w -= lvRecords.Columns(i).Width
        'Next
        ''Set last column
        'If w > 0 Then lvRecords.Columns(Me.ColWorkDescr.Index).Width = w '\ 3
        ''resize pnlEditRecord controls
        ''dtpDate.Width = ColDate.Width + 1
        ''cboUser.Width = ColEmployeeName.Width
        ''cboStartTime.Width = ColStart.Width + 1
        ''cboStopTime.Width = ColStop.Width
        ''lblCompany.Width = ColCompany.Width + 1
        ''lblCategory.Width = ColCategory.Width
        ''lblJobID.Width = ColJobID.Width + 1
        ''lblJobDescr.Width = ColJobDescr.Width
        ''pnlEditRecord.Width = lblJobDescr.Left + lblJobDescr.Width + 1
        'End If
    End Sub

    Private Sub lvRecords_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRecords.Resize
        lvRecords_ColumnWidthChanged(sender, New ColumnWidthChangedEventArgs(0))
    End Sub

    Private Sub lvRecords_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRecords.EnabledChanged
        Me.btnNewCat.Enabled = Me.lvRecords.Enabled
        Me.btnNewCo.Enabled = Me.lvRecords.Enabled
        Me.btnNewJob.Enabled = Me.lvRecords.Enabled
    End Sub

    Private Sub lvRecords_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRecords.MouseDoubleClick

        If DBA.UserType = UserType.Administrator Or DBA.UserType = UserType.Employee Then
            Dim Itm As ListViewItem = lvRecords.GetItemAt(e.X, e.Y)

            If Itm Is Nothing Then Exit Sub

            lvRecords.Enabled = False

            'Position the editing panel beneath the last listitem
            Dim p As Point = lvRecords.Location
            p.Offset(Itm.Bounds.Location)
            If p.Y + pnlEditRecord.Height > lvRecords.Top + lvRecords.Height Then
                p.Y = lvRecords.Top + lvRecords.Height - pnlEditRecord.Height
            End If
            pnlEditRecord.Location = p

            RecordBeingEdited = CInt(Itm.Tag)

            Me.dtpDate.Value = CDate(Itm.SubItems(Me.ColDate.Index).Text)

            Dim temp As String = Itm.SubItems(Me.ColEmployee.Index).Tag.ToString
            temp = temp.Substring(0, temp.Length - 1)
            temp = temp.Substring(temp.LastIndexOf("("c) + 1)
            Me.cboUser.Text = temp

            Me.cboStartTime.Text = CDate(Itm.SubItems(Me.ColStart.Index).Text).ToShortTimeString
            Me.cboStopTime.Text = CDate(Itm.SubItems(Me.ColStop.Index).Text).ToShortTimeString
            Me.cboTimeWorked.Text = Itm.SubItems(Me.ColHours.Index).Text
            Me.lblCompany.Text = Itm.SubItems(Me.ColCompany.Index).Text
            Me.lblCategory.Text = Itm.SubItems(Me.ColCategory.Index).Text

            Me.lblJobDescr.Text = Itm.SubItems(Me.ColJob.Index).Text
            temp = Itm.SubItems(Me.ColJob.Index).Tag.ToString
            temp = temp.Substring(temp.LastIndexOf(" :: ") + 4)
            temp = temp.Substring(0, temp.IndexOf("-"c))
            Me.lblJobDescr.Tag = CInt(temp)
            Me.txtWorkPerf.Text = Itm.SubItems(Me.ColWorkDescr.Index).Text
            Me.btnOK.Text = "Update"
            Me.btnDelRec.Visible = True
            pnlEditRecord.BringToFront()
            pnlEditRecord.Show()
        End If


    End Sub

    Private Function GetGroupName(ByVal row As Integer, ByVal NameIsTag As Boolean) As String
        If NameIsTag Then
            Return lvRecords.Items(row).SubItems(lvRecords.SortColumn).Tag.ToString
        Else
            Return lvRecords.Items(row).SubItems(lvRecords.SortColumn).Text
        End If

    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        pnlEditRecord.Hide()
        btnAddRecord.Hide()
        btnCloseJob.Hide()
        btnChangeJob.Hide()
        lvRecords.Enabled = True
        Dim n As Integer

        Dim NR As DataRow
        If RecordBeingEdited = -1 Then
            'Add a new datarow
            NR = DBA.DataSet.Tables("Records").NewRow
            NR.BeginEdit()
            Dim Changed As Boolean = LoadLogRowItems(NR)
            If Not Changed Then
                NR.RejectChanges()
            End If
            NR.EndEdit()
            DBA.DataSet.Tables("Records").Rows.Add(NR)
            n = CInt(NR.Item(0))
            'cboStartTime.Text = cboStopTime.Text
            'cboTimeWorked.Text = "1"
            'cboTimeWorked_Leave(cboTimeWorked, New EventArgs)
            Me.LastDateAdded = Me.dtpDate.Value
            Me.LastStopTimeAdded = TimeToSng(Me.cboStopTime.Text)
        Else
            n = RecordBeingEdited
            NR = DBA.GetDataRow("Records", n)
            NR.BeginEdit()
            If Not LoadLogRowItems(NR) Then
                NR.RejectChanges()
            End If
            NR.EndEdit()
        End If

        RecordBeingEdited = -1

        UpdateLog(True)
        Dim i As Integer
        For i = 0 To lvRecords.Items.Count - 1
            If lvRecords.Items(i).Text = n.ToString Then
                lvRecords.Items(i).Selected = True
            End If
        Next

        lvRecords.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlEditRecord.Hide()
        lvRecords.Enabled = True
        btnAddRecord.Hide()
        btnCloseJob.Hide()
        btnChangeJob.Hide()
        lvRecords.Focus()
        RecordBeingEdited = -1
    End Sub

    Private Sub btnDelRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelRec.Click
        pnlEditRecord.Hide()
        btnAddRecord.Hide()
        btnCloseJob.Hide()
        btnChangeJob.Hide()
        DBA.GetDataRow("Records", RecordBeingEdited).Delete()
        RecordBeingEdited = -1
        lvRecords.Enabled = True
        UpdateLog(True)
        lvRecords.Focus()
    End Sub

    Private Function LoadLogRowItems(ByRef DtRw As DataRow) As Boolean
        Dim Changed As Boolean = False
        Changed = Changed Or CompareAndChange(DtRw("DateWorked"), CInt(Me.dtpDate.Value.ToString("yyyyMMdd")))
        Changed = Changed Or CompareAndChange(DtRw("StartTime"), CInt(CDate(Me.cboStartTime.Text).ToString("HHmm")))
        Changed = Changed Or CompareAndChange(DtRw("StopTime"), CInt(CDate(Me.cboStopTime.Text).ToString("HHmm")))
        Changed = Changed Or CompareAndChange(DtRw("Username"), Me.cboUser.Text)
        Changed = Changed Or CompareAndChange(DtRw("HoursWorked"), CSng(Me.cboTimeWorked.Text))
        'Dim temp As String = Me.lblJobDescr.Text
        'temp = temp.Substring(0, temp.Length - 1)
        'temp = temp.Substring(temp.LastIndexOf("("c) + 1)
        Changed = Changed Or CompareAndChange(DtRw("JobID"), CInt(Me.lblJobDescr.Tag))
        Changed = Changed Or CompareAndChange(DtRw("WorkDescription"), Me.txtWorkPerf.Text)
        Return Changed
    End Function

#End Region

#Region " ListView-Associated Button Events "

#Region " Task Button Events "

    Private Sub HideJobButtons()
        btnChangeJob.Hide()
        btnAddRecord.Hide()
        btnCloseJob.Hide()
        btnReopenJob.Hide()
        btnQuote.Hide()
        btnEditJob.Hide()
        btnRevQuote.Hide()
        'changed on 7/31/07 per BEZ request
        'btnViewJob.Hide()
        Application.DoEvents()
    End Sub

    Private Sub btnAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRecord.Click
        HideJobButtons()

        Me.lvRecords.Enabled = False
        'Position the editing panel beneath the last listitem
        Dim p As Point = Me.lvRecords.Location
        p.Offset(0, 25)
        If Me.lvRecords.Items.Count > 0 Then
            Me.lvRecords.Items(Me.lvRecords.Items.Count - 1).EnsureVisible()
            p.Offset(Me.lvRecords.Items(Me.lvRecords.Items.Count - 1).Bounds.Location)
        End If
        If p.Y + Me.pnlEditRecord.Height > Me.lvRecords.Top + Me.lvRecords.Height Then
            p.Y = Me.lvRecords.Top + Me.lvRecords.Height - Me.pnlEditRecord.Height
        End If
        Me.pnlEditRecord.Location = p
        Me.cboUser.Text = DBA.User
        Me.txtWorkPerf.Text = ""
        Me.btnOK.Text = "Add"
        Me.btnDelRec.Visible = False
        Me.pnlEditRecord.BringToFront()
        Me.pnlEditRecord.Show()

        'Fill in the data items
        Me.lblCompany.Text = Me.lvJobs.SelectedItems(0).SubItems(Me.ColJobs_Company.Index).Text
        Me.lblCategory.Text = Me.lvJobs.SelectedItems(0).SubItems(Me.ColJobs_Category.Index).Text
        'lblJobID.Text =  Me.lvJobs.SelectedItems(0).Text
        Me.lblJobDescr.Tag = Me.lvJobs.SelectedItems(0).Tag
        Me.lblJobDescr.Text = Me.lvJobs.SelectedItems(0).SubItems(Me.ColJobs_Description.Index).Text '+ " (" + lvJobs.SelectedItems(0).Text + ")"


        Me.dtpDate.Value = Me.LastDateAdded
        Me.cboStartTime.Text = SngToTime(Me.LastStopTimeAdded)
        Me.cboTimeWorked.Text = "0.25"
        Me.cboTimeWorked_Leave(Me.cboTimeWorked, New EventArgs)

    End Sub

    Private Sub btnNewJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewJob.Click
        Dim CatID As Integer = -1
        'Dim Company As String = DBA.UserCompany

        If Me.lvCategories.SelectedItems.Count = 1 AndAlso Me.lvCategories.SelectedItems(0).Text <> "* All *" Then
            CatID = CInt(Me.lvCategories.SelectedItems(0).Tag)
            'Company = Me.lvCategories.SelectedItems(0).SubItems(Me.ColCategory_Company.Index).Text

        Else
            Exit Sub
        End If

        Dim Md As JobEditMode = JobEditMode.Edit
        If DBA.UserType = UserType.Administrator Then Md = JobEditMode.Administrator

        'Dim NJ As New frmJob(CatID, Company, CatID, Md)
        Dim NJR As DataRow = DBA.DataSet.Tables("Jobs").NewRow()
        Dim JID As Integer = CInt(NJR.Item("JobID"))
        NJR("CategoryID") = CatID
        Select Case DBA.UserType
            Case UserType.Administrator, UserType.Employee
                NJR("Status") = "Open"
            Case UserType.Customer
                NJR("Status") = "Awaiting Quote"
        End Select

        DBA.DataSet.Tables("Jobs").Rows.Add(NJR)

        Dim NJ As New frmJob(JID, Md)
        If NJ.ShowDialog = Windows.Forms.DialogResult.OK Then
            NJ.AddNewJob()
            UpdateJobList()
            Me.lvJobs.SelectedItems.Clear()
            Me.lvJobs.FindItemWithText(CStr(DBA.GetDataRow("Jobs", JID).Item("Description"))).Selected = True
            Me.lvJobs.Select()
            UpdateLog(True)
        Else
            DBA.DataSet.Tables("Jobs").Rows.Remove(DBA.GetDataRow("Jobs", JID))
        End If
        NJ.Dispose()

    End Sub

    Private Sub btnChangeJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeJob.Click
        HideJobButtons()

        lblCompany.Text = lvJobs.SelectedItems(0).SubItems(Me.ColJobs_Company.Index).Text
        lblCategory.Text = lvJobs.SelectedItems(0).SubItems(Me.ColJobs_Category.Index).Text
        'lblJobID.Text = lvJobs.SelectedItems(0).Text
        'lblJobDescr.Text = lvJobs.SelectedItems(0).SubItems(Me.ColJobs_Description.Index).Text
        lblJobDescr.Text = lvJobs.SelectedItems(0).SubItems(Me.ColJobs_Description.Index).Text '+ " (" + lvJobs.SelectedItems(0).Text + ")"
        lblJobDescr.Tag = CInt(lvJobs.SelectedItems(0).Tag)

    End Sub

    Private Sub btnEditJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditJob.Click
        HideJobButtons()
        Dim Md As JobEditMode = JobEditMode.Edit
        If DBA.UserType = UserType.Administrator Then Md = JobEditMode.Administrator

        Dim EJ As New frmJob(CInt(Me.lvJobs.SelectedItems(0).Tag), Md)
        If EJ.ShowDialog = Windows.Forms.DialogResult.OK Then
            EJ.UpdateJob()
            UpdateJobList()
        End If
    End Sub

    Private Sub btnQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuote.Click
        HideJobButtons()
        Dim EJ As New frmJob(CInt(Me.lvJobs.SelectedItems(0).Tag), JobEditMode.SubmitQuote)
        If EJ.ShowDialog = Windows.Forms.DialogResult.OK Then
            EJ.AddQuoteToJob()
            UpdateJobList()
        End If
    End Sub

    Private Sub btnRevQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevQuote.Click
        HideJobButtons()
        Dim JID As Integer = CInt(Me.lvJobs.SelectedItems(0).Tag)
        Dim EJ As New frmJob(JID, JobEditMode.ReviewQuote)
        If EJ.ShowDialog = Windows.Forms.DialogResult.OK Then
            EJ.AcceptJobQuote()
            UpdateJobList()
        Else

        End If
    End Sub

    Private Sub btnCloseJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseJob.Click
        HideJobButtons()
        Dim DR As DataRow = DBA.GetDataRow("Jobs", CInt(Me.lvJobs.SelectedItems(0).Tag))
        DR.BeginEdit()
        Dim Changed As Boolean = False
        Changed = Changed Or CompareAndChange(DR("Status"), "Complete")
        Changed = Changed Or CompareAndChange(DR("CompletedOnDate"), Now)
        If Not Changed Then
            DR.RejectChanges()
        End If

        DR.EndEdit()
        'DBA.Update()
        UpdateJobList()

    End Sub

    Private Sub btnReopenJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenJob.Click
        HideJobButtons()
        Dim DR As DataRow = DBA.GetDataRow("Jobs", CInt(Me.lvJobs.SelectedItems(0).Tag))
        DR.BeginEdit()
        Dim Changed As Boolean = False
        Changed = Changed Or CompareAndChange(DR("Status"), "Open")
        If Not Changed Then
            DR.RejectChanges()
        End If
        DR.EndEdit()
        'DBA.Update()
        UpdateJobList()
    End Sub

    'changed on 7/31/07 per BEZ request
    'Private Sub btnViewJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewJob.Click
    '    HideJobButtons()
    '    Dim EJ As New frmJob(CInt(Me.lvJobs.SelectedItems(0).Tag), JobEditMode.View)
    '    EJ.ShowDialog()
    'End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Me.clbStatus.Show()
        Me.btnStatus.BringToFront()
    End Sub

    Private Sub clbStatus_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbStatus.MouseLeave
        clbStatus.Hide()
        Me.lvJobs.Focus()
    End Sub

    Private Sub clbStatus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbStatus.MouseUp
        Dim list As String = ""
        For Each itm As String In clbStatus.CheckedItems
            list += "'" + itm.ToString + "',"
        Next
        If list.EndsWith(",") Then list = list.Substring(0, list.Length - 1)
        clbStatus.Tag = list

        UpdateCategoryList() 'UpdateJobList()
    End Sub

    Private Sub clbStatus_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbStatus.VisibleChanged
        If clbStatus.Visible Then
            Me.btnStatus.ImageIndex = 1
        Else
            Me.btnStatus.ImageIndex = 0
        End If
    End Sub

#End Region

#Region " Project Button Events "

    Private Sub btnNewCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCat.Click
        Dim Co As String = DBA.UserCompany
        If Me.lvCompanies.SelectedItems.Count > 0 Then
            If Me.lvCompanies.SelectedItems(0).Text <> "* All *" Then
                Co = Me.lvCompanies.SelectedItems(0).Text
            End If
        End If
        Dim NC As New frmCategory(Co, DBA.UserType)
        If NC.ShowDialog = Windows.Forms.DialogResult.OK Then
            NC.AddCategory()
            chkShowAllCat.Checked = True
            UpdateCategoryList()
        End If
        NC.Dispose()
    End Sub

    Private Sub btnEditCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCat.Click

        Dim EC As New frmCategory(CInt(Me.lvCategories.SelectedItems(0).Tag), DBA.UserType)
        If EC.ShowDialog = Windows.Forms.DialogResult.OK Then
            EC.UpdateCategory()
            UpdateCategoryList()
        End If
    End Sub

    Private Sub chkShowAllCat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowAllCat.CheckedChanged
        UpdateCategoryList()
    End Sub

#End Region

#Region " Customer Button Events "

    Private Sub btnNewCo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCo.Click
        Dim NC As New frmCompany(DBA.UserType)
        If NC.ShowDialog = Windows.Forms.DialogResult.OK Then
            NC.AddCompany()
            UpdateCompanyList()
        End If
        NC.Dispose()
    End Sub

    Private Sub btnEditCo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCo.Click
        Dim EC As New frmCompany(Me.lvCompanies.SelectedItems(0).Text, DBA.UserType)
        If EC.ShowDialog = Windows.Forms.DialogResult.OK Then
            EC.UpdateCompany()
            UpdateCompanyList()
        End If
    End Sub

#End Region

#End Region

#End Region

#Region " Print Events "

    Private Sub btnGenReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenReport.Click
        pnlPrintOptions.Hide()
        CreateReportsFromData()
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        CreateReportsFromData()
    End Sub

    Private Sub CreateReportsFromData()
        DontUpdateJobs = True
        Me.lvCategories.SelectedItems.Clear()
        DontUpdateJobs = False

        'Select all Categories
        Me.lvCategories.Items(0).Selected = True

        'Error conditions
        If Me.lvRecords.Items.Count = 0 Then
            MessageBox.Show("There are no records selected to print." + vbCrLf + _
            "Please adjust the task selection or date/employee filters.", "Nothing to Print", _
             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Set the dialog default report directory to the desktop if it's not set yet
        If My.Settings.SaveReportFolder = "" Then
            My.Settings.SaveReportFolder = My.Computer.FileSystem.SpecialDirectories.Desktop
        End If

        Using SFD As New SaveFileDialog()
            SFD.InitialDirectory = My.Settings.SaveReportFolder
            SFD.Filter = "*.xls|Excel Workbooks"
            SFD.FileName = SFD.InitialDirectory + "\Report" + Me.dtpLogDateEnd.Value.ToShortDateString.Replace("/", "") + ".xls"
            SFD.CheckFileExists = False

            If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.SaveReportFolder = IO.Directory.GetParent(SFD.FileName).FullName
                WriteExcelReport(SFD.FileName)
                'WriteTextReport(SFD.FileName, True)
            End If
        End Using
    End Sub

    Private Sub WriteTextReport(ByVal Filename As String, ByVal OpenFile As Boolean)

        Dim SavedCol As Integer = lvRecords.SortColumn
        Dim SBForm As New System.Text.StringBuilder
        Dim SBTab As New System.Text.StringBuilder
        Dim GroupX As ListViewGroup
        Dim CurrNode As TreeNode
        Dim LineW As Integer = 104
        Dim DidSummary As Boolean = True
        Dim ShowDetails As Boolean = False
        Dim ReportTitle As String = "Work Report" + vbCrLf + vbCrLf
        Dim GroupHours, CatHours, CompHours, NodeHours As Single
        Dim CurrCat, CurrComp, NameStack() As String
        Dim TotalItemCount As Integer = lvRecords.Items.Count * tvReport.Nodes.Count

        Using TextWriter As New IO.StreamWriter(Filename, False, System.Text.Encoding.UTF8)
            'Add date selection criteria to report Title
            ReportTitle += String.Format("Dates : {0} to {1}", _
                Me.dtpLogDateBegin.Value.ToShortDateString, _
                Me.dtpLogDateEnd.Value.ToShortDateString) + vbCrLf + _
                "Employee : "
            'Add Employee selection criteria to title
            If Me.cboLogEmp.SelectedItem.ToString = "* All *" Then
                For i As Integer = 1 To cboLogEmp.Items.Count - 1
                    ReportTitle += cboLogEmp.Items(i).ToString + "; "
                Next
                ReportTitle = ReportTitle.Remove(ReportTitle.Length - 2)
            Else
                ReportTitle += cboLogEmp.SelectedItem.ToString
            End If
            'Add company selection criteria to title
            ReportTitle += vbCrLf + "Customer : "
            If Me.lvCompanies.SelectedItems(0).Text = "* All *" Then
                For i As Integer = 1 To Me.lvCompanies.Items.Count - 1
                    ReportTitle += Me.lvCompanies.Items(i).Text + "; "
                Next
            Else
                For i As Integer = 0 To Me.lvCompanies.SelectedItems.Count - 1
                    ReportTitle += Me.lvCompanies.SelectedItems(i).Text + "; "
                Next
            End If
            ReportTitle = ReportTitle.Remove(ReportTitle.Length - 2) 'Remove last semicolon
            TextWriter.WriteLine(ReportTitle)
            For Each CurrNode In Me.tvReport.Nodes
                ShowDetails = CurrNode.Nodes(0).Checked
                If CurrNode.Checked Then
                    GroupHours = 0.0F
                    CatHours = 0.0F
                    CompHours = 0.0F
                    NodeHours = 0.0F
                    CurrCat = ""
                    CurrComp = ""
                    Select Case CurrNode.Name
                        Case "Date"
                            lvRecords.SortColumn = ColDate.Index
                        Case "JobID"
                            lvRecords.SortColumn = ColJob.Index
                        Case "Project"
                            lvRecords.SortColumn = ColCategory.Index
                        Case "User"
                            lvRecords.SortColumn = ColEmployee.Index
                    End Select
                    'Sort Records
                    UpdateLog(True)
                    If lvRecords.Items.Count > 0 Then
                        'Add report heading 2 (Summary by User/Date/TaskID)
                        TextWriter.WriteLine("Summary By " + CurrNode.Name + vbCrLf)
                        For Each GroupX In lvRecords.Groups
                            If CurrNode.Name = "JobID" Then
                                GroupHours = CSng(GroupX.Tag)
                                NameStack = GroupX.Name.Replace(" :: ", "|").Split("|"c)
                                If NameStack(1) <> CurrCat Then
                                    If CurrCat <> "" Then
                                        TextWriter.WriteLine("{0} :: {1} Project Hours = {2:0.##}" + vbCrLf, CurrComp, CurrCat, CatHours)
                                    End If
                                    CurrCat = NameStack(1)
                                    CatHours = 0
                                    If NameStack(0) <> CurrComp Then
                                        If CurrComp <> "" Then
                                            TextWriter.WriteLine("{0} Customer Hours = {1:0.##}" + vbCrLf, CurrComp, CompHours)
                                        End If
                                        CurrComp = NameStack(0)
                                        CompHours = 0
                                    End If
                                End If
                                CompHours += GroupHours
                                CatHours += GroupHours
                            ElseIf CurrNode.Name = "Project" Then
                                GroupHours = CSng(GroupX.Tag)
                                NameStack = GroupX.Name.Replace(" :: ", "|").Split("|"c)
                                If NameStack(0) <> CurrComp Then
                                    If CurrComp <> "" Then
                                        TextWriter.WriteLine("{0} Customer Hours = {1:0.##}" + vbCrLf, CurrComp, CompHours)
                                    End If
                                    CurrComp = NameStack(0)
                                    CompHours = 0
                                End If
                                CompHours += GroupHours
                            End If
                            'Add Group Header text
                            TextWriter.WriteLine(TrimTxt(GroupX.Header, LineW))
                            If ShowDetails Then
                                TextWriter.Write(GetGroupDataText(GroupX, CurrNode.Name, LineW, LineWeight.SingleLine))
                            End If
                            NodeHours += CSng(GroupX.Tag)
                        Next
                        If CurrNode.Name = "JobID" Then
                            TextWriter.WriteLine("{0} :: {1} Project Hours = {2:0.##}" + vbCrLf, CurrComp, CurrCat, CatHours)

                            TextWriter.WriteLine(vbCrLf + "{0} Customer Hours = {1:0.##}" + vbCrLf, CurrComp, CompHours)
                        ElseIf CurrNode.Name = "Project" Then
                            TextWriter.WriteLine("{0} Customer Hours = {1:0.##}" + vbCrLf, CurrComp, CompHours)
                        End If
                    End If
                    TextWriter.Write(vbCrLf + vbCrLf + "Total hours worked = " + NodeHours.ToString + ChrW(12) + vbCrLf)
                End If 'Nd2.Checked
            Next CurrNode '(Date, TaskID, or User)
            'Reset the log
            lvRecords.SortColumn = SavedCol
            UpdateLog(False)
        End Using


        'Open the text file in notepad
        If OpenFile Then
            Dim NPExe As String = Environ("systemroot") + "\system32\notepad.exe"
            If IO.File.Exists(NPExe) Then
                Shell(NPExe + " " + Filename, AppWinStyle.NormalFocus)
            End If
        End If

    End Sub

    Private Sub WriteExcelReport(ByVal filename As String)

        Dim XLApp As Excel.Application
        Dim XLWB As Excel.Workbook
        Dim ParamsWS As Excel.Worksheet

        Try
            'Initialize Excel objects
            XLApp = New Excel.Application
            XLWB = XLApp.Workbooks.Add()
            ParamsWS = CType(XLWB.Sheets.Add(), Excel.Worksheet)

            'build a list of parameters
            Dim reportparams As New ArrayList
            reportparams.Add("Created On" + vbTab + Now.ToShortDateString)
            reportparams.Add("Start Date" + vbTab + Me.dtpLogDateBegin.Value.ToShortDateString)
            reportparams.Add("End Date" + vbTab + Me.dtpLogDateEnd.Value.ToShortDateString)
            reportparams.Add("Employees")
            If Me.cboLogEmp.SelectedItem.ToString = "* All *" Then
                For i As Integer = 1 To cboLogEmp.Items.Count - 1
                    reportparams.Add(vbTab + cboLogEmp.Items(i).ToString)
                Next
            Else
                reportparams.Add(vbTab + cboLogEmp.SelectedItem.ToString)
            End If
            reportparams.Add("Companies")
            If Me.lvCompanies.SelectedItems(0).Text = "* All *" Then
                For i As Integer = 1 To Me.lvCompanies.Items.Count - 1
                    reportparams.Add(vbTab + Me.lvCompanies.Items(i).Text)
                Next
            Else
                For i As Integer = 0 To Me.lvCompanies.SelectedItems.Count - 1
                    reportparams.Add(vbTab + Me.lvCompanies.SelectedItems(i).Text)
                Next
            End If

            'Write parameter list into excel sheet
            ParamsWS.Name = "Report Parameters"
            For r As Integer = 1 To reportparams.Count
                Dim fields() As String = reportparams(r - 1).ToString.Split(New String() {vbTab}, StringSplitOptions.None)
                For c As Integer = 1 To fields.Length
                    ParamsWS.Cells(r, c) = fields(c - 1)
                Next
            Next
            ParamsWS.UsedRange.Columns.AutoFit()

            'Add report sheets
            WriteXLSheet(XLWB, "Task Report", New ColumnHeader() {ColCompany, ColCategory, ColJob, ColEmployee, _
                ColDate, ColHours, colBillHours, ColWorkDescr}, New Integer() {1, 2, 3}, New Integer() {6, 7})
            WriteXLSheet(XLWB, "Employee Report", New ColumnHeader() {ColEmployee, ColDate, ColStart, ColStop, ColCompany, _
                ColCategory, ColJob, ColHours, colBillHours, ColWorkDescr}, New Integer() {1, 2}, New Integer() {8, 9})

            'Remove standard empty sheets
            For Each ws As Excel.Worksheet In XLWB.Sheets
                If ws.Name.ToUpper Like "SHEET#" Then ws.Delete()
            Next

            'Save in Excel 2003 format
            XLWB.SaveAs(filename, FileFormat:=Excel.XlFileFormat.xlWorkbookNormal)

        Catch ex As Exception
            MsgBox(String.Format("Error creating Excel report {0}; {1}", filename, ex.Message))
        Finally

            If Not ParamsWS Is Nothing Then
                Runtime.InteropServices.Marshal.ReleaseComObject(ParamsWS)
                ParamsWS = Nothing
            End If

            If Not XLWB Is Nothing Then
                'XLWB.Close(False)
                Runtime.InteropServices.Marshal.ReleaseComObject(XLWB)
                XLWB = Nothing
            End If

            'Leave application open for viewing/editing
            If Not XLApp Is Nothing Then
                XLApp.Visible = True 'XLApp.Quit()
                Runtime.InteropServices.Marshal.ReleaseComObject(XLApp)
                XLApp = Nothing
            End If

            GC.Collect()

        End Try
    End Sub

    Private Sub WriteXLSheet(ByRef WB As Excel.Workbook, ByVal SheetName As String, ByRef cols() As ColumnHeader, _
        ByVal GroupByCols() As Integer, ByVal TotalColumns() As Integer)

        Dim XLWS As Excel.Worksheet = CType(WB.Sheets.Add(), Excel.Worksheet)

        'Rename the worksheet
        XLWS.Name = SheetName

        'Write Column headers
        For col As Integer = 1 To cols.Length
            XLWS.Cells(1, col) = cols(col - 1).Text
        Next

        'Write data
        For row As Integer = 1 To Me.lvRecords.Items.Count
            For col As Integer = 1 To cols.Length
                XLWS.Cells(row + 1, col) = Me.lvRecords.Items(row - 1).SubItems(cols(col - 1).Index).Text
            Next
        Next

        'Sort Rows
        Dim asc As Excel.XlSortOrder = Excel.XlSortOrder.xlAscending
        Dim lastrow As Integer = XLWS.UsedRange.Rows.Count
        Dim datopt As Excel.XlSortDataOption = Excel.XlSortDataOption.xlSortNormal

        'Excel 2003 sort syntax
        XLWS.UsedRange.Sort(Key1:=XLWS.Range("A2"), Order1:=asc, Key2:=XLWS.Range("B2"), Order2:=asc, _
        Key3:=XLWS.Range("C2"), Order3:=asc, Header:=Excel.XlYesNoGuess.xlYes, OrderCustom:=1, MatchCase:=False, _
        Orientation:=Excel.XlSortOrientation.xlSortColumns, DataOption1:=datopt, DataOption2:=datopt, DataOption3:= _
        datopt)

        'Excel 2007 Sort syntax
        'With XLWS.Sort
        '    .SortFields.Clear()
        '    For col As Integer = 1 To cols.Length - 1 
        '        .SortFields.Add(Key:=XLWS.Range(String.Format("{0}2:{0}{1}", ChrW(col + 64), XLWS.UsedRange.Rows.Count)), _
        '            SortOn:=Excel.XlSortOn.xlSortOnValues, Order:=Excel.XlSortOrder.xlAscending, _
        '            DataOption:=Excel.XlSortDataOption.xlSortNormal)
        '    Next
        '    .SetRange(XLWS.UsedRange)
        '    .Header = Excel.XlYesNoGuess.xlYes
        '    .MatchCase = False
        '    .Orientation = Excel.XlSortOrientation.xlSortColumns 'xlTopToBottom
        '    .SortMethod = Excel.XlSortMethod.xlPinYin
        '    .Apply()
        'End With

        'Add hierarchical subtotals totaling on last two of three columns (should always be hours and billable hours)
        For Each col As Integer In GroupByCols
            XLWS.UsedRange.Subtotal(GroupBy:=col, Function:=Excel.XlConsolidationFunction.xlSum, _
                TotalList:=TotalColumns, Replace:=False, PageBreaks:=False, _
                SummaryBelowData:=Excel.XlSummaryRow.xlSummaryBelow)
        Next

        'Do some formatting

        'Autofit column widths and wrap text
        With XLWS.UsedRange
            .Columns.AutoFit()
            .WrapText = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignTop
        End With

        'Make title row bold, centered, and underlined
        With XLWS.Range(XLWS.Cells(1, 1), XLWS.Cells(1, cols.Length))
            .Font.Bold = True
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .ColorIndex = 0
                .Weight = Excel.XlBorderWeight.xlMedium
            End With
            .Interior.ColorIndex = 15
        End With

        'Gray out total lines
        For row As Integer = 1 To XLWS.UsedRange.Rows.Count
            For Each col As Integer In GroupByCols
                Dim txt As String = CStr(CType(XLWS.Cells(row, col), Excel.Range).Value)
                If Not txt Is Nothing AndAlso txt.EndsWith(" Total") Then
                    XLWS.Range(XLWS.Cells(row, 1), XLWS.Cells(row, cols.Length)).Interior.ColorIndex = 15
                End If
            Next
        Next

        'Set Work Descr. col to max of 90
        With XLWS.Range(XLWS.Cells(1, cols.Length), XLWS.Cells(XLWS.UsedRange.Rows.Count, cols.Length))
            If CInt(.ColumnWidth) > 90 Then
                .ColumnWidth = 90
                .WrapText = True
            End If
        End With

        'Set .25 margins and landscape
        With XLWS.PageSetup
            .LeftMargin = XLWS.Application.InchesToPoints(0.25)
            .RightMargin = XLWS.Application.InchesToPoints(0.25)
            .TopMargin = XLWS.Application.InchesToPoints(0.25)
            .BottomMargin = XLWS.Application.InchesToPoints(0.25)
            .HeaderMargin = XLWS.Application.InchesToPoints(0)
            .FooterMargin = XLWS.Application.InchesToPoints(0)
            .Orientation = Excel.XlPageOrientation.xlLandscape
            .Zoom = 50
            .PrintGridlines = True
            .PrintTitleRows = "$1:$1"
            .Order = Excel.XlOrder.xlOverThenDown
        End With

        If Not XLWS Is Nothing Then
            Runtime.InteropServices.Marshal.ReleaseComObject(XLWS)
            XLWS = Nothing
        End If

    End Sub

    Private Function GetGroupDataText(ByRef g As ListViewGroup, ByVal NodeName As String, _
        ByVal LineWidth As Integer, ByVal DblLine As LineWeight) As String
        Dim SB As New System.Text.StringBuilder
        SB.Append(GetReportHeading(NodeName, LineWidth, DblLine))
        For Each ItemX As ListViewItem In g.Items
            SB.Append(GetReportDetails(ItemX, NodeName, LineWidth, DblLine))
        Next
        SB.Append(ASCIILine(False, LineWidth, AsciiLineType.BottomofBox, DblLine) + vbCrLf)
        Return SB.ToString
    End Function

    Private Function GetReportHeading(ByVal NodeName As String, ByVal LineWidth As Integer, ByVal DblLine As LineWeight) As String
        Dim SB As New System.Text.StringBuilder

        Select Case NodeName
            Case "Date"
                SB.Append(ASCIILine(False, LineWidth, AsciiLineType.TopofBox, DblLine) + vbCrLf)
                SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                     TrimTxt("Username", 16), _
                     TrimTxt("Task", 25), _
                     TrimTxt("Hours", 5), _
                     TrimTxt("Work Performed", LineWidth - 51), _
                     ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
            Case "JobID"
                ''Add Task Request Notes
                'Dim Comment As String = DBA.GetDataRow("Jobs", CInt(GroupX.Items(0).SubItems(Me.ColJobID.Index).Text)).Item("RequestNotes").ToString
                'If Comment.Trim <> "" Then
                '    SBSub.Append(Comment + vbCrLf)
                'End If
                SB.Append(ASCIILine(False, LineWidth, AsciiLineType.TopofBox, DblLine) + vbCrLf)
                SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                     TrimTxt("Date", 10), _
                     TrimTxt("Username", 16), _
                     TrimTxt("Hours", 5), _
                     TrimTxt("Work Performed", LineWidth - 36), _
                     ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
            Case "Project"
                SB.Append(ASCIILine(False, LineWidth, AsciiLineType.TopofBox, DblLine) + vbCrLf)
                SB.AppendFormat("{5}{0} {1} {2} {3} {4}{5}" + vbCrLf, _
                     TrimTxt("Date", 10), _
                     TrimTxt("Username", 16), _
                     TrimTxt("Task", 25), _
                     TrimTxt("Hours", 5), _
                     TrimTxt("Work Performed", LineWidth - 62), _
                     ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
            Case "User"
                SB.Append(ASCIILine(False, LineWidth, AsciiLineType.TopofBox, DblLine) + vbCrLf)
                SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                     TrimTxt("Date", 10), _
                     TrimTxt("Task", 25), _
                     TrimTxt("Hours", 5), _
                     TrimTxt("Work Performed", LineWidth - 45), _
                     ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
        End Select 'Case CurrNode.Name
        'Draw mid-line
        SB.Append(ASCIILine(False, LineWidth, AsciiLineType.MiddleofBox, DblLine) + vbCrLf)
        Return SB.ToString

    End Function

    Private Function GetReportDetails(ByRef LI As ListViewItem, ByVal NodeName As String, ByVal LineWidth As Integer, ByVal DblLine As LineWeight) As String
        Dim SB As New System.Text.StringBuilder
        Dim Lines() As String
        Dim line As Integer
        Select Case NodeName
            Case "Date"
                Lines = SplitString(LI.SubItems(Me.ColWorkDescr.Index).Text, LineWidth - 51)
                SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                     TrimTxt(LI.SubItems(Me.ColEmployee.Index).Text, 16), _
                     TrimTxt(LI.SubItems(Me.ColJob.Index).Text, 25), _
                     TrimTxt(LI.SubItems(Me.ColHours.Index).Text, 5), _
                     TrimTxt(Lines(0), LineWidth - 51, True), _
                     ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))

                For line = 1 To Lines.GetUpperBound(0)
                    SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                         TrimTxt(" ", 16), TrimTxt(" ", 25), TrimTxt(" ", 5), _
                         TrimTxt(Lines(line), LineWidth - 51, True), _
                         ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
                Next

            Case "JobID"
                Lines = SplitString(LI.SubItems(Me.ColWorkDescr.Index).Text, LineWidth - 36)
                SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                      TrimTxt(LI.SubItems(Me.ColDate.Index).Text, 10), _
                      TrimTxt(LI.SubItems(Me.ColEmployee.Index).Text, 16), _
                      TrimTxt(LI.SubItems(Me.ColHours.Index).Text, 5), _
                      TrimTxt(Lines(0), LineWidth - 36, True), _
                      ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))

                For line = 1 To Lines.GetUpperBound(0)
                    SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                         TrimTxt(" ", 10), TrimTxt(" ", 16), TrimTxt(" ", 5), _
                         TrimTxt(Lines(line), LineWidth - 36, True), _
                         ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
                Next 'line

            Case "Project"
                Lines = SplitString(LI.SubItems(Me.ColWorkDescr.Index).Text, LineWidth - 61)
                SB.AppendFormat("{5}{0} {1} {2} {3} {4}{5}" + vbCrLf, _
                     TrimTxt(LI.SubItems(Me.ColDate.Index).Text, 10), _
                     TrimTxt(LI.SubItems(Me.ColEmployee.Index).Text, 16), _
                     TrimTxt(LI.SubItems(Me.ColJob.Index).Text, 25), _
                     TrimTxt(LI.SubItems(Me.ColHours.Index).Text, 5), _
                     TrimTxt(Lines(0), LineWidth - 62, True), _
                     ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))

                For line = 1 To Lines.GetUpperBound(0)
                    SB.AppendFormat("{5}{0} {1} {2} {3} {4}{5}" + vbCrLf, _
                         TrimTxt(" ", 10), TrimTxt(" ", 16), TrimTxt(" ", 25), TrimTxt(" ", 5), _
                         TrimTxt(Lines(line), LineWidth - 62, True), _
                         ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
                Next

            Case "User"
                Lines = SplitString(LI.SubItems(Me.ColWorkDescr.Index).Text, LineWidth - 45)
                SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                     TrimTxt(LI.SubItems(Me.ColDate.Index).Text, 10), _
                     TrimTxt(LI.SubItems(Me.ColJob.Index).Text, 25), _
                     TrimTxt(LI.SubItems(Me.ColHours.Index).Text, 5), _
                     TrimTxt(Lines(0), LineWidth - 45, True), _
                     ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))

                For line = 1 To Lines.GetUpperBound(0)
                    SB.AppendFormat("{4}{0} {1} {2} {3}{4}" + vbCrLf, _
                         TrimTxt(" ", 10), TrimTxt(" ", 25), TrimTxt(" ", 5), _
                         TrimTxt(Lines(line), LineWidth - 45, True), _
                         ASCIILine(True, 1, AsciiLineType.TopofBox, DblLine))
                Next
        End Select 'Case CurrNode.Name
        Return SB.ToString
    End Function

    Private Function ASCIILine(ByVal Vertical As Boolean, ByVal Length As Integer, _
                ByVal Position As AsciiLineType, ByVal Weight As LineWeight) As String

        Dim UL, UR, LL, LR, Hor, Vert, ML, MR As Char

        Select Case Weight
            Case LineWeight.None
                Return New String(" "c, Length)
            Case LineWeight.Asterisks
                Return New String("*"c, Length)
            Case LineWeight.Dashes
                If Vertical Then
                    Return "|"c
                Else
                    Return New String("-"c, Length)
                End If
            Case LineWeight.DoubleLine
                UL = ChrW(&H2554)
                UR = ChrW(&H2557)
                LL = ChrW(&H255A)
                LR = ChrW(&H255D)
                Hor = ChrW(&H2550)
                Vert = ChrW(&H2551)
                ML = ChrW(&H2560)
                MR = ChrW(&H2563)
            Case LineWeight.SingleLine
                UL = ChrW(&H250C)
                UR = ChrW(&H2510)
                LL = ChrW(&H2514)
                LR = ChrW(&H2518)
                Hor = ChrW(&H2500)
                Vert = ChrW(&H2502)
                ML = ChrW(&H251C)
                MR = ChrW(&H2524)
        End Select


        If Vertical Then
            Return Vert
        Else
            Select Case Position
                Case AsciiLineType.TopofBox
                    Return String.Format("{0}{1}{2}", UL, New String(Hor, Length - 2), UR)
                Case AsciiLineType.MiddleofBox
                    Return String.Format("{0}{1}{2}", ML, New String(Hor, Length - 2), MR)
                Case AsciiLineType.BottomofBox
                    Return String.Format("{0}{1}{2}", LL, New String(Hor, Length - 2), LR)
                Case Else
                    Return ""
            End Select

        End If

    End Function

    ''' <summary>
    ''' Returns an array of strings word-wrapped into a specified columnwidth
    ''' </summary>
    ''' <param name="text">Input string</param>
    ''' <param name="Colwidth">Maximum number of characters to allow in each row</param>
    ''' <returns>Array of strings</returns>
    ''' <remarks>Handles CRLF and LF as well</remarks>
    Private Function SplitString(ByVal text As String, ByVal Colwidth As Integer) As String()

        Dim str() As String
        Dim UB As Integer = 0
        Dim i As Integer
        Dim out1() As String = text.Replace(ChrW(13), "").Split(ChrW(10))

        If out1.Length > 1 Then
            Dim line As String
            Dim strsub() As String
            ReDim str(-1)

            For Each line In out1
                strsub = SplitString(line, Colwidth)
                For i = 0 To strsub.GetUpperBound(0)
                    UB = str.GetUpperBound(0) + 1
                    ReDim Preserve str(UB)
                    str(UB) = strsub(i)
                Next
            Next
        Else
            Dim nextline As String
            ReDim str(0)
            str(0) = text
            Do While str(UB).Length > Colwidth
                i = str(UB).Substring(0, Colwidth).LastIndexOf(" "c)
                If i < 0 Then i = Colwidth
                nextline = str(UB).Substring(i + 1)
                str(UB) = str(UB).Substring(0, i)
                UB += 1
                ReDim Preserve str(UB)
                str(UB) = nextline
                nextline = ""
            Loop
        End If

        Return str

    End Function

    'Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Dim p As System.Drawing.Point = Me.PointToClient(Control.MousePosition)
    '    p.Offset(-Me.SplitContainer1.Left - Me.SplitContainer1.SplitterDistance, Me.SplitContainer1.Top)
    '    pnlPrintOptions.Top = p.Y
    '    pnlPrintOptions.Left = p.X - pnlPrintOptions.Width
    '    pnlPrintOptions.Show()
    '    pnlPrintOptions.BringToFront()

    'End Sub

    Private Sub btnHideOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHideOptions.Click

        pnlPrintOptions.Hide()

    End Sub

    Private Sub tvReport_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvReport.AfterCheck

        If Not e.Node.Checked Or Not e.Node.IsExpanded Then
            Dim Nd As TreeNode
            For Each Nd In e.Node.Nodes
                Nd.Checked = e.Node.Checked
            Next
        End If
    End Sub

    Private Sub tvReport_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvReport.AfterCollapse

        Dim Nd As TreeNode
        For Each Nd In e.Node.Nodes
            Nd.Collapse()
        Next
    End Sub

    Private Function TrimTxt(ByVal InpStr As String, ByVal TotalLength As Integer, Optional ByVal UseDash As Boolean = False) As String
        If InpStr.Length > TotalLength Then
            If UseDash Then
                InpStr = Microsoft.VisualBasic.Left(InpStr, TotalLength - 1) + "-"
            Else
                InpStr = Microsoft.VisualBasic.Left(InpStr, TotalLength - 3) + "..."
            End If
        End If
        InpStr = InpStr.PadRight(TotalLength)
        Return InpStr
    End Function



#End Region

    'Private Sub chkStyle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStyle.CheckedChanged
    '    If chkStyle.Checked Then
    '        Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled
    '        chkStyle.Text = "XP Style"
    '    Else
    '        Application.VisualStyleState = VisualStyles.VisualStyleState.NoneEnabled
    '        chkStyle.Text = "Classic Style"
    '    End If
    '    Application.DoEvents()
    'End Sub

    Private Sub btnSendUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendUpdates.Click
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        DBA.SendUpdates()
        Me.Enabled = True
        Me.Cursor = Cursors.Default
        UpdateLog(False)
    End Sub

    Private Sub tmrFlashButton_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFlashButton.Tick
        Me.flashCount += 1
        If Me.flashCount >= 10 Then
            tmrFlashButton.Stop()
            Me.btnSendUpdates.BackColor = Drawing.SystemColors.Control
            Application.DoEvents()
            Exit Sub
        End If
        If Me.btnSendUpdates.BackColor = Color.Yellow Then
            Me.btnSendUpdates.BackColor = Drawing.SystemColors.Control
        Else
            Me.btnSendUpdates.BackColor = Color.Yellow
        End If
        Application.DoEvents()
    End Sub

    Private Sub btnChangePW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePW.Click
        Dim chpw As New frmPassword
        If chpw.ShowDialog = Windows.Forms.DialogResult.OK Then
            MessageBox.Show(DBA.ChangePassword(chpw.OldPassword, chpw.NewPassword, chpw.ConfirmPassword), "Change Password Notification", MessageBoxButtons.OK)
        End If
    End Sub

End Class