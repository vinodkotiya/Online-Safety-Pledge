Imports dbOp
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' Session("eid") = "9383"
            '  Session.Clear()



            '  If Session("eid") Is Nothing Then

            '   Response.Redirect("login.aspx?redirectafterlogin=Default.aspx&dummy=1")
            '  Response.Redirect("lock.aspx?day=" & Now.Day)
            'End If
            '  End If

            executeDB("insert into login (eid, log, logintime) values (" & Session("eid") & " , 'Default.aspx Page Access : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")

            If Not Page.IsPostBack Then
                'Dim PICurl = "http://10.0.236.26:8090/bday/photos/" + Session("eid").ToString.PadLeft(8, "0") + ".jpg"
                If Cache("heading") Is Nothing Then
                    Dim heading = getDBsingle("select heading from pledge where active = 1 limit 1")
                    Cache.Insert("heading", heading, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If

                litPic.Text = Cache("heading").ToString ' "<img src='images/cmd.jpg' alt=''  onerror=" & Chr(34) & "this.src='images/user.jpg';" & Chr(34) & " /><h2>CMD's Message (अध्यक्ष  एवं  प्रबंध  निदेशक  का संदेश)</h2>"
                'litName.Text = Session("empname")
                'litDesignation.Text = Session("Dept")
                'If Cache("menu3") Is Nothing Then
                '    Cache.Insert("menu3", makeappmenu(3), Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                'End If
                'nav.InnerHtml = Cache("menu3").ToString

                ' load_user_pref()
                ' If isAdmin(Session("eid")) Then hfAdmin.Value = 1

                '     executeDB("update hits set view = view+1 where page = 'gen'")
                divCount.InnerHtml = getDBsingle("select count (eid) from cert where type in (select type from pledge where active = 1 limit 1) limit 1")


                If Cache("cmdHindi") Is Nothing Then
                    Dim cmdHindi = getDBsingle("select cmdhindi from pledge where active = 1 limit 1")
                    Cache.Insert("cmdHindi", cmdHindi, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If
                Dim cmdEng = ""
                If Cache("cmdEng") Is Nothing Then
                    cmdEng = getDBsingle("select cmdEng from pledge where active = 1 limit 1")
                    Cache.Insert("cmdEng", cmdEng, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If
                divMessage.InnerHtml = Cache("cmdEng").ToString  '"" & "<p>It gives me an immense pleasure to note that the Security Awareness Week Is being observed all over NTPC with a great sense of dedication And determination to keep our lives, both at work And home, secure And safe.</p><p>The observance of Security Awareness Week reaffirms our resolve to keep our workplaces and townships very secure so that these places do not become vulnerable to the inimical elements who leave no opportunity to penetrate our security system.</p> <p>I am very glad to acknowledge and assure you all that we have a robust security system to protect our physical infrastructure as well as our technical facilities. We are making continued efforts to upgrade our security infrastructure after regular security reviews and audit of our facilities. It is with a great sense of satisfaction that I place my compliments to all Head of Projects for attending to security issues with great sense of responsibility.</p> <p>Let us all Pledge ourselves for a secure and peaceful year ahead. I appeal to all to take the security pledge through this online mode to reiterate our dedication and commitment to the cause of security. </p> <img src='images/cmdsign.png' /><br/><b>(Gurdeep Singh)</b> <br/>Chairman & Managing Director "
                '   divMessageHindi.InnerHtml = Cache("cmdHindi").ToString '"<p>मुझे यह जानकर अत्यंत प्रसन्नता है इस समय पूरी एनटीपीसी में अपने जीवन को कार्यस्थल एवं घर पर सुरक्षित एवं संरक्षित रखने के महान समर्पण एवं संकल्प की भावना से सुरक्षा जागरूकता सप्ताह मनाया जा रहा है ।</p><p>सुरक्षा जागरूकता सप्ताह का आयोजन हमारे कार्यस्थल और आवासीय परिसर को अत्यधिक सुरक्षित रखने के संकल्प को पुनः दोहराता है, जिससे कि ये स्थान अहितकर तत्वों से असुरक्षित न रहे और हमारी सुरक्षा प्रणाली को भी प्रभावित न कर सके ।<br/></p> <p>मुझे यह जानकर अपार खुशी है और विश्वास दिलाता हूँ कि हमारे पास भौतिक संरचना के साथ-साथ हमारी तकनीकी सुविधाओं को सुरक्षित रखने के लिए सुदृढ़ सुरक्षा प्रणाली है । हम नियमित सुरक्षा समीक्षा एवं अपनी सुविधाओं के ऑडिट के माध्यम से सुरक्षा संरचना को अद्यतन करने का निरंतर प्रयास कर रहे हैं । इस संतुष्टि की अत्यधिक अनुभूति के साथ, मैं सभी परियोजना प्रमुखों को सुरक्षा मुद्दों के अनुपालन की पूरी जिम्मेदारी देता हूँ ।<br/> </p> <p>आइए, हम सभी यह प्रतिज्ञा लें कि हमारे लिए आगामी वर्ष सुरक्षित एवं शांतिप्रिय होगा । मेरी आपसे अपील है कि हम अपने संगठन में सुरक्षा के प्रति अपनी वचनबद्धता एवं समर्पण के प्रमाण के रूप में इसकी ऑनलाइन मोड से प्रतिज्ञा ग्रहण करें ।</p> <br/><img src='images/cmdsign.png' /><br/><b>( गुरदीप सिंह )</b> <br/>अध्यक्ष  एवं  प्रबंध  निदेशक  <br/>"
            End If
        Catch e1 As Exception
            Response.Write("<div id='bottomline'>" & e1.Message & "</div>")
        End Try
    End Sub
    '

End Class
