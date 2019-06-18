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
    public partial class New_Requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Request.Form["btn1"] != null)
                {
                    //A btn1 was clicked, get it's value
                    int btn = int.Parse(Request.Form["btn1"]);

                    //Do something with this btn number
                    acceptClicked(btn);
                }
                if (Request.Form["btn2"] != null)
                {
                    //A btn2 was clicked, get it's value
                    int btn = int.Parse(Request.Form["btn2"]);

                    //Do something with this btn number
                    rejectClicked(btn);
                }
            }
            GetData();
        }

        private void GetData()
        {
            int s = Convert.ToInt32(Session["ID"]);
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Receive_New_Request", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@contributor_id", s));

            cmd.Parameters.Add("@can_receive", System.Data.SqlDbType.Bit).Direction = System.Data.ParameterDirection.Output;

            bool can_receive;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                can_receive = Convert.ToBoolean(cmd.Parameters["@can_receive"].Value);
            }

            //command.dispose();
            cnn.Close();

            if (!can_receive)
            {
                L1.Text = "Sorry, you have 3 new requests still in process";
            }
            else
            {
                string output = "";
                output += "<table width=\'1000\'>" +
                            "<tr>" +
                                "<th>Viewer Email</th>" +
                                "<th>Information</th>" +
                                "<th>Mine?</th>" +
                                "<th>Accept Status</th>" +
                                "<th>Accepted At</th>" +
                                "<th>Actions</th>" +
                            "</tr>";

                cnn.Open();
                cmd = new SqlCommand("Receive_New_Requests", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@contributor_id", s));
                cmd.Parameters.Add(new SqlParameter("@request_id", DBNull.Value));
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string viewer = "";
                    string sql = "Select email from [user] where id=" + "\'" + rdr.GetValue(4).ToString() + "\'";
                    string connetionString2;
                    SqlConnection cnn2;
                    connetionString2 = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    cnn2 = new SqlConnection(connetionString2);
                    cnn2.Open();
                    SqlCommand command = new SqlCommand(sql, cnn2);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        viewer = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                    cnn2.Close();
                    string information = rdr.GetValue(3).ToString();
                    string specified = "";
                    string actions = "";
                    if (Convert.ToBoolean(rdr.GetValue(2)))
                    {
                        specified = "Yes";
                        if (!rdr.IsDBNull(1))
                        {
                            actions = "No Actions";
                        }
                        else
                        {
                            actions = "<button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn1\">Accept</button>" +
                                      "<button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn2\">Reject</button>";
                        }
                    }
                    else
                    {
                        specified = "No";
                        if (!rdr.IsDBNull(1))
                        {
                            actions = "No Actions";
                        }
                        else
                        {
                            actions = "<button " + "value=" + "\"" + rdr.GetValue(0).ToString() + "\"" + " type=\"submit\" name=\"btn1\">Accept</button>";
                        }
                    }
                    string acceptStatus = "";
                    string acceptDate = "";
                    if (!rdr.IsDBNull(1) && Convert.ToInt32(rdr.GetValue(1)) == 0)
                    {
                        acceptStatus = "Rejected";
                    }
                    else
                    {
                        if (!rdr.IsDBNull(1) && Convert.ToInt32(rdr.GetValue(1)) == 1)
                        {
                            acceptStatus = "Accepted";
                            acceptDate = Convert.ToDateTime(rdr.GetValue(7)).ToString();
                        }
                        else
                            acceptStatus = "No response yet";
                    }

                    output += "<tr>" +
                                "<td>" + viewer + "</td>" +
                                "<td>" + information + "</td>" +
                                "<td>" + specified + "</td>" +
                                "<td>" + acceptStatus + "</td>" +
                                "<td>" + acceptDate + "</td>" +
                                "<td>" + actions + "</td>" +
                              "</tr>";

                }

                cnn.Close();
                L1.Text = output;
            }
        }

        public void acceptClicked(int id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Respond_New_Request", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@contributor_id", Session["ID"]));
            cmd.Parameters.Add(new SqlParameter("@accept_status", true));
            cmd.Parameters.Add(new SqlParameter("@request_id", id));
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
            cnn.Close();
        }

        public void rejectClicked(int id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Respond_New_Request", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@contributor_id", Session["ID"]));
            cmd.Parameters.Add(new SqlParameter("@accept_status", false));
            cmd.Parameters.Add(new SqlParameter("@request_id", id));
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