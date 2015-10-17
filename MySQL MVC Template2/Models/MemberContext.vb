Imports MongoDB.Bson
Imports MongoDB.Driver
Public Class MemberContext
    Public connectionString As String = "mongodb://localhost:27017"
    Public databaseName As String = "persona-db"

    Public Database As MongoDatabase

    Public Sub New()
        Dim client = New MongoClient(connectionString)
        Dim server = client.GetServer()

        Database = server.GetDatabase(databaseName)
    End Sub

    Public ReadOnly Property Members() As MongoCollection(Of MemberModel)
        Get
            Dim _Members = Database.GetCollection(Of MemberModel)("members")

            Return _Members
        End Get
    End Property

    Public ReadOnly Property Beneficiaries() As MongoCollection(Of BeneficiaryModel)
        Get
            Dim _Beneficiary = Database.GetCollection(Of BeneficiaryModel)("beneficiaries")

            Return _Beneficiary
        End Get
    End Property

    Public Function GetBeneficiaries(Member As MemberModel) As List(Of BeneficiaryModel)
        Dim _beneficiaries = Beneficiaries.FindAllAs(Of BeneficiaryModel).Where(Function(b) b.member_id.Equals(Member.member_id))

        Return _beneficiaries.ToList
    End Function
    Public Function GetSponsoredMembers(Member As MemberModel)
        Dim _sponsored = Members.FindAllAs(Of MemberModel).Where(Function(s) s.sponsor_id.Equals(Member.member_id))
        If Not _sponsored Is Nothing Then
            Return _sponsored.ToList
        Else
            Return False
        End If
    End Function
End Class
