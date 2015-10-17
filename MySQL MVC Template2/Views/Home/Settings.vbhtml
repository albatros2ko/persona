@ModelType MySQL_MVC_Template2.ChangePasswordModel

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
    <title>PERSONA | Settings</title>
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
                        <li><a class="nav-active" href="#">SETTINGS</a></li>
                        <li><a href="/Account/Register">REGISTER</a></li>
                        <li><a href="/Account/SignOut">LOGOUT</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="account-settings">
            <div class="row" style="margin-top: 3em;">
                <div class="five columns">
                    <h5>Change password</h5>
                    @Using Html.BeginForm()
                    @Html.ValidationSummary(True, "Password change was unsuccessful. Please correct the errors and try again.")
                        @<div Class="input">
                            <div Class="row">
                                @Html.passwordfor(Function(m) m.OldPassword, New With {Key .placeholder = Html.displayNameFor(Function(m) m.OldPassword)})
                                <p>@Html.ValidationMessageFor(Function(m) m.OldPassword)</p>
                            </div>
                            <div Class="row">
                                @Html.passwordfor(Function(m) m.NewPassword, New With {Key .placeholder = Html.displayNameFor(Function(m) m.NewPassword)})
                                <p>@Html.ValidationMessageFor(Function(m) m.NewPassword)</p>
                            </div>
                            <div Class="row">
                                @Html.passwordfor(Function(m) m.ConfirmPassword, New With {Key .placeholder = Html.displayNameFor(Function(m) m.ConfirmPassword)})
                                <p>@Html.ValidationMessageFor(Function(m) m.ConfirmPassword)</p>
                            </div>
                        </div>

                        @<input type = "submit" value="Save">
                    End using
                    
                </div>
            </div>
        </div>
    </div>
</body>
</html>
