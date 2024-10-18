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
using HRSystemServer.BusinessLayer;
using HRSystemServer.DataLayer;

namespace HRSystemWeb
{
    public partial class SystemUserList : PageBase
    {
        //URLMessage URLMessage = new URLMessage();
        protected override void Page_Load(object sender, EventArgs e)
        {

            base.Page_Load(sender, e);
            PageCode = "SystemUser";
            PageName = "System User";
            lblConfirmation.Visible = false;

            if (!Page.IsPostBack)
            {
                //lblSearchHeaderText.Text = "System User Maintenance";
                //txtSearch.Text = WebUtility.GetCookie(Request, _SearchHintCookie, "");
                btnSearch_Click1(this, null);

                if (URLMessage.GetParam("SystemUser", 0) != 0)
                {
                    BindGrid(Convert.ToString(URLMessage.GetParam("SystemUser", 0)));
                }
            }
        }

        #region "CREATE LINK"
        protected void lnkCreate_Click1(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=create"));
        }
        #endregion

        #region "CANCEL LINK"
        protected void lnkCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect(@"../ControlPanel/ControlPanelhomeList.aspx?");
        }
        #endregion

        #region "BIND GRID"
        private void BindGrid(string Text)
        {
            DataSet dataset;
            dataset = new DataSet();
            new SystemUserBL(SessionContext.SystemUser).FetchForNameInitial(dataset, Text, SessionContext.Site, SessionContext.SiteRoleType);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                divEmpty.Visible = false;
                dataset.Tables[0].Columns.Add("JumpParam");
                foreach (DataRow item in dataset.Tables[0].Rows)
                {
                    item["JumpParam"] = "SystemUserEdit.aspx?" + URLMessage.Encrypt("action=update&SystemUser=" + item["SystemUser"] + "&Referrer=SystemUserList.aspx");
                }
                dataset.Tables[0].DefaultView.Sort = "LastName,FirstName,EmailAddress";
                grdPage.DataSource = dataset.Tables[0].DefaultView;
                grdPage.DataBind();
            }
            else
            {
                divEmpty.Visible = true;
                grdPage.DataSource = new DataTable();
                grdPage.DataBind();
            }
        }
        #endregion

        #region "SEARCH BY NAME INITIALS"
        protected void lnkAll_Command(object sender, EventArgs e)
        {
            try
            {
                if (((LinkButton)(sender)).CommandArgument.ToString() == "ALL")
                {
                    CargoBag.SetValue("SearchString", "");
                    BindGrid("");
                }
                else
                {
                    CargoBag.SetValue("SearchString", ((LinkButton)(sender)).CommandArgument.ToString());
                    BindGrid(((LinkButton)(sender)).CommandArgument.ToString());
                }
            }
            catch
            {
            }
        }
        #endregion

        #region "SEARCH USING TEXTBOX"
        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            BindGrid(txtSearch.Text);
        }
        #endregion

        #region "ITEM COMMAND"
        protected void grdPage_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "ActivateUser":
                    UpdateChanges("ActivateUser", Convert.ToInt32(e.CommandArgument));
                    break;
                case "DeactivateUser":
                    UpdateChanges("DeactivateUser", Convert.ToInt32(e.CommandArgument));
                    break;
                case "LockUser":
                    UpdateChanges("LockUser", Convert.ToInt32(e.CommandArgument));
                    break;
                case "UnlockUser":
                    UpdateChanges("UnlockUser", Convert.ToInt32(e.CommandArgument));
                    break;
                case "Delete":
                    UpdateChanges("DeleteUser", Convert.ToInt32(e.CommandArgument));
                    break;
                case "ResetPassword":
                    UpdatePassword(Convert.ToInt32(e.CommandArgument));
                    break;
            }

        }
        #endregion

        #region "DO UPDATES"
        private void UpdateChanges(string action, int SystemUser)
        {
            DataSet ds;
            SystemUserBL SystemUserBL;
            try
            {
                ds = new DataSet();
                SystemUserBL = new SystemUserBL(SessionContext.SystemUser);
                SystemUserBL.Fetch(ds, SystemUser);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    switch (action)
                    {
                        case "ActivateUser":
                            ScreenScrapeForActivate(ds.Tables[0].Rows[0], true);
                            break;
                        case "DeactivateUser":
                            ScreenScrapeForActivate(ds.Tables[0].Rows[0], false);
                            break;
                        case "LockUser":
                            ScreenScrapeForLock(ds.Tables[0].Rows[0], true);
                            break;
                        case "UnlockUser":
                            ScreenScrapeForLock(ds.Tables[0].Rows[0], false);
                            break;
                        case "DeleteUser":
                            ScreenScrapeForDelete(ds.Tables[0].Rows[0]);
                            break;
                    }
                }

                if (SystemUserBL.Save(ds))
                    BindGrid(CargoBag.GetValue("SearchString", ""));
                //else
                //RaisePage.DataError(SystemUserBL.LastException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds = null;
                SystemUserBL = null;
            }
        }
        #endregion

        #region "SCREEN SCRAPE FOR ACTIVATE/ DEACTIVATE"
        private void ScreenScrapeForActivate(DataRow aDataRow, bool value)
        {
            aDataRow["IsActive"] = value;
            aDataRow["UpdatedBySystemUser"] = SessionContext.SystemUser;
        }
        #endregion

        #region "SCREEN SCRAPE FOR LOCK/ ULOCK"
        private void ScreenScrapeForLock(DataRow aDataRow, bool value)
        {
            aDataRow["IsLocked"] = value;
            aDataRow["UpdatedBySystemUser"] = SessionContext.SystemUser;
        }
        #endregion

        #region "SCREEN SCRAPE FOR DELETE USER"
        private void ScreenScrapeForDelete(DataRow aDataRow)
        {
            aDataRow["IsDeleted"] = 1;
            aDataRow["DeletedBySystemUser"] = SessionContext.SystemUser;
        }
        #endregion

        protected void grdPage_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Pager && e.Item.ItemType != ListItemType.Footer)
            {
                ImageButton imgUserActivate = (ImageButton)e.Item.FindControl("imgUserActivate");
                ImageButton imgUserDeactivate = (ImageButton)e.Item.FindControl("imgUserDeactivate");
                ImageButton imgUserLock = (ImageButton)e.Item.FindControl("imgUserLock");
                ImageButton imgUserUnlock = (ImageButton)e.Item.FindControl("imgUserUnlock");
                ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
                ImageButton imgResetPassword = (ImageButton)e.Item.FindControl("imgResetPassword");
                if (e.Item.Cells[11].Text == "1")
                {
                    e.Item.Cells[7].Style["text-align"] = "center !important;";
                    e.Item.Cells[8].Style["text-align"] = "center !important;";
                    e.Item.Cells[9].Style["text-align"] = "center !important;";
                    e.Item.Cells[10].Style["text-align"] = "center !important;";
                }
                else
                {
                    imgUserActivate.Visible = false;
                    imgUserDeactivate.Visible = false;
                    imgUserLock.Visible = false;
                    imgUserUnlock.Visible = false;
                    imgDelete.Visible = false;
                    imgResetPassword.Visible = false;
                }
            }

        }

        #region "VIEW ALL FILES"
        protected void imgAllFiles_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Document/DocumentList.aspx");
        }
        #endregion


        #region "RESET PASSWORD"
        protected void UpdatePassword(int SystemUser)
        {
            DataSet ds;
            SystemUserBL SystemUserBL;
            try
            {
                ds = new DataSet();
                SystemUserBL = new SystemUserBL(SessionContext.SystemUser);
                SystemUserBL.Fetch(ds, SystemUser);
                string Password = Guid.NewGuid().ToString().Substring(0, 8);
                ScreenScrapeResetPassword(ds.Tables[0].Rows[0], Password);
                if (SystemUserBL.Save(ds))
                {
                    if (BusinessLayerUtility.GetAppSetting("MailServer") != null && BusinessLayerUtility.GetAppSetting("Port") != null && BusinessLayerUtility.GetAppSetting("UserName") != null && BusinessLayerUtility.GetAppSetting("Password") != null && BusinessLayerUtility.GetAppSetting("MailFrom") != null)
                    {
                        SMTP SMTP = new SMTP(BusinessLayerUtility.GetAppSetting("MailServer"), Int32.Parse(BusinessLayerUtility.GetAppSetting("Port")), BusinessLayerUtility.GetAppSetting("UserName"), BusinessLayerUtility.GetAppSetting("Password"), false, true);
                        SMTP.IsHTML = true;
                        if (SMTP.SendEmail(BusinessLayerUtility.GetAppSetting("UserName"), BusinessLayerUtility.GetAppSetting("MailFrom"), ds.Tables[0].Rows[0]["EmailAddress"].ToString(), "", "", SessionContext.SiteX + " - Password Changed", BuildPasswordChangedMail(ds.Tables[0].Rows[0], Password), false))
                        {
                            BindGrid(CargoBag.GetValue("SearchString", ""));
                        }
                        else
                        {
                            lblConfirmation.Visible = true;
                            lblConfirmation.Text = "Password has been successfully changed." + "<br>New Password: " + "<b>" + Password + "</b>";
                        }
                    }
                    else
                    {
                        lblConfirmation.Visible = true;
                        lblConfirmation.Text = "Password has been successfully changed." + "<br>New Password: " + "<b>" + Password + "</b>";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds = null;
                SystemUserBL = null;
            }
        }

        private void ScreenScrapeResetPassword(DataRow aDataRow, string Password)
        {
            aDataRow["Password"] = Password;// WebUtility.EncryptPassword(Password);
        }

        private string BuildPasswordChangedMail(DataRow aDataRow, string Password)
        {
            string XMLFormat = WebUtility.GetXmlValue(SessionContext.SiteX, "PasswordChanged");
            string FullName = aDataRow["FullName"].ToString();
            string BuildMailFinal = string.Format(XMLFormat, FullName, Password);
            return BuildMailFinal;
        }
        #endregion

        protected void grdPage_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            //if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Pager)
            //{
            //    e.Item.Attributes.Add("onmouseover", "className='highlightrow'");
            //    e.Item.Attributes.Add("onmouseout", "className='aspDataGrid_ItemStyle'");
            //}
        }
        protected void grdPage_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdPage.CurrentPageIndex = e.NewPageIndex;
            BindGrid(txtSearch.Text);
        }
    }
}