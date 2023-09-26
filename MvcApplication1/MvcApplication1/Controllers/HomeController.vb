<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Dim connectionString As String = "Data Source=LAPTOP-KCNT9R65;Initial Catalog=aspnetdb;Integrated Security=SSPI;"
    Dim repository As New RegisterRepository(connectionString)
    Function Index() As ActionResult
        ViewData("Message") = "Welcome to Task Manager"

        Return View()
    End Function
    <Authorize()>
    Function About() As ActionResult
        Dim username As String = User.Identity.Name
        Dim appUser As RegisterModel
        appUser = repository.GetByUserName(username)
        Return View(appUser)
    End Function
End Class
