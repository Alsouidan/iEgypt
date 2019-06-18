using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company
{
    public partial class Contributer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void button1Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Upload Original Content.aspx");
        }

        public void button2Clicked(object sender, EventArgs e)
        {
            Response.Redirect("New Requests.aspx");
        }

        public void button3Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer Messages.aspx");
        }

        public void button4Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Upload New Content.aspx");
        }

        public void button5Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Delete Content.aspx");
        }

        public void button6Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer Notifications.aspx");
        }

        public void button7Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer Events.aspx");
        }

        public void button8Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Contributer Advertisements.aspx");
        }

        public void button9Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}