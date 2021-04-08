using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Admin
{
    public partial class DiscussionForum : System.Web.UI.Page
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

                if (tab.Rows.Count > 0)
                {
                    Table1.Rows.Clear();

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row1 = new TableRow();
                        row1.Height = 30;
                        
                        TableCell row1cell2 = new TableCell();
                        row1cell2.Width = 650;
                        HyperLink link = new HyperLink();
                        link.Text = tab.Rows[cnt]["Subject"].ToString();
                        link.ID = "Link~" + tab.Rows[cnt]["TopicId"].ToString();
                        string url = string.Format("../Admin/Comments.aspx?topicname={0}&topicID={1}", tab.Rows[cnt]["Subject"].ToString(), tab.Rows[cnt]["TopicId"].ToString());
                        link.NavigateUrl = url;
                        row1cell2.Controls.Add(link);
                        row1.Controls.Add(row1cell2);

                        TableRow row3 = new TableRow();

                        DataTable tab50 = new DataTable();
                        tab50.Rows.Clear();

                        tab50 = obj.GetCompanyById(tab.Rows[cnt]["CompanyId"].ToString());
                        TableCell row3cell2 = new TableCell();
                        row3cell2.Text = "Posted By : " + tab50.Rows[0]["CompanyName"].ToString() + " ," + "Posted Date : " + tab.Rows[cnt]["PostedDate"].ToString() + "<br/>";
                        row3.Controls.Add(row3cell2);

                        TableRow row10 = new TableRow();

                        TableCell row10_cell1 = new TableCell();
                        row10_cell1.HorizontalAlign = HorizontalAlign.Right;
                                               
                        ImageButton btnDelete = new ImageButton();
                        btnDelete.ID = tab.Rows[cnt]["TopicId"].ToString();
                        btnDelete.Width = 25;
                        btnDelete.Height = 25;
                        btnDelete.ImageUrl = "~/images/delete6.png";
                        btnDelete.OnClientClick = "return confirm('Are you sure want to delete?')";
                        btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                        row10_cell1.Controls.Add(btnDelete);
                        row10.Controls.Add(row10_cell1);

                        TableRow row4 = new TableRow();
                                                
                        TableCell row4cell2 = new TableCell();
                        row4cell2.Width = 900;
                        row4cell2.Text = "<hr/>";
                        row4.Controls.Add(row4cell2);

                        Table1.Controls.Add(row1);
                        Table1.Controls.Add(row3);
                        Table1.Controls.Add(row10);
                        Table1.Controls.Add(row4);
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
                    cell.Text = "No Topics Found";
                    row.Controls.Add(cell);

                    Table1.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to delete the topic and related comments
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            BLL obj = new BLL();
            ImageButton btn = (ImageButton)sender;
                      
            try
            {
                obj.DeleteTopicComments(int.Parse(btn.ID.ToString()));
                obj.DeleteTopic(int.Parse(btn.ID.ToString()));
                GetAllTopics();
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Topic and TopicComments Deleted Successfully')</script>");
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }
               
    }
}