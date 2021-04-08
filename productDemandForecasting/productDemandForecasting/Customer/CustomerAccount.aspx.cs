using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Customer
{
    public partial class CustomerAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
        }

        //click event to update the customer password
        protected void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();
                tab.Rows.Clear();

                tab = obj.GetCustomerById(Session["CustomerId"].ToString());
                string oldPassword = tab.Rows[0]["Password"].ToString();

                if (txtOldPassword.Value.Equals(oldPassword))
                {
                    obj.UpdateCustomerPassword(Session["CustomerId"].ToString(), txtNewPassword.Value);
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Customer Password changed successfully')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Customer Old password incorrect')</script>");
                }
            }
            catch
            {

            }
        }


    }
}