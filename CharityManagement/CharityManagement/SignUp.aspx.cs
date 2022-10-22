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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void signup_Click(object sender, EventArgs e)
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
                        
                        string query1 = "Select count(*) from users where name='" + username.Text + "'";
                        SqlCommand cmd = new SqlCommand(query1, con);
                        con.Open();
                        var result = cmd.ExecuteScalar();
                        if ((int)result != 0)
                        {
                            Response.Write("Username " + username.Text + " already exist");
                        }
                        else {
                            string query = "INSERT INTO users (name,email,phone,password) VALUES(@name,@email,@phone,@password)";

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@name", username.Text);
                            cmd.Parameters.AddWithValue("@email", email.Text);
                            cmd.Parameters.AddWithValue("@phone", phone.Text);
                            cmd.Parameters.AddWithValue("@password", password.Text);
                            
                            cmd.ExecuteNonQuery();
                            con.Close();
                            
                            Response.Write("Data added");
                            Response.Redirect("Login.aspx");
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