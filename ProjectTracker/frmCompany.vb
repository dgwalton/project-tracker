Imports System.Windows.Forms

Public Class frmCompany

    Private _Company As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal UserMode As UserType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If UserMode = UserType.Administrator Then AddUsers(UserMode)

    End Sub

    Public Sub New(ByVal Company As String, ByVal UserMode As UserType)

        Me.New(UserMode)
        _Company = Company

        Dim DR As DataRow = DBA.GetDataRow("Companies", Company)

        Me.Company_Name.Text = DR("Company").ToString
        Me.ContactName.Text = DR("ContactName").ToString
        Me.ContactEmail.Text = DR("ContactEmail").ToString
        Me.ContactPhone.Text = DR("ContactPhone").ToString
        Me.BillToName.Text = DR("BillToName").ToString
        Me.BillToAdd1.Text = DR("BillToAddr1").ToString
        Me.BillToAdd2.Text = DR("BillToAddr2").ToString
        Me.BillToAdd3.Text = DR("BillToAddr3").ToString
        Me.BillToAdd4.Text = DR("BillToAddr4").ToString
        Me.BillToCountry.Text = DR("BillToCountry").ToString
        Me.BillToCity.Text = DR("BillToCity").ToString
        Me.BillToState.Text = DR("BillToState").ToString
        Me.BillToZip.Text = DR("BillToZip").ToString
        Me.BillToPhone.Text = DR("BillToPhone").ToString
        AddUsers(UserMode)
        CheckoffAllowedUsers(DR("AllowedUsers").ToString.Split(","c))

        'The 'add user' button is only visible when in edit mode
        Me.btnNewUser.Enabled = True
    End Sub

    Public Sub AddCompany()

        Me.Cursor = Cursors.WaitCursor
        Dim prog As New frmProgress("Adding Company...", False)
        prog.Show()
        Application.DoEvents()
        Dim DR As DataRow = DBA.DataSet.Tables("Companies").NewRow
        DR.BeginEdit()
        If Not LoadValues(DR) Then
            DR.RejectChanges()
        End If
        DR.EndEdit()
        DBA.DataSet.Tables("Companies").Rows.Add(DR)
        prog.Close()
        Me.Cursor = Cursors.Default


    End Sub

    Public Sub UpdateCompany()
        Dim DR As DataRow = DBA.GetDataRow("Companies", _Company)
        DR.BeginEdit()
        Dim Changed As Boolean = LoadValues(DR)
        If Not Changed Then
            DR.RejectChanges()
        End If

        DR.EndEdit()
        'DBA.Update()
    End Sub

    Private Sub AddUsers(ByVal UserMode As UserType)

        Me.lvAllowedUsers.Items.Clear()

        'Select Case UserMode
        '    Case UserType.Administrator
        '        'add all users, regardless of company
        '        'Me.lvAllowedUsers.Items.AddRange(DBA.GetListViewItems("Users", "UserType=3", "LastName", "FirstName", "Username", "Company"))
        '        Me.lvAllowedUsers.Items.AddRange(DBA.GetListViewItems("Users", "*", _
        '         False, "Username", "FirstName", "LastName", "Company", "UserType"))
        '    Case UserType.Customer
        '        'add only users where company = current company
        '        Me.lvAllowedUsers.Items.AddRange(DBA.GetListViewItems("Users", "(UserType=2 OR UserType=3) AND Company='" + _Company + "'", _
        '        False, "Username", "FirstName", "LastName", "Company", "UserType"))
        '        Me.colCompany.Width = 0
        '    Case Else

        'End Select

        Me.lvAllowedUsers.Items.AddRange(DBA.GetListViewItems("Users", "*", _
                False, "Username", "FirstName", "LastName", "Company", "UserType", "LastLogin"))

    End Sub

    Private Sub CheckoffAllowedUsers(ByVal AllowedEmployees() As String)

        Dim User As String
        Dim LI As ListViewItem

        For Each LI In Me.lvAllowedUsers.Items

            Select Case CType(LI.SubItems(Me.colUserType.Index).Text, UserType)
                Case UserType.Administrator
                    LI.Checked = True
                Case UserType.Customer
                    If LI.SubItems(Me.colCompany.Index).Text = _Company Then
                        LI.Checked = True
                    End If
                Case UserType.Employee
                    For Each User In AllowedEmployees
                        If LI.SubItems(Me.colUsername.Index).Text.ToUpper = User.Trim.ToUpper Then
                            LI.Checked = True
                            Exit For
                        End If
                    Next
            End Select
        Next

    End Sub

    Private Function LoadValues(ByRef DR As DataRow) As Boolean
        Dim Changed As Boolean = False
        Changed = Changed Or CompareAndChange(DR("Company"), Me.Company_Name.Text)
        Changed = Changed Or CompareAndChange(DR("ContactName"), Me.ContactName.Text)
        Changed = Changed Or CompareAndChange(DR("ContactEmail"), Me.ContactEmail.Text)
        Changed = Changed Or CompareAndChange(DR("ContactPhone"), Me.ContactPhone.Text)
        Changed = Changed Or CompareAndChange(DR("BillToName"), Me.BillToName.Text)
        Changed = Changed Or CompareAndChange(DR("BillToAddr1"), Me.BillToAdd1.Text)
        Changed = Changed Or CompareAndChange(DR("BillToAddr2"), Me.BillToAdd2.Text)
        Changed = Changed Or CompareAndChange(DR("BillToAddr3"), Me.BillToAdd3.Text)
        Changed = Changed Or CompareAndChange(DR("BillToAddr4"), Me.BillToAdd4.Text)
        Changed = Changed Or CompareAndChange(DR("BillToCountry"), Me.BillToCountry.Text)
        Changed = Changed Or CompareAndChange(DR("BillToCity"), Me.BillToCity.Text)
        Changed = Changed Or CompareAndChange(DR("BillToState"), Me.BillToState.Text)
        Changed = Changed Or CompareAndChange(DR("BillToZip"), Me.BillToZip.Text)
        Changed = Changed Or CompareAndChange(DR("BillToPhone"), Me.BillToPhone.Text)
        Dim Userlist As String = ""
        Dim LI As ListViewItem
        For Each LI In Me.lvAllowedUsers.Items
            Select Case CType(LI.SubItems(Me.colUserType.Index).Text, UserType)

                Case UserType.Employee
                    If LI.Checked Then
                        Userlist += ", " + LI.SubItems(Me.colUsername.Index).Text
                    End If
            End Select
        Next
        If Userlist.StartsWith(", ") Then Userlist = Userlist.Substring(2)
        Changed = Changed Or CompareAndChange(DR("AllowedUsers"), Userlist)
        Return Changed
    End Function

    Private Sub lvAllowedUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAllowedUsers.SelectedIndexChanged
        Me.btnEditUser.Enabled = False

        If lvAllowedUsers.SelectedItems.Count = 1 Then

            Select Case DBA.UserType
                Case UserType.Administrator
                    Me.btnEditUser.Enabled = True
                Case UserType.Customer
                    If lvAllowedUsers.SelectedItems(0).SubItems(Me.colCompany.Index).Text = DBA.UserCompany Then
                        Me.btnEditUser.Enabled = True
                    End If
            End Select
        End If

    End Sub

    Private Sub btnEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUser.Click
        Dim EU As New frmUser(Me.lvAllowedUsers.SelectedItems(0).SubItems(Me.colUsername.Index).Text, _Company, DBA.UserType)
        If EU.ShowDialog = Windows.Forms.DialogResult.OK Then
            EU.UpdateUser()
        End If
    End Sub

    Private Sub btnNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUser.Click
        Dim NU As New frmUser(_Company, DBA.UserType)
        Do
            Select Case NU.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Dim user As String = NU.AddUser()
                    If user <> "" Then
                        Me.lvAllowedUsers.Items.AddRange(DBA.GetListViewItems("Users", _
                           "Username='" + user + "'", False, "Username", "FirstName", "LastName", "Company", "UserType"))
                        Dim NewItem As ListViewItem = Me.lvAllowedUsers.FindItemWithText(user, False, 0)
                        If Not NewItem Is Nothing Then
                            NewItem.EnsureVisible()
                            NewItem.Selected = True
                        End If
                    End If
                    Exit Do
                Case Windows.Forms.DialogResult.Retry
                    NU.txtUsername.Select()
                    NU.txtUsername.SelectAll()
                Case Windows.Forms.DialogResult.Cancel
                    Exit Do
            End Select
        Loop

        NU.Dispose()
    End Sub


End Class
