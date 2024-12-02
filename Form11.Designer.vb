<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form11
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label13 = New Label()
        btnUploadpicture = New Button()
        studpicture = New PictureBox()
        buttonClear = New Button()
        buttonSave = New Button()
        Label12 = New Label()
        Label11 = New Label()
        Label10 = New Label()
        txtEmailAddress = New TextBox()
        Label5 = New Label()
        txtConNumber = New TextBox()
        Label2 = New Label()
        txtSNumber = New TextBox()
        Label3 = New Label()
        txtSName = New TextBox()
        Label4 = New Label()
        Label1 = New Label()
        buttonDelete = New Button()
        buttonUpdate = New Button()
        Label14 = New Label()
        txtManageStudentSearch = New TextBox()
        btnEmail = New Button()
        btnExit = New Button()
        Panel1 = New Panel()
        dataGrid = New DataGridView()
        comboSections = New TextBox()
        comboYearLevel = New TextBox()
        comboSubjects = New TextBox()
        comboCourses = New TextBox()
        combo_class = New ComboBox()
        cboSheet1 = New ComboBox()
        Label7 = New Label()
        Label6 = New Label()
        Button1 = New Button()
        txtFileName1 = New TextBox()
        CType(studpicture, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(dataGrid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.ForeColor = Color.White
        Label13.Location = New Point(108, 289)
        Label13.Margin = New Padding(4, 0, 4, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(124, 20)
        Label13.TabIndex = 80
        Label13.Text = "Student Picture"
        ' 
        ' btnUploadpicture
        ' 
        btnUploadpicture.BackColor = Color.White
        btnUploadpicture.FlatStyle = FlatStyle.Flat
        btnUploadpicture.ForeColor = Color.Black
        btnUploadpicture.Location = New Point(105, 320)
        btnUploadpicture.Name = "btnUploadpicture"
        btnUploadpicture.Size = New Size(137, 30)
        btnUploadpicture.TabIndex = 79
        btnUploadpicture.Text = "Upload Picture"
        btnUploadpicture.UseVisualStyleBackColor = False
        ' 
        ' studpicture
        ' 
        studpicture.BackColor = Color.Transparent
        studpicture.Image = My.Resources.Resources.icon
        studpicture.Location = New Point(86, 117)
        studpicture.Name = "studpicture"
        studpicture.Size = New Size(183, 161)
        studpicture.SizeMode = PictureBoxSizeMode.Zoom
        studpicture.TabIndex = 78
        studpicture.TabStop = False
        ' 
        ' buttonClear
        ' 
        buttonClear.BackColor = Color.Firebrick
        buttonClear.FlatStyle = FlatStyle.Flat
        buttonClear.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        buttonClear.ForeColor = Color.White
        buttonClear.Location = New Point(45, 633)
        buttonClear.Margin = New Padding(4, 3, 4, 3)
        buttonClear.Name = "buttonClear"
        buttonClear.Size = New Size(250, 44)
        buttonClear.TabIndex = 75
        buttonClear.Text = "CLEAR"
        buttonClear.UseVisualStyleBackColor = False
        ' 
        ' buttonSave
        ' 
        buttonSave.BackColor = Color.White
        buttonSave.FlatStyle = FlatStyle.Flat
        buttonSave.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        buttonSave.ForeColor = Color.DarkRed
        buttonSave.Location = New Point(44, 572)
        buttonSave.Margin = New Padding(4, 3, 4, 3)
        buttonSave.Name = "buttonSave"
        buttonSave.Size = New Size(251, 44)
        buttonSave.TabIndex = 74
        buttonSave.Text = "ADD"
        buttonSave.UseVisualStyleBackColor = False
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.ForeColor = Color.White
        Label12.Location = New Point(318, 412)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(65, 20)
        Label12.TabIndex = 72
        Label12.Text = "Section"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = Color.White
        Label11.Location = New Point(453, 412)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(63, 20)
        Label11.TabIndex = 70
        Label11.Text = "Course"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.White
        Label10.Location = New Point(318, 332)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(88, 20)
        Label10.TabIndex = 68
        Label10.Text = "Year Level"
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.BorderStyle = BorderStyle.FixedSingle
        txtEmailAddress.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmailAddress.Location = New Point(318, 291)
        txtEmailAddress.Margin = New Padding(4, 3, 4, 3)
        txtEmailAddress.Multiline = True
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.Size = New Size(250, 29)
        txtEmailAddress.TabIndex = 61
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(318, 264)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(118, 20)
        Label5.TabIndex = 60
        Label5.Text = "Email Address"
        ' 
        ' txtConNumber
        ' 
        txtConNumber.BorderStyle = BorderStyle.FixedSingle
        txtConNumber.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        txtConNumber.Location = New Point(318, 217)
        txtConNumber.Margin = New Padding(4, 3, 4, 3)
        txtConNumber.Multiline = True
        txtConNumber.Name = "txtConNumber"
        txtConNumber.Size = New Size(250, 29)
        txtConNumber.TabIndex = 59
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(318, 190)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(131, 20)
        Label2.TabIndex = 58
        Label2.Text = "Contact Number"
        ' 
        ' txtSNumber
        ' 
        txtSNumber.BorderStyle = BorderStyle.FixedSingle
        txtSNumber.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        txtSNumber.Location = New Point(45, 457)
        txtSNumber.Margin = New Padding(4, 3, 4, 3)
        txtSNumber.Multiline = True
        txtSNumber.Name = "txtSNumber"
        txtSNumber.Size = New Size(250, 29)
        txtSNumber.TabIndex = 57
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(45, 366)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(115, 20)
        Label3.TabIndex = 54
        Label3.Text = "Student Name"
        ' 
        ' txtSName
        ' 
        txtSName.BorderStyle = BorderStyle.FixedSingle
        txtSName.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        txtSName.Location = New Point(45, 391)
        txtSName.Margin = New Padding(4, 3, 4, 3)
        txtSName.Multiline = True
        txtSName.Name = "txtSName"
        txtSName.Size = New Size(250, 29)
        txtSName.TabIndex = 55
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(45, 434)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(130, 20)
        Label4.TabIndex = 56
        Label4.Text = "Student Number"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.Transparent
        Label1.Location = New Point(45, 41)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(202, 42)
        Label1.TabIndex = 53
        Label1.Text = "STUDENT"
        ' 
        ' buttonDelete
        ' 
        buttonDelete.BackColor = Color.Brown
        buttonDelete.FlatStyle = FlatStyle.Flat
        buttonDelete.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        buttonDelete.ForeColor = Color.White
        buttonDelete.Location = New Point(317, 633)
        buttonDelete.Name = "buttonDelete"
        buttonDelete.Size = New Size(250, 44)
        buttonDelete.TabIndex = 82
        buttonDelete.Text = "DELETE"
        buttonDelete.UseVisualStyleBackColor = False
        ' 
        ' buttonUpdate
        ' 
        buttonUpdate.BackColor = Color.White
        buttonUpdate.FlatAppearance.BorderSize = 0
        buttonUpdate.FlatStyle = FlatStyle.Flat
        buttonUpdate.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        buttonUpdate.ForeColor = Color.Firebrick
        buttonUpdate.Location = New Point(318, 572)
        buttonUpdate.Name = "buttonUpdate"
        buttonUpdate.Size = New Size(251, 44)
        buttonUpdate.TabIndex = 83
        buttonUpdate.Text = "UPDATE"
        buttonUpdate.UseVisualStyleBackColor = False
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.ForeColor = Color.White
        Label14.Location = New Point(608, 79)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(62, 20)
        Label14.TabIndex = 87
        Label14.Text = "Search"
        ' 
        ' txtManageStudentSearch
        ' 
        txtManageStudentSearch.BorderStyle = BorderStyle.FixedSingle
        txtManageStudentSearch.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        txtManageStudentSearch.Location = New Point(678, 73)
        txtManageStudentSearch.Margin = New Padding(4, 3, 4, 3)
        txtManageStudentSearch.Multiline = True
        txtManageStudentSearch.Name = "txtManageStudentSearch"
        txtManageStudentSearch.Size = New Size(217, 28)
        txtManageStudentSearch.TabIndex = 84
        ' 
        ' btnEmail
        ' 
        btnEmail.FlatAppearance.BorderSize = 0
        btnEmail.FlatStyle = FlatStyle.Flat
        btnEmail.Font = New Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        btnEmail.ForeColor = Color.White
        btnEmail.Image = My.Resources.Resources.send__1_
        btnEmail.ImageAlign = ContentAlignment.MiddleLeft
        btnEmail.Location = New Point(45, 506)
        btnEmail.Name = "btnEmail"
        btnEmail.Padding = New Padding(30, 0, 0, 0)
        btnEmail.Size = New Size(250, 48)
        btnEmail.TabIndex = 88
        btnEmail.Text = "   Send Email"
        btnEmail.TextAlign = ContentAlignment.MiddleLeft
        btnEmail.TextImageRelation = TextImageRelation.ImageBeforeText
        btnEmail.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.Transparent
        btnExit.BackgroundImageLayout = ImageLayout.None
        btnExit.FlatAppearance.BorderSize = 0
        btnExit.FlatStyle = FlatStyle.Flat
        btnExit.Image = My.Resources.Resources._Exit
        btnExit.Location = New Point(1170, 0)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(51, 38)
        btnExit.TabIndex = 89
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.RedTiles1
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(dataGrid)
        Panel1.Controls.Add(comboSections)
        Panel1.Controls.Add(comboYearLevel)
        Panel1.Controls.Add(comboSubjects)
        Panel1.Controls.Add(comboCourses)
        Panel1.Controls.Add(combo_class)
        Panel1.Controls.Add(cboSheet1)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(txtFileName1)
        Panel1.Controls.Add(btnEmail)
        Panel1.Controls.Add(Label14)
        Panel1.Controls.Add(txtManageStudentSearch)
        Panel1.Controls.Add(buttonDelete)
        Panel1.Controls.Add(buttonUpdate)
        Panel1.Controls.Add(Label13)
        Panel1.Controls.Add(btnUploadpicture)
        Panel1.Controls.Add(studpicture)
        Panel1.Controls.Add(buttonClear)
        Panel1.Controls.Add(buttonSave)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(txtEmailAddress)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(txtConNumber)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtSNumber)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(txtSName)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1221, 728)
        Panel1.TabIndex = 90
        ' 
        ' dataGrid
        ' 
        dataGrid.AllowUserToOrderColumns = True
        dataGrid.BackgroundColor = Color.White
        dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGrid.Location = New Point(615, 107)
        dataGrid.Name = "dataGrid"
        dataGrid.RowHeadersWidth = 51
        dataGrid.RowTemplate.Height = 29
        dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dataGrid.Size = New Size(570, 455)
        dataGrid.TabIndex = 102
        ' 
        ' comboSections
        ' 
        comboSections.BorderStyle = BorderStyle.FixedSingle
        comboSections.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        comboSections.Location = New Point(318, 434)
        comboSections.Margin = New Padding(4, 3, 4, 3)
        comboSections.Multiline = True
        comboSections.Name = "comboSections"
        comboSections.Size = New Size(115, 29)
        comboSections.TabIndex = 101
        ' 
        ' comboYearLevel
        ' 
        comboYearLevel.BorderStyle = BorderStyle.FixedSingle
        comboYearLevel.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        comboYearLevel.Location = New Point(317, 366)
        comboYearLevel.Margin = New Padding(4, 3, 4, 3)
        comboYearLevel.Multiline = True
        comboYearLevel.Name = "comboYearLevel"
        comboYearLevel.Size = New Size(115, 29)
        comboYearLevel.TabIndex = 100
        ' 
        ' comboSubjects
        ' 
        comboSubjects.BorderStyle = BorderStyle.FixedSingle
        comboSubjects.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        comboSubjects.Location = New Point(318, 488)
        comboSubjects.Margin = New Padding(4, 3, 4, 3)
        comboSubjects.Multiline = True
        comboSubjects.Name = "comboSubjects"
        comboSubjects.Size = New Size(115, 29)
        comboSubjects.TabIndex = 99
        ' 
        ' comboCourses
        ' 
        comboCourses.BorderStyle = BorderStyle.FixedSingle
        comboCourses.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        comboCourses.Location = New Point(454, 434)
        comboCourses.Margin = New Padding(4, 3, 4, 3)
        comboCourses.Multiline = True
        comboCourses.Name = "comboCourses"
        comboCourses.Size = New Size(115, 29)
        comboCourses.TabIndex = 98
        ' 
        ' combo_class
        ' 
        combo_class.FormattingEnabled = True
        combo_class.Items.AddRange(New Object() {"BSCS", "BSIS", "BSOA", "BSED", "BSHM"})
        combo_class.Location = New Point(318, 126)
        combo_class.Margin = New Padding(4, 3, 4, 3)
        combo_class.Name = "combo_class"
        combo_class.Size = New Size(115, 28)
        combo_class.TabIndex = 96
        ' 
        ' cboSheet1
        ' 
        cboSheet1.FormattingEnabled = True
        cboSheet1.Location = New Point(702, 619)
        cboSheet1.Name = "cboSheet1"
        cboSheet1.Size = New Size(202, 28)
        cboSheet1.TabIndex = 95
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(605, 622)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 20)
        Label7.TabIndex = 94
        Label7.Text = "Sheet:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(605, 589)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(90, 20)
        Label6.TabIndex = 93
        Label6.Text = "File Name:"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Firebrick
        Button1.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(1121, 585)
        Button1.Name = "Button1"
        Button1.Size = New Size(64, 24)
        Button1.TabIndex = 92
        Button1.Text = "Browse"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' txtFileName1
        ' 
        txtFileName1.Location = New Point(702, 584)
        txtFileName1.Name = "txtFileName1"
        txtFileName1.Size = New Size(413, 27)
        txtFileName1.TabIndex = 91
        ' 
        ' Form11
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Firebrick
        ClientSize = New Size(1221, 728)
        Controls.Add(Panel1)
        Controls.Add(btnExit)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form11"
        Text = "Form11"
        CType(studpicture, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(dataGrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label13 As Label
    Friend WithEvents btnUploadpicture As Button
    Friend WithEvents studpicture As PictureBox
    Friend WithEvents buttonClear As Button
    Friend WithEvents buttonSave As Button
    Protected Friend WithEvents Label12 As Label
    Protected Friend WithEvents Label11 As Label
    Protected Friend WithEvents Label10 As Label
    Friend WithEvents txtEmailAddress As TextBox
    Protected Friend WithEvents Label5 As Label
    Friend WithEvents txtConNumber As TextBox
    Protected Friend WithEvents Label2 As Label
    Friend WithEvents txtSNumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSName As TextBox
    Protected Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents buttonDelete As Button
    Friend WithEvents buttonUpdate As Button
    Protected Friend WithEvents Label14 As Label
    Friend WithEvents txtManageStudentSearch As TextBox
    Friend WithEvents comboManageStudentClassNum As ComboBox
    Friend WithEvents btnEmail As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents txtFileName1 As TextBox
    Friend WithEvents cboSheet1 As ComboBox
    Friend Protected WithEvents Label7 As Label
    Friend Protected WithEvents Label6 As Label
    Friend WithEvents combo_class As ComboBox
    Friend WithEvents comboSubjects As TextBox
    Friend WithEvents comboCourses As TextBox
    Friend WithEvents comboYearLevel As TextBox
    Friend WithEvents comboSections As TextBox
    Friend WithEvents dataGrid As DataGridView
End Class
