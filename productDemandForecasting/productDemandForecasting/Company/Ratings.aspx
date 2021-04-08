<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="Ratings.aspx.cs" Inherits="productDemandForecasting.Company.Ratings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelCustomers" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Customers Ratings</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
    <asp:Label ID="lblProductName" runat="server" Font-Bold="True" 
                                 Font-Size="Large" ></asp:Label>
                                 <br />
	      	<div class="clear">
             <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                           
                <asp:Table ID="tableCustomers" runat="server">
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
