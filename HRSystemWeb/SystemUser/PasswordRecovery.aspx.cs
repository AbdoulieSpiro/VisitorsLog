using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using HRSystemWeb.Issue;
using HRSystemServer.BusinessLayer;
using HRSystemWeb;
public partial class SystemUser_PasswordRecovery : Page
{
    protected DataSet ds = new DataSet();
    string PageCode;
    string PageName;
    protected void Page_Load(object sender, EventArgs e)
    {
        // this.RequireAuthentication = false;
        PageCode = "SystemUser";
        PageName = "System User";
        // base.Page_Load(sender, e);

        if (!Page.IsPostBack)
        {
            lblPageName.Text = "Password Assistance";
            //CargoBag.SetValue("Referrer", Request.UrlReferrer.AbsoluteUri);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Message = "";
        SystemUserBL bl = new SystemUserBL(SessionContext.SystemUser);
        lblMessage.Visible = false;
        try
        {
            bl.FetchForLoginEmailAddress(ds, SessionContext.Site, txtUserId.Text);
            if (ds.Tables[0].Rows.Count == 0)
            {
                valUserIdChack.IsValid = false;
            }
            else
            {
                Message = "Welcome to SMS <br> Dear <b>" + ds.Tables[0].Rows[0]["FullName"].ToString() + "</b>" + "<br><br>Please find your User Name and Password below. Please note that the passwords are case sensitive.<br>UID:<b> " + ds.Tables[0].Rows[0]["LoginEmailAddress"].ToString() + "</b><br>Password : " + GetNewPassword((int)ds.Tables[0].Rows[0]["SystemUser"]);
                SMTP smtp = WebUtility.GetSMTPObject();
                smtp.IsHTML = true;
                smtp.SendEmail(WebUtility.GetAppSetting("From"), ds.Tables[0].Rows[0]["EmailAddress"].ToString(), "Password Assistance", Message);
                txtUserId.Text = "";
                lblMessage.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = Ex.Message;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string GetNewPassword(int SystemUser)
    {
        PasswordChangeLogBL bl = new PasswordChangeLogBL(0);
        string Password = Guid.NewGuid().ToString().Substring(0, 6);
        bl.Upsert(-1, SystemUser, Password);
        return Password;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("..//login//login.aspx");
    }
}
