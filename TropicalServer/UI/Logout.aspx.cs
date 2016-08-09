using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TropicalServer.UI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["useridtextbox"] != null)
            {
                //Retrieving UserName from Session
                welcomelbl.Text = "Welcome : " + Session["useridtextbox"];
            }
            else
            {
                welcomelbl.Text = "Welcome!";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}