<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Pledge.aspx.vb" Inherits="_Pledge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>NTPC Pledge</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
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
							<span class="avatar"><asp:Literal runat="server" ID="litPic"></asp:Literal></span>
							<h1><asp:Literal runat="server" ID="litName" /></h1>
							<p><asp:Literal runat="server" ID="litDesignation" /></p>
                          <%--  <input type="button" id="btnPledge" value="Take Pledge" />--%>
                           <%-- <div id="divPledge" class="pledge"></div>
                               <input type="button" id="btnIPledge" value="I Pledge & View Certificate" disabled  style="display: none;" />
                            <input type="button" id="btnIPledgeHindi" value="मैं  शपथ लेता हूँ ! प्रमाण पत्र देखें" disabled style="display: none;" />--%>
                            <div id="divPledge" runat="server" class="pledge" />
                            <asp:Button ID="btnPledge" runat="server" Text="I Pledge" />
						</header>
						<footer>
							<ul class="icons">
								<li><img src="images/ntpc.png"  width="200" height="120" /></li>
								
							</ul>
                             <asp:LinkButton ID="lbLang" runat="server" CausesValidation="False" ></asp:LinkButton>
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
    <script>
        //$(document).ready(function () {

            
        //    var onClickEnglish = function () {

        //        $("#divPledge").typedText("Pledge: <br/>I do hereby solemnly pledge that I shall continuously strive to be sensitive to the security needs of our organization and that I shall contribute my best to ensure a fool-proof and fail-proof security system. I also promise that I shall remain vigilant and adhere to all the security norms and guidelines issued by the authorities in this regard. Through our collective efforts, we shall create a secured work environment and bring pride to our organization. We also solemnly affirm to work for sensitizing the associated agencies, family members and friends regarding security.", "fast", function () {
        //            $("#btnIPledge").attr('disabled', false);
        //        })
        //    };
        //    var onClickHindi = function () {

        //        $("#divPledge").typedText("प्रतिज्ञा: <br/>मैं सत्यनिष्ठा से यह प्रतिज्ञा लेता हूँ कि मैं सदैव अपने संगठन की सुरक्षा आवश्यकताओं के लिए संवेदनशील रहने का प्रयत्न करूंगा और मैं अचूक एवं सुदृढ़ सुरक्षा प्रणाली सुनिश्चित करने के लिए भरसक प्रयास करूंगा । मैं यह भी वचन देता हूँ कि इस संबंध में प्राधिकारियों द्वारा जारी सुरक्षा नियमों और दिशा-निर्देशों के प्रति सतर्क रहूँगा और अनुपालन करूंगा । हम अपने सम्मिलित प्रयासों के माध्यम से सुरक्षित वातावरण बनाकर अपने संगठन को गौरवान्वित करेंगे । हम सत्यनिष्ठा से यह भी घोषणा करते हैं कि संबंधित एजेंसियों, पारिवारिक सदस्यों और मित्रों को भी सुरक्षा के संबंध में संवेदनशील करने का कार्य करेंगे ।", "fast", function () {
        //            $("#btnIPledgeHindi").attr('disabled', false);
                  
        //        })
        //    };
        //   // onClick();
        //    if (window.location.hash) {
        //        var hash = window.location.hash.substring(1);
        //        if (hash == "english") {
        //            onClickEnglish();
        //            $("#btnIPledge").show();
        //        }
        //        else
        //        {
        //            onClickHindi();
        //            $("#btnIPledgeHindi").show();
        //        }
        //    }
        // //   $("#btnPledge").click(onClick);

        //    var printClick = function () {
        //        window.location = "https://cc.ntpc.co.in/pledge/content.aspx?lang=english";
        //    };

        //    $("#btnIPledge").click(printClick);
        //    var printClickHindi = function () {
        //        window.location = "https://cc.ntpc.co.in/pledge/content.aspx?lang=hindi";
        //    };

        //    $("#btnIPledgeHindi").click(printClickHindi);
        //});
       

    </script>
</body>
</html>
