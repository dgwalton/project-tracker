Option Strict On
Option Explicit On

Imports System.Web
Imports System.Web.Services
Imports System.Data
Imports System.Data.OleDb

<WebService(Namespace:="http://www.dpspec.com/ProjectTracking/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service

    Inherits System.Web.Services.WebService

#Region "Declarations"

    'Settings to be changed as needed
    Private DBFile As String = Server.MapPath("~/App_Data/DPS.mdb")
    Private ReadIso As IsolationLevel = IsolationLevel.ReadCommitted
    Private WriteIso As IsolationLevel = IsolationLevel.ReadCommitted

    Private Enum UserType
        None = 0
        Administrator = 1
        Customer = 2
        Employee = 3
    End Enum

    'ADO Objects
    Private FullDS As DataSet
    Private UpdateDS As DataSet

    'OLEDB Objects
    Private Conn As OleDbConnection
    Private Transaction As OleDbTransaction
    Private IdentityCommand As OleDbCommand

    'OLEDB Table Adapters
    Private RecordAdapter As OleDbDataAdapter
    Private EmailAdapter As OleDbDataAdapter
    Private UserAdapter As OleDbDataAdapter
    Private JobAdapter As OleDbDataAdapter
    Private CategoryAdapter As OleDbDataAdapter
    Private CompanyAdapter As OleDbDataAdapter

#End Region

#Region "Public Web Methods"

    <WebMethod()> Public Function GetData(ByVal Username As String, ByVal Password As String, _
                  ByVal StartWork As System.DateTime) As Data.DataSet
        Dim DS As DataSet
        Try

            OpenConnection(ReadIso)

            Dim ThisUserType As UserType = Authenticate(Username, Password)

            If ThisUserType = UserType.None Then
                DS = Nothing
            Else
                SetupDataSet(True)

                Select Case ThisUserType
                    Case UserType.Administrator 'GET ALL COMPANIES, ALL USERS
                        'select all companies
                        FillAdapter(CompanyAdapter, "Companies")
                        'select all users
                        FillAdapter(UserAdapter, "Users")
                    Case UserType.Customer
                        Dim Co As String = GetCompany(Username)
                        'select company belonging to current user
                        FillAdapter(CompanyAdapter, "Companies", "Company='" + Co + "'")

                        'All non-admin users (type 2 or 3) whose company is current company
                        Dim filter As String = "((([UserType]=2) OR ([UserType]=3)) AND ([Company]='" + Co + "'))"

                        'All users in company.allowedusers
                        Dim AllUsers As New ArrayList
                        For Each r As DataRow In FullDS.Tables("Companies").Select()
                            For Each u As String In CStr(r("AllowedUsers")).Split(","c)
                                If AllUsers.IndexOf(u.Trim) < 0 Then
                                    AllUsers.Add(u.Trim)
                                End If
                            Next
                        Next

                        If AllUsers.Count > 0 Then
                            filter = "(Username IN ('" + String.Join("','", CstrA(AllUsers)) + "')) OR " + filter
                        End If

                        FillAdapter(UserAdapter, "Users", filter)

                    Case UserType.Employee
                        'get companies WHERE ALLOWEDUSERS CONTAINS USERNAME
                        Dim CoList As New ArrayList
                        Using c As New OleDbCommand("SELECT [Companies].* FROM [Companies]", Conn, Transaction)
                            Dim r As OleDbDataReader = c.ExecuteReader(CommandBehavior.SingleResult)
                            Do While r.Read
                                If ("," + CStr(r("AllowedUsers")).Replace(" ", "") + ",").IndexOf("," + Username + ",") >= 0 Then
                                    CoList.Add(r("Company"))
                                End If
                            Loop
                            r.Close()
                        End Using


                        If CoList.Count > 0 Then
                            FillAdapter(CompanyAdapter, "Companies", "Company IN ('" + String.Join("','", CstrA(CoList)) + "')")
                        End If
                        'Get users where username=username
                        FillAdapter(UserAdapter, "Users", "UserName='" + Username + "'")
                End Select

                FillAdapter(CategoryAdapter, "Categories", New String() {"Companies"}, New String() {"Company"}, New String() {"Company"}, "")
                FillAdapter(JobAdapter, "Jobs", New String() {"Categories"}, New String() {"CategoryID"}, New String() {"CategoryID"}, "")
                FillAdapter(EmailAdapter, "Emails", New String() {"Jobs"}, New String() {"JobID"}, New String() {"JobID"}, "")
                FillAdapter(RecordAdapter, "Records", New String() {"Jobs", "Users"}, New String() {"JobID", "UserName"}, New String() {"JobID", "UserName"}, String.Format("[DateWorked] >= {0:0000}{1:00}{2:00}", StartWork.Year, StartWork.Month, StartWork.Day))

                'Add ReservedUserNames Table
                Dim ru As DataTable = FullDS.Tables.Add("ReservedUserNames")
                ru.Columns.Add("UserName")
                Using rdr As OleDbDataReader = New OleDbCommand("SELECT UserName FROM [Users]", Conn, Transaction).ExecuteReader()
                    Do While rdr.Read
                        ru.Rows.Add(rdr("UserName"))
                    Loop
                End Using

                'Add NotifyAdmins Table
                'Add ReservedUserNames Table
                Dim admins As DataTable = FullDS.Tables.Add("Admins")
                admins.Columns.Add("UserName", GetType(System.String))
                admins.Columns.Add("UserType", GetType(System.Int16))
                admins.Columns.Add("Company", GetType(System.String))
                Using rdr As OleDbDataReader = New OleDbCommand("SELECT [UserName], [UserType], [Company] FROM [Users] WHERE " + _
                    "[Deactivated]=false AND ([UserType]=1 OR [UserType]=2)", Conn, Transaction).ExecuteReader()
                    Do While rdr.Read
                        admins.Rows.Add(rdr("UserName"), rdr("UserType"), rdr("Company"))
                    Loop
                End Using

                DS = FullDS

            End If

            Transaction.Commit()
            Dispose()

        Catch ex As Exception
            Dispose()
            Throw ex
            DS = Nothing
        End Try

        BackupFile()

        Return DS

    End Function

    <WebMethod()> Public Function PutData(ByVal Username As String, ByVal Password As String, _
                                             ByVal UpdatedDataSet As Data.DataSet) As String

        Dim Result As String = ""

        Try
            OpenConnection(WriteIso)

            If Authenticate(Username, Password) <> UserType.None Then

                SetupDataSet(False)

                UpdateDS = UpdatedDataSet

                'Delete rows in child tables first
                DeleteRows(RecordAdapter)
                DeleteRows(EmailAdapter)
                DeleteRows(UserAdapter)
                DeleteRows(JobAdapter)
                DeleteRows(CategoryAdapter)
                DeleteRows(CompanyAdapter)

                'Insert/Update in parent tables first
                InsertRows(CompanyAdapter)
                UpdateRows(CompanyAdapter)
                InsertRows(UserAdapter)
                UpdateRows(UserAdapter)
                InsertRows(CategoryAdapter)
                UpdateRows(CategoryAdapter)

                InsertRows(JobAdapter)
                UpdateRows(JobAdapter)

                InsertRows(RecordAdapter)
                UpdateRows(RecordAdapter)
                InsertRows(EmailAdapter)
                UpdateRows(EmailAdapter)

                SendJobEmails()
                SendWorkRecordEmails()

                Transaction.Commit()

                Result = "OK"
            Else
                Result = "Invalid Login"
            End If
        Catch ex As Exception
            If Not Transaction Is Nothing Then Transaction.Rollback()
            Result = ex.ToString
        End Try

        Dispose()

        Return Result

    End Function

#End Region

#Region "Private Methods"

    Private Function Authenticate(ByVal User As String, ByVal PW As String) As UserType

        Dim result As UserType = UserType.None
        Try
            Using c As New OleDbCommand("SELECT * FROM Users WHERE [Username]='" + User + _
            "' AND [UserPassword]='" + PW + "' AND [Deactivated]=false", Conn, Transaction)
                Using r As OleDbDataReader = c.ExecuteReader
                    If r.HasRows Then
                        Dim count As Integer = 0
                        Do While r.Read
                            count += 1
                            result = CType(r("UserType"), UserType)
                        Loop
                        If count = 1 Then
                            'Authenticated! Set date stamp
                            Using c2 As New OleDbCommand(String.Format( _
                            "UPDATE [Users] SET [LastLogin]=#{0:MM/dd/yyyy hh:mm:ss}# WHERE [Username]='{1}'", Now, User), Conn, Transaction)
                                c2.ExecuteNonQuery()
                            End Using
                        End If
                        If count > 1 Then result = UserType.None
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error in Authenticate: " + ex.ToString)
        End Try


        Return result

    End Function

    Private Sub BackupFile()
        Dim datadir As String = "~/App_Data/"
        Dim firstdayofthismonth As New Date(Now.Year, Now.Month, 1, 0, 0, 0)
        Dim lastbackupdate As New Date(2000, 1, 1)
        Dim lastbackupfile As String = ""
        For Each file As String In IO.Directory.GetFiles(Server.MapPath(datadir), "*.backup")
            Dim writetime As Date = New IO.FileInfo(file).LastWriteTime
            If writetime.CompareTo(lastbackupdate) > 0 Then
                lastbackupdate = writetime
                lastbackupfile = file
            End If
        Next
        If lastbackupdate < firstdayofthismonth Then
            Dim newfile As String = Server.MapPath(datadir + "DPS." + Now.ToString("yyyyMMdd") + ".backup")
            IO.File.Copy(DBFile, newfile)
        End If

    End Sub

    Private Function CstrA(ByVal AL As ArrayList) As String()
        Dim out(AL.Count - 1) As String
        For i As Integer = 0 To AL.Count - 1
            out(i) = CStr(AL(i))
        Next
        Return out
    End Function

    Private Sub DeleteRows(ByRef DA As OleDbDataAdapter)
        Dim DeletedData As DataTable = UpdateDS.Tables(DA.TableMappings(0).DataSetTable).GetChanges(DataRowState.Deleted)
        If DeletedData Is Nothing OrElse DeletedData.Rows.Count = 0 Then Exit Sub
        DA.Update(DeletedData)
    End Sub

    Private Overloads Sub Dispose()

        Conn.Close()
        If Not FullDS Is Nothing Then FullDS.Dispose()
        If Not EmailAdapter Is Nothing Then EmailAdapter.Dispose()
        If Not UserAdapter Is Nothing Then UserAdapter.Dispose()
        If Not JobAdapter Is Nothing Then JobAdapter.Dispose()
        If Not CategoryAdapter Is Nothing Then CategoryAdapter.Dispose()
        If Not CompanyAdapter Is Nothing Then CompanyAdapter.Dispose()
        If Not Transaction Is Nothing Then Transaction.Dispose()
        If Not Conn Is Nothing Then Conn.Dispose()

    End Sub

    Private Sub FillAdapter(ByRef Adapter As OleDbDataAdapter, ByVal SourceTable As String, Optional ByVal FilterExp As String = "")
        If FilterExp <> "" Then
            Adapter.SelectCommand.CommandText += " WHERE " + FilterExp
        End If
        Adapter.Fill(FullDS.Tables(SourceTable))
    End Sub

    Private Sub FillAdapter(ByRef Adapter As OleDbDataAdapter, ByVal SourceTable As String, _
        ByVal FilterTables() As String, ByVal FilterColumnNames() As String, ByVal SourceColumnNames() As String, ByVal ExtraFilter As String)

        Dim Filters As New ArrayList
        For i As Integer = 0 To FilterTables.Length - 1
            Dim FilterRows As DataRow() = FullDS.Tables(FilterTables(i)).Select
            If FilterRows.Length > 0 Then
                Dim FilterValues(FilterRows.GetUpperBound(0)) As String
                Dim Quote As String = ""
                Select Case FullDS.Tables(FilterTables(i)).Columns(FilterColumnNames(i)).DataType.Name
                    Case "String", "DateTime"
                        Quote = "'"
                End Select
                For rw As Integer = 0 To FilterRows.GetUpperBound(0)
                    FilterValues(rw) = Quote + CStr(FilterRows(rw).Item(FilterColumnNames(i))) + Quote
                Next
                Filters.Add(String.Format("[{0}].[{1}] IN ({2})", SourceTable, SourceColumnNames(i), String.Join(",", FilterValues)))
            Else 'No rows means no records here
                Exit Sub
            End If
        Next
        If Filters.Count = FilterTables.Length Then
            If ExtraFilter <> "" Then Filters.Add(ExtraFilter)
            Dim filterexp As String = "(" + String.Join(") AND (", CstrA(Filters)) + ")"
            FillAdapter(Adapter, SourceTable, filterexp)
        End If

    End Sub

    Private Function GetCompany(ByVal Username As String) As String
        Dim c As New OleDbCommand("SELECT [Users].[Company] FROM [Users] WHERE [Username]='" + Username + "'", Conn, Transaction)
        Dim result As String = CStr(c.ExecuteScalar)
        c.Dispose()
        Return result
    End Function

    Private Function GetLastInsertedAutoNumber() As Integer
        Return CInt(IdentityCommand.ExecuteScalar())
    End Function

    Private Sub InsertRows(ByRef DA As OleDbDataAdapter)

        Dim Tbl As DataTable = UpdateDS.Tables(DA.TableMappings(0).DataSetTable)
        Dim AddedData As DataTable = Tbl.GetChanges(DataRowState.Added)
        If AddedData Is Nothing OrElse AddedData.Rows.Count = 0 Then Exit Sub

        If AddedData.PrimaryKey(0).AutoIncrement And Tbl.ChildRelations.Count > 0 Then
            'Perform inserts one row at a time and check autonumber values if children exist
            Dim PKCol As Integer = AddedData.PrimaryKey(0).Ordinal
            For Each Row As DataRow In AddedData.Rows
                DA.Update(New DataRow() {Row})
                Dim oldrowid As Integer = CInt(Row.Item(PKCol))
                Dim newrowid As Integer = GetLastInsertedAutoNumber()
                If newrowid <> oldrowid Then
                    'Change the ADO (disconnected, received via web) record to match the OLEDB (on-disk, just added) row
                    'This will cascade the new identity value to all child rows
                    Tbl.Rows.Find(oldrowid).Item(PKCol) = newrowid
                End If
            Next Row
        Else
            'No potential for referential integrity violation with child rows, so
            'perform a 'bulk' table update
            DA.Update(AddedData)
        End If

    End Sub

    Private Sub OpenConnection(ByVal Isolation As IsolationLevel)
        Try


            'If Conn Is Nothing Then
            '    Dim CB As New OleDbConnectionStringBuilder
            '    CB.DataSource = DBFile
            '    CB.Provider = "Microsoft.Jet.OLEDB.4.0"
            '    CB.PersistSecurityInfo = False
            '    CB.Add("User ID", "Admin")
            '    Conn = New OleDbConnection(CB.ConnectionString)
            '    CB.Clear()
            'End If
            Dim SB As New StringBuilder()
            SB.Append("Provider=""Microsoft.Jet.OLEDB.4.0"";")
            SB.Append("Data Source=" + Chr(34) + DBFile + Chr(34) + ";")
            'If Isolation < IsolationLevel.ReadCommitted Then
            'SB.Append("Mode=Share Deny None;")
            'End If
            SB.Append("Persist Security Info=False;")
            SB.Append("Extended Properties=;")
            SB.Append("User ID=Admin;")
            SB.Append("Jet OLEDB:Global Partial Bulk Ops=2;") '1=Partial Operations allowed, 2=Partial operations rolled back on error
            SB.Append("Jet OLEDB:Registry Path=;")
            SB.Append("Jet OLEDB:Database Locking Mode=1;") '0=page level, 1=row level
            SB.Append("Jet OLEDB:Engine Type=5;") '5 for Access 2003+
            SB.Append("Jet OLEDB:System database=;")
            SB.Append("Jet OLEDB:SFP=False;")
            SB.Append("Jet OLEDB:Compact Without Replica Repair=False;")
            SB.Append("Jet OLEDB:Encrypt Database=False;")
            SB.Append("Jet OLEDB:Create System Database=False;")
            SB.Append("Jet OLEDB:Don't Copy Locale on Compact=False;")
            SB.Append("Jet OLEDB:Global Bulk Transactions=2") '0=default, 1=not transacted, 2=transacted

            Conn = New OleDb.OleDbConnection(SB.ToString)
            'If Conn.State = ConnectionState.Broken Then Conn.Close()
            'Dim sec_waiting As Integer = 0
            'Do Until Conn.State = ConnectionState.Closed Or sec_waiting = 10
            '    System.Threading.Thread.Sleep(1000)
            '    sec_waiting += 1
            'Loop
            Conn.Open()
            Transaction = Conn.BeginTransaction(Isolation)
        Catch ex As Exception
            Throw New Exception("Exception in OpenConnection" + ex.ToString)
        End Try

    End Sub

    Private Sub SendEmail(ByVal MailTo As Net.Mail.MailAddressCollection, ByVal FromAddr As Net.Mail.MailAddress, ByVal Subject As String, ByVal Body As String)

        Dim msg As New System.Net.Mail.MailMessage
        For i As Integer = 0 To MailTo.Count
            msg.To.Add(MailTo(i))
        Next
        msg.From = FromAddr
        msg.Subject = Subject
        msg.Body = Body
        Dim c As New System.Net.Mail.SmtpClient
        c.UseDefaultCredentials = False
        c.Credentials = New NetworkCredential("notify@dpspec.com", "Zw739xJ")
        c.EnableSsl = True
        c.Send(msg)
        'Disable until resolved 9/28/09 DGW
        'c.Send(From.ToString, MailTo.ToString, Subject, Body)
        'For testing on local machine
        'MsgBox(String.Format("From: {0}{4}To: {1}{4}Subj: {2}{4}{3}", From.ToString, MailTo.ToString, Subject, Body, vbCrLf))

    End Sub

    Private Sub SendEmail(ByVal UserNames() As String, ByVal Subject As String, ByVal Body As String)

        Dim Recipients As New System.Net.Mail.MailAddressCollection()
        Dim r As OleDbDataReader

        Using cmd As New OleDbCommand("SELECT UserName, LastName, FirstName, UserEmail FROM Users WHERE UserName IN ('" + _
              String.Join("','", UserNames) + "')", Conn, Transaction)
            r = cmd.ExecuteReader()
        End Using

        Do While r.Read
            Recipients.Add(New System.Net.Mail.MailAddress(CStr(r("UserEmail")), CStr(r("FirstName")) + " " + CStr(r("LastName"))))
        Loop

        SendEmail(Recipients, New System.Net.Mail.MailAddress("notify@dpspec.com", "DPS Job Notifications"), Subject, Body)


    End Sub

    Private Sub SendJobEmails()

        Using Jobs As DataTable = UpdateDS.Tables("Jobs").GetChanges(DataRowState.Added Or DataRowState.Modified)
            If Jobs Is Nothing Then Exit Sub
            For Each JobRow As DataRow In Jobs.Rows
                SendJobEmail(JobRow)
            Next
        End Using

    End Sub

    Private Sub SendJobEmail(ByVal jobrow As DataRow)

        If jobrow.IsNull("NotifyEmail") Then Exit Sub

        Dim catid As Integer = CInt(jobrow("CategoryID"))

        'Attempt to get category and company name, this may fail if the category is new
        Dim company As String = "?"
        Dim category As String = "?"
        Try
            Using cmd As New OleDbCommand("SELECT Company, CategoryName FROM Categories WHERE CategoryID=" + _
                catid.ToString, Conn, Transaction)
                Using r As OleDbDataReader = cmd.ExecuteReader()
                    If r.HasRows Then
                        r.Read()
                        company = CStr(r("Company"))
                        category = CStr(r("CategoryName"))
                    End If
                End Using
            End Using
            If company = "?" Then
                Dim catrow As DataRow = UpdateDS.Tables("categories").Rows.Find(catid)
                If Not catrow Is Nothing Then
                    company = CStr(catrow("Company"))
                    category = CStr(catrow("CategoryName"))
                End If
            End If
        Catch ex As Exception
            company = "?"
            category = "?"
        End Try

        Dim subj As String = "Job Updated:"
        If jobrow.RowState = DataRowState.Added Then subj = "New Job:"
        subj += " " + jobrow("Description").ToString

        Dim sb As New System.Text.StringBuilder
        sb.AppendLine(String.Format("Company: {0}", company))
        sb.AppendLine(String.Format("Category: {0}", category))
        sb.AppendLine(String.Format("Job Description: {0}", jobrow("Description")))
        sb.AppendLine(String.Format("Accounting ID: {0}", jobrow("AccountingID")))
        sb.AppendLine(String.Format("Priority: {0}", jobrow("Priority")))
        sb.AppendLine(String.Format("Created By: {0}", jobrow("RequestedByUser")))
        sb.AppendLine(String.Format("Notes: {0}", jobrow("RequestNotes")))
        sb.AppendLine(String.Format("Job created on: {0:M/d/yy}", jobrow("RequestDate")))
        sb.AppendLine(String.Format("Complete by: {0:M/d/yy}", jobrow("RequestedCompleteByDate")))
        sb.AppendLine(String.Format("Status: {0}", jobrow("Status")))
        sb.AppendLine(String.Format("Re-billable: {0}", jobrow("Billable")))
        sb.AppendLine(String.Format("Notify users: {0}", jobrow("NotifyEmail")))

        Select Case CStr(jobrow("Status")).ToUpper
            Case "OPEN"
                sb.AppendLine(String.Format("Approved by: {0}", jobrow("ApprovedByUser")))
                sb.AppendLine(String.Format("Job opened on: {0:M/d/yy}", jobrow("OpenedOnDate")))
            Case "AWAITING QUOTE"
                subj += ", ** Quote Requested **"

            Case "AWAITING APPROVAL"
                subj += ", ** Quote Submitted **"
                sb.AppendLine("Quote Details")
                sb.AppendLine("*************")
                sb.AppendLine(String.Format("Hours quoted: {0}", jobrow("QuotedHours")))
                sb.AppendLine(String.Format("Cost quoted: {0}", jobrow("QuotedCost")))
                sb.AppendLine(String.Format("Quote comments: {0}", jobrow("QuoteComments")))
            Case "ON HOLD"
                subj += ", ** Placed on Hold **"
            Case "COMPLETE"
                subj += ", ** Complete **"
                sb.AppendLine(String.Format("Completed on: {0:M/d/yy}", jobrow("CompletedOnDate")))
        End Select

        Dim userlist As String = CStr(jobrow("NotifyEmail"))

        If userlist.Equals("All Allowed Users") Then

            Using cmd As New OleDbCommand("SELECT AllowedUsers FROM Companies WHERE Company='" + company + "'", Conn, Transaction)
                userlist = CStr(cmd.ExecuteScalar)
            End Using

        End If

        SendEmail(userlist.Replace(" ", "").Split(","c), subj, sb.ToString)


    End Sub

    Private Sub SendWorkRecordEmails()
        Using addedrecords As DataTable = UpdateDS.Tables("Records").GetChanges(DataRowState.Added)
            If addedrecords Is Nothing Then Exit Sub
            For Each addedrec As DataRow In addedrecords.Rows
                SendWorkEmail(addedrec)
            Next
        End Using
    End Sub

    Private Sub SendWorkEmail(ByVal workrec As DataRow)
        'Get Job and Category fields
        Dim dr As OleDbDataReader
        Dim userlist As String
        Using cmd As New OleDbCommand("SELECT Jobs.Description, Jobs.NotifyEmail, Categories.CategoryName, Categories.Company " + _
        "FROM (Categories INNER JOIN Jobs ON Categories.CategoryID = Jobs.CategoryID) " + _
        "WHERE (Jobs.JobID = " + CStr(workrec("jobID")) + ")", Conn, Transaction)
            dr = cmd.ExecuteReader
        End Using

        If Not dr.HasRows Then Exit Sub
        dr.Read()
        If dr.IsDBNull(1) Then Exit Sub
        userlist = CStr(dr("NotifyEmail"))
        If userlist = "" Then Exit Sub

        Dim jobdescr As String = CStr(dr("Description"))
        Dim category As String = CStr(dr("CategoryName"))
        Dim company As String = CStr(dr("Company"))

        If userlist.Equals("All Allowed Users") Then
            Using cmd As New OleDbCommand("SELECT AllowedUsers FROM Companies WHERE Company='" _
                + company + "'", Conn, Transaction)
                userlist = CStr(cmd.ExecuteScalar)
            End Using
        End If

        'Get work record fields
        Dim hours As Single = CSng(workrec("HoursWorked"))
        Dim work As String = CStr(workrec("WorkDescription"))
        Dim datestr As String = CStr(workrec("DateWorked"))
        Dim dateworked As New Date(CInt(Left(datestr, 4)), CInt(Mid(datestr, 5, 2)), CInt(Right(datestr, 2)))

        'Get User full name
        Dim userfullname As String
        Using cmd As New OleDbCommand("SELECT Users.FirstName & ' ' & Users.LastName AS FullName " + _
            "FROM Users WHERE UserName='" + CStr(workrec("UserName")) + "'", Conn, Transaction)
            userfullname = CStr(cmd.ExecuteScalar)
        End Using

        Dim sb As New System.Text.StringBuilder
        sb.AppendLine(String.Format("Company: {0}", company))
        sb.AppendLine(String.Format("Category: {0}", category))
        sb.AppendLine(String.Format("Job: {0}", jobdescr))
        sb.AppendLine(String.Format("Date: {0:MMM d yyyy}", dateworked))
        sb.AppendLine(String.Format("Hours: {0:0.00}", hours))
        sb.AppendLine(String.Format("User: {0}", userfullname))
        sb.AppendLine(String.Format("Work done: {0}", work))

        SendEmail(userlist.Replace(" ", "").Split(","c), "Project Tracker - Work Reported", sb.ToString)

    End Sub

    Private Sub SetupDataAdapter(ByRef DA As OleDbDataAdapter, ByVal TableName As String, ByVal GetSelectCommandOnly As Boolean)
        Try


            DA = New OleDbDataAdapter("SELECT [" + TableName & "].* FROM [" + TableName + "]", Conn)

            DA.SelectCommand.CommandType = CommandType.Text
            DA.SelectCommand.UpdatedRowSource = UpdateRowSource.Both
            DA.SelectCommand.Transaction = Transaction

            If Not GetSelectCommandOnly Then
                Dim CB As New OleDbCommandBuilder(DA)
                DA.InsertCommand = CB.GetInsertCommand
                DA.InsertCommand.Transaction = Transaction
                DA.InsertCommand.UpdatedRowSource = UpdateRowSource.Both

                DA.UpdateCommand = CB.GetUpdateCommand
                DA.UpdateCommand.Transaction = Transaction
                DA.UpdateCommand.UpdatedRowSource = UpdateRowSource.Both

                DA.DeleteCommand = CB.GetDeleteCommand
                DA.DeleteCommand.Transaction = Transaction
                DA.DeleteCommand.UpdatedRowSource = UpdateRowSource.Both
            End If

            DA.MissingMappingAction = MissingMappingAction.Error
            DA.MissingSchemaAction = MissingSchemaAction.Error
            DA.FillSchema(FullDS, SchemaType.Source, TableName)

            Dim NewDTM As Common.DataTableMapping = DA.TableMappings.Add(TableName, TableName)
            For Each Col As DataColumn In FullDS.Tables(TableName).Columns
                NewDTM.ColumnMappings.Add(Col.ColumnName, Col.ColumnName)
            Next
        Catch ex As Exception
            Throw New Exception("Error in SetupDataAdapter: " + ex.ToString)
        End Try
    End Sub

    Private Sub SetupDataSet(ByVal GetSelectCommandsOnly As Boolean)
        Try


            FullDS = New DataSet

            'Initialize table adapters
            SetupDataAdapter(CompanyAdapter, "Companies", GetSelectCommandsOnly)
            SetupDataAdapter(CategoryAdapter, "Categories", GetSelectCommandsOnly)
            SetupDataAdapter(JobAdapter, "Jobs", GetSelectCommandsOnly)
            SetupDataAdapter(UserAdapter, "Users", GetSelectCommandsOnly)
            SetupDataAdapter(EmailAdapter, "Emails", GetSelectCommandsOnly)
            SetupDataAdapter(RecordAdapter, "Records", GetSelectCommandsOnly)

            'Add a database relation for all rows in the schema table
            For Each Row As DataRow In Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, New Object() {Nothing, Nothing, Nothing, Nothing}).Rows
                Dim PT As String = CStr(Row("PK_TABLE_NAME"))
                Dim CT As String = CStr(Row("FK_TABLE_NAME"))
                Dim PC As String = CStr(Row("PK_COLUMN_NAME"))
                Dim CC As String = CStr(Row("FK_COLUMN_NAME"))
                FullDS.Relations.Add(String.Format("{0}_{1}_{2}_{3}", PT, PC, CT, CC), _
                     FullDS.Tables(PT).Columns(PC), FullDS.Tables(CT).Columns(CC))
            Next

            'Set up identity command
            IdentityCommand = New OleDbCommand("SELECT @@IDENTITY", Conn, Transaction)
        Catch ex As Exception
            Throw New Exception("Error in SetupDataSet: " + ex.ToString)
        End Try
    End Sub

    Private Sub UpdateRows(ByRef DA As OleDbDataAdapter)
        Dim ModifiedData As DataTable = UpdateDS.Tables(DA.TableMappings(0).DataSetTable).GetChanges(DataRowState.Modified)
        If ModifiedData Is Nothing OrElse ModifiedData.Rows.Count = 0 Then Exit Sub
        Try
            DA.Update(ModifiedData)
        Catch ex As Exception
            Throw New Exception("Query failed: " + DA.UpdateCommand.CommandText + vbCrLf + ex.ToString)
        End Try

    End Sub

#End Region

End Class
