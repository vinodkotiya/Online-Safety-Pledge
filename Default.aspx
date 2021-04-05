<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>NTPC Pledge</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
     <script src="js/jquery-1.8.3.min.js"></script>
		<!--[if lte IE 8]><script src="assets/js/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="css/main.css" />
		<!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
		<noscript><link rel="stylesheet" href="assets/css/noscript.css" /></noscript>
  <link href='favicon.ico' rel='icon' type='image/x-icon'/>
   <style>
      h2 {
  font-size: 1.5em;
  letter-spacing: 0.04em;
  margin: 0;
  font-weight: normal;
  color: #ff5252;
}

.announcement {
  padding: 10px 15px 0px;
  border: 1px solid #e1e1e1;
  background-color: #f9f9f9;
  border-radius: 4px;
 
  font-family: 'Dosis', Arial,Helvetica,sans-serif !important;
  color: #444;
  text-align: justify;
}
.content-right {
    float: left;
    width: 48%;
    font-size: 20px!important ;
}   
  
.content-left {
    float: left;
    width: 48%;
     font-size: 18px;
} 
.flash-button{
	background:blue;
	padding:15px 15px;
	color:#fff;
	border:none;
	border-radius:5px;
	animation-name: flash;
	animation-duration: 1s;
	animation-timing-function: linear;
	animation-iteration-count: infinite;

	-webkit-animation-name: flash;
	-webkit-animation-duration: 1s;
	-webkit-animation-timing-function: linear;
	-webkit-animation-iteration-count: infinite;

	
	-moz-animation-name: flash;
	-moz-animation-duration: 1s;
	-moz-animation-timing-function: linear;
	-moz-animation-iteration-count: infinite;
}

@keyframes flash {  
    0% { opacity: 1.0; }
    50% { opacity: 0.5; }
    100% { opacity: 1.0; }
}


@-webkit-keyframes flash {  
    0% { opacity: 1.0; }
    50% { opacity: 0.5; }
    100% { opacity: 1.0; }
}


@-moz-keyframes flash {  
    0% { opacity: 1.0; }
    50% { opacity: 0.5; }
    100% { opacity: 1.0; }
}
 .count {
  background: #cccccc;
  border-radius: 0.8em;
  -moz-border-radius: 0.8em;
  -webkit-border-radius: 0.8em;
  color: #ffffff;
  display: inline-block;
  font-weight: bold;
  line-height: 1.6em;
  margin-right: 5px;
  text-align: center;
  width: 1.6em; 
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
                           
						<span class="avatar"><asp:Literal runat="server" ID="litPic"></asp:Literal></span>
                         <%-- <div class='content-left'>--%>
                                 <div id="divMessage" runat="server" class="announcement" />
                           <%--   </div>--%>
                            <%-- <div class='content-right'>
                                 <div id="divMessageHindi" runat="server" class="announcement" />
                              </div>--%> <br/>
                            <div style="display:inline-block">
                                <br/><br/>
                                </div>
						</header>
						<!--
						<hr />
						<h2>Extra Stuff!</h2>
						<form method="post" action="#">
							<div class="field">
								<input type="text" name="name" id="name" placeholder="Name" />
							</div>
							<div class="field">
								<input type="email" name="email" id="email" placeholder="Email" />
							</div>
							<div class="field">
								<div class="select-wrapper">
									<select name="department" id="department">
										<option value="">Department</option>
										<option value="sales">Sales</option>
										<option value="tech">Tech Support</option>
										<option value="null">/dev/null</option>
									</select>
								</div>
							</div>
							<div class="field">
								<textarea name="message" id="message" placeholder="Message" rows="4"></textarea>
							</div>
							<div class="field">
								<input type="checkbox" id="human" name="human" /><label for="human">I'm a human</label>
							</div>
							<div class="field">
								<label>But are you a robot?</label>
								<input type="radio" id="robot_yes" name="robot" /><label for="robot_yes">Yes</label>
								<input type="radio" id="robot_no" name="robot" /><label for="robot_no">No</label>
							</div>
							<ul class="actions">
								<li><a href="#" class="button">Get Started</a></li>
							</ul>
						</form>
						<hr />
						-->
                        
						
					</section>
                <section class="#main">
                    <div style="display:inline-block">
							<%--	<h1><asp:Literal runat="server" ID="litName" /></h1>
							<p><asp:Literal runat="server" ID="litDesignation" /></p>--%>
                           <a class="flash-button" href="pledge.aspx?lang=english">Read in English!</a>
                           &nbsp;&nbsp;&nbsp;&nbsp; <a class="flash-button" href="pledge.aspx?lang=hindi">हिंदी में !</a>
                        <br /><hr />
                      <%-- <h3>प्रतिज्ञा तीन आसान चरणों में लें</h3> 
<h3>TAKE PLEDGE IN THREE EASY STEPS</h3>
                        <ul>
                            <li> GET YOUR BASIC DETAILS AFTER LOG IN (बुनियादी विवरण दर्ज कीजिये)</li>
                            <li>SELECT PLEDGE LANGUAGE (प्रतिज्ञा की भाषा चुनिये)</li>
                            <li> READ & TAKE PLEDGE (पढ़ें और प्रतिज्ञा लें)</li>
                            <li>Send certificate to your Email/Mobile/Download Certificate<br /> (प्रमाणपत्र डाउनलोड / अपने ई-मेल/मोबाइल पर भेजें )</li>
                            <li>If already taken Pledge, Get the Certificate of Commitment <br />(यदि प्रतिज्ञा पहले ही ले ली है तो वचनबद्धता का प्रमाण-पत्र प्राप्त करें ।)</li>
                        </ul>--%>
                          </div>
                    <footer>
                          
							<ul class="icons">
                                <li>
                                  <a href="report.aspx" target="_blank" >Empoloyees who have read Safety Policy (प्रतिज्ञा ले चुके कर्मचारी  ) </a> : <div class='count' runat="server" id="divCount">23</div> 
                                </li>
								<li><img src="images/ntpc.png"  width="200" height="120" style="margin-left: 0px;" /></li>
								
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

				$('.count').each(function () {
				    $(this).prop('Counter', 0).animate({
				        Counter: $(this).text()
				    }, {
				        duration: 2000,
				        easing: 'swing',
				        step: function (now) {
				            $(this).text(Math.ceil(now));
				        }
				    });
				});

			</script>
   
</body>
</html>
