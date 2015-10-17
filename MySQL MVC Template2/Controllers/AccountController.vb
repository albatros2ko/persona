Imports System.Web.Mvc
Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Public Function Login() As ActionResult
            Return View()
        End Function


        <HttpPost()>
        Public Function Login(ByVal model As LoginModel, ByVal returnUrl As String) As ActionResult
            If ModelState.IsValid Then
                If Membership.ValidateUser(model.UserName, model.Password) Then
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe)
                    If Url.IsLocalUrl(returnUrl) AndAlso returnUrl.Length > 1 AndAlso returnUrl.StartsWith("/") _
                   AndAlso Not returnUrl.StartsWith("//") AndAlso Not returnUrl.StartsWith("/\\") Then
                        Return Redirect(returnUrl)
                    Else
                        Return RedirectToAction("Settings", "Home")
                    End If
                Else
                    ModelState.AddModelError("", "The user name or password is not correct.")
                End If
            End If

            Return View(model)
        End Function

        Public Function SignOut() As ActionResult
            FormsAuthentication.SignOut()

            Return RedirectToAction("Login", "Account")
        End Function

        Public Function Register() As ActionResult
            If User.IsInRole("master") Then
                Return View()
            Else
                Return RedirectToAction("Unauthorized", "Account")
            End If
        End Function


        <HttpPost()>
        <Authorize(Roles:="master")>
        Public Function Register(ByVal model As CreateUserModel) As ActionResult
            If ModelState.IsValid Then
                Dim createStatus As MembershipCreateStatus
                Membership.CreateUser(model.UserName, model.Password, model.Email, model.Question, model.Answer, True, Nothing, createStatus)

                If createStatus = MembershipCreateStatus.Success Then
                    FormsAuthentication.SetAuthCookie(model.UserName, False)

                    Dim roleIsAdmin = Request.Form("roleIsAdmin")
                    If roleIsAdmin = "on" Then
                        Roles.AddUserToRole(model.UserName, "master")
                    Else
                        Roles.AddUserToRole(model.UserName, "apprentice")
                    End If

                    Return RedirectToAction("SuccessRegisterAccount", "Account")
                Else
                    ModelState.AddModelError("", ErrorCodeToString(createStatus))
                End If
            End If

            Return View(model)
        End Function

        Public Function SuccessRegisterAccount() As ActionResult
            Return View()
        End Function

        Public Function Unauthorized() As ActionResult
            Return View()
        End Function

#Region "Status Code"
        Public Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String

            Select Case createStatus
                Case MembershipCreateStatus.DuplicateUserName
                    Return "User name already exists. Please enter a different user name."

                Case MembershipCreateStatus.DuplicateEmail
                    Return "A user name for that e-mail address already exists. Please enter a different e-mail address."

                Case MembershipCreateStatus.InvalidPassword
                    Return "The password provided is invalid. Please enter a valid password value."

                Case MembershipCreateStatus.InvalidEmail
                    Return "Email is invalid. Please enter a different value and try again."

                Case MembershipCreateStatus.InvalidAnswer
                    Return "The password answer provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidQuestion
                    Return "The password question provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidUserName
                    Return "The user name provided is invalid. Please enter a different value and try again."

                Case MembershipCreateStatus.ProviderError
                    Return "The authentication provider returned an error. Please verify and try again."

                Case MembershipCreateStatus.UserRejected
                    Return "The user creation request has been cancelled. Please verify and try again."

                Case Else
                    Return "An unknown error occurred."
            End Select
        End Function
#End Region

    End Class
End Namespace