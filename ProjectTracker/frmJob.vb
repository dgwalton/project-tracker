Option Strict On
Option Explicit On

Imports Microsoft.Office.Interop
Imports System.Net.Mail

Public Class frmJob

#Region "Declarations"
    Private CatChanging As Boolean = False
    Private _JobID As Integer
    Private _JobMode As JobEditMode
    Private _Company As String
    Private _EmailsAdded As Boolean = False
    'Private NewEmailRows() As Integer
    Private OpenEmailForms() As frmViewEmail
#End Region

#Region "Constructors"

    ''' <summary>
    ''' Opens form in edit mode
    ''' </summary>
    ''' <param name="JobID"></param>
    ''' <param name="EditMode"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal JobID As Integer, ByVal EditMode As ProjectTracker.JobEditMode)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'ReDim Me.NewEmailRows(-1)
        ReDim Me.OpenEmailForms(-1)

        _JobID = JobID
        _JobMode = EditMode


        Dim DR As DataRow = DBA.GetDataRow("Jobs", JobID)
        _Company = DBA.GetDataRow("Categories", DR("CategoryID")).Item("Company").ToString

        LoadCompanies()
        LoadUsers()
        LoadEmails()

        Me.pnlAdmin.Hide()
        Me.Height -= Me.pnlAdmin.Height
        Me.pnlQuote.Hide()
        Me.Height -= Me.pnlQuote.Height
        Me.pnlRevQuote.Hide()
        Me.Height -= Me.pnlRevQuote.Height
        Me.chkQuote.Enabled = False
        Me.lvEmails.Enabled = True
        Me.colSubject.TextAlign = HorizontalAlignment.Left

        Select Case DR("Status").ToString
            Case "Open"
                Me.chkQuote.Enabled = True
                Me.chkQuote.Checked = False
            Case "Awaiting Quote"
                Me.chkQuote.Enabled = True
                Me.chkQuote.Checked = True
            Case Else '"Complete", "On Hold", "Awaiting Approval"
                Me.chkQuote.Enabled = False
                Me.chkQuote.Checked = False
        End Select

        Select Case EditMode
            Case JobEditMode.View
                Me.Text = "View Task"
                Me.pnlMain.Enabled = False
                Me.OK_Button.Hide()
                Me.Cancel_Button.Text = "Close"

            Case JobEditMode.Administrator
                Me.Text = "Edit Task (Admin Mode)"
                Me.pnlAdmin.Show()
                Me.Height += Me.pnlAdmin.Height

            Case JobEditMode.Edit
                Me.Text = "Edit Task"
                Me.OK_Button.Enabled = Me.txtDescr.Text.Length > 0

            Case JobEditMode.SubmitQuote
                Me.Text = "Submit Task Quote"
                Me.pnlQuote.Show()
                Me.Height += Me.pnlQuote.Height
                Me.pnlMain.Enabled = False
                Me.pnlEmail.Enabled = True

            Case JobEditMode.ReviewQuote
                Me.Text = "Review Task Quote"
                Me.chkQuote.Enabled = False
                Me.pnlRevQuote.Show()
                Me.pnlQuote.Show()
                Me.pnlQuote.Enabled = False
                Me.Height -= 40 'hides ok and cancel
                Me.Height += Me.pnlRevQuote.Height
                Me.Height += Me.pnlQuote.Height
        End Select

        Me.txtQuotedHours.Text = DR("QuotedHours").ToString
        Me.txtQuotedCost.Text = DR("QuotedCost").ToString

        'Set fields
        SetCombo(Me.cboPriority, DR("Priority").ToString, False)
        SetCombo(Me.cboCompany, _Company, True)
        SetCombo(Me.cboCatID, DR("CategoryID").ToString, True)
        SetCombo(Me.cboStatus, DR("Status").ToString, True)
        SetCombo(Me.cboReqUser, DR("RequestedByUser").ToString, True)
        SetCombo(Me.cboApprUser, DR("ApprovedByUser").ToString, True)

        'Add company allowed users (Employees)
        Dim visibleusers As New System.Collections.Generic.List(Of String)

        'Add all allowed users for current company
        visibleusers.AddRange(DBA.GetDataRow("Companies", _Company).Item("AllowedUsers").ToString.Split( _
            New String() {", "}, StringSplitOptions.RemoveEmptyEntries))
        'Add all company admins
        Dim admins() As String = DBA.GetItems("Admins", "Company='" + _Company + "' AND UserType=2", "{0}", "UserName")
        visibleusers.AddRange(admins)
        'Add all super admins - not now, it doesn't seem necessary
        visibleusers.AddRange(DBA.GetItems("Admins", "UserType=1", "{0}", "UserName"))
        visibleusers.Sort()
        For Each vu As String In visibleusers
            If Not Me.clbNotify.Items.Contains(vu) Then
                Me.clbNotify.Items.Add(vu)
            End If
        Next

        If DR("NotifyEmail") Is DBNull.Value Then
            If MessageBox.Show("This job has no users tagged for notifications." + vbCrLf + _
            "Do you want to notify company administrators when changes or work occur on this job?", "Add Notifications?", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SetNotifiedUsers(admins)
            End If
        Else
            SetNotifiedUsers(CStr(DR("NotifyEmail")).Split(","c))
        End If

        'Set Date Pickers
        Dim dt As Date = Now.AddMonths(1)
        If DR("RequestedCompleteByDate").ToString.Trim <> "" Then
            dt = CDate(DR("RequestedCompleteByDate"))
        End If
        Me.dtpEndDate.Value = dt

        If DR("OpenedOnDate").ToString.Trim <> "" Then
            Me.dtpOpenedOn.Value = CDate(DR("OpenedOnDate"))
        End If

        If DR("CompletedOnDate").ToString.Trim <> "" And DR("Status").ToString = "Complete" Then
            Me.lblClosedOn.Text = CDate(DR("CompletedOnDate")).ToShortDateString
        End If

        Me.txtDescr.Text = DR("Description").ToString
        Me.txtNotes.Text = DR("RequestNotes").ToString
        Me.txtAccountingID.Text = DR("AccountingID").ToString
        Select Case DR("Billable").ToString.ToUpper
            Case "B"
                Me.rbBillable.Checked = True
            Case "N"
                Me.rbNotBillable.Checked = True
            Case "S"
                Me.rbSplitBillable.Checked = True
        End Select

    End Sub

#End Region

    Private Sub SetCombo(ByRef Combo As ComboBox, ByVal Value As String, ByVal ForceValue As Boolean)
        If ForceValue Then
            Combo.Text = Value
        Else
            Dim i As Integer
            For i = 0 To Combo.Items.Count - 1
                If Combo.Items(i).ToString.ToUpper = Value.ToUpper Then
                    Combo.SelectedIndex = i
                    Exit Sub
                End If
            Next
            Combo.SelectedIndex = -1
        End If

    End Sub

    Public Sub AddNewJob()
        Dim DR As DataRow = DBA.GetDataRow("Jobs", _JobID)
        DR.BeginEdit()
        Dim Changed As Boolean = LoadValues(DR)

        Changed = Changed Or CompareAndChange(DR("RequestDate"), Now)
        Changed = Changed Or CompareAndChange(DR("RequestedbyUser"), DBA.User)
        If CStr(DR("Status")) = "Open" Then
            Changed = Changed Or CompareAndChange(DR("ApprovedbyUser"), DBA.User)
        End If
        If Not Changed Then
            DR.RejectChanges()
        End If
        DR.EndEdit()

    End Sub

    Public Sub UpdateJob()
        Dim DR As DataRow = DBA.GetDataRow("Jobs", _JobID)
        DR.BeginEdit()
        Dim Changed As Boolean = LoadValues(DR)
        If Me.chkQuote.Visible Then
            If Me.chkQuote.Checked Then
                Changed = Changed Or CompareAndChange(DR("Status"), "Awaiting Quote")
            Else
                Changed = Changed Or CompareAndChange(DR("Status"), "Open")
            End If
        End If
        If Not Changed Then
            DR.RejectChanges()
        End If
        DR.EndEdit()

    End Sub

    Public Sub AddQuoteToJob()
        Dim DR As DataRow = DBA.GetDataRow("Jobs", _JobID)
        DR.BeginEdit()
        Dim Changed As Boolean = False
        If Me.rbQuoteCost.Checked Then
            Changed = Changed Or CompareAndChange(DR("QuotedCost"), Me.txtQuotedCost.Text)
        Else
            Changed = Changed Or CompareAndChange(DR("QuotedHours"), Me.txtQuotedHours.Text)
        End If
        Changed = Changed Or CompareAndChange(DR("Status"), "Awaiting Approval")
        If Not Changed Then
            DR.RejectChanges()
        End If

        DR.EndEdit()
        'DBA.Update()
    End Sub

    Public Sub AcceptJobQuote()
        Dim DR As DataRow = DBA.GetDataRow("Jobs", _JobID)
        DR.BeginEdit()
        Dim Changed As Boolean = False
        Changed = Changed Or CompareAndChange(DR("Status"), "Open")
        Changed = Changed Or CompareAndChange(DR("ApprovedByUser"), DBA.User)
        Changed = Changed Or CompareAndChange(DR("OpenedOnDate"), Now)
        If Not Changed Then
            DR.RejectChanges()
        End If

        DR.EndEdit()
        'DBA.Update()
    End Sub

#Region "List Loading Subs"

    Private Function LoadValues(ByRef DtRw As DataRow) As Boolean
        Dim Changed As Boolean = _EmailsAdded

        Changed = Changed Or CompareAndChange(DtRw("CategoryID"), Me.cboCatID.SelectedItem.ToString)
        Changed = Changed Or CompareAndChange(DtRw("Description"), Me.txtDescr.Text)
        If Me.cboPriority.Text <> "" Then
            Changed = Changed Or CompareAndChange(DtRw("Priority"), CInt(Me.cboPriority.Text))
        End If
        Changed = Changed Or CompareAndChange(DtRw("RequestedByUser"), Me.cboReqUser.Text)
        Changed = Changed Or CompareAndChange(DtRw("RequestNotes"), Me.txtNotes.Text)
        Changed = Changed Or CompareAndChange(DtRw("Status"), Me.cboStatus.Text)
        Changed = Changed Or CompareAndChange(DtRw("ApprovedByUser"), Me.cboApprUser.Text)
        Changed = Changed Or CompareAndChange(DtRw("RequestedCompleteByDate"), Me.dtpEndDate.Value)
        Changed = Changed Or CompareAndChange(DtRw("OpenedOnDate"), Me.dtpOpenedOn.Value)
        Changed = Changed Or CompareAndChange(DtRw("NotifyEmail"), GetNotifiedUsers())
        Changed = Changed Or CompareAndChange(DtRw("AccountingID"), Me.txtAccountingID.Text)
      
        'Changed = Changed Or CompareAndChange(DtRw("CompletedOnDate"), Me.dtpClosedOn.Value)

        Dim Bill As String = "N"
        If Me.rbBillable.Checked Then
            Bill = "B"
        ElseIf Me.rbSplitBillable.Checked Then
            Bill = "S"
        End If
        Changed = Changed Or CompareAndChange(DtRw("Billable"), Bill)
        Return Changed

    End Function

    Private Function GetNotifiedUsers() As String
        Dim out As String = ""
        For Each U As String In Me.clbNotify.CheckedItems
            out += U + ","
        Next
        If out.EndsWith(",") Then out = out.Substring(0, out.Length - 1)
        Return out
    End Function

    Private Sub SetNotifiedUsers(ByVal users() As String) 'ByVal Userlist As String, ByVal Separator As String)
        'Dim Users() As String = Userlist.Split(New String() {Separator}, StringSplitOptions.RemoveEmptyEntries)
        For Each u As String In users
            Dim user As String = u.Trim
            If user <> "" AndAlso Me.clbNotify.Items.Contains(user) Then
                'Me.clbNotify.Items.Add(user, True)
                Me.clbNotify.SetItemChecked(Me.clbNotify.FindStringExact(user), True)
            End If

        Next
    End Sub

    Private Sub LoadCompanies()
        cboCompany.Items.Clear()
        Me.cboCompany.Items.AddRange(DBA.GetItems("Companies", "*", "{0}", "Company"))
    End Sub

    Private Sub LoadUsers()
        Me.cboReqUser.Items.Clear()
        Me.cboApprUser.Items.Clear()
        Dim items() As String = DBA.GetItems("Users", "*", "{0}", "Username")
        Me.cboReqUser.Items.AddRange(items)
        Me.cboApprUser.Items.AddRange(items)

    End Sub

    Private Sub LoadCategories()
        Me.cboCatID.Items.Clear()
        Me.cboCategory.Items.Clear()
        Me.cboCatID.Items.AddRange(DBA.GetItems("Categories", "Company='" + cboCompany.Text + "'", "{0}", "CategoryID"))
        Me.cboCategory.Items.AddRange(DBA.GetItems("Categories", "Company='" + cboCompany.Text + "'", "{0}", "CategoryName"))
    End Sub

    Private Sub LoadEmails()

        Me.lvEmails.Items.Clear()
        'Load stored emails
        Me.lvEmails.Items.AddRange(DBA.GetListViewItems("Emails", "JobID=" + _JobID.ToString, False, "EmailID", _
        "EmailFrom", "EmailSubject", "EmailDateTime"))
        'Load any new emails
        'For i As Integer = 0 To Me.NewEmailRows.GetUpperBound(0)
        '    Me.lvEmails.Items.AddRange(DBA.GetListViewItems("Emails", "EmailID=" + Me.NewEmailRows(i).ToString, False, "EmailID", _
        '            "EmailFrom", "EmailSubject", "EmailDateTime"))
        'Next
        Dim s As Integer
        For Each LVI As ListViewItem In Me.lvEmails.Items
            s = LVI.SubItems(Me.colFrom.Index).Text.IndexOf("["c)
            If s >= 0 Then
                LVI.SubItems(Me.colFrom.Index).Text = LVI.SubItems(Me.colFrom.Index).Text.Substring(0, s)
            End If
        Next
    End Sub

#End Region

#Region "Control Events"

    Private Sub frmJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        For Each OE As frmViewEmail In Me.OpenEmailForms
            OE.Close()
            OE.Dispose()
        Next
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cboCatID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatID.SelectedIndexChanged

        If Not CatChanging Then
            CatChanging = True
            cboCategory.SelectedIndex = cboCatID.SelectedIndex
            CatChanging = False
        End If

    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged

        If Not CatChanging Then
            CatChanging = True
            cboCatID.SelectedIndex = cboCategory.SelectedIndex
            CatChanging = False
        End If
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        LoadCategories()
        If cboCatID.Items.Count > 0 Then cboCatID.SelectedIndex = 0
    End Sub

    Private Sub chkQuote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkQuote.CheckedChanged
        If Me.chkQuote.Checked Then
            If _JobID > 0 Then
                If DBA.DataSet.Tables("Records").Select("JobID=" + _JobID.ToString).Length > 0 Then
                    MessageBox.Show("A quote cannot be requested because" + vbCrLf _
                                     + "this job already has work records added.")
                    chkQuote.Checked = False
                Else
                    SetCombo(Me.cboStatus, "Awaiting Quote", False)
                End If
            Else
                SetCombo(Me.cboStatus, "Awaiting Quote", False)
            End If
        Else
            SetCombo(Me.cboStatus, "Open", False)
        End If
    End Sub

    Private Sub txtDescr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescr.TextChanged
        Me.OK_Button.Enabled = Me.txtDescr.Text.Trim.Length > 0
    End Sub

    Private Sub btnAcceptQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptQuote.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnRejectClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRejectClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbQuoteHours_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQuoteHours.CheckedChanged, rbQuoteCost.CheckedChanged
        Me.txtQuotedHours.Enabled = rbQuoteHours.Checked
        Me.txtQuotedCost.Enabled = rbQuoteCost.Checked
    End Sub

#Region "Emails Listview"

    Private Sub lvEmails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEmails.DoubleClick
        Dim i As Integer
        Dim ID As Integer
        Dim FoundOpen As Boolean
        For i = 0 To lvEmails.SelectedItems.Count - 1
            FoundOpen = False
            ID = CInt(lvEmails.SelectedItems(i).Text)

            'Search though open emails for existing copy
            For Each OE As frmViewEmail In Me.OpenEmailForms
                If OE.EmailID = ID Then
                    If Not OE.IsDisposed Then
                        FoundOpen = True
                        OE.Show()
                        OE.BringToFront()
                        OE.Select()
                        OE.Focus()
                        Exit For
                    End If

                End If
            Next
            'Create a new form if this email is not open yet
            If Not FoundOpen Then
                Dim UB As Integer = Me.OpenEmailForms.Length
                ReDim Preserve Me.OpenEmailForms(UB)
                Me.OpenEmailForms(UB) = New frmViewEmail(ID)
                Me.OpenEmailForms(UB).Owner = Me
                Me.OpenEmailForms(UB).Show()
            End If
        Next
    End Sub

    Private Sub lvEmails_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvEmails.DragDrop

        Dim OLApp As New Outlook.ApplicationClass
        Dim OLExp As Outlook.Explorer = OLApp.ActiveExplorer
        Dim OLMailItem As Outlook.MailItem
        Dim Rec As Outlook.Recipient
        Dim DR As DataRow
        Dim i As Integer

        For i = 1 To OLExp.Selection.Count
            OLMailItem = DirectCast(OLExp.Selection.Item(i), Outlook.MailItem)

            DR = DBA.DataSet.Tables("Emails").NewRow
            DR.BeginEdit()
            Dim Changed As Boolean = False
            Changed = Changed Or CompareAndChange(DR("JobID"), _JobID)
            Changed = Changed Or CompareAndChange(DR("EmailSubject"), OLMailItem.Subject)
            Changed = Changed Or CompareAndChange(DR("EmailDateTime"), OLMailItem.SentOn)
            Select Case OLMailItem.BodyFormat
                Case Outlook.OlBodyFormat.olFormatPlain, Outlook.OlBodyFormat.olFormatRichText
                    Changed = Changed Or CompareAndChange(DR("EmailBody"), OLMailItem.Body)
                Case Outlook.OlBodyFormat.olFormatHTML, Outlook.OlBodyFormat.olFormatUnspecified
                    Changed = Changed Or CompareAndChange(DR("EmailBody"), OLMailItem.HTMLBody)
            End Select


            Dim SendTo As String = ""
            Dim CC As String = ""
            Dim BCC As String = ""

            For Each Rec In OLMailItem.Recipients

                Dim Name As String = ""
                If Rec.Name <> Nothing Then Name = CStr(Rec.Name).Trim()
                If Name.StartsWith("'") Then Name = Name.Substring(1)
                If Name.EndsWith("'") Then Name = Name.Remove(Name.Length - 1)

                Dim Addr As String = ""
                If Rec.Address <> Nothing Then Addr = CStr(Rec.Address).Trim()
                If Addr = Name Then Addr = ""
                If Addr <> "" Then Addr = " [" + Addr + "]"

                Select Case Rec.Type
                    Case Outlook.OlMailRecipientType.olTo
                        SendTo = Name + Addr + "; "
                    Case Outlook.OlMailRecipientType.olCC
                        CC = Name + Addr + "; "
                    Case Outlook.OlMailRecipientType.olBCC
                        BCC = Name + Addr + "; "
                    Case Outlook.OlMailRecipientType.olOriginator
                End Select
            Next

            If SendTo.EndsWith("; ") Then SendTo = SendTo.Remove(SendTo.Length - 2)
            If CC.EndsWith("; ") Then CC = CC.Remove(CC.Length - 2)
            If BCC.EndsWith("; ") Then BCC = BCC.Remove(BCC.Length - 2)

            Dim From As String = OLMailItem.SenderName
            If From.StartsWith("'") Then From = From.Substring(1)
            If From.EndsWith("'") Then From = From.Remove(Name.Length - 1)
            If OLMailItem.SenderEmailAddress <> Nothing Then
                If OLMailItem.SenderEmailAddress <> From Then
                    From += " [" + OLMailItem.SenderEmailAddress + "]"
                End If
            End If

            Changed = Changed Or CompareAndChange(DR("EmailTo"), SendTo)
            Changed = Changed Or CompareAndChange(DR("EmailCC"), CC)
            Changed = Changed Or CompareAndChange(DR("EmailBCC"), BCC)
            Changed = Changed Or CompareAndChange(DR("EmailFrom"), From)
            If Not Changed Then
                DR.RejectChanges()
            End If
            DR.EndEdit()

            DBA.DataSet.Tables("Emails").Rows.Add(DR)
            _EmailsAdded = True

            'Dim UB As Integer = Me.NewEmailRows.GetUpperBound(0) + 1
            'ReDim Preserve Me.NewEmailRows(UB)
            'Me.NewEmailRows(UB) = CInt(DR("EmailID"))
            OLMailItem.Close(Outlook.OlInspectorClose.olDiscard)
        Next


        'OLExp.Close()
        OLExp = Nothing
        OLMailItem = Nothing
        OLApp = Nothing

        LoadEmails()

    End Sub

    Private Sub lvEmails_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvEmails.DragOver
        e.Effect = DragDropEffects.None
        If _JobID <> -1 AndAlso (_JobMode = JobEditMode.Edit Or _JobMode = JobEditMode.Administrator) Then
            If (e.Data.GetDataPresent("Object Descriptor")) Then
                Dim myMem As New IO.MemoryStream
                Dim strCheck As String = ""
                myMem = DirectCast(e.Data.GetData("Object Descriptor"), IO.MemoryStream)
                Dim myByte As Byte() = myMem.ToArray
                myMem.Close()
                For i As Integer = 0 To myByte.Length - 1
                    If myByte(i) <> 0 Then
                        strCheck += ChrW(myByte(i))
                    End If
                Next
                If strCheck.ToLower.IndexOf("outlook") > -1 Then
                    e.Effect = e.AllowedEffect
                End If
            End If
        End If

    End Sub

    Private Sub lvEmails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvEmails.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                If _JobMode = JobEditMode.Administrator Or _JobMode = JobEditMode.Edit Then
                    If Me.lvEmails.SelectedItems.Count > 0 Then
                        If MessageBox.Show("Email message(s) will be permanently deleted." + vbCrLf + _
                                           "Are you sure?", "Delete Messages?", MessageBoxButtons.OKCancel, _
                                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                            For Each SI As ListViewItem In Me.lvEmails.SelectedItems
                                DBA.GetDataRow("Emails", CInt(SI.Text)).Delete()
                            Next
                            LoadEmails()
                        End If
                    End If
                End If
        End Select
    End Sub

#End Region

#End Region

   
End Class

