using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {


                SqlConnection con = new SqlConnection();
                //con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anshi\OneDrive\Documents\Sem_5_material\WAD\Raise Fund\RaiseFund\RaiseFund\App_Data\users.mdf;Integrated Security=True";
                con.ConnectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
                try
                {
                    using (con)
                    {
                        string query = "SELECT * from users";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                if (rdr["name"].ToString() == username.Text && rdr["password"].ToString() == password.Text)
                                {
                                    //redirect to home page
                                    Session["id"] = rdr["u_id"];
                                    Session["name"] = rdr["name"];
                                    Response.Redirect("HomePage.aspx");

                                }

                            }
                            Response.Write("Incorrect userName or password");
                            rdr.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Errors: " + ex.Message);
                }
            }
        }
    }
}