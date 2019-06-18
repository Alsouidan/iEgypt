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
    public partial class Delete_Comments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Request.Form["btn"] != null)
                {
                    //A btn was clicked, get it's value
                    string btn = Request.Form["btn"];
                    char[] delimiters = { '\\' };
                    string[] Array = btn.Split(delimiters);
                    
                    //Do something with this btn number
                    deleteClicked(int.Parse(Array[0]),Array[1]);
                }
            }
        }

        public void button1Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "select * from comment inner join [user] on comment.viewer_id=[user].id where comment.original_content_id=" + ContentDropdown.SelectedValue;
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while (rdr.Read())
            {
                output += "<p>" +
                            rdr.GetValue(3) + " " + rdr.GetValue(5) + " " + rdr.GetValue(2) +
                            " <button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\\" + rdr.GetValue(2).ToString() + "\"" + " type=\"submit\" name=\"btn\">Delete</button>" +
                           "</p>";
            }

            if (!rdr.HasRows)
                output = "<p>No Comments</p>";
            rdr.Close();
            cnn.Close();
            L1.Text = output;
        }

        public void deleteClicked(int viewerId, string date)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Delete_Comment2", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@viewer_id", viewerId));
            System.Diagnostics.Debug.WriteLine(viewerId);
            cmd.Parameters.Add(new SqlParameter("@original_content_id", ContentDropdown.SelectedValue));
            System.Diagnostics.Debug.WriteLine(ContentDropdown.SelectedValue);
            System.Diagnostics.Debug.WriteLine(date);
            System.Diagnostics.Debug.WriteLine(Convert.ToDateTime(date));
            cmd.Parameters.Add(new SqlParameter("@comment_time", Convert.ToDateTime(date)));
            cmd.ExecuteReader();
            cnn.Close();
            button1Clicked(null, null);
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}