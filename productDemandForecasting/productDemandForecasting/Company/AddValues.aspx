<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMasterPage.Master" AutoEventWireup="true" CodeBehind="AddValues.aspx.cs" Inherits="productDemandForecasting.Company.AddValues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelFeatures" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">manage features values</h4>
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
      <a href="#"><div class="reg_fb"><i>add values</i><div class="clear"></div></div></a>
		 <div class="registration_form">

                <div>
					<label>
                       <asp:DropDownList ID="dropdownlistCategories" runat="server" 
                                                      AutoPostBack="True" 
                                                      onselectedindexchanged="dropdownlistCategories_SelectedIndexChanged" 
                                                      Width="95%">
                                                  </asp:DropDownList>
                        
                         <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                      ControlToValidate="dropdownlistCategories" CssClass="failureNotification" 
                                                      ErrorMessage="Select Category" 
                        Operator="NotEqual" ToolTip="Select Category" 
                                                      ValidationGroup="a" ValueToCompare="- All -" 
                        ForeColor="#FF3300"></asp:CompareValidator>
						
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               
                <div>
					<label>
                       <asp:DropDownList ID="dropdownlistFeatures" runat="server" 
                                                      AutoPostBack="True" 
                                                      Width="95%" 
                        onselectedindexchanged="dropdownlistFeatures_SelectedIndexChanged">
                                                  </asp:DropDownList>
                        
                         <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                      ControlToValidate="dropdownlistFeatures" CssClass="failureNotification" 
                                                      ErrorMessage="Select Feature" 
                        Operator="NotEqual" ToolTip="Select Feature" 
                                                      ValidationGroup="a" ValueToCompare="- All -" 
                        ForeColor="#FF3300"></asp:CompareValidator>
						
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               					
				<div>
					<label>
						<input placeholder="value:" type="text" tabindex="3" runat="server" id="txtValue">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Enter Value" ControlToValidate="txtValue" 
                        CssClass="failureNotification" ToolTip="Enter Value" 
                        ValidationGroup="a" ForeColor="#FF3300"></asp:RequiredFieldValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               
				<div>
                 <asp:Button ID="btnAdd" runat="server" tabindex="4" Text="Add" 
                        ValidationGroup="a" onclick="btnAdd_Click" 
                        />
					
				</div>
		
		</div>

        <br />

         <a href="#"><div class="reg_fb"><i>view values</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 					
				<div>
					<div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                        <asp:Table ID="tableValues" runat="server" HorizontalAlign="Center">
                        </asp:Table>
                        </div>
                        </div>


				</div>
			
		</div>


	</div>
	</div>

	</div>
	<div class="clear"></div>
</div>
</div>
</div>



    </asp:Panel>


</asp:Content>
