using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityManagement
{
    public partial class DonateFund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            lbluserName.Text = Session["userRF"].ToString();
            lblCause.Text = Session["cause"].ToString();

        }

        DataSet ds;
        protected void btn_ClickDonateFund(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                try
                {
                    using (con)
                    {
                        //for inserting values in donate fund table
                        cmd.CommandText = "Insert into donateFund Values (@amount, @RF_id, @user_id)";
                        con.Open();
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text);

                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con;
                        cmd1.CommandText = "Select * from users where name = @name";
                        cmd1.Parameters.AddWithValue("@name", Session["userRF"]);

                        
                        SqlDataReader rdr = cmd1.ExecuteReader();
                        int userId = 0;

                        while (rdr.Read())
                        {
                            userId = Int32.Parse(rdr["u_id"].ToString());
                            break;
                        }
                        rdr.Close();

                        
                        SqlCommand cmd2 = new SqlCommand();

                        cmd2.Connection = con;
                        String funding_for_cause = Session["cause"].ToString();

                        cmd2.CommandText = "Select * from raisefunds where cause = @funding_for_cause and userId = @userId";
                        cmd2.Parameters.AddWithValue("@funding_for_cause", funding_for_cause);
                        cmd2.Parameters.AddWithValue("@userId", userId);

                       

                        rdr = cmd2.ExecuteReader();
                        int RF_id = 0;

                        while (rdr.Read())
                        {
                            RF_id = Int32.Parse(rdr["RF_id"].ToString());
                            break;
                        }
                        rdr.Close();

                        cmd.Parameters.AddWithValue("@RF_id", RF_id);
                        cmd.Parameters.AddWithValue("@user_id", userId);

                        cmd.ExecuteNonQuery();


                        //for doing modification in raise fund table
                        cmd.CommandText = "Select gathered_amount From raisefunds where RF_Id = @RF_id";
                        SqlDataReader dr;
                        var amt = 0;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr.HasRows)
                            {
                                amt = (int)dr[0];
                            }
                        }
                        dr.Close();
                        cmd.CommandText = "Update raisefunds set gathered_amount='" + (amt + Int32.Parse(txtAmount.Text.ToString())) + "' where RF_Id = @RF_id";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "Select total_amount,gathered_amount from raisefunds where RF_Id = @RF_id";
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            if (Int32.Parse(rdr[0].ToString()) <= Int32.Parse(rdr[1].ToString()))
                            {
                                rdr.Close();
                                cmd.CommandText = "Update raisefunds set status='completed' where RF_Id = @RF_id";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //Response.Write("Successfull");
                        Response.Redirect("HomePage.aspx");
                    }

                }
                catch(Exception err)
                {
                    Response.Write("Error :" + err.Message);
                }
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