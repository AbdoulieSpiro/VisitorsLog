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

namespace HRSystemWeb
{
    public partial class SystemRoleTypeEdit : PageBase
    {
        protected DataSet ds = new DataSet();


        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "SystemRoleType";
            PageName = "System Roletype";
            Confirm(lnkDelete, "Are you sure to delete selected System Role Type?");
            if (!Page.IsPostBack)
            {
                //  ((MasterPage)(Page.Master)).PageTitle(SessionContext.SiteX + " - " + PageName);

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
            EnableControls();
        }

        private void EnableControls()
        {
            if (URLMessage.GetParam(PageCode, 0) == Convert.ToInt32(WebUtility.SystemRoleType.Administrator) || URLMessage.GetParam(PageCode, 0) == Convert.ToInt32(WebUtility.SystemRoleType.SuperAdministrator))
            {
                pnlInput.Enabled = false;
                lnkDelete.Visible = false;
            }
            else
            {
                pnlInput.Enabled = true;
                lnkDelete.Visible = true;

            }

        }
        private void PrepCreate()
        {
            lnkDelete.Visible = false;
            RowId = int.MinValue;
            SystemRoleTypeBL bl = new SystemRoleTypeBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            DataRow newRow = ds.Tables[0].NewRow();
            newRow["AllowAllSiteAccess"] = false;
            newRow["AllowAllCompanyAccess"] = false;
            ds.Tables[0].Rows.Add(newRow);
            WebUtility.FillDropDownList(lstSecurityProfile, new SecurityProfileBL(SessionContext.SystemUser));
            this.DataBind();
        }

        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);
            SystemRoleTypeBL bl = new SystemRoleTypeBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.DataBind();
                WebUtility.FillDropDownList(lstSecurityProfile, new SecurityProfileBL(SessionContext.SystemUser), (int)ds.Tables[0].Rows[0]["SecurityProfile"]);
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
            aDataRow["SystemRoleTypeX"] = txtSystemRoleTypeX.Text;
            aDataRow["SecurityProfile"] = lstSecurityProfile.SelectedValue;
            aDataRow["AllowAllCompanyAccess"] = chkAllowAllCompanyAccess.Checked;
            aDataRow["AllowAllSiteAccess"] = chkAllowAllSchoolAccess.Checked;

        }

        private void DoCreate(SystemRoleTypeBL bl)
        {
            bl.Fetch(ds, int.MinValue);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            ScreenScrape(newRow);
        }
        private void DoUpdate(SystemRoleTypeBL bl)
        {
            bl.Fetch(ds, RowId);
            ScreenScrape(ds.Tables[0].Rows[0]);
        }

        private void DoDelete(SystemRoleTypeBL bl)
        {
            bl.Fetch(ds, RowId);
            ds.Tables[0].Rows[0].Delete();
        }

        protected void lnkUpdate_Click(object sender, System.EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                SystemRoleTypeBL bl = new SystemRoleTypeBL(SessionContext.SystemUser);
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
                    Response.Redirect(PageCode + "List.aspx");
                //else
                // Error Handler	Issue.RaisePage.DataError(bl.LastException);
            }

        }

        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(PageCode + "List.aspx");
        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            SystemRoleTypeBL bl = new SystemRoleTypeBL(SessionContext.SystemUser);
            try
            {
                DoDelete(bl);
                lblMsg.Visible = false;
                if (bl.Save(ds))
                    Response.Redirect(PageCode + "List.aspx");

            }
            catch (System.Data.SqlClient.SqlException ex1)
            {
                if (ex1.Number == 547)
                {
                    lblMsg.Visible = true;
                }

            }
            //catch (Exception ex)
            //{

            //}

        }



    }
}
