﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="Queries.aspx.cs" Inherits="productDemandForecasting.Company.Queries" %>
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
                             &nbsp;</td>
                        <td>
                        &nbsp</td>
                        <td>
                            <asp:Button ID="btnAnswered" runat="server" onclick="btnAnswered_Click" 
                                Text="Answered Queries" />
                        </td>
                    </tr>
                </table>
                <br />
             
                <asp:Table ID="tableQueries" runat="server">
                </asp:Table>
                <br />
                  <br />

                  
                  <table style="width: 60%;">
            <tr style="font-size: small">
                <td class="style1">
                    <b>Add New Query</b></td>
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
                    <asp:TextBox ID="txtQuery" runat="server" Height="80px" TextMode="MultiLine" 
                        Width="400px"></asp:TextBox>
                </td>
                <td style="width: 398px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtQuery" CssClass="failureNotification" 
                        ErrorMessage="Enter Query" ToolTip="Enter Query" ValidationGroup="Query" 
                        Font-Size="Large"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="font-size: small">
                <td align="right">
                    <asp:Button ID="btnPostQuery" runat="server" onclick="btnPostQuery_Click" 
                        Text="Post Query" ValidationGroup="Query" />
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
</div>




    </asp:Panel>




</asp:Content>
