Option Explicit On 
Option Strict On

Public Class OLEDBDataAccess

    Private MyDS As System.Data.DataSet

    Private _LoggedInUserPW As String
    Private _LoggedInUser As String
    Private _LoggedInUserCompany As String
    Private _LoggedInUserType As UserType
    Private _StartDate As DateTime

    Public Dirty As Boolean = False
    Public Changes As String = ""

    Public ReadOnly Property DataSet() As System.Data.DataSet
        Get
            Return MyDS
        End Get
    End Property
    Public ReadOnly Property User() As String
        Get
            Return _LoggedInUser
        End Get
    End Property
    Public ReadOnly Property UserCompany() As String
        Get
            Return _LoggedInUserCompany
        End Get
    End Property
    Public ReadOnly Property UserType() As UserType
        Get
            Return _LoggedInUserType
        End Get
    End Property

#Region "Public Subs"

    ''' <summary>
    ''' Imports data from an XML Web Service.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal Username As String, ByVal Password As String, ByVal StartDate As System.DateTime)
        _StartDate = StartDate
        MyDS = New System.Data.DataSet
        GetData(Username, Password)
        Login(Username, Password)
    End Sub

    Public Function ChangePassword(ByVal oldPW As String, ByVal NewPW As String, ByVal confirmPW As String) As String

        If oldPW <> _LoggedInUserPW Then Return "The current password you provided is incorrect."
        If NewPW <> confirmPW Then Return "New password entries do not match."
        If NewPW = oldPW Then Return "New password must be different from old password."
        If NewPW.Length < 6 Then Return "New password must be at least 6 characters long."


        If oldPW = _LoggedInUserPW AndAlso NewPW.Length > 2 AndAlso NewPW <> _LoggedInUserPW Then
            Dim DR As DataRow = DBA.GetDataRow("Users", _LoggedInUser)
            DR.BeginEdit()
            DR.Item("Userpassword") = NewPW
            DR.EndEdit()
            If SendData("Users") Then
                _LoggedInUserPW = NewPW
                MyDS.Tables("Users").AcceptChanges()
                Return "Password was successfully changed"
            Else
                Return "There was a problem changing your password."
            End If

        End If



    End Function

    ''' <summary>
    ''' Releases all system resources.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()

        If Not MyDS Is Nothing Then
            MyDS.Dispose()
        End If


    End Sub

    ''' <summary>
    ''' Returns a DataRow object containing a unique row of data from the specified Table and Key
    ''' </summary>
    ''' <param name="Tablename">The name of a table within the current database</param>
    ''' <param name="PrimaryKeyValue">The value of the table's primary key</param>
    ''' <returns>System.Data.DataRow object</returns>
    ''' <remarks></remarks>
    Public Function GetDataRow(ByVal Tablename As String, ByVal PrimaryKeyValue As Object) As System.Data.DataRow
        Dim Rw As DataRow = MyDS.Tables(Tablename).Rows.Find(PrimaryKeyValue)
        'Dim i As Integer
        'For i = 0 To Rw.ItemArray.Length - 1
        '    Try
        '        If Rw.Item(i) Is DBNull.Value Then
        '            Select Case MyDS.Tables(Tablename).Columns(i).DataType.Name
        '                Case "String"
        '                    Rw.Item(i) = ""
        '                Case "Single", "Double"
        '                    Rw.Item(i) = 0.0F
        '                Case "Integer", "Long", "Int16", "Int32", "Int64"
        '                    Rw.Item(i) = 0
        '                Case "DateTime"
        '                    Rw.Item(i) = New DateTime(1980, 1, 1)
        '                Case Else
        '                    Rw.Item(i) = Nothing
        '            End Select
        '        End If
        '    Catch ex As Exception
        '        Rw.Item(i) = Nothing
        '    End Try
        'Next
        Return Rw
    End Function

    Public Function GetDataRows(ByVal TableName As String, ByVal FilterExpression As String) As DataRow()
        If FilterExpression = "*" Then
            Return MyDS.Tables(TableName).Select()
        Else
            Return MyDS.Tables(TableName).Select(FilterExpression)
        End If
    End Function

    ''' <summary>
    ''' Returns an array of listview items containing selected fields of selected data records.
    ''' </summary>
    ''' <param name="TableName">The datatable to pull records from</param>
    ''' <param name="FilterExpression">The filter string, e.g. "UserName = 'James'" 
    ''' The wildcard (*) may be used. Note: 
    ''' The field value must be encapsulated in single quotes. </param>
    ''' <param name="FieldNames">A list of field names whose data you want to format. 
    ''' Each field will be added to a new ListView Column.</param>
    ''' <remarks>An array of System.Windows.Forms.ListViewItems</remarks>
    Public Function GetUserListViewItems(ByVal TableName As String, ByVal UserName As String, _
           ByVal AllowedUsersField As String, ByVal FilterExpression As String, _
           ByVal ParamArray FieldNames() As String) As ListViewItem()

        'This sub allows you to fill a listview with multiple fields.
        'Example Sytnax: FillControl("Accounts", "*", "LastName", "FirstName")
        'where 'LastName' and 'FirstName' correspond to column names in the 'Accounts' table
        'Example Output: Cntrl.Items(i) = "Walton | Daniel"

        If Not MyDS.Tables.Contains(TableName) Then
            Return Nothing
        End If

        Dim FilteredRows() As DataRow
        Dim LVI() As ListViewItem
        Dim Rw As DataRow
        Dim UB As Integer
        Dim i As Integer
        ReDim LVI(-1)

        If FilterExpression = "*" Then FilterExpression = "1 = 1"
        FilteredRows = MyDS.Tables(TableName).Select(FilterExpression)

        'Add data items
        For Each Rw In FilteredRows
            If HasPermission(Rw.Item(AllowedUsersField).ToString, UserName) Then
                UB = LVI.GetUpperBound(0) + 1
                ReDim Preserve LVI(UB)
                LVI(UB) = New ListViewItem(ParseDBFields(FieldNames(0), Rw))
                If FieldNames.Length > 1 Then
                    For i = 1 To FieldNames.GetUpperBound(0)
                        LVI(UB).SubItems.Add(ParseDBFields(FieldNames(i), Rw))
                    Next
                End If
            End If
        Next

        Return LVI

    End Function

    ''' <summary>
    ''' Returns an array of listview items containing selected fields of selected data records.
    ''' </summary>
    ''' <param name="TableName">The datatable to pull records from</param>
    ''' <param name="FilterExpression">The filter string, e.g. "UserName = 'James'" 
    ''' The wildcard (*) may be used. Note: 
    ''' The field value must be encapsulated in single quotes. </param>
    ''' <param name="FieldNames">A list of field names whose data you want to format. 
    ''' Each field will be added to a new ListView Column.</param>
    ''' <remarks>An array of System.Windows.Forms.ListViewItems</remarks>
    Public Function GetListViewItems(ByVal TableName As String, ByVal FilterExpression As String, _
           ByVal MakeFirstFieldItemTag As Boolean, ByVal ParamArray FieldNames() As String) As ListViewItem()
        'This sub allows you to fill a listview with multiple fields.
        'Example Sytnax: FillControl("Accounts", "*", "LastName", "FirstName")
        'where 'LastName' and 'FirstName' correspond to column names in the 'Accounts' table
        'Example Output: Cntrl.Items(i) = "Walton | Daniel"

        If Not MyDS.Tables.Contains(TableName) Then
            Return Nothing
        End If

        Dim FilteredRows() As DataRow
        Dim LVI() As ListViewItem
        Dim Rw As DataRow
        Dim UB As Integer
        Dim i As Integer
        ReDim LVI(-1)

        FilteredRows = GetDataRows(TableName, FilterExpression)

        'Add data items
        For Each Rw In FilteredRows
            UB = LVI.GetUpperBound(0) + 1
            ReDim Preserve LVI(UB)
            If MakeFirstFieldItemTag Then
                LVI(UB) = New ListViewItem(ParseDBFields(FieldNames(1), Rw))
                LVI(UB).Tag = ParseDBFields(FieldNames(0), Rw)
                If FieldNames.Length > 2 Then
                    For i = 2 To FieldNames.GetUpperBound(0)
                        LVI(UB).SubItems.Add(ParseDBFields(FieldNames(i), Rw))
                    Next
                End If
            Else
                LVI(UB) = New ListViewItem(ParseDBFields(FieldNames(0), Rw))
                If FieldNames.Length > 1 Then
                    For i = 1 To FieldNames.GetUpperBound(0)
                        LVI(UB).SubItems.Add(ParseDBFields(FieldNames(i), Rw))
                    Next
                End If
            End If

        Next

        Return LVI

    End Function

    Public Function GetItems(ByVal TableName As String, ByVal FilterExpression As String, _
       ByVal ItemFormat As String, ByVal ParamArray FieldNames() As String) As String()

        'This sub allows you to fill a listbox with multiple fields formatted 
        'to your specification
        'Example Sytnax: FillControl(Cntrl, "Accounts", "{0},  {1}", "LastName", "FirstName")
        'where 'LastName' and 'FirstName' correspond to column names in the 'Accounts' table
        'Example Output: Cntrl.Items(i) = "Walton,  Daniel"
        Dim InputDT As System.Data.DataTable = MyDS.Tables(TableName)
        If InputDT Is Nothing Then
            Return Nothing
        Else
            Dim FilteredRows() As DataRow
            Dim Row As Integer ' DataRow
            Dim i As Integer
            If FilterExpression = "*" Then FilterExpression = "1 = 1"
            FilteredRows = InputDT.Select(FilterExpression)
            Dim Out(FilteredRows.GetUpperBound(0)) As String
            Dim ItemText As String
            Dim RowData(FieldNames.GetUpperBound(0)) As String

            For Row = 0 To FilteredRows.GetUpperBound(0)
                For i = 0 To FieldNames.GetUpperBound(0)
                    If FilteredRows(Row).Item(FieldNames(i)) Is DBNull.Value Then
                        RowData(i) = ""
                    Else
                        RowData(i) = CStr(FilteredRows(Row).Item(FieldNames(i)))
                    End If

                Next
                ItemText = String.Format(ItemFormat, RowData)

                Out(Row) = ItemText
            Next
            Return Out
        End If

    End Function

    Public Function GetUserItems(ByVal TableName As String, ByVal Username As String, ByVal AllowedUsersField As String, _
       ByVal FilterExpression As String, ByVal ItemFormat As String, ByVal ParamArray FieldNames() As String) As String()
        Dim InputDT As System.Data.DataTable = MyDS.Tables(TableName)
        If InputDT Is Nothing Then
            Return Nothing
        Else
            Dim FilteredRows() As DataRow
            Dim Row As Integer ' DataRow
            Dim i, UB As Integer
            If FilterExpression = "*" Then FilterExpression = "1 = 1"
            FilteredRows = InputDT.Select(FilterExpression)
            Dim Out() As String
            ReDim Out(-1)
            Dim ItemText As String
            Dim RowData(FieldNames.GetUpperBound(0)) As String

            For Row = 0 To FilteredRows.GetUpperBound(0)
                If HasPermission(FilteredRows(Row).Item(AllowedUsersField).ToString, Username) Then
                    For i = 0 To FieldNames.GetUpperBound(0)

                        If FilteredRows(Row).Item(FieldNames(i)) Is DBNull.Value Then
                            RowData(i) = ""
                        Else
                            RowData(i) = CStr(FilteredRows(Row).Item(FieldNames(i)))
                        End If
                    Next
                    ItemText = String.Format(ItemFormat, RowData)
                    UB = Out.Length
                    ReDim Preserve Out(UB)
                    Out(UB) = ItemText
                End If
            Next
            Return Out
        End If

    End Function

    ''' <summary>
    ''' Updates the database source file with any changes made to the local dataset.
    ''' </summary>
    ''' <remarks>In order to update a dataset, the parent-child order of the tables 
    ''' must be specified.</remarks>
    Public Function SendData(Optional ByVal tablename As String = "") As Boolean
        If MyDS Is Nothing Then Exit Function
        Dim Success As Boolean = True
        Dim UpdatedDS As DataSet
        If tablename = "" Then
            UpdatedDS = MyDS.GetChanges
        Else
            UpdatedDS = New DataSet
            UpdatedDS.Tables.Add(MyDS.Tables(tablename).GetChanges)
            For Each table As DataTable In MyDS.Tables
                If table.TableName <> tablename Then
                    UpdatedDS.Tables.Add(table.TableName)
                End If
            Next
        End If

        If Not UpdatedDS Is Nothing Then
            Dim Tbl As DataTable
            Dim Changed As Boolean = False

            'UpdatedDS.EnforceConstraints = False

            For Each Tbl In UpdatedDS.Tables
                If Not Tbl Is Nothing Then
                    If Tbl.Rows.Count > 0 Then
                        Changed = True
                    End If
                End If
            Next

            If Changed Then
                Dim Response As String = ""
                Try
                    Dim HG As New ProjectTrackingService_localhost.Service
                    Response = HG.PutData(_LoggedInUser, _LoggedInUserPW, UpdatedDS)
                Catch ex As Exception
                    Response = ex.Message
                Finally
                    If Response <> "OK" Then
                        Success = MessageBox.Show("Project Tracker could not send your updates to the server." + vbCrLf + _
                                  "If you exit now, your updates will be lost." + vbCrLf + _
                                  "Do you want to exit?" + vbCrLf + vbCrLf + "Error Message:" + vbCrLf + _
                                  Response, "Update Error", MessageBoxButtons.YesNo, _
                                  MessageBoxIcon.Error) = DialogResult.Yes
                    End If
                End Try
            End If
        End If

        Return Success

    End Function

    Public Sub GetData(ByVal Username As String, ByVal Password As String)

        Dim HG As New ProjectTracker.ProjectTrackingService_localhost.Service

        MyDS.Clear()
        Try
            MyDS = HG.GetData(Username, Password, _StartDate)
            If MyDS Is Nothing Then
                _LoggedInUserType = Main.UserType.None
                Exit Sub
            End If
            Dim i As Integer
            For i = 0 To MyDS.Tables.Count - 1

                Select Case MyDS.Tables(i).TableName.ToUpper
                    Case "COMPANIES", "CATEGORIES", "JOBS", "USERS", "RECORDS"
                        AddHandler MyDS.Tables(i).RowChanged, AddressOf Me.TableRowChanged
                    Case Else
                End Select
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        MyDS.AcceptChanges()
        Me.Dirty = False
        Me.Changes = ""
    End Sub

    Public Function GetJobCount(ByVal categoryID As Integer, ByVal extrafilter As String) As Integer
        'Return Me.GetDataRows("Jobs", String.Format("CategoryID={0} AND Status<>'Complete'", categoryID)).Length
        Return Me.GetDataRows("Jobs", String.Format("CategoryID={0} AND {1}", categoryID, extrafilter)).Length
    End Function

