Option Explicit On
Option Strict On

''' <summary>
''' Windows ListView derived control with several enhanced features
''' </summary>
''' <remarks>
''' Added features:
''' <list type="bullet">
''' <item><description>* A <c>SortColumn</c> property which redirects the <c>Sort()</c> method to the proper column</description></item>
''' <item><description>* A tooltip feature that shows the entire item or subitem when it is truncated by column width</description></item>
''' <item><description>* <c>OnVScroll()</c> and <c>OnHScroll()</c> events</description></item>
''' <item><description>* Sorting on integer, string, or date values is automatically handled</description></item>
''' </list>
''' </remarks>
Public Class EnhancedListView
    Inherits System.Windows.Forms.ListView

#Region "Class-Private Declarations"

    'Display-related fields
    Private TextFmt As StringFormat
    Private InvRect As Rectangle
    Private HoverItem As ListViewItem.ListViewSubItem
    Private GetItem As ListViewItem.ListViewSubItem
    Private GetRowItem As ListViewItem

    'Class storage fields
    Private _FillColumn As Integer = 0
    Private _SortColumn As Integer = 0
    Private _SortOnClick As Boolean = False
    Private _Sorting As SortOrder = SortOrder.Ascending
    Private _BlanksFirst As Boolean = False
    Private _SortByTag As Boolean = False

    'Message related fields (for WndProc() message intercept)
    Private Const WM_HSCROLL As Integer = &H114
    Private Const WM_VSCROLL As Integer = &H115

#End Region

    Public Sub New()
        TextFmt = New StringFormat(StringFormat.GenericTypographic)
        TextFmt.FormatFlags = StringFormatFlags.NoClip
        Me.DoubleBuffered = True
    End Sub

#Region "Public Event Declarations"

    ''' <summary>
    ''' Raised when the user scrolls the control with the horizontal scroll handle
    ''' </summary>
    ''' <remarks></remarks>
    Public Event OnHScroll()

    ''' <summary>
    ''' Raised when the user scrolls the control with the vertical scroll handle
    ''' </summary>
    ''' <remarks></remarks>
    Public Event OnVScroll()

#End Region

