<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/GuestMasterPage.Master" AutoEventWireup="true" CodeBehind="CompanyRegistration.aspx.cs" Inherits="productDemandForecasting.Guest.CompanyRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:Panel ID="panelCompanyRegistration" runat="server">
 
    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Company Registration</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	
	<div class="login_left">
		<h3>register new company</h3>
		<p>By creating an account with our application, you will be able to make use of services such as product demand forecasting, discussion forum, etc..</p>
		<div class="registration_left">
		<a href="#"><div class="reg_fb"><i>Specify Details</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 <!-- Form -->
			<form id="registration_form" action="contact.php" method="post">
				<div>
					<label>
						<input placeholder="Company Id:" type="text" tabindex="1" required="" autofocus="" runat="server" id="txtCompanyId">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div>
					<label>
						<input placeholder="password:" type="password" tabindex="2" required="" runat="server" id="txtPassword">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>						
				<div>
					<label>
						<input placeholder="retype password:" type="password" tabindex="3" required="" runat="server" id="txtConfirmPassword">
                          <asp:CompareValidator runat="server" ErrorMessage="mismatch" 
                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                        ToolTip="mismatch" ValidationGroup="a" CssClass="failureNotification"></asp:CompareValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				<div>
					<label>
						<input placeholder="Company Name:" type="text" tabindex="4" required="" autofocus="" runat="server" id="txtCompanyName">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div>
					<label>
						<input placeholder="Address:" type="text" tabindex="5" required="" autofocus="" runat="server" id="txtAddress">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div>
					<label>
						<input placeholder="City:" type="text" tabindex="6" required="" autofocus="" runat="server" id="txtCity">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div>
					<label>
						<input placeholder="Contact Number:" type="text" tabindex="7" required="" autofocus="" runat="server" id="txtContactNo">
                        <asp:RegularExpressionValidator runat="server" 
                        ErrorMessage="input 10 digits" ControlToValidate="txtContactNo" 
                        CssClass="failureNotification" ToolTip="input 10 digits" 
                        ValidationExpression="\d{10}" ValidationGroup="a"></asp:RegularExpressionValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				
				<div>
					<label>
						<input placeholder="email address:" type="text" tabindex="8" required="" runat="server" id="txtEmailId">
                         <asp:RegularExpressionValidator runat="server" 
                        ErrorMessage="invalid format" ControlToValidate="txtEmailId" 
                        CssClass="failureNotification" ToolTip="invalid format" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="a"></asp:RegularExpressionValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div>
					<label>
						<input placeholder="Website Address:" type="text" tabindex="9" required="" autofocus="" runat="server" id="txtWebsiteAddress">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div>
					<label>
						<input placeholder="Receipt Number:" type="text" tabindex="10" required="" autofocus="" runat="server" id="txtReceiptNumber">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                  <div>
					<label>
                        <asp:FileUpload placeholder="Upload Logo:" runat="server" required="" autofocus="" id="fileuploadPhoto">
                        </asp:FileUpload>


						
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
					
				<div>
                    <asp:Button ID="btnRegister" runat="server" Text="create an account" 
                        onclick="btnRegister_Click" ValidationGroup="a" />
					
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
