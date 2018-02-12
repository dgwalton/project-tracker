<%@ WebService Language="vb" CodeBehind="~/App_Code/Service.vb" Class="Service" %>

'Option Strict On
'Option Explicit On

'Imports System.Web
'Imports System.Web.Services
'Imports System.Data
'Imports System.Data.OleDb

'<WebService(Namespace:="http://localhost:51894/DPSProjectTrackingService_localhost/")> _
'<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
'<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
'Public Class Service
'    Inherits WebService

'    'Settings to be changed as needed
'    Private DBFile As String = Server.MapPath("~/App_Data/DPS.mdb")
'    Private TransactionIsolation As IsolationLevel = IsolationLevel.ReadCommitted

'    Private Enum UserType
'        None = 0
'        Administrator = 1
'        Customer = 2
'        Employee = 3
'    End Enum

'    'ADO Objects
'    Private FullDS As DataSet
'    Private UpdateDS As DataSet

'    'OLEDB Objects
'    Private Conn As OleDbConnection
'    Private Transaction As OleDbTransaction
'    Private IdentityCommand As OleDbCommand

'    'OLEDB Table Adapters
'    Private RecordAdapter As OleDbDataAdapter
'    Private EmailAdapter As OleDbDataAdapter
'    Private UserAdapter As OleDbDataAdapter
'    Private JobAdapter As OleDbDataAdapter
'    Private CategoryAdapter As OleDbDataAdapter
'    Private CompanyAdapter As OleDbDataAdapter

'    <WebMethod()> Public Function GetData(ByVal Username As String, ByVal Password As String, _
'                  ByVal StartWork As System.DateTime) As Data.DataSet
'        Dim DS As DataSet
'        Try

'            OpenConnection()

'            Dim ThisUserType As UserType = Authenticate(Username, Password)

'            If ThisUserType = UserType.None Then
'                DS = Nothing
'            Else
'                SetupDataSet(True)

'                Select Case ThisUserType
'                    Case UserType.Administrator 'GET ALL COMPANIES, ALL USERS
'                        'select all companies
'                        FillAdapter(CompanyAdapter, "Companies")
'                        'select all users
'                        FillAdapter(UserAdapter, "Users")
'                    Case UserType.Customer
'                        Dim Co As String = GetCompany(Username)
'                        'select company belonging to current user
'                        FillAdapter(CompanyAdapter, "Companies", "Company='" + Co + "'")

'                        'All non-admin users (type 2 or 3) whose company is current company
'                        Dim filter As String = "((([UserType]=2) OR ([UserType]=3)) AND ([Company]='" + Co + "'))"

'                        'All users in company.allowedusers
'                        Dim AllUsers As New ArrayList
'                        For Each r As DataRow In FullDS.Tables("Companies").Select()
'                            For Each u As String In CStr(r("AllowedUsers")).Split(","c)
'                                If AllUsers.IndexOf(u.Trim) < 0 Then
'                                    AllUsers.Add(u.Trim)
'                                End If
'                            Next
'                        Next

'                        If AllUsers.Count > 0 Then
'                            filter = "(Username IN ('" + String.Join("','", CstrA(AllUsers)) + "')) OR " + filter
'                        End If

'                        FillAdapter(UserAdapter, "Users", filter)

'                    Case UserType.Employee
'                        'get companies WHERE ALLOWEDUSERS CONTAINS USERNAME
'                        Dim c As New OleDbCommand("SELECT [Companies].* FROM [Companies]", Conn, Transaction)
'                        Dim r As OleDbDataReader = c.ExecuteReader(CommandBehavior.SingleResult)
'                        Dim CoList As New ArrayList
'                        Do While r.Read
'                            If ("," + CStr(r("AllowedUsers")).Replace(" ", "") + ",").IndexOf("," + Username + ",") >= 0 Then
'                                CoList.Add(r("Company"))
'                            End If
'                        Loop
'                        r.Close()
'                        c.Dispose()
'                        If CoList.Count > 0 Then
'                            FillAdapter(CompanyAdapter, "Companies", "Company IN ('" + String.Join("','", CstrA(CoList)) + "')")
'                        End If
'                        'Get users where username=username
'                        FillAdapter(UserAdapter, "Users", "UserName='" + Username + "'")
'                End Select

