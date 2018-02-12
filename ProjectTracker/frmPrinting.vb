Option Explicit On
Option Strict On

Public Class frmPrint

    Inherits System.Windows.Forms.Form

    Private PageFont As Font = New Font("Courier New", 10)
    Private NumPages As Integer
    Private MyReportText As String
    Friend WithEvents pnlPage As System.Windows.Forms.Panel
    Friend WithEvents pnlBack As System.Windows.Forms.Panel
    Private FirstCharofPage() As Int32
    Private PagePadding As Int32 = 5

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal ReportText As String, ByVal ReportTitle As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        MyReportText = ReportText
        Me.PrintDocument1.DocumentName = ReportTitle

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents tbbPrint As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbPgSetup As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbFont As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tbbCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.tbbPrint = New System.Windows.Forms.ToolBarButton()
        Me.tbbCancel = New System.Windows.Forms.ToolBarButton()
        Me.tbbPgSetup = New System.Windows.Forms.ToolBarButton()
        Me.tbbFont = New System.Windows.Forms.ToolBarButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.pnlPage = New System.Windows.Forms.Panel()
        Me.pnlBack = New System.Windows.Forms.Panel()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBack.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintDialog1
        '
        Me.PrintDialog1.AllowSelection = True
        Me.PrintDialog1.AllowSomePages = True
        Me.PrintDialog1.Document = Me.PrintDocument1
        '
        'PrintDocument1
        '
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'FontDialog1
        '
        Me.FontDialog1.AllowScriptChange = False
        Me.FontDialog1.AllowVectorFonts = False
        Me.FontDialog1.AllowVerticalFonts = False
        Me.FontDialog1.FixedPitchOnly = True
        Me.FontDialog1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FontDialog1.FontMustExist = True
        Me.FontDialog1.MaxSize = 48
        Me.FontDialog1.MinSize = 4
        Me.FontDialog1.ScriptsOnly = True
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbPrint, Me.tbbCancel, Me.tbbPgSetup, Me.tbbFont})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(48, 48)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(929, 77)
        Me.ToolBar1.TabIndex = 2
        '
        'tbbPrint
        '
        Me.tbbPrint.ImageIndex = 0
        Me.tbbPrint.Name = "tbbPrint"
        Me.tbbPrint.Text = "Print"
        Me.tbbPrint.ToolTipText = "Print"
        '
        'tbbCancel
        '
        Me.tbbCancel.ImageIndex = 4
        Me.tbbCancel.Name = "tbbCancel"
        Me.tbbCancel.Text = "Cancel Printing"
        Me.tbbCancel.ToolTipText = "Canel Printing"
        '
        'tbbPgSetup
        '
        Me.tbbPgSetup.ImageIndex = 1
        Me.tbbPgSetup.Name = "tbbPgSetup"
        Me.tbbPgSetup.Text = "Page Setup"
        Me.tbbPgSetup.ToolTipText = "Page Setup"
        '
        'tbbFont
        '
        Me.tbbFont.ImageIndex = 2
        Me.tbbFont.Name = "tbbFont"
        Me.tbbFont.Text = "Change Font"
        Me.tbbFont.ToolTipText = "Change Font"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar1.Location = New System.Drawing.Point(0, 522)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(929, 24)
        Me.StatusBar1.TabIndex = 3
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatusBarPanel1.MinWidth = 100
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 10000
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBar1.LargeChange = 1
        Me.VScrollBar1.Location = New System.Drawing.Point(913, 77)
        Me.VScrollBar1.Maximum = 1
        Me.VScrollBar1.Minimum = 1
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(16, 445)
        Me.VScrollBar1.TabIndex = 4
        Me.VScrollBar1.Value = 1
        '
        'pnlPage
        '
        Me.pnlPage.BackColor = System.Drawing.Color.White
        Me.pnlPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPage.Location = New System.Drawing.Point(292, 19)
        Me.pnlPage.Name = "pnlPage"
        Me.pnlPage.Size = New System.Drawing.Size(348, 393)
        Me.pnlPage.TabIndex = 5
        '
        'pnlBack
        '
        Me.pnlBack.Controls.Add(Me.pnlPage)
        Me.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBack.Location = New System.Drawing.Point(0, 77)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(913, 445)
        Me.pnlBack.TabIndex = 6
        '
        'frmPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 15)
        Me.ClientSize = New System.Drawing.Size(929, 546)
        Me.Controls.Add(Me.pnlBack)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Printing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBack.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub ShowPage(ByVal Page As Integer)
        DrawPage(Page)
    End Sub

    Private Function PrintPage(ByVal PageNumber As Integer, ByRef Grfx As System.Drawing.Graphics) As Boolean
        'exit conditions


        If PageNumber < 1 Then Exit Function
        If FirstCharofPage Is Nothing Then Exit Function
        If PageNumber > FirstCharofPage.GetUpperBound(0) Then Exit Function

        Dim Scaling As Single = Grfx.PageScale
        Dim NewFont As New Font(PageFont.FontFamily, PageFont.Size * Scaling, PageFont.Style, PageFont.Unit)
        Dim intCurrentChar As Int32 = FirstCharofPage(PageNumber)
        Dim PrintAreaHeight, PrintAreaWidth, marginLeft, marginTop As Int32
        Dim MorePages As Boolean = True
        Dim fmt As New StringFormat(StringFormatFlags.LineLimit)
        Dim intLinesFilled, intCharsFitted As Int32

        'setup the printable area
        With PrintDocument1.DefaultPageSettings
            PrintAreaHeight = Convert.ToInt32((.PaperSize.Height - .Margins.Top - .Margins.Bottom) * Scaling)
            PrintAreaWidth = Convert.ToInt32((.PaperSize.Width - .Margins.Left - .Margins.Right) * Scaling)
            marginLeft = Convert.ToInt32(.Margins.Left * Scaling)
            marginTop = Convert.ToInt32(.Margins.Top * Scaling)
        End With

        ' if landscape mode, swap the printing area height and width
        If PrintDocument1.DefaultPageSettings.Landscape Then
            Dim intTemp As Int32
            intTemp = PrintAreaHeight
            PrintAreaHeight = PrintAreaWidth
            PrintAreaWidth = intTemp
        End If

        Dim rectPrintingArea As New RectangleF(marginLeft, marginTop, PrintAreaWidth, PrintAreaHeight)

        Grfx.MeasureString(Mid(MyReportText, intCurrentChar + 1), _
                                 NewFont, New SizeF(PrintAreaWidth, PrintAreaHeight), _
                                fmt, intCharsFitted, intLinesFilled)

        Dim i As Integer = Strings.Mid(MyReportText, intCurrentChar + 1, intCharsFitted).IndexOf(ChrW(12))
        If i > 0 Then
            'Hard page break found, remeasure string length and print the text to the page
            Grfx.MeasureString(Mid(MyReportText, intCurrentChar + 1, i), _
                                    NewFont, New SizeF(PrintAreaWidth, PrintAreaHeight), _
                                    fmt, intCharsFitted, intLinesFilled)

            Grfx.DrawString(Mid(MyReportText, intCurrentChar + 1, i), NewFont, Brushes.Black, rectPrintingArea, fmt)
            intCurrentChar += intCharsFitted + 1
        Else
            'Soft page break, just print the text to the page
            Grfx.DrawString(Mid(MyReportText, intCurrentChar + 1, intCharsFitted), NewFont, Brushes.Black, rectPrintingArea, fmt)
            intCurrentChar += intCharsFitted
        End If

        If intCurrentChar < MyReportText.Length Then
            MorePages = True
        Else
            MorePages = False
            intCurrentChar = 0
        End If

        Return MorePages

    End Function

    Private Sub PreviewDocument()

        Dim intCurrentChar As Int32 = 0
        Dim PrintAreaHeight, PrintAreaWidth, marginLeft, marginTop As Int32
        Dim MorePages As Boolean = True
        Dim NewG As System.Drawing.Graphics = (New System.Windows.Forms.Panel).CreateGraphics
        Dim fmt As New StringFormat(StringFormatFlags.LineLimit) 'encapsulates text layout information
        Dim intLinesFilled, intCharsFitted As Int32

        ReDim FirstCharofPage(0)
        NumPages = 0

        'setup the printable area size
        With PrintDocument1.DefaultPageSettings
            PrintAreaHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            PrintAreaWidth = .PaperSize.Width - .Margins.Left - .Margins.Right
            marginLeft = .Margins.Left
            marginTop = .Margins.Top
        End With

        'if using landscape mode, swap the printing area height and width
        If PrintDocument1.DefaultPageSettings.Landscape Then
            Dim intTemp As Int32 = PrintAreaHeight
            PrintAreaHeight = PrintAreaWidth
            PrintAreaWidth = intTemp
        End If

        'rectangle structure defines the printing area
        Dim rectPrintingArea As New RectangleF(marginLeft, marginTop, PrintAreaWidth, PrintAreaHeight)

        Do While intCurrentChar < MyReportText.Length
            NumPages += 1
            ReDim Preserve FirstCharofPage(NumPages)
            FirstCharofPage(NumPages) = intCurrentChar
            NewG.MeasureString(Mid(MyReportText, intCurrentChar + 1), _
                                     PageFont, New SizeF(PrintAreaWidth, PrintAreaHeight), _
                                    fmt, intCharsFitted, intLinesFilled)
            Dim i As Integer = Strings.Mid(MyReportText, intCurrentChar + 1, intCharsFitted).IndexOf(ChrW(12))
            If i > 0 Then
                NewG.MeasureString(Mid(MyReportText, intCurrentChar + 1, i), _
                                        PageFont, New SizeF(PrintAreaWidth, PrintAreaHeight), _
                                        fmt, intCharsFitted, intLinesFilled)
                intCurrentChar += intCharsFitted + 1
            Else
                intCurrentChar += intCharsFitted
            End If
        Loop

        Me.VScrollBar1.Maximum = NumPages
        VScrollBar1.Value = 1

    End Sub

    Private Sub DrawPage(ByVal PageNumber As Integer)

        If pnlPage.Width > 0.0F And pnlPage.Height > 0.0F Then
            Dim Gfx As Graphics = pnlPage.CreateGraphics
            Gfx.PageScale = Convert.ToSingle(pnlPage.Width / _
                            PrintDocument1.DefaultPageSettings.Bounds.Width)
            Gfx.Clear(Color.White)
            PrintPage(PageNumber, Gfx)
            Me.StatusBarPanel1.Text = "Page " + PageNumber.ToString + " of " + NumPages.ToString
        End If

    End Sub

