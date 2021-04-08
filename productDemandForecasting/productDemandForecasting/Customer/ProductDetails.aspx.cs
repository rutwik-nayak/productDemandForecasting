using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Customer
{
    public partial class ProductDetails : System.Web.UI.Page
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
                LoadProductFeatures();
            }                       
        }

         //function to load product features
        private void LoadProductFeatures()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                lblProductName.Text = Request.QueryString["productName"].ToString();

                tab = obj.GetFeaturesByCategory(int.Parse(Request.QueryString["categoryId"].ToString()));

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
                    cell3.Text = "<b>Feature Name</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Value</b>";
                    headerrow.Controls.Add(cell4);

                    tableFeatures.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 35;

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 10;
                        cellSerialNo.Font.Size = 10;
                        cellSerialNo.Text = serialNo + cnt + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellFeature = new TableCell();
                        cellFeature.Width = 250;

                        DataTable tabFeature = new DataTable();
                        tabFeature = obj.GetFeatureById(int.Parse(tab.Rows[cnt]["FeatureId"].ToString()));

                        cellFeature.Text = tabFeature.Rows[0]["Feature"].ToString();
                        row.Controls.Add(cellFeature);

                        DataTable tabvalues = new DataTable();
                        tabvalues = obj.GetValuesByFeature(int.Parse(tab.Rows[cnt]["FeatureId"].ToString()));

                        TableCell cellvalue = new TableCell();

                        DropDownList dropdownlistValue = new DropDownList();
                        dropdownlistValue.Width = 200;
                        int num = serialNo + cnt;
                        dropdownlistValue.ID = num.ToString();

                        if (tabvalues.Rows.Count > 0)
                        {
                            for (int i = 0; i < tabvalues.Rows.Count; i++)
                            {
                                ListItem item = new ListItem(tabvalues.Rows[i]["Value"].ToString(), tabvalues.Rows[i]["ValueId"].ToString());
                                dropdownlistValue.Items.Add(item);
                            }
                        }
                        else
                        {
                            ListItem item = new ListItem("Notset", "Notset");
                            dropdownlistValue.Items.Add(item);
                        }

                        DataTable tabproductFeature = new DataTable();
                        tabproductFeature = obj.GetProductFeatures(int.Parse(Request.QueryString["productId"].ToString()));

                        if (tabproductFeature.Rows.Count > 0)
                        {
                            string valueText = dropdownlistValue.Items.FindByValue(tabproductFeature.Rows[cnt]["ValueId"].ToString()).ToString();

                            ListItem itemValue = new ListItem(valueText, tabproductFeature.Rows[cnt]["ValueId"].ToString());
                            int Index = dropdownlistValue.Items.IndexOf(itemValue);

                            if (Index != -1)

                                dropdownlistValue.SelectedIndex = Index;
                            dropdownlistValue.Enabled = false;
                        }

                        cellvalue.Controls.Add(dropdownlistValue);
                        row.Controls.Add(cellvalue);
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
                    cell.Text = "No Features Found";

                    row.Controls.Add(cell);
                    tableFeatures.Controls.Add(row);
                }
            }
            catch
            {

            }

        }

    }
}