'                FillAdapter(CategoryAdapter, "Categories", New String() {"Companies"}, New String() {"Company"}, New String() {"Company"}, "")
'                FillAdapter(JobAdapter, "Jobs", New String() {"Categories"}, New String() {"CategoryID"}, New String() {"CategoryID"}, "")
'                FillAdapter(EmailAdapter, "Emails", New String() {"Jobs"}, New String() {"JobID"}, New String() {"JobID"}, "")
'                FillAdapter(RecordAdapter, "Records", New String() {"Jobs", "Users"}, New String() {"JobID", "UserName"}, New String() {"JobID", "UserName"}, String.Format("[DateWorked] >= {0:0000}{1:00}{2:00}", StartWork.Year, StartWork.Month, StartWork.Day))

'                'Add ReservedUserNames Table
'                Dim ru As DataTable = FullDS.Tables.Add("ReservedUserNames")
'                ru.Columns.Add("UserName")
'                Dim rdr As OleDbDataReader = New OleDbCommand("SELECT UserName FROM [Users]", Conn, Transaction).ExecuteReader()
'                Do While rdr.Read
'                    ru.Rows.Add(rdr("UserName"))
'                Loop
'                rdr.Close()

'                DS = FullDS

'            End If

'            Transaction.Commit()

'        Catch ex As Exception
'            Throw ex
'            DS = Nothing

'        End Try
'        Dispose()
'        Return DS

'    End Function

'    <WebMethod()> Public Function PutData(ByVal Username As String, ByVal Password As String, _
'                                             ByVal UpdatedDataSet As Data.DataSet) As String

'        Dim Result As String = ""

'        Try
'            OpenConnection()
'            If Authenticate(Username, Password) <> UserType.None Then

'                SetupDataSet(False)

'                UpdateDS = UpdatedDataSet

'                Try
'                    SendJobEmails()
'                Catch ex As Exception
'                    'ingore exception
'                End Try

'                'Delete rows in child tables first
'                DeleteRows(RecordAdapter)
'                DeleteRows(EmailAdapter)
'                DeleteRows(UserAdapter)
'                DeleteRows(JobAdapter)
'                DeleteRows(CategoryAdapter)
'                DeleteRows(CompanyAdapter)

'                'Insert/Update in parent tables first
'                InsertRows(CompanyAdapter)
'                UpdateRows(CompanyAdapter)
'                InsertRows(UserAdapter)
'                UpdateRows(UserAdapter)
'                InsertRows(CategoryAdapter)
'                UpdateRows(CategoryAdapter)

'                InsertRows(JobAdapter)
'                UpdateRows(JobAdapter)

'                InsertRows(RecordAdapter)
'                UpdateRows(RecordAdapter)
'                InsertRows(EmailAdapter)
'                UpdateRows(EmailAdapter)

'                Transaction.Commit()
'                Dispose()
'                Result = "OK"
'            Else
'                Result = "Invalid Login"
'            End If
'        Catch ex As Exception
'            Transaction.Rollback()
'            Result = ex.ToString
'        End Try

'        Return Result

'    End Function

'    Private Function Authenticate(ByVal User As String, ByVal PW As String) As UserType

'        Dim da As New OleDbDataAdapter("SELECT * FROM Users WHERE [Username]='" + User + "' AND [UserPassword]='" + PW + "'", Conn)
'        da.SelectCommand.Transaction = Transaction
'        Dim Results As New DataTable
'        If da.Fill(Results) = 1 Then
'            Return CType(Results.Rows(0).Item("UserType"), UserType)
'        Else
'            Return UserType.None
'        End If
'        da.Dispose()


'    End Function

'    Private Function CstrA(ByVal AL As ArrayList) As String()
'        Dim out(AL.Count - 1) As String
'        For i As Integer = 0 To AL.Count - 1
'            out(i) = CStr(AL(i))
'        Next
'        Return out
'    End Function

'    Private Sub DeleteRows(ByRef DA As OleDbDataAdapter)
'        Dim DeletedData As DataTable = UpdateDS.Tables(DA.TableMappings(0).DataSetTable).GetChanges(DataRowState.Deleted)
'        If DeletedData Is Nothing OrElse DeletedData.Rows.Count = 0 Then Exit Sub
'        DA.Update(DeletedData)
'    End Sub

