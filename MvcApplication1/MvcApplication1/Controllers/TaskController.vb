Namespace MvcApplication1
    <Authorize()>
    Public Class TaskController
        Inherits System.Web.Mvc.Controller

        Dim connectionString As String = "Data Source=LAPTOP-KCNT9R65;Initial Catalog=aspnetdb;Integrated Security=SSPI;"
        Dim repository As New TaskRepository(connectionString)
        Dim userRepository As New RegisterRepository(connectionString)
        '
        ' GET: /Task

        Function Index() As ActionResult
            Dim userName As String = User.Identity.Name
            Dim appUser As RegisterModel
            appUser = userRepository.GetByUserName(userName)
            Dim tasks As List(Of Task) = repository.GetAllTasks(appUser.Id)
            Return View("Tasks", tasks)
        End Function

        '
        ' GET: /Task/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Dim task As Task = repository.GetById(id)
            Return View(task)
        End Function

        '
        ' GET: /Task/Create

        Function Create() As ActionResult
            Return View("Create")
        End Function

        '
        ' POST: /Task/Create

        <HttpPost()> _
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                Dim username As String = User.Identity.Name
                Dim appUser As RegisterModel
                appUser = userRepository.GetByUserName(username)
                Dim entity As New Task()
                entity.Name = collection("Name")
                entity.Status = "PENDING"
                entity.UserId = appUser.Id
                repository.Insert(entity)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Task/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            Dim task As Task = repository.GetById(id)
            Return View(task)
        End Function

        '
        ' POST: /Task/Edit/5

        <HttpPost()> _
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                Dim entity As New Task()
                entity.Id = id
                entity.Name = collection("Name")
                entity.Status = collection("Status")
                repository.Update(entity)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Task/Delete/5

        Function Delete(ByVal id As Integer) As ActionResult
            Dim task As Task = repository.GetById(id)
            Return View(task)
        End Function

        '
        ' POST: /Task/Delete/5

        <HttpPost()> _
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                repository.Delete(id)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace