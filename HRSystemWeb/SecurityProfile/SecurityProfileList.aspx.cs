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

namespace HRSystemWeb.SecurityProfile
{
    public partial class SecurityProfileList : PageBase
    {

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "SecurityProfile";
            PageName = "Security Profile";
            if (!Page.IsPostBack)
            {
                //((MasterPage)(Page.Master)).PageTitle(SessionContext.SiteX + " - " + PageName);

                FillGrid(SessionContext.GridPage);
            }
        }

        private void FillGrid(int aPageNumber)
        {
            DataSet ds = new DataSet();
            SecurityProfileBL bl = new SecurityProfileBL(0);
            bl.FetchAll(ds);
            ds.Tables[0].Columns.Add("JumpParam");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                item["JumpParam"] = "../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("SecurityProfile=" + item["SecurityProfile"]);
            }
            ds.Tables[0].DefaultView.Sort = PageCode + "X";
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
            this.grdPage.PageIndexChanged += new DataGridPageChangedEventHandler(this.grdPage_PageIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion


        private void grdPage_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            FillGrid(e.NewPageIndex);
        }

        private void lnkReloadSecurity_Click(object sender, System.EventArgs e)
        {

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
