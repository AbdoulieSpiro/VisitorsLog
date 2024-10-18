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
    public partial class SecurityProfileEdit : PageBase
    {
        protected DataSet ds = new DataSet();


        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "SecurityProfile";
            PageName = "Security Profile";
            Confirm(lnkDelete, "Are you sure to delete selected Security Profile?");
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
            SecurityProfileBL bl = new SecurityProfileBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            this.DataBind();
        }

        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);
            SecurityProfileBL bl = new SecurityProfileBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            if (ds.Tables[0].Rows.Count > 0)
                this.DataBind();
            //else
            // Error Handling	Issue.RaisePage.ItemNotFound(Request.RawUrl);
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
            aDataRow["SecurityProfileX"] = txtSecurityProfileX.Text;
        }

        private void DoCreate(SecurityProfileBL bl)
        {
            bl.Fetch(ds, int.MinValue);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            ScreenScrape(newRow);
        }
        private void DoUpdate(SecurityProfileBL bl)
        {
            bl.Fetch(ds, RowId);
            ScreenScrape(ds.Tables[0].Rows[0]);
        }

        private void DoDelete(SecurityProfileBL bl)
        {
            bl.Fetch(ds, RowId);
            ds.Tables[0].Rows[0].Delete();
        }

        protected void lnkUpdate_Click(object sender, System.EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                SecurityProfileBL bl = new SecurityProfileBL(SessionContext.SystemUser);
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
                    Response.Redirect("../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("action=view&SecurityProfile=" + ds.Tables[0].Rows[0]["SecurityProfile"].ToString()));

                //else
                // Error Handler	Issue.RaisePage.DataError(bl.LastException);
            }

        }

        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("action=view&SecurityProfile=" + RowId));
        
        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            SecurityProfileBL bl = new SecurityProfileBL(SessionContext.SystemUser);
            DoDelete(bl);
            if (bl.Save(ds))
                Response.Redirect(PageCode + "List.aspx");
            //else
            // Error Page	Issue.RaisePage.DataError(bl.LastException);
        }



    }
}
