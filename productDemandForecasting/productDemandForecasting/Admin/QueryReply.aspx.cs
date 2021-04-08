using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Admin
{
    public partial class QueryReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    txtCompanyId.Disabled = true;
                    txtQuery.Disabled = true;

                    LoadQuery();
                }
            }
        }

        //function to load query details
        private void LoadQuery()
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();

            try
            {
                tab = obj.GetQueryById(int.Parse(Request.QueryString["queryId"].ToString()));

                txtCompanyId.Value = tab.Rows[0]["CompanyId"].ToString();
                txtQuery.Value = tab.Rows[0]["Query"].ToString();
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }

        }

        //click event to send reply
        protected void btnReply_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            try
            {
                obj.SendReply(txtResponse.Value, DateTime.Now, int.Parse(Request.QueryString["queryId"].ToString()));
                Response.Redirect("~/Admin/CompanyQueries.aspx");
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

    }
}