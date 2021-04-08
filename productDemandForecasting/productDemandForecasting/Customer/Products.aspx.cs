using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Customer
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    LoadCompanies();
                }

                LoadProducts();
            }
        }

        //function to load all companies
        private void LoadCompanies()
        {
            BLL obj = new BLL();
            DataTable tabCompanies = new DataTable();

            try
            {
                tabCompanies = obj.GetCompaniesByStatus("Approved");

                if (tabCompanies.Rows.Count > 0)
                {
                    DropDownListCompanies.Items.Clear();

                    DropDownListCompanies.DataSource = tabCompanies;
                    DropDownListCompanies.DataTextField = "CompanyName";
                    DropDownListCompanies.DataValueField = "CompanyId";
                    DropDownListCompanies.DataBind();

                    DropDownListCompanies.Items.Insert(0, "All");
                }
                else
                {
                    DropDownListCompanies.Items.Clear();

                    DropDownListCompanies.DataSource = null;
                    DropDownListCompanies.DataBind();

                    DropDownListCompanies.Items.Insert(0, "Input Companies");
                }
            }
            catch
            {

            }
        }

        //function to load categories based on company
        private void LoadCategoriesByCompany()
        {
            BLL obj = new BLL();
            DataTable tabCategories = new DataTable();

            try
            {
                tabCategories = obj.GetCategoriesByCompany(DropDownListCompanies.SelectedValue);

                if (tabCategories.Rows.Count > 0)
                {
                    DropDownListCategories.Items.Clear();

                    DropDownListCategories.DataSource = tabCategories;
                    DropDownListCategories.DataTextField = "CategoryName";
                    DropDownListCategories.DataValueField = "CategoryId";
                    DropDownListCategories.DataBind();

                    DropDownListCategories.Items.Insert(0, "All");
                }
                else
                {
                    DropDownListCategories.Items.Clear();

                    DropDownListCategories.DataSource = null;
                    DropDownListCategories.DataBind();

                    DropDownListCategories.Items.Insert(0, "Input Companies");
                }
            }
            catch
            {

            }
        }

        //function to load company products
        private void LoadProducts()
        {
            BLL obj = new BLL();
            DataTable tabProducts = new DataTable();

            try
            {
                if (DropDownListCompanies.SelectedIndex > 0)
                {
                    if (DropDownListCategories.SelectedIndex > 0)
                    {
                        tabProducts = obj.GetProductsByCompanyIdandCategoryId(DropDownListCompanies.SelectedValue, int.Parse(DropDownListCategories.SelectedValue));
                    }
                    else
                    {
                        tabProducts = obj.GetProductsByCompany(DropDownListCompanies.SelectedValue);
                    }
                }
                else
                {
                    tabProducts = obj.GetAllProducts();
                }

                if (tabProducts.Rows.Count > 0)
                {
                    tableProducts.Rows.Clear();

                    tableProducts.BorderStyle = BorderStyle.Double;
                    tableProducts.GridLines = GridLines.Both;
                    tableProducts.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>Photo</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Category Name</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Product Name</b>";
                    headerrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>Product Cost</b>";
                    headerrow.Controls.Add(cell5);

                    if (DropDownListCompanies.SelectedIndex > 0 && DropDownListCategories.SelectedIndex > 0)
                    {
                        TableCell cell6 = new TableCell();
                        cell6.Text = "<b>Rating</b>";
                        headerrow.Controls.Add(cell6);
                    }

                    tableProducts.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tabProducts.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 30;

                        TableCell cellPhoto = new TableCell();
                        cellPhoto.VerticalAlign = VerticalAlign.Top;
                        cellPhoto.Width = 50;
                        cellPhoto.Height = 50;
                        Image imgPhoto = new Image();
                        imgPhoto.Width = 50;
                        imgPhoto.Height = 50;
                        imgPhoto.ImageUrl = tabProducts.Rows[cnt]["ProductPhoto"].ToString();
                        cellPhoto.Controls.Add(imgPhoto);
                        row.Controls.Add(cellPhoto);

                        TableCell cellType = new TableCell();
                        cellType.Width = 150;

                        DataTable tabCategory = new DataTable();
                        tabCategory = obj.GetCategoryById(int.Parse(tabProducts.Rows[cnt]["CategoryId"].ToString()));

                        cellType.Text = tabCategory.Rows[0]["CategoryName"].ToString();
                        row.Controls.Add(cellType);

                        TableCell cellPName = new TableCell();
                        cellPName.Width = 150;
                        HyperLink hypPName = new HyperLink();
                        hypPName.Text = tabProducts.Rows[cnt]["ProductName"].ToString();
                        hypPName.NavigateUrl = string.Format("~/Customer/ProductDetails.aspx?categoryId={0}&productId={1}&productName={2}", tabProducts.Rows[cnt]["CategoryId"].ToString(), tabProducts.Rows[cnt]["ProductId"].ToString(), tabProducts.Rows[cnt]["ProductName"].ToString());
                        cellPName.Controls.Add(hypPName);
                        row.Controls.Add(cellPName);

                        TableCell cellCost = new TableCell();
                        cellCost.Width = 150;
                        cellCost.Text = tabProducts.Rows[cnt]["ProductCost"].ToString();
                        row.Controls.Add(cellCost);

                        if (DropDownListCompanies.SelectedIndex > 0 && DropDownListCategories.SelectedIndex > 0)
                        {
                            TableCell cellRating = new TableCell();
                            DropDownList dropdownlistRating = new DropDownList();
                            dropdownlistRating.Width = 200;
                            dropdownlistRating.ID = tabProducts.Rows[cnt]["ProductId"].ToString();

                            for (int i = 1; i < 6; i++)
                            {
                                dropdownlistRating.Items.Add(i.ToString());
                            }

                            DataTable tabRatings = new DataTable();
                            tabRatings = obj.CheckCustomerRating(Session["CustomerId"].ToString(), int.Parse(tabProducts.Rows[cnt]["ProductId"].ToString()));

                            if (tabRatings.Rows.Count > 0)
                            {
                                string valueText = dropdownlistRating.Items.FindByValue(tabRatings.Rows[0]["Rating"].ToString()).ToString();

                                ListItem itemValue = new ListItem(valueText, tabRatings.Rows[0]["Rating"].ToString());
                                int Index = dropdownlistRating.Items.IndexOf(itemValue);

                                if (Index != -1)

                                    dropdownlistRating.SelectedIndex = Index;
                            }

                            cellRating.Controls.Add(dropdownlistRating);
                            row.Controls.Add(cellRating);
                        }

                        tableProducts.Controls.Add(row);
                    }
                }
                else
                {
                    tableProducts.Rows.Clear();
                    tableProducts.GridLines = GridLines.None;

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Font.Bold = true;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.ColumnSpan = 5;
                    cell.Text = "No Products Found";
                    row.Controls.Add(cell);

                    tableProducts.Controls.Add(row);
                }
            }
            catch
            {

            }
        }

        protected void DropDownListCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategoriesByCompany();
            LoadProducts();
        }

        protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        protected void btnRating_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();

            try
            {
                DataTable tabProducts = new DataTable();
                tabProducts = obj.GetProductsByCompanyIdandCategoryId(DropDownListCompanies.SelectedValue, int.Parse(DropDownListCategories.SelectedValue));

                tab = obj.GetCustomerRating(Session["CustomerId"].ToString());

                if (tab.Rows.Count > 0)
                {
                    obj.DeleteCustomerRatings(Session["CustomerId"].ToString());

                    for (int i = 0; i < tableProducts.Rows.Count - 1; i++)
                    {
                        DropDownList dropdownlistRating = (DropDownList)tableProducts.FindControl(tabProducts.Rows[i]["productId"].ToString());
                        obj.InsertRating(Session["CustomerId"].ToString(), int.Parse(dropdownlistRating.ID), int.Parse(dropdownlistRating.SelectedValue), DateTime.Now);
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Ratings Set Successfully')</script>");
                }
                else
                {
                    for (int i = 0; i < tableProducts.Rows.Count - 1; i++)
                    {
                        DropDownList dropdownlistRating = (DropDownList)tableProducts.FindControl(tabProducts.Rows[i]["productId"].ToString());
                        obj.InsertRating(Session["CustomerId"].ToString(), int.Parse(dropdownlistRating.ID), int.Parse(dropdownlistRating.SelectedValue), DateTime.Now);
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Ratings Set Successfully')</script>");
                }
            }
            catch
            {

            }

        }

    }
}