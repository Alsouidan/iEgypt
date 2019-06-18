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
    public partial class Order_Contributers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Show_Possible_Contributors", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while (rdr.Read())
            {
                string name = "";
                string email = "";
                SqlConnection cnn2 = new SqlConnection(connetionString);
                cnn2.Open();
                string sql2 = "select first_name + ' ' + middle_name + ' ' + last_name AS name,email from [user] where id=" + rdr.GetValue(0);
                SqlCommand cmd2 = new SqlCommand(sql2, cnn2);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    name = rdr2.GetValue(0).ToString();
                    email = rdr2.GetValue(1).ToString();
                }
                rdr2.Close();
                cnn2.Close();

                output += "<p>" +
                            name + " " + email + " No of handled requests: " + rdr.GetValue(1) +
                          "</p>";
            }

            if (!rdr.HasRows)
            {
                output = "<p>No contributers</p>";
            }

            L1.Text = output;
            rdr.Close();
            cnn.Close();
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}