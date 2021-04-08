using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Admin
{
    public partial class CompanyQueries : System.Web.UI.Page
    {
        DataTable tab = new DataTable();
        BLL obj = new BLL();
        static string status = "All";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Guest/Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    status = "All";
                    GetAllQueries();
                }
                else
                {
                    if (status.Equals("Pending"))

                        GetPendingQueries();

                    else if (status.Equals("Answered"))

                        GetAnsweredQueries();
                }
            }
        }

        //function to get all company queries
        public void GetAllQueries()
        {
            try
            {
                tab.Rows.Clear();
                tab = obj.GetAllQueries();

                if (tab.Rows.Count > 0)
                {
                    tableQueries.Rows.Clear();

                    tableQueries.BorderStyle = BorderStyle.Double;
                    tableQueries.GridLines = GridLines.Both;
                    tableQueries.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableHeaderCell cell1 = new TableHeaderCell();
                    cell1.Text = "Company Id";
                    headerrow.Controls.Add(cell1);

                    TableHeaderCell cell2 = new TableHeaderCell();
                    cell2.Text = "Query";
                    headerrow.Controls.Add(cell2);

                    TableHeaderCell cell3 = new TableHeaderCell();
                    cell3.Text = "Posted Date";
                    headerrow.Controls.Add(cell3);

                    TableHeaderCell cell4 = new TableHeaderCell();
                    cell4.Text = "Response";
                    headerrow.Controls.Add(cell4);

                    TableHeaderCell cell5 = new TableHeaderCell();
                    cell5.Text = "Repy Date";
                    headerrow.Controls.Add(cell5);

                    tableQueries.Controls.Add(headerrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 30;

                        TableCell cell_username = new TableCell();
                        cell_username.Width = 150;
                        cell_username.Text = tab.Rows[i]["CompanyId"].ToString();
                        row.Controls.Add(cell_username);

                        TableCell cell_Question = new TableCell();
                        cell_Question.Width = 250;
                        cell_Question.Text = tab.Rows[i]["Query"].ToString();
                        row.Controls.Add(cell_Question);

                        TableCell cell_posteddate = new TableCell();
                        cell_posteddate.Width = 100;
                        string[] s = tab.Rows[i]["PostedDate"].ToString().Split(' ');
                        cell_posteddate.Text = s[0];
                        row.Controls.Add(cell_posteddate);

                        TableCell cell_response = new TableCell();
                        cell_response.Width = 250;
                        cell_response.Text = tab.Rows[i]["Reply"].ToString();
                        row.Controls.Add(cell_response);

                        TableCell cell_replydate = new TableCell();
                        cell_replydate.Width = 100;
                        string[] s1 = tab.Rows[i]["ReplyDate"].ToString().Split(' ');
                        cell_replydate.Text = s1[0];
                        row.Controls.Add(cell_replydate);

                        tableQueries.Controls.Add(row);
                    }
                }

                else
                {
                    tableQueries.Rows.Clear();
                    tableQueries.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "<b>No Queries Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    tableQueries.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //function to retrive all pending queries
        public void GetPendingQueries()
        {
            try
            {
                tab.Rows.Clear();
                tableQueries.Rows.Clear();

                tab = obj.GetPendingQueries();

                if (tab.Rows.Count > 0)
                {
                    tableQueries.Rows.Clear();

                    tableQueries.BorderStyle = BorderStyle.Double;
                    tableQueries.GridLines = GridLines.Both;
                    tableQueries.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableHeaderCell cell1 = new TableHeaderCell();
                    cell1.Text = "CompanyId";
                    headerrow.Controls.Add(cell1);

                    TableHeaderCell cell2 = new TableHeaderCell();
                    cell2.Text = "Query";
                    headerrow.Controls.Add(cell2);

                    TableHeaderCell cell3 = new TableHeaderCell();
                    cell3.Text = "Posted Date";
                    headerrow.Controls.Add(cell3);

                    TableHeaderCell cell4 = new TableHeaderCell();
                    cell4.Text = "Send Reply";
                    headerrow.Controls.Add(cell4);

                    tableQueries.Controls.Add(headerrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cell_username = new TableCell();
                        cell_username.Width = 150;
                        cell_username.Text = tab.Rows[i]["CompanyId"].ToString();
                        row.Controls.Add(cell_username);

                        TableCell cell_Question = new TableCell();
                        cell_Question.Width = 250;
                        cell_Question.Text = tab.Rows[i]["Query"].ToString();
                        row.Controls.Add(cell_Question);

                        TableCell cell_date = new TableCell();
                        cell_date.Width = 150;
                        string[] s = tab.Rows[i]["PostedDate"].ToString().Split(' ');
                        cell_date.Text = s[0];
                        row.Controls.Add(cell_date);

                        TableCell cell_FQreply = new TableCell();

                        ImageButton btnReply = new ImageButton();
                        btnReply.ID = tab.Rows[i]["QueryId"].ToString();
                        btnReply.Width = 50;
                        btnReply.Height = 25;
                        btnReply.ImageUrl = "~/images/replybtn.png";
                        btnReply.Click += new ImageClickEventHandler(btnReply_Click);
                        cell_FQreply.Controls.Add(btnReply);

                        row.Controls.Add(cell_FQreply);
                        tableQueries.Controls.Add(row);


                    }

                }
                else
                {
                    tableQueries.Rows.Clear();
                    tableQueries.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "<b>No Pending Queries Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    tableQueries.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to send reply
        void btnReply_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            int Question_ID = int.Parse(btn.ID.ToString());

            Response.Redirect(string.Format("~/Admin/QueryReply.aspx?queryId={0}", Question_ID));
        }
              
        //function to retrive answered queries
        public void GetAnsweredQueries()
        {
            try
            {
                tab.Rows.Clear();
                tab = obj.GetAnsweredQueries();

                if (tab.Rows.Count > 0)
                {
                    tableQueries.Rows.Clear();

                    tableQueries.BorderStyle = BorderStyle.Double;
                    tableQueries.GridLines = GridLines.Both;
                    tableQueries.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow headerrow = new TableRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.Gray;

                    TableHeaderCell cell1 = new TableHeaderCell();
                    cell1.Text = "CompanyId";
                    headerrow.Controls.Add(cell1);

                    TableHeaderCell cell2 = new TableHeaderCell();
                    cell2.Text = "Feedback";
                    headerrow.Controls.Add(cell2);

                    TableHeaderCell cell3 = new TableHeaderCell();
                    cell3.Text = "Posted Date";
                    headerrow.Controls.Add(cell3);

                    TableHeaderCell cell4 = new TableHeaderCell();
                    cell4.Text = "Response";
                    headerrow.Controls.Add(cell4);

                    TableHeaderCell cell5 = new TableHeaderCell();
                    cell5.Text = "Reply Date";
                    headerrow.Controls.Add(cell5);

                    TableHeaderCell cell6 = new TableHeaderCell();
                    cell6.Text = "Delete";
                    headerrow.Controls.Add(cell6);

                    tableQueries.Controls.Add(headerrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cell_username = new TableCell();
                        cell_username.Width = 150;
                        cell_username.Text = tab.Rows[i]["CompanyId"].ToString();
                        row.Controls.Add(cell_username);

                        TableCell cell_Question = new TableCell();
                        cell_Question.Width = 250;
                        cell_Question.Text = tab.Rows[i]["Query"].ToString();
                        row.Controls.Add(cell_Question);

                        TableCell cell_posteddate = new TableCell();
                        cell_posteddate.Width = 100;
                        string[] s = tab.Rows[i]["PostedDate"].ToString().Split(' ');
                        cell_posteddate.Text = s[0];
                        row.Controls.Add(cell_posteddate);

                        TableCell cell_response = new TableCell();
                        cell_response.Width = 250;
                        cell_response.Text = tab.Rows[i]["Reply"].ToString();
                        row.Controls.Add(cell_response);

                        TableCell cell_replydate = new TableCell();
                        cell_replydate.Width = 100;
                        string[] s1 = tab.Rows[i]["ReplyDate"].ToString().Split(' ');
                        cell_replydate.Text = s1[0];
                        row.Controls.Add(cell_replydate);

                        TableCell cellDelete = new TableCell();

                        ImageButton btnDelete = new ImageButton();
                        btnDelete.ID = tab.Rows[i]["QueryId"].ToString();
                        btnDelete.Width = 25;
                        btnDelete.Height = 25;
                        btnDelete.ImageUrl = "~/images/delete6.png";
                        btnDelete.OnClientClick = "return confirm('Are you sure want to delete?')";
                        btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);
                        cellDelete.Controls.Add(btnDelete);
                        row.Controls.Add(cellDelete);

                        tableQueries.Controls.Add(row);
                    }

                }
                else
                {
                    tableQueries.Rows.Clear();
                    tableQueries.GridLines = GridLines.None;

                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 10;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Font.Bold = true;
                    cell.Font.Size = 14;
                    cell.Text = "<b>No Answered Queries Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    tableQueries.Controls.Add(row);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        //click event to delete the company query
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            BLL obj = new BLL();
            ImageButton imgbtn = (ImageButton)sender;

            try
            {
                obj.DeleteQuery(int.Parse(imgbtn.ID));
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Query deleted successfully')</script>");
                GetAnsweredQueries();
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }
        
        //click event to retrive all pending queries
        protected void btnPending_Click(object sender, EventArgs e)
        {
            status = "Pending";
            GetPendingQueries();
        }

        //click event to retrive all answered queries
        protected void btnAnswered_Click(object sender, EventArgs e)
        {
            status = "Answered";
            GetAnsweredQueries();
        }

    }
}