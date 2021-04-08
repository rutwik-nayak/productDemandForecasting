<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="productDemandForecasting.Admin.Comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:Panel ID="panelComments" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Discussion Forum [Comments]</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">

	      	<div class="clear">
               <asp:Label ID="lblTopic" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="#990000"></asp:Label>
                        <br />
                          <br />

                <asp:Table ID="Table1" runat="server">
                </asp:Table>
            </div>
	</div>
</div>
</div>
</div>




    </asp:Panel>



</asp:Content>
