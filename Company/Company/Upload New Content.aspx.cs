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
    public partial class Upload_New_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SubcategoryIEGYPT.SelectCommand = "Select [name] from sub_category where category_type = " + "\'" + CategoryDropdown.Text + "\'";
            requestIEGYPT.SelectCommand = "Select New_request.id, [user].email + '  information: ' + New_request.information AS info from New_request inner join [user] on [user].id=New_request.viewer_id where New_request.accept_status=1 and New_request.contributer_id=" + Session["ID"] + " and not exists(select * from new_content where new_request_id=New_request.id)";
            L1.Text = "";
        }

        public void button1Clicked(object sender, EventArgs e)
        {
            string output = "";
            int s = Convert.ToInt32(Session["ID"]);
            string type = TypeDropdown.Text;
            string category = CategoryDropdown.Text;
            string subcategory = SubcategoryDropdown.Text;
            string link = linkTB.Text;
            int requestId = Int32.Parse(RequestDropdown.SelectedValue);

            if (link.Equals(""))
            {
                output = "You have to enter a link";
                L1.Text = output;
                return;
            }

            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                SqlCommand command;
                SqlDataReader dataReader;

                String sql;
                sql = "Upload_New_Content";

                command = new SqlCommand(sql, cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@subcategory_name", subcategory));
                command.Parameters.Add(new SqlParameter("@category_id", category));
                command.Parameters.Add(new SqlParameter("@contributor_id", s));
                command.Parameters.Add(new SqlParameter("@link", link));
                command.Parameters.Add(new SqlParameter("@new_request_id", requestId));
                command.Parameters.Add(new SqlParameter("@type_id", type));

                dataReader = command.ExecuteReader();

                dataReader.Close();
                cnn.Close();

                output = "Content Uploaded Successfully";
                RequestDropdown.DataBind();
            }
            catch
            {
                output = "Make sure to complete all fields";
            }

            L1.Text = output;
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer.aspx");
        }
    }
}