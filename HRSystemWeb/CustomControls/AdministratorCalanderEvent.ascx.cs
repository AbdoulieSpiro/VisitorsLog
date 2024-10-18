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


namespace HRSystemWeb
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AdministratorCalanderEvent : ControlBase
    {
        URLMessage URLMessage;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            URLMessage = new URLMessage();
            if (!IsPostBack)
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgMngUser_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/SystemUser/SystemUserList.aspx?" + URLMessage.Encrypt("action=create&School=" + SessionContext.Site));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgMngProject_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/Project/ProjectList.aspx?" + URLMessage.Encrypt("action=view"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgAssignUser_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/Project/ProjectAssignUsers.aspx?" + URLMessage.Encrypt("action=view"));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgLogOut_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();

            Response.Redirect("~/Login/Login.aspx?");
        }
    }
}