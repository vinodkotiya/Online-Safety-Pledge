Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Web.Script.Serialization
Imports System.Data.SQLite
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://vinodkotiya.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class vinservice
    Inherits System.Web.Services.WebService

    <WebMethod()> _
     <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod(Description:="say hello with name")> _
   <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function sayhelloname(ByVal name As String) As String
        Return "from asp.net web service Hello " + name
    End Function
    <WebMethod(Description:="say hello with name1")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function updatefileCount(ByVal filename As String) As String
        filename = Server.UrlDecode(filename)
        Dim q = "update upload set downloads = downloads+1 , lastview=current_timestamp where filename='" + filename + "'" '"
        Try
            Dim r = dbOp.getDBsingle("update upload set downloads = downloads+1 , lastview=current_timestamp where filename='" + filename + "' ")
            Return "from asp.net web service Hello " + filename + r + q
        Catch e As Exception
            Return "Error: from asp.net web service Hello " + e.Message + q
        End Try

    End Function

End Class