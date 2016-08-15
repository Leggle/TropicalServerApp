using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace TropicalServer.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["useridtextbox"] != null)
            {
                useridtextbox.Text = Request.Cookies["useridtextbox"].Value;
            }
        }

        protected void MsgBox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void btnlogin_Onclick(object sender, EventArgs e)
        {

            string adminID = useridtextbox.Text;
            string pwd = passwordtextbox.Text;
            string query = "select FirstName,LastName from tblTropicalUser WHERE LoginID = @adminID and Password = @pwd";

            Page.Validate();
            if (!Page.IsValid)
            {
                RequiredFieldValidator1.EnableClientScript = true;
                RequiredFieldValidator2.EnableClientScript = true;
            }

            //if (adminID == "" || pwd == "")
            //{
            //    Response.Write(msg + "UserID or password cannot be empty!" + "'); </script>");
            //}
            else
            {
                //string alertMsg;
                string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.AddWithValue("@adminID", adminID);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string firstname = reader["FirstName"].ToString();
                        string lastname = reader["LastName"].ToString();


                        Session["useridtextbox"] = firstname + " " + lastname;
                    }

                    if (RememberMyID.Checked == true)
                    {
                        Response.Cookies["useridtextbox"].Value = useridtextbox.Text;
                        //Response.Cookies["useridtextbox"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        Response.Cookies["useridtextbox"].Expires = DateTime.Now.AddDays(-1);
                    }

                    reader.Close();
                    sqlcon.Close();

                    Response.Redirect("Logout.aspx");
                }
                else
                {
                    MsgBox("UserID or password is incorrect!");
                    sqlcon.Close();
                }
            }

        }
    }
}