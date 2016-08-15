using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TropicalServer.UI
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
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

        private void dataBind()
        {
            DataSet itemData = getItemData("orderJoinCustomer");
            GridView1.DataSource = itemData;
            GridView1.DataBind();
        }

        private DataSet updateItemData(string procedure, string orderTracking,
            /*DateTime orderDate,*/ int custNo/*, string custName, string custAddress, int custRouteNo*/)
        {
            string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand(procedure, sqlcon);
            cmd.Parameters.Add("@OrderTrackingNo", SqlDbType.VarChar).Value = orderTracking;
            //cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orderDate;
            cmd.Parameters.Add("@CustNumber", SqlDbType.Int).Value = custNo;
            //cmd.Parameters.Add("@CustName", SqlDbType.VarChar).Value = custName;
            //cmd.Parameters.Add("@CustOfficeAddress", SqlDbType.VarChar).Value = custAddress;
            //cmd.Parameters.Add("@CustRoutNo", SqlDbType.Int).Value = custRouteNo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlcon.Close();

            return ds;
        }

        private DataSet deleteItemData(string procedure, string orderTracking,
            DateTime orderDate, int custNo)
        {
            string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand(procedure, sqlcon);
            cmd.Parameters.Add("@OrderTrackingNo", SqlDbType.VarChar).Value = orderTracking;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orderDate;
            cmd.Parameters.Add("@CustNumber", SqlDbType.Int).Value = custNo;
           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlcon.Close();

            return ds;
        }
    

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            dataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            dataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            string orderTracking = ((TextBox)row.FindControl("trackingtbx")).Text;
            //DateTime orderDate = Convert.ToDateTime(GridView1.Rows[e.RowIndex].FindControl("orderDate").ToString());
            string custID = ((Label)GridView1.Rows[e.RowIndex].FindControl("CustIDlbl")).Text;
            //string custName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("CustName")).Text;
            //string custAddress = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("CustAddress")).Text;
            //string custRoute = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("CustRoute")).Text;

            updateItemData("updateOrderCustomer", orderTracking, /*orderDate,*/Convert.ToInt32(custID)/*, custName, custAddress, Convert.ToInt32(custRoute)*/);
            GridView1.EditIndex = -1;
            dataBind();
        }

        //protected void MsgBox(string msg)
        //{
        //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        //}

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            string orderTracking = ((Label)row.FindControl("trackinglbl")).Text;
            string custID = ((Label)GridView1.Rows[e.RowIndex].FindControl("CustIDlbl")).Text;
            //MsgBox(((Label)GridView1.Rows[e.RowIndex].FindControl("orderdate")).Text);
            string date = ((Label)GridView1.Rows[e.RowIndex].FindControl("orderdate")).Text;
            DateTime orderdate = DateTime.Parse(date);
            //GridView1
            deleteItemData("deleteOrder", orderTracking, orderdate, Convert.ToInt32(custID));
            dataBind();
        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if(e.CommandName == "View")
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = GridView1.Rows[index];
        //        try
        //        {
        //            trackingId.Text = (GridView1.SelectedRow.FindControl("trackinglbl") as Label).Text;
        //        }
        //        catch
        //        {
        //            trackingId.Text = " ";
        //        }
                
                
        //    }
        //}

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOrderDate.Text = (GridView1.SelectedRow.FindControl("orderdate") as Label).Text;
            lblCustID.Text = (GridView1.SelectedRow.FindControl("CustIDlbl") as Label).Text;
            lblCustName.Text = (GridView1.SelectedRow.FindControl("CustNamelbl") as Label).Text;
            lblAddress.Text = (GridView1.SelectedRow.FindControl("addresslbl") as Label).Text;
            lblRoute.Text = (GridView1.SelectedRow.FindControl("routelbl") as Label).Text;
            mpe.Show();
        }
    }
}