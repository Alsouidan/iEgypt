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
    public partial class Staff_Notifications : System.Web.UI.Page
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

            SqlCommand cmd = new SqlCommand("Show_Notification", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@user_id", Session["ID"]));

            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while (rdr.Read())
            {
                output += "<p>Sent At: " + rdr.GetValue(1) + " Description: " + rdr.GetValue(6) + " Location: " +
                             rdr.GetValue(7) + " City: " + rdr.GetValue(8) + " Time: " + rdr.GetValue(9) + " Entertainer: " +
                              rdr.GetValue(10);
                output += " Information: " + rdr.GetValue(16);
                string sql2 = "";
                if (rdr.IsDBNull(12))
                {
                    output += " Request Viewer: ";
                    sql2 = "select email from [user] where id=" + rdr.GetValue(17).ToString();
                }
                else
                {
                    output += " Event Viewer: ";
                    sql2 = "select email from [user] where id=" + rdr.GetValue(12).ToString();
                }
                
                SqlConnection cnn2 = new SqlConnection(connetionString);
                cnn2.Open();

                SqlCommand cmd2 = new SqlCommand(sql2, cnn2);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                    output += rdr2.GetValue(0);
                rdr2.Close();
                cnn2.Close();
                if (!rdr.IsDBNull(1))
                {
                    output += " Seen At: " + rdr.GetValue(1);
                }
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