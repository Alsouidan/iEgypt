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
    public partial class Staff_Delete_Content : System.Web.UI.Page
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
                    deleteOriginalClicked(btn);
                }
                if (Request.Form["btn2"] != null)
                {
                    //A btn2 was clicked, get it's value
                    int btn = int.Parse(Request.Form["btn2"]);

                    //Do something with this btn number
                    deleteNewClicked(btn);
                }
            }
            GetData();
        }

        public void GetData()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "select * from content inner join original_content on content.id=original_content.id inner join [user] on [user].id=content.contributer_id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while (rdr.Read())
            {
                output += "<p>" +
                            "Link: " + rdr.GetValue(1) + " Uploaded At: " + rdr.GetValue(2) + " Category: " + rdr.GetValue(3) +
                            " Subcategory: " + rdr.GetValue(5) + " Type: " + rdr.GetValue(6) + " Rating: " + rdr.GetValue(12) +
                            " Contributer: " + rdr.GetValue(14) +
                            " <button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn1\">Delete</button>" +
                           "</p>";
            }
            L1.Text = output;
            rdr.Close();
            sql = "select * from content inner join new_content on content.id=new_content.id inner join [user] on [user].id=content.contributer_id";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader reader = command.ExecuteReader();
            output = "";
            while (reader.Read())
            {
                output += "<p>" +
                            "Link: " + reader.GetValue(1) + " Uploaded At: " + reader.GetValue(2) + " Category: " + reader.GetValue(3) +
                            " Subcategory: " + reader.GetValue(5) + " Type: " + reader.GetValue(6)  +
                            " Contributer: " + reader.GetValue(10) +
                            " <button " + "value=" + "\"" + reader.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn2\">Delete</button>" +
                           "</p>";
            }
            L2.Text = output;
            reader.Close();
            cnn.Close();
        }

        public void deleteOriginalClicked(int id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Delete_Original_Content", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@content_id", id));
            cmd.ExecuteReader();
            cnn.Close();
        }

        public void deleteNewClicked(int id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Delete_New_Content", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@content_id", id));
            cmd.ExecuteReader();
            cnn.Close();
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}