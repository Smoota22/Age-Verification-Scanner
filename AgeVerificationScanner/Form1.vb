Public Class AgeVerificationScanner
    Dim timeDisplaySeconds As Integer 'Stores number of seconds the display timer will be set to every time an ID is scanned
    Dim staticCodes As String() = {"DAA", "DAB", "DAC", "DAD", "DAE", "DAF", "DAG", "DAH", "DAI",
        "DAJ", "DAK", "DAL", "DAM", "DAN", "DAO", "DAP", "DAQ", "DAR", "DAS", "DAT", "DAU", "DAV",'All known codes for ID's properties
        "DAW", "DAX", "DAY", "DAZ", "DBA", "DBB", "DBC", "DBD", "DBE", "DBF", "DBG", "DBH", "DBI",
        "DBJ", "DBK", "DBL", "DBM", "DBN", "DBO", "DBP", "DBQ", "DBR", "DBS", "DCA", "DCB", "DCD",
        "DCE", "DCF", "DCG", "DCH", "DCI", "DCJ", "DCK", "DCL", "DCM", "DCN", "DCO", "DCP", "DCQ",
        "DCR", "DCS", "DCT", "DCU", "DDA", "DDB", "DDD", "DDE", "DDF", "DDG", "DDH", "DDI",
        "DDJ", "DDK", "DDL", "PAA", "PAB", "PAC", "PAD", "PAE", "PAF", "ZVA", "ZGG"}

    Private Sub AgeVerificationScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScan.KeyUp
        'KeyUp only needs to handle anything if 'Enter' key is pressed
        If e.KeyCode = Keys.Enter Then

            'Create and initialize string array of different codes
            Dim codeData(staticCodes.Length) As String
            For i As Integer = 0 To codeData.Length - 1
                codeData(i) = ""
            Next

            Dim fullString As String 'Entire string read in by the scanner
            Dim prefix As String 'Three-character codes for properties
            Dim codeDataWriteIndex = 0 'Index for which property code the data should be getting written into
            fullString = txtScan.Text

            'Loops through fullstring one character at a time
            For i As Integer = 0 To fullString.Length - 4
                'Linearly searches through array of codes to see if prefix matches one
                prefix = fullString.Substring(i, 3)
                Dim foundCode As Boolean = False
                For j As Integer = 0 To staticCodes.Length - 1
                    If (prefix.Equals(staticCodes(j))) Then
                        codeDataWriteIndex = j + 1
                        i += 2
                        foundCode = True
                        Exit For
                    End If
                Next
                If (Not foundCode) Then
                    codeData(codeDataWriteIndex) += fullString.Substring(i, 1) 'Write in one character at a time into the correct property
                End If
            Next

            txtScan.Text = "" 'Clears textbox that the scanner reads into

            For i As Integer = 0 To codeData.Length - 1
                txtScan.Text += codeData(i) + vbCrLf
            Next

            handleParsedData(codeData)

            timeDisplaySeconds = 10 'Set length of display time (seconds)
            displayTimer.Start()
        End If
    End Sub

    'Finds pertinent data from parsed data to display and handle
    Private Sub handleParsedData(ByRef codeData As String())
        Dim fieldData As String
        Dim secondFieldData As String

        'Check for full name
        fieldData = getCodeDataAtIndex(codeData, "DAA")
        If (fieldData <> "") Then
            dispNameDAA(fieldData)
        End If

        'Check different codes for first name
        fieldData = getCodeDataAtIndex(codeData, "DAC")
        If (fieldData = "") Then
            fieldData = getCodeDataAtIndex(codeData, "DBP")
        End If
        If (fieldData = "") Then
            fieldData = getCodeDataAtIndex(codeData, "DCT")
        End If

        'Check different codes for last name
        secondFieldData = getCodeDataAtIndex(codeData, "DAB")
        If (secondFieldData = "") Then
            secondFieldData = getCodeDataAtIndex(codeData, "DBO")
        End If
        If (secondFieldData = "") Then
            secondFieldData = getCodeDataAtIndex(codeData, "DCS")
        End If

        'Check if either first or last name exist
        If (fieldData <> "" Or secondFieldData <> "") Then
            dispNameSeparate(fieldData, secondFieldData)
        End If

        'Check for date of birth
        fieldData = getCodeDataAtIndex(codeData, "DBB")
        If (fieldData <> "") Then
            dispAge(fieldData)
        End If

        'Check for city
        fieldData = getCodeDataAtIndex(codeData, "DAN")
        If (fieldData = "") Then
            fieldData = getCodeDataAtIndex(codeData, "DAI")
        End If
        If (fieldData <> "") Then
            dispCity(fieldData)
        End If

        'Check for expiration date
        fieldData = getCodeDataAtIndex(codeData, "DBA")
        If (fieldData = "") Then
            fieldData = getCodeDataAtIndex(codeData, "PAB")
        End If
        If (fieldData <> "") Then
            dispExpiration(fieldData)
        End If
    End Sub

    'Helper function return data of a given code
    Private Function getCodeDataAtIndex(ByRef codeData As String(), ByVal code As String) As String
        Dim index As Integer = indexOfHelper(code)
        If index = -1 Then
            Return ""
        End If

        Return codeData(index + 1)
    End Function

    'Helper function to find index of a given code
    Private Function indexOfHelper(ByVal code As String) As Integer
        For i As Integer = 0 To staticCodes.Length - 1
            If (staticCodes(i).Equals(code)) Then
                Return i
            End If
        Next

        Return -1
    End Function

    'Calculates and displays age from eight-character date of birth
    Private Sub dispAge(ByVal birthDate As String)
        Dim age As Integer = calculateYearDifference(birthDate)
        If (age = 999) Then
            Return
        End If
        'Displays age information
        If (age >= 21) Then
            pctBoxYesAlcohol.Visible = True
            pctBoxYesTobacco.Visible = True
        ElseIf (age >= 18) Then
            pctBoxNoAlcohol.Visible = True
            pctBoxYesTobacco.Visible = True
        Else
            pctBoxNoAlcohol.Visible = True
            pctBoxNoTobacco.Visible = True
        End If

        lblDispAge.Text = "AGE: " & age
    End Sub

    'Parses and displays name using code DAA
    Private Sub dispNameDAA(ByVal DAA As String)
        Dim firstName As String
        Dim lastName As String
        Dim index As Integer = 0

        For i As Integer = 0 To DAA.Length - 1
            If DAA.Substring(i, 1).Equals(",") Then
                index = i
            End If
        Next

        lastName = DAA.Substring(0, index)
        firstName = DAA.Substring(index + 1)

        lblDispName.Text = "NAME: " + firstName + " " + lastName
    End Sub

    'Displays cardholder's name if encoded with first and last name separately
    Private Sub dispNameSeparate(ByVal firstName As String, ByVal lastName As String)
        lblDispName.Text = "NAME: " + firstName + " " + lastName
    End Sub

    'Displays cardholder's home city
    Private Sub dispCity(ByVal city As String)
        lblDispCity.Text = "CITY: " + city
    End Sub

    'Displays cardholder's home city
    Private Sub dispExpiration(ByVal expirationDate As String)
        Dim timeSinceExpiration As Integer = calculateYearDifference(expirationDate)

        If (timeSinceExpiration >= 0) Then
            pctBoxExpired.Visible = True
        End If
    End Sub

    'Calculates year difference between current day and specified date
    Private Function calculateYearDifference(ByVal checkDate As String) As Integer
        Dim currentYear As Integer
        Dim currentMonth As Integer
        Dim currentDay As Integer
        Dim checkYear As Integer
        Dim checkMonth As Integer
        Dim checkDay As Integer
        Dim years As Integer

        If (checkDate.Length <> 8) Then 'Code only works on eight-character string
            Return 999
        End If

        checkMonth = checkDate.Substring(0, 2)
        checkDay = checkDate.Substring(2, 2)
        checkYear = checkDate.Substring(4, 4)

        If (checkMonth > 12) Then 'Check if first four characters of string are the birth year or birth month and day
            checkYear = checkDate.Substring(0, 4)
            checkMonth = checkDate.Substring(4, 2)
            checkDay = checkDate.Substring(6, 2)
        End If

        currentYear = DateTime.Now.Year
        currentMonth = DateTime.Now.Month
        currentDay = DateTime.Now.Day

        'Compares two dates to calculate age
        years = currentYear - checkYear
        If (checkMonth > currentMonth) Then
            years -= 1
        ElseIf (checkMonth = currentMonth) Then
            If (checkDay > currentDay) Then
                years -= 1
            End If
        End If

        Return years
    End Function

    'Counts down for display and handles clearing display when time ends
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles displayTimer.Tick
        timeDisplaySeconds -= 1

        If (timeDisplaySeconds = 0) Then 'Reset all displayed info
            pctBoxNoAlcohol.Visible = False
            pctBoxNoTobacco.Visible = False
            pctBoxYesAlcohol.Visible = False
            pctBoxYesTobacco.Visible = False
            pctBoxExpired.Visible = False
            lblDispAge.Text = "AGE: "
            lblDispName.Text = "NAME: "
            lblDispCity.Text = "CITY: "
            displayTimer.Stop()
        End If
    End Sub
