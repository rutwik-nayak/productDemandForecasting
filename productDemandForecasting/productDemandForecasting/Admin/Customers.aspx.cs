using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Admin
{
    public partial class Customers : System.Web.UI.Page
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
                GetCustomers();
            }
        }


        //function to retrive registered customers
        private void GetCustomers()
        {
            try
            {
                BLL obj = new BLL();
                DataTable tab = new DataTable();

                tab = obj.GetAllCustomers();

                if (tab.Rows.Count > 0)
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
                    cell7.Text = "Delete";
                    headerrow.Controls.Add(cell7);

                    tableCustomers.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 35;

                        TableCell cellFName = new TableCell();
                        cellFName.Width = 150;
                        cellFName.Text = tab.Rows[cnt]["FName"].ToString();
                        row.Controls.Add(cellFName);

                        TableCell cellLName = new TableCell();
                        cellLName.Width = 100;
                        cellLName.Text = tab.Rows[cnt]["LName"].ToString();
                        row.Controls.Add(cellLName);

                        TableCell cellEmailId = new TableCell();
                        cellEmailId.Width = 200;
                        cellEmailId.Text = tab.Rows[cnt]["EmailId"].ToString();
                        row.Controls.Add(cellEmailId);

                        TableCell cellPhone = new TableCell();
                        cellPhone.Width = 200;
                        cellPhone.Text = tab.Rows[cnt]["Mobile"].ToString();
                        row.Controls.Add(cellPhone);

                        TableCell cellRegisteredDate = new TableCell();
                        cellRegisteredDate.Width = 100;
                        string[] s = tab.Rows[cnt]["RegisteredDate"].ToString().Split(' ');
                        cellRegisteredDate.Text = s[0];
                        row.Controls.Add(cellRegisteredDate);

                        TableCell cellDelete = new TableCell();

                        ImageButton btnDelete = new ImageButton();
                        btnDelete.ID = tab.Rows[cnt]["CustomerId"].ToString();
                        btnDelete.Width = 25;
                        btnDelete.Height = 25;
                        btnDelete.ImageUrl = "~/images/delete6.png";
                        btnDelete.OnClientClick = "return confirm('Are you sure want to delete?')";
                        btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);
                        cellDelete.Controls.Add(btnDelete);
                        row.Controls.Add(cellDelete);

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
                    cell.Text = "<b>No Registered Customers Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    tableCustomers.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to delete the customer registration details
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            BLL obj = new BLL();
            ImageButton imgbtn = (ImageButton)sender;
            try
            {
                obj.DeleteCustomerRatings(imgbtn.ID);
                obj.DeleteCustomer(imgbtn.ID);

                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Customer and related details deleted successfully')</script>");
                GetCustomers();
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }
                
    }
}