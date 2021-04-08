<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/GuestMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="productDemandForecasting.Guest.CustomerRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:Panel ID="panelCustomerRegistration" runat="server">
 
    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Customer Registration</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	
	<div class="login_left">
		<h3>register new customer</h3>
		<p>By creating an account with our application, you will be able to make use of services such as browsing company products, specifying ratings, profile updation, etc..</p>
		<div class="registration_left">
		<a href="#"><div class="reg_fb"><i>Specify Details</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 <!-- Form -->
			<form id="registration_form" action="contact.php" method="post">
				<div>
					<label>
						<input placeholder="Customer Id:" type="text" tabindex="1" required="" autofocus="" runat="server" id="txtCustomerId">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div>
					<label>
						<input placeholder="password:" type="password" tabindex="2" required="" runat="server" id="txtPassword">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>						
				<div>
					<label>
						<input placeholder="retype password:" type="password" tabindex="3" required="" runat="server" id="txtConfirmPassword">
                        <asp:CompareValidator runat="server" ErrorMessage="mismatch" 
                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                        ToolTip="mismatch" ValidationGroup="a" CssClass="failureNotification"></asp:CompareValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				<div>
					<label>
						<input placeholder="First Name:" type="text" tabindex="4" required="" autofocus="" runat="server" id="txtFName">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div>
					<label>
						<input placeholder="Last Name:" type="text" tabindex="5" required="" autofocus="" runat="server" id="txtLName">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                
                <div>
					<label>
						<input placeholder="Contact Number:" type="text" tabindex="6" required="" autofocus="" runat="server" id="txtContactNo">
                        <asp:RegularExpressionValidator runat="server" 
                        ErrorMessage="input 10 digits" ControlToValidate="txtContactNo" 
                        CssClass="failureNotification" ToolTip="input 10 digits" 
                        ValidationExpression="\d{10}" ValidationGroup="a"></asp:RegularExpressionValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				
				<div>
					<label>
						<input placeholder="email address:" type="text" tabindex="7" required="" runat="server" id="txtEmailId">
                        <asp:RegularExpressionValidator runat="server" 
                        ErrorMessage="invalid format" ControlToValidate="txtEmailId" 
                        CssClass="failureNotification" ToolTip="invalid format" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="a"></asp:RegularExpressionValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

              
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
