Imports ExcelDataReader
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational
Imports System.Data
Imports System.IO
Imports System.Text


Public Class Form11
    Dim tables As DataTableCollection
    Dim myData As New DataTable

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClassNumbers()
        DisplayData(dataGrid)


    End Sub

    Private Sub LoadClassNumbers()
        Try
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()
                Dim query As String = "SELECT class_number FROM classes"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        combo_class.Items.Clear() ' Clear any previous items
                        While reader.Read()
                            combo_class.Items.Add(reader("class_number").ToString()) ' Add class_number to the ComboBox
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
            If String.IsNullOrEmpty(combo_class.SelectedItem?.ToString()) Then
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
                    cmd.Parameters.AddWithValue("@class_number", combo_class.SelectedItem.ToString())

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




    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Form3.Show()
        Me.Hide()
    End Sub


    Public Sub Save()
        Try
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()

                Using cmd As New MySqlCommand("INSERT INTO `students`(`student_name`, `student_number`, `contact_number`, `email_address`, `year_level`, `course`, `section`, `subject`, `class_number`, `student_image`) VALUES (@student_name, @student_number, @contact_number, @email_address, @year_level, @course, @section, @subject, @class_number, @student_image)", conn)
                    ' Add parameters for the values to be inserted
                    cmd.Parameters.AddWithValue("@student_name", txtSName.Text)
                    cmd.Parameters.AddWithValue("@contact_number", txtConNumber.Text)
                    cmd.Parameters.AddWithValue("@email_address", txtEmailAddress.Text)
                    cmd.Parameters.AddWithValue("@year_level", comboYearLevel.Text)
                    cmd.Parameters.AddWithValue("@course", comboCourses.Text)
                    cmd.Parameters.AddWithValue("@section", comboSections.Text)
                    cmd.Parameters.AddWithValue("@subject", comboSubjects.Text)
                    cmd.Parameters.AddWithValue("@class_number", combo_class.SelectedItem.ToString()) ' Add class_number parameter
                    cmd.Parameters.AddWithValue("@student_number", txtSNumber.Text)

                    ' Handle image saving
                    If studpicture.Image IsNot Nothing Then
                        Using ms As New MemoryStream()
                            studpicture.Image.Save(ms, studpicture.Image.RawFormat)
                            Dim imageBytes As Byte() = ms.ToArray()
                            cmd.Parameters.AddWithValue("@student_image", imageBytes)
                        End Using
                    Else
                        cmd.Parameters.AddWithValue("@student_image", DBNull.Value)
                    End If

                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Data and image have been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' After saving, refresh the DataGridView to see the latest data
                DisplayData(dataGrid)
                Form5.RefreshDataGrid()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        Save()
    End Sub

    Private Sub buttonClear_Click(sender As Object, e As EventArgs) Handles buttonClear.Click
        txtSName.Clear()
        txtSNumber.Clear()

        txtConNumber.Clear()
        txtEmailAddress.Clear()


        comboYearLevel.Clear()
        comboCourses.Clear()
        comboSections.Clear()
        comboSubjects.Clear()
    End Sub

    Private Sub buttonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
        ' Check if a row is selected
        If dataGrid.SelectedRows.Count > 0 Then
            ' Get the selected student_number
            Dim studentNumber = dataGrid.SelectedRows(0).Cells("col2").Value.ToString

            ' Ask for confirmation before deleting
            Dim result = MessageBox.Show($"Are you sure you want to delete student with Student Number: {studentNumber}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' If user confirms, proceed with deletion
                DeleteStudent(studentNumber)
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        DisplayData(dataGrid)
        Form5.RefreshDataGrid()
    End Sub


    Private Sub DeleteStudent(studentNumber As String)
        Try
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()

                Using cmd As New MySqlCommand("DELETE FROM students WHERE student_number = @student_number", conn)
                    cmd.Parameters.AddWithValue("@student_number", studentNumber)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"Student {studentNumber} has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error deleting student: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearForm()
        ' Clear the form controls
        txtSName.Clear()
        txtSNumber.Clear()

        txtConNumber.Clear()
        txtEmailAddress.Clear()


        comboYearLevel.Clear()
        comboCourses.Clear()
        comboSections.Clear()
        comboSubjects.Clear()
        buttonSave.Enabled = True
    End Sub

    Private Sub dataGrid_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)

    End Sub




    Private Function GetImagePathFromDatabase(studentNumber As String) As String
        Try
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()

                ' Assuming your image path is stored in a column named "student_image" in the "students" table
                Dim query As String = "SELECT student_image FROM students WHERE student_number = @student_number"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@student_number", studentNumber)

                    Dim result As Object = cmd.ExecuteScalar()

                    ' Check if the result is not DBNull.Value and not empty
                    If result IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(result.ToString()) Then
                        ' Return the image path
                        Return result.ToString()
                    Else
                        ' Return an empty string if the image path is not found
                        Return String.Empty
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log or display an error message)
            Console.WriteLine("Error: " & ex.Message)
            Return String.Empty
        End Try
    End Function

    Private Sub buttonUpdate_Click(sender As Object, e As EventArgs) Handles buttonUpdate.Click
        Try
            ' Corrected the port number in the connection string
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()

                ' SQL query corrected to include `student_image`
                Using cmd As New MySqlCommand("UPDATE `students` SET `student_name` = @student_name, `contact_number` = @contact_number, `email_address` = @email_address, `year_level` = @year_level, `course` = @course, `section` = @section, `subject` = @subject, `class_number` = @class_number, `student_image` = @student_image WHERE `student_number` = @student_number", conn)
                    ' Adding parameters for update
                    cmd.Parameters.AddWithValue("@student_name", txtSName.Text)
                    cmd.Parameters.AddWithValue("@contact_number", txtConNumber.Text)
                    cmd.Parameters.AddWithValue("@email_address", txtEmailAddress.Text)
                    cmd.Parameters.AddWithValue("@year_level", comboYearLevel.Text)
                    cmd.Parameters.AddWithValue("@course", comboCourses.Text)
                    cmd.Parameters.AddWithValue("@section", comboSections.Text)
                    cmd.Parameters.AddWithValue("@subject", comboSubjects.Text)
                    cmd.Parameters.AddWithValue("@class_number", If(combo_class.SelectedItem IsNot Nothing, combo_class.SelectedItem.ToString(), DBNull.Value))
                    cmd.Parameters.AddWithValue("@student_number", txtSNumber.Text)

                    ' Handle image update
                    If studpicture.Image IsNot Nothing Then
                        Using ms As New MemoryStream()
                            studpicture.Image.Save(ms, studpicture.Image.RawFormat)
                            Dim imageBytes As Byte() = ms.ToArray()
                            cmd.Parameters.AddWithValue("@student_image", imageBytes)
                        End Using
                    Else
                        cmd.Parameters.AddWithValue("@student_image", DBNull.Value)
                    End If

                    cmd.ExecuteNonQuery()
                End Using

                ' Success message
                MessageBox.Show("Data and image have been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh DataGridView
                DisplayData(dataGrid)
                Form5.RefreshDataGrid()
            End Using
        Catch ex As Exception
            ' Error handling
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub comboManageStudentClassNum_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Add code for handling class number selection if needed
    End Sub

    Private Sub txtManageStudentSearch_TextChanged(sender As Object, e As EventArgs) Handles txtManageStudentSearch.TextChanged
        FilterStudentData(txtManageStudentSearch.Text)
    End Sub

    Private Sub FilterStudentData(searchTerm As String)
        Try
            Dim filterExpression As String = ""

            If Not String.IsNullOrEmpty(searchTerm) Then
                ' Check if searchTerm is a valid integer
                Dim isNumeric As Boolean = Integer.TryParse(searchTerm, Nothing)

                If isNumeric Then
                    ' If it's an integer, filter using '=' (convert numeric search term to string for comparison)
                    filterExpression = $"student_name LIKE '%{searchTerm}%' OR " &
                       $"course LIKE '%{searchTerm}%' OR " &
                       $"email_address LIKE '%{searchTerm}%' OR " &
                       $"section LIKE '%{searchTerm}%' OR " &
                       $"contact_number LIKE '{searchTerm}%'"

                Else
                    ' If it's not an integer, filter using 'LIKE'
                    filterExpression = $"student_name LIKE '%{searchTerm}%' OR " &
                       $"course LIKE '%{searchTerm}%' OR " &
                       $"email_address LIKE '%{searchTerm}%' OR " &
                       $"section LIKE '%{searchTerm}%' OR " &
                       $"contact_number LIKE '{searchTerm}%'"

                End If
            End If

            Console.WriteLine("Filter Expression: " & filterExpression) ' Debug output

            ' Check if any rows are found after filtering
            If myData IsNot Nothing AndAlso myData.Rows.Count > 0 Then
                myData.DefaultView.RowFilter = filterExpression

                If myData.DefaultView.Count = 0 Then
                    MsgBox("No matching records found.")
                End If
            End If
        Catch ex As FormatException
            ' Handle the FormatException (related to incomplete numeric parsing) silently without showing an error message
        Catch ex As Exception
            ' Handle other exceptions and show an error message
            Console.WriteLine("Error: " & ex.Message) ' Debug output
        End Try
    End Sub

    Private Sub btnUploadpicture_Click(sender As Object, e As EventArgs) Handles btnUploadpicture.Click
        Try
            Dim openFileDialog As New OpenFileDialog
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            openFileDialog.Title = "Select an Image File"

            If openFileDialog.ShowDialog = DialogResult.OK Then
                Dim imagePath = openFileDialog.FileName

                ' Display the selected image in the PictureBox
                studpicture.Image = Image.FromFile(imagePath)

                ' Convert the image to a byte array
                Dim imageBytes = File.ReadAllBytes(imagePath)

                ' Update the database with the image
                UpdateStudentImage(txtSNumber.Text, imageBytes)
            End If
        Catch ex As Exception
            MessageBox.Show("Error uploading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateStudentImage(studentNumber As String, imageBytes As Byte())
        Try
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()

                Using cmd As New MySqlCommand("UPDATE students SET student_image = @student_image WHERE student_number = @student_number", conn)
                    cmd.Parameters.AddWithValue("@student_image", imageBytes)
                    cmd.Parameters.AddWithValue("@student_number", studentNumber)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Image has been uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error updating student image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub studpicture_Click(sender As Object, e As EventArgs) Handles studpicture.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    'Logic For Excel to table
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using ofd As New OpenFileDialog With {.Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"}
            If ofd.ShowDialog() = DialogResult.OK Then
                txtFileName1.Text = ofd.FileName
                Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                    Using reader = ExcelReaderFactory.CreateReader(stream)
                        Dim result = reader.AsDataSet(New ExcelDataSetConfiguration With {
                        .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration With {
                            .UseHeaderRow = True
                        }
                    })
                        tables = result.Tables
                        cboSheet1.Items.Clear()

                        For Each table As DataTable In tables
                            cboSheet1.Items.Add(table.TableName)
                        Next
                    End Using
                End Using
            End If
        End Using
    End Sub


    Private Sub cboSheet1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSheet1.SelectedIndexChanged
        Dim dt = tables(cboSheet1.SelectedItem.ToString)
        dataGrid.DataSource = dt
    End Sub


    Private Sub combo_class_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_class.SelectedIndexChanged
        If String.IsNullOrEmpty(combo_class.SelectedItem?.ToString()) Then


            Return ' Do nothing if no class is selected
        End If

        SetClassDetails(combo_class.SelectedItem.ToString())

    End Sub

    Private Sub SetClassDetails(classNumber As String)
        Try
            Using conn As New MySqlConnection("server=localhost;port=3306;database=attendancesystem;username=root;password=;")
                conn.Open()

                Dim query As String = "
            SELECT CYear, CCourse, CSection, CSubject 
            FROM classes 
            WHERE class_number = @class_number"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@class_number", classNumber)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            comboYearLevel.Text = reader("CYear").ToString()
                            comboCourses.Text = reader("CCourse").ToString()
                            comboSections.Text = reader("CSection").ToString()
                            comboSubjects.Text = reader("CSubject").ToString()
                        End If
                    End Using
                    DisplayData(dataGrid)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Dim currentEmail As String = txtEmailAddress.Text
        Dim form13 As New Form13(currentEmail)  ' Create a new instance of Form13
        form13.Show()  ' Show the form
    End Sub

    Private Sub dataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles dataGrid.SelectionChanged
        If dataGrid.SelectedRows.Count > 0 Then
            Dim selectedRow = dataGrid.SelectedRows(0)

            ' Ensure column values are not Nothing before setting text fields
            If selectedRow.Cells("col3").Value IsNot Nothing Then
                txtSName.Text = selectedRow.Cells("col3").Value.ToString() ' "Student Name"
            End If

            If selectedRow.Cells("col2").Value IsNot Nothing Then
                txtSNumber.Text = selectedRow.Cells("col2").Value.ToString() ' "Student Number"
            End If

            If selectedRow.Cells("col9").Value IsNot Nothing Then
                txtConNumber.Text = selectedRow.Cells("col9").Value.ToString() ' "Contact Number"
            End If

            If selectedRow.Cells("col10").Value IsNot Nothing Then
                txtEmailAddress.Text = selectedRow.Cells("col10").Value.ToString() ' "Email Address"
            End If

            ' Assign values from other columns, with null check
            If selectedRow.Cells("col5").Value IsNot Nothing Then
                comboYearLevel.Text = selectedRow.Cells("col5").Value.ToString() ' "Year Level"
            End If

            If selectedRow.Cells("col6").Value IsNot Nothing Then
                comboCourses.Text = selectedRow.Cells("col6").Value.ToString() ' "Course"
            End If

            If selectedRow.Cells("col7").Value IsNot Nothing Then
                comboSections.Text = selectedRow.Cells("col7").Value.ToString() ' "Section"
            End If

            If selectedRow.Cells("col8").Value IsNot Nothing Then
                comboSubjects.Text = selectedRow.Cells("col8").Value.ToString() ' "Subject"
            End If

            ' Check for image in col4 and update studpicture
            Dim image As Image = CType(selectedRow.Cells("col4").Value, Image)
            If image IsNot Nothing Then
                studpicture.Image = image ' Set the selected image
            Else
                ' Set default image if no image exists
                studpicture.Image = Image.FromFile("C:\Users\client\source\repos\System for System Fair\Resources\icon.jpg")
            End If
        End If
    End Sub





End Class
