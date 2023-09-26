Imports System.Security.Cryptography
Imports System.Text
Public Class AccountService
    Function HashPassword(ByVal password As String, ByVal salt As String) As String
        Dim combinedBytes() As Byte = Encoding.Unicode.GetBytes(password + salt)
        Dim sha256 As New SHA256Managed()
        Dim hashBytes() As Byte = sha256.ComputeHash(combinedBytes)
        Return Convert.ToBase64String(hashBytes)
    End Function
    Function VerifyPassword(ByVal inputPassword As String, ByVal storedHashedPassword As String, ByVal storedSalt As String) As Boolean
        Dim inputHashedPassword As String = HashPassword(inputPassword, storedSalt)
        Return inputHashedPassword = storedHashedPassword
    End Function
End Class
