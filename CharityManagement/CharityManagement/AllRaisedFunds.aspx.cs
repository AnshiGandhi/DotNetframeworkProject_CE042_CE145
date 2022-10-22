using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityManagement
{
    public partial class AllRaisedFunds : System.Web.UI.Page
    {
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblName.Text = Session["name"].ToString();
            }

            SqlConnection conStr = new SqlConnection();
            conStr.ConnectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conStr;
            cmd.CommandText = "Select users.name, rf.total_amount, rf.cause, rf.raising_for, rf.description, rf.gathered_amount, rf.status,rf.photo from raisefunds as rf " +
                "INNER JOIN users ON rf.userId = users.u_id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();

            try
            {
                using (conStr)
                {
                    conStr.Open();
                    da.Fill(ds, "usersRaisefunds");
                }
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }

            
            //GridViewRF.DataSource = ds.Tables["usersRaisefunds"];
            //GridViewRF.DataBind();
            foreach (GridViewRow row in GridViewRF.Rows)
            {
                LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
                lb.Text = "Donate";
            }

        }

       

        
        protected void OnRowSelected(object sender, GridViewSelectEventArgs e)
        {

            Session["userRF"] = GridViewRF.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            Session["cause"] = GridViewRF.DataKeys[e.NewSelectedIndex].Values[1].ToString();
            //Session["userName"] = CurrentGVR.Cells[0].Text;

            Response.Redirect("DonateFund.aspx");
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