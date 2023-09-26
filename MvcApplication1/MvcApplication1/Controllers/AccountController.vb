Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Web.Routing
Imports System.Web.Security

<HandleError()> _
Public Class AccountController
    Inherits System.Web.Mvc.Controller

    Private formsServiceValue As IFormsAuthenticationService
    Private membershipServiceValue As IMembershipService
    Dim connectionString As String = "Data Source=LAPTOP-KCNT9R65;Initial Catalog=aspnetdb;Integrated Security=SSPI;"
    Dim repository As New RegisterRepository(connectionString)
    Dim Service As New AccountService
    Dim Salt As String = "salt"

    Public Property FormsService() As IFormsAuthenticationService
        Get
            Return formsServiceValue
        End Get
        Set(ByVal value As IFormsAuthenticationService)
            formsServiceValue = value
        End Set
    End Property

    Public Property MembershipService() As IMembershipService
        Get
            Return membershipServiceValue
        End Get
        Set(ByVal value As IMembershipService)
            membershipServiceValue = value
        End Set
    End Property

    Protected Overrides Sub Initialize(ByVal requestContext As RequestContext)
        If FormsService Is Nothing Then FormsService = New FormsAuthenticationService()
        If MembershipService Is Nothing Then MembershipService = New AccountMembershipService()

        MyBase.Initialize(requestContext)
    End Sub

    ' **************************************
    ' URL: /Account/LogOn
    ' **************************************

    Public Function LogOn() As ActionResult
        Return View()
    End Function

    <HttpPost()>
    Public Function LogOn(ByVal model As LogOnModel, ByVal returnUrl As String) As ActionResult
        If ModelState.IsValid Then
            Dim connectionString As String = "Data Source=LAPTOP-KCNT9R65;Initial Catalog=aspnetdb;Integrated Security=SSPI;"
            Dim repository As New RegisterRepository(connectionString)
            Dim user As RegisterModel = repository.GetByUserName(model.UserName)
            If user IsNot Nothing AndAlso Service.VerifyPassword(model.Password, user.Password, Salt) Then
                ' Password is correct; you can proceed with authentication
                ' Here, you may set authentication cookies or session variables
                Dim authTicket As New FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), False, "")
                Dim encryptedTicket As String = FormsAuthentication.Encrypt(authTicket)
                Dim authCookie As New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                Response.Cookies.Add(authCookie)
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If
        End If

        ' If ModelState is not valid or authentication fails, return to the login view with an error message
        Return View(model)
    End Function


    ' **************************************
    ' URL: /Account/LogOff
    ' **************************************

    Public Function LogOff() As ActionResult
        FormsService.SignOut()

        Return RedirectToAction("Index", "Home")
    End Function

    ' **************************************
    ' URL: /Account/Register
    ' **************************************

    Public Function Register() As ActionResult
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View()
    End Function

    <HttpPost()> _
    Public Function Register(ByVal model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            model.Password = Service.HashPassword(model.Password, Salt)
            repository.Insert(model)
            Return (RedirectToAction("Index", "Home"))
        End If

        ' If we got this far, something failed, redisplay form
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View(model)
    End Function

    ' **************************************
    ' URL: /Account/ChangePassword
    ' **************************************

    <Authorize()> _
    Public Function ChangePassword() As ActionResult
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View()
    End Function

    <Authorize()> _
    <HttpPost()> _
    Public Function ChangePassword(ByVal model As ChangePasswordModel) As ActionResult
        If ModelState.IsValid Then
            If MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword) Then
                Return RedirectToAction("ChangePasswordSuccess")
            Else
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
            End If
        End If

        ' If we got this far, something failed, redisplay form
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View(model)
    End Function

    ' **************************************
    ' URL: /Account/ChangePasswordSuccess
    ' **************************************

    Public Function ChangePasswordSuccess() As ActionResult
        Return View()
    End Function
End Class
