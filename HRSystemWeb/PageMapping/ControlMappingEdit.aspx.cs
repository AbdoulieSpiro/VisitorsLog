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
    public partial class ControlMappingEdit : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();


        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "ControlMapping";
            PageName = "Control Mapping";
            Confirm(lnkDelete, "Are you sure to delete selected mapping?");
            if (!Page.IsPostBack)
            {
                // ((MasterPage)(Page.Master)).PageTitle(SessionContext.SiteX + " - " + PageName);

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
            ParentId = URLMessage.GetParam("PageMapping", -1);
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            DataRow newRow = ds.Tables[0].NewRow();
            newRow["PageMapping"] = ParentId;
            ds.Tables[0].Rows.Add(newRow);
            this.DataBind();
        }

        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ParentId = (int)ds.Tables[0].Rows[0]["PageMapping"];
                this.DataBind();
            }
            //else
            // Error Handler	Issue.RaisePage.ItemNotFound(Request.RawUrl);
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
            aDataRow["ControlMappingX"] = txtControlMappingX.Text;
            aDataRow["ControlMappingCode"] = txtControlMappingCode.Text;
        }

        private void DoCreate(ControlMappingBL bl)
        {
            bl.Fetch(ds, int.MinValue);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            ScreenScrape(newRow);
            newRow["PageMapping"] = URLMessage.GetParam("PageMapping", 0);
        }
        private void DoUpdate(ControlMappingBL bl)
        {
            bl.Fetch(ds, RowId);
            ScreenScrape(ds.Tables[0].Rows[0]);
        }

        private void DoDelete(ControlMappingBL bl)
        {
            bl.Fetch(ds, RowId);
            ds.Tables[0].Rows[0].Delete();
        }

        protected void lnkUpdate_Click(object sender, System.EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
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
                    Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));
                //else
                // Error Handler	Issue.RaisePage.DataError(bl.LastException);
            }

        }

        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));
        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            DoDelete(bl);
            if (bl.Save(ds))
                Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));
            //else
            // Error Handler	Issue.RaisePage.DataError(bl.LastException);
        }



    }
}
