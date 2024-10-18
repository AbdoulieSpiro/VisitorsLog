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
using HRSystemWeb;


public partial class Custom_Controls_LoginControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie c = Request.Cookies["LastLogin"];
        if (!Page.IsPostBack)
        {
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
        }


    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Validate User and Password
        DataSet ds = new DataSet();
        SystemUserBL bl = new SystemUserBL(0);
        //bl.FetchForLogin(ds,txtLoginId.Text, txtPassword.Text);
        bl.FetchForLogin(ds, Security.GetBaseURL(), txtLoginId.Text, txtPassword.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            SessionContext.SystemUser = (int)ds.Tables[0].Rows[0]["SystemUser"];
            SessionContext.SystemUserX = ds.Tables[0].Rows[0]["FirstName"] + " " + ds.Tables[0].Rows[0]["LastName"];
            SessionContext.SystemRoleType = (int)ds.Tables[0].Rows[0]["SystemRoleType"];
            //Initialize FormsAuthentications
            FormsAuthentication fa = new FormsAuthentication();
            FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, txtLoginId.Text, DateTime.Now, DateTime.Now.AddMinutes(30), false, "Association", FormsAuthentication.FormsCookiePath);

            HttpCookie c = new HttpCookie("LastLogin");
            c.Values.Add("UserId", txtLoginId.Text);
            c.Values.Add("Password", txtPassword.Text);
            c.Expires = DateTime.MaxValue;
            Response.Cookies.Add(c);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(fat);

            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            //// Redirect back to original URL.
            string jumpto = "";
            jumpto = FormsAuthentication.GetRedirectUrl(txtLoginId.Text, false);
            ApplicationContext.ReloadControlSecurity();
            if (ds.Tables[0].Rows[0]["ChangePassword"].ToString() == "1")
            {
                Response.Redirect(@"../SystemUser/UpdatePasword.aspx?action=update&sendtohome=1");
            }
            else
            {
                Response.Redirect(jumpto);
            }
        }
        else
        {
            valSignIn.Visible = true;
            valSignIn.IsValid = false;
        }

    }
    public void HideLogin()
    {
        btnLogin.Visible = false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkForgetPsw_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"../SystemUser/PasswordRecovery.aspx?");
    }
}
