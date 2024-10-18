using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HRSystemServer.BusinessLayer;
using HRSystemWeb.Issue;

namespace HRSystemWeb
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ControlPanel_ControlPanelAdministratorList : PageBase
    {
        /// <summary>
        /// Local variable declarations..
        /// </summary>
        #region Variable Declaration
        protected DataSet ds = new DataSet();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Page_Load(object sender, System.EventArgs e)
        {
            PageName = "Administrator List";
            PageCode = "AdministratorList";
            base.Page_Load(sender, e);
        }

    }
}