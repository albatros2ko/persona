@ModelType IEnumerable(Of MySQL_MVC_Template2.MemberModel)

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
    <title>Index</title>
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

        <div class="row" style="margin-top: 3em;">
            <div class="member-list eleven columns" style="position: relative; float: left;">

            @Using Html.beginform()
                @<div class="row">
                     <h5>List Of Members</h5>
                     <a href=@Url.Action("Create", "Member")>
                         <input type="button" value="Add Member" />
                     </a>
                </div>

                @<div Class="row">
                    <div Class="member-list-options">
                        <form style="float: right">
                            @Html.TextBox("searchString")
                            <input type="submit" value="Search" />
                        </form>
                    </div>
                </div>

                @<Table Class="u-full-width">
                    <thead>
                        <tr>
                            <th>Member ID</th>
                            <th>@Html.actionlink("First Name", "Index", New With {Key .sortOrder = viewbag.FirstNameSort})</th>
                            <th>@Html.actionlink("Last Name", "Index", New With {Key .sortOrder = viewbag.LastNameSort})</th>
                            <th>Birth Date</th>
                            <th>@Html.actionlink("Home Address", "Index", New With {Key .sortOrder = viewbag.HomeAddSort})</th>
                            <th>Contact No.#</th>
                        </tr>
                    </thead>
                    <tbody>
                        @for Each item In Model
                            @<tr>
                                <td>@Html.displayfor(Function(modelitem) item.member_id)</td>
                                <td>@Html.displayfor(Function(modelitem) item.first_name)</td>
                                <td>@Html.displayfor(Function(modelitem) item.last_name)</td>
                                <td>@Html.displayfor(Function(modelitem) item.birth_date)</td>
                                <td>@Html.displayfor(Function(modelitem) item.home_address)</td>
                                <td>@Html.displayfor(Function(modelitem) item.contact_number)</td>
                                <td>@Html.ActionLink("Edit", "Edit", New With {Key .id = item.Id})
                                    @Html.actionlink("Details", "Details", New With {Key .id = item.Id})
                                    @Html.actionlink("Delete", "Delete", New With {Key .id = item.Id})
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            End Using
            </div>
        </div>
    </div>
</body>
</html>
