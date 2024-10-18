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
using System.IO;

namespace HRSystemWeb
{
    public partial class SaleReportDetail : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        public int Requests;
        public bool flag = true;

     //   Transaction1BL transactionBL = new Transaction1BL(0);
        public DataSet dstransaction = new DataSet();

        protected new void Page_Load(object sender, System.EventArgs e)
        {
            PageCode = "SaleTransactionReport";
            PageName = "Sale Transaction Report ";
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                lblPageName.Text =  PageName ;

                //FillGrid(SessionContext.GridPage);
                BindDropDowns();
            }
        }


       



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //   ReceivedTransactionReport();
            FillGrid(0);
        }

        private void BindDropDowns()
        {
            //WebUtility.FillDropDownList(drpDepartment, new DepartmentBL(0), "DepartmentX", "Department");
         //   WebUtility.FillDropDownList(drpBranch, new BranchBL(0), "BRANCH_NAME", "BRANCH_ID", "Branch");
            InsertSelect(drpBranch);
            WebUtility.SetDropDownListValue(drpBranch, SessionContext.Branch);


            //DataSet dsItem = new DataSet();
            //ItemBL itemBL = new ItemBL(0);
            //itemBL.FetchForBranch(dsItem, SessionContext.Branch);
            ////itemBL.FetchForBranch(dsItem, drpBranchFrom.Text.ToString());
            //WebUtility.FillDropDownList(drpItem, dsItem.Tables[0], "ItemXX", "Item");
            //InsertSelect(drpItem);


            drpBranch.Enabled = false;
            if (SessionContext.UserOrderLevel == 4)
            {
                drpBranch.Enabled = true;

            }

        }

        protected void drpBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet dsItem = new DataSet();
                //ItemBL itemBL = new ItemBL(0);
                //itemBL.FetchForBranch(dsItem, drpBranch.SelectedValue.ToString());
                ////itemBL.FetchForBranch(dsItem, drpBranchFrom.Text.ToString());
                //WebUtility.FillDropDownList(drpItem, dsItem.Tables[0], "ItemXX", "Item");
                //InsertSelect(drpItem);
            }
            catch (Exception ex)
            { }


        }




        private void FillGrid(int aPageNumber)
        {
            //ItemTranBL ItemTranBL = new ItemTranBL(0);
            //DataSet DSItem = new DataSet();
            //ItemTranBL.FetchSoldForperiodicByUser(DSItem, drpBranch.SelectedValue.ToString(), WinUtility.Cast(drpItem.SelectedValue, 0), WinUtility.Cast(txtStartDate.Text, DateTime.Now), WinUtility.Cast(txtEndDate.Text, DateTime.Now), SessionContext.SystemUser);

            //if (DSItem.Tables[0].Rows.Count == 0)
            //{
            //    //      MessageBox.Show("No Record Found");
            //}
            //else if (DSItem.Tables[1].Rows.Count > 0)
            //{
            //    ltxIssue.Text = "0.00";
            //    ltxIssueRev.Text = "0.00";
            //    ltxNet.Text = "0.00";
            //    foreach (DataRow dr in DSItem.Tables[1].Rows)
            //    {
            //        if (dr.ItemArray[0].ToString() == "Sale Reversal Transaction")
            //        {
            //            ltxIssueRev.Text = dr.ItemArray[1].ToString();
            //        }
            //        else if (dr.ItemArray[0].ToString() == "Sale Transaction")
            //        {
            //            ltxIssue.Text = dr.ItemArray[1].ToString();
            //        }

            //    }

            //    ltxNet.Text = string.Format("{0:#,##0.00}", (Convert.ToDecimal(ltxIssue.Text) - Convert.ToDecimal(ltxIssueRev.Text)));

            //}

            decimal totalAmount = 0;
            //foreach (DataRow dr in DSItem.Tables[0].Rows)
            //{
            //    totalAmount += Convert.ToDecimal(dr["Amount"]);
            //}

         //   grdRequest.DataSource = DSItem.Tables[0].DefaultView;
            grdRequest.DataBind();

            // Add the footer row with the total amount
            if (grdRequest.FooterRow != null)
            {
                grdRequest.FooterRow.Cells[0].Text = "Total";
                grdRequest.FooterRow.Cells[0].ColumnSpan = 7; // Adjust this based on your columns
                grdRequest.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                grdRequest.FooterRow.Cells.RemoveAt(1); // Remove unnecessary cells based on your columns
                grdRequest.FooterRow.Cells.RemoveAt(1);
                grdRequest.FooterRow.Cells.RemoveAt(1);
                grdRequest.FooterRow.Cells.RemoveAt(1);
                grdRequest.FooterRow.Cells.RemoveAt(1);
                grdRequest.FooterRow.Cells.RemoveAt(1);

                grdRequest.FooterRow.Cells[1].Text = totalAmount.ToString("N2");
                grdRequest.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            }



            //grdRequest.DataSource = DSItem.Tables[0].DefaultView;
            //grdRequest.DataBind();
            flag = false;

            grdRequest.PageIndex = aPageNumber > grdRequest.PageCount ? 0 : aPageNumber;
            SessionContext.GridPage = grdRequest.PageIndex;
            // objRequest = null;
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //ExportGridViewToCSV(grdRequests, "export.csv");

            ExportToExcel();
        }


        // Implement grdRequests_RowCommand and grdRequests_PageIndexChanging if needed



        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=DetailSaleTransactionReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                // To Export all pages
                grdRequest.AllowPaging = false;
                FillGrid(grdRequest.PageIndex);

                grdRequest.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdRequest.HeaderRow.Cells)
                {
                    cell.BackColor = grdRequest.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdRequest.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdRequest.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdRequest.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdRequest.RenderControl(hw);

                // Style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /* Verifies that the control is rendered */
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
