Imports System.Data
Imports System.Net
Imports System.IO
Partial Class _lock
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' Session("eid") = "9383"



            If Not Page.IsPostBack Then

                dbOp.executeDB("insert into login (eid, log, logintime) values (0, 'Lock.aspx Page Access : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")


            End If
        Catch e1 As Exception
            Response.Write("<div id='bottomline'>" & e1.Message & "</div>")
        End Try
    End Sub

    '

End Class
