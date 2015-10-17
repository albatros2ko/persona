@ModelType MySQL_MVC_Template2.MemberModel

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
    <title>Delete</title>
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
                        <li><a class="nav-active" href="/Member/Index">MANAGE MEMBERS</a></li>
                        <li><a href="/Home/Settings">SETTINGS</a></li>
                        <li><a href="/Account/Register">REGISTER</a></li>
                        <li><a href="/Account/SignOut">LOGOUT</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div style="margin-top: 3em;">
            <h5>Are you sure you want to delete Member @Html.displayfor(Function(model) model.member_id) record?</h5>
            <div>
                <p>Member's details</p>
                <hr />
                <table>
                    <thead>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Birth Data</th>
                        <th>Home Address</th>
                        <th>Contact No.#</th>
                    </thead>
                    <tbody>
                        <td>@Html.displayfor(Function(model) model.first_name)</td>
                        <td>@Html.displayfor(Function(model) model.last_name)</td>
                        <td>@Html.displayfor(Function(model) model.birth_date)</td>
                        <td>@Html.displayfor(Function(model) model.home_address)</td>
                        <td>@Html.displayfor(Function(model) model.contact_number)</td>
                    </tbody>
                </table>

                <div class="row">
                    <a href=@Url.Action("Index", "Member")>
                        <button>Back to List</button>
                    </a>

                    @Using (Html.BeginForm())
                        @Html.AntiForgeryToken()


                        @<input type="submit" value="Delete" Class="btn btn-default" />

                    End Using
                </div>

            </div>
        </div>
    </div>
</body>
</html>
