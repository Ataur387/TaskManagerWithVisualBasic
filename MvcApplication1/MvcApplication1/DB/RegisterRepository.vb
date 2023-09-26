Imports System.Data.SqlClient
Public Class RegisterRepository
    Private connectionString As String

    Public Sub New(ByVal connectionString As String)
        Me.connectionString = connectionString
    End Sub
    Public Sub Insert(ByVal entity As RegisterModel)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using cmd As New SqlCommand("INSERT INTO register (username, fullname, password, email) VALUES (@Value1, @Value2, @Value3, @Value4)", connection)
                cmd.Parameters.AddWithValue("@Value1", entity.UserName)
                cmd.Parameters.AddWithValue("@Value2", entity.FullName)
                cmd.Parameters.AddWithValue("@Value3", entity.Password)
                cmd.Parameters.AddWithValue("@Value4", entity.Email)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Function GetByUserName(ByVal UserName As String) As RegisterModel
        Dim user As New RegisterModel()

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using cmd As New SqlCommand("SELECT * FROM register WHERE username = @UserName", connection)
                cmd.Parameters.AddWithValue("@username", UserName)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        user.FullName = reader("fullname").ToString()
                        user.UserName = reader("username").ToString()
                        user.Email = reader("email").ToString
                        user.Password = reader("password").ToString
                        user.Id = reader("id").ToString()
                    End If
                End Using
            End Using
        End Using

        Return user
    End Function
End Class
