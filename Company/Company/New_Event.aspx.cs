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
    public partial class New_Event : System.Web.UI.Page
    {
        String sqlerror;
        int s;
        protected void Page_Load(object sender, EventArgs e)
        {
            s = Convert.ToInt32(Session["ID"].ToString());

        }

        protected void button1Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            cnn.InfoMessage += new SqlInfoMessageEventHandler(Cnn_InfoMessage);
            SqlTransaction trans = cnn.BeginTransaction();
            SqlCommand cmd = new SqlCommand("Viewer_Create_Event", cnn, trans);
            SqlCommand cmd3=null;
            SqlCommand cmd4=null;
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@city", TextBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@event_date_time", TextBox2.Text));
                cmd.Parameters.Add(new SqlParameter("@description", TextBox3.Text));
                cmd.Parameters.Add(new SqlParameter("@entertainer", TextBox7.Text));
                cmd.Parameters.Add(new SqlParameter("@location", TextBox8.Text));
                cmd.Parameters.Add(new SqlParameter("@viewer_id", s));
                cmd.Parameters.Add("@event_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                int e_id = 0;
                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    e_id = Convert.ToInt32(cmd.Parameters["@event_id"].Value);
                }
                if (TextBox9.Text.Equals("") && TextBox10.Text.Equals(""))
                {
                    sqlerror = "You have to insert either a photo link or a video link";
                    Label10.Text = sqlerror;
                    trans.Rollback();
                    return;

                }
                else if (TextBox10.Text.Equals(""))
                {
                    cmd3 = new SqlCommand("Viewer_Upload_Event_Photo", cnn, trans);
                    cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd3.Parameters.Add(new SqlParameter("@event_id", e_id));
                    cmd3.Parameters.Add(new SqlParameter("@link", TextBox9.Text));
                }
                else
                if (TextBox9.Text.Equals(""))
                {
                    cmd4 = new SqlCommand("Viewer_Upload_Event_Video", cnn, trans);
                    cmd4.Parameters.Add(new SqlParameter("@event_id", e_id));
                    cmd4.Parameters.Add(new SqlParameter("@link", TextBox10.Text));
                }
                else
                {
                    cmd3 = new SqlCommand("Viewer_Upload_Event_Photo", cnn, trans);
                    cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd3.Parameters.Add(new SqlParameter("@event_id", e_id));
                    cmd3.Parameters.Add(new SqlParameter("@link", TextBox9.Text));
                    cmd4 = new SqlCommand("Viewer_Upload_Event_Video", cnn, trans);
                    cmd4.Parameters.Add(new SqlParameter("@event_id", e_id));
                    cmd4.Parameters.Add(new SqlParameter("@link", TextBox10.Text));
                }
                    if (CheckBox1.Checked)
                {
                    SqlCommand cmd1 = new SqlCommand("Viewer_Create_Ad_From_Event", cnn, trans);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@event_id", e_id));
                    try
                    {
                        cmd3.ExecuteNonQuery();
                    }
                    catch { }
                    try
                    {
                        cmd4.ExecuteNonQuery();
                    }
                    catch { }
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    try
                    {
                        cmd3.ExecuteNonQuery();
                    }
                    catch { }
                    try
                    {
                        cmd4.ExecuteNonQuery();
                    }
                    catch { }
                }






                trans.Commit();

                Response.Redirect("Viewer.aspx");
}
            catch (SqlException ex)
            {
                sqlerror = "Make sure Dates are in the correct format";
                Label10.Text = sqlerror;
                sqlerror = "";
                foreach (SqlError error in ex.Errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.Message);
                }
                trans.Rollback();

            }
            finally { cnn.Close(); }

        }
        private void Cnn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            sqlerror += e.Message + "\n";
        }
    }
}