Imports System.Data.SqlClient
Public Class TaskRepository
    Private connectionString As String

    Public Sub New(ByVal connectionString As String)
        Me.connectionString = connectionString
    End Sub
    Public Sub Update(ByVal entity As Task)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using cmd As New SqlCommand("UPDATE task SET name = @Name, status = @Status WHERE id = @Id", connection)
                cmd.Parameters.AddWithValue("@Id", entity.Id)
                cmd.Parameters.AddWithValue("@Name", entity.Name)
                cmd.Parameters.AddWithValue("@Status", entity.Status)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Function GetById(ByVal id As Integer) As Task
        Dim task As New Task()

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using cmd As New SqlCommand("SELECT * FROM task WHERE id = @Id", connection)
                cmd.Parameters.AddWithValue("@Id", id)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        task.Id = Convert.ToInt32(reader("id"))
                        task.Name = reader("name").ToString()
                        task.Status = reader("status").ToString()
                    End If
                End Using
            End Using
        End Using

        Return task
    End Function

    Public Sub Insert(ByVal entity As Task)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using cmd As New SqlCommand("INSERT INTO task (name, status) VALUES (@Value1, @Value2)", connection)
                cmd.Parameters.AddWithValue("@Value1", entity.Name)
                cmd.Parameters.AddWithValue("@Value2", entity.Status)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function GetAllTasks() As List(Of Task)
        Dim tasks As New List(Of Task)()

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM task"

            Using cmd As New SqlCommand(query, connection)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim task As New Task()
                        task.Id = Convert.ToInt32(reader("id"))
                        task.Name = reader("name").ToString()
                        task.Status = reader("status").ToString()

                        tasks.Add(task)
                    End While
                End Using
            End Using
        End Using

        Return tasks
    End Function
    Public Sub Delete(ByVal id As Integer)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using cmd As New SqlCommand("DELETE FROM task WHERE id = @Id", connection)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


End Class
