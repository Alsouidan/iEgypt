using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company
{
    public partial class Register1 : System.Web.UI.Page
    {
        public List <TextBox> list;
        public String sqlerror;
        protected void Page_Load(object sender, EventArgs e)
        {
            list = new List <TextBox>();

            list.Add(TextBox1); list.Add(TextBox2); list.Add(TextBox3); list.Add(TextBox4); list.Add(TextBox5); 
            list.Add(TextBox6); list.Add(TextBox7); list.Add(TextBox8); list.Add(TextBox9); list.Add(TextBox10);
            list.Add(TextBox11); list.Add(TextBox12); list.Add(TextBox13); list.Add(TextBox14); list.Add(TextBox15);
            list.Add(TextBox16);

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.Text.Equals("Viewer")) {
                for (int i = 0; i < 9; i++)
                    list[i].Enabled = true;
                for (int i = 9; i < 16; i++)
                    list[i].Enabled = false;
            }
            if (DropDownList1.Text.Equals("Contributor"))
            {
                for (int i = 0; i < 6; i++)
                    list[i].Enabled = true;
                for (int i = 9; i < 12; i++)
                    list[i].Enabled = true;
                for (int i = 12; i < 16; i++)
                    list[i].Enabled = false;
                for (int i =6; i < 9; i++)
                    list[i].Enabled = false;
            }
            if (DropDownList1.Text.Equals("Authorized Reviewer"))
            {
                for (int i = 0; i < 6; i++)
                    list[i].Enabled = true;
                for (int i = 9; i < 12; i++)
                    list[i].Enabled = false;
                for (int i = 12; i < 15; i++)
                    list[i].Enabled = true;
                for (int i = 6; i < 9; i++)
                    list[i].Enabled = false;
                list[15].Enabled = false;
            }
            if (DropDownList1.Text.Equals("Content Manager"))
            {
                for (int i = 0; i < 6; i++)
                    list[i].Enabled = true;
                for (int i = 9; i < 12; i++)
                    list[i].Enabled = false;
                for (int i = 12; i < 16; i++)
                    list[i].Enabled = true;
                for (int i = 6; i < 9; i++)
                    list[i].Enabled = false;
            }
            if (DropDownList1.Text.Equals("Choose a User Type"))
            {
                foreach (TextBox a in list)
                    a.Enabled = false;
            }
        }

        protected void MyButton_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            cnn.InfoMessage += new SqlInfoMessageEventHandler(Cnn_InfoMessage);
            SqlTransaction trans = cnn.BeginTransaction();
            SqlCommand cmd = new SqlCommand("Register_User", cnn,trans);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", TextBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@usertype",DropDownList1.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@password", TextBox2.Text));
                cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@firstname", TextBox3.Text));
                cmd.Parameters.Add(new SqlParameter("@middlename", TextBox4.Text));
                cmd.Parameters.Add(new SqlParameter("@lastname", TextBox5.Text));
                cmd.Parameters.Add(new SqlParameter("@birth_date", TextBox6.Text));
                cmd.Parameters.Add(new SqlParameter("@working_place_name", TextBox7.Text));
                cmd.Parameters.Add(new SqlParameter("@working_place_type", TextBox8.Text));
                cmd.Parameters.Add(new SqlParameter("@working_place_description", TextBox9.Text));
                cmd.Parameters.Add(new SqlParameter("@specilization", TextBox10.Text));
                cmd.Parameters.Add(new SqlParameter("@portofolio_link", TextBox11.Text));
                if (DropDownList1.SelectedValue.Equals("Contributor"))
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@years_experience", Convert.ToInt32(TextBox12.Text)));
                    }
                    catch { sqlerror = "Make sure that Years of Experience field is a number"; }
                else
                    cmd.Parameters.Add(new SqlParameter("@years_experience", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@hire_date", TextBox13.Text));
                if (DropDownList1.SelectedValue.Equals("Authorized Reviewer") || DropDownList1.SelectedValue.Equals("Content Manager"))
                {
                    if (!TextBox14.Text.Equals(""))
                        try
                        {
                            cmd.Parameters.Add(new SqlParameter("@working_hours", Convert.ToInt32(TextBox14.Text)));
                        }
                        catch { sqlerror = "Make sure that Working Hours field is a number"; }
                    else
                        cmd.Parameters.Add(new SqlParameter("@working_hours", DBNull.Value));

                    if (!TextBox15.Text.Equals(""))
                        try
                        {
                            cmd.Parameters.Add(new SqlParameter("@payment_rate", Convert.ToDouble(TextBox15.Text)));
                        }
                        catch { sqlerror = "Make sure that Payment Rate field is a number"; }
                    else
                        cmd.Parameters.Add(new SqlParameter("@payment_rate", DBNull.Value));

                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@payment_rate", DBNull.Value)); cmd.Parameters.Add(new SqlParameter("@working_hours", DBNull.Value));

                }
                int id = 0;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
                    }
                    catch { }
                }


                if (DropDownList1.SelectedValue.Equals("Content Manager"))
                {
                    SqlCommand cmd1 = new SqlCommand("Check_type", cnn, trans);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@typename", TextBox16.Text));
                    cmd1.Parameters.Add(new SqlParameter("@content_manager_id", id));
                    cmd1.ExecuteNonQuery();
                }
                
                trans.Commit();
                Session["ID"] = id;
                if (id!=0 && id!=-1)
                Response.Redirect("Default.aspx");
                else
                   Label24.Text = sqlerror;
                sqlerror = "";

            }
            catch (SqlException ex) {
                sqlerror = "Make Sure you have filled all necessary fields";
                Label24.Text = sqlerror;
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