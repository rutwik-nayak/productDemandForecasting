using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Guest
{
    public partial class Companies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetApprovedCompanies();
        }

        //function to retrive approved companies
        private void GetApprovedCompanies()
        {
            try
            {
                BLL obj = new BLL();
                DataTable tab = new DataTable();

                tab = obj.GetCompaniesByStatus("Approved");

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
                    cell1.Text = "<b>Logo</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Company Name</b>";
                    headerrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Email Id</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Website Address</b>";
                    headerrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>Phone No</b>";
                    headerrow.Controls.Add(cell5);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>RegisteredDate</b>";
                    headerrow.Controls.Add(cell6);

                    tableCompanies.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();

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

                        TableCell cellCompanyName = new TableCell();
                        cellCompanyName.Width = 200;
                        cellCompanyName.Text = "<a href='#'>" + tab.Rows[cnt]["CompanyName"].ToString() + "<span>CName : " + tab.Rows[cnt]["CompanyName"].ToString() + ".</br>Address : " + tab.Rows[cnt]["Address"].ToString() + ".</br>City : " + tab.Rows[cnt]["City"].ToString() + "</span></a>";
                        row.Controls.Add(cellCompanyName);

                        TableCell cellEmailId = new TableCell();
                        cellEmailId.Width = 200;
                        cellEmailId.Text = tab.Rows[cnt]["EmailId"].ToString();
                        row.Controls.Add(cellEmailId);

                        TableCell cellWebsiteAddress = new TableCell();
                        cellWebsiteAddress.Width = 250;
                        cellWebsiteAddress.Text = tab.Rows[cnt]["WebsiteAddress"].ToString();
                        row.Controls.Add(cellWebsiteAddress);

                        TableCell cellPhone = new TableCell();
                        cellPhone.Width = 150;
                        cellPhone.Text = tab.Rows[cnt]["ContactNo"].ToString();
                        row.Controls.Add(cellPhone);

                        TableCell cellRegisteredDate = new TableCell();
                        cellRegisteredDate.Width = 100;
                        string[] s = tab.Rows[cnt]["RegisteredDate"].ToString().Split(' ');
                        cellRegisteredDate.Text = s[0];
                        row.Controls.Add(cellRegisteredDate);

                        tableCompanies.Controls.Add(row);

                    }
                }
                else
                {
                    tableCompanies.Rows.Clear();
                    tableCompanies.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    //cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "<b>No Registered Companies Found</b>";
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

    }
}