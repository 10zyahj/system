Imports ExcelDataReader
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational
Imports System.Data
Imports System.IO
Imports System.Text


Public Class Form5
    Private connectionString As String = "server=localhost;port=3306;database=attendancesystem;username=root;password=;"

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClassNumbersCombo() ' Call the method when the form is loaded
    End Sub

    ' ComboBox selection changed event to load students based on class_number
    Private Sub combo_class_check_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_class_check.SelectedIndexChanged
        Dim selectedClassNumber As String = combo_class_check.SelectedItem.ToString()

        ' Call the method to load students for the selected class
        DisplayData(datagrid)
    End Sub

    ' Method to load class numbers into ComboBox
    Private Sub LoadClassNumbersCombo()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT class_number FROM classes"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        combo_class_check.Items.Clear() ' Clear any previous items
                        While reader.Read()
                            combo_class_check.Items.Add(reader("class_number").ToString()) ' Add class_number to the ComboBox
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayData(dataGrid As DataGridView)
        Try
            ' If no class is selected, just exit the method
            If String.IsNullOrEmpty(combo_class_check.SelectedItem?.ToString()) Then
                Return ' Exit without doing anything if combo_class is empty
            End If

            ' Remove the existing DataGridView and create a new one
            dataGrid.Columns.Clear()
            dataGrid.Rows.Clear()

            ' Create columns programmatically
            dataGrid.Columns.Add("col1", "Class")
            dataGrid.Columns.Add("col2", "Student Number")
            dataGrid.Columns.Add("col3", "Student Name")

            ' Create an image column explicitly
            Dim imageColumn As New DataGridViewImageColumn()
            imageColumn.Name = "col4"
            imageColumn.HeaderText = "Picture"
            dataGrid.Columns.Add(imageColumn)

            ' Create a ComboBox column for the Status field
            Dim statusColumn As New DataGridViewComboBoxColumn()
            statusColumn.Name = "col11"
            statusColumn.HeaderText = "Status"
            statusColumn.Items.AddRange("Present", "Late", "Absent")
            dataGrid.Columns.Add(statusColumn)

            ' Add remaining columns after Status column
            dataGrid.Columns.Add("col5", "Year Level")
            dataGrid.Columns.Add("col6", "Course")
            dataGrid.Columns.Add("col7", "Section")
            dataGrid.Columns.Add("col8", "Subject")
            dataGrid.Columns.Add("col9", "Contact Number")
            dataGrid.Columns.Add("col10", "Email Address")

            ' Set up specific column formatting for image column (col4)
            imageColumn.Width = 100
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom  ' Set image layout to Zoom

            ' Set row height to fit the image
            dataGrid.RowTemplate.Height = 100

            ' Now proceed to get data from the database
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()

                ' Query to fetch combined data from classes and students
                Dim query As String = "
    SELECT 
        c.class_number AS class,
        s.student_number AS student_number,
        s.student_name AS student_name,
        s.student_image AS picture,
        c.CYear AS year_level,
        c.CCourse AS course,
        c.CSection AS section,
        c.CSubject AS subject,
        s.contact_number AS contact_number,
        s.email_address AS email_address
    FROM 
        classes c
    INNER JOIN 
        students s ON c.class_number = s.class_number
    WHERE 
        c.class_number = @class_number
    "

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@class_number", combo_class_check.SelectedItem.ToString())

                    Using da As New MySqlDataAdapter(cmd)
                        Dim myData As New DataTable
                        da.Fill(myData)

                        ' Loop through the data and add rows to the DataGridView
                        For Each row As DataRow In myData.Rows
                            Dim rowIndex As Integer = dataGrid.Rows.Add()

                            ' Populate the row with data from the DataTable
                            dataGrid.Rows(rowIndex).Cells("col1").Value = row("class")
                            dataGrid.Rows(rowIndex).Cells("col2").Value = row("student_number")
                            dataGrid.Rows(rowIndex).Cells("col3").Value = row("student_name")
                            dataGrid.Rows(rowIndex).Cells("col5").Value = row("year_level")
                            dataGrid.Rows(rowIndex).Cells("col6").Value = row("course")
                            dataGrid.Rows(rowIndex).Cells("col7").Value = row("section")
                            dataGrid.Rows(rowIndex).Cells("col8").Value = row("subject")
                            dataGrid.Rows(rowIndex).Cells("col9").Value = row("contact_number")
                            dataGrid.Rows(rowIndex).Cells("col10").Value = row("email_address")

                            ' Get the image from the byte array (assuming s.student_image is a BLOB in the database)
                            Dim imageBytes As Byte() = TryCast(row("picture"), Byte())
                            If imageBytes IsNot Nothing AndAlso imageBytes.Length > 0 Then
                                Using ms As New IO.MemoryStream(imageBytes)
                                    dataGrid.Rows(rowIndex).Cells("col4").Value = Image.FromStream(ms)
                                End Using
                            End If

                            ' Optionally, set default status (can be empty initially)
                            dataGrid.Rows(rowIndex).Cells("col11").Value = "Present" ' Default status
                        Next

                        ' Optionally, auto-size columns to fit the content
                        dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                    End Using
                End Using
            End Using

            ' Explicitly refresh the grid layout
            dataGrid.Refresh()
            dataGrid.PerformLayout()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub btnViewAttendance_Click(sender As Object, e As EventArgs) Handles btnViewAttendance.Click
        With Form10
            .TopLevel = False
            Form3.Panel4.Controls.Add(Form10)
            .BringToFront()
            .Show()
        End With
    End Sub


    ' Capture selected date from DateTimePicker and insert attendance records

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Get the selected date from the DateTimePicker control (day)
            Dim selectedDate As DateTime = day.Value

            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                For Each row As DataGridViewRow In datagrid.Rows
                    ' Check if the row is not a header
                    If Not row.IsNewRow Then
                        ' Get the student number (from the DataGridView)
                        Dim studentNumber As String = CStr(row.Cells("col2").Value) ' Use the correct cell for student_number

                        ' Find the student_number using the student_number (no need for student_id now)
                        Dim studentNumberInDb As String = ""
                        Dim findStudentNumberSql As String = "SELECT student_number FROM students WHERE student_number = @student_number"
                        Using findStudentCmd As New MySqlCommand(findStudentNumberSql, connection)
                            findStudentCmd.Parameters.AddWithValue("@student_number", studentNumber)
                            Dim result As Object = findStudentCmd.ExecuteScalar()

                            If result IsNot Nothing Then
                                studentNumberInDb = CStr(result)
                            Else
                                ' Handle case where student_number does not exist
                                MessageBox.Show("Student with number " & studentNumber & " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Continue For ' Skip this row if student is not found
                            End If
                        End Using

                        ' Get the selected status from the ComboBox column
                        Dim statusCell As DataGridViewComboBoxCell = TryCast(row.Cells("col11"), DataGridViewComboBoxCell)
                        Dim selectedStatus As String = If(statusCell IsNot Nothing, CStr(statusCell.Value), "Present") ' Default status

                        ' Insert into the attendance_records table (now using student_number instead of student_id)
                        Dim sql As String = "INSERT INTO attendance (student_number, attendance_date, attendance_status) " &
                                        "VALUES (@student_number, @attendance_date, @attendance_status)"
                        Using command As New MySqlCommand(sql, connection)
                            command.Parameters.AddWithValue("@student_number", studentNumberInDb) ' Using student_number
                            command.Parameters.AddWithValue("@attendance_date", selectedDate) ' Use the selected date from DateTimePicker
                            command.Parameters.AddWithValue("@attendance_status", selectedStatus)
                            command.ExecuteNonQuery()
                        End Using
                    End If
                Next

                MessageBox.Show("Attendance records saved successfully.")
                Form10.RefreshAttendance() ' If needed, refresh other forms or data
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub




    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For Each row As DataGridViewRow In datagrid.Rows
            If Not row.IsNewRow Then
                row.Cells("col3").Value = String.Empty
            End If
        Next
    End Sub



    ' In Form5
    Public Sub RefreshDataGrid()
        ' Call the DisplayData method that reloads the data into the DataGridView

    End Sub



    ' DataGridView click event
    Private Sub datagrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid.CellContentClick

    End Sub

    ' DatePicker value change event (if needed)
    Private Sub day_ValueChanged(sender As Object, e As EventArgs) Handles day.ValueChanged

    End Sub

    Private Sub lblPresent_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblAbsent_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblLate_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblNumStud_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
