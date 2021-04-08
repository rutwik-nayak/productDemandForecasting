using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Guest
{
    public partial class CompanyRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //click event for the company registration
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (obj.CheckCompanyId(txtCompanyId.Value))
                {
                    string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                    int index = photoName.LastIndexOf('.');
                    string ext = photoName.Substring(index + 1);

                    string photoPath = null;
                    string dbPath = null;

                    photoPath = Server.MapPath("~/Guest/Logos/" + txtCompanyId.Value + "." + ext);
                    fileuploadPhoto.PostedFile.SaveAs(photoPath);
                    dbPath = @"/Guest/Logos/" + txtCompanyId.Value + "." + ext;

                    obj.InsertCompany(txtCompanyId.Value, txtPassword.Value, txtCompanyName.Value, txtAddress.Value, txtCity.Value, txtContactNo.Value, txtEmailId.Value,
                        txtWebsiteAddress.Value, dbPath, txtReceiptNumber.Value, DateTime.Now, "Pending");
                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Registration Successfull!!!')</script>");
                    ClearTxts();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('CompanyId already exisits!!!')</script>");
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
            txtAddress.Value = txtCity.Value = txtCompanyId.Value = txtCompanyName.Value = txtContactNo.Value = txtReceiptNumber.Value = txtWebsiteAddress.Value = txtEmailId.Value= string.Empty;

        }
    }
}