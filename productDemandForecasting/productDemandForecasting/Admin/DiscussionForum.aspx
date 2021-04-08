<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="DiscussionForum.aspx.cs" Inherits="productDemandForecasting.Admin.DiscussionForum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:Panel ID="panelDF" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Discussion Forum</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
     <marquee style="font-weight: 700; color: #FF3300">Click on Topic Name to view Comments....</marquee>
     <br />
     <br />
	      	<div class="clear">
                <asp:Table ID="Table1" runat="server">
                </asp:Table>
            </div>

	</div>
</div>
</div>
</div>




    </asp:Panel>



</asp:Content>
