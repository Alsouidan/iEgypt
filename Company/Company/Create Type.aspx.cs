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
    public partial class Create_Type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void button1Clicked(object sender, EventArgs e)
        {
            if (T1.Text.Equals(""))
            {
                L1.Text = "Please enter a type";
                return;
            }

            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Content_type where [type]='" + T1.Text + "'", cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            bool flag = rdr.HasRows;
            rdr.Close();
            if (flag)
            {
                L1.Text = "This Type already exists";
                return;
            }

            SqlCommand command = new SqlCommand("Staff_Create_Type", cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@type_name", T1.Text));
            command.ExecuteReader();
            L1.Text = "Created Successfully!";
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}