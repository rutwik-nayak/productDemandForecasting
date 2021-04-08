using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Company
{
    public partial class Categories : System.Web.UI.Page
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
                GetCategories();
            }
        }

        //function to get categories
        private void GetCategories()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                tab = obj.GetCategoriesByCompany(Session["CompanyId"].ToString());

                if (tab.Rows.Count > 0)
                {
                    tableCategories.Rows.Clear();

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row1 = new TableRow();

                        TableCell row1cell1 = new TableCell();
                        row1cell1.Width = 10;
                        row1cell1.Font.Size = 10;
                        row1cell1.Text = serialNo + cnt + ".";
                        row1.Controls.Add(row1cell1);

                        TableCell row1cell2 = new TableCell();
                        row1cell2.HorizontalAlign = HorizontalAlign.Left;
                        row1cell2.Width = 475;
                        row1cell2.Text = tab.Rows[cnt]["CategoryName"].ToString();
                        row1.Controls.Add(row1cell2);

                        TableRow row2 = new TableRow();

                        TableCell row2cell1 = new TableCell();
                        row2cell1.Width = 10;
                        row2cell1.Text = " ";
                        row2.Controls.Add(row2cell1);

                        TableCell row2Cell2 = new TableCell();
                        row2Cell2.Width = 400;
                        row2Cell2.HorizontalAlign = HorizontalAlign.Right;

                        ImageButton btnDel = new ImageButton();
                        btnDel.Width = 15;
                        btnDel.Height = 15;
                        btnDel.ImageUrl = "~/images/deletebtn.jpg";
                        btnDel.ToolTip = "Click here to Delete the Category";
                        btnDel.ID = "Category~" + tab.Rows[cnt]["CategoryId"].ToString();
                        btnDel.OnClientClick = "return confirm('Are you sure do you want to Delete?')";
                        btnDel.Click += new ImageClickEventHandler(btnDel_Click);

                        row2Cell2.Controls.Add(btnDel);
                        row2.Controls.Add(row2Cell2);

                        TableRow row3 = new TableRow();
                        TableCell row3cell1 = new TableCell();
                        row3cell1.Width = 10;
                        row3cell1.Text = " ";
                        row3.Controls.Add(row3cell1);

                        TableCell row3cell2 = new TableCell();
                        row3cell2.Width = 400;
                        row3cell2.Text = "<hr/>";
                        row3.Controls.Add(row3cell2);

                        tableCategories.Controls.Add(row1);
                        tableCategories.Controls.Add(row2);
                        tableCategories.Controls.Add(row3);
                    }
                }
                else
                {
                    tableCategories.Rows.Clear();

                    TableHeaderRow row = new TableHeaderRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "No Categories Found";
                    row.Controls.Add(cell);

                    tableCategories.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }

        }

        //click event to delete the category
        void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                obj.DeleteCategory(int.Parse(s[1].ToString()));
                
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Category Deleted Successfully!!!')</script>");
                ClearTextboxes();
                GetCategories();
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Deletion Error!!!(Firts Delete Related Things)')</script>");
            }
        }   
                     
        //function to clear the textboxes
        private void ClearTextboxes()
        {
            txtCategoryName.Value = string.Empty;
        }

        //click event to insert the new category
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (obj.CheckCategoryName(Session["CompanyId"].ToString(),txtCategoryName.Value))
                {
                    obj.InsertCategory(Session["CompanyId"].ToString(), txtCategoryName.Value);
                    ClearTextboxes();
                    GetCategories();

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('New Category Added Successfully')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Category Name Already Exists!!!')</script>");
                }

            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }

        }

    }
}