End Class

'''Code Descriptions from https://www.dynamsoft.com/blog/barcode-reader/extract-data-pdf417-driver-licenses/
'         { 'abbreviation': 'DAA', 'description': 'Full Name' }
'		, { 'abbreviation': 'DAB', 'description': 'Last Name' }
'		, { 'abbreviation': 'DAB', 'description': 'Family Name' }
'		, { 'abbreviation': 'DAC', 'description': 'First Name' }
'		, { 'abbreviation': 'DAC', 'description': 'Given Name' }
'		, { 'abbreviation': 'DAD', 'description': 'Middle Name or Initial' }
'		, { 'abbreviation': 'DAD', 'description': 'Middle Name' }
'		, { 'abbreviation': 'DAE', 'description': 'Name Suffix' }
'		, { 'abbreviation': 'DAF', 'description': 'Name Prefix' }
'		, { 'abbreviation': 'DAG', 'description': 'Mailing Street Address1' }
'		, { 'abbreviation': 'DAH', 'description': 'Mailing Street Address2' }
'		, { 'abbreviation': 'DAI', 'description': 'Mailing City' }
'		, { 'abbreviation': 'DAJ', 'description': 'Mailing Jurisdiction Code' }
'		, { 'abbreviation': 'DAK', 'description': 'Mailing Postal Code' }
'		, { 'abbreviation': 'DAL', 'description': 'Residence Street Address1' }
'		, { 'abbreviation': 'DAM', 'description': 'Residence Street Address2' }
'		, { 'abbreviation': 'DAN', 'description': 'Residence City' }
'		, { 'abbreviation': 'DAO', 'description': 'Residence Jurisdiction Code' }
'		, { 'abbreviation': 'DAP', 'description': 'Residence Postal Code' }
'		, { 'abbreviation': 'DAQ', 'description': 'License or ID Number' }
'		, { 'abbreviation': 'DAR', 'description': 'License Classification Code' }
'		, { 'abbreviation': 'DAS', 'description': 'License Restriction Code' }
'		, { 'abbreviation': 'DAT', 'description': 'License Endorsements Code' }
'		, { 'abbreviation': 'DAU', 'description': 'Height in FT_IN' }
'		, { 'abbreviation': 'DAV', 'description': 'Height in CM' }
'		, { 'abbreviation': 'DAW', 'description': 'Weight in LBS' }
'		, { 'abbreviation': 'DAX', 'description': 'Weight in KG' }
'		, { 'abbreviation': 'DAY', 'description': 'Eye Color' }
'		, { 'abbreviation': 'DAZ', 'description': 'Hair Color' }
'		, { 'abbreviation': 'DBA', 'description': 'License Expiration Date' }
'		, { 'abbreviation': 'DBB', 'description': 'Date of Birth' }
'		, { 'abbreviation': 'DBC', 'description': 'Sex' }
'		, { 'abbreviation': 'DBD', 'description': 'License or ID Document Issue Date' }
'		, { 'abbreviation': 'DBE', 'description': 'Issue Timestamp' }
'		, { 'abbreviation': 'DBF', 'description': 'Number of Duplicates' }
'		, { 'abbreviation': 'DBG', 'description': 'Medical Indicator Codes' }
'		, { 'abbreviation': 'DBH', 'description': 'Organ Donor' }
'		, { 'abbreviation': 'DBI', 'description': 'Non-Resident Indicator' }
'		, { 'abbreviation': 'DBJ', 'description': 'Unique Customer Identifier' }
'		, { 'abbreviation': 'DBK', 'description': 'Social Security Number' }
'		, { 'abbreviation': 'DBL', 'description': 'Date Of Birth' }
'		, { 'abbreviation': 'DBM', 'description': 'Social Security Number' }
'		, { 'abbreviation': 'DBN', 'description': 'Full Name' }
'		, { 'abbreviation': 'DBO', 'description': 'Last Name' }
'		, { 'abbreviation': 'DBO', 'description': 'Family Name' }
'		, { 'abbreviation': 'DBP', 'description': 'First Name' }
'		, { 'abbreviation': 'DBP', 'description': 'Given Name' }
'		, { 'abbreviation': 'DBQ', 'description': 'Middle Name' }
'		, { 'abbreviation': 'DBQ', 'description': 'Middle Name or Initial' }
'		, { 'abbreviation': 'DBR', 'description': 'Suffix' }
'		, { 'abbreviation': 'DBS', 'description': 'Prefix' }
'		, { 'abbreviation': 'DCA', 'description': 'Virginia Specific Class' }
'		, { 'abbreviation': 'DCB', 'description': 'Virginia Specific Restrictions' }
'		, { 'abbreviation': 'DCD', 'description': 'Virginia Specific Endorsements' }
'		, { 'abbreviation': 'DCE', 'description': 'Physical Description Weight Range' }
'		, { 'abbreviation': 'DCF', 'description': 'Document Discriminator' }
'		, { 'abbreviation': 'DCG', 'description': 'Country territory of issuance' }
'		, { 'abbreviation': 'DCH', 'description': 'Federal Commercial Vehicle Codes' }
'		, { 'abbreviation': 'DCI', 'description': 'Place of birth' }
'		, { 'abbreviation': 'DCJ', 'description': 'Audit information' }
'		, { 'abbreviation': 'DCK', 'description': 'Inventory Control Number' }
'		, { 'abbreviation': 'DCL', 'description': 'Race Ethnicity' }
'		, { 'abbreviation': 'DCM', 'description': 'Standard vehicle classification' }
'		, { 'abbreviation': 'DCN', 'description': 'Standard endorsement code' }
'		, { 'abbreviation': 'DCO', 'description': 'Standard restriction code' }
'		, { 'abbreviation': 'DCP', 'description': 'Jurisdiction specific vehicle classification description' }
'		, { 'abbreviation': 'DCQ', 'description': 'Jurisdiction-specific' }
'		, { 'abbreviation': 'DCR', 'description': 'Jurisdiction specific restriction code description' }
'		, { 'abbreviation': 'DCS', 'description': 'Family Name' }
'		, { 'abbreviation': 'DCS', 'description': 'Last Name' }
'		, { 'abbreviation': 'DCT', 'description': 'Given Name' }
'		, { 'abbreviation': 'DCT', 'description': 'First Name' }
'		, { 'abbreviation': 'DCU', 'description': 'Suffix' }
'		, { 'abbreviation': 'DDA', 'description': 'Compliance Type' }
'		, { 'abbreviation': 'DDB', 'description': 'Card Revision Date' }
'		, { 'abbreviation': 'DDC', 'description': 'HazMat Endorsement Expiry Date' }
'		, { 'abbreviation': 'DDD', 'description': 'Limited Duration Document Indicator' }
'		, { 'abbreviation': 'DDE', 'description': 'Family Name Truncation' }
'		, { 'abbreviation': 'DDF', 'description': 'First Names Truncation' }
'		, { 'abbreviation': 'DDG', 'description': 'Middle Names Truncation' }
'		, { 'abbreviation': 'DDH', 'description': 'Under 18 Until' }
'		, { 'abbreviation': 'DDI', 'description': 'Under 19 Until' }
'		, { 'abbreviation': 'DDJ', 'description': 'Under 21 Until' }
'		, { 'abbreviation': 'DDK', 'description': 'Organ Donor Indicator' }
'		, { 'abbreviation': 'DDL', 'description': 'Veteran Indicator' }
'		, { 'abbreviation': 'PAA', 'description': 'Permit Classification Code' }
'		, { 'abbreviation': 'PAB', 'description': 'Permit Expiration Date' }
'		, { 'abbreviation': 'PAC', 'description': 'Permit Identifier' }
'		, { 'abbreviation': 'PAD', 'description': 'Permit IssueDate' }
'		, { 'abbreviation': 'PAE', 'description': 'Permit Restriction Code' }
'		, { 'abbreviation': 'PAF', 'description': 'Permit Endorsement Code' }
'		, { 'abbreviation': 'ZVA', 'description': 'Court Restriction Code' }
'         ZGG: Georgia Weight
