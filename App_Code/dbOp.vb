Imports Microsoft.VisualBasic
Imports System.Data.SQLite
Imports System.Data
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net.Mail
Imports System.Net

Public Class dbOp
    Public Shared Function getDBsingle(ByVal mysql As String, Optional ByVal myConn As String = "vindb") As String
        ''this function will return single value from table according to myQuery
        'Create Connection String
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings(myConn).ConnectionString)
            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader
            Dim result As String
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                connection.Open()
                sqlComm = New SQLiteCommand(mysql, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count
                sqlReader.Close()
                sqlComm.Dispose()
                If dataTableRowCount = 1 Then
                    result = dt.Rows(0).Item(0).ToString()
                    connection.Close()
                    Return result
                Else
                    connection.Close()
                    Return "Error:Too many Records Found"
                End If

            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return "Error" + e.Message
            End Try
            connection.Close()
        End Using
    End Function
    Public Shared Function executeDB(ByVal mysql As String, Optional ByVal myConn As String = "vindb") As String

        'Create Connection String
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings(myConn).ConnectionString)
            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader

            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SQLiteCommand(mysql, connection)
                sqlReader = sqlComm.ExecuteReader()
                'Add Insert Statement
                sqlComm.Dispose()

                connection.Close()
                executeDB = "ok"


            Catch exp As Exception
                'lbldebug.Text = exp.Message
                connection.Close()
                executeDB = "Error:" + exp.Message

            End Try
            'Close Database connection
            'and Dispose Database objects
        End Using

    End Function
    Public Shared Function getDBTable(ByVal myQuery As String, Optional ByVal myConn As String = "vindb") As DataTable
        ''this function will return DataTable from table according to myQuery
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings(myConn).ConnectionString)
            ' connection.Close()
            connection.Open()

            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                sqlComm = New SQLiteCommand(myQuery, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)

                dataTableRowCount = dt.Rows.Count
                sqlReader.Close()
                sqlComm.Dispose()
                If Not dt Is Nothing Then

                    connection.Close()
                    Return dt
                Else
                    connection.Close()
                    Return dt.NewRow("Too many Records Found")
                End If

            Catch e As Exception
                'lblDebug.text = e.Message
                dt.Columns.Add("Error")
                Dim tmprow = dt.NewRow
                connection.Close()
                tmprow(0) = "Error: " & e.Message & myQuery
                dt.Rows.Add(tmprow)
                ' Return dt.NewRow("Error in getdatatable")
                Return dt
            End Try
            connection.Close()
        End Using
    End Function
    Public Shared Function Encrypt(clearText As String, Optional ByVal EncryptionKey As String = "VINODKOTIYA2016") As String

        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Shared Function Decrypt(cipherText As String, Optional ByVal EncryptionKey As String = "VINODKOTIYA2016") As String
        'If System.Web.HttpRuntime.Cache("marks" & cipherText) Is Nothing Then

        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using
                    cipherText = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using
        '  System.Web.HttpRuntime.Cache.Insert("marks" & cipherText, cipherText, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)

        'End If
        '''PHP Equivqlent
        '        $decryptedBytes = NULL;
        '$saltBytes = array(1,2,3,4,5,6,7,8);
        '$saltBytesstring = "";
        'For ($i= 0;$i<count($saltBytes);$i++){ echo $i;
        '    $saltBytesstring=$saltBytesstring.chr($saltBytes[$i]);
        '}

        '$AESKeyLength = 265/8;
        '$AESIVLength = 128/8;

        '$key = hash_pbkdf2("sha1", $passwordBytesstring, $saltBytesstring, 1000, $AESKeyLength + $AESIVLength, true); 

        '$aeskey = (  substr($key,0,$AESKeyLength) );
        '$aesiv =  (  substr($key,$AESKeyLength,$AESIVLength) );

        '$decrypted = mcrypt_decrypt
        '      (
        '          MCRYPT_RIJNDAEL_128,
        '          $aeskey,
        '          $bytesToBeDecryptedbinstring,
        '          MCRYPT_MODE_CBC,
        '          $aesiv
        '       );
        '$arr = str_split($decrypted);
        'For ($i= 0;$i<count($arr);$i++){
        '    $arr[$i] = ord($arr[$i]);
        '}
        '$decryptedBytes = $arr;
        Return cipherText
    End Function

    Public Shared Function takeBackup() As String
        ''Backup
        Dim thefile As String = "\App_Data\sso.db"
        Dim fs As System.IO.FileInfo = New System.IO.FileInfo(System.Web.HttpContext.Current.Server.MapPath("~") + thefile)
        Dim dbsize = Math.Round((fs.Length / (1024)), 2)
        Dim str = "Storage Status: " & dbsize.ToString() & " kb of 140 TB (" & Math.Round(Decimal.Divide(dbsize, 150323855359), 10).ToString & "% of database max limit)"

        Dim copystatus = ""
        Try
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day1'") > 24 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\sso1.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day1'")
                copystatus += "<br/>Day1 backup taken"
            Else
                copystatus += "<br/>Skip Copy, 1 Day old backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day1'")
            End If
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day2'") > 48 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\sso2.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day2'")
                copystatus += "<br/>Day2 backup taken"
            Else
                copystatus += "<br/>Skip Copy, 2 Day old backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day2'")
            End If
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day7'") > 150 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\sso7.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day7'")
                copystatus += "<br/>Weekly backup taken"
            Else
                copystatus += "<br/>Skip Copy, weekly backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day7'")
            End If
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day30'") > 600 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\sso30.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day30'")
                copystatus += "<br/>Monthly backup taken"
            Else
                copystatus += "<br/>Skip Copy, Monthly backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day30'")
            End If
        Catch ex As Exception
            copystatus += "Unable to copy " & ex.Message
        End Try
        Return str & "<br/>" & copystatus
    End Function
    Public Shared Function getRecentLoginDetail(ByVal email As String) As String
        Dim mydt = getDBTable("select lastapp , strftime('%d.%m.%Y %H:%m', DATETIME(last_updated, '+330 minutes')) || ' from IP ' || lastupdatedby from vinusers where email='" & email & "'")
        If mydt.Rows.Count = 0 Then
            Return "Existing User. Enter Password."
        End If
        Dim appname = getDBsingle("select appname from vinapp where appid = '" & mydt.Rows(0)(0) & "' limit 1")
        If appname.Contains("Error") Then appname = "Developer Page"
        Return "Last login:" & appname & "<br/>on " & mydt.Rows(0)(1)
    End Function
    Public Shared Function getDeveloperDetail(ByVal appID As String) As String
        Dim email = getDBsingle("select email from vinapp where appid = '" & appID & "' limit 1")
        If email.Contains("Error") Then Return "No Developer Details"
        Return getDBsingle("select email || ' - '|| cell from vinusers where email = '" & email & "'")
    End Function

    Public Shared Function getCC(ByVal pageload As String) As String
        Return "<p>HTML5 | Cache Enabled | AJAX | Page creation Time:" & pageload.ToString & " ms | Design & Developed By: <b>CC-IT</b> </p>"
    End Function

    Public Shared Function SendEmail(ByVal mailfrom As String, ByVal mailto As String, ByVal cc As String, ByVal bcc As String, ByVal subject As String, ByVal message As String, Optional ByVal attach1 As String = "", Optional ByVal attach2 As String = "", Optional ByVal userid As String = "", Optional ByVal pwd As String = "") As String
        Try
            'If Not mailto.Contains("ntpc.co.in") Then
            '    Return " Fail Non NTPC mail"
            'End If
            'create the mail message
            Dim mail As New MailMessage()

            'set the addresses
            mail.IsBodyHtml = True
        mail.From = New MailAddress(mailfrom)
        mail.To.Add(mailto)
            If Not String.IsNullOrEmpty(cc) Then mail.CC.Add(cc)
            'mail.Bcc.Add(bcc)
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<br/>" & message & "<br/>", Nothing, "text/html")
        'create the LinkedResource (embedded image)
        'Dim path As String = HttpContext.Current.Server.MapPath("~/DPR/")
        'Dim fileNameWitPath As String = path + Now.ToString("dd.MM.yy") + ".png"
        'If System.IO.File.Exists(fileNameWitPath) Then
        '    Dim logo As New LinkedResource(fileNameWitPath)
        '    logo.ContentId = "nw"
        '    'add the LinkedResource to the appropriate view
        '    htmlView.LinkedResources.Add(logo)
        'End If
        'set the content
        mail.Subject = subject
        ' mail.Body = message
        mail.AlternateViews.Add(htmlView)

        'add an attachment from the filesystem
        If Not String.IsNullOrEmpty(attach1) Then mail.Attachments.Add(New Attachment(attach1))

        'to add additional attachments, simply call .Add(...) again
        '  mail.Attachments.Add(New Attachment(attach2))
        ' mail.Attachments.Add(New Attachment("c:\temp\example3.txt"))

        'send the message
        Dim mailClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()

        'This object stores the authentication values
        Dim basicCredential As System.Net.NetworkCredential = New System.Net.NetworkCredential(userid, pwd)
        'SMTP gateway IPs 10.1.10.72 or 10.1.10.73 for mail flow out side ntpc or 10.1.8.119
        If mailto.Contains("ntpc.co.in") Or mailto.Contains("NTPC.CO.IN") Then
            mailClient.Host = "10.1.10.73"
        Else
            mailClient.Host = "10.1.10.73"
        End If

        mailClient.UseDefaultCredentials = False
        mailClient.Credentials = basicCredential
            mailClient.Send(mail)
            For Each attach In mail.Attachments
                attach.Dispose()
            Next
            Return "ok"
        Catch exp As Exception

        Return "Error: " & exp.Message
        End Try

    End Function

    Public Shared Function JustSendSMS(ByVal mobileNumbersseperatedbycomma As String, ByVal msg As String) As String

        'Multiple mobiles numbers separated by comma
        Dim mobileNumber As String = mobileNumbersseperatedbycomma
        'Your message to send, Add URL encoding here.
        Dim message As String = HttpUtility.UrlEncode(msg)

        'Prepare you post parameters
        Dim sbPostData As New StringBuilder()
        sbPostData.AppendFormat("locid={0}", "001000")
        sbPostData.AppendFormat("&msg={0}", message)
        sbPostData.AppendFormat("&num={0}", mobileNumber)


        Try
            'Call Send SMS API
            'Dim sendSMSUri As String = "https://control.msg91.com/api/sendhttp.php"
            'http://ers.ntpc.co.in:8080/ntpcd/URL2_Sender?locid=001000&msg=SMS_MSG&num=9650990024
            Dim sendSMSUri As String = "http://ers.ntpc.co.in:8080/ntpcd/URL2_Sender"
            'Create HTTPWebrequest
            Dim proxyObject As WebProxy = New WebProxy("http://10.0.236.36:8080")
            Dim httpWReq As HttpWebRequest = DirectCast(WebRequest.Create(sendSMSUri), HttpWebRequest)
            'httpWReq.Headers.Clear()
            'httpWReq.AllowAutoRedirect = True
            'httpWReq.Timeout = 1000 * 2
            'httpWReq.PreAuthenticate = True
            httpWReq.Credentials = CredentialCache.DefaultCredentials
            'httpWReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)"
            'httpWReq.Timeout = 150000
            '  httpWReq.Proxy = proxyObject
            'Prepare and Add URL Encoded data
            Dim encoding As New UTF8Encoding()
            Dim data As Byte() = encoding.GetBytes(sbPostData.ToString())
            'Specify post method
            httpWReq.Method = "POST"
            httpWReq.ContentType = "application/x-www-form-urlencoded"
            httpWReq.ContentLength = data.Length
            Using stream As Stream = httpWReq.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using
            'Get the response
            Dim response As HttpWebResponse = DirectCast(httpWReq.GetResponse(), HttpWebResponse)
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim responseString As String = reader.ReadToEnd()

            'Close the response
            reader.Close()
            response.Close()
            'Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://ers.ntpc.co.in:8080/ntpcd/URL2_Sender"), HttpWebRequest)
            ''Dim proxyObject As WebProxy = New WebProxy("http://10.0.236.36:8080")
            ''request.Proxy = proxyObject
            'request.Method = "POST"
            'request.ContentType = "application/x-www-form-urlencoded"
            'Dim postData As String = "locid=001000&msg=" && "&num=9650990024"
            'Dim bytes As Byte() = Encoding.UTF8.GetBytes(postData)
            'request.ContentLength = bytes.Length

            'Dim requestStream As Stream = request.GetRequestStream()
            'requestStream.Write(bytes, 0, bytes.Length)
            ''End Using
            'Dim response As WebResponse = request.GetResponse()
            'Dim stream As Stream = response.GetResponseStream()
            'Dim reader As New StreamReader(stream)

            'Dim result = reader.ReadToEnd()
            ''  reader.Close()

            'stream.Dispose()
            'reader.Dispose()
            Return "Success"
        Catch ex As Exception
            Return "Error:" & ex.Message.ToString()
        End Try
    End Function
End Class
