using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company
{
    public partial class Edit_Ad : System.Web.UI.Page
    {
        int s=0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                s = Convert.ToInt32(Session["ID"].ToString());
                SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                DataTable dt1 = new DataTable();
                String com = "select advertisement.id,'Description: '+[Description]+'  Location: '+[location] as 'Info' from advertisement where viewer_id=" + s + ";";
                SqlDataAdapter adpt = new SqlDataAdapter(com, cnn);
                adpt = new SqlDataAdapter(com, cnn);
                dt1 = new DataTable();
                adpt.Fill(dt1);
                DropDownList8.DataSource = dt1;
                DropDownList8.DataTextField = "Info";
                DropDownList8.DataValueField = "id";
                DropDownList8.DataBind();
                DropDownList8.Items.Insert(0, new ListItem("", ""));
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select description,[location] from advertisement where id=@id", cnn);
                cmd.Parameters.AddWithValue("@id", DropDownList8.SelectedValue);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    TextBox7.Text = dataReader.GetValue(0).ToString();
                    TextBox8.Text = dataReader.GetValue(1).ToString();
                }
                cnn.Close();
            }
        }
        protected void fillFields(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            SqlCommand cmd = new SqlCommand("select description,[location] from advertisement where id=@id", cnn);
            cmd.Parameters.AddWithValue("@id", DropDownList8.SelectedValue);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {

                TextBox7.Text = dataReader.GetValue(0).ToString();
                TextBox8.Text = dataReader.GetValue(1).ToString();
            }
            cnn.Close();
        }
        protected void button10Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Edit_Ad";
            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ad_id", DropDownList8.SelectedValue));
            command.Parameters.Add(new SqlParameter("@description", TextBox7.Text));
            command.Parameters.Add(new SqlParameter("@location", TextBox8.Text));


            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Advertisement has been edited";
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine(e1.Message);
                Label5.Text = "An error has occured";
            }
            finally { cnn.Close(); }
            Response.Redirect("Viewer.aspx");
        }

    }
}