#Region "Control Event Handlers"

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
        Handles PrintDocument1.PrintPage

        Static i As Integer = e.PageSettings.PrinterSettings.FromPage
        e.HasMorePages = PrintPage(i, e.Graphics) And i < e.PageSettings.PrinterSettings.ToPage
        i += 1

    End Sub

    Private Sub frmPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData

            Case Keys.PageDown, Keys.Down
                If VScrollBar1.Value < VScrollBar1.Maximum Then VScrollBar1.Value += 1
            Case Keys.PageUp, Keys.Down
                If VScrollBar1.Value > VScrollBar1.Minimum Then VScrollBar1.Value -= 1
            Case Keys.End
                VScrollBar1.Value = VScrollBar1.Maximum
            Case Keys.Home
                VScrollBar1.Value = VScrollBar1.Minimum
        End Select
    End Sub

    Private Sub Printing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load
        'PrintDocument1.DefaultPageSettings = New Drawing.Printing.PageSettings(New Printing.PrinterSettings())
        PrintDocument1.DefaultPageSettings.Landscape = True
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
        PreviewDocument()
        DrawPage(1)

    End Sub

    Private Sub frmPrint_Resize(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles MyBase.Resize
        If Me.Visible And Me.WindowState <> FormWindowState.Minimized Then

            Dim Aspect As Single = Convert.ToSingle(PrintDocument1.DefaultPageSettings.Bounds.Width / _
                                   PrintDocument1.DefaultPageSettings.Bounds.Height)
            pnlBack.Dock = DockStyle.Fill
            Select Case pnlBack.Width / pnlBack.Height
                Case Is >= Aspect 'wider than page
                    pnlPage.Top = PagePadding
                    pnlPage.Height = pnlBack.Height - (PagePadding * 2)
                    pnlPage.Width = Convert.ToInt32(Aspect * pnlPage.Height)
                    pnlPage.Left = Convert.ToInt32((pnlBack.Width - pnlPage.Width) / 2)
                Case Is < Aspect 'taller than page
                    pnlPage.Left = PagePadding
                    pnlPage.Width = pnlBack.Width - (PagePadding * 2)
                    pnlPage.Height = Convert.ToInt32(pnlPage.Width / Aspect)
                    pnlPage.Top = Convert.ToInt32((pnlBack.Height - pnlPage.Height) / 2)
            End Select

            DrawPage(VScrollBar1.Value)
        End If

    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) _
        Handles ToolBar1.ButtonClick
        Dim RefreshDocument As Boolean = False
        Select Case e.Button.Text
            Case "Print"
                With PrintDialog1.PrinterSettings
                    .MinimumPage = 1
                    .FromPage = 1
                    .MaximumPage = Me.NumPages
                    .ToPage = Me.NumPages
                    .PrintRange = Printing.PrintRange.AllPages
                End With

                If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'showDialog method makes the dialog box visible at run time
                    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
                    PrintDocument1.Print()
                End If
            Case "Page Setup"

                PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings

                Try
                    If PageSetupDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
                        RefreshDocument = True
                    End If
                Catch es As Exception
                    MessageBox.Show(es.Message)
                End Try
            Case "Change Font"
                Try
                    FontDialog1.Font = PageFont
                    If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                        PageFont = FontDialog1.Font
                        RefreshDocument = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Cancel Printing"
                Me.Close()
        End Select

        If RefreshDocument Then
            PreviewDocument()
            'Resize event will force recalculation of page dimensions and redraw
            frmPrint_Resize(Me, New System.EventArgs)
        End If

    End Sub

    Private Sub frmPrint_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
    Handles MyBase.MouseWheel
        Select Case System.Math.Sign(e.Delta)
            Case 0
            Case -1
                If VScrollBar1.Value < VScrollBar1.Maximum Then
                    VScrollBar1.Value += 1
                    'Else
                    '    DrawPage(VScrollBar1.Value)
                End If

            Case 1
                If VScrollBar1.Value > VScrollBar1.Minimum Then
                    VScrollBar1.Value -= 1
                    'Else
                    '    DrawPage(VScrollBar1.Value)
                End If
        End Select

    End Sub

    Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles VScrollBar1.ValueChanged
        DrawPage(VScrollBar1.Value)
    End Sub

#End Region

End Class
