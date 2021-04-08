using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Guest
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                radiobtnAdmin.Checked = true;
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (radiobtnAdmin.Checked == true)
                {
                    if (obj.CheckAdminLogin(txtUserId.Value, txtPassword.Value))
                    {
                        Session["AdminId"] = txtUserId.Value;
                        Response.Redirect("~/Admin/AdminHome.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Invalid admin id/password!!!')</script>");
                    }
                }
                else if (radiobtnCompany.Checked == true)
                {
                    if (obj.CheckCompanyLogin(txtUserId.Value, txtPassword.Value))
                    {
                        Session["CompanyId"] = txtUserId.Value;
                        Response.Redirect("~/Company/CompanyHome.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Invalid company id/password/not yet approved!!!')</script>");
                    }
                }
                else if (radiobtnCustomer.Checked == true)
                {
                    if (obj.CheckCustomerLogin(txtUserId.Value, txtPassword.Value))
                    {
                        Session["CustomerId"] = txtUserId.Value;
                        Response.Redirect("~/Customer/CustomerHome.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Invalid customer id/password!!!')</script>");
                    }
                }
                //else
                //{
                //    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Select the type of user!!!')</script>");
                //}
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }
    }
}