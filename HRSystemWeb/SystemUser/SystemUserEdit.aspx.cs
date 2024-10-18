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
using System.Net.NetworkInformation;


namespace HRSystemWeb
{
    public partial class SystemUserEdit : PageBase
    {
        protected DataSet ds = new DataSet();
        string Password = "";
       
        #region "PAGE LOAD EVENT"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            PageCode = "SystemUser";
            PageName = "System User";
            lblConfirmation.Visible = false;
            valDuplicatePassword.Visible = false;
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
                    default:
                        PrepCreate();
                        break;
                }

            }
        }
        #endregion

        #region "PREP CREATE"
        /// <summary>
        /// 
        /// </summary>
        private void PrepCreate()
        {
            txtPassword.Visible = true;
            lblPassword.Visible = true;
            lblLastLogin.Visible = false;
            lblLastLoginResult.Visible = false;
            new SystemUserBL(SessionContext.SystemUser).Fetch(ds, int.MinValue);
            DataRow newRow = ds.Tables[0].NewRow();
            newRow["IsActive"] = true;
            ds.Tables[0].Rows.Add(newRow);
            this.DataBind();
            txtFailedLoginCount.Text = "0";
            DataSet ds1 = new DataSet();
            new SystemRoleTypeBL(SessionContext.SystemUser).FetchForSystemRoleType(ds1, SessionContext.SiteRoleType);
            WebUtility.FillDropDownList(drpSystemRoleType, ds1.Tables[0], "SystemRoleTypeX", "SystemRoleType", -1);
            drpSystemRoleType.Items.Insert(0, new ListItem("Select", "-1"));

            DataSet ds2 = new DataSet();
            new BranchBL(SessionContext.SystemUser).FetchForBranch(ds2, SessionContext.SiteRoleType);
            WebUtility.FillDropDownList(drpBranch, ds2.Tables[0], "BranchXX", "Branch", -1);
            drpBranch.Items.Insert(0, new ListItem("Select", "-1"));


            //BindDropDowns();


        }
        #endregion



        #region "PREP UPDATE"
        /// <summary>
        /// 
        /// </summary>
        private void PrepUpdate()
        {
            SystemUserBL SystemUserBL = new SystemUserBL(SessionContext.SystemUser);
            SystemUserBL.Fetch(ds, URLMessage.GetParam("SystemUser", 0));
            txtPassword.Visible = false;
            lblPassword.Visible = false;
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.DataBind();
                txtFailedLoginCount.Enabled = true;

                DataSet ds1 = new DataSet();
                new SystemRoleTypeBL(SessionContext.SystemUser).FetchForSystemRoleType(ds1, SessionContext.SiteRoleType);
                WebUtility.FillDropDownList(drpSystemRoleType, ds1.Tables[0], "SystemRoleTypeX", "SystemRoleType", -1);
                drpSystemRoleType.Items.Insert(0, new ListItem("Select", "-1"));
                WebUtility.SetDropDownListValue(drpSystemRoleType, (int)ds.Tables[0].Rows[0]["SystemRoleType"]);

                DataSet ds2 = new DataSet();
                new BranchBL(SessionContext.SystemUser).FetchForBranch(ds2, SessionContext.SiteRoleType);
                WebUtility.FillDropDownList(drpBranch, ds2.Tables[0], "BranchXX", "Branch", -1);
                drpBranch.Items.Insert(0, new ListItem("Select", "-1"));
                WebUtility.SetDropDownListValue(drpBranch, ds.Tables[0].Rows[0]["BranchID"]);
                //WebUtility.SetDropDownListValue(drpBranch, ds.Tables[0].Rows[0]["BranchCode"].ToString());

            }
            //else
            //    RaisePage.ItemNotFound(Request.RawUrl);
        }
        #endregion

        #region "SCREEN SCRAPE"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDataRow"></param>
        private void ScreenScrape(DataRow aDataRow)
        {
            aDataRow["Site"] = SessionContext.Site;
            aDataRow["IsActive"] = chkIsActive.Checked;
            aDataRow["FailedLoginCount"] = WebUtility.Cast(txtFailedLoginCount.Text, 0);
            aDataRow["SystemRoleType"] = WebUtility.ValueToSQLInteger(drpSystemRoleType.SelectedValue);
            aDataRow["LoginName"] = txtLoginEmailAddress.Text.Trim();
            aDataRow["EmailAddress"] = txtEmailAddress.Text.Trim();
            if (URLMessage.URLAction == URLAction.create)
             aDataRow["Password"] = txtPassword.Text;
            aDataRow["FirstName"] = txtFirstName.Text.Trim();
            aDataRow["LastName"] = txtLastName.Text.Trim();
            aDataRow["BranchCode"] = drpBranch.SelectedValue.ToString().Trim();
            //aDataRow["BranchCode"] = drpBranch.SelectedItem.Text;
            aDataRow["SystemUserX"] = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            //aDataRow["DateOfBirth"] = txtDateOfBirth.Text.Trim();
            //aDataRow["PermanentAddress"] = txtPermanentAddress.Text.Trim();
            //aDataRow["CorrespondanceAddress"] = txtCoAddress.Text.Trim();
            //aDataRow["EducationQaulification"] = txtEduQualification.Text.Trim();
            //aDataRow["CreatedBySystemUser"] = SessionContext.SystemUser;
        }
        #endregion

        #region "UPDATE EVENT"
        protected void lnkUpdate_Click1(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                SystemUserBL SystemUserBL = new SystemUserBL(SessionContext.SystemUser);
                string Action = "";
                switch (URLMessage.URLAction)
                {
                    case URLAction.create:
                        DoCreate(SystemUserBL);
                        Action = "Create";
                        break;
                    case URLAction.update:
                        DoUpdate(SystemUserBL);
                        Action = "Update";
                        break;
                    case URLAction.delete:
                        break;
                    default:
                        DoCreate(SystemUserBL);
                        Action = "Create";
                        break;
                }
                if (SystemUserBL.Save(ds))
                {
                    if (Action == "Create")
                    {
                        if (BusinessLayerUtility.GetAppSetting("MailServer") != null && BusinessLayerUtility.GetAppSetting("Port") != null && BusinessLayerUtility.GetAppSetting("UserName") != null && BusinessLayerUtility.GetAppSetting("Password") != null && BusinessLayerUtility.GetAppSetting("MailFrom") != null)
                        {
                            SMTP SMTP = new SMTP(BusinessLayerUtility.GetAppSetting("MailServer"), Int32.Parse(BusinessLayerUtility.GetAppSetting("Port")), BusinessLayerUtility.GetAppSetting("UserName"), BusinessLayerUtility.GetAppSetting("Password"), false, true);
                            SMTP.IsHTML = true;
                            if (SMTP.SendEmail(BusinessLayerUtility.GetAppSetting("UserName"), BusinessLayerUtility.GetAppSetting("MailFrom"), txtEmailAddress.Text.Trim().ToString(), "", "", SessionContext.SiteX + " - Your Login Details", BuildMail(), false))
                            {
                                Response.Redirect("SystemUserList.aspx");
                            }
                            else
                            {
                                lblConfirmation.Visible = true;
                                lblConfirmation.Text = "User has been successfully created." + "<br>Username: " + "<b>" + txtLoginEmailAddress.Text.ToString().Trim() + "</b>" + "<br>Password: " + "<b>" + txtPassword.Text + "</b>";
                                lnkUpdate.Enabled = false;
                            }
                        }
                        else
                        {
                            lblConfirmation.Visible = true;
                            lblConfirmation.Text = "User has been successfully created." + "<br>Username: " + "<b>" + txtLoginEmailAddress.Text.ToString().Trim() + "</b>" + "<br>Password: " + "<b>" + txtPassword.Text + "</b>";
                            lnkUpdate.Enabled = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("SystemUserList.aspx");
                    }

                }
                else
                {
                    if (SystemUserBL.LastException.Message.IndexOf("UNIQUE KEY") == 0)
                    {
                        // RaisePage.DataError(SystemUserBL.LastException);
                    }
                    else
                    {
                        valDuplicatePassword.Visible = true;
                        PrepUpdate();
                    }
                }
            }
        }
        #endregion

        #region "DO CREATE"
        private void DoCreate(SystemUserBL SystemUserBL)
        {
            SystemUserBL.Fetch(ds, int.MinValue);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            //Password = Guid.NewGuid().ToString().Substring(0, 8);
            ScreenScrape(newRow);
        }
        #endregion

        #region "DO UPDATE"
        private void DoUpdate(SystemUserBL SystemUserBL)
        {
            SystemUserBL.Fetch(ds, URLMessage.GetParam("SystemUser", -1));
            ScreenScrape(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region "TEXT CHANGED EVENT ON txtLoginEmailAddress"
        protected void txtEmailAddress_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLoginEmailAddress.Text.Equals(""))
            {
                txtLoginEmailAddress.Text = txtEmailAddress.Text.Trim();
            }
        }
        #endregion

        #region "CANCEL LINK"
        protected void LinkCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SystemUserList.aspx");
        }
        #endregion

        #region "BUILD MAIL"
        private string BuildMail()
        {
            string XMLFormat = WebUtility.GetXmlValue(SessionContext.SiteX, "PasswordMessage");
            string FullName = txtLastName.Text + " " + txtFirstName.Text;
            string BuildMailFinal = string.Format(XMLFormat, FullName, txtLoginEmailAddress.Text.ToString().Trim(), Password);
            return BuildMailFinal;
        }
        #endregion

        #region "CANCEL LINK"
        protected void LinkCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"../SystemUser/SystemUserList.aspx");
        }
        #endregion

    }
}