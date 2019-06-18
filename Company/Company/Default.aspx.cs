using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;

namespace Company
{

    public partial class Default : System.Web.UI.Page
    {
        String sqlerror;
        String s;
        int code;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            if (!IsPostBack)
            {
                string com = "Select [user].id,first_name+' '+middle_name+' '+last_name as 'Fullname'" +
                " from [user],contributor where [user].id=contributor.id";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Fullname";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("", ""));
            }
            s = Request.QueryString["ID"];
            try { s = Session["ID"].ToString();
                setcode();
                LinkButton1.Visible = true; }
            catch (Exception e2)
            {
                System.Diagnostics.Debug.WriteLine(e2.Message);
                Button7.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label6.Visible = true;
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                Button8.Visible = false;
                Button9.Visible = false;
                Button10.Visible = false;
            }


            if (s != null) {
                Button7.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button8.Visible = true;
                GetData();
                Button9.Visible = true;
                Button10.Visible = true;

            }
            //ListView1.DataSource = this.GetData();
            //ListView1.DataBind();
            //GetData();

        }
        public void setcode(){
            string email;
            string password;
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();
            SqlCommand cmd = new SqlCommand("gettype", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(s)));
            cmd.Parameters.Add("@code", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                code = Convert.ToInt32(cmd.Parameters["@code"].Value);
                System.Diagnostics.Debug.WriteLine(code);
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
            sql = "";
            switch (code)

            {
                case 1: sql = "select * from [user],viewer where [user].id=@id and [user].id=[viewer].id"; LinkButton1.Text = "Actions"; break;
                case 2: sql = "select * from [user],contributor where [user].id=@id and [user].id=[contributor].id"; LinkButton1.Text = "Actions"; break;
                case 3: sql = "select * from [user],staff where [user].id=@id and [user].id=[staff].id";LinkButton1.Text = "Actions"; break;
                case 4: sql = "select * from [user],staff,content_manager where [user].id=@id and [user].id=[staff].id and content_manager.id=[user].id"; LinkButton1.Text = "Actions"; break;
                default: sql = "select * from [user] where id=@id";break;
            }

            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(s));
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output += "My Profile: </br>"+"Fullname: " + dataReader.GetValue(2).ToString() + " " + dataReader.GetValue(3).ToString() + " " + dataReader.GetValue(4).ToString() + "</br>" +
                    "Email: " + dataReader.GetValue(1).ToString() + "</br>" + "Password: " + dataReader.GetValue(7).ToString() + "</br>" +
                    "Birth Date: " + dataReader.GetValue(5).ToString() + "    Age:" + dataReader.GetValue(6).ToString() + "</br>";
                switch (code) {
                    case 1:Output=Output+"Working Place: " + dataReader.GetValue(11).ToString() + "</br>" + "Working Place Type: " + dataReader.GetValue(12).ToString()
                 + "</br>" + "Working Place Description " + dataReader.GetValue(13).ToString();break;
                    case 2:Output = Output + "Years of Experience: " + dataReader.GetValue(11).ToString() + "</br>" + "Portofolio Link: " + dataReader.GetValue(12).ToString() + "</br>"
                   + "Specialization: " + dataReader.GetValue(13).ToString() + "</br>";break;
                    case 3:Output = Output + "Hire Date :" + dataReader.GetValue(11).ToString() + "</br>" + "Working Hours: " + dataReader.GetValue(12).ToString() + "</br>" +
                            "Payment Rate: " + dataReader.GetValue(13).ToString() + "</br>" + "Total Salary: " + dataReader.GetValue(14).ToString() + "</br>";break;
                    case 4:
                        Output = Output + "Hire Date :" + dataReader.GetValue(11).ToString() + "</br>" + "Working Hours: " + dataReader.GetValue(12).ToString() + "</br>" +
                         "Payment Rate: " + dataReader.GetValue(13).ToString() + "</br>" + "Total Salary: " + dataReader.GetValue(14).ToString() + "</br>" + "Type: " + dataReader.GetValue(17).ToString() + "</br>";break;
                            }
            
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

