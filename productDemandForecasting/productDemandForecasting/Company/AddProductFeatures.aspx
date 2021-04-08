<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="AddProductFeatures.aspx.cs" Inherits="productDemandForecasting.AddProductFeatures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelProductFeatures" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">manage product features</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	
	<div class="login_left">
		
	<!-- start registration -->
	<div class="registration">
		<!-- [if IE] 
		    < link rel='stylesheet' type='text/css' href='ie.css'/>  
		 [endif] -->  
		  
		<!-- [if lt IE 7]>  
		    < link rel='stylesheet' type='text/css' href='ie6.css'/>  
		<! [endif] -->  
		<script>
		    (function () {

		        // Create input element for testing
		        var inputs = document.createElement('input');

		        // Create the supports object
		        var supports = {};

		        supports.autofocus = 'autofocus' in inputs;
		        supports.required = 'required' in inputs;
		        supports.placeholder = 'placeholder' in inputs;

		        // Fallback for autofocus attribute
		        if (!supports.autofocus) {

		        }

		        // Fallback for required attribute
		        if (!supports.required) {

		        }

		        // Fallback for placeholder attribute
		        if (!supports.placeholder) {

		        }

		        // Change text inside send button on submit
		        var send = document.getElementById('register-submit');
		        if (send) {
		            send.onclick = function () {
		                this.innerHTML = '...Sending';
		            }
		        }

		    })();
		</script>
	<div class="registration_left">
		<a href="#"><div class="reg_fb"><i>Name of the Product</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 <!-- Form -->
			
				<div>
					<label>
						<input placeholder="Product Name/Id:" type="text" tabindex="1" required="" autofocus="" runat="server" id="txtProductName">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                
				</div>

               <a href="#"><div class="reg_fb"><i>Product Features</i></div></a>
		 <div class="registration_form">
		 					
				<div>
					<div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                        <asp:Table ID="tableFeatures" runat="server">
                        </asp:Table>
                        </div>
                        </div>


				</div>
			
	

        	<div>

             <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSet" runat="server" tabindex="3" Text="Set" onclick="btnSet_Click"  
                        />
					
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnPredict" runat="server" tabindex="4" Text="Predict Demand" onclick="btnPredict_Click"  
                        />
					
                        </td>
                         <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" tabindex="5" Text="Delete" 
                                onclick="btnDelete_Click" onclientclick="return confirm('are u sure want to delete product features?')"   
                        />
					
                        </td>
                    </tr>
                </table>

                 	</div>
				</div>
                               
					
			<!-- /Form -->
		
	</div>
	</div>
	<!-- end registration -->
	</div>

    <div class="login_left">
		
	<!-- start registration -->
	<div class="registration">
		
	<div class="registration_left">
		<a href="#"><div class="reg_fb"><i>Similar Products Dataset</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 
				<div>
					<label>
						<input placeholder="Data Set:" type="text" tabindex="1" required="" autofocus="" runat="server" id="txtDataSet">
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div ID="Div1">
                        <div style="height:400px; width:auto; overflow:auto">
                            <asp:Table ID="tableDataset" runat="server" HorizontalAlign="Center">
                            </asp:Table>
                            <br />
                            <br />
                            <asp:Table ID="Table5" runat="server">
                            </asp:Table>
                        </div>
                    </div>
                </div>
                
              
		</div>

        
	</div>
	</div>
	<!-- end registration -->
	</div>


	<div class="clear"></div>
</div>
</div>
</div>



    </asp:Panel>
</asp:Content>
