Imports Microsoft.VisualBasic

Public Class Common
    Public invalid As Boolean
    Public Shared Function strip(ByVal str As String) As String

        Return Regex.Replace(str, "[\[\]\\\^\$\|\?\/\*\'\+\(\)\{\}%,;><!@#\-\+]", "")
    End Function
    Public Shared Function makemenu(Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a1, a2, a3, a4, a5 As String
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"

        Dim temp = "<ul class='sf-menu'><li " & a1 & "><a href='Default.aspx'>Home</a></li> " &
               "	<li  " & a3 & ">  <a href ='saplogin.aspx'>PACE Officer</a></li> " &
                "	<li  " & a3 & ">  <a href ='#'>Links</a></li> " &
                "	<li  " & a4 & ">	<a href ='report.aspx' > Reports</a>		</li>" &
                  "  <li  " & a5 & ">   <a href='Contacts.aspx'>Contacts</a>   </li>	</ul>"

        Return temp
    End Function
    Public Shared Function makeappmenu(ByVal url As String, Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a1, a2, a3, a4, a5, a6, a7 As String
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"
        If sel = 6 Then a6 = "class='current'"
        If sel = 7 Then a7 = "class='current'"

        Dim temp = "<ul class='sf-menu'><li ><a href='epace.aspx'>Dashboard</a></li> " &
              " <li " & a1 & "><a href='" & url & "?mode=1'>Basic Information</a></li> " &
                    "<li  " & a2 & "> <a  href='" & url & "?mode=2'>Responsibility</a> </li>" &
                "	<li  " & a3 & ">  <a href ='" & url & "?mode=3'>Tasks/KPA</a></li> " &
                "	<li  " & a4 & ">	<a href ='" & url & "?mode=4' >Self Assessment</a>		</li>" &
                   "	<li  " & a6 & ">	<a href ='" & url & "?mode=6' >Competencies</a>		</li>" &
                       "	<li  " & a7 & ">	<a href ='" & url & "?mode=7' >Attachments</a>		</li>" &
                 "	<li  " & a5 & ">	<a href ='" & url & "?mode=5' >Submit</a>		</li>" &
                  "  <li  " & a1 & ">   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"

        Return temp
    End Function
    Public Shared Function makereportmenu(Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a0, a1, a2, a3, a4, a5 As String
        If sel = 0 Then a0 = "class='current'"
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"

        Dim temp = "<ul class='sf-menu'><li " & a0 & "><a href='reports.aspx?mode=0'>Simulate</a></li> " &
                 "<li  " & a1 & "> <a  href='reports.aspx?mode=1'>KPA</a> </li>" &
                 "<li  " & a2 & "> <a  href='reports.aspx?mode=2'>WorkFlow Maintenance</a> </li>" &
                "	<li  " & a3 & ">  <a href ='reports.aspx?mode=3'>Refresh Data</a></li> " &
                "	<li  " & a4 & ">	<a href ='reports.aspx?mode=4' >z</a>		</li>" &
                  "  <li  " & a5 & ">   <a href='reports.aspx?mode=5'>xx</a>   </li>	</ul>"

        Return temp
    End Function
    Public Shared Function makeAdminmenu(ByVal isAdmin As String, Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a99, a98, a11, a41, a61 As String
        If sel = 0 Then a0 = "class='current'"
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"
        If sel = 6 Then a6 = "class='current'"
        If sel = 7 Then a7 = "class='current'"
        If sel = 8 Then a8 = "class='current'"
        If sel = 9 Then a9 = "class='current'"
        If sel = 99 Then a99 = "class='current'"
        If sel = 98 Then a98 = "class='current'"
        If sel = 61 Then a61 = "class='current'"
        If sel = 41 Then a41 = "class='current'"
        Dim temp = ""
        If isAdmin = "1" Then
            temp = "<ul class='sf-menu'><li " & a0 & "><a href='admin.aspx?mode=0'>Simulate</a></li> " &
                 "<li  " & a99 & "> <a  href='admin.aspx?mode=99'>Dashboard</a> </li>" &
                  "<li  " & a98 & "> <a  href='admin.aspx?mode=98'>Support</a> </li>" &
                 "<li  " & a2 & "> <a  href='admin.aspx?mode=2'>WorkFlow</a> </li>" &
                "	<li  " & a3 & ">  <a href ='admin.aspx?mode=3'>Upload</a></li> " &
                "	<li  " & a4 & ">	<a href ='admin.aspx?mode=4' >Bulk Create</a>		</li>" &
                 "	<li  " & a41 & ">	<a href ='admin.aspx?mode=41' >Create</a>		</li>" &
                  "	<li  " & a7 & ">	<a href ='admin.aspx?mode=7' >Delete</a>		</li>" &
                  "  <li  " & a5 & ">   <a href='admin.aspx?mode=5'>Change</a>   </li>	" &
          "  <li  " & a6 & ">   <a href='admin.aspx?mode=6'>PACE Officer</a>   </li>	" &
           "  <li  " & a6 & ">   <a href='admin.aspx?mode=69'>SMS</a>   </li>	" &
           "  <li  " & a61 & ">   <a href='admin.aspx?mode=61'>Proj</a>   </li>	" &
            "  <li  " & a9 & ">   <a href='admin.aspx?mode=9'>Sep</a>   </li>	" &
            "  <li  " & a8 & ">   <a href='admin.aspx?mode=8'>Report</a>   </li>	" &
          "  <li  >   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"
        ElseIf isAdmin = "2" Then
            temp = "<ul class='sf-menu'>" &
                  "<li  " & a1 & "> <a  href='Default.aspx?eid=0'>Home</a> </li>" &
                    "<li  " & a99 & "> <a  href='admin.aspx?mode=99'>Dashboard</a> </li>" &
                  "<li  " & a98 & "> <a  href='admin.aspx?mode=98'>Support</a> </li>" &
            "<li  " & a2 & "><a href='admin.aspx?mode=2'>WorkFlow</a></li>" &
              "	<li  " & a4 & ">	<a href ='admin.aspx?mode=41' >Create Forms</a>		</li>" &
                "  <li  " & a5 & ">   <a href='admin.aspx?mode=5'>Change Status</a>   </li>	" &
                  "  <li  " & a6 & ">   <a href='admin.aspx?mode=61'>PACE Officer</a>   </li>	" &
         "  <li  " & a9 & ">   <a href='admin.aspx?mode=9'>Seperated</a>   </li>	" &
             "  <li  " & a8 & ">   <a href='admin.aspx?mode=8'>Report</a>   </li>	" &
        "  <li  >   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"
        Else
            temp = "<ul class='sf-menu'>" &
                 "<li  " & a1 & "> <a  href='Default.aspx?eid=0'>Home</a> </li>" &
                   "<li  " & a99 & "> <a  href='admin.aspx?mode=99'>Dashboard(E8+)</a> </li>" &
                 "<li  " & a98 & "> <a  href='admin.aspx?mode=98'>Support(E1-E7)</a> </li>" &
                    "<li  " & a2 & "> <a  href='admin.aspx?mode=2'>Workflow(E8+)</a> </li>" &
           "  <li  " & a8 & ">   <a href='admin.aspx?mode=8'>Report(E8+)</a>   </li>	" &
       "  <li  >   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"
        End If


        Return temp
    End Function
    Public Shared Function makeePACEmenu(ByVal sel As String) As String
        Dim a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a99, a98, a11, a41, a61 As String
        If sel = "0" Then a0 = "class='current'"
        If sel = "1" Then a1 = "class='current'"
        If sel = "2" Then a2 = "class='current'"
        If sel = "3" Then a3 = "class='current'"
        'http://191.254.1.42/cmg/
        Dim temp = "<ul class='sf-menu'><li  " & a0 & "> <a href='epace.aspx?mode=0'>Dashboard</a></li> " &
       "  <li  " & a2 & ">   <a href='epace.aspx?mode=2'>Support Message</a>   </li>	" &
        "  <li  " & a3 & ">   <a href='epace.aspx?mode=3'>Help Doc</a>   </li>	" &
                 "  <li >   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"

        Return temp
    End Function
    Public Function IsValidEmail(strIn As String) As Boolean
        invalid = False
        If String.IsNullOrEmpty(strIn) Then Return False

        '' Use IdnMapping class to convert Unicode domain names.
        'Try
        '    strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf DomainMapper,
        '                          RegexOptions.None, TimeSpan.FromMilliseconds(200))
        'Catch e As RegexMatchTimeoutException
        '    Return False
        'End Try

        If invalid Then Return False

        ' Return true if strIn is in valid e-mail format.
        Try
            Return Regex.IsMatch(strIn,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                   RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try
    End Function
    Private Function DomainMapper(match As Match) As String
        ' IdnMapping class with default property values.
        Dim idn As New System.Globalization.IdnMapping()

        Dim domainName As String = match.Groups(2).Value
        Try
            domainName = idn.GetAscii(domainName)
        Catch e As ArgumentException
            invalid = True
        End Try
        Return match.Groups(1).Value + domainName
    End Function
    Public Shared Function getOrGenerateEid(ByVal email As String) As String
        Dim q = "select empno from employee where email = '" & email & "' limit 1"
        Dim empno = dbOp.getDBsingle(q)
        If empno.Contains("Error") Then
            '' generate emp no for this user.
            q = "insert into employeemore (email, last_updated) values ('" & email & "', current_timestamp)"
            Dim ret = dbOp.executeDB(q)
            If ret.Contains("Error") Then
                Return ret
            Else
                Return dbOp.getDBsingle("select eid from employeemore  where email = '" & email & "' limit 1")
            End If
        Else
            Return empno
        End If
    End Function
    Public Shared Function getOrGenerateOTP(ByVal email As String) As String
        Dim q = "select OTP from vinotp where email = '" & email & "'   order by last_updated desc limit 1"
        Dim empno = dbOp.getDBsingle(q)
        If empno.Contains("Error") Then
            '' generate emp no for this user.
            q = "insert into vinotp (email, verify, resend, last_updated) values ('" & email & "', 0, 3, current_timestamp)"
            Dim ret = dbOp.executeDB(q)
            If ret.Contains("Error") Then
                Return ret
            Else
                'verify = 0 & 1 for sign up verify = 3, 4 for reset
                Return dbOp.getDBsingle("select otp from vinotp  where email = '" & email & "' and verify = 0 or verify = 3  order by last_updated desc limit 1")
            End If
        Else
            Return empno
        End If
    End Function
End Class
