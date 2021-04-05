Imports System.Data
Imports System.Net
Imports System.IO
Imports dbOp
Partial Class _sms
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' Session("eid") = "9383"


            If Session("eid") Is Nothing Then

                Response.Redirect("login.aspx?redirectafterlogin=Default.aspx")
            End If
            If Not Page.IsPostBack Then
                txtSMS.Text = ""


            End If
        Catch e1 As Exception
            Response.Write("<div id='bottomline'>" & e1.Message & "</div>")
        End Try
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Exit Sub
        Dim q = ""
        Dim subject = ""
        Dim msg = ""
        If rblSMS.SelectedValue = "Pledged" Then
            q = "select eid, email, cellphone, name, department,city as location , strftime('%d.%m.%Y %H:%M:%S',emp_dt DATETIME(last_updated, '+330 minutes')) as 'Pledged On' from cert c, employee e where c.eid = e.empno and last_updated > '2017-12-08'  order by last_updated desc limit 3"
        ElseIf rblSMS.SelectedValue = "Thanks" Then
            q = "select eid,email, '' as d,  name from cert where 1 "
            subject = "Thanks Ms/Mr "
            msg = "<p><strong>Dear Team</strong></p><p>Thanks for taking part in online security Pledge through Single Sign On&nbsp;(SSO). <strong>Total 6790 Employees</strong> took the pledge.</p><p>During the process, you have created your SSO ID and password. If you want to change your SSO Password then you can do it here&nbsp;<a href='http://10.0.8.68/ccAuth/Authenticate/changepassword'>http://10.0.8.68/ccAuth/Authenticate/changepassword</a>&nbsp;.You might be having your old password in mobile/email received during registration.</p><p>&nbsp;</p><p><strong>Do you know what is&nbsp;Single Sign On&nbsp;(SSO):</strong> It's the initiative of IT to provide users a single user ID &amp; Password for many non-SAP applications thus avoiding multiple id and password for each applications. Id and Password which you used during online pledge can also be used in Transit camp booking, CC Intranet, Emart, PP&amp;M Site, Shramshakti Award, JV OS Performance System, E8 &amp; above appraisal,Supervisor&nbsp;&amp; Workmen appraisal System and many more application which will be integrated to&nbsp;SSO in future.</p><p>Regards,</p><p>&nbsp;</p><p>&nbsp;</p> <p>System generated email. Please do not reply.</p>"
        Else
            q = "select empno as eid , email, cellphone, firstname, department,city as location  from  employee where  not empno in (select distinct eid from cert) and not (lastname = 'CMD' or lastname = 'E9' or lastname = 'E8'  )  order by empno desc   "
            subject = "Final Call: Online Pledge window is closing Ms/Mr "
            msg = "<p>Dear Team</p><p>Online security pledge window is about to close in a Day. <strong>5000+ employees</strong> have taken pledge. To show your security concern towards organization, <strong>you may easily take pledge even on your mobile</strong> by clicking or typing <a href='https://cc.ntpc.co.in/pledge'>https://cc.ntpc.co.in/pledge</a></p><p>&nbsp;</p><p>Register to get the password, or use forgot password. You may also take help of Site IT to get pledge certificate.</p><p>Regards,</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>System generated email. Please do not reply.</p>"
        End If
        Dim mydt = dbOp.getDBTable(q)
        Dim log = ""
        For Each r In mydt.Rows
            Dim mailto = r(1)
            Dim finalsubject = subject & r(3) & " for taking online pledge using SSO"
            log = log & "<br/>" & r(0) & SendEmail("CCIT-NOREPLY@ntpc.co.in", mailto, "", "", finalsubject, msg, "", "", "", "")
            executeDB("insert into smslog (eid, msg, rcpt, last_updated ) values (0 , '" & finalsubject.Replace("'", "") & " " & msg.Replace("'", "") & " " & Now.ToString() & " - " & Request.UserHostAddress & "','" & mailto & "', current_timestamp)", "logdb")
        Next
        divMsg.InnerHtml = log

    End Sub

    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        Exit Sub
        Try
            Dim q = ""
            Dim subject = ""
            Dim msg = ""
            If rblSMS.SelectedValue = "Pledged" Then
                q = "select eid, email, cellphone, name, department,city as location , strftime('%d.%m.%Y %H:%M:%S',emp_dt DATETIME(last_updated, '+330 minutes')) as 'Pledged On' from cert c, employee e where c.eid = e.empno and last_updated > '2017-12-08'  order by last_updated desc limit 3"

            Else
                q = "select empno as eid , email, cellphone, firstname, department,city as location  from  employee where  not empno in (select distinct eid from cert) and lastname = 'E7'  order by empno desc  "
                subject = "Reminder: Action Required to take Online Pledge Ms/Mr "
                msg = " 5000 Employees have taken Online Security Pledge and you are being left out." & vbCrLf & "It's very easy. In mobile Just open https://cc.ntpc.co.in/pledge " & vbCrLf & " and register to get password, or use forgot password."
            End If
            Dim mydt = dbOp.getDBTable(q)
            Dim log = ""
            For Each r In mydt.Rows
                Dim mob50 = r(2)
                Dim finalmsg = "Dear " & longToShort(r(3)) & vbCrLf & msg
                log = log & "<br/>" & r(0) & JustSendSMS(mob50, finalmsg)
                executeDB("insert into smslog (eid, msg, rcpt, last_updated ) values (0 , '" & finalmsg.Replace("'", "") & " " & Now.ToString() & " - " & Request.UserHostAddress & "','" & mob50 & "', current_timestamp)", "logdb")
            Next
            divMsg.InnerHtml = log
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message
        End Try
    End Sub
    Function longToShort(longform As String) As String
        Try
            '  If longform.Length < 16 Then Return longform
            Dim a() = longform.Split(" ")
            Dim shortname = ""
            Dim i = 1
            Dim surname = ""
            For Each part In a
                If i < a.Length Then
                    shortname = shortname & Left(part, 1) & ". "
                Else
                    shortname = part
                End If
                i = i + 1
            Next
            Return shortname
        Catch ex As Exception
            Return longform
        End Try
    End Function
    Private Sub rblSMS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblSMS.SelectedIndexChanged

        Dim q = ""
        If rblSMS.SelectedValue = "Pledged" Then
            q = "select eid, email, cellphone, name, department,city as location ,DATETIME(last_updated, '+330 minutes') as 'Pledged On' from cert c, employee e where c.eid = e.empno and last_updated > '2017-12-08'  order by last_updated desc"
        ElseIf rblSMS.SelectedValue = "Thanks" Then
            q = "select eid,email, '' as d,  name from cert where 1"
        Else
            q = "select empno as eid , email, cellphone, firstname, department,city as location  from  employee where  not empno in (select distinct eid from cert) and not (lastname = 'CMD' or lastname = 'E9' or lastname = 'E8'  ) order by empno desc "

        End If
        Dim mydt = dbOp.getDBTable(q)
        gvReport.Caption = mydt.Rows.Count
        gvReport.DataSource = mydt
        gvReport.DataBind()
    End Sub

    '

End Class
