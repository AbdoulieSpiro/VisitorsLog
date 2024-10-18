using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using HRSystemServer.BusinessLayer;

namespace HRSystemWeb
{
    public partial class MasterPageLogin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();


        }
        protected void lnkhome_Click(object sender, EventArgs e)
        {
            //Response.Redirect(@"~/ControlPanel/ControlPanelhomeList.aspx?");
            Response.Redirect(@"~/Default.aspx");
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Login/Login.aspx?");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

     
        protected void lnkThemeChange_Click(object sender, EventArgs e)
        {

            //SessionContext.Theme = "HRGray";
            Response.Redirect(Request.RawUrl);
        }
        protected void lnkThemeChange_Click1(object sender, EventArgs e)
        {

        }

    }

}