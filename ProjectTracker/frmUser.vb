Imports System.Windows.Forms

Public Class frmUser
    Private ErrorBC As Color = Color.LightSalmon

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal Company As String, ByVal UserMode As UserType)
        InitializeComponent()
        Me.User_Type.Text = "Employee"
        Me.cboCompany.Items.Clear()

        If UserMode = UserType.Administrator Then
            LoadCompanies()
        Else
            Me.cboCompany.Items.Add(DBA.UserCompany)
            Me.cboCompany.Enabled = False
            Me.User_Type.Enabled = False
        End If
        Me.cboCompany.Text = Company
    End Sub

    Public Sub New(ByVal Username As String, ByVal Company As String, ByVal UserMode As UserType)
        Me.New(Company, UserMode)
        Dim DR As DataRow = DBA.GetDataRow("Users", Username)
        Me.FirstName.Text = DR("FirstName").ToString
        Me.LastName.Text = DR("LastName").ToString
        Me.cboCompany.Text = DR("Company").ToString
        Me.txtUsername.Text = DR("Username").ToString
        Me.txtUsername.Enabled = False
        Me.txtPassword.Text = DR("UserPassword").ToString
        Me.MailtoAdd1.Text = DR("MailtoAdd1").ToString
        Me.MailtoAdd2.Text = DR("MailtoAdd2").ToString
        'Me.MailtoAdd3.Text = DR("MailtoAdd3").ToString
        Me.MailtoCity.Text = DR("MailToCity").ToString
        Me.MailtoState.Text = DR("MailToState").ToString
        Me.MailtoZip.Text = DR("MailtoZip").ToString
        Me.HomePhone.Text = DR("HomePhone").ToString
        Me.WorkPhone.Text = DR("WorkPhone").ToString
        Me.MobilePhone.Text = DR("MobilePhone").ToString
        Me.User_Type.SelectedIndex = CInt(DR("UserType")) - 1
        Me.chkIsContractor.Checked = CBool(DR("IsContractor"))
        Me.Email.Text = DR("UserEmail").ToString
    End Sub

    Public Function AddUser() As String

        Dim NewUser As String = ""

        Dim DR As DataRow = DBA.DataSet.Tables("Users").NewRow
        DR.BeginEdit()
        If Not LoadValues(DR) Then
            DR.RejectChanges()
        End If
        DR.EndEdit()
        NewUser = DR("Username").ToString
        DBA.DataSet.Tables("Users").Rows.Add(DR)

        Dim DR2 As DataRow = DBA.DataSet.Tables("ReservedUserNames").NewRow
        DR2("Username") = Me.txtUsername.Text
        DBA.DataSet.Tables("ReservedUserNames").Rows.Add(DR2)

        Return NewUser

    End Function

    Public Sub UpdateUser()
        Dim DR As DataRow = DBA.GetDataRow("Users", Me.txtUsername.Text)
        DR.BeginEdit()
        If Not LoadValues(DR) Then
            DR.RejectChanges()
        End If
        DR.EndEdit()
        'DBA.Update()
    End Sub

    Private Function LoadValues(ByRef DR As DataRow) As Boolean
        Dim Changed As Boolean = False
        Changed = Changed Or CompareAndChange(DR("Username"), Me.txtUsername.Text)
        Changed = Changed Or CompareAndChange(DR("UserPassword"), Me.txtPassword.Text)
        Changed = Changed Or CompareAndChange(DR("Company"), Me.cboCompany.Text)
        Changed = Changed Or CompareAndChange(DR("FirstName"), Me.FirstName.Text)
        Changed = Changed Or CompareAndChange(DR("LastName"), Me.LastName.Text)
        Changed = Changed Or CompareAndChange(DR("MailtoAdd1"), Me.MailtoAdd1.Text)
        Changed = Changed Or CompareAndChange(DR("MailtoAdd2"), Me.MailtoAdd2.Text)
        'Changed = Changed Or CompareAndChange(DR("MailtoAdd3"), Me.MailtoAdd3.Text)
        Changed = Changed Or CompareAndChange(DR("MailToCity"), Me.MailtoCity.Text)
        Changed = Changed Or CompareAndChange(DR("MailToState"), Me.MailtoState.Text)
        Changed = Changed Or CompareAndChange(DR("MailtoZip"), Me.MailtoZip.Text)
        Changed = Changed Or CompareAndChange(DR("HomePhone"), Me.HomePhone.Text)
        Changed = Changed Or CompareAndChange(DR("WorkPhone"), Me.WorkPhone.Text)
        Changed = Changed Or CompareAndChange(DR("MobilePhone"), Me.MobilePhone.Text)
        Changed = Changed Or CompareAndChange(DR("UserType"), Me.User_Type.SelectedIndex + 1)
        Changed = Changed Or CompareAndChange(DR("IsContractor"), Me.chkIsContractor.Checked)
        Changed = Changed Or CompareAndChange(DR("UserEmail"), Me.Email.Text)

        Return Changed
    End Function

    Private Sub LoadCompanies()
        Me.cboCompany.Items.Clear()
        Me.cboCompany.Items.AddRange(DBA.GetItems("Companies", "*", "{0}", "Company"))
    End Sub

    Private Sub text_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtPassword.KeyDown, txtUsername.KeyDown, FirstName.KeyDown, LastName.KeyDown
        If e.KeyCode = Keys.Space Then e.SuppressKeyPress = True

    End Sub

    Private Sub ValidateControls(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FirstName.TextChanged, LastName.TextChanged, txtUsername.TextChanged, txtPassword.TextChanged, Email.TextChanged, Me.Load
 
        Me.OK_Button.Enabled = IsValidFirstName() And IsValidLastName() And _
                               IsValidUserName() And IsValidPassword() And _
                               IsValidEmail()

    End Sub

    Private Function IsValidFirstName() As Boolean
        Dim valid As Boolean = FirstName.Text.Length > 0
        If valid Then
            FirstName.BackColor = Color.White
        Else
            FirstName.BackColor = ErrorBC
        End If
        Return valid
    End Function

    Private Function IsValidLastName() As Boolean
        Dim valid As Boolean = LastName.Text.Length > 0
        If valid Then
            LastName.BackColor = Color.White
        Else
            LastName.BackColor = ErrorBC
        End If
        Return valid
    End Function

    Private Function IsValidEmail() As Boolean
        Dim valid As Boolean = New System.Text.RegularExpressions.Regex( _
            "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", _
            System.Text.RegularExpressions.RegexOptions.None).IsMatch(Email.Text)
        If valid Then
            Email.BackColor = Color.White
        Else
            Email.BackColor = ErrorBC
        End If
        Return valid
    End Function

    Private Function IsValidUserName() As Boolean
        Dim valid As Boolean = True
        If txtUsername.Enabled Then
            If txtUsername.Text.Length < 5 OrElse txtUsername.Text.Contains(" ") OrElse Not Char.IsLetter(txtUsername.Text.Chars(0)) Then
                valid = False
            Else
                Dim DR() As DataRow = DBA.GetDataRows("ReservedUserNames", "UserName='" + txtUsername.Text.Trim + "'")
                valid = DR.Length = 0
            End If

            If valid Then
                txtUsername.BackColor = Color.White
            Else
                txtUsername.BackColor = ErrorBC
            End If
        Else
            txtUsername.BackColor = Color.White
        End If
        Return valid
    End Function

    Private Function IsValidPassword() As Boolean
        Dim valid As Boolean = txtPassword.Text.Length > 2

        If valid Then
            txtPassword.BackColor = Color.White
        Else
            txtPassword.BackColor = ErrorBC
        End If
        Return valid
    End Function

End Class
