namespace HRSystemWeb
{
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
    using HRSystemServer.BusinessLayer;
    using OboutInc.Flyout2;
    using OboutInc.EasyMenu_Pro;
    using System.Security.Policy;
    using HRSystemServer.DataLayer;

    /// <summary>
    ///		Summary description for menucontrol.
    /// </summary>
    public partial class MenuControl_Horizontal : System.Web.UI.UserControl
    {
        URLMessage URLMessage = new URLMessage();
        protected EasyMenu mainEM;
        protected EasyMenu em_1;
        protected EasyMenu em_2;
        protected EasyMenu em_4;
        protected EasyMenu em_5;
        protected EasyMenu em_6;
        public String User;
        private HRSystemServer.UPSLayer.Secure secure = new HRSystemServer.UPSLayer.Secure("^%&*()JUHtg43@!~$9lLKo)(", "(*&^y54$#EWEd3@!0(8Mk)(*");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            UpdatePassword.NavigateUrl = ResolveUrl("~/UpdatePasword.aspx?" + URLMessage.Encrypt("action=update"));
            Logins.NavigateUrl = ResolveUrl("~/Login/Login.aspx");
            Home.NavigateUrl = ResolveUrl("~/ControlPanel/ControlPanelHomeList.aspx");
        

          



            //if (SessionContext.LoginName != "System")
            //{
            //    SystemUserList.Visible = false;
            //    PageMapping.Visible = false;
            //    SecurityProfile.Visible = false;
            //    SystemRoletype.Visible = false;
            //}


            //if (SessionContext.UserOrderLevel <= 1)
            //{
            //    ApproveSale.Visible = false;
            //}


            //if (SessionContext.UserOrderLevel < 3)
            //{
            //    ApproveRequest.Visible = false;
            //    AdminRequest.Visible = false;
            //}

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="aMenu"></param>
        public void SecureMenuControl(EasyMenu aMenu)
        {
            int mnuIndex = -1;
            string PageSecurityName = "MenuSMSGray.aspx";
            DataTable dtPageSecurity = ApplicationContext.GetApplicationControlSecurity();
            dtPageSecurity.DefaultView.RowFilter = "SecurityProfile=" + SessionContext.SecurityProfile.ToString() + " and (PageMappingX='" + PageSecurityName + "')";
            dtPageSecurity = dtPageSecurity.DefaultView.ToTable();
            if (dtPageSecurity.Rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < dtPageSecurity.Rows.Count; i++)
            {
                string[] MenuItem = new string[2];

                if (dtPageSecurity.Rows[i]["ControlMappingCode"].ToString().IndexOf("_") > 0)
                {
                    MenuItem = dtPageSecurity.Rows[i]["ControlMappingCode"].ToString().Split('_');
                    EasyMenu emnu = (EasyMenu)this.FindControl(MenuItem[0].ToString());
                    if (emnu != null)
                    {
                        if (dtPageSecurity.Rows[i]["ControlState"].ToString() == "H")
                        {
                            mnuIndex = GetIndex(emnu, MenuItem[1].ToString());
                            if (mnuIndex > -1)
                            {
                                emnu.Components.RemoveAt(mnuIndex);
                            }
                            emnu.Visible = emnu.Components.Count > 0;

                        }

                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esymnu"></param>
        /// <param name="childMenu"></param>
        /// <returns></returns>
        private int GetIndex(EasyMenu esymnu, string childMenu)
        {
            int Result = -1;
            for (int j = 0; j < esymnu.Components.Count; j++)
            {
                if (esymnu.Components[j].ID == childMenu)
                {
                    Result = j;
                    break;
                }

            }
            return Result;
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
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {




            this.PreRender += new System.EventHandler(this.MenuControl_PreRender);





        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public virtual string SchoolStyleSheet
        {
            get { return SessionContext.SiteStyleSheet; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MenuControl_PreRender(object sender, System.EventArgs e)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializeMenu()
        {

        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }

        protected void lnkThemeChange_Click(object sender, EventArgs e)
        {

            SessionContext.Theme = "SMS";
            //Response.Redirect(Request.RawUrl);
        }


    }
}
