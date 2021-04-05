<%@ Page Language="VB" AutoEventWireup="false" CodeFile="sms.aspx.vb" Inherits="_sms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>NTPC Pledge</title>
		<meta charset="utf-8" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
		<meta name="viewport" content="width=device-width, initial-scale=1" />
     <script src="js/jquery-1.8.3.min.js"></script>
		<!--[if lte IE 8]><script src="assets/js/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="css/main.css" />
		<!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
		<noscript><link rel="stylesheet" href="assets/css/noscript.css" /></noscript>
    <script src="js/typedText.min.js"></script>
   <style>
       .pledge
       {
           position: relative;
    /*margin: 10% auto;*/
    min-width:600px;
    max-width:95%;
    padding: 5px 20px 13px 20px;
    border-radius: 10px;
    background: #fff;
    background: -moz-linear-gradient(#fff, #aedade);
    background: -webkit-linear-gradient(#fff, #aedade);
    background: -o-linear-gradient(#fff, #aedade);
    font-family: Arial, Helvetica, sans-serif;
    font-size:22px;
       }
   </style>
</head>
<body class="is-loading">
    <form id="form1" runat="server">
 

		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
					<section id="main">
						<header>
							<span class="avatar"><asp:Literal runat="server" ID="litPic"  ></asp:Literal></span>
                            <asp:RadioButtonList ID="rblSMS" runat="server"  AutoPostBack="True" >
                               <asp:ListItem Value="Pledged"  ></asp:ListItem>
                                 <asp:ListItem Value="UnPledged"  ></asp:ListItem>
                                 <asp:ListItem Value="Thanks"  ></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:TextBox ID="txtSMS" runat="server" TextMode="MultiLine" Height="100px" ></asp:TextBox>
                         <br />   <asp:Button ID="btnSMS" runat="server" Text="SMS" />
                     &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   <asp:Button ID="btnEmail" runat="server" Text="Email" />
                            <div id="divMsg" runat="server" />
                      <asp:GridView ID="gvReport" runat="server" CssClass="mytable1" ></asp:GridView>
                         
						</header>
						<footer>
							<ul class="icons">
								<li><img src="images/ntpc.png"  width="200" height="120" /></li>
								
							</ul>
                           
						</footer>
					</section>

				<!-- Footer -->
					<footer id="footer">
						<ul class="copyright">
							<li>&copy; CC-IT</li><li>2017: <a href="http://www.ntpc.co.in">NTPC Limited</a></li>
						</ul>
                        
					</footer>

			</div>

		

	
    </form>
    <!-- Scripts -->
			<!--[if lte IE 8]><script src="assets/js/respond.min.js"></script><![endif]-->
			<script>
				if ('addEventListener' in window) {
					window.addEventListener('load', function() { document.body.className = document.body.className.replace(/\bis-loading\b/, ''); });
					document.body.className += (navigator.userAgent.match(/(MSIE|rv:11\.0)/) ? ' is-ie' : '');
				}
			</script>
  
</body>
</html>
