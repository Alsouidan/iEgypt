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
    public partial class Register : System.Web.UI.Page
    {
        public List <TextBox> list;
        public String sqlerror;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
            

        }

        public void bind()
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql;


            sql = "Select * from [user] where id=@id";

            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(Session["ID"].ToString()));
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
              
                TextBox2.Text = dataReader.GetValue(7).ToString();
                TextBox1.Text = dataReader.GetValue(1).ToString();
                TextBox3.Text = dataReader.GetValue(2).ToString();
                TextBox4.Text = dataReader.GetValue(3).ToString();
                TextBox5.Text = dataReader.GetValue(4).ToString();
                TextBox6.Text = dataReader.GetValue(5).ToString();
}   dataReader.Close();
            sql = "Select * from [viewer] where id=@id";

            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(Session["ID"].ToString()));
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {TextBox7.Text= dataReader.GetValue(1).ToString();
                TextBox8.Text = dataReader.GetValue(2).ToString();
                TextBox9.Text = dataReader.GetValue(3).ToString();
            }
            dataReader.Close();
            sql = "Select * from [contributor] where id=@id";

            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(Session["ID"].ToString()));
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                TextBox10.Text = dataReader.GetValue(3).ToString();
                TextBox11.Text = dataReader.GetValue(2).ToString();
                TextBox12.Text = dataReader.GetValue(1).ToString();
            }
            dataReader.Close();
            sql = "Select * from [staff] where id=@id";

            command = new SqlCommand(sql, cnn);
            command.Parameters.Add("@id", Convert.ToInt32(Session["ID"].ToString()));
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                TextBox13.Text = dataReader.GetValue(1).ToString();
                TextBox14.Text = dataReader.GetValue(2).ToString();
                TextBox15.Text = dataReader.GetValue(3).ToString();
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
            SqlCommand cmd = new SqlCommand("Edit_Profile", cnn,trans);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", TextBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@password", TextBox2.Text));
                System.Diagnostics.Debug.WriteLine(Session["ID"].ToString());
                cmd.Parameters.Add("@user_id", Convert.ToInt32(Session["ID"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@firstname", TextBox3.Text));
                cmd.Parameters.Add(new SqlParameter("@middlename", TextBox4.Text));
                cmd.Parameters.Add(new SqlParameter("@lastname", TextBox5.Text));
                System.Diagnostics.Debug.WriteLine(TextBox6.Text);
                cmd.Parameters.Add(new SqlParameter("@birth_date", TextBox6.Text));
                cmd.Parameters.Add(new SqlParameter("@working_place_name", TextBox7.Text));
                cmd.Parameters.Add(new SqlParameter("@working_place_type", TextBox8.Text));
                cmd.Parameters.Add(new SqlParameter("@wokring_place_description", TextBox9.Text));
                cmd.Parameters.Add(new SqlParameter("@specilization", TextBox10.Text));
                cmd.Parameters.Add(new SqlParameter("@portofolio_link", TextBox11.Text));
                    try
                    {if(!TextBox12.Text.Equals(""))
                        cmd.Parameters.Add(new SqlParameter("@years_experience", Convert.ToInt32(TextBox12.Text)));
                    else cmd.Parameters.Add(new SqlParameter("@years_experience", DBNull.Value));

                }
                catch { sqlerror = "Make sure that Years of Experience field is a number"; }
                
                cmd.Parameters.Add(new SqlParameter("@hire_date", TextBox13.Text));
                
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


                cmd.ExecuteNonQuery();
                
               


           
                
                trans.Commit();
                
                Response.Redirect("Default.aspx");
                

            }
            catch (SqlException ex) {
                sqlerror = "Make sure Dates are in the correct format";
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