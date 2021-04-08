<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="_SingleBPhone.aspx.cs" Inherits="productDemandForecasting.Company._SingleBPhone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            color: #00CC00;
        }
        .style2
        {
            color: #003399;
        }
        .style3
        {
            color: #6600FF;
        }
        .style4
        {
            color: #FF0000;
        }
        .style5
        {
            color: #FF9900;
        }
        .style6
        {
            color: #00CCFF;
        }
        .style7
        {
            color: #000066;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelCustomerRegistration" runat="server">
 
    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Basic Phone Demand Prediction</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	
	<div class="login_left">
		<h3>Product Demand Prediction</h3>
		<p>Enter all parameters and click on the submit button to know the demand for the product for the inputted parameters...</p>
		<p>
            <span class="style1">fm(1-no,2-yes)</span>, <span class="style2">
            battery(0-low,1-medium,2-high,3-veryhigh)</span>, <span class="style3">
            color(0-white,1-black,2-grey,3-red,4-blue)</span>, <span class="style4">
            camera(1-0.1MP,2-0.2MP,3-0.3MP,4-0.4MP,5-0.5MP,6-0.6MP,7-0.7MP,8-0.8MP)</span>,
            <span class="style5">ram(1-4MB,2-8MB,3-16MB,4-24MB,5-32MB)</span>,
            <span class="style6">storage(1-1GB,2-2GB,3-4GB,4-&lt;4GB)</span>,
            <span class="style7">dualsim(1-single sim,2-dual sim)</span>	</p>
		<div class="registration_left">
		<a href="#"><div class="reg_fb"><i>Specify Parameters</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 <!-- Form -->
			<form id="registration_form" action="contact.php" method="post">

            <div>
					<label>
						<input placeholder="PRODUCT NAME:" type="text" tabindex="1" required="" autofocus="" runat="server" id="txtPName">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				<div>
					<label>
						<input placeholder="FM:" type="text" tabindex="1" required="" autofocus="" runat="server" id="txtFM">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div>
					<label>
						<input placeholder="BATTERY:" type="text" tabindex="2" required="" runat="server" id="txtBattery">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>						
				<div>
					<label>
						<input placeholder="COLOR:" type="text" tabindex="3" required="" runat="server" id="txtColor">
                        
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				<div>
					<label>
						<input placeholder="CAMERA:" type="text" tabindex="4" required="" autofocus="" runat="server" id="txtCamera">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div>
					<label>
						<input placeholder="RAM:" type="text" tabindex="5" required="" autofocus="" runat="server" id="txtRAM">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                
                <div>
					<label>
						<input placeholder="STORAGE:" type="text" tabindex="6" required="" autofocus="" runat="server" id="txtStroage">
                       
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				
				<div>
					<label>
						<input placeholder="DUAL SIM:" type="text" tabindex="7" required="" runat="server" id="txtDualSim">
                        
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

              
				<div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Predict Demand" 
                        ValidationGroup="a" onclick="btnSubmit_Click" />
					
				    <br />
                    <br />
                    <asp:Label ID="lblResult" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="Red"></asp:Label>
					
				</div>
				
			</form>
			<!-- /Form -->
		</div>
	</div>
	</div>
	<div class="clear"></div>
</div>
</div>
</div>

    </asp:Panel>
</asp:Content>
