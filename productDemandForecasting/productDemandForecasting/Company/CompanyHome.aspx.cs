using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace productDemandForecasting.Company
{
    public partial class CompanyHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    LoadCompanyDetails();
                }
            }
        }

        //click event to update Company profile details
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (btnUpdate.Text.Equals("Edit Profile"))
            {
                EnableControls();
                btnUpdate.Text = "Update";

            }
            else if (btnUpdate.Text.Equals("Update"))
            {
                if (fileuploadPhoto.Enabled)
                {
                    File.Delete(Server.MapPath(Session["oldDBPath"].ToString()));
                    string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                    int index = photoName.LastIndexOf('.');
                    string ext = photoName.Substring(index + 1);

                    string phtotPath = Server.MapPath("/Guest/Logos/" + Session["CompanyId"].ToString() + "." + ext);
                    fileuploadPhoto.PostedFile.SaveAs(phtotPath);

                    string dbPath = "~/Guest/Logos/" + Session["CompanyId"].ToString() + "." + ext;

                    obj.UpdateCompanyProfile(txtAddress.Value, txtCity.Value, txtContactNo.Value, txtEmailId.Value, txtWebsiteAddress.Value, dbPath, Session["CompanyId"].ToString());

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Profile Updated Successfully')</script>");
                    btnUpdate.Text = "Edit Profile";

                    LoadCompanyDetails();

                }
                else
                {
                    obj.UpdateCompanyProfile(txtAddress.Value, txtCity.Value, txtContactNo.Value, txtEmailId.Value, txtWebsiteAddress.Value, Session["oldDBPath"].ToString(), Session["CompanyId"].ToString());

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Profile Updated Successfully')</script>");
                    btnUpdate.Text = "Edit Profile";

                    LoadCompanyDetails();

                }
            }
        }

        //click event to enable fileupload component
        protected void lbtnChangephoto_Click(object sender, EventArgs e)
        {
            fileuploadPhoto.Enabled = true;
            RequiredFieldValidator9.Enabled = true;
            RegularExpressionValidator2.Enabled = true;
        }

        //function to load company profile details
        public void LoadCompanyDetails()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab.Rows.Clear();
            tab = obj.GetCompanyById(Session["CompanyId"].ToString());

            txtCity.Value = tab.Rows[0]["City"].ToString();
            txtAddress.Value = tab.Rows[0]["Address"].ToString();
            txtEmailId.Value = tab.Rows[0]["EmailId"].ToString();
            txtContactNo.Value = tab.Rows[0]["ContactNo"].ToString();
            txtWebsiteAddress.Value = tab.Rows[0]["WebsiteAddress"].ToString();
            lblRegisteredDate.Text = "Registered Date: " + tab.Rows[0]["RegisteredDate"].ToString();
            imgPhoto.ImageUrl = tab.Rows[0]["Logo"].ToString();
            Session["oldDBPath"] = null;
            Session["oldDBPath"] = tab.Rows[0]["Logo"].ToString();

            DisableControls();

        }

        //functiont to disable controls
        private void DisableControls()
        {
            txtAddress.Disabled = true;
            txtEmailId.Disabled = true;
            txtCity.Disabled = true;
            txtContactNo.Disabled = true;
            fileuploadPhoto.Enabled = false;
            lbtnChangephoto.Enabled = false;

            RequiredFieldValidator9.Enabled = false;
            RegularExpressionValidator2.Enabled = false;
        }

        //functiont to enable controls
        private void EnableControls()
        {
            txtAddress.Disabled = false;
            txtEmailId.Disabled = false;
            txtCity.Disabled = false;
            txtContactNo.Disabled = false;
            fileuploadPhoto.Enabled = false;
            lbtnChangephoto.Enabled = true;

            RequiredFieldValidator9.Enabled = false;
            RegularExpressionValidator2.Enabled = false;
        }

    }
}