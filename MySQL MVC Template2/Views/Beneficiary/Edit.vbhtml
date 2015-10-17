@ModelType MySQL_MVC_Template2.BeneficiaryModel

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
                    <h5>Update Beneficiary of Member @Html.displayfor(Function(m) m.member_id) Record</h5>
                    @Using Html.BeginForm()
                        @Html.ValidationSummary(True, "Update of Beneficiary's record was unsuccessful. Please correct the errors and try again.")
                        @<div Class="input">
                            <div Class="row" style="display: none">
                                @Html.TextBoxfor(Function(m) m.member_id, New With {Key .text = Html.displayfor(Function(m) m.member_id)})
                                <p>@Html.ValidationMessageFor(Function(m) m.member_id)</p>
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
                                @Html.TextBoxfor(Function(m) m.contact_number, New With {Key .placeholder = "Contact No.#"})
                                <p>@Html.ValidationMessageFor(Function(m) m.contact_number)</p>
                            </div>
                        </div>

                        @<input type="submit" value="Save">
                    End using

                    <a href=@Url.Action("Index", "Beneficiary", New With {Key .member_id = Html.displayfor(Function(m) m.member_id)})>
                        <button>Back to List</button>
                    </a>
                </div>
            </div>
        </div>

    </div>
</body>
</html>
