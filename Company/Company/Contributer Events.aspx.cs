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
    public partial class Contributer_Events : System.Web.UI.Page
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

            SqlCommand cmd = new SqlCommand("Show_Event", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@event_id", DBNull.Value));

            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while(rdr.Read())
            {
                output += "<p>Description: " + rdr.GetValue(1) + " Location: " + rdr.GetValue(2) + " City: " +
                        rdr.GetValue(3) + " Time: " + rdr.GetValue(4) + " Entertainer: " + rdr.GetValue(5) +
                        " Video: " + rdr.GetValue(8) + " Photo: " + rdr.GetValue(9) + " Event Creator: " +
                        rdr.GetValue(10) + " " + rdr.GetValue(11) + " " + rdr.GetValue(12) +"</p>";
            }
            if (!rdr.HasRows)
                output = "<p>Nothing to show</p>";
            rdr.Close();
            cnn.Close();
            L1.Text = output;
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer.aspx");
        }
    }
}