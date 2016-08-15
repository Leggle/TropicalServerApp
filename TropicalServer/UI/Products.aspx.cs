using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TropicalServer.UI
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = getItemData("itemType");
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                Cache["itemNum"] = 0;
            }

            if (Cache["ItemData"] != null)
            {
                //MsgBox("Loading from cache!");
                DataSet itemData = (DataSet)Cache["ItemData"];
                GridView1.DataSource = itemData;
                GridView1.DataBind();
            }
            else
            {
                DataSet itemData = getItemData("item");
                Cache["ItemData"] = itemData;
                GridView1.DataSource = itemData;
                GridView1.DataBind();
            }
        }

        protected void MsgBox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        private DataSet getItemData(string procedure)
        {
            string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand(procedure, sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlcon.Close();

            return ds;
        }

        private DataSet getItemData(int itemTypeNum)
        {
            string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand("itemWithType", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", itemTypeNum);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlcon.Close();

            return ds;
        }

        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            int a = Convert.ToInt32(e.CommandArgument);

            GridView1.PageIndex = 0;

            Cache["itemNum"] = a;

            if (Cache["ItemData"] != null)
            {
               // MsgBox("Loading from cache!");
                DataSet item = (DataSet)Cache["ItemData"];
                DataTable itemTable;

                try
                {
                    DataRow[] itemRow = item.Tables[0].Select("ItemType=" + a);
                    itemTable = itemRow.CopyToDataTable<DataRow>();
                }
                catch
                {
                    itemTable = new DataTable();
                }


                //MsgBox(""+ itemTable.Rows.Count);

                GridView1.DataSource = itemTable;
                GridView1.DataBind();
                
            }
            else
            {
                DataSet ds = getItemData(a);

                GridView1.DataSource = ds;
                GridView1.DataBind();

            }

            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            if(Convert.ToInt32(Cache.Get("itemNum")) != 0)
            {
                GridView1.DataSource = getItemData(Convert.ToInt32(Cache["itemNum"]));
            }
            
            GridView1.DataBind();
        }
    }
}