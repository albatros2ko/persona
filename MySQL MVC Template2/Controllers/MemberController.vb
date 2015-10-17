Imports System.Web.Mvc
Imports MongoDB.Bson
Imports MongoDB.Driver.Builders
Imports MongoDB.Driver.Linq

Public Class MemberController
    Inherits Controller

    Private ReadOnly Context As New MemberContext()

    <Authorize>
    Public Function Index(searchString As String, sortOrder As String) As ActionResult
        Dim Members 'local @var to contain query result

        'sorting flags
        ViewBag.FirstNameSort = If(String.IsNullOrEmpty(sortOrder), "first_name_asc", "")
        ViewBag.LastNameSort = If(String.IsNullOrEmpty(sortOrder), "last_name_desc", "")
        ViewBag.HomeAddSort = If(String.IsNullOrEmpty(sortOrder), "home_add_asc", "")

        'evaluate the search string IF any
        If Not String.IsNullOrEmpty(searchString) Then
            Members = Context.Members.FindAll().SetSortOrder(SortBy(Of MemberModel).Ascending(Function(m) m.last_name)).Where(Function(m) m.first_name.ToLower.ContainsAny(searchString.ToLower.Split(" "c)) Or m.last_name.ToLower.ContainsAny(searchString.ToLower.Split(" "c)) Or m.birth_date.ToLower.ContainsAny(searchString.ToLower.Split(" "c)) Or m.home_address.ToLower.ContainsAny(searchString.ToLower.Split(" "c)) Or m.contact_number.ToLower.ContainsAny(searchString.ToLower.Split(" "c)))
            Return View(Members)
        End If

        'set sort order of members list by flag
        Select Case (sortOrder)
            Case "first_name_desc"
                Members = Context.Members.FindAll().SetSortOrder(SortBy(Of MemberModel).Descending(Function(m) m.first_name))
            Case "last_name_desc"
                Members = Context.Members.FindAll().SetSortOrder(SortBy(Of MemberModel).Descending(Function(m) m.last_name))
            Case "home_add_desc"
                Members = Context.Members.FindAll().SetSortOrder(SortBy(Of MemberModel).Descending(Function(m) m.home_address))
            Case Else
                Members = Context.Members.FindAll().SetSortOrder(SortBy(Of MemberModel).Descending(Function(m) m.first_name))
        End Select

        Return View(Members)
    End Function

    <Authorize>
    Public Function Create() As ActionResult
        Return View()
    End Function

    <HttpPost>
    Public Function Create(_Member As MemberModel) As ActionResult
        If ModelState.IsValid Then
            ' generate random 6-digit string
            Dim generator As Random = New Random()
            Dim r As String = generator.Next(0, 100000).ToString("D5")

            _Member.member_id = r
            If _Member.sponsor_id Is Nothing Then
                _Member.sponsor_id = "00000"
            End If
            Context.Members.Insert(_Member)
            Return RedirectToAction("Index")
        End If

        Return View()
    End Function

    Public Function Edit(Id As String) As ActionResult
        If Not User.IsInRole("master") Then
            Return RedirectToAction("Unauthorized", "Account")
        Else
            If String.IsNullOrEmpty(Id) Then
                Return RedirectToAction("Index")
            End If

            Dim Member = Context.Members.FindOneById(New ObjectId(Id))
            Return View(Member)
        End If
    End Function

    <HttpPost>
    Public Function Edit(_Member As MemberModel) As ActionResult
        If ModelState.IsValid Then
            Context.Members.Save(_Member)
            Return RedirectToAction("Index")
        End If

        Return View()
    End Function

    Public Function Details(Id As String) As ActionResult
        If String.IsNullOrEmpty(Id) Then
            Return RedirectToAction("Index")
        End If

        Dim Member = Context.Members.FindOneById(New ObjectId(Id))
        Dim Sponsor

        If Not Member.sponsor_id = "00000" Then
            Sponsor = Context.Members.FindOne(Query.EQ("member_id", Member.sponsor_id))

            If Not Sponsor Is Nothing Then
                ViewData("SponsoredBy") = "Sponsored by " & Sponsor.first_name & " " & Sponsor.last_name
            Else
                Member.sponsor_id = "00000"
            End If
        Else
            ViewData("SponsoredBy") = "none"
        End If

        Member.beneficiaries = Context.GetBeneficiaries(Member) ' retrieve all beneficiaries under selected member record
        Member.sponsored_members = Context.GetSponsoredMembers(Member) ' retrieve all sponsored members under selected member record
        Return View(Member)
    End Function

    <HttpGet>
    Public Function Delete(Id As String) As ActionResult
        If Not User.IsInRole("master") Then
            Return RedirectToAction("Unauthorized", "Account")
        Else
            If String.IsNullOrEmpty(Id) Then
                Return RedirectToAction("Index")
            End If

            Dim rental = Context.Members.FindOneById(New ObjectId(Id))
            Return View(rental)
        End If
    End Function

    <HttpPost, ActionName("Delete")>
    Public Function DeleteConfirmed(Id As String) As ActionResult
        Dim rental = Context.Members.Remove(Query.EQ("_id", New ObjectId(Id)))

        Return RedirectToAction("Index")
    End Function
End Class