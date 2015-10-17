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
    <title>Details</title>
</head>
<body>
    <div class="container">
        <div class="printableArea">
            <h3>@Html.displayfor(Function(model) model.first_name) @Html.displayfor(Function(model) model.last_name)</h3>
            @If Not ViewData("SponsoredBy") = "none" Then
                @<h6>@ViewData("SponsoredBy")</h6>
            End If
            <hr />
            <div Class="row">
                <div Class="five columns">
                    <b> Birth Date</b>
                    <p>@Html.displayfor(Function(model) model.birth_date)</p>
                </div>
                <div class="five columns">
                    <b>Home Address</b>
                    <p>@Html.displayfor(Function(model) model.home_address)</p>

                    <b>Contact No. #</b>
                    <p>@Html.displayfor(Function(model) model.contact_number)</p>
                </div>
            </div>
            <hr />
            <div class="row">
                @If Not Model.sponsored_members Is Nothing Then
                    @<label for="sponsored"> Sponsored Members</label>
                    @<table id="sponsored">
                        <thead>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Birth Date</th>
                        <th>Home Address</th>
                        <th>Contact No. #</th>
                        </thead>
                        <tbody>
                            @For Each item In Model.sponsored_members
                                @<tr>
                                    <td>@Html.displayfor(Function(modelitem) item.first_name)</td>
                                    <td>@Html.displayfor(Function(modelitem) item.last_name)</td>
                                    <td>@Html.displayfor(Function(modelitem) item.birth_date)</td>
                                    <td>@Html.displayfor(Function(modelitem) item.home_address)</td>
                                    <td>@Html.displayfor(Function(modelitem) item.contact_number)</td>
                                </tr>
                            Next
                        </tbody>
                    </table>
                End If

                <br />

                @If Not Model.beneficiaries Is Nothing Then
                    @<label for="beneficiaries"> Beneficiaries</label>
                    @<table id="beneficiaries">
                        <thead>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Contact No. #</th>
                        </thead>
                        <tbody>
                            @For Each item In Model.beneficiaries
                                @<tr>
                                    <td>@Html.displayfor(Function(modelitem) item.first_name)</td>
                                    <td>@Html.displayfor(Function(modelitem) item.last_name)</td>
                                    <td>@Html.displayfor(Function(modelitem) item.contact_number)</td>
                                </tr>
                            Next
                        </tbody>
                    </table>
                End If
            </div>
        </div>
    </div>
</body>
</html>
