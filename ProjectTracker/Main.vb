Option Explicit On 
Option Strict On

Public Module Main
    
    Public DBA As OLEDBDataAccess

    Public Enum JobEditMode As Integer
        View = 0
        Edit = 1
        SubmitQuote = 2
        ReviewQuote = 3
        Administrator = 4
        CreateNew = 5
    End Enum

    Public Enum UserType
        None = 0
        Administrator = 1
        Customer = 2
        Employee = 3
    End Enum

    Public Sub Main()
        Application.EnableVisualStyles()
        Application.DoEvents()
        Dim Success As Boolean = False
        Using login As New frmLogin()
            login.StartDate = Now.AddDays(-90)
            If login.ShowDialog = Windows.Forms.DialogResult.OK Then
                Success = True
            End If
        End Using
        If Success Then
            Using main As New frmMain
                main.Show()
                Application.Run(main)
            End Using
        End If

    End Sub

    Public Function CompareAndChange(ByRef DataItem As Object, ByVal Value As Object) As Boolean
        Dim Changed As Boolean = False

        If DataItem Is DBNull.Value Then
            If Not Value Is Nothing Then
                If Value.GetType.Name = "String" Then
                    If CStr(Value) <> "" Then
                        DataItem = Value
                        Changed = True
                    End If
                Else
                    DataItem = Value
                    Changed = True
                End If
            End If
        Else
            Select Case Value.GetType.Name
                Case "String"
                    If CStr(DataItem) <> CStr(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case "Boolean", "Bool"
                    If CBool(DataItem) <> CBool(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case "DateTime", "Date"
                    If CDate(DataItem) <> CDate(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case "Int16", "Short"
                    If CShort(DataItem) <> CShort(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case "Int32", "Integer"
                    If CInt(DataItem) <> CInt(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case "Int64", "Long"
                    If CLng(DataItem) <> CLng(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case "Single"
                    If CSng(DataItem) <> CSng(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case "Double"
                    If CDbl(DataItem) <> CDbl(Value) Then
                        DataItem = Value
                        Changed = True
                    End If
                Case Else
                    Throw New Exception("Unknown data type")

            End Select
        End If

        Return Changed
    End Function

#Region "Text Handling Functions"

    Public Function TimeToSng(ByVal TimeIn As String) As Single

        Dim Hr As Integer
        Dim MnString As String
        Dim Mn As Integer
        Dim PMFlag As Boolean
        Dim AMFlag As Boolean
        Try
            'Remove Spaces and Illegal Characters
            TimeIn = StripChar(TimeIn, " "c, "!"c, "#"c, "%"c, "$"c, "@"c, "^"c, "&"c, "*"c, "("c, ")"c)

            'remove a trailing "m"
            If UCase(Right(TimeIn, 1)) = "M" Then
                TimeIn = Left(TimeIn, Len(TimeIn) - 1)
            End If

            'Check for Am or Pm, set flags, then remove
            If UCase(Right(TimeIn, 1)) = "P" Then
                PMFlag = True
                TimeIn = Left(TimeIn, Len(TimeIn) - 1)
            ElseIf UCase(Right(TimeIn, 1)) = "A" Then
                AMFlag = True
                TimeIn = Left(TimeIn, Len(TimeIn) - 1)
            End If


            If IsNumeric(TimeIn) Then
                TimeToSng = CSng(TimeIn)
            ElseIf InStr(TimeIn, ":") >= 0 Then
                Hr = CShort(Left(TimeIn, InStr(TimeIn, ":") - 1))
                MnString = Left(Right(TimeIn, Len(TimeIn) - InStr(TimeIn, ":")), 2)
                Select Case MnString
                    Case "1", "2", "3", "4", "5", "6"
                        Mn = CInt(MnString) * 10
                    Case " ", ""
                        Mn = 0
                    Case Else
                        Mn = CInt(MnString)
                End Select
                TimeToSng = CSng(Hr + Mn / 60.0F)
            Else
                TimeToSng = -1.0F
                Exit Function
            End If

            If PMFlag And TimeToSng < 12.0F Then
                TimeToSng = TimeToSng + 12.0F
            End If

            If AMFlag And TimeToSng >= 12.0 Then
                TimeToSng = TimeToSng - 12.0F
            End If

            If TimeToSng < 0 Or TimeToSng > 24 Then
                TimeToSng = -1.0F
            End If
        Catch ex As Exception
            TimeToSng = -1.0F
        End Try

    End Function

    Public Function SngToTime(ByVal sngTime As Single, Optional ByVal TwentyFourHour As Boolean = False) As String

        Dim Hr As Integer
        Dim Mn As Integer
        Dim PMFlag As Boolean

        Try
            'check for legal values
            If IsNumeric(sngTime) Then
                If sngTime < 0 Or sngTime > 24 Then
                    Throw New System.Exception("Invalid Time Entry Format")
                End If
            Else
                Throw New System.Exception("Invalid Time Entry Format")
            End If

            'Acquire hour and minute values from strings with period or colon or neither
            If InStr(CStr(sngTime), ".") >= 0 Then
                Hr = CInt(sngTime - 0.5)
                Mn = CInt((CSng(sngTime) - Hr) * 60.0#)
            Else
                Hr = CInt(sngTime)
                Mn = 0
            End If

            'in reality this should never be run
            Do While Mn >= 60
                Hr = Hr + 1
                Mn = Mn - 60
            Loop

            'Account for various hour cases and adjust accordingly

            If TwentyFourHour Then
                SngToTime = CStr(Hr) & ":" & Mn.ToString("00")
            Else
                Select Case Hr
                    Case 0
                        Hr = 12
                        PMFlag = False
                    Case 1 To 11
                        PMFlag = False
                    Case 12
                        PMFlag = True
                    Case 13 To 23
                        Hr = Hr - 12
                        PMFlag = True
                    Case 24
                        Hr = 12
                        PMFlag = False
                    Case Else
                        Throw New System.Exception("Invalid Time Entry Format")
                End Select

                SngToTime = CStr(Hr) & ":" & Mn.ToString("00") & " "
                If PMFlag Then
                    SngToTime = SngToTime & "pm"
                Else
                    SngToTime = SngToTime & "am"
                End If

            End If
        Catch ex As Exception
            SngToTime = ""
        End Try

    End Function

    Public Function StripChar(ByVal Text As String, ByVal ParamArray IllegalCharacters() As Char) As String
        Dim CharCounter As Integer
        Dim IllegalChar As Char
        Dim Character As String
        Dim FoundIllegalChar As Boolean
        Dim TempString As String = ""

        For CharCounter = 0 To Text.Length - 1
            FoundIllegalChar = False
            Character = Text.Chars(CharCounter)
            For Each IllegalChar In IllegalCharacters
                If Character = IllegalChar Then
                    FoundIllegalChar = True
                End If
            Next IllegalChar 'IllegalChar
            If Not FoundIllegalChar Then TempString += Character
        Next  'CharCounter

        Return TempString

    End Function

    Public Function RemoveSpace(ByVal Text As String) As String
        RemoveSpace = StripChar(Text, " "c)
    End Function

#End Region

End Module


