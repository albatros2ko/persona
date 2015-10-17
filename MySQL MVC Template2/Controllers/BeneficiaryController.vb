Imports System.Web.Mvc
Imports MongoDB.Bson
Imports MongoDB.Driver.Builders
Imports MongoDB.Driver.Linq

Public Class BeneficiaryController
    Inherits Controller

    Private ReadOnly Context As New MemberContext()

    <Authorize>
    Public Function Index(member_id As String, searchString As String, sortOrder As String) As ActionResult
        Dim Beneficiaries 'local @var to contain query result
        ViewData("member_id") = member_id

        'sorting flags
        ViewBag.FirstNameSort = If(String.IsNullOrEmpty(sortOrder), "first_name_asc", "")
        ViewBag.LastNameSort = If(String.IsNullOrEmpty(sortOrder), "last_name_desc", "")

        'evaluate the search string IF any
        If Not String.IsNullOrEmpty(searchString) Then
            Beneficiaries = Context.Beneficiaries.FindAll().SetSortOrder(SortBy(Of BeneficiaryModel).Ascending(Function(m) m.last_name)).Where(Function(m) m.member_id.Equals(member_id) And m.first_name.ToLower.ContainsAny(searchString.ToLower.Split(" "c)) Or m.last_name.ToLower.ContainsAny(searchString.ToLower.Split(" "c)) Or m.contact_number.ToLower.ContainsAny(searchString.ToLower.Split(" "c)))
            Return View(Beneficiaries)
        End If

        'set sort order of Beneficiaries list by flag
        Select Case (sortOrder)
            Case "first_name_desc"
                Beneficiaries = Context.Beneficiaries.FindAll().SetSortOrder(SortBy(Of BeneficiaryModel).Descending(Function(m) m.first_name)).Where(Function(m) m.member_id.Equals(member_id))
            Case "last_name_desc"
                Beneficiaries = Context.Beneficiaries.FindAll().SetSortOrder(SortBy(Of BeneficiaryModel).Descending(Function(m) m.last_name)).Where(Function(m) m.member_id.Equals(member_id))
            Case Else
                Beneficiaries = Context.Beneficiaries.FindAll().SetSortOrder(SortBy(Of BeneficiaryModel).Descending(Function(m) m.first_name)).Where(Function(m) m.member_id.Equals(member_id))
        End Select

        Return View(Beneficiaries)
    End Function

    <Authorize>
    Public Function Create(member_id As String) As ActionResult
        ViewData("member_id") = member_id
        Return View()
    End Function

    <HttpPost>
    Public Function Create(member_id As String, _Beneficiary As BeneficiaryModel) As ActionResult
        If ModelState.IsValid Then
            Context.Beneficiaries.Insert(_Beneficiary)
            Return RedirectToAction("Index", New With {Key .member_id = member_id})
        End If

        Return View()
    End Function

    Public Function Edit(member_id As String, Id As String) As ActionResult
        ViewData("member_id") = member_id
        If Not User.IsInRole("master") Then
            Return RedirectToAction("Unauthorized", "Account")
        Else
            If String.IsNullOrEmpty(Id) Then
                Return RedirectToAction("Index")
            End If

            Dim Beneficiary = Context.Beneficiaries.FindOneById(New ObjectId(Id))
            Return View(Beneficiary)
        End If
    End Function

    <HttpPost>
    Public Function Edit(member_id As String, _Beneficiary As BeneficiaryModel) As ActionResult
        If ModelState.IsValid Then
            Context.Beneficiaries.Save(_Beneficiary)
            Return RedirectToAction("Index", New With {Key .member_id = member_id})
        End If

        Return View()
    End Function

    <HttpGet>
    Public Function Delete(member_id As String, Id As String) As ActionResult
        ViewData("member_id") = member_id
        If Not User.IsInRole("master") Then
            Return RedirectToAction("Unauthorized", "Account")
        Else
            If String.IsNullOrEmpty(Id) Then
                Return RedirectToAction("Index")
            End If

            Dim rental = Context.Beneficiaries.FindOneById(New ObjectId(Id))
            Return View(rental)
        End If
    End Function

    <HttpPost, ActionName("Delete")>
    Public Function DeleteConfirmed(member_id As String, Id As String) As ActionResult
        Dim rental = Context.Beneficiaries.Remove(Query.EQ("_id", New ObjectId(Id)))

        Return RedirectToAction("Index", New With {Key .member_id = member_id})
    End Function
End Class