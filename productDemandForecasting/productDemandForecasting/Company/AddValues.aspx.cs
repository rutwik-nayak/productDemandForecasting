using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Company
{
    public partial class AddValues : System.Web.UI.Page
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
                    LoadCategories();
                    txtValue.Focus();
                }

                if (dropdownlistCategories.SelectedIndex > 0 && dropdownlistFeatures.SelectedIndex > 0)
                {
                    GetValues();
                }
                else
                {
                    tableValues.Rows.Clear();

                    TableHeaderRow row = new TableHeaderRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "No Values Found";
                    row.Controls.Add(cell);

                    tableValues.Controls.Add(row);
                }
                                
            }
        }

        //function to load all product categories into dropdown list -dropdownlistCategory
        private void LoadCategories()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                tab = obj.GetCategoriesByCompany(Session["CompanyId"].ToString());

                if (tab.Rows.Count > 0)
                {
                    dropdownlistCategories.DataSource = tab;
                    dropdownlistCategories.DataTextField = "CategoryName";
                    dropdownlistCategories.DataValueField = "CategoryId";

                    dropdownlistCategories.DataBind();
                    dropdownlistCategories.Items.Insert(0, "- All -");
                }
                else
                {
                    dropdownlistCategories.Items.Insert(0, "- Input Category First-");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }
                    
        protected void dropdownlistFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownlistCategories.SelectedIndex > 0 && dropdownlistFeatures.SelectedIndex > 0)
            {
                GetValues();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Category and Feature!!!')</script>");
            }

        }

        //function to retrive the feature values
        private void GetValues()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();
            int serialNo = 1;

            try
            {
                tab = obj.GetValuesByFeature(int.Parse(dropdownlistFeatures.SelectedValue));

                if (tab.Rows.Count > 0)
                {
                    tableValues.Rows.Clear();

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
                        row1cell2.Width = 400;
                        row1cell2.Text = tab.Rows[cnt]["Value"].ToString();
                        row1.Controls.Add(row1cell2);

                        TableRow row2 = new TableRow();

                        TableCell row2cell1 = new TableCell();
                        row2cell1.Width = 10;
                        row2cell1.Text = " ";
                        row2.Controls.Add(row2cell1);

                        TableCell row2Cell2 = new TableCell();
                        row2Cell2.Width = 475;
                        row2Cell2.HorizontalAlign = HorizontalAlign.Right;

                        ImageButton btnDel = new ImageButton();
                        btnDel.Width = 15;
                        btnDel.Height = 15;
                        btnDel.ImageUrl = "~/images/deletebtn.jpg";
                        btnDel.ToolTip = "Click here to Delete the Value";
                        btnDel.ID = "Value~" + tab.Rows[cnt]["ValueId"].ToString();
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

                        tableValues.Controls.Add(row1);
                        tableValues.Controls.Add(row2);
                        tableValues.Controls.Add(row3);
                    }
                }
                else
                {
                    tableValues.Rows.Clear();

                    TableHeaderRow row = new TableHeaderRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "No Values Found";
                    row.Controls.Add(cell);

                    tableValues.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to delete the feature value
        void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                obj.DeleteValue(int.Parse(s[1].ToString()));
                txtValue.Value = string.Empty;

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Feature Value Deleted Successfully!!!')</script>");
                dropdownlistFeatures_SelectedIndexChanged(sender, e);
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('First Delete Related Products!!!')</script>");
            }
        }

        protected void dropdownlistCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropdownlistCategories.SelectedIndex > 0)
                {
                    DataTable tab = new DataTable();
                    BLL obj = new BLL();

                    tableValues.Rows.Clear();
                    tab = obj.GetFeaturesByCategory(int.Parse(dropdownlistCategories.SelectedValue));

                    if (tab.Rows.Count > 0)
                    {
                        dropdownlistFeatures.Items.Clear();
                        dropdownlistFeatures.DataSource = tab;
                        dropdownlistFeatures.DataTextField = "Feature";
                        dropdownlistFeatures.DataValueField = "FeatureId";

                        dropdownlistFeatures.DataBind();
                        dropdownlistFeatures.Items.Insert(0, "- All -");
                    }
                    else
                    {
                        dropdownlistFeatures.Items.Insert(0, "- Input Features-");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Category!!!')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropdownlistCategories.SelectedIndex > 0 && dropdownlistFeatures.SelectedIndex > 0)
                {
                    BLL obj = new BLL();

                    if (obj.CheckValueName(int.Parse(dropdownlistFeatures.SelectedValue), txtValue.Value))
                    {
                        obj.InsertValue(int.Parse(dropdownlistFeatures.SelectedValue), txtValue.Value);
                        txtValue.Value = string.Empty;
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Value Inserted Successfully!!!')</script>");
                        dropdownlistFeatures_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Value Exists!!!')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Category and Feature!!!')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

    }
}