'    Private Overloads Sub Dispose()

'        Conn.Close()
'        If Not FullDS Is Nothing Then
'            FullDS.Dispose()
'            EmailAdapter.Dispose()
'            UserAdapter.Dispose()
'            JobAdapter.Dispose()
'            CategoryAdapter.Dispose()
'            CompanyAdapter.Dispose()
'        End If
'        Transaction.Dispose()
'        Conn.Dispose()

'    End Sub

'    Private Sub FillAdapter(ByRef Adapter As OleDbDataAdapter, ByVal SourceTable As String, Optional ByVal FilterExp As String = "")
'        If FilterExp <> "" Then
'            Adapter.SelectCommand.CommandText += " WHERE " + FilterExp
'        End If
'        Adapter.Fill(FullDS.Tables(SourceTable))
'    End Sub

'    Private Sub FillAdapter(ByRef Adapter As OleDbDataAdapter, ByVal SourceTable As String, _
'        ByVal FilterTables() As String, ByVal FilterColumnNames() As String, ByVal SourceColumnNames() As String, ByVal ExtraFilter As String)

'        Dim Filters As New ArrayList
'        For i As Integer = 0 To FilterTables.Length - 1
'            Dim FilterRows As DataRow() = FullDS.Tables(FilterTables(i)).Select
'            If FilterRows.Length > 0 Then
'                Dim FilterValues(FilterRows.GetUpperBound(0)) As String
'                Dim Quote As String = ""
'                Select Case FullDS.Tables(FilterTables(i)).Columns(FilterColumnNames(i)).DataType.Name
'                    Case "String", "DateTime"
'                        Quote = "'"
'                End Select
'                For rw As Integer = 0 To FilterRows.GetUpperBound(0)
'                    FilterValues(rw) = Quote + CStr(FilterRows(rw).Item(FilterColumnNames(i))) + Quote
'                Next
'                Filters.Add(String.Format("[{0}].[{1}] IN ({2})", SourceTable, SourceColumnNames(i), String.Join(",", FilterValues)))
'            Else 'No rows means no records here
'                Exit Sub
'            End If
'        Next
'        If Filters.Count = FilterTables.Length Then
'            If ExtraFilter <> "" Then Filters.Add(ExtraFilter)
'            Dim filterexp As String = "(" + String.Join(") AND (", CstrA(Filters)) + ")"
'            FillAdapter(Adapter, SourceTable, filterexp)
'        End If

'    End Sub

'    Private Function GetCompany(ByVal Username As String) As String
'        Dim c As New OleDbCommand("SELECT [Users].[Company] FROM [Users] WHERE [Username]='" + Username + "'", Conn, Transaction)
'        Dim result As String = CStr(c.ExecuteScalar)
'        c.Dispose()
'        Return result
'    End Function

'    Private Function GetLastInsertedAutoNumber() As Integer
'        Return CInt(IdentityCommand.ExecuteScalar())
'    End Function

'    Private Sub InsertRows(ByRef DA As OleDbDataAdapter)

'        Dim Tbl As DataTable = UpdateDS.Tables(DA.TableMappings(0).DataSetTable)
'        Dim AddedData As DataTable = Tbl.GetChanges(DataRowState.Added)
'        If AddedData Is Nothing OrElse AddedData.Rows.Count = 0 Then Exit Sub

'        If AddedData.PrimaryKey(0).AutoIncrement And Tbl.ChildRelations.Count > 0 Then
'            'Perform inserts one row at a time and check autonumber values if children exist
'            Dim PKCol As Integer = AddedData.PrimaryKey(0).Ordinal
'            For Each Row As DataRow In AddedData.Rows
'                DA.Update(New DataRow() {Row})
'                Dim oldrowid As Integer = CInt(Row.Item(PKCol))
'                Dim newrowid As Integer = GetLastInsertedAutoNumber()
'                If newrowid <> oldrowid Then
'                    'Change the ADO (disconnected, received via web) record to match the OLEDB (on-disk, just added) row
'                    'This will cascade the new identity value to all child rows
'                    Tbl.Rows.Find(oldrowid).Item(PKCol) = newrowid
'                End If
'            Next Row
'        Else
'            'No potential for referential integrity violation with child rows, so
'            'perform a 'bulk' table update
'            DA.Update(AddedData)
'        End If

