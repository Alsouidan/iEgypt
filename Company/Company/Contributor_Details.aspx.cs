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
    public partial class Contributor_Details : System.Web.UI.Page
    {
        int s;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                s = Convert.ToInt32(Session["CID"].ToString());
            }
            catch { }
            getdata();
        }

        protected void button1Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Viewer.aspx");

        }
        public void getdata()
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";

            sql = "select * from [user],contributor where [user].id=@id and [user].id=[contributor].id";


            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(s));
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output += "Fullname: " + dataReader.GetValue(2).ToString() + " " + dataReader.GetValue(3).ToString() + " " + dataReader.GetValue(4).ToString() + "</br>" +
                    "Email: " + dataReader.GetValue(1).ToString() + "</br>" +
                    "Birth Date: " + dataReader.GetValue(5).ToString() + "    Age:" + dataReader.GetValue(6).ToString() + "</br>";


                Output = Output + "Years of Experience: " + dataReader.GetValue(11).ToString() + "</br>" + "Portofolio Link: " + dataReader.GetValue(12).ToString() + "</br>"
               + "Specialization: " + dataReader.GetValue(13).ToString() + "</br>"; break;

            }





            //Response.Write(Session["ID"]);

            dataReader.Close();
            //command.dispose();
            cnn.Close();

            Label2.Text = Output;
        }
        }
    }
