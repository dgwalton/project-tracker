Option Explicit On
Option Strict On

Public Class frmProgress
    ''' <summary>
    ''' An integer between 0 and 100 indicating the percent completion
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As Integer
        Get
            Return Me.ProgressBar1.Value
        End Get
        Set(ByVal value As Integer)
            Me.ProgressBar1.Value = value
            Application.DoEvents()
        End Set
    End Property

    Public Property Task() As String
        Get
            Return Me.Label1.Text
        End Get
        Set(ByVal value As String)
            Me.Label1.Text = value
        End Set
    End Property

    Public Sub New(ByVal Task As String, ByVal ShowProgress As Boolean)
        InitializeComponent()
        Me.Task = Task
        If Not ShowProgress Then
            SplitContainer1.Panel2Collapsed = True
        End If
    End Sub
End Class