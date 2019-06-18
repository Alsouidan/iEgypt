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
    public partial class Delete_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Request.Form["btn"] != null)
                {
                    //A btn was clicked, get it's value
                    int btn = int.Parse(Request.Form["btn"]);

                    //Do something with this btn number
                    deleteClicked(btn);
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
            SqlCommand command;
            SqlDataReader dataReader;

            String sql;
            sql = "Select * from Content inner join Original_content on content.id=original_content.id where content.contributer_id="+Session["ID"];

            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            String output = "<h1>Original Content</h1>";
            while(dataReader.Read())
            {
                output += "<p>Link: " + dataReader.GetValue(1) + " Uploaded at: " + dataReader.GetValue(2) +
                            " Category: " + dataReader.GetValue(3) + " Subcategory: " + dataReader.GetValue(5) +
                            " Type: " + dataReader.GetValue(6) + " Rating: " + dataReader.GetValue(12);
                if (dataReader.IsDBNull(10))
                {
                    output += "  <button " + "value=" + "\"" + dataReader.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn\">Delete</button>";
                }
                else
                    output += "  Filtering Process Started";
                output += "</p>";
            }
            cnn.Close();
            SqlConnection cnn2;
            cnn2 = new SqlConnection(connetionString);
            cnn2.Open();
            SqlCommand cmd;
            SqlDataReader rdr;

            sql = "Select * from Content inner join new_content on content.id=new_content.id where content.contributer_id=" + Session["ID"];
            cmd = new SqlCommand(sql, cnn2);
            rdr = cmd.ExecuteReader();
            output += "<h1>New Content</h1>";
            while(rdr.Read())
            {
                output += "<p>Link: " + rdr.GetValue(1) + " Uploaded at: " + rdr.GetValue(2) +
                            " Category: " + rdr.GetValue(3) + " Subcategory: " + rdr.GetValue(5) +
                            " Type: " + rdr.GetValue(6) +
                            "  <button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn\">Delete</button>" +
                            "</p>";
            }
            cnn2.Close();
            L1.Text = output;
        }

        public void deleteClicked(int id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Delete_Content", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@content_id", id));
            
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
            cnn.Close();
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer.aspx");
        }
    }
}