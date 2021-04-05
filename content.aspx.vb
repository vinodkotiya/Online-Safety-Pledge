Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports dbOp
Partial Class content
    Inherits System.Web.UI.Page

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If Session("eid") Is Nothing Then

            Response.Redirect("login.aspx?redirectafterlogin=Default.aspx")
        End If

        Dim thefile = "cert" & Session("eid") & ".jpg"
        Dim resizefile = Server.MapPath("./upload/" & thefile)
        Response.ContentType = "image/jpeg"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & thefile)
        Response.TransmitFile(resizefile)
        Response.End()
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Dim thefile = Server.MapPath("~/upload/") + "cert" & Session("eid") & ".jpg"

        thefile = Server.MapPath("~/upload/") + "safety.pdf"
        btnEmail.Text = "Mail Sent " & SendEmail("CCIT-NOREPLY@ntpc.co.in", Session("email"), "", "", "Congratulations!! You have read Safety Policy on  " & Now.ToString("dd.MM.yyyy"), "Dear Ma'm/Sir <br/><br/> You have read the Safety Policy. Document is attached. Thanks. <br/> Do not reply to this email. <br/><br/>Regards, <br/>TEAM NTPC", thefile, "", "", "")
        btnEmail.Enabled = False
    End Sub

    Private Sub content_Load(sender As Object, e As EventArgs) Handles Me.Load
        '   Session("eid") = "9383"
        Try
            If Session("eid") Is Nothing Then

                Response.Redirect("login.aspx?redirectafterlogin=Default.aspx")
            End If

            If Cache("type") Is Nothing Then
                Dim type = getDBsingle("select type from pledge where active = 1 limit 1")
                Cache.Insert("type", type, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
            End If
            divCount.InnerHtml = getDBsingle("select count (eid) from cert where type in (select type from pledge where active = 1 limit 1) limit 1")

            executeDB("replace into cert (eid,name,email,last_updated,lastupdateby, type) values (" & Session("eid") & ",'" & Session("empname").replace("'", "") & "','" & Session("email").replace("'", "") & "', current_timestamp,'" & Request.UserHostAddress & "-" & Now.ToString & "', '" & Cache("type").ToString & "' )")

            Exit Sub

            btnEmail.Text = "Email Certificate to: " & Session("email")
            Dim cert = "cert.jpg"
            Dim empname = longToShort(Session("empname"))
            'lbLang.Text = "हिंदी में प्रमाण पत्र लें"
            'lbLang.PostBackUrl = "content.aspx?lang=hindi"
            lbLang.Visible = True
            lbLangHindi.Visible = False
            Dim x = 770
            If empname.ToString.Length > 17 Then x = 980

            Dim y = 470
            If Request.Params("lang") = "hindi" Then
                cert = "certhindi.jpg"
                empname = getHindiName(Session("eid"), empname)
                'lbLang.Text = "Get Certificate in English"
                'lbLang.PostBackUrl = "content.aspx?lang=english"
                lbLang.Visible = False
                lbLangHindi.Visible = True
                If empname.ToString.Length > 27 Then x = 980
                y = 480
            End If


            Dim originalfile = Server.MapPath("./upload/" & cert)
            Dim thefile = "cert" & Session("eid") & ".jpg"
            Dim resizefile = Server.MapPath("./upload/" & thefile)
            'Dim ret = ResizeImage(originalfile, resizefile, 1024, True, False)
            'Dim islandscape = False
            'If ret.Contains("Error") Then Exit Sub
            'If ret.Contains("True") Then islandscape = True

            Using bitmap__1 As System.Drawing.Image = DirectCast(Bitmap.FromFile(originalfile), System.Drawing.Image)
                ' set image 
                'draw the image object using a Graphics object
                Using graphicsImage As Graphics = Graphics.FromImage(bitmap__1)

                    '''Draw Rectangle
                    Dim customColor As Color = Color.FromArgb(50, Color.Gray)
                    'Dim shadowBrush As New SolidBrush(customColor)
                    ''graphicsImage.DrawRectangle()
                    'graphicsImage.FillRectangle(shadowBrush, New Rectangle(x, y, 400, 600))

                    'Set the alignment based on the coordinates   
                    Dim stringformat As New StringFormat()
                    stringformat.Alignment = StringAlignment.Far
                    stringformat.LineAlignment = StringAlignment.Far
                    Dim stringformat2 As New StringFormat()
                    stringformat2.Alignment = StringAlignment.Center
                    stringformat2.LineAlignment = StringAlignment.Center
                    'Set the font color/format/size etc..  
                    Dim StringColor As Color = System.Drawing.ColorTranslator.FromHtml("#933eea")
                    'direct color adding
                    Dim StringColor2 As Color = System.Drawing.ColorTranslator.FromHtml("#e80c88")
                    'customise color adding
                    Dim Str_TextOnImage As String = "" & empname
                    'Your Text On Image
                    ' Dim Str_TextOnImage2 As String = "- Tr"
                    'Your Text On Image
                    graphicsImage.DrawString(Str_TextOnImage, New Font("arial", 26, FontStyle.Regular), New SolidBrush(StringColor), New Point(x, y), stringformat)
                    'Response.ContentType = "image/jpeg"
                    ''   graphicsImage.DrawString(Str_TextOnImage2, New Font("Edwardian Script ITC", 34, FontStyle.Bold), New SolidBrush(StringColor2), New Point(x, y + 100), stringformat2)
                    'Response.ContentType = "image/jpeg"
                    ' bitmap__1.Save(Response.OutputStream, ImageFormat.Jpeg)
                    bitmap__1.Save(resizefile, ImageFormat.Jpeg)
                End Using
            End Using
            divCert.InnerHtml = "<img src='upload/" & thefile & "' width='80%' height='80%' />"
            If Cache("type") Is Nothing Then
                Dim type = getDBsingle("select type from pledge where active = 1 limit 1")
                Cache.Insert("type", type, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
            End If

            executeDB("replace into cert (eid,name,email,last_updated,lastupdateby, type) values (" & Session("eid") & ",'" & Session("empname").replace("'", "") & "','" & Session("email").replace("'", "") & "', current_timestamp,'" & Request.UserHostAddress & "-" & Now.ToString & "', '" & Cache("type").ToString & "' )")
        Catch ex As Exception
            divMsg.InnerHtml = "Error occured in generating certificate. Please Try Later !!" & ex.Message
        End Try

    End Sub
    Function longToShort(longform As String) As String
        Try
            If longform.Length < 16 Then Return longform
            Dim a() = longform.Split(" ")
            Dim shortname = ""
            Dim i = 1
            Dim surname = ""
            For Each part In a
                If i < a.Length Then
                    shortname = shortname & Left(part, 1) & ". "
                Else
                    shortname = shortname & part
                End If
                i = i + 1
            Next
            Return shortname
        Catch ex As Exception
            Return longform
        End Try
    End Function
    Function getHindiName(ByVal eid As String, ByVal empname As String) As String
        Try
            Dim hindiname = getDBsingle("select fhindi || ' ' || lhindi from emphindi where eid = " & eid & " limit 1 ")
            If hindiname.Contains("Error") Then Return empname
            If System.Text.RegularExpressions.Regex.IsMatch(hindiname, "\d") Then Return empname
            If String.IsNullOrEmpty(hindiname.Trim) Then Return empname
            Return hindiname
        Catch ex As Exception
            Return empname
        End Try
    End Function

End Class
