<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="productDemandForecasting.Company.Topics" %>
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
    <div class="registration_form">
    <marquee style="font-weight: 700; color: #FF3300">Click on Topic Name to view Comments....</marquee>
     <br />
     <br />
	      	<div class="clear">
                <asp:Table ID="Table1" runat="server">
                </asp:Table>
            </div>

            <br />
              <br />
              <table style="width: 60%;">
            <tr style="font-size: small">
                <td class="style1">
                    <b>Add New Topic</b></td>
                <td style="width: 398px">
                    &nbsp;</td>
            </tr>
             <tr style="font-size: small">
                <td class="style1">
                   </td>
                <td style="width: 398px">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: small">
                <td class="style1">
                    <asp:TextBox ID="txt_topic" runat="server" Height="80px" TextMode="MultiLine" 
                        Width="400px"></asp:TextBox>
                </td>
                <td style="width: 398px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txt_topic" CssClass="failureNotification" 
                        ErrorMessage="Enter Topic" ToolTip="Enter Topic" ValidationGroup="topic" 
                        Font-Bold="True" Font-Size="Large"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="font-size: small">
                <td align="right" class="style1">
                    <asp:Button ID="btn_topic" runat="server" onclick="btn_topic_Click" 
                        Text="Submit" ValidationGroup="topic" />
                </td>
                <td align="right" style="width: 398px">
                    &nbsp;</td>
            </tr>
        </table>

        </div>
	</div>
</div>
</div>
</div>




    </asp:Panel>



</asp:Content>
