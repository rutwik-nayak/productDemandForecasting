using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Company
{
    public partial class Features : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
        }

        protected void btnAddFeature_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/AddFeatures.aspx");
        }

        protected void btnAddValue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/AddValues.aspx");
        }

    

    }
}