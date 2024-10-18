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
using HRSystemWeb;
using HRSystemWeb.Issue;
using HRSystemServer.BusinessLayer;
public partial class SystemUser_UpdatePasword : PageBase
{
    protected DataSet ds = new DataSet();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected override void Page_Load(object sender, EventArgs e)
    {

        PageCode = "SystemUser";
        PageName = "System User";
        base.Page_Load(sender, e);
        string s = txtOldPassword.Text;
        if (!Page.IsPostBack)
        {
            CargoBag.SetValue("Referrer", Request.UrlReferrer.AbsoluteUri);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private bool SaveNewPassword(SystemUserBL SystemUserBL)
    {
        ds = new DataSet();
        SystemUserBL.Fetch(ds, SessionContext.SystemUser);

        if ((ds.Tables[0].Rows[0]["Password"].ToString().Trim() == txtOldPassword.Text.Trim() || ds.Tables[0].Rows[0]["NewPassword"].ToString().Trim() == txtOldPassword.Text.Trim()) && (txtPassword1.Text == txtPassword2.Text))
        {
            lblError.Visible = false;
            ScreenScrapeSavePassword(ds.Tables[0].Rows[0]);
            return true;
        }
        else
        {
            if (ds.Tables[0].Rows[0]["Password"].ToString().Trim() != txtOldPassword.Text.Trim())
            {
                lblError.Visible = true;
            }
            return false;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrInput"></param>
    /// <returns></returns>
    private string ByteArrayToString(byte[] arrInput)
    {
        int i = 0;
        System.Text.StringBuilder sOutput = new System.Text.StringBuilder(arrInput.Length);
        for (i = 0; i <= 15; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString().Trim();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="aDataRow"></param>
    private void ScreenScrapeSavePassword(DataRow aDataRow)
    {
        aDataRow["Password"] = txtPassword1.Text.Trim().ToString();
        aDataRow["UpdatedBySystemUser"] = SessionContext.SystemUser;
        aDataRow["ChangePassword"] =0;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        args.IsValid = txtPassword1.Text.Equals(txtPassword2.Text);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            SystemUserBL bl = new SystemUserBL(SessionContext.SystemUser);
            switch (URLMessage.URLAction)
            {
                case URLAction.update:
                    if (!SaveNewPassword(bl))
                    {
                        return;
                    }
                    break;
            }
            if (bl.Save(ds))
            {

                Response.Redirect(@"~/ControlPanel/ControlPanelHomeList.aspx?");
            }
            else
            {
                RaisePage.DataError(bl.LastException);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect(CargoBag.GetValue("Referrer", "SystemUserList.aspx"));
    }
}
