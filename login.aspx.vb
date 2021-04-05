Imports dbOp
Imports Common
Partial Class login
    Inherits System.Web.UI.Page

    Private Sub login_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Not Request.Params("eid") Is Nothing Then
                Session("eid") = Request.Params("eid")
                Session("empname") = getDBsingle("select firstName from employee where empno = " & Session("eid") & " limit 1")
                Session("Dept") = getDBsingle("select department || ' - ' || city from employee where empno = " & Session("eid") & " limit 1")
                Session("email") = getDBsingle("select email from employee where empno = " & Session("eid") & " limit 1")
                Response.Redirect("Default.aspx")
            End If
            head.InnerHtml = "<spam>NTPC PLEDGE</spam> <br /> Access Denied - 403"

            If Request.Form.Count > 0 Then
                Dim appsecret = "%4gxG0N$RT1" ' "r6wOj9RZ29o" 'sdcg9+Q2jyNP/Az3sqEmjg=="
                '  Dim appsecret = "sdcg9+Q2jyNP/Az3sqEmjg=="
                '  Dim eid = Decrypt(Request.Form("eid"), appsecret)
                Dim eid = Decrypt(Request.Form("EmpId"), appsecret)
                Dim email = Decrypt(Request.Form("EmailId"), appsecret)
                Dim empname = Decrypt(Request.Form("EmpName"), appsecret)
                Dim Dept = Decrypt(Request.Form("Dept"), appsecret)
                Dim Location = Decrypt(Request.Form("Location"), appsecret)
                Dim Mobile = Decrypt(Request.Form("Mobile"), appsecret)

                'lblEid.Text =
                'lblEmail.Text =
                divMsg.InnerHtml = "<p>eid=" & Session("eid") & " Email: " & email & "</p>"
                ''check if non ntpc user, create an eid for it
                If eid.Contains("@") Then
                    eid = getOrGenerateEid(eid)
                End If
                '' Check if eid is authorised for this application
                'If isAuthorised(eid) = False Then
                '    divMsg.InnerHtml = "<p>Your Emp ID No: " & eid & " for Email: " & email & " Emp Name " & empname & " Dept " & Dept & " Location " & Location & " Mobile " & Mobile & " is not authorised to use this application. Contact the administrator to get authorisation. Communicate your Emp ID: " & eid & " on phone to administrator.</p>"
                '    executeDB("insert into login (eid, log, logintime) values (" & eid & " , 'Email " & email & " login.aspx App access not allowed : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                '    Exit Sub
                'End If
                Session("eid") = eid
                Session("empname") = Strings.UCase(empname)
                Session("Dept") = Dept & ", " & Location
                Session("email") = email
                'executeDB("insert into login (eid, log, logintime) values (" & Session("eid") & " , 'Successfull Login Access Granted : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                'executeDB("update m_users set ename = '" & empname & "', dept = '" & Dept & "', email= '" & email.ToLower & "', cell='" & Mobile & "' where eid = " & Session("eid"))
                If Session("redirectafterlogin") Is Nothing Then
                    Response.Redirect("Default.aspx")
                Else
                    Response.Redirect(Session("redirectafterlogin"))
                End If
            End If
        End If
        If Session("eid") Is Nothing Then
            If Not Request.Params("redirectafterlogin") Is Nothing Then
                Session("redirectafterlogin") = Request.Params("redirectafterlogin")
            End If
            ' Response.Redirect("https://cc.ntpc.co.in/sso/Default.aspx?appid=12343212")  ''2017110800017
            Response.Redirect("https://mapp.ntpc.co.in/sso/oAuthntpcs/applogin/2017120500019")
        End If

        If Not Request.Params("logout") Is Nothing Then
            Session("eid") = ""
            Session.Clear()
            Session.Abandon()
            divMsg.InnerHtml = "<p>Logout Successfull. <a href=default.aspx > Click here to return</a></p>"
        End If
    End Sub
End Class
