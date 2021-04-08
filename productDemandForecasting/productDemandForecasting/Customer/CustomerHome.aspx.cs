using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Customer
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    LoadCustomerDetails();
                }
            }
        }

        //click event to update Customer profile details
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            try
            {
                if (btnUpdate.Text.Equals("Edit Profile"))
                {
                    EnableControls();
                    btnUpdate.Text = "Update";

                }
                else if (btnUpdate.Text.Equals("Update"))
                {
                    obj.UpdateCustomer(txtFName.Value, txtLName.Value, txtContactNo.Value, txtEmailId.Value, Session["CustomerId"].ToString());

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Profile Updated Successfully')</script>");
                    btnUpdate.Text = "Edit Profile";

                    LoadCustomerDetails();
                }
            }
            catch
            {

            }
        }

        //function to load customer profile details
        public void LoadCustomerDetails()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                tab.Rows.Clear();
                tab = obj.GetCustomerById(Session["CustomerId"].ToString());

                txtFName.Value = tab.Rows[0]["FName"].ToString();
                txtLName.Value = tab.Rows[0]["LName"].ToString();
                txtEmailId.Value = tab.Rows[0]["EmailId"].ToString();
                txtContactNo.Value = tab.Rows[0]["Mobile"].ToString();
                lblRegisteredDate.Text = "Registered Date: " + tab.Rows[0]["RegisteredDate"].ToString();

                DisableControls();
            }
            catch
            {

            }
        }

        //functiont to disable controls
        private void DisableControls()
        {
            txtFName.Disabled = true;
            txtEmailId.Disabled = true;
            txtLName.Disabled = true;
            txtContactNo.Disabled = true;
        }

        //functiont to enable controls
        private void EnableControls()
        {
            txtFName.Disabled = false;
            txtEmailId.Disabled = false;
            txtLName.Disabled = false;
            txtContactNo.Disabled = false;
        }

    }

}
