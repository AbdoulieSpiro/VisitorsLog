//===========================================================================
// This file was modified as part of an ASP.NET 2.0 Web project conversion.
// The class name was changed and the class modified to inherit from the abstract base class 
//// in file 'App_Code\Migrated\Login\Stub_Login_aspx_cs.cs'.
// During runtime, this allows other classes in your web application to bind and access 
// the code-behind page using the abstract base class.
// The associated content page 'Login\Login.aspx' was also modified to refer to the new class name.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================
//===========================================================================
// This file was modified as part of an ASP.NET 2.0 Web project conversion.
// The class name was changed and the class modified to inherit from the abstract base class 
//// in file 'App_Code\Migrated\Login\Stub_Login_aspx_cs.cs'.
// During runtime, this allows other classes in your web application to bind and access 
// the code-behind page using the abstract base class.
// The associated content page 'Login\Login.aspx' was also modified to refer to the new class name.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================
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
using System.Web.Security;
using HRSystemServer.BusinessLayer;

namespace HRSystemWeb
{
    /// <summary>
    /// Summary description for Login.
    /// </summary>
    public partial class Login_Login : PageBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Page_Load(object sender, System.EventArgs e)
        {
            //Set btnLogin as a default button to click when return key is pressed in txtPassword field
            //WebUtility.SetDefaultButtonForControl(this, WebUtility.ControlTypes.TextBox, txtPassword, btnLogin);
            this.RequireAuthentication = false;
            // base.Page_Load(sender, e);

