﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/GuestMasterPage.Master" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="productDemandForecasting.Guest.Companies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <asp:Panel ID="panelCompanies" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Registered Companies</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
	      	<div class="clear">
            <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                <asp:Table ID="tableCompanies" runat="server">
                </asp:Table>
                </div>
                </div>
            </div>
	</div>
</div>
</div>
</div>




    </asp:Panel>



</asp:Content>
