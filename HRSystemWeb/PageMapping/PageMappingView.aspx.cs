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
    public partial class PageMappingView : PageBase
    {
        protected DataSet ds = new DataSet();


        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "PageMapping";
            PageName = "Page Mapping";
            if (!Page.IsPostBack)
            {
                //  ((MasterPage)(Page.Master)).PageTitle(SessionContext.SiteX + " - " + PageName + " View");
                PrepView();
            }
        }


        private void PrepView()
        {
            RowId = URLMessage.GetParam(PageCode, 0);
            PageMappingBL bl = new PageMappingBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ControlMappingBL bl2 = new ControlMappingBL(SessionContext.SystemUser);
                bl2.FetchForPageMapping(ds, RowId);
                ds.Tables[1].Columns.Add("JumpParam");
                foreach (DataRow item in ds.Tables[1].Rows)
                {
                    item["JumpParam"] = "ControlMappingEdit.aspx?" + URLMessage.Encrypt("action=update&ControlMapping=" + item["ControlMapping"]);
                }
                grdControlMapping.DataSource = ds.Tables[1].DefaultView;
                grdControlMapping.DataBind();
                this.DataBind();
            }
            //else
            //	Error Handler Issue.RaisePage.ItemNotFound(Request.RawUrl);
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
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        protected void lnkCreate_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("ControlMappingEdit.aspx?" + URLMessage.Encrypt("action=create&PageMapping=" + RowId));
        }

        protected void lnkEdit_Click1(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=" + URLAction.update.ToString() + "&" + PageCode + "=" + RowId));
        }
        protected void lnkCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "List.aspx");
        }
    }
}
