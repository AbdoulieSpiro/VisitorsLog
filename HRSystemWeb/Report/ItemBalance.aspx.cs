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
    public partial class ItemBalance : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        public int Requests;
        public bool flag = true;

   //     Transaction1BL transactionBL = new Transaction1BL(0);
        public DataSet dstransaction = new DataSet();

        protected new void Page_Load(object sender, System.EventArgs e)
        {
            PageCode = "PurchaseTransactionReport";
            PageName = "Item Balance By Depot Report ";
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                lblPageName.Text =  PageName ;

                //FillGrid(SessionContext.GridPage);
               
                FillGrid(0);
            }
        }


       



      

   

        protected void drpBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            { }


        }




        private void FillGrid(int aPageNumber)
        {

         //   ItemBL ItemBL = new ItemBL(0);
            DataSet DSItem = new DataSet();
         //   ItemBL.FetchForBalance(DSItem);
            // ItemTranBL.FetchSoldForperiodicByUser(DSItem, drpBranch.SelectedValue.ToString(), WinUtility.Cast(drpItem.SelectedValue, 0), WinUtility.Cast(txtStartDate.Text, DateTime.Now), WinUtility.Cast(txtEndDate.Text, DateTime.Now), SessionContext.SystemUser);
            // ItemTranBL.FetchForItemsPurchasedPeriodic(DSItem, WinUtility.Cast(drpItem.SelectedValue, 0), WinUtility.Cast(txtStartDate.Text, DateTime.Now), WinUtility.Cast(txtEndDate.Text, DateTime.Now), drpBranch.SelectedValue);

            if (DSItem.Tables[0].Rows.Count > 0)
            {
                double Net = 0.0;
                ltxNet.Text = "0.00";

                foreach (DataRow dr in DSItem.Tables[0].Rows)
                {
            //       Net = Net + WinUtility.Cast(dr.ItemArray[6].ToString(), 0.0);
                }


                ltxNet.Text = string.Format("{0:#,##0.00}", Net);
                grdRequest.DataSource = DSItem.Tables[0].DefaultView; ;
                grdRequest.DataBind();
                flag = false;

                grdRequest.PageIndex = aPageNumber > grdRequest.PageCount ? 0 : aPageNumber;
                SessionContext.GridPage = grdRequest.PageIndex;
                // objRequest = null;
                ds = null;

                //      MessageBox.Show("No Record Found");
            }

          
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
                //Handle the selected itemX value here
                //For example, you could store it in a session variable, display it on the page, etc.
                //Response.Write("Selected ItemCode: " + itemX);
                string encodeMessage = URLMessage.Encrypt("action=update&ApproveRequest=" + Requests);
                string url = @"~/Request/ApproveRequest.aspx?" + encodeMessage;

                // Redirect to the new URL
                Response.Redirect(url);
                //Response.Redirect(@"~/Transaction/RequestList.aspx?"+encodedMessage);

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/ControlPanel/ControlPanelHomeList.aspx?");
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
