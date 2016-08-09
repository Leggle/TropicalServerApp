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

        protected void btnlogin_Onclick(object sender, EventArgs e)
        {

            string adminID = useridtextbox.Text;
            string pwd = passwordtextbox.Text;
            string query = "select FirstName,LastName from tblTropicalUser WHERE LoginID = @adminID and Password = @pwd";
            string msg = "<script language=\"javascript\"> alert('";

            if (adminID == "" || pwd == "")
            {
                Response.Write(msg + "UserID or password cannot be empty!" + "'); </script>");
            }
            else
            {
                string alertMsg;
                string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.AddWithValue("@adminID", adminID);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        alertMsg = "Hello, " + Convert.ToString(reader["FirstName"]) + " " + Convert.ToString(reader["LastName"]);
                        msg += alertMsg + "'); </script>";
                        Response.Write(msg);
                    }

                    if (RememberMyID.Checked == true)
                    {
                        Response.Cookies["useridtextbox"].Value = useridtextbox.Text;
                        Response.Cookies["useridtextbox"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        Response.Cookies["useridtextbox"].Expires = DateTime.Now.AddDays(-1);
                    }

                    sqlcon.Close();
                    Session["useridtextbox"] = useridtextbox.Text;
                    Response.Redirect("Logout.aspx");
                }
                else
                {
                    Response.Write(msg + "UserID or password is incorrect!" + "'); </script>");
                }
            }

        }
    }
}