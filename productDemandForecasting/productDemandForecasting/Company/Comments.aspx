<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="productDemandForecasting.Company.Comments" %>
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
    <div class="registration_form">

	      	<div class="clear">
               <asp:Label ID="lblTopic" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="#990000"></asp:Label>
                        <br />
                          <br />

                <asp:Table ID="Table1" runat="server">
                </asp:Table>
            </div>

              <br />
              <br />
        <table align="center" style="width: 95%;">
            <tr style="font-size: small">
                <td style="width: 398px">
                    <b>Add New Comment</b></td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr style="font-size: small">
                <td style="width: 398px">
                   </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="font-size: small">
                <td style="width: 398px">
                    <asp:TextBox ID="txt_comment" runat="server" Height="80px" TextMode="MultiLine" 
                        Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txt_comment" ErrorMessage="Enter Comment" ToolTip="field required" 
                        ValidationGroup="comment" CssClass="failureNotification" Font-Size="Large"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="font-size: small">
                <td align="right" style="width: 398px">
                    <asp:Button ID="btn_comment" runat="server" Text="Submit" 
                        ValidationGroup="comment" onclick="btn_comment_Click" />
                </td>
                <td>
                    <br />
                </td>
            </tr>
        </table>
       
       </div>

	</div>
</div>
</div>
</div>




    </asp:Panel>



</asp:Content>
