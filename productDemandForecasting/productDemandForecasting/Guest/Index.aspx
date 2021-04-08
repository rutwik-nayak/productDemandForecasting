<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="productDemandForecasting.Guest.Index" %>

<!DOCTYPE HTML>
<html>
<head>
<title>Product Demand Forecasting</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href='http://fonts.googleapis.com/css?family=Maven+Pro:400,900,700,500' rel='stylesheet' type='text/css'>
<link href="../css/style.css" rel="stylesheet" type="text/css" media="all" />
<!--- start-mmmenu-script---->
<script src="../js/jquery.min.js" type="text/javascript"></script>
<link type="text/css" rel="stylesheet" href="../css/jquery.mmenu.all.css" />
<script type="text/javascript" src="../js/jquery.mmenu.js"></script>
		<script type="text/javascript">
		    //	The menu on the left
		    $(function () {
		        $('nav#menu-left').mmenu();
		    });
		</script>
<!-- start slider -->
	<link href="../css/slider.css" rel="stylesheet" type="text/css" media="all" />
        <script type="text/javascript" src="../js/jquery.eislideshow.js"></script>
        <script type="text/javascript" src="../js/easing.js"></script>
        <script type="text/javascript">
            $(function () {
                $('#ei-slider').eislideshow({
                    animation: 'center',
                    autoplay: true,
                    slideshow_interval: 3000,
                    titlesFactor: 0
                });
            });
        </script>
<!-- start top_js_button -->
<script type="text/javascript" src="../js/move-top.js"></script>
   <script type="text/javascript">
       jQuery(document).ready(function ($) {
           $(".scroll").click(function (event) {
               event.preventDefault();
               $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1200);
           });
       });
	</script>
</head>
<body>
<!-- start header -->
<div class="top_bg">
<div class="wrap">
	<div class="header">
		<div class="logo">
			<a href="Index.aspx"><img src="../images/logo3.png" alt=""/></a>
		</div>
		<div class="log_reg">
				<ul>
					<li><a href="Login.aspx">Login</a> </li>
					<span class="log"> or </span>
					<li><a href="Register.aspx">Register</a> </li>								   
					<div class="clear"></div>
				</ul>
		</div>		
						
		<div class="clear"></div>
	</div>	
</div>
</div>
<!-- start header_btm -->
<div class="wrap">
<div class="header_btm">
		<div class="menu">
			<ul>
				<li><a href="Index.aspx">Home</a></li>
				<li><a href="Aboutus.aspx">Aboutus</a></li>
				<li><a href="Contactus.aspx">Contactus</a></li>
				<li><a href="Services.aspx">Services</a></li>
                <li><a href="FAQs.aspx">FAQs</a></li>
				<li><a href="Companies.aspx">Companies</a></li>
                <%--<li><a href="Customers.aspx">Customers</a></li>--%>
			</ul>
		</div>
		
	
	<div class="clear"></div>
</div>
</div>
<!-- start slider -->
<div class="slider">
				<!---start-image-slider---->
				<div class="image-slider">
					 <div class="wrapper">
                <div id="ei-slider" class="ei-slider">
                    <ul class="ei-slider-large">
						<li>
                            <img src="../images/PDF5.jpg" alt="image06"/>
                            
                        </li>
                        <li>
                            <img src="../images/PDF2.jpg" alt="image01" />
                           
                        </li>
                        <li>
                            <img src="../images/PDF3.jpg" alt="image02" />
                           
                        </li>
                        <li>
                            <img src="../images/PDF4.jpg" alt="image03"/>
                           
                        </li>
                        <li>
                            <img src="../images/PDF1.jpg" alt="image04"/>
                            
                        </li>
                        <li>
                            <img src="../images/PDF2.jpg" alt="image05"/>
                            
                        </li>
                        <li>
                            <img src="../images/PDF5.jpg" alt="image07"/>
                           
                        </li>
                    </ul><!-- ei-slider-large -->
                    <ul class="ei-slider-thumbs">
                        <li class="ei-slider-element">Current</li>
						<li>
							<a href="#">
								<span class="active">Forecasting</span>
								
							</a>
							<img src="../images/PDF2.jpg" alt="thumb01" />
						</li>
                        <li class="hide"><a href="#"><span>Sales</span></a><img src="../images/PDF5.jpg" alt="thumb01" /></li>
                        <li  class="hide1"><a href="#"><span>Demand</span></a><img src="../images/PDF3.jpg" alt="thumb02" /></li>
                        <li class="hide1"><a href="#"><span>Planning</span> </a><img src="../images/PDF4.jpg" alt="thumb03" /></li>
                        <li><a href="#"><span>Features</span></a><img src="../images/PDF1.jpg" alt="thumb04" /></li>
                        <li><a href="#"><span>Product Cost</span></a><img src="../images/PDF2.jpg" alt="thumb05" /></li>
                        <li><a href="#"><span>Prediction</span></a><img src="../images/PDF5.jpg" alt="thumb07" /></li>
                    </ul><!-- ei-slider-thumbs -->
                </div><!-- ei-slider -->
            </div><!-- wrapper -->
		</div>
		<!---End-image-slider---->	
</div>
<!-- start image1_of_3 -->

<!-- start main -->
<div class="main_bg">
<div class="wrap">

</div>
</div>

<!-- start footer -->
<div class="footer_mid">
<div class="wrap">

</div>
</div>
<!-- start footer -->
<div class="footer_bg">
<div class="wrap">
<div class="footer">
		<!-- scroll_top_btn -->
	    <script type="text/javascript">
	        $(document).ready(function () {

	            var defaults = {
	                containerID: 'toTop', // fading element id
	                containerHoverID: 'toTopHover', // fading element hover id
	                scrollSpeed: 1200,
	                easingType: 'linear'
	            };


	            $().UItoTop({ easingType: 'easeOutQuart' });

	        });
		</script>
		 <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;"></span></a>
		<!--end scroll_top_btn -->
	<div class="f_nav1">
		<ul>
			<li><a href="Index.aspx">home /</a></li>
			<li><a href="Aboutus.aspx">aboutus /</a></li>
			<li><a href="Services.aspx">services /</a></li>
			<li><a href="FAQs.aspx">Faqs /</a></li>
			<li><a href="Contactus.aspx">Contact us</a></li>
		</ul>
		</div>
	<div class="copy">
		<p class="link"><span>© All rights reserved | Product Demand Forecasting&nbsp;</span></p>
	</div>
	<div class="clear"></div>
</div>
</div>
</div>
</body>
</html>