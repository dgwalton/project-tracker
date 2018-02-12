Public Class StatePicker
    Private Abbreviations As String() = New String() {"", "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", _
    "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH", "MD", "MA", "MI", "MN", _
    "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "MP", "OH", "OK", "OR", "PW", "PA", _
    "PR", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VI", "VA", "WA", "WV", "WI", "WY"}

    Private Descriptions As String() = New String() {"N/A", "ALABAMA", "ALASKA", "AMERICAN SAMOA", "ARIZONA", "ARKANSAS", _
    "CALIFORNIA", "COLORADO", "CONNECTICUT", "DELAWARE", "DISTRICT OF COLUMBIA", "FEDERATED STATES OF MICRONESIA", _
    "FLORIDA", "GEORGIA", "GUAM", "HAWAII", "IDAHO", "ILLINOIS", "INDIANA", "IOWA", "KANSAS", "KENTUCKY", "LOUISIANA", _
    "MAINE", "MARSHALL ISLANDS", "MARYLAND", "MASSACHUSETTS", "MICHIGAN", "MINNESOTA", "MISSISSIPPI", "MISSOURI", _
    "MONTANA", "NEBRASKA", "NEVADA", "NEW HAMPSHIRE", "NEW JERSEY", "NEW MEXICO", "NEW YORK", "NORTH CAROLINA", _
    "NORTH DAKOTA", "NORTHERN MARIANA ISLANDS", "OHIO", "OKLAHOMA", "OREGON", "PALAU", "PENNSYLVANIA", _
    "PUERTO RICO", "RHODE ISLAND", "SOUTH CAROLINA", "SOUTH DAKOTA", "TENNESSEE", "TEXAS", "UTAH", "VERMONT", _
    "VIRGIN ISLANDS", "VIRGINIA", "WASHINGTON", "WEST VIRGINIA", "WISCONSIN", "WYOMING"}

    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private Table As DataTable


    Public Sub New()

        InitializeComponent()

        Table = New DataTable("States")
        Table.Columns.Add("Abbreviation")
        Table.Columns.Add("Description")
        Dim TI As System.Globalization.TextInfo = New System.Globalization.CultureInfo("en-US", False).TextInfo
        For i As Integer = 0 To Abbreviations.GetUpperBound(0)
            Table.Rows.Add(Abbreviations(i), TI.ToTitleCase(Descriptions(i).ToLower))
        Next
        Me.Combo.Items.AddRange(Abbreviations)
        Me.Combo.DataSource = Table
        Me.Combo.DisplayMember = "Abbreviation"
        Me.Combo.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems

    End Sub

    Private Sub Combo_Changed(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Combo.SelectedValueChanged
        Me.Label.Text = Table.Rows(Me.Combo.SelectedIndex)("Description").ToString
    End Sub

    Public Overrides Property Text() As String
        Get
            Return Me.Combo.Text
        End Get
        Set(ByVal value As String)
            Me.Combo.Text = value
        End Set
    End Property
End Class
