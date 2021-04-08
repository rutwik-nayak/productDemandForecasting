using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace productDemandForecasting.Company
{
    public partial class Queries : System.Web.UI.Page
    {
        DataTable tab = new DataTable();
        BLL obj = new BLL();
        static string status = "All";

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
                tab = obj.GetQueriesByCompany(Session["CompanyId"].ToString());

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

            }
        }

        //function to retrive company pending queries
        public void GetPendingQueries()
        {
            try
            {
                tab.Rows.Clear();
                tableQueries.Rows.Clear();

                tab = obj.GetPendingQueriesByCompany(Session["CompanyId"].ToString());

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

                        TableCell cell_date = new TableCell();
                        cell_date.Width = 150;
                        string[] s = tab.Rows[i]["PostedDate"].ToString().Split(' ');
                        cell_date.Text = s[0];
                        row.Controls.Add(cell_date);

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

            }
        }
               
        //function to retrive company answered queries
        public void GetAnsweredQueries()
        {
            try
            {
                tab.Rows.Clear();
                tab = obj.GetAnsweredQueriesByCompany(Session["CompanyId"].ToString());

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
                    cell.Text = "<b>No Answered Queries Found</b>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Controls.Add(cell);
                    tableQueries.Controls.Add(row);
                }
            }
            catch
            {

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

        //click event to post new query
        protected void btnPostQuery_Click(object sender, EventArgs e)
        {
            try
            {
                obj.InsertNewQuery(Session["CompanyId"].ToString(), txtQuery.Text, DateTime.Now);
                txtQuery.Text = string.Empty;
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Query Posted Successfully!!!')</script>");
                GetAllQueries();
            }
            catch
            {

            }
        }

    }
}