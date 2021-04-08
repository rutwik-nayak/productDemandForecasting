<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CompanyQueries.aspx.cs" Inherits="productDemandForecasting.Admin.CompanyQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelQueries" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Companies Queries</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
	      	<div class="clear">
             <div class="registration_form">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnPending" runat="server" onclick="btnPending_Click" 
                                Text="Pending Queries" />
                        </td>
                        <td>
                        &nbsp</td>
                        <td>
                            <asp:Button ID="btnAnswered" runat="server" onclick="btnAnswered_Click" 
                                Text="Answered Queries" />
                        </td>
                    </tr>
                </table>
                <br />
                </div>
                <asp:Table ID="tableQueries" runat="server">
                </asp:Table>
            </div>
	</div>
</div>
</div>
</div>




    </asp:Panel>



</asp:Content>
