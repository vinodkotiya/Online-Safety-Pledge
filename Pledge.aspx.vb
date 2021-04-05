Imports System.Data
Imports System.Net
Imports System.IO
Imports dbOp
Partial Class _Pledge
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' Session("eid") = "9383"

            If Request.Params("lang") = "download" Then
                Dim url = ""
                Dim msg = ""
                Dim mydt = dbOp.getDBTable("select distinct eid from emphindi where 1")
                For Each r In mydt.Rows
                    Try
                        url = "http://10.0.236.26:8090/bday/photos/" + r(0).ToString.PadLeft(8, "0") + ".jpg"
                        Dim file_name As String = Server.MapPath("./upload/pic/") + r(0).ToString.PadLeft(8, "0") + ".jpg"

                        save_file_from_url(file_name, url)

                        msg = msg & r(0) & " The file has been saved at: " & file_name & "<br/>"
                    Catch ex As Exception
                        msg = msg & ex.Message & url & "<br/>"
                    End Try

                Next
                divPledge.InnerHtml = msg
                Exit Sub
            End If
            If Session("eid") Is Nothing Then

                Response.Redirect("login.aspx?redirectafterlogin=Default.aspx")
            End If
            If Not Page.IsPostBack Then
                '  Dim PICurl = "http://10.0.236.26:8090/bday/photos/" + Session("eid").ToString.PadLeft(8, "0") + ".jpg"
                Dim PICurl = "upload/pic/" + Session("eid").ToString.PadLeft(8, "0") + ".jpg"
                litPic.Text = "<img src='" & PICurl & "' alt=''  onerror=" & Chr(34) & "this.src='images/user.jpg';" & Chr(34) & " width='126px' height='150px' />"
                litName.Text = Session("empname")
                litDesignation.Text = Strings.UCase(Session("Dept"))

                If Cache("pHindi") Is Nothing Then
                    Dim pHindi = getDBsingle("select phindi from pledge where active = 1 limit 1")
                    Cache.Insert("pHindi", pHindi, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If

                If Cache("pEng") Is Nothing Then
                    Dim pEng = getDBsingle("select pEng from pledge where active = 1 limit 1")
                    Cache.Insert("pEng", pEng, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If
                Dim content = Cache("pEng").ToString
                If content.Contains("png") Then content = "<img src='upload/" & content & "' />"
                divPledge.InnerHtml = content ' "Pledge: <br/>I do hereby solemnly pledge that I shall continuously strive to be sensitive to the security needs of our organization and that I shall contribute my best to ensure a fool-proof and fail-proof security system. I also promise that I shall remain vigilant and adhere to all the security norms and guidelines issued by the authorities in this regard. Through our collective efforts, we shall create a secured work environment and bring pride to our organization. We also solemnly affirm to work for sensitizing the associated agencies, family members and friends regarding security."
                If Cache("btnindi") Is Nothing Then
                    Dim btnindi = getDBsingle("select btnhindi from pledge where active = 1 limit 1")
                    Cache.Insert("btnindi", btnindi, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If
                If Cache("btneng") Is Nothing Then
                    Dim btneng = getDBsingle("select btneng from pledge where active = 1 limit 1")
                    Cache.Insert("btneng", btneng, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If
                btnPledge.Text = Cache("btneng").ToString
                lbLang.Text = "हिंदी में प्रतिज्ञा "
                lbLang.PostBackUrl = "pledge.aspx?lang=hindi"
                If Request.Params("lang") = "hindi" Then
                    litName.Text = getHindiName(Session("eid"), Session("empname"))
                    lbLang.Text = "Read in English"
                    lbLang.PostBackUrl = "pledge.aspx?lang=english"
                    btnPledge.Text = Cache("btnindi").ToString ' "मैं  शपथ लेता हूँ ! प्रमाण पत्र देखें"
                    content = Cache("pHindi").ToString
                    If content.Contains("png") Then content = "<img src='upload/" & content & "' />"
                    divPledge.InnerHtml = content ' "प्रतिज्ञा: <br/>मैं सत्यनिष्ठा से यह प्रतिज्ञा लेता हूँ कि मैं सदैव अपने संगठन की सुरक्षा आवश्यकताओं के लिए संवेदनशील रहने का प्रयत्न करूंगा और मैं अचूक एवं सुदृढ़ सुरक्षा प्रणाली सुनिश्चित करने के लिए भरसक प्रयास करूंगा । मैं यह भी वचन देता हूँ कि इस संबंध में प्राधिकारियों द्वारा जारी सुरक्षा नियमों और दिशा-निर्देशों के प्रति सतर्क रहूँगा और अनुपालन करूंगा । हम अपने सम्मिलित प्रयासों के माध्यम से सुरक्षित वातावरण बनाकर अपने संगठन को गौरवान्वित करेंगे । हम सत्यनिष्ठा से यह भी घोषणा करते हैं कि संबंधित एजेंसियों, पारिवारिक सदस्यों और मित्रों को भी सुरक्षा के संबंध में संवेदनशील करने का कार्य करेंगे ।"
                End If
                'If Cache("menu3") Is Nothing Then
                '    Cache.Insert("menu3", makeappmenu(3), Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                'End If
                'nav.InnerHtml = Cache("menu3").ToString

                ' load_user_pref()
                ' If isAdmin(Session("eid")) Then hfAdmin.Value = 1

                '     executeDB("update hits set view = view+1 where page = 'gen'")
                '   executeDB("insert into login (eid, log, logintime) values (" & Session("eid") & " , 'gen.aspx Page Access : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
            End If
        Catch e1 As Exception
            Response.Write("<div id='bottomline'>" & e1.Message & "</div>")
        End Try
    End Sub
    Function getHindiName(ByVal eid As String, ByVal empname As String) As String
        Try
            Dim hindiname = dbOp.getDBsingle("select fhindi || ' ' || lhindi from emphindi where eid = " & eid & " limit 1 ")
            If hindiname.Contains("Error") Then Return empname
        If System.Text.RegularExpressions.Regex.IsMatch(hindiname, "\d") Then Return empname
        If String.IsNullOrEmpty(hindiname.Trim) Then Return empname
        Return hindiname
        Catch ex As Exception
        Return empname
        End Try
    End Function
    Sub save_file_from_url(file_name As String, url As String)
        Dim content As Byte()
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        Dim response As WebResponse = request.GetResponse()

        Dim stream As Stream = response.GetResponseStream()

        Using br As New BinaryReader(stream)
            content = br.ReadBytes(500000)
            br.Close()
        End Using
        response.Close()

        Dim fs As New FileStream(file_name, FileMode.Create)
        Dim bw As New BinaryWriter(fs)
        Try
            bw.Write(content)
        Finally
            fs.Close()
            bw.Close()
        End Try
    End Sub
    Private Sub btnPledge_Click(sender As Object, e As EventArgs) Handles btnPledge.Click
        If btnPledge.Text.Contains("Pledge") Then
            Response.Redirect("content.aspx?lang=english")
        Else
            Response.Redirect("content.aspx?lang=hindi")
        End If
    End Sub

    Private Sub lbLang_Click(sender As Object, e As EventArgs) Handles lbLang.Click
        Response.Redirect(lbLang.PostBackUrl)
    End Sub
    '

End Class
