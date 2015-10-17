Public Module StringExtension
    Sub New()
    End Sub
    <Runtime.CompilerServices.Extension>
    Public Function ContainsAny(str As String, searchTerms As IEnumerable(Of String)) As Boolean
        Return searchTerms.Any(Function(searchTerm) str.ToLower().Contains(searchTerm.ToLower()))
    End Function

    <Runtime.CompilerServices.Extension>
    Public Function ContainsAll(str As String, searchTerms As IEnumerable(Of String)) As Boolean
        Return searchTerms.All(Function(searchTerm) str.ToLower().Contains(searchTerm.ToLower()))
    End Function
End Module