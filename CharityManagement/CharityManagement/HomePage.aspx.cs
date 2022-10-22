using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CharityManagement
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblName.Text = Session["name"].ToString();
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "Select amount,cause,description,total_amount,gathered_amount" +
                        " from donatefund inner join " +
                        "raisefunds on raisefunds.Rf_Id=donatefund.Rf_Id where donatefund.user_id=" + Session["id"];
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (String.IsNullOrEmpty(rdr.ToString()))
                    {
                        lblfunds.Text = "You have not yet donated";
                    }
                    else
                    {
                        display_donations.DataSource = rdr;
                        display_donations.DataBind();
                        while (rdr.Read())
                        {
                            display_donations.DataSource = rdr;
                            display_donations.DataBind();
                        }
                    }
                    rdr.Close();
                    con.Close();

                    string command1 = "Select * from raisefunds where userId=" + Session["id"];
                    SqlCommand cmd1 = new SqlCommand(command1, con);
                    con.Open();
                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (String.IsNullOrEmpty(rdr1.ToString()))
                    {
                        lblfunds.Text = "You have not raised any funds";
                    }
                    else
                    {
                        display_funds.DataSource = rdr1;
                        display_funds.DataBind();
                        while (rdr1.Read())
                        {
                            display_funds.DataSource = rdr1;
                            display_funds.DataBind();
                        }
                    }
                    rdr1.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }

        protected void btn_clickRaiseFund(object sender, EventArgs e)
        {
            Response.Redirect("RaiseFund.aspx");
        }

        protected void Button_ClickDonate(object sender, EventArgs e)
        {
            Response.Redirect("AllRaisedFunds.aspx");
        }

        protected void btn_clickViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("DisplayProfile.aspx");
        }

        protected void btn_clickLogout(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}