            if (!Page.IsPostBack)
            {
                SessionContext.Logout();
                FormsAuthentication.SignOut();
                Session.Abandon();

                //panNewUser.Visible = false;
                this.Title = " Visitors LOG : Login";
                PrepPage();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        override public string SchoolX
        {
            get { return SessionContext.SiteX; }
        }
        /// <summary>
        /// 
        /// </summary>
        private void PrepPage()
        {

            HttpCookie c = Request.Cookies["LastLogin"];
            if (c == null)
            {
                txtLoginId.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                txtLoginId.Text = c.Values["UserId"];
                txtPassword.Text = c.Values["Password"];

            }

            //	lnkNewUser.Visible = SessionContext.IsOpenToPublic;
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
            //this.valDuplicateEmailAddress.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.valDuplicateEmailAddress_ServerValidate);
            //this.valMatchEmailAddress.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.valMatchEmailAddress_ServerValidate);

        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreate_Click(object sender, System.EventArgs e)
        {
            //if (this.IsValid)
            //{
            //    DataSet ds = new DataSet();
            //    SystemUserBL bl = new SystemUserBL(SessionContext.SystemUser);
            //    bl.FetchForLoginEmailAddress(ds, txtEmailAddress.Text);
            //    if (ds.Tables[0].Rows.Count == 0)
            //    {
            //        DataRow newRow = ds.Tables[0].NewRow();
            //        newRow["School"] = SessionContext.Site;
            //        newRow["FirstName"] = txtFirstName.Text;
            //        newRow["LastName"] = txtLastName.Text;
            //        newRow["EmailAddress"] = txtEmailAddress.Text;
            //        newRow["LoginEmailAddress"] = txtEmailAddress.Text;
            //        newRow["Password"] = txtPassword1.Text;
            //        newRow["IsActive"] = 1;
            //        newRow["SystemRoletype"] = WebUtility.Cast(BusinessLayerUtility.GetAppSetting("DefaultSystemRoleType"), -1);
            //        ds.Tables[0].Rows.Add(newRow);
            //        if (bl.Save(ds))
            //        {
            //            txtLoginId.Text = txtEmailAddress.Text;
            //            txtPassword.Text = txtPassword1.Text;
            //            lnkNewUser_Click(sender, e);
            //        }
            //        else
            //        {
            //            lblErrorMessage.Text = bl.LastException.Message;
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void valDuplicateEmailAddress_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            //DataSet ds = new DataSet();
            //SystemUserBL bl = new SystemUserBL(SessionContext.SystemUser);
            //bl.FetchForLoginEmailAddress(ds, txtEmailAddress.Text);
            //args.IsValid = ds.Tables[0].Rows.Count == 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void valMatchEmailAddress_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            //	args.IsValid = (txtPassword1.Text.Trim().Length>0 && txtPassword1.Text.Equals(txtPassword2.Text));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {

            try
            {

                //this.MasterPageFile = "~/MasterPageMain.master";
                //Page.Theme = SessionContext.SiteTheme;
            }

            catch
            {
                //((MasterPage)(Page.Master)).SchoolStyleSheet(SessionContext.SiteStyleSheet);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string sKey = txtLoginId.Text.Trim() + txtPassword.Text.Trim();
            string sUser = WebUtility.Cast(System.Web.HttpContext.Current.Cache[sKey], "");

            //Validate User and Password
            DataSet ds = new DataSet();
            SystemUserBL bl = new SystemUserBL(0);
            bl.FetchForLogin(ds, Security.GetBaseURL(), txtLoginId.Text, txtPassword.Text);
            //bl.FetchForLogin(ds, txtLoginId.Text, txtPassword.Text);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SessionContext.IsSiteUser = (bool)ds.Tables[0].Rows[0]["IsActive"];
                if (!SessionContext.IsSiteUser)
                {
                    valSignIn.IsValid = false;
                    FormsAuthentication.SignOut();
                    Issue.RaisePage.ConfirmationPage("Your account is not Active. You may not be able to access the system at this time.");
                }
                else if ((bool)ds.Tables[0].Rows[0]["IsLocked"])
                {
                    valSignIn.IsValid = false;
                    valSignIn.Visible = false;
                    valLockOut.IsValid = false;
                    valLockOut.Visible = true;

                }
                else
                {

                    if (WebUtility.Cast(ds.Tables[0].Rows[0]["IsTrial"], false) && WebUtility.Cast(ds.Tables[0].Rows[0]["TrialDays"], -1) < 0)
                    {
                        valTrialExpired.Visible = true;
                        valTrialExpired.IsValid = false;
                    }
                    else
                    {

                        TimeSpan SessTimeOut = new TimeSpan(0, 0, HttpContext.Current.Session.Timeout, 0, 0);
                        SessionContext.SystemUserUnique = sKey;
                        HttpContext.Current.Cache.Insert(sKey, sKey, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);

                        SessionContext.TrialDays = WebUtility.Cast(ds.Tables[0].Rows[0]["TrialDays"], -1);
                        SessionContext.IsTrial = WebUtility.Cast(ds.Tables[0].Rows[0]["IsTrial"], false);
                        SessionContext.SystemUser = WebUtility.Cast(ds.Tables[0].Rows[0]["SystemUser"], -1);
                        SessionContext.SystemUserX = ds.Tables[0].Rows[0]["FirstName"] + " " + ds.Tables[0].Rows[0]["LastName"];
                        SessionContext.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                        SessionContext.SiteRoleType = WebUtility.Cast(ds.Tables[0].Rows[0]["SystemRoleType"], -1);
                        SessionContext.SecurityProfile = (int)ds.Tables[0].Rows[0]["SecurityProfile"];
                 //       SessionContext.BranchID = (int)ds.Tables[0].Rows[0]["BranchID"];
                        SessionContext.Branch = ds.Tables[0].Rows[0]["BranchCode"].ToString();
                        SessionContext.UserOrderLevel = WebUtility.Cast(ds.Tables[0].Rows[0]["UserOrderLevel"],-1);
                        SessionContext.SuperAdministrator = false;
                        SessionContext.SiteAdministrator = false;
                        SessionContext.Site = WebUtility.Cast(ds.Tables[0].Rows[0]["site"], -1); ;
                        SessionContext.Theme = ds.Tables[0].Rows[0]["Theme"].ToString();
                        SessionContext.SiteX = ds.Tables[0].Rows[0]["SiteX"].ToString();
                        SessionContext.CurrentSchoolSession = WebUtility.Cast(ds.Tables[0].Rows[0]["CurrentSession"], -1);
                        SessionContext.BaseURL = Security.GetBaseURL();

                        FormsAuthentication fa = new FormsAuthentication();
                        FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, txtLoginId.Text, DateTime.Now, DateTime.Now.AddMinutes(30), false, "HRISGRA", FormsAuthentication.FormsCookiePath);
                        HttpCookie c = new HttpCookie("LastLogin");
                        c.Values.Add("UserId", txtLoginId.Text);
                        c.Values.Add("Password", txtPassword.Text);
                        c.Expires = DateTime.MaxValue;
                        Response.Cookies.Add(c);
                        // Encrypt the ticket.
                        string encTicket = FormsAuthentication.Encrypt(fat);


                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));



                        if ((bool)ds.Tables[0].Rows[0]["ChangePassword"])
                        {
                            Response.Redirect(@"../SystemUser/UpdatePasword.aspx?" + URLMessage.Encrypt("action=update&sendtohome=1"));
                        }
                        else
                        {
                            //string jumpto = @"../Default.aspx";
                            string jumpto = @"../ControlPanel/ControlPanelHomeList.aspx";
                            //jumpto = FormsAuthentication.GetRedirectUrl(txtLoginId.Text, false);
                            jumpto.Replace("!systemuser!", SessionContext.SystemUser.ToString());
                            Response.Redirect(jumpto);
                        }
                    }

                }
            }
            else
            {
                valSignIn.Visible = true;
                valSignIn.IsValid = false;
            }
        }
    }
}






