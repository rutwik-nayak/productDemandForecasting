using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Admin
{
    public partial class Comments : System.Web.UI.Page
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
                GetTopicComments();
            }

        }

        //function to retrive the topic related comments
        public void GetTopicComments()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                tab.Rows.Clear();
                tab = obj.GetTopicComments(int.Parse(Request.QueryString["topicID"].ToString()));

                lblTopic.Text = "Topic Name : " + Request.QueryString["topicname"].ToString() + " [Number of Comments: " + tab.Rows.Count + "]";

                if (tab.Rows.Count > 0)
                {
                    Table1.Rows.Clear();
                                       
                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row1 = new TableRow();
                        row1.Height = 30;
                        
                        TableCell row1cell2 = new TableCell();
                        row1cell2.Width = 650;
                        row1cell2.Text = tab.Rows[cnt]["Comment"].ToString();
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
                        btnDelete.ID = tab.Rows[cnt]["CommentId"].ToString();
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

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 5;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Text = "No Topic Comments Found";
                    row.Controls.Add(cell);

                    Table1.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to delete comment
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            BLL obj = new BLL();

            try
            {
                obj.DeleteComment(int.Parse(btn.ID.ToString()));
                GetTopicComments();
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Comment Deleted Successfully')</script>");

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('!Server Error')</script>");
            }
        }
                
    }
}