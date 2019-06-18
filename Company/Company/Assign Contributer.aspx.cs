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
    public partial class Assign_Contributer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void button1Clicked(object sender, EventArgs e)
        {
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Assign_Contributor_Request", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@contributor_id", ContributerDropdown.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@new_request_id", RequestDropdown.SelectedValue));
                cmd.ExecuteReader();
                L1.Text = "Contributer Assigned Successfully";
                RequestDropdown.DataBind();
                ContributerDropdown.DataBind();
            }

            catch
            {
                L1.Text = "Something went wrong, make sure you selected values in all fields";
            }
            
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Member.aspx");
        }
    }
}