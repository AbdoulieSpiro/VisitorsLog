using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HRSystemWeb;
/// <summary>
/// Summary description for License
/// </summary>
public class License
{
    public License()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public static void Validate()
    {
        if (SessionContext.IsLicensinsed)
        {
            return;
        }
        LicensingDLL.LicienceHandler handler = new LicensingDLL.LicienceHandler(System.Web.HttpContext.Current.Server.MapPath("~/bin") + "\\", "SMS");
        if (handler.ValidateLicience() == ValidationResult.Failed)
        {
            String ApplicationURL = ConfigurationSettings.AppSettings["ApplicationURL"].ToString();
            SessionContext.IsLicensinsed = false;
            System.Web.HttpContext.Current.Response.Redirect(ApplicationURL + "info.aspx?msg=" + handler.ResponseMessage + "&returl" + System.Web.HttpContext.Current.Request.Url.ToString());

        }
        else
        {
            SessionContext.IsLicensinsed = true;
        }
    }
}
