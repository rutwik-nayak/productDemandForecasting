using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Company
{
    public partial class AddFeatures : System.Web.UI.Page
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
                    txtFeature.Focus();
                }

                GetFeatures();
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
                    dropdownlistCategories.Items.Insert(0, "- Input Types First-");
                }

            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //function to get all features
        private void GetFeatures()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                if (dropdownlistCategories.SelectedIndex > 0)
                {
                    tab = obj.GetFeaturesByCategory(int.Parse(dropdownlistCategories.SelectedValue));
                }
                else
                {
                    tab = obj.GetFeaturesByCompany(Session["CompanyId"].ToString());
                }

                if (tab.Rows.Count > 0)
                {
                    tableFeatures.Rows.Clear();

                    tableFeatures.BorderStyle = BorderStyle.Double;
                    tableFeatures.GridLines = GridLines.Both;
                    tableFeatures.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SLNo</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Category Name</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Feature Name</b>";
                    headerrow.Controls.Add(cell4);

                    if (dropdownlistCategories.SelectedIndex > 0)
                    {
                        TableCell cell6 = new TableCell();
                        cell6.Text = "<b>Edit</b>";
                        headerrow.Controls.Add(cell6);

                        TableCell cell7 = new TableCell();
                        cell7.Text = "<b>Delete</b>";
                        headerrow.Controls.Add(cell7);
                    }
                    else
                    {

                    }

                    tableFeatures.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 30;

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 10;
                        cellSerialNo.Font.Size = 10;
                        cellSerialNo.Text = serialNo + cnt + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellType = new TableCell();
                        cellType.Width = 150;

                        DataTable tabCategory = new DataTable();
                        tabCategory = obj.GetCategoryById(int.Parse(tab.Rows[cnt]["CategoryId"].ToString()));

                        cellType.Text = tabCategory.Rows[0]["CategoryName"].ToString();
                        row.Controls.Add(cellType);

                        TableCell cellSubcategory = new TableCell();
                        cellSubcategory.Width = 250;
                        cellSubcategory.Text = tab.Rows[cnt]["Feature"].ToString();
                        row.Controls.Add(cellSubcategory);
                        
                        if (dropdownlistCategories.SelectedIndex > 0)
                        {
                            TableCell cellEdit = new TableCell();

                            ImageButton btnEdit = new ImageButton();
                            btnEdit.Width = 15;
                            btnEdit.Height = 15;
                            btnEdit.ImageUrl = "~/images/edit-10-xxl.png";
                            btnEdit.ToolTip = "Click here to Edit the feature";
                            btnEdit.ID = "FeatureEdit~" + tab.Rows[cnt]["FeatureId"].ToString();
                            btnEdit.Click += new ImageClickEventHandler(btnEdit_Click);

                            cellEdit.Controls.Add(btnEdit);
                            row.Controls.Add(cellEdit);

                            TableCell cellDelete = new TableCell();

                            ImageButton btnDelete = new ImageButton();
                            btnDelete.Width = 15;
                            btnDelete.Height = 15;
                            btnDelete.ImageUrl = "~/images/delete6.png";
                            btnDelete.ToolTip = "Click here to Delete the feature";
                            btnDelete.ID = "FeatureeDelete~" + tab.Rows[cnt]["FeatureId"].ToString();
                            btnDelete.OnClientClick = "return confirm('Are you sure do you want to Delete?')";
                            btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                            cellDelete.Controls.Add(btnDelete);
                            row.Controls.Add(cellDelete);
                        }
                        else
                        {

                        }

                        tableFeatures.Controls.Add(row);
                    }

                }
                else
                {
                    tableFeatures.Rows.Clear();
                    tableFeatures.BorderStyle = BorderStyle.None;

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 5;
                    cell.Font.Bold = true;
                    cell.ForeColor = System.Drawing.Color.Red;
                    if (dropdownlistCategories.SelectedIndex > 0)
                    {
                        cell.Text = "No Features Found " + "for " + dropdownlistCategories.SelectedItem.Text;
                    }
                    else
                    {
                        cell.Text = "No Features Found";
                    }
                    row.Controls.Add(cell);
                    tableFeatures.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }

        }

        //click event to delete feature details
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                obj.DeleteFeature(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Feature Deleted Successfully!!!')</script>");
                GetFeatures();
                btnAdd.Text = "Add";
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('First Delete Related Products!!!')</script>");
            }
        }

        //click event to edit feature details
        void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                DataTable tabFeature = new DataTable();
                BLL obj = new BLL();

                tabFeature = obj.GetFeatureById(int.Parse(s[1].ToString()));

                txtFeature.Value = tabFeature.Rows[0]["Feature"].ToString();

                int featureId = int.Parse(tabFeature.Rows[0]["FeatureId"].ToString());
                int categoryId = int.Parse(tabFeature.Rows[0]["CategoryId"].ToString());
                Session["FeatureId"] = null;
                Session["FeatureId"] = featureId;

                string dataTextField = dropdownlistCategories.Items.FindByValue(categoryId.ToString()).ToString();

                ListItem item = new ListItem(dataTextField, categoryId.ToString());
                int index = dropdownlistCategories.Items.IndexOf(item);

                if (index != -1)

                    dropdownlistCategories.SelectedIndex = index;

                dropdownlistCategories_SelectedIndexChanged(sender, e);
                btnAdd.Text = "Update";
            }
            catch
            {

            }
        }

        //function to clear the textboxes
        private void ClearTextboxes()
        {
            txtFeature.Value = string.Empty;
            btnAdd.Text = "Add";
        }

        //event to retrive features based on categories
        protected void dropdownlistCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFeatures();
        }

        //click event to insert new feature and to update existing feature
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            try
            {
                if (btnAdd.Text == "Add")
                {
                    if (dropdownlistCategories.SelectedIndex > 0)
                    {
                        if (obj.CheckFeatureName(Session["CompanyId"].ToString(), int.Parse(dropdownlistCategories.SelectedValue), txtFeature.Value))
                        {
                            obj.InsertFeature(int.Parse(dropdownlistCategories.SelectedValue.ToString()), txtFeature.Value);
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('New Feature Added Successfully')</script>");
                            ClearTextboxes();
                            dropdownlistCategories_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Feature Name Exists!!!')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Category!!!')</script>");
                    }
                }
                else if (btnAdd.Text == "Update")
                {
                    if (dropdownlistCategories.SelectedIndex > 0)
                    {
                        obj.UpdateFeature(int.Parse(dropdownlistCategories.SelectedValue.ToString()), txtFeature.Value, int.Parse(Session["FeatureId"].ToString()));
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Feature Updated Successfully')</script>");
                        ClearTextboxes();

                        btnAdd.Text = "Add";
                        dropdownlistCategories_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Category!!!')</script>");
                    }
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }
              
    }
}