#Region "Public Properties"
    ''' <summary>
    ''' The index of the column that will expand or contract when the control is resized.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FillColumn() As Integer
        Get
            Return _FillColumn
        End Get
        Set(ByVal value As Integer)
            _FillColumn = value
        End Set
    End Property

    ''' <summary>
    ''' When the Sort() method is invoked, the column on which the sort is performed
    ''' </summary>
    Public Property SortColumn() As Integer
        Get
            Return _SortColumn
        End Get
        Set(ByVal value As Integer)
            _SortColumn = value
        End Set
    End Property

    ''' <summary>
    ''' If true then the listview will automatically sort items on a columnclick() 
    ''' event before any user event code is run.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SortOnColumnClick() As Boolean
        Get
            Return _SortOnClick
        End Get
        Set(ByVal value As Boolean)
            _SortOnClick = value
        End Set
    End Property

    ''' <summary>
    ''' The order of sorting
    ''' </summary>
    ''' <remarks>This field shadows the base class field in order to 
    ''' prevent undesirable behavior when the sorting changes.</remarks>
    Public Shadows Property Sorting() As SortOrder
        Get
            Return _Sorting
        End Get
        Set(ByVal value As SortOrder)
            _Sorting = value
        End Set
    End Property

    ''' <summary>
    ''' Determines how blank values are sorted
    ''' </summary>
    ''' <remarks></remarks>
    Public Property BlanksFirst() As Boolean
        Get
            Return _BlanksFirst
        End Get
        Set(ByVal value As Boolean)
            _BlanksFirst = value
        End Set
    End Property

    Public Property SortByTag() As Boolean
        Get
            Return _SortByTag
        End Get
        Set(ByVal value As Boolean)
            _SortByTag = value
        End Set
    End Property


#End Region

#Region "Overridden Events"

    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)

        'Me.OwnerDraw = True

        Select Case CStr(Me.Columns(e.Column).Tag)
            Case "-"
                Me.Sorting = SortOrder.Ascending
                Me.Columns(e.Column).Tag = "+"
            Case Else
                Me.Sorting = SortOrder.Descending
                Me.Columns(e.Column).Tag = "-"
        End Select

        'If Me.SortColumn = e.Column Then
        '    Select Case Me.Sorting
        '        Case SortOrder.Ascending
        '            Me.Sorting = SortOrder.Descending
        '        Case SortOrder.Descending, SortOrder.None
        '            Me.Sorting = SortOrder.Ascending
        '    End Select
        'Else
        '    Me.Sorting = SortOrder.Ascending
        'End If

        Me.SortColumn = e.Column

        If Me.SortOnColumnClick Then
            Me.Sort()
        End If

        'MyBase.ListViewItemSorter = Nothing

        MyBase.OnColumnClick(e)

    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)

        Me.Invalidate()
        Application.DoEvents()

        MyBase.OnMouseLeave(e)

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)

        If Me.Items.Count = 0 Then Exit Sub
        GetRowItem = Me.GetItemAt(e.X, e.Y)
        If GetRowItem Is Nothing Then Exit Sub
        Dim RowWidth As Integer = GetRowItem.Bounds.Width
        GetItem = GetRowItem.GetSubItemAt(e.X, e.Y)
        If GetItem Is Nothing Then Exit Sub
        If GetItem Is HoverItem Then Exit Sub

        HoverItem = GetItem

        'Clear any old boxes
        Me.Invalidate()
        Application.DoEvents()
        Try


            Dim g As Graphics = Me.CreateGraphics
            Dim t As String = GetItem.Text
            InvRect = GetItem.Bounds
            If InvRect.Width >= RowWidth Then
                InvRect.Width = Me.Columns(0).Width
            End If

            'Determine if wrapping is needed
            Dim Edge As Integer = Me.Width
            If Me.Scrollable Then Edge -= 22

            'Determine if single-line box will overlap listview edge
            TextFmt.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap
            TextFmt.LineAlignment = StringAlignment.Center
            Dim w As Integer = CInt(g.MeasureString(t, HoverItem.Font, InvRect.Width, TextFmt).Width)

            If InvRect.Left + w < Edge And t.IndexOf(ChrW(10)) < 0 Then
                'Print as one line
                If w + 8 > InvRect.Width Then
                    InvRect.Width = w
                    g.FillRectangle(Brushes.LightYellow, InvRect.X - 3, InvRect.Y, InvRect.Width + 6, InvRect.Height)
                    g.DrawRectangle(Pens.Black, InvRect.X - 3, InvRect.Y, InvRect.Width + 6, InvRect.Height)
                    g.DrawString(t, HoverItem.Font, Brushes.Black, InvRect, TextFmt)
                End If
            Else
                'Wrap the text
                TextFmt.FormatFlags = StringFormatFlags.NoClip
                TextFmt.LineAlignment = StringAlignment.Near
                Dim h As Integer = CInt(g.MeasureString(t, HoverItem.Font, InvRect.Width, TextFmt).Height)
                If h > InvRect.Height Then
                    InvRect.Height = h
                    g.FillRectangle(Brushes.LightYellow, InvRect.X - 3, InvRect.Y, InvRect.Width + 6, InvRect.Height)
                    g.DrawRectangle(Pens.Black, InvRect.X - 3, InvRect.Y, InvRect.Width + 6, InvRect.Height)
                    g.DrawString(t, HoverItem.Font, Brushes.Black, InvRect, TextFmt)
                End If
            End If

        Catch ex As Exception

        End Try
        MyBase.OnMouseMove(e)

    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

        MyBase.OnResize(e)

        Dim w As Integer = Me.Width
        Select Case Me.BorderStyle
            Case Windows.Forms.BorderStyle.Fixed3D
                w -= SystemInformation.Border3DSize.Width * 2
            Case Windows.Forms.BorderStyle.FixedSingle
                w -= SystemInformation.BorderSize.Width * 2
        End Select

        If Me.VertScrollIsVisible Then w -= SystemInformation.VerticalScrollBarWidth

        For i As Integer = 0 To Me.Columns.Count - 1
            If i <> Me.FillColumn Then
                w -= Me.Columns(i).Width
            End If
        Next
        If w < 0 Then w = 0
        Me.Columns(Me.FillColumn).Width = w

    End Sub

    ''' <summary>
    ''' Sort method is shadowed in order to implement a once-only sort
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Sub Sort()
        MyBase.ListViewItemSorter = New ListViewItemComparer(Me.SortColumn, Me.Sorting, Me.BlanksFirst, Me.SortByTag)
        MyBase.Sort()
        MyBase.ListViewItemSorter = Nothing
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        If m.Msg = WM_HSCROLL Then
            RaiseEvent OnHScroll()
        End If

        If m.Msg = WM_VSCROLL Then
            RaiseEvent OnVScroll()
        End If


        MyBase.WndProc(m)

    End Sub

#End Region

    Private ReadOnly Property VertScrollIsVisible() As Boolean
        Get
            If Me.Items.Count > 0 Then
                Try
                    Return Me.Items(0).Bounds.Height * Me.Items.Count > Me.Height
                Catch ex As Exception
                    Return True
                End Try
            Else
                Return False
            End If
        End Get
    End Property

End Class

Public Class ListViewItemComparer
    Implements IComparer

    Private _Column As Integer
    Private _Order As System.Windows.Forms.SortOrder
    Private _BlanksFirst As Boolean
    Private _SortOnTag As Boolean

    Public Sub New(ByVal Column As Integer, ByVal Order As System.Windows.Forms.SortOrder, ByVal BlanksFirst As Boolean, ByVal SortOnTag As Boolean)
        _Column = Column
        _Order = Order
        _BlanksFirst = BlanksFirst
        _SortOnTag = SortOnTag
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim Ascnd As Integer = 1
        Select Case _Order
            Case SortOrder.None
                Return 0
            Case SortOrder.Ascending
                Ascnd = 1
            Case SortOrder.Descending
                Ascnd = -1
        End Select

        Dim sx, sy As String

        If _SortOnTag Then
            sx = CType(x, ListViewItem).SubItems(_Column).Tag.ToString
            sy = CType(y, ListViewItem).SubItems(_Column).Tag.ToString
        Else
            sx = CType(x, ListViewItem).SubItems(_Column).Text
            sy = CType(y, ListViewItem).SubItems(_Column).Text
        End If

        If IsNumeric(sx) And IsNumeric(sy) Then 'check for pure numbers
            Return Math.Sign(Val(sx) - Val(sy)) * Ascnd
        ElseIf sx Like "*#/*#/**##" And sy Like "*#/*#/**##" Then 'compare date strings
            Return Date.Compare(CDate(sx), CDate(sy)) * Ascnd
        ElseIf sx Like "*#:## [AP]M" And sy Like "*#:## [AP]M" Then 'compare time strings
            Return String.Compare(CDate(sx).ToString("HHmm"), CDate(sy).ToString("HHmm")) * Ascnd
        Else 'compare strings
            If CStr(sx) = "" Or CStr(sy) = "" Then
                If CStr(sx) = "" And CStr(sy) = "" Then
                    Return 0
                Else
                    Dim BlankInt As Integer = 1
                    If _BlanksFirst Then BlankInt = -1
                    If CStr(sx) = "" Then
                        Return BlankInt
                    Else
                        Return BlankInt * -1
                    End If

                End If
            Else
                Return String.Compare(sx, sy) * Ascnd
            End If
        End If
    End Function

End Class



