using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Admin
{
    public partial class AdminHome : System.Web.UI.Page
    {
        DataTable tab = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
            else
            {
                GetPendingCompanies();
            }

        }
        
        //function to retrive pending companies
        private void GetPendingCompanies()
        {
            try
            {
                BLL obj = new BLL();

                tab = obj.GetCompaniesByStatus("Pending");

                if (tab.Rows.Count > 0)
                {
                    tableCompanies.Rows.Clear();

                    tableCompanies.BorderStyle = BorderStyle.Double;
                    tableCompanies.GridLines = GridLines.Both;
                    tableCompanies.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>Check</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Company Name</b>";
                    headerrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Email Id</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>Phone No</b>";
                    headerrow.Controls.Add(cell5);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>ReceiptNo</b>";
                    headerrow.Controls.Add(cell6);

                    TableCell cell7 = new TableCell();
                    cell7.Text = "<b>RegisteredDate</b>";
                    headerrow.Controls.Add(cell7);

                    TableCell cell8 = new TableCell();
                    cell8.Text = "<b>Logo</b>";
                    headerrow.Controls.Add(cell8);

                    tableCompanies.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 30;

                        TableCell cell_Check = new TableCell();
                        CheckBox che = new CheckBox();
                        che.ID = tab.Rows[cnt]["CompanyId"].ToString();

                        cell_Check.Controls.Add(che);
                        row.Controls.Add(cell_Check);

                        TableCell cellCompanyName = new TableCell();
                        cellCompanyName.Width = 200;
                        cellCompanyName.Text = "<a href='#'>" + tab.Rows[cnt]["CompanyName"].ToString() + "<span>CName : " + tab.Rows[cnt]["CompanyName"].ToString() + ".</br>Address : " + tab.Rows[cnt]["Address"].ToString() + ".</br>City : " + tab.Rows[cnt]["City"].ToString() + ".</br>Website : " + tab.Rows[cnt]["WebsiteAddress"].ToString() + "</span></a>";
                        row.Controls.Add(cellCompanyName);

                        TableCell cellEmailId = new TableCell();
                        cellEmailId.Width = 200;
                        cellEmailId.Text = tab.Rows[cnt]["EmailId"].ToString();
                        row.Controls.Add(cellEmailId);

                        TableCell cellPhone = new TableCell();
                        cellPhone.Width = 150;
                        cellPhone.Text = tab.Rows[cnt]["ContactNo"].ToString();
                        row.Controls.Add(cellPhone);

                        TableCell cellReceipt = new TableCell();
                        cellReceipt.Width = 150;
                        cellReceipt.Text = tab.Rows[cnt]["ReceiptNo"].ToString();
                        row.Controls.Add(cellReceipt);

                        TableCell cellRegisteredDate = new TableCell();
                        cellRegisteredDate.Width = 100;
                        string[] s = tab.Rows[cnt]["RegisteredDate"].ToString().Split(' ');
                        cellRegisteredDate.Text = s[0];
                        row.Controls.Add(cellRegisteredDate);

                        TableCell cellPhoto = new TableCell();
                        cellPhoto.VerticalAlign = VerticalAlign.Top;
                        cellPhoto.Width = 50;
                        cellPhoto.Height = 50;
                        Image imgPhoto = new Image();
                        imgPhoto.Width = 50;
                        imgPhoto.Height = 50;
                        imgPhoto.ImageUrl = tab.Rows[cnt]["Logo"].ToString();
                        cellPhoto.Controls.Add(imgPhoto);
                        row.Controls.Add(cellPhoto);

                        tableCompanies.Controls.Add(row);

                    }
                }
                else
                {
                    tableCompanies.Rows.Clear();
                    tableCompanies.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "<b>No Pending Companies Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    tableCompanies.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to approve the selected companies [newly registered]
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab1 = new DataTable();

            try
            {
                int q = 0;

                if (CheckSelection())
                {
                    for (int i = 1; i < tableCompanies.Rows.Count; i++)
                    {
                        CheckBox chk = (CheckBox)tableCompanies.FindControl(tab.Rows[q]["CompanyId"].ToString());

                        //tab1 = obj.GetCompanyById(chk.ID.ToString());

                        if (chk.Checked)
                        {
                            obj.CompanyApproval("Approved", chk.ID.ToString());
                            //Emails.MailSender.SendEmail("sender email id", "password", tab1.Rows[0]["EmailId"].ToString(), "Approved", "Registration Details Approved Successfully", "");
                        }
                        ++q;

                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Companies Approved Successfully')</script>");
                    GetPendingCompanies();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Select the Companies')</script>");

                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to reject the selected companies [newly registered]
        protected void btnReject_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab1 = new DataTable();

            try
            {
                int q = 0;

                if (CheckSelection())
                {
                    for (int i = 1; i < tableCompanies.Rows.Count; i++)
                    {
                        CheckBox chk = (CheckBox)tableCompanies.FindControl(tab.Rows[q]["CompanyId"].ToString());
                        //tab1 = obj.GetCompanyById(chk.ID.ToString());

                        if (chk.Checked)
                        {
                            obj.DeleteCompany(chk.ID.ToString());
                            //Emails.MailSender.SendEmail("sender email id", "password", tab1.Rows[0]["EmailId"].ToString(), "Rejected", "Registration Details Rejected Successfully", "");
                        }
                        ++q;

                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Companies Rejected Successfully')</script>");
                    GetPendingCompanies();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Select the Companies')</script>");

                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //function to check the companies selection
        public bool CheckSelection()
        {
            int q = 0;

            foreach (TableRow row in tableCompanies.Rows)
            {
                if (q < tableCompanies.Rows.Count - 1)
                {
                    CheckBox chk = (CheckBox)row.FindControl(tab.Rows[q]["CompanyId"].ToString());

                    if (chk.Checked)
                    {
                        return true; ;
                    }

                    ++q;
                }
            }

            return false;
        }
        
    }
}