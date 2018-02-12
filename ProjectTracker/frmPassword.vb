Imports System.Windows.Forms

Public Class frmPassword

    Public ReadOnly Property OldPassword() As String
        Get
            Return Me.OldPW.Text
        End Get
    End Property

    Public ReadOnly Property NewPassword() As String
        Get
            Return Me.NewPW.Text
        End Get
    End Property

    Public ReadOnly Property ConfirmPassword() As String
        Get
            Return Me.ConfirmPW.Text
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
