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

        private void dataBind()
        {
            DataSet itemData = getItemData("orderJoinCustomer");
            GridView1.DataSource = itemData;
            GridView1.DataBind();
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

        private DataSet updateItemData(string procedure, string orderTracking, DateTime orderdate, int custNo)
        {
            string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand(procedure, sqlcon);
            cmd.Parameters.Add("@OrderTrackingNo", SqlDbType.VarChar).Value = orderTracking;
            cmd.Parameters.Add("@CustNumber", SqlDbType.Int).Value = custNo;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orderdate;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlcon.Close();

            return ds;
        }

        private DataSet deleteItemData(string procedure, 
            DateTime orderDate, int custNo)
        {
            string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand(procedure, sqlcon);
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            filterData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            filterData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            string orderTracking = ((TextBox)row.FindControl("trackingtbx")).Text;
            string custID = ((Label)GridView1.Rows[e.RowIndex].FindControl("CustIDlbl")).Text;
            DateTime order_date = Convert.ToDateTime(((TextBox)row.FindControl("orderDatetbx")).Text);

            updateItemData("updateOrderCustomer", orderTracking, order_date, Convert.ToInt32(custID));
            GridView1.EditIndex = -1;

            filterData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            string custID = ((Label)GridView1.Rows[e.RowIndex].FindControl("CustIDlbl")).Text;
            string date = ((Label)GridView1.Rows[e.RowIndex].FindControl("orderdate")).Text;
            DateTime orderdate = DateTime.Parse(date);
            deleteItemData("deleteOrder", orderdate, Convert.ToInt32(custID));

            //dataBind();
            filterData();
        }

        private void filterData()
        {
            if (datefilter.SelectedValue==""&& tb_custID.Text == "" && tb_custName.Text == "" && manager.SelectedValue=="")
            {
                dataBind();
            }
            else
            {
                
                string custName = tb_custName.Text;
                string managerName = manager.SelectedValue;
                string date_filter = datefilter.SelectedValue;
                DateTime before = DateTime.Now;

                switch (date_filter)
                {
                    case "":
                        before = DateTime.Now.AddYears(-100);
                        break;
                    case "today":
                        before = DateTime.Today.AddMinutes(-1);
                        break;
                    case "last7days":
                        before = DateTime.Now.AddDays(-7);
                        break;
                    case "last1month":
                        before = DateTime.Now.AddMonths(-1);
                        break;
                    case "last6months":
                        before = DateTime.Now.AddMonths(-6);
                        break;
                }

                if (tb_custID.Text == "")
                {
                    int custID = -1;
                    DataSet itemData = filterItemData("filterOrder", custID, custName,managerName, before);

                    GridView1.DataSource = itemData;
                    GridView1.DataBind();
                }
                else
                {
                    int custID = Convert.ToInt32(tb_custID.Text);
                    DataSet itemData = filterItemData("filterOrder", custID, custName, managerName, before);

                    GridView1.DataSource = itemData;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackingId.Text = (GridView1.SelectedRow.FindControl("trackinglbl") as Label).Text;
            lblOrderDate.Text = (GridView1.SelectedRow.FindControl("orderdate") as Label).Text;
            lblCustID.Text = (GridView1.SelectedRow.FindControl("CustIDlbl") as Label).Text;
            lblCustName.Text = (GridView1.SelectedRow.FindControl("CustNamelbl") as Label).Text;
            lblAddress.Text = (GridView1.SelectedRow.FindControl("addresslbl") as Label).Text;
            lblRoute.Text = (GridView1.SelectedRow.FindControl("routelbl") as Label).Text;
            mpe.Show();
        }


        private DataSet filterItemData(string procedure, int custID, string custName, string custManager, DateTime dateType)
        {
            string con = System.Configuration.ConfigurationManager.
                ConnectionStrings["SampleCon"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand(procedure, sqlcon);
            cmd.Parameters.Add("@custID", SqlDbType.Int).Value = custID;
            cmd.Parameters.Add("@custName", SqlDbType.VarChar).Value = custName;
            cmd.Parameters.Add("@custManager", SqlDbType.VarChar).Value = custManager;
            cmd.Parameters.Add("@custDate", SqlDbType.VarChar).Value = dateType;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlcon.Close();

            return ds;
        }

        protected void Unnamed_TextChanged(object sender, EventArgs e)
        {
            filterData();
        }

    }
}