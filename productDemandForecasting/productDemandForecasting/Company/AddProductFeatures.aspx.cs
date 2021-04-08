using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace productDemandForecasting
{
    public partial class AddProductFeatures : System.Web.UI.Page
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
                txtDataSet.Value = "Training Dataset Found or Not found";
                GetProductFeatures();
            }
        }

        //function to retrive the features based on product
        private void GetProductFeatures()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                txtProductName.Value = Request.QueryString["productName"].ToString();
                txtProductName.Disabled = true;
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
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to set the features for the product
        protected void btnSet_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();
            int serialNo=1;

            try
            {
                tab = obj.GetProductFeatures(int.Parse(Request.QueryString["productId"].ToString()));

                if (tab.Rows.Count > 0)
                {
                    obj.DeleteProductFeatures(int.Parse(Request.QueryString["productId"].ToString()));

                    for (int i = 0; i < tableFeatures.Rows.Count - 1; i++)
                    {
                        int num = serialNo + i;
                        DropDownList dropdownlistValue = (DropDownList)tableFeatures.FindControl(num.ToString());
                        obj.InsertProductFeature(int.Parse(Request.QueryString["productId"].ToString()), int.Parse(dropdownlistValue.SelectedValue.ToString()));
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Product Features Added Successfully')</script>");
                }
                else
                {
                    for (int i = 0; i < tableFeatures.Rows.Count - 1; i++)
                    {
                        int num = serialNo + i;
                        DropDownList dropdownlistValue = (DropDownList)tableFeatures.FindControl(num.ToString());
                        obj.InsertProductFeature(int.Parse(Request.QueryString["productId"].ToString()), int.Parse(dropdownlistValue.SelectedValue.ToString()));
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Product Features Added Successfully')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }

        }

        //click event to predict the demand for the product
        protected void btnPredict_Click(object sender, EventArgs e)
        {
            int serialNo=1;
            BLL obj=new BLL ();
            DataTable tabTrainingSet = new DataTable();

            try
            {
                tabTrainingSet = GetTrainingDataset(int.Parse(Request.QueryString["categoryId"].ToString()));

                if (tabTrainingSet.Rows.Count > 0)
                {
                    tableDataset.Rows.Clear();

                    tableDataset.BorderStyle = BorderStyle.Double;
                    tableDataset.GridLines = GridLines.Both;
                    tableDataset.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SLNo</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Product Name</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Profit</b>";
                    headerrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>Profit Level</b>";
                    headerrow.Controls.Add(cell5);

                    tableDataset.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tabTrainingSet.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 30;

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 20;
                        cellSerialNo.Font.Size = 10;
                        cellSerialNo.Text = serialNo + cnt + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellProductName = new TableCell();
                        cellProductName.Width = 250;
                        cellProductName.Text = tabTrainingSet.Rows[cnt]["ProductName"].ToString();
                        row.Controls.Add(cellProductName);

                        TableCell cellProfit = new TableCell();
                        cellProfit.Width = 150;
                        cellProfit.Text = tabTrainingSet.Rows[cnt]["Profit"].ToString();
                        row.Controls.Add(cellProfit);

                        TableCell cellResult = new TableCell();
                        cellResult.Width = 150;
                       
                        if (tabTrainingSet.Rows[cnt]["Profit"].ToString().Equals("Loss"))
                        {
                            cellResult.Text = "< 0%";
                        }
                        else if (tabTrainingSet.Rows[cnt]["Profit"].ToString().Equals("LessProfit"))
                        {
                            cellResult.Text = "0% to 40%";
                        }
                        else if (tabTrainingSet.Rows[cnt]["Profit"].ToString().Equals("MediumProfit"))
                        {
                            cellResult.Text = "40% to 60%";
                        }
                        else if (tabTrainingSet.Rows[cnt]["Profit"].ToString().Equals("HighProfit"))
                        {
                            cellResult.Text = "> 60%";
                        }

                        row.Controls.Add(cellResult);
                        tableDataset.Controls.Add(row);
                    }

                    NaiveBayes();          
                    txtDataSet.Value = "Training Dataset Found";
                    txtDataSet.Disabled = true;
                }
                else
                {
                    txtDataSet.Value = "Training Dataset Not Found";
                    txtDataSet.Disabled = true;
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }

        }
        
        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function which contains the algorithm steps
        private void NaiveBayes()
        {
            BLL obj=new BLL ();

            try
            {
                string[] s = GetSubject();
                
                ArrayList features = new ArrayList ();
                DataTable tabFeatures = new DataTable();

                tabFeatures = obj.GetFeaturesByCategory(int.Parse(Request.QueryString["categoryId"].ToString()));
                
                int m = tabFeatures.Rows.Count;
                double p = 0.25;

                if (tabFeatures.Rows.Count > 0)
                {
                    for (int i = 0; i < tabFeatures.Rows.Count; i++)
                    {
                        features.Add(tabFeatures.Rows[i]["Feature"].ToString());
                    }
                }

                ArrayList classify = new ArrayList();
                int serialNo = 1;

                for (int i = 0; i < tableFeatures.Rows.Count - 1; i++)
                {
                    int num = serialNo + i;
                    DropDownList dropdownlistValue = (DropDownList)tableFeatures.FindControl(num.ToString());
                    classify.Add(dropdownlistValue.SelectedItem.Text);
                }

                DataTable tabTrainingSet = new DataTable();
                tabTrainingSet = GetTrainingDataset(int.Parse(Request.QueryString["categoryId"].ToString()));
                
                for (int i = 0; i < s.Length; i++)
                {
                    mul.Clear();

                    for (int j = 0; j < features.Count; j++)
                    {
                        n = 0;
                        nc = 0;

                        for (int d = 0; d < tabTrainingSet.Rows.Count; d++)
                        {
                            if (tabTrainingSet.Rows[d][j + 1].ToString().Equals(classify[j]))
                            {
                                ++n;

                                if (tabTrainingSet.Rows[d][m + 1].ToString().Equals(s[i]))

                                    ++nc;
                            }
                        }

                        double x = m * p;
                        double y = n + m;
                        double z = nc + x;

                        pi = z / y;
                        mul.Add(Math.Abs(pi));
                    }

                    double mulres = 1.0;

                    for (int z = 0; z < mul.Count; z++)
                    {
                        mulres *= double.Parse(mul[z].ToString());
                    }

                    result = mulres * p;
                    output.Add(Math.Abs(result));
                }

                DisplayOutput(s);
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //function to display the output
        private void DisplayOutput(string[] s)
        {
            ArrayList list1 = new ArrayList();

            Table5.GridLines = GridLines.Both;
            Table5.Rows.Clear();

            TableHeaderRow mainrow = new TableHeaderRow();

            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.HorizontalAlign = HorizontalAlign.Left;
            cell2.ForeColor = System.Drawing.Color.Red;
            cell2.Font.Bold = true;
            cell2.Text = "Result" + "<br/><br/>";
            mainrow.Controls.Add(cell2);

            Table5.Controls.Add(mainrow);

            for (int x = 0; x < s.Length; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();
            TableRow row = new TableRow();

            for (int y = 0; y < s.Length; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    TableCell cellResult = new TableCell();

                    if (s[y].Equals("Loss"))
                    {
                        cellResult.Text = "Product profit is classified to : " + s[y].ToString() + "<br/><br/>" + "Product profit may be around < 0% ";
                    }
                    else if (s[y].Equals("LessProfit"))
                    {
                        cellResult.Text = "Product profit is classified to : " + s[y].ToString() + "<br/><br/>" + "Product profit may be around 0% to 40% ";
                    }
                    else if (s[y].Equals("MediumProfit"))
                    {
                        cellResult.Text = "Product profit is classified to : " + s[y].ToString() + "<br/><br/>" + "Product profit may be around 40% to 60% ";
                    }
                    else if (s[y].Equals("HighProfit"))
                    {
                        cellResult.Text = "Product profit is classified to : " + s[y].ToString() + "<br/><br/>" + "Product profit may be around > 60% ";
                    }

                    row.Controls.Add(cellResult);

                    Table5.Controls.Add(row);

                    return;
                }
            }
            
        }

        //function to load training data set
        public DataTable GetTrainingDataset(int categoryId)
        {
            BLL obj = new BLL();
            DataTable tabNewFeatures=new DataTable ();
            DataTable tabFeatures = new DataTable();

            tabFeatures = obj.GetFeaturesByCategory(int.Parse(Request.QueryString["categoryId"].ToString()));

            if (tabFeatures.Rows.Count > 0)
            {
                tabNewFeatures.Columns.Add("ProductName");

                for (int i = 0; i < tabFeatures.Rows.Count; i++)
                {
                    tabNewFeatures.Columns.Add(tabFeatures.Rows[i]["Feature"].ToString());
                }

                tabNewFeatures.Columns.Add("Profit");
            }

            DataTable tab = new DataTable();
            tab = obj.GetProductsByCategory_Id(int.Parse(Request.QueryString["categoryId"].ToString()),int.Parse(Request.QueryString["productId"].ToString()));
            string[] s;

            if (tab.Rows.Count > 0)
            {
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    DataTable tab1 = new DataTable();
                    tab1 = obj.GetProductFeatures(int.Parse(tab.Rows[i]["ProductId"].ToString()));
                                      
                    if (tab1.Rows.Count > 0)
                    {
                        DataRow row = tabNewFeatures.NewRow();

                        row[tabNewFeatures.Columns[0].ToString()] = tab.Rows[i]["ProductName"].ToString();

                        for (int j = 0; j < tab1.Rows.Count; j++)
                        {
                            DataTable tabValue=new DataTable ();
                            tabValue=obj.GetValueById(int.Parse(tab1.Rows[j]["ValueId"].ToString()));
                            row[tabNewFeatures.Columns[j + 1].ToString()] = tabValue.Rows[0]["Value"].ToString();
                        }

                        row[tabNewFeatures.Columns[tab1.Rows.Count + 1].ToString()] = tab.Rows[i]["Profit"].ToString();

                        tabNewFeatures.Rows.Add(row);
                    }
                }
            }

            return tabNewFeatures;
        }

        //function to load subject
        public string[] GetSubject()
        {
            string[] s = { "Loss", "LessProfit", "MediumProfit", "HighProfit" };

            return s;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();
           
            try
            {
                tab = obj.GetProductFeatures(int.Parse(Request.QueryString["productId"].ToString()));

                if (tab.Rows.Count > 0)
                {
                    obj.DeleteProductFeatures(int.Parse(Request.QueryString["productId"].ToString()));
                    GetProductFeatures();
                   
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Product Features Deleted Successfully')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('First Add Product Features')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

    }
}