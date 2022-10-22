using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CharityManagement
{
    public partial class RaiseFund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }


        protected void btn_clickRaiseFund(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /*
                int length = 0;
                byte[] pic;
                if (FileUploadimage.HasFile)
                {

                    //length = FileUploadimage.PostedFile.ContentLength;
                    //pic = new byte[length];
                    //FileUploadimage.PostedFile.InputStream.Read(pic, 0, length);
                }
                else
                {
                    pic = null;
                }*/


                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
                string query = "INSERT INTO raisefunds (total_amount, cause, raising_for, userId,description, photo) VALUES(@total_amount,@cause,@raising_for,@u_id,@description, @photo)";
                try
                {
                    string extension = Path.GetExtension(FileUploadimage.FileName);
                    if (extension == ".jpg" || extension == ".png")
                    {
                        if (FileUploadimage.PostedFile.ContentLength < 102400)
                        {
                            string pic = Path.GetFileName(FileUploadimage.FileName);
                            FileUploadimage.SaveAs(Server.MapPath("Images/" + pic));


                            using (con)
                            {
                                using (SqlCommand cmd = new SqlCommand(query))
                                {
                                    cmd.Parameters.AddWithValue("@total_amount", Int32.Parse(amount.Text));
                                    cmd.Parameters.AddWithValue("@cause", cause.Text);
                                    cmd.Parameters.AddWithValue("@raising_for", person.Text);
                                    cmd.Parameters.AddWithValue("@u_id", Int32.Parse(Session["id"].ToString()));
                                    cmd.Parameters.AddWithValue("@description", desc.InnerText);
                                    cmd.Parameters.AddWithValue("@photo", FileUploadimage.FileName);

                                    cmd.Connection = con;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }

                                //Response.Write("Data added");
                                Response.Redirect("HomePage.aspx");
                            }
                        }
                        else
                        {
                            lblmsg.Text = "File has to be less than 100kb.";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblmsg.Text = "Only jpg and png are accepted.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Errors: " + ex.Message);
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