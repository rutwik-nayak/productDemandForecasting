using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Company
{
    public partial class Topics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyId"] == null)
            {
                Session.Abandon();
                Response.Redirect("../Guest/Login.aspx");
            }
            else
            {
                GetAllTopics();
            }
        }

        //function to retrive all topics
        public void GetAllTopics()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();
            
            try
            {
                tab.Rows.Clear();
                tab = obj.GetAllTopics();

                int serialNo = 1;

                if (tab.Rows.Count > 0)
                {
                    Table1.Rows.Clear();

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row1 = new TableRow();
                        row1.Height = 30;

                        TableCell row1_cell1 = new TableCell();
                        row1_cell1.Font.Size = 10;
                        row1_cell1.Text = cnt + serialNo + ".";
                        row1.Controls.Add(row1_cell1);

                        TableCell cell_topic = new TableCell();
                        cell_topic.Width = 650;
                        HyperLink li = new HyperLink();
                        li.ID = tab.Rows[cnt]["TopicId"].ToString();
                        li.Text = tab.Rows[cnt]["Subject"].ToString();
                        li.NavigateUrl = string.Format("~/Company/Comments.aspx?topicname={0}&topicID={1}", tab.Rows[cnt]["Subject"].ToString(), tab.Rows[cnt]["TopicId"].ToString());
                        cell_topic.Controls.Add(li);
                        row1.Controls.Add(cell_topic);

                        TableRow row3 = new TableRow();
                        row3.Height = 30;

                        TableCell row3cell1 = new TableCell();
                        row3cell1.Text = " ";
                        row3.Controls.Add(row3cell1);

                        DataTable tab50 = new DataTable();
                        tab50.Rows.Clear();

                        tab50 = obj.GetCompanyById(tab.Rows[cnt]["CompanyId"].ToString());
                        TableCell row3cell2 = new TableCell();
                        row3cell2.Text = "Posted By : " + tab50.Rows[0]["CompanyName"].ToString() + " ," + "Posted Date : " + tab.Rows[cnt]["PostedDate"].ToString() + "<br/>";
                        row3.Controls.Add(row3cell2);

                        TableRow row10 = new TableRow();

                        TableCell row10_cell1 = new TableCell();
                        row10_cell1.ColumnSpan = 10;
                        row10_cell1.Width = 660;
                        row10_cell1.Text = "<hr/>";
                        row10.Controls.Add(row10_cell1);

                        Table1.Controls.Add(row1);
                        Table1.Controls.Add(row3);
                        Table1.Controls.Add(row10);
                    }
                }
                else
                {
                    Table1.Rows.Clear();
                    Table1.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "<b>No Topics Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    Table1.Controls.Add(row);
                }
            }
            catch
            {

            }
        }

        //click event to add the topic
        protected void btn_topic_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            try
            {
                obj.InsertTopic(Session["CompanyId"].ToString(), txt_topic.Text, DateTime.Now);
                txt_topic.Text = string.Empty;
                GetAllTopics();
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('New Topic Posted Successfully')</script>");
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Server Error!')</script>");
            }
        }

    }
}