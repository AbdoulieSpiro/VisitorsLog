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

namespace HRSystemWeb.PageMapping
{
    public partial class PageMappingList : PageBase
    {

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "PageMapping";
            PageName = "Page Mapping";
            if (!Page.IsPostBack)
            {
                // ((MasterPage)(Page.Master)).PageTitle(SessionContext.SiteX + " - " + PageName);
                FillGrid(SessionContext.GridPage);
            }
        }

        private void FillGrid(int aPageNumber)
        {
            DataSet ds = new DataSet();
            PageMappingBL bl = new PageMappingBL(0);
            bl.FetchAll(ds);
            ds.Tables[0].Columns.Add("JumpParam");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                item["JumpParam"] = "PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + item["PageMapping"]);
            }
            ds.Tables[0].DefaultView.Sort = PageCode + "XX";
            grdPage.DataSource = ds.Tables[0].DefaultView;
            grdPage.CurrentPageIndex = aPageNumber > grdPage.PageCount ? 0 : aPageNumber;
            grdPage.DataBind();
            SessionContext.GridPage = grdPage.CurrentPageIndex;
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdPage.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grdPage_PageIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion


        private void grdPage_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            FillGrid(e.NewPageIndex);
        }

        protected void lnkCreate_Click1(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=create"));
        }
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ControlPanel/ControlPanelHomeList.aspx");
        }
    }
}
