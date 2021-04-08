<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/GuestMasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="productDemandForecasting.Guest.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:Panel ID="panelRegister" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h2 class="style">Users Registration</h2>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
			
	     	 <div class="registration_form">
                <table style="width:60%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnCompany" runat="server" onclick="btnCompany_Click" 
                                Text="Click Here for Company Registration" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnCustomer" runat="server" onclick="btnCustomer_Click" 
                                Text="Click here for Customer Registration" Visible="False" />
                        </td>
                    </tr>
                </table>
                <br />
                </div>
	      	<div class="clear"></div>
	</div>
</div>
</div>
</div>


    </asp:Panel>
 
</asp:Content>
