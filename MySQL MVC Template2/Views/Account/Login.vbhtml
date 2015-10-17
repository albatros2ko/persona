@ModelType MySQL_MVC_Template2.LoginModel

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
    <title>PERSONA | Login</title>
</head>
<body>
    <div class="container">
        <div Class="form-login">
            <center>
                <div Class="row">
                    <div Class="five">
                        <h5> Please log into your account.</h5>
                    </div>
                </div>
                <div Class="row">
                    <div Class="five">
                        @using Html.BeginForm()
                            @Html.ValidationSummary(True)
                            @<div Class="input">
                                <div Class="row">
                                    @Html.TextBoxFor(Function(m) m.UserName, New With {Key .style = "width: 320px", Key .placeholder = Html.DisplayNameFor(Function(m) m.UserName)})
                                    @Html.ValidationMessageFor(Function(m) m.UserName)
                                </div>

                                <div Class="row">
                                    @Html.PasswordFor(Function(m) m.Password, New With {Key .style = "width: 320px", Key .placeholder = Html.DisplayNameFor(Function(m) m.Password)})
                                    @Html.ValidationMessageFor(Function(m) m.Password)
                                </div>
                            </div>

                            @<div Class="row">
                                <input Class="button-primary" type="submit" value="Login" />
                            </div>
                        End Using
                    </div>
                </div>
            </center>
        </div>
    </div>
</body>
</html>
