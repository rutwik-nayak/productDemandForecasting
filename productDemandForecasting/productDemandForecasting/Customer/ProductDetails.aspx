<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="productDemandForecasting.Customer.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelProductDetails" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">View Product Details</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
	      	
            <table style="width:90%;" align="center">
             <tr>
                 <td valign="top">
                     &nbsp;</td>
             </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblProductName" runat="server" Font-Bold="True" 
                            Font-Size="Large"></asp:Label>
                    </td>
                </tr>
             <tr>
             
                 <td align="left" valign="top">
                
                     <table style="width:100%;">
                         <tr>
                             <td>
                             
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Table ID="tableFeatures" runat="server">
                                 </asp:Table>
                             </td>
                         </tr>
                     </table>
                   
                 </td>
             </tr>
             <tr>
                 <td align="left" valign="top">
                     &nbsp;</td>
             </tr>
    </table>

	</div>
</div>
</div>
</div>




    </asp:Panel>



</asp:Content>
