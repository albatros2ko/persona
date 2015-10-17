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
    <title>Create</title>
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

        <div class="account-settings">
            <div class="row" style="margin-top: 3em;">
                <div class="seven columns">
                    <h5>Add Member</h5>
                    @Using Html.BeginForm()
                        @Html.ValidationSummary(True, "Addition of Member's record was unsuccessful. Please correct the errors and try again.")
                        @<div Class="input">
                             <div Class="row">
                                 @Html.TextBoxfor(Function(m) m.sponsor_id, New With {Key .placeholder = "Sponsor's Member ID"})
                                 <p>@Html.ValidationMessageFor(Function(m) m.sponsor_id)</p>
                             </div>
                            <div Class="row">
                                @Html.TextBoxfor(Function(m) m.first_name, New With {Key .placeholder = "First Name"})
                                <p>@Html.ValidationMessageFor(Function(m) m.first_name)</p>
                            </div>
                            <div Class="row">
                                @Html.TextBoxfor(Function(m) m.last_name, New With {Key .placeholder = "Last Name"})
                                <p>@Html.ValidationMessageFor(Function(m) m.last_name)</p>
                            </div>
                             <div Class="row">
                                 @Html.TextBoxfor(Function(m) m.birth_date, New With {Key .placeholder = "Birth Date (DD/MM/YYYY)"})
                                 <p>@Html.ValidationMessageFor(Function(m) m.birth_date)</p>
                             </div>
                            <div Class="row">
                                @Html.TextBoxfor(Function(m) m.home_address, New With {Key .placeholder = "Home Address"})
                                <p>@Html.ValidationMessageFor(Function(m) m.home_address)</p>
                            </div>
                             <div Class="row">
                                 @Html.TextBoxfor(Function(m) m.contact_number, New With {Key .placeholder = "Contact No.#"})
                                 <p>@Html.ValidationMessageFor(Function(m) m.contact_number)</p>
                             </div>
                        </div>

                        @<input type="submit" value="Add Member">
                    End using

                    <a href=@Url.Action("Index", "Member")>
                        <button>Back to List</button>
                    </a>
                </div>
            </div>
        </div>

    </div>
</body>
</html>
