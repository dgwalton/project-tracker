﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
'
Namespace ProjectTrackingService
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="ServiceSoap", [Namespace]:="http://www.dpspec.com/ProjectTracking/")>  _
    Partial Public Class Service
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GetDataOperationCompleted As System.Threading.SendOrPostCallback
        
        Private PutDataOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.ProjectTracker.My.MySettings.Default.ProjectTracker_com_dpspec_www_Service
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event GetDataCompleted As GetDataCompletedEventHandler
        
        '''<remarks/>
        Public Event PutDataCompleted As PutDataCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dpspec.com/ProjectTracking/GetData", RequestNamespace:="http://www.dpspec.com/ProjectTracking/", ResponseNamespace:="http://www.dpspec.com/ProjectTracking/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetData(ByVal Username As String, ByVal Password As String, ByVal StartWork As Date) As System.Data.DataSet
            Dim results() As Object = Me.Invoke("GetData", New Object() {Username, Password, StartWork})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetDataAsync(ByVal Username As String, ByVal Password As String, ByVal StartWork As Date)
            Me.GetDataAsync(Username, Password, StartWork, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetDataAsync(ByVal Username As String, ByVal Password As String, ByVal StartWork As Date, ByVal userState As Object)
            If (Me.GetDataOperationCompleted Is Nothing) Then
                Me.GetDataOperationCompleted = AddressOf Me.OnGetDataOperationCompleted
            End If
            Me.InvokeAsync("GetData", New Object() {Username, Password, StartWork}, Me.GetDataOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetDataOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetDataCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDataCompleted(Me, New GetDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dpspec.com/ProjectTracking/PutData", RequestNamespace:="http://www.dpspec.com/ProjectTracking/", ResponseNamespace:="http://www.dpspec.com/ProjectTracking/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function PutData(ByVal Username As String, ByVal Password As String, ByVal UpdatedDataSet As System.Data.DataSet) As String
            Dim results() As Object = Me.Invoke("PutData", New Object() {Username, Password, UpdatedDataSet})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub PutDataAsync(ByVal Username As String, ByVal Password As String, ByVal UpdatedDataSet As System.Data.DataSet)
            Me.PutDataAsync(Username, Password, UpdatedDataSet, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub PutDataAsync(ByVal Username As String, ByVal Password As String, ByVal UpdatedDataSet As System.Data.DataSet, ByVal userState As Object)
            If (Me.PutDataOperationCompleted Is Nothing) Then
                Me.PutDataOperationCompleted = AddressOf Me.OnPutDataOperationCompleted
            End If
            Me.InvokeAsync("PutData", New Object() {Username, Password, UpdatedDataSet}, Me.PutDataOperationCompleted, userState)
        End Sub
        
        Private Sub OnPutDataOperationCompleted(ByVal arg As Object)
            If (Not (Me.PutDataCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent PutDataCompleted(Me, New PutDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub GetDataCompletedEventHandler(ByVal sender As Object, ByVal e As GetDataCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetDataCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataSet
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataSet)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub PutDataCompletedEventHandler(ByVal sender As Object, ByVal e As PutDataCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class PutDataCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
