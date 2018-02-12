Option Strict On
Option Explicit On

Public Class frmLogin
    Private tries As Integer = 0
    Private waitingForData As Boolean = False

#Region "Properties"

    Public Property Username() As String
        Get
            Return Me.UserNameTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.UserNameTextBox.Text = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return Me.PasswordTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.PasswordTextBox.Text = value
        End Set
    End Property

    Public Property StartDate() As System.DateTime
        Get
            Return Me.DateTimePicker1.Value
        End Get
        Set(ByVal value As System.DateTime)
            Me.DateTimePicker1.Value = value
        End Set
    End Property

#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.PictureBox1.Show()
        Dim th As New Threading.ThreadStart(AddressOf GetDataSet_Asynch)
        th.BeginInvoke(AddressOf GetDataSet_Completed, Nothing)
        Me.Timer1.Start()
    End Sub

    Private Sub GetDataSet_Asynch()
        waitingForData = True
        DBA = New OLEDBDataAccess(Me.Username, Me.Password, Me.StartDate)
    End Sub

    Private Sub GetDataSet_Completed(ByVal ar As System.IAsyncResult)
        waitingForData = False
    End Sub

    Private Sub ResetInfo()
        If Me.UserNameTextBox.Text = "" Then
            Me.PasswordTextBox.Clear()
            Me.ActiveControl = Me.UserNameTextBox
        Else
            Me.PasswordTextBox.SelectAll()
            Me.ActiveControl = Me.PasswordTextBox
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = Me.UserNameTextBox
        'With My.Application.Info.Version
        '    Me.Version.Text = String.Format("Version {0}.{1}.{2}.{3}", .Major, .MajorRevision, .Minor, .MinorRevision)
        'End With
        ResetInfo()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not waitingForData Then
            Me.Timer1.Stop()
            Me.PictureBox1.Hide()
            Me.Label1.Visible = DBA.UserType = UserType.None
            If DBA.UserType <> UserType.None Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                DBA.Dispose()
                tries += 1
                If tries > 5 Then
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
                End If
                ResetInfo()
            End If
        End If
    End Sub

    Private Sub PasswordTextBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles PasswordTextBox.MouseClick, UserNameTextBox.MouseClick
        If TypeOf sender Is TextBox Then
            CType(sender, TextBox).SelectAll()
        End If
    End Sub

    Private Sub PasswordTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles PasswordTextBox.MouseDoubleClick, UserNameTextBox.MouseDoubleClick
        If TypeOf sender Is TextBox Then
            CType(sender, TextBox).SelectionLength = 0
        End If
    End Sub

    'Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
    '    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '    Me.Hide()
    'End Sub

    'Private Sub PasswordTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        OK.PerformClick()
    '    End If
    'End Sub

End Class
