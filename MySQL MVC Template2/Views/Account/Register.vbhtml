@ModelType MySQL_MVC_Template2.CreateUserModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <link rel="stylesheet" href="@Url.content("~/Content/normalize.css")" type="text/css" />
    <link rel="stylesheet" href="@Url.content("~/Content/skeleton.css")" type="text/css" />
    <link rel="stylesheet" href="@Url.content("~/Content/main.css")" type="text/css" />
    <meta name="viewport" content="width=device-width" />
    <title>Register</title>
</head>
<body>
    <div class="container">

        <div class="row">
            <div class="eleven">
                <div class="nav">
                    <ul>
                        <li>
                            <h5 class="brand-name">persona</h5>
                        </li>
                        <li><a href="/Member/Index">MANAGE MEMBERS</a></li>
                        <li><a href="/Home/Settings">SETTINGS</a></li>
                        <li><a class="nav-active" href="#">REGISTER</a></li>
                        <li><a href="/Account/SignOut">LOGOUT</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <center>
            <div Class="row">
                <div Class="five">
                    <h5>Register a new account.</h5>
                </div>
            </div>
            <div Class="row form-login">
                <div Class="five">
                    @using Html.BeginForm()
                        @Html.ValidationSummary(True, "User creation was not successful. Please correct the errors and try again.")
                        @<div Class="input">
                            <div Class="row">
                                @Html.TextBoxFor(Function(m) m.UserName, New With {Key .style = "width: 320px", Key .placeholder = Html.DisplayNameFor(Function(m) m.UserName)})
                                @Html.ValidationMessageFor(Function(m) m.UserName)
                            </div>
                            <div Class="row">
                                @Html.TextBoxFor(Function(m) m.Email, New With {Key .style = "width: 320px", Key .placeholder = Html.DisplayNameFor(Function(m) m.Email)})
                                @Html.ValidationMessageFor(Function(m) m.Email)
                            </div>
                            <div Class="row">
                                @Html.PasswordFor(Function(m) m.Password, New With {Key .style = "width: 320px", Key .placeholder = Html.DisplayNameFor(Function(m) m.Password)})
                                @Html.ValidationMessageFor(Function(m) m.Password)
                            </div>
                            <div Class="row">
                                @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {Key .style = "width: 320px", Key .placeholder = Html.DisplayNameFor(Function(m) m.ConfirmPassword)})
                                @Html.ValidationMessageFor(Function(m) m.ConfirmPassword)
                            </div>
                            <div class="row">
                                <label for="roleIsAdmin">Register as an Administrator <input style="display: inline-block" type="checkbox" name="roleIsAdmin" /></label>
                            </div>
                        </div>

                            @<div Class="row">
                                <input Class="button-primary" type="submit" value="Register" />
                            </div>
                    End Using
                </div>
            </div>
        </center>



    </div>
</body>
</html>
