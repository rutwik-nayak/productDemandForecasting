<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="productDemandForecasting.Customer.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 164px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelProducts" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Browse Products</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
    <div class="registration_form">
	      	 
        <table style="width: 99%;" align="center">
            <tr>
                <td>
                    <table style="width: 99%;">
                        <tr>
                            <td style="text-align: left; " class="style1">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; " class="style1">
                                <b>Select Company</b></td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="DropDownListCompanies" runat="server" Width="200px" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="DropDownListCompanies_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; " class="style1">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <table style="width: 99%;">
                        <tr>
                            <td style="text-align: left; width: 182px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 201px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 182px">
                                <b>Select Category</b></td>
                            <td style="text-align: left; width: 201px">
                                <asp:DropDownList ID="DropDownListCategories" runat="server" Width="200px" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="DropDownListCategories_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 182px">
                                &nbsp;</td>
                            <td style="text-align: left; width: 201px">
                                &nbsp;</td>
                        </tr>
                    </table></td>
            </tr>
        </table>
      
        <br />
        <table style="width: 99%;" align="center">
            <tr>
                <td>
                    <asp:Table ID="tableProducts" runat="server">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnRating" runat="server" onclick="btnRating_Click" 
                        Text="Set Rating" />
                </td>
            </tr>
        </table>
      </div>
        <br />
	</div>
</div>
</div>
</div>




    </asp:Panel>


</asp:Content>
