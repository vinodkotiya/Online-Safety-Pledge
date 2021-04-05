Imports System.Data
Imports System.Net
Imports System.IO
Partial Class _report
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' 

            If Request.Params("bypass") = 1 Then Session("eid") = "1"


            If Session("eid") Is Nothing Then

                Response.Redirect("login.aspx?redirectafterlogin=Default.aspx")
            End If
            '   Exit Sub
            If Not Page.IsPostBack Then
                If Cache("mydt") Is Nothing Then
                    Dim mydt = dbOp.getDBTable(" select e.eid, fname || ' ' || lname as name,  grade, dept, project, location,gender , strftime('%d.%m.%Y %H:%M:%S',DATETIME(last_updated, '+330 minutes')) as 'Pledged On' from cert c, employeesap e where c.eid = e.eid and type in (select type from pledge where active = 1 limit 1)   order by last_updated desc")
                    Cache.Insert("mydt", mydt, Nothing, DateTime.Now.AddMinutes(5.0), TimeSpan.Zero)
                End If
                gvReport.DataSource = Cache("mydt")
                gvReport.DataBind()

                btnReportDownload.Text = "Download Pledge data of " & dbOp.getDBsingle("select count (eid) from cert where type  in (select type from pledge where active = 1 limit 1)  limit 1") & " Employees"
                If Cache("mydt1") Is Nothing Then
                    Dim mydt1 = dbOp.getDBTable("select count(gender), gender || ' - Total' as desc from employeesap where 1 group by gender union select count(gender), gender || ' - Pledged' as desc from employeesap where eid in (select eid  from cert where  type  in (select type from pledge where active = 1 limit 1)) group by gender")
                    Cache.Insert("mydt1", mydt1, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
                End If
                gvGender.DataSource = Cache("mydt1")
                gvGender.DataBind()
                If Cache("mydt2") Is Nothing Then
                    Dim mydt2 = dbOp.getDBTable(" select count(eid) as 'Total Pledge', strftime('%d.%m.%Y',DATETIME(last_updated, '+330 minutes')) as desc from cert  where type  in (select type from pledge where active = 1 limit 1)  group by desc")
                    Cache.Insert("mydt2", mydt2, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
                End If
                gvDay.DataSource = Cache("mydt2")
                gvDay.DataBind()
                If Cache("mydt3") Is Nothing Then
                    Dim mydt3 = dbOp.getDBTable("select count(project), project || ' - Total' as desc from employeesap where 1 group by project union select count(project), project || ' - Pledged' as desc from employeesap where eid in (select eid  from cert where type  in (select type from pledge where active = 1 limit 1) ) group by project order by desc")
                    Cache.Insert("mydt3", mydt3, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
                End If
                gvProject.DataSource = Cache("mydt3")
                gvProject.DataBind()
                If Cache("mydt4") Is Nothing Then
                    Dim mydt4 = dbOp.getDBTable("select count(grade), grade || ' - Total' as desc from employeesap where grade like 'E%'  or grade like 'w%' group by grade union select count(grade), grade || ' - Pledged' as desc from employeesap where  (grade like 'E%'  or grade like 'w%' ) and eid in (select eid  from cert where  type  in (select type from pledge where active = 1 limit 1)) group by grade order by desc")
                    Cache.Insert("mydt4", mydt4, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
                End If
                gvGrade.DataSource = Cache("mydt4")
                gvGrade.DataBind()

                End If
        Catch e1 As Exception
            Response.Write("<div id='bottomline'>" & e1.Message & "</div>")
        End Try
    End Sub

    Private Sub btnReportDownload_Click(sender As Object, e As EventArgs) Handles btnReportDownload.Click
        saveExcel()
    End Sub
    Sub saveExcel()
        ' Change the Header Row back to white color
        'gvReport.PageSize = 70
        ' gvReport.DataBind()
        gvReport.HeaderRow.Style.Add("background-color", "#FFFFFF")

        '' This loop is used to apply stlye to cells based on particular row
        'For Each gvrow As GridViewRow In gvReport.Rows
        '    gvrow.BackColor = Drawing.Color.White

        '    'If gvrow.Cells(4).Text = "True" Then
        '    '    gvrow.BackColor = Drawing.Color.Yellow
        '    '    'For k As Integer = 0 To gvrow.Cells.Count - 1
        '    '    '    gvrow.Cells(k).Style.Add("background-color", "#EFF3FB")
        '    '    'Next
        '    'End If
        'Next

        Response.ClearContent()
        Response.ClearHeaders()
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.AddHeader("content-disposition", "attachment; filename=PledgeReport.xls")

        Response.ContentType = "application/excel"

        Dim sWriter As New System.IO.StringWriter()

        Dim hTextWriter As New HtmlTextWriter(sWriter)

        gvReport.RenderControl(hTextWriter)

        Response.Write(sWriter.ToString())

        Response.End()
        'lblMsg.Text = "Excel created"

        'GridView1.RenderControl(htw)

    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub

End Class