#End Region

#Region "Private Functions and Subs"

    'Private Function CStrDB(ByVal InpItem As Object) As String
    '    Try
    '        If InpItem Is DBNull.Value Then
    '            Return ""
    '        Else
    '            Return CStr(InpItem)
    '        End If
    '    Catch ex As Exception
    '        Console.WriteLine("Warning: Object '" + InpItem.ToString + "' could not be converted to string.")
    '        Return ""
    '    End Try
    'End Function

    ''' <summary>
    ''' If the database contains a table of usernames and passwords, use this function to authenticate a user.
    ''' </summary>
    ''' <param name="User">The username to authenticate</param>
    ''' <param name="UserFieldName">The name of the column that contains usernames</param>
    ''' <param name="PW">The user password to authenticate</param>
    ''' <param name="PWFieldName">The name of the column that contains passwords</param>
    ''' <param name="UserTableName">The name of the table containing username and password records</param>
    ''' <returns>Integer: 0 (failed), 1 ,2 ,3</returns>
    ''' <remarks></remarks>
    Private Function Login(ByVal User As String, ByVal PW As String, _
                                     Optional ByVal UserTableName As String = "Users", _
                                     Optional ByVal UserFieldName As String = "Username", _
                                     Optional ByVal PWFieldName As String = "UserPassword") As String
        Try
            'check for the existence of the table
            If Not MyDS.Tables.Contains(UserTableName) Then
                Return "Table '" + UserTableName + "' Not Found"
            End If

            'check for the existence of the columns
            If Not MyDS.Tables(UserTableName).Columns.Contains(UserFieldName) Then
                Return "Table '" + UserTableName + "' does not contain column '" + UserFieldName + "'."
            End If
            If Not MyDS.Tables(UserTableName).Columns.Contains(PWFieldName) Then
                Return "Table '" + UserTableName + "' does not contain column '" + PWFieldName + "'."
            End If

            'select the records with username 
            Dim DR() As DataRow = MyDS.Tables(UserTableName).Select(UserFieldName + " = '" + User + "'")

            Select Case DR.Length
                Case 0 'no records returned
                    Return "Unknown User"
                Case 1 'one record returned
                    If CType(DR(0).Item(PWFieldName), System.String) = PW Then
                        _LoggedInUser = User
                        _LoggedInUserPW = PW
                        _LoggedInUserType = CType(DR(0).Item("UserType"), UserType)
                        _LoggedInUserCompany = CStr(DR(0).Item("Company"))
                        'Date stamp is performed on server
                        'With DR(0)
                        '    .BeginEdit()
                        '    .Item("LastLogin") = Now
                        '    .EndEdit()
                        'End With
                        Return "OK"
                    Else
                        Return "Invalid Password"
                    End If
                Case Else 'too many records returned
                    Return "Non-Unique Username"
            End Select

        Catch ex As Exception
            Return "Unknown Error"
        End Try

    End Function

    Public Sub SendUpdates()
        SendData()
        GetData(Me._LoggedInUser, Me._LoggedInUserPW)
    End Sub

    Private Sub TableRowChanged(ByVal sender As Object, ByVal args As DataRowChangeEventArgs)
        Select Case args.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Delete
                Me.Dirty = True
                Dim changes As String = "Summary of Changes"
                Dim changeddb As DataSet = MyDS.GetChanges()
                For Each tbl As DataTable In changeddb.Tables
                    If tbl.Rows.Count > 0 Then
                        changes += vbCrLf + tbl.TableName + ": "
                    End If
                    Dim added As DataTable = tbl.GetChanges(DataRowState.Added) '.Rows.Count
                    Dim updated As DataTable = tbl.GetChanges(DataRowState.Modified) '.Rows.Count
                    Dim deleted As DataTable = tbl.GetChanges(DataRowState.Deleted) '.Rows.Count
                    If Not added Is Nothing Then changes += String.Format("{0} Added", added.Rows.Count)
                    If Not updated Is Nothing Then changes += String.Format(", {0} Updated", updated.Rows.Count)
                    If Not deleted Is Nothing Then changes += String.Format(", {0} Deleted", deleted.Rows.Count)
                Next
                Me.Changes = changes
        End Select
    End Sub

    Private Function GetListElements(ByVal InpStr As String) As String()
        Dim Elements() As String
        Dim Count As Integer = 0
        Dim CC As Integer = 0
        ReDim Elements(Count)
        Elements(Count) += InpStr.Chars(0)
        For CC = 1 To InpStr.Length - 1
            If System.Char.IsLetterOrDigit(InpStr.Chars(CC)) Or InpStr.Chars(CC) = "."c Then    'viewing an element character
                If Not System.Char.IsLetterOrDigit(InpStr.Chars(CC - 1)) And InpStr.Chars(CC - 1) <> "."c Then    'last character was a format character
                    Count += 1
                    ReDim Preserve Elements(Count)
                End If
                Elements(Count) += InpStr.Chars(CC)
            End If
        Next

        Return Elements
    End Function

    Private Function GetListFormat(ByVal InpStr As String) As String

        Dim ElementCount As Integer = 0
        Dim CC As Integer = 0
        Dim temp As String = "{0}"

        For CC = 1 To InpStr.Length - 1
            If System.Char.IsLetterOrDigit(InpStr.Chars(CC)) Or InpStr.Chars(CC) = "."c Then    'viewing an element character
                If Not System.Char.IsLetterOrDigit(InpStr.Chars(CC - 1)) And InpStr.Chars(CC - 1) <> "."c Then    'last character was a format character
                    ElementCount += 1
                    temp += "{" + ElementCount.ToString + "}"
                End If
            Else    'viewing a format character
                temp += InpStr.Chars(CC).ToString
            End If
        Next
        Return temp
    End Function

    Private Function ParseDBFields(ByVal InpStr As String, ByVal MyRow As DataRow) As String
        Dim Elements() As String = GetListElements(InpStr)
        Dim ElementData(Elements.GetUpperBound(0)) As Object
        Dim FormatStr As String = GetListFormat(InpStr)
        Dim FetchTable As String
        Dim FetchRow As DataRow
        Dim FetchField As String
        Dim ThisTable As DataTable = MyRow.Table
        Dim Rel As DataRelation
        Dim GetDS As DataSet = MyRow.Table.DataSet
        Dim i As Integer

        For i = 0 To Elements.GetUpperBound(0)
            FetchRow = MyRow
            FetchField = Elements(i)
            If Elements(i).IndexOf("."c) > 0 Then
                FetchTable = Elements(i).Substring(0, Elements(i).IndexOf("."c))
                FetchField = Elements(i).Substring(Elements(i).IndexOf("."c) + 1)
                For Each Rel In GetDS.Tables(FetchTable).ChildRelations
                    If Rel.ChildTable Is ThisTable Then
                        FetchRow = MyRow.GetParentRow(Rel.RelationName)
                        Exit For
                    End If
                Next
            End If
            ElementData(i) = FetchRow.Item(FetchField)
        Next

        Return [String].Format(FormatStr, ElementData)

    End Function

    Private Function HasPermission(ByVal Permissionstring As String, ByVal UserName As String) As Boolean
        Return ("," + Permissionstring.ToUpper.Replace(" ", "") + ",").IndexOf("," + UserName.ToUpper + ",") >= 0
    End Function

#End Region

End Class


