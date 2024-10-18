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
    public partial class PageMappingEdit : PageBase
    {
        protected DataSet ds = new DataSet();


        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "PageMapping";
            PageName = "Page Mapping";
            Confirm(lnkDelete, "Are you sure to delete the page mapping?");
            if (!Page.IsPostBack)
            {
                switch (URLMessage.URLAction)
                {
                    case URLAction.create:
                        PrepCreate();
                        break;
                    case URLAction.update:
                        PrepUpdate();
                        break;
                    case URLAction.delete:
                        break;
                }
            }
        }

        private void PrepCreate()
        {
            lnkDelete.Visible = false;
            RowId = int.MinValue;
            PageMappingBL bl = new PageMappingBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            this.DataBind();
        }

        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);
            PageMappingBL bl = new PageMappingBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            if (ds.Tables[0].Rows.Count > 0)
                this.DataBind();
            //else
            // Erro Handler	Issue.RaisePage.ItemNotFound(Request.RawUrl);
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

        private void ScreenScrape(DataRow aDataRow)
        {
            aDataRow["PageMappingX"] = txtPageMappingX.Text;
            aDataRow["PageMappingXX"] = txtPageMappingXX.Text;
        }

        private void DoCreate(PageMappingBL bl)
        {
            bl.Fetch(ds, int.MinValue);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            ScreenScrape(newRow);
        }
        private void DoUpdate(PageMappingBL bl)
        {
            bl.Fetch(ds, RowId);
            ScreenScrape(ds.Tables[0].Rows[0]);
        }

        private void DoDelete(PageMappingBL bl)
        {
            bl.Fetch(ds, RowId);
            ds.Tables[0].Rows[0].Delete();
        }

        protected void lnkUpdate_Click(object sender, System.EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                PageMappingBL bl = new PageMappingBL(SessionContext.SystemUser);
                switch (URLMessage.URLAction)
                {
                    case URLAction.create:
                        DoCreate(bl);
                        break;
                    case URLAction.update:
                        DoUpdate(bl);
                        break;
                    case URLAction.delete:
                        break;
                }
                if (bl.Save(ds))
                {
                    Response.Redirect(PageCode + "View.aspx?" + URLMessage.Encrypt(PageCode + "=" + ds.Tables[0].Rows[0][PageCode].ToString()));
                }
                //else
                // Erro Handler	Issue.RaisePage.DataError(bl.LastException);
            }
        }

        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(PageCode + "List.aspx");
        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            PageMappingBL bl = new PageMappingBL(SessionContext.SystemUser);
            DoDelete(bl);
            if (bl.Save(ds))
                Response.Redirect(PageCode + "List.aspx");
            //else
            // Erro Handler	Issue.RaisePage.DataError(bl.LastException);
        }
    }
}
