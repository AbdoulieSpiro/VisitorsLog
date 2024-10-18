using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace HRSystemWeb
{
    public partial class AdministrationPortal : ControlBase
    {
        URLMessage URLMessage;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            URLMessage = new URLMessage();
            if (!IsPostBack)
            {

            }
        }

        protected void imgMngUser_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/SystemUser/SystemUserList.aspx?" + URLMessage.Encrypt("action=create&Site="));
        }

        protected void imgStockReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Reports/StockBalReport.aspx?");
        }

        protected void imgStockCard_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Reports/StockCard.aspx?");
        }

        protected void imgDeptBal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Reports/DepartmentReport.aspx?");
        }

        protected void imgDeptSal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Reports/OutletStock.aspx?");
        }
        protected void imgStoreDate_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Reports/StockBalReportAsAt.aspx?");
        }
    }
}