'    End Sub

'    Private Sub OpenConnection()

'        'If Conn Is Nothing Then
'        '    Dim CB As New OleDbConnectionStringBuilder
'        '    CB.DataSource = DBFile
'        '    CB.Provider = "Microsoft.Jet.OLEDB.4.0"
'        '    CB.PersistSecurityInfo = False
'        '    CB.Add("User ID", "Admin")
'        '    Conn = New OleDbConnection(CB.ConnectionString)
'        '    CB.Clear()
'        'End If
'        Dim SB As New StringBuilder()
'        SB.Append("Provider=" + Chr(34) + "Microsoft.Jet.OLEDB.4.0" + Chr(34) + ";")
'        SB.Append("Data Source=" + Chr(34) + DBFile + Chr(34) + ";")
'        SB.Append("Mode=Share Deny None;")
'        SB.Append("persist security info=False;")
'        SB.Append("Extended Properties=;")
'        SB.Append("User ID=Admin;")
'        SB.Append("Jet OLEDB:Global Partial Bulk Ops=2;")
'        SB.Append("Jet OLEDB:Registry Path=;")
'        SB.Append("Jet OLEDB:Database Locking Mode=1;")
'        SB.Append("Jet OLEDB:Engine Type=5;")
'        SB.Append("Jet OLEDB:System database=;")
'        SB.Append("Jet OLEDB:SFP=False;")
'        SB.Append("Jet OLEDB:Compact Without Replica Repair=False;")
'        SB.Append("Jet OLEDB:Encrypt Database=False;")
'        SB.Append("Jet OLEDB:Create System Database=False;")
'        SB.Append("Jet OLEDB:Don't Copy Locale on Compact=False;")
'        'SB.Append("Jet OLEDB:Global Bulk Transactions=1")

'        Conn = New OleDb.OleDbConnection(SB.ToString)
'        If Conn.State = ConnectionState.Broken Then Conn.Close()
'        If Conn.State = ConnectionState.Closed Then Conn.Open()
'        Transaction = Conn.BeginTransaction(TransactionIsolation)

'    End Sub

'    Private Sub SendEmail(ByVal MailTo As Net.Mail.MailAddressCollection, ByVal From As Net.Mail.MailAddress, ByVal Subject As String, ByVal Body As String)
'        Dim c As New System.Net.Mail.SmtpClient
'        c.Send(From.ToString, MailTo.ToString, Subject, Body)
'        c.Send(new 
'    End Sub

'    Private Sub SendEmail(ByVal UserNames() As String, ByVal Subject As String, ByVal Body As String)

'        Dim Recipients As New System.Net.Mail.MailAddressCollection()
'        Dim r As OleDbDataReader = New OleDbCommand( _
'                                    "SELECT UserName, LastName, FirstName, UserEmail FROM Users WHERE UserName IN ('" + _
'                                    String.Join("','", UserNames) + "')", Conn, Transaction).ExecuteReader
'        Do While r.Read
'            Recipients.Add(New System.Net.Mail.MailAddress(CStr(r("UserEmail")), CStr(r("FirstName")) + " " + CStr(r("LastName"))))
'        Loop

'        SendEmail(Recipients, New System.Net.Mail.MailAddress("Notify@DPSpec.com", "DPS Job Notifications"), Subject, Body)
'    End Sub

'    Private Sub SendJobEmails()
'        For Each JobRow As DataRow In UpdateDS.Tables("Jobs").GetChanges().Rows
'            If JobRow.RowState = DataRowState.Added Or JobRow.RowState = DataRowState.Modified Then
'                Dim subj As String = "Job Update Notification"
'                If JobRow.RowState = DataRowState.Added Then subj = "New Job Notification"
'                Dim body As String = ""
'                For i As Integer = 0 To JobRow.Table.Columns.Count - 1
'                    body += String.Format("{0,-25}: {1}{2}", JobRow.Table.Columns(i).ColumnName, JobRow(i), vbCrLf)
'                Next
'                Dim userlist As String = CStr(JobRow("NotifyEmail"))

