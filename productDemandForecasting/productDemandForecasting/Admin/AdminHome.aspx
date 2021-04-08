<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="productDemandForecasting.Admin.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelCompanies" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Newly Registered Companies</h4>
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
                            <asp:Button ID="btnApprove" runat="server" onclick="btnApprove_Click" 
                                Text="Click here to approve" 
                                onclientclick="confirm('r u sure want to approve?')" />
                        </td>
                        <td>
                         &nbsp;
                        </td>
                       
                        <td>
                            <asp:Button ID="btnReject" runat="server" onclick="btnReject_Click" 
                                Text="Clicke here to Reject" 
                                onclientclick="confirm('r u sure want to reject?')" />
                        </td>
                    </tr>
                </table>
                <br />
                </div>
                  <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                        <asp:Table ID="tableCompanies" runat="server" HorizontalAlign="Center">
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
