<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="_SmartphoneDemand.aspx.cs" Inherits="productDemandForecasting.Company._SmartphoneDemand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelAboutus" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Smart Phones Demand Prediction Using Naive Bayes Algorithm</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
			
             <div class="registration_form">
            <br />
 <div style="height:500px; width:auto; overflow:auto">
<asp:GridView ID="GridView1" runat="server" BackColor="White" 
         BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" BorderStyle="None" 
         Width="650px">

    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <PagerStyle ForeColor="#000066" 
        HorizontalAlign="Left" BackColor="White" />
    <RowStyle ForeColor="#000066" />
    <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#007DBB" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#00547E" />

</asp:GridView>
</div>
          <br />
          <br />

           <h1><span>DEMAND </span>PREDICTION USING NAIVE BAYES ALGORITHM!!!</h1>
          <hr />

          <br />
          <asp:Button ID="btnPrediction" runat="server" 
                      Text="Click Here to Predict Demand" 
              onclick="btnPrediction_Click" CssClass="btn" /> &nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnResults" runat="server" CssClass="btn" 
              onclick="btnResults_Click" Text="Find Accuracy" />
          <br /><br /><div>

          <h1>0 - Loss, 1- Less Profit, 2- Medium Profit and 3- High Profit</h1>
          <br />
      <asp:Table ID="tablePrediction" runat="server">
      </asp:Table>
      </div>
          <br />


          </div>

	</div>
</div>
</div>
</div>


    </asp:Panel>


</asp:Content>
