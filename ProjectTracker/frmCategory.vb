Imports System.Windows.Forms

Public Class frmCategory
    Private _CatID As Integer
    Private categories As System.Collections.Generic.List(Of String)

    ''' <summary>
    ''' Opens the form in Add mode
    ''' </summary>
    ''' <param name="CompanyName"></param>
    ''' <param name="UserMode"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal CompanyName As String, ByVal UserMode As UserType)
        InitializeComponent()
        If UserMode = UserType.Administrator Then
            Company.Enabled = True
            LoadCompanies()
            SetCombo(Company, CompanyName, False)
        Else
            Company.Enabled = False
            Company.Items.Add(DBA.UserCompany)
            SetCombo(Company, DBA.UserCompany, True)
        End If
        CategoryName.Focus()
        OK_Button.Enabled = False
    End Sub

    ''' <summary>
    ''' Opens a category data item for editing
    ''' </summary>
    ''' <param name="CatID"></param>
    ''' <param name="UserMode"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal CatID As Integer, ByVal UserMode As UserType)
        Me.New(DBA.UserCompany, UserMode)
        Dim DR As DataRow = DBA.GetDataRow("Categories", CatID)
        _CatID = CatID
        Me.CategoryName.Text = DR("CategoryName").ToString
        SetCombo(Me.Company, DR("Company").ToString, True)
        Me.BillToName.Text = DR("BillToName").ToString
        Me.BillToAdd1.Text = DR("BillToAdd1").ToString
        Me.BillToAdd2.Text = DR("BillToAdd2").ToString
        Me.BillToCity.Text = DR("BillToCity").ToString
        Me.BillToState.Text = DR("BillToState").ToString
        Me.BillToZip.Text = DR("BillToZip").ToString
        Me.Phone.Text = DR("BillToPhone").ToString
        Me.Email.Text = DR("BillToEmail").ToString
        Me.Comments.Text = DR("Comments").ToString

    End Sub

    Public Sub AddCategory()
        Me.Cursor = Cursors.WaitCursor
        Dim prog As New frmProgress("Adding Project...", False)
        prog.Show()
        Application.DoEvents()
        Dim DR As DataRow = DBA.DataSet.Tables("Categories").NewRow
        DR.BeginEdit()
        Dim Changed As Boolean = LoadValues(DR)

        If Not Changed Then
            DR.RejectChanges()
        End If

        DR.EndEdit()
        DBA.DataSet.Tables("Categories").Rows.Add(DR)
        prog.Close()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub UpdateCategory()
        Dim DR As DataRow = DBA.GetDataRow("Categories", _CatID)
        DR.BeginEdit()
        Dim Changed As Boolean = LoadValues(DR)
        If Not Changed Then
            DR.RejectChanges()
        End If

        DR.EndEdit()
        'DBA.Update()
    End Sub

#Region "Private Subs"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub LoadCompanies()
        Company.Items.Clear()
        Company.Items.AddRange(DBA.GetItems("Companies", "*", "{0}", "Company"))
    End Sub

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

    Private Function LoadValues(ByRef DR As DataRow) As Boolean
        Dim Changed As Boolean = False
        Changed = Changed Or CompareAndChange(DR("CategoryName"), Me.CategoryName.Text)
        Changed = Changed Or CompareAndChange(DR("Company"), Me.Company.Text)
        Changed = Changed Or CompareAndChange(DR("BillToName"), Me.BillToName.Text)
        Changed = Changed Or CompareAndChange(DR("BillToAdd1"), Me.BillToAdd1.Text)
        Changed = Changed Or CompareAndChange(DR("BillToAdd2"), Me.BillToAdd2.Text)
        Changed = Changed Or CompareAndChange(DR("BillToCity"), Me.BillToCity.Text)
        Changed = Changed Or CompareAndChange(DR("BillToState"), Me.BillToState.Text)
        Changed = Changed Or CompareAndChange(DR("BillToZip"), Me.BillToZip.Text)
        Changed = Changed Or CompareAndChange(DR("BillToPhone"), Me.Phone.Text)
        Changed = Changed Or CompareAndChange(DR("BillToEmail"), Me.Email.Text)
        Changed = Changed Or CompareAndChange(DR("Comments"), Me.Comments.Text)
        Return Changed
    End Function

#End Region

    Private Sub CategoryName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryName.TextChanged
        Dim okname As Boolean = False
        Dim cat As String = CategoryName.Text

        If cat <> "" Then

            For i As Integer = 0 To categories.Count - 1
                If String.Compare(cat, categories(i), True) = 0 Then
                    okname = False
                End If
            Next
            okname = True
        End If

        Me.OK_Button.Enabled = okname
        If okname Then
            CategoryName.ForeColor = Color.Black
        Else
            CategoryName.ForeColor = Color.Red
        End If
    End Sub

   
    Private Sub Company_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Company.SelectedIndexChanged
        categories = New System.Collections.Generic.List(Of String)(DBA.GetItems("Categories", "Company='" + CStr(Company.SelectedItem) + "'", "{0}", "CategoryName"))
    End Sub
End Class
