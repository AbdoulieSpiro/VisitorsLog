using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HRSystemServer.BusinessLayer;
using System.Web.UI.DataVisualization.Charting;
using System.Activities.Expressions;
using System.Windows.Forms;

namespace HRSystemWeb
{
    public partial class DepartmentList : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        public int Requests;
        public bool flag = true;

        public DataSet dstransaction = new DataSet();

        protected new void Page_Load(object sender, System.EventArgs e)
        {
            PageCode = "DepartmentList";
            PageName = "Department List";
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                lblPageName.Text = "Department List ";
                //FillGrid(SessionContext.GridPage);
                loadRequest();
            }
        }

        private void loadRequest()
        {
            if (flag == true)
            {
                DataSet dsGrid = new DataSet();

                DepartmentBL DepartmentBL = new DepartmentBL(SessionContext.SystemUser);
                DepartmentBL.FetchAll(dsGrid);


                //dGVRequests.AutoGenerateColumns = false;
                //if (dsGrid.Tables[0].Rows.Count == 0)
                //{
                //    flag = false;
                //    MessageBox.Show("NO RECORD FOUND TO SUPPLY", "INFO");
                //}
                dsGrid.Tables[DepartmentBL.SqlEntityX].Columns.Add("JumpParam");
                foreach (DataRow item in dsGrid.Tables[DepartmentBL.SqlEntityX].Rows)
                {
                    item["JumpParam"] = URLMessage.Encrypt("action=update&Department=" + item["Department"].ToString());
                }

                grdRequest.DataSource = dsGrid.Tables[0];
                grdRequest.DataBind();
                flag = false;
            }

        }

        private void FillGrid(int aPageNumber)
        {
            DataSet dsGrid = new DataSet();

            DepartmentBL DepartmentBL = new DepartmentBL(SessionContext.SystemUser);
            DepartmentBL.FetchAll(dsGrid);


            //dGVRequests.AutoGenerateColumns = false;
            //if (dsGrid.Tables[0].Rows.Count == 0)
            //{
            //    flag = false;
            //    MessageBox.Show("NO RECORD FOUND TO SUPPLY", "INFO");
            //}
            dsGrid.Tables[DepartmentBL.SqlEntityX].Columns.Add("JumpParam");
            foreach (DataRow item in dsGrid.Tables[DepartmentBL.SqlEntityX].Rows)
            {
                item["JumpParam"] = URLMessage.Encrypt("action=update&Department=" + item["Department"].ToString());
            }






            //dGVRequests.AutoGenerateColumns = false;
            //if (dsGrid.Tables[0].Rows.Count == 0)
            //{
            //    flag = false;
            //    MessageBox.Show("NO RECORD FOUND TO SUPPLY", "INFO");
            //}

            grdRequest.DataSource = dsGrid.Tables[0].DefaultView; ;
            grdRequest.DataBind();
            flag = false;




            grdRequest.PageIndex = aPageNumber > grdRequest.PageCount ? 0 : aPageNumber;
            SessionContext.GridPage = grdRequest.PageIndex;
            DepartmentBL = null;
            ds = null;
        }

        protected void grdgrdRequest_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            FillGrid(e.NewPageIndex);
        }


        protected void grdRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "SelectItem")
            {
                string Requests = e.CommandArgument.ToString();
                string encodeMessage = URLMessage.Encrypt("action=update&Department=" + Requests);
                string url = @"~/Maintenance/Department.aspx?" + encodeMessage;
                Response.Redirect(url);
            }


            if (e.CommandName == "View")
            {
                string Requests = e.CommandArgument.ToString();
                string encodeMessage = URLMessage.Encrypt("action=view&Department=" + Requests);
                string url = @"~/Maintenance/Department.aspx?" + encodeMessage;
                Response.Redirect(url);
            }
        }

        private void Navigate(String Url)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/ControlPanel/ControlPanelHomeList.aspx?");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Maintenance/Department.aspx?");
        }

        protected void grdRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRequest.PageIndex = e.NewPageIndex > grdRequest.PageCount ? 0 : e.NewPageIndex;
            FillGrid(e.NewPageIndex);
        }



        public void FillTrainingGrid(int aPageNumber)
        {


        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
        #endregion

    }
}
