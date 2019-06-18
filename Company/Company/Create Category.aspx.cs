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
    public partial class Create_Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void button1Clicked(object sender, EventArgs e)
        {
            if(T1.Text.Equals("") || T2.Text.Equals(""))
            {
                L1.Text = "Please Complete all fields";
                return;
            }

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd1 = new SqlCommand("select * from category where [type]='" + T1.Text + "'", cnn);
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            bool rdr1Flag = rdr1.HasRows;
            rdr1.Close();
            SqlCommand cmd2 = new SqlCommand("select * from sub_category where category_type='" + T1.Text + "'" + "and [name]='" + T2.Text + "'", cnn);
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            bool rdr2Flag = rdr2.HasRows;
            rdr2.Close();
            if(rdr1Flag && rdr2Flag)
            {
                L1.Text = "This category and subcategory already exist";
                return;
            }

            if(rdr1Flag)
            {
                SqlCommand command = new SqlCommand("Staff_Create_Subcategory", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@category_name", T1.Text));
                command.Parameters.Add(new SqlParameter("@subcategory_name", T2.Text));
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
            else
            {
                SqlCommand command = new SqlCommand("Staff_Create_Category", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@category_name", T1.Text));
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                command = new SqlCommand("Staff_Create_Subcategory", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@category_name", T1.Text));
                command.Parameters.Add(new SqlParameter("@subcategory_name", T2.Text));
                reader = command.ExecuteReader();
                reader.Close();
            }

            L1.Text = "Created Succesfully!";
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}