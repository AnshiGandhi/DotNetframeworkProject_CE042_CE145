using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityManagement
{
    public partial class DisplayProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DeleteProfile(object sender, GridViewDeleteEventArgs e)
        {
            if (e.Cancel)
            {
                Response.Write("You can't delete untill you delete all funds raised by you.");
            }
        }

        protected void btn_clickHome(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btn_clickLogout(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}