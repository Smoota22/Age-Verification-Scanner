<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AgeVerificationScanner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.displayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.txtScan = New System.Windows.Forms.TextBox()
        Me.lblDispAge = New System.Windows.Forms.Label()
        Me.lblDispName = New System.Windows.Forms.Label()
        Me.lblDispCity = New System.Windows.Forms.Label()
        Me.pctBoxNoAlcohol = New System.Windows.Forms.PictureBox()
        Me.pctBoxNoTobacco = New System.Windows.Forms.PictureBox()
        Me.dispInfo = New System.Windows.Forms.PictureBox()
        Me.pctBoxYesTobacco = New System.Windows.Forms.PictureBox()
        Me.pctBoxYesAlcohol = New System.Windows.Forms.PictureBox()
        Me.pctBoxExpired = New System.Windows.Forms.PictureBox()
        CType(Me.pctBoxNoAlcohol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctBoxNoTobacco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dispInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctBoxYesTobacco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctBoxYesAlcohol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctBoxExpired, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'displayTimer
        '
        Me.displayTimer.Interval = 1000
        '
        'txtScan
        '
        Me.txtScan.Location = New System.Drawing.Point(766, 45)
        Me.txtScan.Multiline = True
        Me.txtScan.Name = "txtScan"
        Me.txtScan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtScan.Size = New System.Drawing.Size(533, 336)
        Me.txtScan.TabIndex = 16
        '
        'lblDispAge
        '
        Me.lblDispAge.AutoSize = True
        Me.lblDispAge.BackColor = System.Drawing.Color.Transparent
        Me.lblDispAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDispAge.Location = New System.Drawing.Point(42, 85)
        Me.lblDispAge.Name = "lblDispAge"
        Me.lblDispAge.Size = New System.Drawing.Size(90, 32)
        Me.lblDispAge.TabIndex = 18
        Me.lblDispAge.Text = "AGE: "
        '
        'lblDispName
        '
        Me.lblDispName.AutoSize = True
        Me.lblDispName.BackColor = System.Drawing.Color.Transparent
        Me.lblDispName.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDispName.Location = New System.Drawing.Point(21, 40)
        Me.lblDispName.Name = "lblDispName"
        Me.lblDispName.Size = New System.Drawing.Size(111, 32)
        Me.lblDispName.TabIndex = 19
        Me.lblDispName.Text = "NAME: "
        '
        'lblDispCity
        '
        Me.lblDispCity.AutoSize = True
        Me.lblDispCity.BackColor = System.Drawing.Color.Transparent
        Me.lblDispCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDispCity.Location = New System.Drawing.Point(39, 132)
        Me.lblDispCity.Name = "lblDispCity"
        Me.lblDispCity.Size = New System.Drawing.Size(93, 32)
        Me.lblDispCity.TabIndex = 24
        Me.lblDispCity.Text = "CITY: "
        '
        'pctBoxNoAlcohol
        '
        Me.pctBoxNoAlcohol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pctBoxNoAlcohol.Image = Global.AgeVerificationScanner.My.Resources.Resources.No_Alcohol_Icon
        Me.pctBoxNoAlcohol.Location = New System.Drawing.Point(444, 395)
        Me.pctBoxNoAlcohol.Name = "pctBoxNoAlcohol"
        Me.pctBoxNoAlcohol.Size = New System.Drawing.Size(200, 200)
        Me.pctBoxNoAlcohol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBoxNoAlcohol.TabIndex = 21
        Me.pctBoxNoAlcohol.TabStop = False
        Me.pctBoxNoAlcohol.Visible = False
        '
        'pctBoxNoTobacco
        '
        Me.pctBoxNoTobacco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pctBoxNoTobacco.Image = Global.AgeVerificationScanner.My.Resources.Resources.No_Tobacco_Icon
        Me.pctBoxNoTobacco.Location = New System.Drawing.Point(70, 395)
        Me.pctBoxNoTobacco.Name = "pctBoxNoTobacco"
        Me.pctBoxNoTobacco.Size = New System.Drawing.Size(200, 200)
        Me.pctBoxNoTobacco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBoxNoTobacco.TabIndex = 20
        Me.pctBoxNoTobacco.TabStop = False
        Me.pctBoxNoTobacco.Visible = False
        '
        'dispInfo
        '
        Me.dispInfo.BackColor = System.Drawing.SystemColors.Control
        Me.dispInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dispInfo.Location = New System.Drawing.Point(13, 26)
        Me.dispInfo.Name = "dispInfo"
        Me.dispInfo.Size = New System.Drawing.Size(694, 355)
        Me.dispInfo.TabIndex = 17
        Me.dispInfo.TabStop = False
        '
        'pctBoxYesTobacco
        '
        Me.pctBoxYesTobacco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pctBoxYesTobacco.Image = Global.AgeVerificationScanner.My.Resources.Resources.Yes_Tobacco_Icon
        Me.pctBoxYesTobacco.Location = New System.Drawing.Point(70, 395)
        Me.pctBoxYesTobacco.Name = "pctBoxYesTobacco"
        Me.pctBoxYesTobacco.Size = New System.Drawing.Size(200, 200)
        Me.pctBoxYesTobacco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBoxYesTobacco.TabIndex = 22
        Me.pctBoxYesTobacco.TabStop = False
        Me.pctBoxYesTobacco.Visible = False
        '
        'pctBoxYesAlcohol
        '
        Me.pctBoxYesAlcohol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pctBoxYesAlcohol.Image = Global.AgeVerificationScanner.My.Resources.Resources.Yes_Alcohol_Icon
        Me.pctBoxYesAlcohol.Location = New System.Drawing.Point(444, 395)
        Me.pctBoxYesAlcohol.Name = "pctBoxYesAlcohol"
        Me.pctBoxYesAlcohol.Size = New System.Drawing.Size(200, 200)
        Me.pctBoxYesAlcohol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBoxYesAlcohol.TabIndex = 23
        Me.pctBoxYesAlcohol.TabStop = False
        Me.pctBoxYesAlcohol.Visible = False
        '
        'pctBoxExpired
        '
        Me.pctBoxExpired.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pctBoxExpired.Image = Global.AgeVerificationScanner.My.Resources.Resources.expired
        Me.pctBoxExpired.Location = New System.Drawing.Point(154, 173)
        Me.pctBoxExpired.Name = "pctBoxExpired"
        Me.pctBoxExpired.Size = New System.Drawing.Size(400, 328)
        Me.pctBoxExpired.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBoxExpired.TabIndex = 26
        Me.pctBoxExpired.TabStop = False
        Me.pctBoxExpired.Visible = False
        '
        'AgeVerificationScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 607)
        Me.Controls.Add(Me.pctBoxExpired)
        Me.Controls.Add(Me.lblDispCity)
        Me.Controls.Add(Me.pctBoxNoAlcohol)
        Me.Controls.Add(Me.pctBoxNoTobacco)
        Me.Controls.Add(Me.lblDispName)
        Me.Controls.Add(Me.lblDispAge)
        Me.Controls.Add(Me.dispInfo)
        Me.Controls.Add(Me.txtScan)
        Me.Controls.Add(Me.pctBoxYesTobacco)
        Me.Controls.Add(Me.pctBoxYesAlcohol)
        Me.Name = "AgeVerificationScanner"
        Me.Text = "Age Verification Scanner"
        CType(Me.pctBoxNoAlcohol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctBoxNoTobacco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dispInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctBoxYesTobacco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctBoxYesAlcohol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctBoxExpired, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents displayTimer As Timer
    Friend WithEvents txtScan As TextBox
    Friend WithEvents dispInfo As PictureBox
    Friend WithEvents lblDispAge As Label
    Friend WithEvents lblDispName As Label
    Friend WithEvents pctBoxNoTobacco As PictureBox
    Friend WithEvents pctBoxNoAlcohol As PictureBox
    Friend WithEvents pctBoxYesTobacco As PictureBox
    Friend WithEvents pctBoxYesAlcohol As PictureBox
    Friend WithEvents lblDispCity As Label
    Friend WithEvents pctBoxExpired As PictureBox
End Class
