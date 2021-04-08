using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Admin
{
    public partial class ExistingCompanies : System.Web.UI.Page
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
                GetExistingCompanies();
            }
        }

        //function to retrive approved companies
        private void GetExistingCompanies()
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();

            try
            {
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

                    TableCell cell7 = new TableCell();
                    cell7.Text = "Delete";
                    headerrow.Controls.Add(cell7);

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
                        cellCompanyName.Width = 250;
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

                        TableCell cellDelete = new TableCell();

                        ImageButton btnDelete = new ImageButton();
                        btnDelete.ID = tab.Rows[cnt]["CompanyId"].ToString();
                        btnDelete.Width = 25;
                        btnDelete.Height = 25;
                        btnDelete.ImageUrl = "~/images/delete6.png";
                        btnDelete.OnClientClick = "return confirm('Are you sure want to delete?')";
                        btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);
                        cellDelete.Controls.Add(btnDelete);
                        row.Controls.Add(cellDelete);

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

        //click event to delete the company registration details
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            BLL obj = new BLL();
            ImageButton imgbtn = (ImageButton)sender;

            try
            {
                DataTable tabQueries = new DataTable();
                tabQueries = obj.GetQueriesByCompany(imgbtn.ID);

                if (tabQueries.Rows.Count > 0)
                {
                    obj.DeleteQueriesByCompany(imgbtn.ID);
                }

                DataTable tabComments = new DataTable();
                tabComments = obj.GetCommentsByCompany(imgbtn.ID);

                if (tabComments.Rows.Count > 0)
                {
                    obj.DeleteCompanyComments(imgbtn.ID);
                }

                DataTable tabTopics = new DataTable();
                tabTopics = obj.GetTopicsByCompanyId(imgbtn.ID);

                if (tabTopics.Rows.Count > 0)
                {
                    obj.DeleteCompanyTopics(imgbtn.ID);
                }

                DataTable tabcategories = new DataTable();
                tabcategories = obj.GetCategoriesByCompany(imgbtn.ID);

                if (tabcategories.Rows.Count > 0)
                {
                    DataTable tabProducts = new DataTable();
                    DataTable tabFeatures = new DataTable();

                    for (int i = 0; i < tabcategories.Rows.Count; i++)
                    {
                        tabProducts = obj.GetProductsByCategory(int.Parse(tabcategories.Rows[i]["CategoryId"].ToString()));

                        if (tabProducts.Rows.Count > 0)
                        {
                            for (int j = 0; j < tabProducts.Rows.Count; j++)
                            {
                                DataTable tabPF = new DataTable();
                                tabPF = obj.GetProductFeatures(int.Parse(tabProducts.Rows[j]["ProductId"].ToString()));

                                if (tabPF.Rows.Count > 0)
                                {
                                    obj.DeleteProductFeatures(int.Parse(tabProducts.Rows[j]["ProductId"].ToString()));
                                }

                                DataTable tabPR = new DataTable();
                                tabPR = obj.GetRatingsByProduct(int.Parse(tabProducts.Rows[j]["ProductId"].ToString()));

                                if (tabPR.Rows.Count > 0)
                                {
                                    obj.DeleteProductRatings(int.Parse(tabProducts.Rows[j]["ProductId"].ToString()));
                                }

                                obj.DeleteProduct(int.Parse(tabProducts.Rows[j]["ProductId"].ToString()));
                            }
                        }

                        tabFeatures = obj.GetFeaturesByCategory(int.Parse(tabcategories.Rows[i]["CategoryId"].ToString()));

                        if (tabFeatures.Rows.Count > 0)
                        {
                            for (int z = 0; z < tabFeatures.Rows.Count; z++)
                            {
                                obj.DeleteValuesByFeature(int.Parse(tabFeatures.Rows[z]["FeatureId"].ToString()));
                            }

                            obj.DeleteFeaturesByCategory(int.Parse(tabcategories.Rows[i]["CategoryId"].ToString()));
                        }

                        obj.DeleteCategory(int.Parse(tabcategories.Rows[i]["CategoryId"].ToString()));
                    }
                }

                obj.DeleteCompany(imgbtn.ID);

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Company and its related details deleted successfully')</script>");
                GetExistingCompanies();
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

    }
}