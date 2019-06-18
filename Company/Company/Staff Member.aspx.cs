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
    public partial class Staff_Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            button1();
        }

        public void button1()
        {
            int s = Convert.ToInt32(Session["ID"].ToString());
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "select * from Reviewer where id = " + s;
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                B1.Text = "Review Original Content";
                B1.Click += new EventHandler(button1ClickedReviewer);
            }
            rdr.Close();
            sql = "select * from Content_manager where id = " + s;
            cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                B1.Text = "Filter Original Content";
                B1.Click += new EventHandler(button1ClickedManager);
            }
        }

        public void button1ClickedReviewer(object sender, EventArgs e)
        {
            Response.Redirect("Review Original Content.aspx");
        }

        public void button1ClickedManager(object sender, EventArgs e)
        {
            Response.Redirect("Filter Original Content.aspx");
        }

        public void button2Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Create Category.aspx");
        }

        public void button3Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Create Type.aspx");
        }

        public void button4Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Most Requested Content.aspx");
        }

        public void button5Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Workingplace Category Relation.aspx");
        }

        public void button6Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Notifications.aspx");
        }

        public void button7Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Delete Comments.aspx");
        }

        public void button8Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Staff Delete Content.aspx");
        }

        public void button9Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Order Contributers.aspx");
        }

        public void button10Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Assign Contributer.aspx");
        }

        public void button11Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}