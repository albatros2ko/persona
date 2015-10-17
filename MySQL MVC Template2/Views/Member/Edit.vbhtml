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
                    <h5>Update Member @Html.displayfor(Function(m) m.member_id) Record</h5>
                    @Using Html.BeginForm()
                        @Html.ValidationSummary(True, "Update of Member's record was unsuccessful. Please correct the errors and try again.")
                        @<div Class="input">
                             <div Class="row" style="display: none">
                                 @Html.TextBoxfor(Function(m) m.member_id, New With {Key .text = Html.displayfor(Function(m) m.member_id)})
                                 <p>@Html.ValidationMessageFor(Function(m) m.member_id)</p>
                             </div>
                             <div Class="row">
                                 @Html.TextBoxFor(Function(m) m.sponsor_id, New With {Key .text = Html.DisplayFor(Function(m) m.sponsor_id), Key .placeholder = "Sponsor's Member ID", Key .onblur = "resetSponsorId(this)"})
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
                                 <p>@Html.ValidationMessageFor(Function(m) m.birth_Date)</p>
                             </div>
                            <div Class="row">
                                @Html.TextBoxfor(Function(m) m.home_address, New With {Key .placeholder = "Home Address"})
                                <p>@Html.ValidationMessageFor(Function(m) m.home_address)</p>
                            </div>
                            <div Class="row">
                                @Html.TextBoxfor(Function(m) m.contact_number, New With {Key .name = "contact_number", Key .placeholder = "Contact No.#", Key .onkeydown = "validateCN(this)"})
                                <p>@Html.ValidationMessageFor(Function(m) m.contact_number)</p>
                            </div>
                        </div>

                        @<input name="submit" type="submit" value="Save">
                    End using

                    <div class="row">
                        <a href=@Url.Action("Index", "Beneficiary", New With {Key .member_id = Model.member_id})>
                            <button>Manage Beneficiary</button>
                        </a>
                    </div>

                    <a href=@Url.Action("Index", "Member")>
                        <button>Back to List</button>
                    </a>
                </div>
            </div>
        </div>

    </div>

    <script>

        function resetSponsorId(field) {
            if (field.value == "") {
                field.value = "00000"
            }
        }

        function validateCN(field) {
            var btn_submit = document.getElementsByName("submit");
            var re = /^\d+$/;
            if (re.test(field.value) == true) {
                btn_submit.disabled = false
            } else {
                btn_submit.disabled = true
            }
        }
    </script>
</body>
</html>
