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
    public partial class Viewer : System.Web.UI.Page
    {
        public int s;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            s = Convert.ToInt32(Session["ID"].ToString());
            GetData();
            if (!IsPostBack)
            {
                MaintainScrollPositionOnPostBack = true;
                binddata();
            }
        }
        
        private void GetData()
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);
            
            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Select * from [user],viewer where [user].id=@id and [user].id=viewer.id";

            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id", s);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output += "Fullname: " + dataReader.GetValue(2).ToString() + " " + dataReader.GetValue(3).ToString() + " " + dataReader.GetValue(4).ToString() + "</br>" +
                    "Email: " + dataReader.GetValue(1).ToString() + "</br>" + "Password: " + dataReader.GetValue(7).ToString() + "</br>" +
                    "Birth Date: " + dataReader.GetValue(5).ToString() + "    Age:" + dataReader.GetValue(6).ToString()+"</br>" +
                    "Working Place: "+ dataReader.GetValue(11).ToString()+"</br>"+"Working Place Type: "+ dataReader.GetValue(12).ToString()
                    + "</br>" + "Working Place Description " + dataReader.GetValue(13).ToString();
                ////Response.Write(dataReader.GetValue(1));
                //if (s != null & dataReader.GetValue(0).ToString().Equals(s)) {
                //    Output = Output + " NEW : </br>";
                //}
                //else {
                //    Output = Output + "OLD : </br>";
                //}
                //Output = Output + " " + dataReader.GetValue(0) + " Email: " + dataReader.GetValue(1) + ", First Name: " + dataReader.GetValue(3) + "</br>";
                //if (Session["ID"] != null & Convert.ToInt32(Session["ID"]) == Convert.ToInt32(dataReader.GetValue(0)))
                //{
                //    //&Session["ID"].ToString().Equals()
                //    Output = Output + "Password : " + dataReader.GetValue(2) + " <br>";
                //}
            }



            //Response.Write(Session["ID"]);

            dataReader.Close();
            //command.dispose();
            cnn.Close();
            Label2.Text = Output;
            
        }
        public void binddata()
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);
            string com = "select content.id,'Link: ' + link + '  Category/SubCategory  Type: ' + category_type + '/' + subcategory_name+ '  Type: ' + [type] as 'Info' from content, Original_content where content.id = Original_content.id and Original_content.rating >= 4;";
           
                SqlDataAdapter adpt = new SqlDataAdapter(com, cnn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Info";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                com = "Select [user].id,first_name+' '+middle_name+' '+last_name as 'Fullname'" +
                   " from [user],contributor where [user].id=contributor.id";
                adpt = new SqlDataAdapter(com, cnn);
                DataTable dt1 = new DataTable();
                adpt.Fill(dt1);
                DropDownList2.DataSource = dt1;
                DropDownList2.DataTextField = "Fullname";
                DropDownList2.DataValueField = "ID";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("No Specific Contributor", ""));
            com = "select information,id from new_request where  (accept_status=0 or accept_status is null) and viewer_id=" + s + ";";
            adpt = new SqlDataAdapter(com, cnn);
                dt1 = new DataTable();
                adpt.Fill(dt1);
                DropDownList3.DataSource = dt1;
                DropDownList3.DataTextField = "information";
                DropDownList3.DataValueField = "id";
                DropDownList3.DataBind();

                com = "select content.id,'Link: ' + link + '  Category/SubCategory  Type: ' + category_type + '/' + subcategory_name+ '  Type: ' + [type] as 'Info' from content, Original_content where content.id = Original_content.id ;";
                adpt = new SqlDataAdapter(com, cnn);
                dt1 = new DataTable();
                adpt.Fill(dt1);
                DropDownList4.DataSource = dt1;
                DropDownList4.DataTextField = "Info";
                DropDownList4.DataValueField = "id";
                DropDownList4.DataBind();
            com = "select content.id,'Link: ' + link + '  Category/SubCategory  Type: ' + category_type + '/' + subcategory_name+ '  Type: ' + [type] as 'Info' from content, Original_content where content.id = Original_content.id ;";
            adpt = new SqlDataAdapter(com, cnn);
            dt1 = new DataTable();
            adpt.Fill(dt1);
            DropDownList5.DataSource = dt1;
            DropDownList5.DataTextField = "Info";
            DropDownList5.DataValueField = "id";
            DropDownList5.DataBind();

            com = "select convert(varchar(40),viewer_id)+'#'+convert(varchar(40),original_content_id)+ '#' + convert(varchar(40),[date],21) + '#' +[text] as 'key',' Comment: '+[text]+ ' Link: ' + link + '  Category/SubCategory  Type: ' + category_type + '/' + subcategory_name + '  Type: ' + [type] as 'Info' from Comment, Original_content, content where original_content_id = Original_content.id and Original_content.id = content.id and viewer_id=" + s + ";";
            adpt = new SqlDataAdapter(com, cnn);
            dt1 = new DataTable();
            adpt.Fill(dt1);
            DropDownList6.DataSource = dt1;
            DropDownList6.DataTextField = "Info";
            DropDownList6.DataValueField = "key";
            DropDownList6.DataBind();
            com = "select convert(varchar(40),viewer_id)+'#'+convert(varchar(40),original_content_id)+ '#' + convert(varchar(40),[date],21) + '#' +[text] as 'key',' Comment: '+[text]+ ' Link: ' + link + '  Category/SubCategory  Type: ' + category_type + '/' + subcategory_name + '  Type: ' + [type] as 'Info' from Comment, Original_content, content where original_content_id = Original_content.id and Original_content.id = content.id and viewer_id=" + s + ";";
            adpt = new SqlDataAdapter(com, cnn);
            dt1 = new DataTable();
            adpt.Fill(dt1);
            DropDownList7.DataSource = dt1;
            DropDownList7.DataTextField = "Info";
            DropDownList7.DataValueField = "key";
            DropDownList7.DataBind();
          
                 com = "select advertisement.id,'Description: '+[Description]+'  Location: '+[location] as 'Info' from advertisement where viewer_id=" + s + ";";
            adpt = new SqlDataAdapter(com, cnn);
            dt1 = new DataTable();
            adpt.Fill(dt1);
            DropDownList9.DataSource = dt1;
            DropDownList9.DataTextField = "Info";
            DropDownList9.DataValueField = "id";
            DropDownList9.DataBind();
            com = "select  content.contributer_id as 'id','Link: ' + link + '  Category/SubCategory  Type: ' + category_type + '/' + subcategory_name + '  Type: ' + [type] as 'Info' from content, new_content, new_request where content.id = New_content.id and New_content.new_request_id = new_request.id and new_request.viewer_id=" + s + ";";
            adpt = new SqlDataAdapter(com, cnn);
            dt1 = new DataTable();
            adpt.Fill(dt1);
            ListBox1.DataSource = dt1;
            ListBox1.DataTextField = "Info";
            ListBox1.DataValueField = "id";
            ListBox1.DataBind();
        }
        protected void button1Clicked(object sender, EventArgs e)
        {

            Response.Redirect("New_Event.aspx");
        }

        protected void button2Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Apply_Existing_Request";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@viewer_id", s));
            command.Parameters.Add(new SqlParameter("@original_content_id", DropDownList1.SelectedValue));
            try
            {  
                command.ExecuteNonQuery();
                Label5.Text = "Content has been bought successfully";
            }
            catch { Label5.Text = "An Error has occured"; }
            finally { cnn.Close(); }binddata();


            
        }

        protected void button3Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Apply_New_Request";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@viewer_id", s));
            if (DropDownList2.SelectedValue.Equals(""))
                command.Parameters.Add(new SqlParameter("@contributor_id", DBNull.Value));
            else
                command.Parameters.Add(new SqlParameter("@contributor_id", DropDownList2.SelectedValue));
            command.Parameters.Add(new SqlParameter("@information", TextBox1.Text));
            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Request has been made";
            }
            catch { Label5.Text = "An Error has occured"; }
            finally { cnn.Close(); }binddata();
        }

        protected void button4Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Delete_New_Request";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@request_id", DropDownList3.SelectedValue));
           
            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Request has been deleted";
            }
            catch { Label5.Text = "An Error has occured"; }
            finally { cnn.Close();
            }binddata();
        }

        protected void button5Clicked(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Rating_Original_Content";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@viewer_id", s));
            command.Parameters.Add(new SqlParameter("@orignal_content_id", DropDownList4.SelectedValue));
            System.Diagnostics.Debug.WriteLine(DropDownList4.SelectedValue);

            try
            {
                if (Convert.ToDouble(TextBox2.Text) > 5 || Convert.ToDouble(TextBox2.Text) < 0) { Label5.Text = "Please Rate with a number between 0 and 5";return; }
                else
                command.Parameters.Add(new SqlParameter("@rating_value", Convert.ToDouble(TextBox2.Text)));
            }
            catch { Label5.Text = "Please Make Sure the Rating field is a number";return; }
            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Rating has been made";
            }
            catch (Exception e1) {
                System.Diagnostics.Debug.WriteLine(e1.Message);
                Label5.Text = "You have already rated this content"; }
            finally { cnn.Close(); }binddata();
        }

        protected void button6Clicked(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Write_Comment";
            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@viewer_id", s));
            command.Parameters.Add(new SqlParameter("@original_content_id", DropDownList5.SelectedValue));
            command.Parameters.Add(new SqlParameter("@comment_text", TextBox3.Text));
            command.Parameters.Add(new SqlParameter("@written_time", DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond)))); 

            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Comment has been made";
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine(e1.Message);
                Label5.Text = "An error has occured";
            }
            finally { cnn.Close(); }
            binddata();

        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Edit_Comment";
            string[] tokens = DropDownList6.SelectedValue.Split('#');
            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@viewer_id", tokens[0]));
            command.Parameters.Add(new SqlParameter("@original_content_id", tokens[1]));
            command.Parameters.Add(new SqlParameter("@comment_text", TextBox4.Text));
            command.Parameters.Add(new SqlParameter("@last_written_time", tokens[2]));
            command.Parameters.Add(new SqlParameter("@updated_written_time", DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond))));


            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Comment has been edited";
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine(e1.Message);
                Label5.Text = "An error has occured";
            }
            finally { cnn.Close(); }
            binddata();
        }

        protected void button8Clicked(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Delete_Comment";
            string[] tokens = DropDownList7.SelectedValue.Split('#');
            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@viewer_id", tokens[0]));
            command.Parameters.Add(new SqlParameter("@original_content_id", tokens[1]));
            command.Parameters.Add(new SqlParameter("@written_time", tokens[2]));


            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Comment has been deleted";
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine(e1.Message);
                Label5.Text = "An error has occured";
            }
            finally { cnn.Close(); }
            binddata();
        
        
    }

        protected void button9Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            SqlCommand cmd = new SqlCommand("Create_Ads", cnn);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@description", TextBox5.Text));
                cmd.Parameters.Add(new SqlParameter("@location", TextBox6.Text));
                cmd.Parameters.Add(new SqlParameter("@viewer_id", s));
                cmd.ExecuteNonQuery();
                Label5.Text = "Advertisement has been created";
                binddata();
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.Message);
                }

            }
            finally { cnn.Close(); }
        }

       
       

        protected void button11Clicked(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Delete_ads";
            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ad_id", DropDownList9.SelectedValue));


            try
            {
                command.ExecuteNonQuery();
                Label5.Text = "Advertisement has been deleted";
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine(e1.Message);
                Label5.Text = "An error has occured";
            }
            finally { cnn.Close(); }
            binddata();
        }

        protected void button12Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Edit_Ad.aspx");
        }

        protected void button13Clicked(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");
        }

        protected void setLink(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql;


            sql = "Select first_name + ' '+middle_name+' '+last_name+'''s Profile' from [user],contributor where [user].id=contributor.id and [user].id=@id";

            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id", ListBox1.SelectedValue);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                LinkButton1.Text = dataReader.GetValue(0).ToString();
            }
            dataReader.Close();
            cnn.Close();
        }

        protected void ViewProfile(object sender, EventArgs e)
        {
            Session["CID"] = ListBox1.SelectedValue;
            Response.Redirect("Contributor_Details.aspx");
        
        }
    }
}