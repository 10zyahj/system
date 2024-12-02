Imports MySql.Data.MySqlClient

Public Class Form4
    ' Define the connection string with your database information
    Dim connectionString As String = "Server=localhost;Database=AttendanceSystem;username=root;Password=;"
    Dim connection As MySqlConnection

    Public Property username As String
    Public Sub New()
        InitializeComponent()
        ' Initialize the database connection
        connection = New MySqlConnection(connectionString)
    End Sub


    Public Sub FillTextBoxes()
        Try
            connection.Open()

            Dim query As String = "SELECT EmployeeName, EmployeeNumber, ContactNumber, EmailAddress, Department, SubjectCode FROM register WHERE Username = @username"
            Dim cmd As MySqlCommand = New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@username", username)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txtContactNumber.Text = reader("ContactNumber").ToString()
                txtEmailAddress.Text = reader("EmailAddress").ToString()
                txtDepartment.Text = reader("Department").ToString()


                lblEmployeeName.Text = reader("EmployeeName").ToString()
                lblEmployeeID.Text = reader("EmployeeNumber").ToString()
            End If

            reader.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub YourFormName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillTextBoxes()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub lblEmployeeName_Click(sender As Object, e As EventArgs) Handles lblEmployeeName.Click

    End Sub

    Private Sub txtContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtContactNumber.TextChanged

    End Sub

    ' Rest of your code...

End Class