Namespace Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Settings() As ActionResult
            If Not User.Identity.IsAuthenticated Then
                Return RedirectToAction("Login", "Account")
            Else
                Return View()
            End If
        End Function

        <HttpPost()>
        Public Function Settings(ByVal model As ChangePasswordModel) As ActionResult
            If Not User.Identity.IsAuthenticated Then
                Return RedirectToAction("Login", "Account")
            Else
                If User.IsInRole("master") Then
                    If ModelState.IsValid Then
                        Dim changePasswordSucceeded As Boolean

                        Try
                            Dim currentUser As MembershipUser = Membership.GetUser(User.Identity.Name, True)
                            changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword)
                        Catch ex As Exception
                            changePasswordSucceeded = False
                        End Try

                        If changePasswordSucceeded Then
                            Return RedirectToAction("SuccessChangePassword", "Home")
                        Else
                            ModelState.AddModelError("", "The password is incorrect or new password is invalid.")
                        End If
                    End If

                    Return View(model)
                Else
                    Return RedirectToAction("Unauthorized", "Account")
                End If
            End If
        End Function

        Public Function SuccessChangePassword() As ActionResult
            Return View()
        End Function
    End Class
End Namespace