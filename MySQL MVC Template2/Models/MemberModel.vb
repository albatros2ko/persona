Imports System.ComponentModel.DataAnnotations
Imports MongoDB.Bson
Imports MongoDB.Bson.Serialization.Attributes
Imports MySQL_MVC_Template2

Public Class MemberModel
    <BsonRepresentation(BsonType.ObjectId)>
    Public Property Id As String

    <RegularExpression("^\d+$", ErrorMessage:="Must be a numeric ID")>
    Public Property member_id As String ' must be unique to every member's record

    <RegularExpression("^\d+$", ErrorMessage:="Must be a numeric ID")>
    Public Property sponsor_id As String ' is not required; must contain the sponsor's member_id

    <DataType(DataType.Text)>
    <Required>
    Public Property first_name As String

    <DataType(DataType.Text)>
    <Required>
    Public Property last_name As String

    ' perhaphs it would be nice to abstract the regex below
    <RegularExpression("^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$", ErrorMessage:="Invalid Date format. Valid Date Format DD/MM/YYYY")>
    <Required>
    Public Property birth_date As String

    <DataType(DataType.Text)>
    <Required>
    Public Property home_address As String

    <RegularExpression("^\d+$", ErrorMessage:="Must be a valid telephone/mobile number")>
    <Required>
    Public Property contact_number As String

    Public Property beneficiaries As List(Of BeneficiaryModel)

    Public Property sponsored_members As List(Of MemberModel)
End Class

Public Class BeneficiaryModel
    <BsonRepresentation(BsonType.ObjectId)>
    Public Property Id As String

    Public Property member_id As String ' should resolve to the member's id to which the beneficiary is linked to

    <DataType(DataType.Text)>
    <Required>
    Public Property first_name As String

    <DataType(DataType.Text)>
    <Required>
    Public Property last_name As String

    <RegularExpression("^\d+$", ErrorMessage:="Must be a valid telephone/mobile number")>
    <Required>
    Public Property contact_number As String
End Class
