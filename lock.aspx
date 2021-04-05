<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lock.aspx.vb" Inherits="_lock" %>

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
 
     <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="css/demo.css">




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
                    	<div class="countdown countdown-container container">
    <div class="clock row">
        <div class="clock-item clock-days countdown-time-value col-sm-6 col-md-3">
            <div class="wrap">
                <div class="inner">
                    <div id="canvas-days" class="clock-canvas"></div>

                    <div class="text">
                        <p class="val">0</p>
                        <p class="type-days type-time">DAYS</p>
                    </div><!-- /.text -->
                </div><!-- /.inner -->
            </div><!-- /.wrap -->
        </div><!-- /.clock-item -->

        <div class="clock-item clock-hours countdown-time-value col-sm-6 col-md-3">
            <div class="wrap">
                <div class="inner">
                    <div id="canvas-hours" class="clock-canvas"></div>

                    <div class="text">
                        <p class="val">0</p>
                        <p class="type-hours type-time">HOURS</p>
                    </div><!-- /.text -->
                </div><!-- /.inner -->
            </div><!-- /.wrap -->
        </div><!-- /.clock-item -->

        <div class="clock-item clock-minutes countdown-time-value col-sm-6 col-md-3">
            <div class="wrap">
                <div class="inner">
                    <div id="canvas-minutes" class="clock-canvas"></div>

                    <div class="text">
                        <p class="val">0</p>
                        <p class="type-minutes type-time">MINUTES</p>
                    </div><!-- /.text -->
                </div><!-- /.inner -->
            </div><!-- /.wrap -->
        </div><!-- /.clock-item -->

        <div class="clock-item clock-seconds countdown-time-value col-sm-6 col-md-3">
            <div class="wrap">
                <div class="inner">
                    <div id="canvas-seconds" class="clock-canvas"></div>

                    <div class="text">
                        <p class="val">0</p>
                        <p class="type-seconds type-time">SECONDS</p>
                    </div><!-- /.text -->
                </div><!-- /.inner -->
            </div><!-- /.wrap -->
        </div><!-- /.clock-item -->
    </div><!-- /.clock -->
</div>
					<section id="main">
						<header>
							<span class="avatar"><asp:Literal runat="server" ID="litPic"></asp:Literal></span>
							
                     <h1>Site will be open on 08.12.2017</h1>
                          <img src="images/pledge.png" />
                               <h2>Meanwhile create SSO Login ID by clicking <a href="https://mapp.ntpc.co.in/sso/oAuthntpcs/applogin/2017120500019"> <<--HERE-->> </a></h2>
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
  
<script type="text/javascript" src="js/kinetic.js"></script>
<script type="text/javascript" src="js/jquery.final-countdown.js"></script>
<script type="text/javascript">  
    $('document').ready(function() {
        'use strict';
        var seconds = new Date().getTime() / 1000;

        var endTime = 1512727200;
    	$('.countdown').final_countdown({
    	    'start': 1512554400,
            'end': endTime,
            'now': seconds
        });
    });
</script>


</body>
</html>
