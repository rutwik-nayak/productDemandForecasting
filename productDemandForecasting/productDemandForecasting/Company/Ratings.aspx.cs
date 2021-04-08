using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Company
{
    public partial class Ratings : System.Web.UI.Page
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
                lblProductName.Text = "Product Name: " + Request.QueryString["productName"].ToString() + "<br/>";
                GetCustomerRatings();
            }         
        }

        //function to retrive customer ratings based on product
        private void GetCustomerRatings()
        {
            BLL obj = new BLL();
            DataTable tabRatings = new DataTable();

            try
            {
                tabRatings = obj.GetRatingsByProduct(int.Parse(Request.QueryString["productId"].ToString()));

                if (tabRatings.Rows.Count > 0)
                {
                    tableCustomers.Rows.Clear();

                    tableCustomers.BorderStyle = BorderStyle.Double;
                    tableCustomers.GridLines = GridLines.Both;
                    tableCustomers.BorderColor = System.Drawing.Color.Black;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>First Name</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Last Name</b>";
                    headerrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Email Id</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Phone No</b>";
                    headerrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>RegisteredDate</b>";
                    headerrow.Controls.Add(cell5);

                    TableCell cell7 = new TableCell();
                    cell7.Text = "Ratings";
                    headerrow.Controls.Add(cell7);

                    tableCustomers.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tabRatings.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 35;

                        DataTable tabCustomer = new DataTable();
                        tabCustomer = obj.GetCustomerById(tabRatings.Rows[cnt]["CustomerId"].ToString());

                        TableCell cellFName = new TableCell();
                        cellFName.Width = 150;
                        cellFName.Text = tabCustomer.Rows[0]["FName"].ToString();
                        row.Controls.Add(cellFName);

                        TableCell cellLName = new TableCell();
                        cellLName.Width = 100;
                        cellLName.Text = tabCustomer.Rows[0]["LName"].ToString();
                        row.Controls.Add(cellLName);

                        TableCell cellEmailId = new TableCell();
                        cellEmailId.Width = 200;
                        cellEmailId.Text = tabCustomer.Rows[0]["EmailId"].ToString();
                        row.Controls.Add(cellEmailId);

                        TableCell cellPhone = new TableCell();
                        cellPhone.Width = 200;
                        cellPhone.Text = tabCustomer.Rows[0]["Mobile"].ToString();
                        row.Controls.Add(cellPhone);

                        TableCell cellRegisteredDate = new TableCell();
                        cellRegisteredDate.Width = 100;
                        string[] s = tabCustomer.Rows[0]["RegisteredDate"].ToString().Split(' ');
                        cellRegisteredDate.Text = s[0];
                        row.Controls.Add(cellRegisteredDate);

                        TableCell cellRatings = new TableCell();
                        cellRatings.Width = 200;
                        cellRatings.Text = tabRatings.Rows[cnt]["Rating"].ToString();
                        row.Controls.Add(cellRatings);

                        tableCustomers.Controls.Add(row);
                    }
                }
                else
                {
                    tableCustomers.Rows.Clear();
                    tableCustomers.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "<b>No Product Ratings Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    tableCustomers.Controls.Add(row);
                }
            }
            catch
            {

            }
        }

    }
}