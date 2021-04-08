using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace productDemandForecasting.Guest
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //click event for the customer registration
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (obj.CheckCustomerId(txtCustomerId.Value))
                {
                    obj.InsertCustomer(txtCustomerId.Value, txtPassword.Value, txtFName.Value, txtLName.Value, txtContactNo.Value, txtEmailId.Value, DateTime.Now);
                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Registration Successfull!!!')</script>");
                    ClearTxts();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('CustomerId already exists!!!')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }

        }

        //function to clear the textbox contents
        private void ClearTxts()
        {
            txtFName.Value = txtLName.Value = txtCustomerId.Value = txtContactNo.Value = txtEmailId.Value = string.Empty;

        }
    }
}