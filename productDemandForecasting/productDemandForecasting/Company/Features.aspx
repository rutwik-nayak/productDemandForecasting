<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="Features.aspx.cs" Inherits="productDemandForecasting.Company.Features" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelFeature" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h2 class="style">Manage Features</h2>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
			
	     	 <div class="registration_form">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddFeature" runat="server" 
                                Text="Add New Features" onclick="btnAddFeature_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnAddValue" runat="server" 
                                Text="Add Feature Values" onclick="btnAddValue_Click" />
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