           Label7.Text = Output;
        }
        public void search() {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Original_Content_Search";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (CB1.Checked)
            {
                command.Parameters.Add(new SqlParameter("@typename", tb1.Text));
                command.Parameters.Add(new SqlParameter("@categoryname", "null"));
            }
            if (CB2.Checked)
            {
                command.Parameters.Add(new SqlParameter("@typename", "null"));
                command.Parameters.Add(new SqlParameter("@categoryname", tb1.Text));
            }
            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output += "Type Name: " + dataReader.GetValue(12).ToString() + " Rating:" + dataReader.GetValue(5).ToString() +
                        " Link:" + dataReader.GetValue(7).ToString() + " Category Type:" + dataReader.GetValue(9).ToString() + " Sub Category:" +
                        dataReader.GetValue(11).ToString() + "</br>";
                }
                dataReader.Close();
            }
            catch { Output = "An Error has occured,please check the fields"; }
            if (Output.Equals(" "))
                Output = "No results";
            cnn.Close();
            L1.Text = Output;
            }
        public void search2()
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Contributor_Search";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@fullname", tb2.Text));

            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output += "Fullname: " + dataReader.GetValue(7).ToString() + " " + dataReader.GetValue(8).ToString() + " " + dataReader.GetValue(9).ToString() + " Birthdate:" + dataReader.GetValue(10).ToString() +
                        " Age:" + dataReader.GetValue(11).ToString() + " Years of Experience:" + dataReader.GetValue(1).ToString() + " Specialization:" + dataReader.GetValue(3).ToString() + " Portofolio Link:" + dataReader.GetValue(2).ToString() + " Email:" + dataReader.GetValue(6).ToString();
                }
                dataReader.Close();
            }
            catch { Output = "An Error has occured,please check the fields"; }
            if (Output.Equals(" "))
                Output = "No results";
            cnn.Close();
            L1.Text = Output;
        }
        public void show() {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Order_Contributor";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output += "Fullname: " + dataReader.GetValue(7).ToString() + " " + dataReader.GetValue(8).ToString() + " " + dataReader.GetValue(9).ToString() + " Birthdate:" + dataReader.GetValue(10).ToString() +
                        " Age:" + dataReader.GetValue(11).ToString() + " Years of Experience:" + dataReader.GetValue(1).ToString() + " Specialization:" + dataReader.GetValue(3).ToString() + " Portofolio Link:" + dataReader.GetValue(2).ToString() + " Email:" + dataReader.GetValue(6).ToString()+"</br>";
                }
                dataReader.Close();
            }
            catch { Output = "An Error has occured,please check the fields"; }
            if (Output.Equals(" "))
                Output = "No results";
            cnn.Close();
            L1.Text = Output;
        }
        public void search3()
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Show_Original_content";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {if (!DropDownList1.Text.Equals(""))
                    command.Parameters.Add(new SqlParameter("@contributor_id", Int32.Parse(DropDownList1.SelectedValue)));
                else
                    command.Parameters.Add(new SqlParameter("@contributor_id", DBNull.Value));
            }
            catch { L1.Text = "Please Enter a number in this field"; cnn.Close(); return; }
            

            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output += "Fullname: " + dataReader.GetValue(20).ToString() + " " + dataReader.GetValue(21).ToString() + " " + dataReader.GetValue(22).ToString() + " Birthdate:" + dataReader.GetValue(23).ToString() +
                        " Age:" + dataReader.GetValue(24).ToString() + " Years of Experience:" + dataReader.GetValue(14).ToString() + " Specialization:" + dataReader.GetValue(16).ToString() + " Portofolio Link:" + dataReader.GetValue(15).ToString() + " Email:" + dataReader.GetValue(19).ToString() +
                        " Content Info, ID:" + dataReader.GetValue(0).ToString() + " Rating:" + dataReader.GetValue(5).ToString() + " Link:" + dataReader.GetValue(7).ToString() + " Uploaded at:" + dataReader.GetValue(8).ToString() + " Category Type:" + dataReader.GetValue(9).ToString() + " Sub Category name:" + dataReader.GetValue(11).ToString() + " Type:" + dataReader.GetValue(12).ToString() + "</br>";
                }
                dataReader.Close();
            }
            catch(Exception e) { Output = "An Error has occured,please check the fields";Console.WriteLine(e.Message); }
            if (Output.Equals(" "))
                Output = "No results";
            cnn.Close();
            L1.Text = Output;
        }
        public void Login() {
            string email;
            string password;

           


            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();
            cnn.InfoMessage += new SqlInfoMessageEventHandler(Cnn_InfoMessage);
            SqlCommand cmd = new SqlCommand("User_login", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@email", TextBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@password", TextBox2.Text));

            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            int e_id = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                e_id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
            }

            //command.dispose();
            if (e_id == 0 || e_id==-1) {
                Session["ID"] = null;
            }
            else
            Session["ID"] = e_id;
            if (e_id != -1 && e_id != 0)
            {
                Response.Redirect("Default.aspx");
                 cnn.Close();
            }
            else
            {


                cnn.Close();
                System.Diagnostics.Debug.WriteLine(sqlerror);
                L1.Text = sqlerror;
            }
            sqlerror = "";



        }

        private void Cnn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            sqlerror+=e.Message+"\n";
        }
        public void deactivate()
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Deactivate_Profile";

            command = new SqlCommand(sql, cnn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("user_id", Convert.ToInt32(s)));
            command.ExecuteNonQuery();
            L1.Text = "You have deactivated your profile";
        }

        public void button1Clicked(object sender, EventArgs args)
        {

            Response.Redirect("Register.aspx");
        }

        public void button2Clicked(object sender, EventArgs args)
        {
            search();
            //Response.Redirect("Login.aspx");
        }
        public void button3Clicked(object sender, EventArgs args)
        {
            search2();
            //Response.Redirect("Login.aspx");
        }
        public void button4Clicked(object sender, EventArgs args)
        {
            show();
            //Response.Redirect("Login.aspx");
        }
        public void button5Clicked(object sender, EventArgs args)
        {
            search3();
            //Response.Redirect("Login.aspx");
        }
        public void button6Clicked(object sender, EventArgs args)
        {
            
            Response.Redirect("Register.aspx");
        }
        public void button7Clicked(object sender, EventArgs args)
        {
            Login();
        }
        public void button8Clicked(object sender, EventArgs args)
        {
            deactivate();
        }
        public void button9Clicked(object sender, EventArgs args)
        {   Response.Redirect("Edit.aspx");

        }
        public void button10Clicked(object sender, EventArgs args)
        {
            Session["ID"] = null;
            Response.Redirect("Default.aspx");

        }
        public void Link1ButtonClicked(object sender, EventArgs args)
        {
            switch (code) {
                case 1:Response.Redirect("viewer.aspx");break;
                case 2: Response.Redirect("Contributer.aspx"); break;
                case 3: Response.Redirect("Staff Member.aspx"); break;
                case 4: Response.Redirect("Staff Member.aspx"); break;
            }
        }
        public void CheckBox1(object sender, EventArgs e)
        {
            if (CB1.Checked)
            {
                CB2.Enabled = false;
            }
            else
            {
                CB2.Enabled = true;
            }
        }
        public void CheckBox2(object sender, EventArgs e)
        {

            if (CB2.Checked)
                CB1.Enabled = false;
            else
                CB1.Enabled = true;
        }
        }

}
