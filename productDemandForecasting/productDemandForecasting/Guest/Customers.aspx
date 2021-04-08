<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/GuestMasterPage.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="productDemandForecasting.Guest.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelCompanies" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Registered Customers</h4>
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
                <asp:Table ID="tableCustomers" runat="server" BorderColor="#FF3300">
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
