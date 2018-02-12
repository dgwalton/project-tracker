Imports System.Windows.Forms

Public Class frmViewEmail
    Public EmailID As Integer

    Public Sub New(ByVal EmailID As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.EmailID = EmailID
        ' Add any initialization after the InitializeComponent() call.
        Dim DR As DataRow = DBA.GetDataRow("Emails", EmailID)
        Me.lblSentOn.Text = CDate(DR("EmailDateTime")).ToLongDateString
        Me.txtFrom.Text = DR("EmailFrom").ToString
        Me.txtTo.Text = DR("EmailTo").ToString
        Me.txtCC.Text = DR("EmailCC").ToString
        Me.txtBCC.Text = DR("EmailBCC").ToString
        Me.txtSubject.Text = DR("EmailSubject").ToString
        'Me.rtBody.Text = DR("EmailBody").ToString
        Me.WebBrowser1.DocumentText = DR("EmailBody").ToString
        Me.Text = DR("EmailSubject").ToString
        Me.ActiveControl = Me.WebBrowser1

    End Sub

    Private Sub frmViewEmail_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.Visible Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

End Class
