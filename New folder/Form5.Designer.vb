<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        btnClear = New Button()
        btnSave = New Button()
        day = New DateTimePicker()
        Label20 = New Label()
        btnViewAttendance = New Button()
        datagrid = New DataGridView()
        Panel1 = New Panel()
        combo_class_check = New ComboBox()
        CType(datagrid, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Firebrick
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(60, 632)
        btnClear.Margin = New Padding(4, 3, 4, 3)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(396, 44)
        btnClear.TabIndex = 106
        btnClear.Text = "CLEAR"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        btnSave.ForeColor = Color.DarkRed
        btnSave.Location = New Point(473, 632)
        btnSave.Margin = New Padding(4, 3, 4, 3)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(396, 44)
        btnSave.TabIndex = 105
        btnSave.Text = "SAVE"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' day
        ' 
        day.AllowDrop = True
        day.Location = New Point(348, 101)
        day.Name = "day"
        day.Size = New Size(250, 27)
        day.TabIndex = 92
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.Transparent
        Label20.Font = New Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label20.ForeColor = SystemColors.Control
        Label20.Location = New Point(259, 46)
        Label20.Name = "Label20"
        Label20.Size = New Size(429, 42)
        Label20.TabIndex = 91
        Label20.Text = "CHECK ATTENDANCE"
        ' 
        ' btnViewAttendance
        ' 
        btnViewAttendance.BackColor = Color.Firebrick
        btnViewAttendance.FlatAppearance.BorderSize = 0
        btnViewAttendance.FlatStyle = FlatStyle.Flat
        btnViewAttendance.Font = New Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        btnViewAttendance.ForeColor = Color.White
        btnViewAttendance.ImageAlign = ContentAlignment.MiddleLeft
        btnViewAttendance.Location = New Point(768, 8)
        btnViewAttendance.Margin = New Padding(4, 3, 4, 3)
        btnViewAttendance.Name = "btnViewAttendance"
        btnViewAttendance.Size = New Size(168, 49)
        btnViewAttendance.TabIndex = 109
        btnViewAttendance.Text = "View Attendance"
        btnViewAttendance.TextImageRelation = TextImageRelation.ImageBeforeText
        btnViewAttendance.UseVisualStyleBackColor = False
        ' 
        ' datagrid
        ' 
        datagrid.AllowUserToAddRows = False
        datagrid.BackgroundColor = SystemColors.Control
        datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        datagrid.Location = New Point(60, 204)
        datagrid.Name = "datagrid"
        datagrid.RowHeadersWidth = 51
        datagrid.RowTemplate.Height = 29
        datagrid.Size = New Size(809, 355)
        datagrid.TabIndex = 129
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.RedTiles1
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(combo_class_check)
        Panel1.Controls.Add(datagrid)
        Panel1.Controls.Add(btnViewAttendance)
        Panel1.Controls.Add(btnClear)
        Panel1.Controls.Add(btnSave)
        Panel1.Controls.Add(day)
        Panel1.Controls.Add(Label20)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(953, 728)
        Panel1.TabIndex = 130
        ' 
        ' combo_class_check
        ' 
        combo_class_check.FormattingEnabled = True
        combo_class_check.Location = New Point(341, 169)
        combo_class_check.Name = "combo_class_check"
        combo_class_check.Size = New Size(151, 28)
        combo_class_check.TabIndex = 130
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Firebrick
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(953, 728)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form5"
        Text = "Form5"
        CType(datagrid, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend Protected WithEvents Label9 As Label
    Friend WithEvents day As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents btnViewAttendance As Button
    Friend WithEvents datagrid As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents comboYear As ComboBox
    Friend WithEvents comboCourse As ComboBox
    Friend WithEvents comboSection As ComboBox
    Friend WithEvents comboClass1 As ComboBox
    Friend WithEvents txtSection1 As TextBox
    Friend WithEvents txtCourse1 As TextBox
    Friend WithEvents txtYear1 As TextBox
    Friend WithEvents col7 As DataGridViewImageColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents combo_class_check As ComboBox
End Class
