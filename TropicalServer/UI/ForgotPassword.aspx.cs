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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MsgBox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void confirmPwd(object sender, EventArgs e)
        {
            Page.Validate("r1");
            if (!Page.IsValid)
            {
                MsgBox("Login ID, new password cannot be empty!");
            }
            else
            {
                Page.Validate("r2");
                if (!Page.IsValid)
                {
                    MsgBox("Two passwords should be the same!");
                }

                string adminID = useridtextbox.Text;
                string newPwd = passwordtextbox.Text;
                string checkID = "select LoginID from tblTropicalUser WHERE LoginID = @adminID";
                string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(checkID, sqlcon);
                cmd.Parameters.AddWithValue("@adminID", adminID);
                var isIdExist = cmd.ExecuteScalar();

                if (isIdExist == null)
                {
                    MsgBox("User ID does not exist!");
                }
                else
                {
                    string updatePwd = "update tblTropicalUser set Password = @newPwd where LoginID = @adminID";
                    SqlCommand update = new SqlCommand(updatePwd, sqlcon);
                    update.Parameters.AddWithValue("@adminID", adminID);
                    update.Parameters.AddWithValue("@newPwd", newPwd);
                    int row = update.ExecuteNonQuery();

                    if (row != 0)
                    {
                        MsgBox("Updated password!");
                    }
                }

                sqlcon.Close();
            }

            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            useridtextbox.Text = "";
            passwordtextbox.Text = "";
            newpasswordtextbox.Text = "";
        }
    }
}