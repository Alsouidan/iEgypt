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
    public partial class Contributer_Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void button1Clicked(object sender, EventArgs e)
        {
            int viewerId = Int32.Parse(ViewersDropdown.SelectedValue);

            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            string sql = "select * from message where viewer_id=" + viewerId + " and contributer_id=" + Session["ID"];
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while(rdr.Read())
            {
                output += "<p>" + rdr.GetValue(5).ToString() + "<br/>" +
                                  rdr.GetValue(0).ToString() + "<br/>";
                if (Convert.ToBoolean(rdr.GetValue(3)))
                    output += "Sent";
                else
                    output += "Received";
                output += "</p>";
            }
            L1.Text = output;
            T1.Visible = true;
            B1.Visible = true;
            rdr.Close();
            cnn.Close();
        }

        public void button2Clicked(object sender, EventArgs e)
        {
            int viewerId = Int32.Parse(ViewersDropdown.SelectedValue);

            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Send_Message", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@msg_text", T1.Text));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", viewerId));
            cmd.Parameters.Add(new SqlParameter("@contributor_id", Session["ID"]));
            cmd.Parameters.Add(new SqlParameter("@sender_type", true));
            cmd.Parameters.Add(new SqlParameter("@sent_at", DateTime.Now));
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
            cnn.Close();
            button1Clicked(null, null);
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer.aspx");
        }
    }
}