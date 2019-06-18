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
    public partial class Contributer_Advertisements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            String sql = "select * from advertisement left outer join Ads_video_link on advertisement.id=Ads_video_link.advertisement_id left outer join Ads_photos_link on advertisement.id=Ads_photos_link.advertisement_id inner join [user] on [user].id=advertisement.viewer_id";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader rdr = cmd.ExecuteReader();
            string output = "";
            while(rdr.Read())
            {
                output += "<p>Description: " + rdr.GetValue(1) + " Location: " + rdr.GetValue(2) + " Video: " + rdr.GetValue(6) +
                        " Photo: " + rdr.GetValue(8) + " Advertisement Creator: " + rdr.GetValue(11) + " " + rdr.GetValue(12) + " " + rdr.GetValue(13) +
                        "</p>";
            }
            if (!rdr.HasRows)
                output = "<p>Nothing to show</p>";
            rdr.Close();
            cnn.Close();

            L1.Text = output;
        }

        public void backClicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer.aspx");
        }
    }
}