'                If userlist.Equals("All Allowed Users") Then
'                    Dim co As String = CStr(New OleDbCommand("SELECT Categories.Company FROM Categories WHERE CategoryID=" + _
'                        CStr(JobRow("CategoryID")), Conn, Transaction).ExecuteScalar)
'                    userlist = CStr(New OleDbCommand("SELECT AllowedUsers FROM Companies WHERE Company='" + _
'                               co + "'", Conn, Transaction).ExecuteScalar)
'                End If

'                SendEmail(userlist.Replace(" ", "").Split(","c), "New Job Notification", body)
'            End If
'        Next
'    End Sub

'    Private Sub SetupDataAdapter(ByRef DA As OleDbDataAdapter, ByVal TableName As String, ByVal GetSelectCommandOnly As Boolean)

'        DA = New OleDbDataAdapter("SELECT [" + TableName & "].* FROM [" + TableName + "]", Conn)

'        DA.SelectCommand.CommandType = CommandType.Text
'        DA.SelectCommand.UpdatedRowSource = UpdateRowSource.Both
'        DA.SelectCommand.Transaction = Transaction

'        If Not GetSelectCommandOnly Then
'            Dim CB As New OleDbCommandBuilder(DA)
'            DA.InsertCommand = CB.GetInsertCommand
'            DA.InsertCommand.Transaction = Transaction
'            DA.InsertCommand.UpdatedRowSource = UpdateRowSource.Both

'            DA.UpdateCommand = CB.GetUpdateCommand
'            DA.UpdateCommand.Transaction = Transaction
'            DA.UpdateCommand.UpdatedRowSource = UpdateRowSource.Both

'            DA.DeleteCommand = CB.GetDeleteCommand
'            DA.DeleteCommand.Transaction = Transaction
'            DA.DeleteCommand.UpdatedRowSource = UpdateRowSource.Both
'        End If

'        DA.MissingMappingAction = MissingMappingAction.Error
'        DA.MissingSchemaAction = MissingSchemaAction.Error
'        DA.FillSchema(FullDS, SchemaType.Source, TableName)

'        Dim NewDTM As Common.DataTableMapping = DA.TableMappings.Add(TableName, TableName)
'        For Each Col As DataColumn In FullDS.Tables(TableName).Columns
'            NewDTM.ColumnMappings.Add(Col.ColumnName, Col.ColumnName)
'        Next

'    End Sub

'    Private Sub SetupDataSet(ByVal GetSelectCommandsOnly As Boolean)

'        FullDS = New DataSet

'        'Initialize table adapters
'        SetupDataAdapter(CompanyAdapter, "Companies", GetSelectCommandsOnly)
'        SetupDataAdapter(CategoryAdapter, "Categories", GetSelectCommandsOnly)
'        SetupDataAdapter(JobAdapter, "Jobs", GetSelectCommandsOnly)
'        SetupDataAdapter(UserAdapter, "Users", GetSelectCommandsOnly)
'        SetupDataAdapter(EmailAdapter, "Emails", GetSelectCommandsOnly)
'        SetupDataAdapter(RecordAdapter, "Records", GetSelectCommandsOnly)

'        'Add a database relation for all rows in the schema table
'        For Each Row As DataRow In Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, New Object() {Nothing, Nothing, Nothing, Nothing}).Rows
'            Dim PT As String = CStr(Row("PK_TABLE_NAME"))
'            Dim CT As String = CStr(Row("FK_TABLE_NAME"))
'            Dim PC As String = CStr(Row("PK_COLUMN_NAME"))
'            Dim CC As String = CStr(Row("FK_COLUMN_NAME"))
'            FullDS.Relations.Add(String.Format("{0}_{1}_{2}_{3}", PT, PC, CT, CC), _
'                 FullDS.Tables(PT).Columns(PC), FullDS.Tables(CT).Columns(CC))
'        Next

'        'Set up identity command
'        IdentityCommand = New OleDbCommand("SELECT @@IDENTITY", Conn, Transaction)

'    End Sub

'    Private Sub UpdateRows(ByRef DA As OleDbDataAdapter)
'        Dim ModifiedData As DataTable = UpdateDS.Tables(DA.TableMappings(0).DataSetTable).GetChanges(DataRowState.Modified)
'        If ModifiedData Is Nothing OrElse ModifiedData.Rows.Count = 0 Then Exit Sub
'        DA.Update(ModifiedData)
'    End Sub

'End Class
