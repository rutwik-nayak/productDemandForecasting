using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace productDemandForecasting.Company
{
    public partial class AddProducts : System.Web.UI.Page
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
                    txtProductName.Focus();
                }

                GetProducts();
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

        //function to get company products
        private void GetProducts()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                if (dropdownlistCategories.SelectedIndex > 0)
                {
                    tab = obj.GetProductsByCategory(int.Parse(dropdownlistCategories.SelectedValue));
                }
                else
                {
                    tab = obj.GetProductsByCompany(Session["CompanyId"].ToString());
                }

                if (tab.Rows.Count > 0)
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
                    cell5.Text = "<b>Cost</b>";
                    headerrow.Controls.Add(cell5);

                    TableCell cell8 = new TableCell();
                    cell8.Text = "Rating";
                    headerrow.Controls.Add(cell8);

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

                    tableProducts.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
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
                        imgPhoto.ImageUrl = tab.Rows[cnt]["ProductPhoto"].ToString();
                        cellPhoto.Controls.Add(imgPhoto);
                        row.Controls.Add(cellPhoto);

                        TableCell cellType = new TableCell();
                        cellType.Width = 150;

                        DataTable tabCategory = new DataTable();
                        tabCategory = obj.GetCategoryById(int.Parse(tab.Rows[cnt]["CategoryId"].ToString()));

                        cellType.Text = tabCategory.Rows[0]["CategoryName"].ToString();
                        row.Controls.Add(cellType);

                        TableCell cellPName = new TableCell();
                        cellPName.Width = 150;

                        if (dropdownlistCategories.SelectedIndex > 0)
                        {
                            HyperLink hypPName = new HyperLink();
                            hypPName.Text = tab.Rows[cnt]["ProductName"].ToString();
                            hypPName.NavigateUrl = string.Format("~/Company/AddProductFeatures.aspx?categoryId={0}&productId={1}&productName={2}", dropdownlistCategories.SelectedValue, tab.Rows[cnt]["ProductId"].ToString(), tab.Rows[cnt]["ProductName"].ToString());
                            cellPName.Controls.Add(hypPName);
                        }
                        else
                        {
                            cellPName.Text = tab.Rows[cnt]["ProductName"].ToString();
                        }

                        row.Controls.Add(cellPName);

                        TableCell cellCost = new TableCell();
                        cellCost.Width = 80;
                        cellCost.Text = tab.Rows[cnt]["ProductCost"].ToString();
                        row.Controls.Add(cellCost);

                        TableCell cellratings = new TableCell();
                        cellratings.Width = 80;

                        DataTable tabRatings = new DataTable();
                        tabRatings = obj.GetRatingsByProduct(int.Parse(tab.Rows[cnt]["ProductId"].ToString()));

                        int rating = 0;

                        if (tabRatings.Rows.Count > 0)
                        {
                            rating = obj.GetProductRatings(int.Parse(tab.Rows[cnt]["ProductId"].ToString()));
                        }
                        else
                        {
                            rating = 0;
                        }

                        HyperLink hypRating = new HyperLink();
                        hypRating.Text = rating.ToString();
                        hypRating.NavigateUrl = string.Format("~/Company/Ratings.aspx?productId={0}&productName={1}", tab.Rows[cnt]["ProductId"].ToString(), tab.Rows[cnt]["ProductName"].ToString());
                        cellratings.Controls.Add(hypRating);
                        row.Controls.Add(cellratings);

                        if (dropdownlistCategories.SelectedIndex > 0)
                        {
                            TableCell cellEdit = new TableCell();

                            ImageButton btnEdit = new ImageButton();
                            btnEdit.Width = 15;
                            btnEdit.Height = 15;
                            btnEdit.ImageUrl = "~/images/edit-10-xxl.png";
                            btnEdit.ToolTip = "Click here to Edit the Product";
                            btnEdit.ID = "ProductEdit~" + tab.Rows[cnt]["ProductId"].ToString();
                            btnEdit.Click += new ImageClickEventHandler(btnEdit_Click);

                            cellEdit.Controls.Add(btnEdit);
                            row.Controls.Add(cellEdit);

                            TableCell cellDelete = new TableCell();

                            ImageButton btnDelete = new ImageButton();
                            btnDelete.Width = 15;
                            btnDelete.Height = 15;
                            btnDelete.ImageUrl = "~/images/delete6.png";
                            btnDelete.ToolTip = "Click here to Delete the Product";
                            btnDelete.ID = "ProductDelete~" + tab.Rows[cnt]["ProductId"].ToString();
                            btnDelete.OnClientClick = "return confirm('Are you sure do you want to Delete?')";
                            btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                            cellDelete.Controls.Add(btnDelete);
                            row.Controls.Add(cellDelete);
                        }
                        else
                        {

                        }

                        tableProducts.Controls.Add(row);
                    }
                }
                else
                {
                    tableProducts.Rows.Clear();
                    tableProducts.BorderStyle = BorderStyle.None;

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 5;
                    cell.Font.Bold = true;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Text = "No Products Found";
                    row.Controls.Add(cell);

                    tableProducts.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to delete product details
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();

                //obj.DeleteProductRatings(int.Parse(s[1].ToString()));
                obj.DeleteProduct(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Product Deleted Successfully!!!')</script>");
                GetProducts();
                btnAdd.Text = "Add";
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('First Delete Related Products Features!!!')</script>");
            }
        }

        //click event to edit product details
        void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                DataTable tabProduct = new DataTable();
                BLL obj = new BLL();

                tabProduct = obj.GetProductById(int.Parse(s[1].ToString()));

                txtProductName.Value = tabProduct.Rows[0]["ProductName"].ToString();
                txtCost.Value = tabProduct.Rows[0]["ProductCost"].ToString();
                txtDescription.Value = tabProduct.Rows[0]["Description"].ToString();
                txtInvestment.Value = tabProduct.Rows[0]["Investment"].ToString();
                txtProfit.Value = tabProduct.Rows[0]["Profit"].ToString();

                txtSoldQuantity.Text = tabProduct.Rows[0]["SoldQuantity"].ToString();
                txtQuantity.Text = tabProduct.Rows[0]["StockQuantity"].ToString();
                txtInvestmentperProduct.Text = tabProduct.Rows[0]["ActualCost"].ToString();

                int productId = int.Parse(tabProduct.Rows[0]["ProductId"].ToString());
                int categoryId = int.Parse(tabProduct.Rows[0]["CategoryId"].ToString());
                Session["ProductId"] = null;
                Session["ProductId"] = productId;

                Session["oldDBPath"] = null;
                Session["oldDBPath"] = tabProduct.Rows[0]["ProductPhoto"].ToString();

                Session["productName"] = null;
                Session["productName"] = tabProduct.Rows[0]["ProductName"].ToString();

                string dataTextField = dropdownlistCategories.Items.FindByValue(categoryId.ToString()).ToString();

                ListItem item = new ListItem(dataTextField, categoryId.ToString());
                int index = dropdownlistCategories.Items.IndexOf(item);

                if (index != -1)

                    dropdownlistCategories.SelectedIndex = index;

                dropdownlistCategories_SelectedIndexChanged(sender, e);
                btnAdd.Text = "Update";

                DisableControls();
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //function to clear the textboxes
        private void ClearTextboxes()
        {
            txtProductName.Value = string.Empty;
            txtCost.Value = string.Empty;
            txtDescription.Value = string.Empty;
            txtInvestment.Value = string.Empty;
            txtProfit.Value = string.Empty;
            txtSoldQuantity.Text = string.Empty;
            lblProfit.Text = string.Empty;
            txtInvestmentperProduct.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            btnAdd.Text = "Add";
        }

        //event to retrive products based on categories
        protected void dropdownlistCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProducts();
        }

        //click event to insert new product and to update existing product
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            try
            {
                if (btnAdd.Text == "Add")
                {
                    if (dropdownlistCategories.SelectedIndex > 0)
                    {
                        if (obj.CheckProductName(int.Parse(dropdownlistCategories.SelectedValue), txtProductName.Value))
                        {
                            string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                            int index = photoName.LastIndexOf('.');
                            string ext = photoName.Substring(index + 1);

                            string photoPath = null;
                            string dbPath = null;

                            photoPath = Server.MapPath("~/Company/Photos/" + txtProductName.Value+ "." + ext);
                            fileuploadPhoto.PostedFile.SaveAs(photoPath);
                            dbPath = @"/Company/Photos/" + txtProductName.Value + "." + ext;
                            
                            if (txtSoldQuantity.Text.Equals(""))
                            {
                                txtSoldQuantity.Text = "0";
                                txtProfit.Value = "0";
                            }

                            obj.InsertProduct(int.Parse(dropdownlistCategories.SelectedValue.ToString()), txtProductName.Value, txtDescription.Value, float.Parse(txtCost.Value), dbPath,
                                float.Parse(txtInvestment.Value), int.Parse(txtSoldQuantity.Text), txtProfit.Value, DateTime.Now, float.Parse(txtInvestmentperProduct.Text), int.Parse(txtQuantity.Text));
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('New Product Added Successfully')</script>");
                            ClearTextboxes();
                            dropdownlistCategories_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Product Name Exists!!!')</script>");
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
                        if (Session["productName"].Equals(txtProductName.Value))
                        {
                            if (fileuploadPhoto.Enabled)
                            {
                                File.Delete(Server.MapPath(Session["oldDBPath"].ToString()));
                                string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                                int index = photoName.LastIndexOf('.');
                                string ext = photoName.Substring(index + 1);

                                string phtotPath = Server.MapPath("/Company/Photos/" + Session["productName"] + "." + ext);
                                fileuploadPhoto.PostedFile.SaveAs(phtotPath);

                                string dbPath = "~/Company/Photos/" + Session["productName"] + "." + ext;

                                if (txtSoldQuantity.Text.Equals(""))
                                {
                                    txtSoldQuantity.Text = "0";
                                    txtProfit.Value = "0";
                                }

                                obj.UpdateProduct(int.Parse(dropdownlistCategories.SelectedValue), txtProductName.Value, txtDescription.Value, float.Parse(txtCost.Value), dbPath,
                                    float.Parse(txtInvestment.Value), int.Parse(txtSoldQuantity.Text), txtProfit.Value, DateTime.Now, int.Parse(Session["ProductId"].ToString()), float.Parse(txtInvestmentperProduct.Text), int.Parse(txtQuantity.Text));
                            }
                            else
                            {
                                obj.UpdateProduct(int.Parse(dropdownlistCategories.SelectedValue), txtProductName.Value, txtDescription.Value, float.Parse(txtCost.Value), Session["oldDBPath"].ToString(),
                                   float.Parse(txtInvestment.Value), int.Parse(txtSoldQuantity.Text), txtProfit.Value, DateTime.Now, int.Parse(Session["ProductId"].ToString()), float.Parse(txtInvestmentperProduct.Text), int.Parse(txtQuantity.Text));
                            }

                            btnAdd.Text = "Add";
                            dropdownlistCategories_SelectedIndexChanged(sender, e);
                            ClearTextboxes();
                            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Product Updated Successfully')</script>");

                        }
                        else
                        {
                            if (obj.CheckProductName(int.Parse(dropdownlistCategories.SelectedValue), txtProductName.Value))
                            {
                                if (fileuploadPhoto.Enabled)
                                {
                                    File.Delete(Server.MapPath(Session["oldDBPath"].ToString()));
                                    string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                                    int index = photoName.LastIndexOf('.');
                                    string ext = photoName.Substring(index + 1);

                                    string phtotPath = Server.MapPath("/Company/Photos/" + txtProductName.Value + "." + ext);
                                    fileuploadPhoto.PostedFile.SaveAs(phtotPath);

                                    string dbPath = "~/Company/Photos/" + txtProductName.Value + "." + ext;

                                    if (txtSoldQuantity.Text.Equals(""))
                                    {
                                        txtSoldQuantity.Text = "0";
                                        txtProfit.Value = "0";
                                    }


                                    obj.UpdateProduct(int.Parse(dropdownlistCategories.SelectedValue), txtProductName.Value, txtDescription.Value, float.Parse(txtCost.Value), dbPath,
                                        float.Parse(txtInvestment.Value), int.Parse(txtSoldQuantity.Text), txtProfit.Value, DateTime.Now, int.Parse(Session["ProductId"].ToString()), float.Parse(txtInvestmentperProduct.Text), int.Parse(txtQuantity.Text));
                                }
                                else
                                {
                                    obj.UpdateProduct(int.Parse(dropdownlistCategories.SelectedValue), txtProductName.Value, txtDescription.Value, float.Parse(txtCost.Value), Session["oldDBPath"].ToString(),
                                       float.Parse(txtInvestment.Value), int.Parse(txtSoldQuantity.Text), txtProfit.Value, DateTime.Now, int.Parse(Session["ProductId"].ToString()), float.Parse(txtInvestmentperProduct.Text), int.Parse(txtQuantity.Text));
                                }

                                btnAdd.Text = "Add";
                                dropdownlistCategories_SelectedIndexChanged(sender, e);
                                ClearTextboxes();
                                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Product Updated Successfully')</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Product Name Exists!!!')</script>");
                            }
                        }

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

        //functiont to disable controls
        private void DisableControls()
        {
            fileuploadPhoto.Enabled = false;
            lbtnChangephoto.Enabled = true;

            RequiredFieldValidator9.Enabled = false;
            RegularExpressionValidator2.Enabled = false;

            lbtnChangephoto.Enabled = true;
        }

        //functiont to enable controls
        private void EnableControls()
        {
            fileuploadPhoto.Enabled = true;

            RequiredFieldValidator9.Enabled = false;
            RegularExpressionValidator2.Enabled = false;
            lbtnChangephoto.Enabled = false;
        }

        //click event to enable fileupload component
        protected void lbtnChangephoto_Click(object sender, EventArgs e)
        {
            EnableControls();
        }

        protected void txtSoldQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sQty = int.Parse(txtQuantity.Text);
                int soldQty = int.Parse(txtSoldQuantity.Text);

                if (soldQty > sQty)
                {
                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Actual Price if more than the Selling Price!!!')</script>");
                    btnAdd.Enabled = false;
                }
                else
                {


                    double investment = double.Parse(txtInvestment.Value);
                    double cost = double.Parse(txtCost.Value);

                    int soldQuantity = int.Parse(txtSoldQuantity.Text);
                    double totalCost = soldQuantity * cost;

                    double gain = totalCost - investment;

                    double profitPercentage = (gain * 100.0) / investment;

                    if (profitPercentage < 0)
                    {
                        lblProfit.Text = "Loss = " + gain + "units and percentage = " + profitPercentage.ToString() + "% Loss";
                        txtProfit.Value = "Loss";
                    }
                    else if (profitPercentage == 0)
                    {
                        lblProfit.Text = "No Profit/No Loss";
                        txtProfit.Value = "No Profit/No Loss";
                    }
                    else if (profitPercentage > 0 && profitPercentage < 40)
                    {
                        lblProfit.Text = "Gain = " + gain + "units and percentage = " + profitPercentage.ToString() + "% Profit";
                        txtProfit.Value = "LessProfit";
                    }
                    else if (profitPercentage >= 40 && profitPercentage < 60)
                    {
                        lblProfit.Text = "Gain = " + gain + "units and percentage = " + profitPercentage.ToString() + "% Profit";
                        txtProfit.Value = "MediumProfit";
                    }
                    else
                    {
                        if (profitPercentage >= 80)
                        {
                            lblProfit.Text = "Gain = " + gain + "units and percentage = " + profitPercentage.ToString() + "% Profit";
                            txtProfit.Value = "HighProfit";
                        }
                    }

                    btnAdd.Enabled = true;
                }


            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            float investment = float.Parse(txtInvestmentperProduct.Text);
            float qty = float.Parse(txtQuantity.Text);

            float totalInvestment = investment * qty;

            txtInvestment.Value = totalInvestment.ToString();
        }

        protected void txtInvestmentperProduct_TextChanged(object sender, EventArgs e)
        {
            double ActualCost = double.Parse(txtInvestmentperProduct.Text);
            double SellingCost = double.Parse(txtCost.Value);

            if (ActualCost > SellingCost)
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Actual Price if more than the Selling Price!!!')</script>");
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }

        }

    }
}