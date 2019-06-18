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
    public partial class Most_Requested_Content : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("Most_Requested_Content", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while (rdr.Read())
            {
                output += "<p>" +
                            "Link: " + rdr.GetValue(3) + " Category: " + rdr.GetValue(5) + " Subcategory: " + rdr.GetValue(7) +
                            " Type: " + rdr.GetValue(8) + " Rating: " + rdr.GetValue(24) + " No of existing requests: " + rdr.GetValue(1) +
                           "</p>";
            }

            if (!rdr.HasRows)
                output = "<p>Nothing to show</p>";
            rdr.Close();
            cnn.Close();
            L1.Text = output;
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}