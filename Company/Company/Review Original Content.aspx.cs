using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company
{
    public partial class Review_Original_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Request.Form["btn1"] != null)
                {
                    //A btn1 was clicked, get it's value
                    int btn = int.Parse(Request.Form["btn1"]);

                    //Do something with this btn number
                    acceptClicked(btn);
                }
                if (Request.Form["btn2"] != null)
                {
                    //A btn2 was clicked, get it's value
                    int btn = int.Parse(Request.Form["btn2"]);

                    //Do something with this btn number
                    rejectClicked(btn);
                }
            }
            GetData();
        }

        public void GetData()
        {
            int s = Convert.ToInt32(Session["ID"].ToString());
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "select * from content inner join original_content on content.id=original_content.id inner join [user] on [user].id=content.contributer_id where review_status is null";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while (rdr.Read())
            {
                output += "<p>" +
                   "Link: " + rdr.GetValue(1) + " Uploaded At: " + rdr.GetValue(2) + " Category: " + rdr.GetValue(3) +
                    " Subcategory: " + rdr.GetValue(5) + " Type: " + rdr.GetValue(6) + " Contributer: " + rdr.GetValue(14) +
                    " <button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn1\">Accept</button>" +
                    " <button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn2\">Reject</button>" +
                    "</p>";
            }

            if (!rdr.HasRows)
                output = "<p>Nothing to show</p>";
            rdr.Close();
            cnn.Close();
            L1.Text = output;
        }

        public void acceptClicked(int id)
        {
            int s = Convert.ToInt32(Session["ID"].ToString());
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("reviewer_filter_content", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@reviewer_id", s));
            cmd.Parameters.Add(new SqlParameter("@original_content", id));
            cmd.Parameters.Add(new SqlParameter("@status", true));
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
            cnn.Close();
        }

        public void rejectClicked(int id)
        {
            int s = Convert.ToInt32(Session["ID"].ToString());
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command = new SqlCommand("reviewer_filter_content", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            command.Parameters.Add(new SqlParameter("@reviewer_id", s));
            command.Parameters.Add(new SqlParameter("@original_content", id));
            command.Parameters.Add(new SqlParameter("@status", false));
            SqlDataReader rdr = command.ExecuteReader();
            rdr.Close();
            cnn.Close();
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}