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
using System.Web.SessionState;
using System.IO;
using HRSystemServer.BusinessLayer;

namespace HRSystemWeb
{
    public partial class MasterPageGray : System.Web.UI.MasterPage
    {
        URLMessage URLMessage = new URLMessage();
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            lblWelCome.Text = "Welcome :  <b>" + SessionContext.SystemUserX + "</b>";
            //lbltrilaDays.Text = "You are using trail version. you have<b> " + SessionContext.TrialDays.ToString() + "</b> days left";
           // lbltrilaDays.Visible = SessionContext.IsTrial;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void lnkLogin_Click(object sender, EventArgs e)
        {

        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            //SessionContext.Logout();
            //Response.Redirect("~/Home/Home.aspx");
        }
        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
        //}

        //protected void btDonate_Click(object sender, ImageClickEventArgs e)
        //{
        //    //Response.Redirect("~/Donation/DonorDetails.aspx?" + URLMessage.Encrypt("action=Create&DonationDrive=13&DonationCause=19"));
        //}
    }
}