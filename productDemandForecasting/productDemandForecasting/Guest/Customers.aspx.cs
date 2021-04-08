using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Guest
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRegisteredCustomers();
        }

        //function to retrive registered customers
        private void GetRegisteredCustomers()
        {
            try
            {
                BLL obj = new BLL();
                DataTable tab = new DataTable();

                tab = obj.GetAllCustomers();

                if (tab.Rows.Count > 0)
                {
                    tableCustomers.Rows.Clear();

                    tableCustomers.GridLines = GridLines.Both;
                    tableCustomers.BorderColor = System.Drawing.Color.Black;
                    tableCustomers.BorderStyle = BorderStyle.Double;

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

                    tableCustomers.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 35;

                        TableCell cellFirstName = new TableCell();
                        cellFirstName.Width = 150;
                        cellFirstName.Text = tab.Rows[cnt]["FName"].ToString();
                        row.Controls.Add(cellFirstName);

                        TableCell cellLName = new TableCell();
                        cellLName.Width = 150;
                        cellLName.Text = tab.Rows[cnt]["LName"].ToString();
                        row.Controls.Add(cellLName);

                        TableCell cellEmailId = new TableCell();
                        cellEmailId.Width = 200;
                        cellEmailId.Text = tab.Rows[cnt]["EmailId"].ToString();
                        row.Controls.Add(cellEmailId);

                        TableCell cellPhone = new TableCell();
                        cellPhone.Width = 100;
                        cellPhone.Text = tab.Rows[cnt]["Mobile"].ToString();
                        row.Controls.Add(cellPhone);

                        TableCell cellRegisteredDate = new TableCell();
                        cellRegisteredDate.Width = 200;
                        cellRegisteredDate.Text = tab.Rows[cnt]["RegisteredDate"].ToString();
                        row.Controls.Add(cellRegisteredDate);

                        tableCustomers.Controls.Add(row);
                    }
                }
                else
                {
                    tableCustomers.Rows.Clear();
                    tableCustomers.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    //cell.ColumnSpan = 10;
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
    }
}