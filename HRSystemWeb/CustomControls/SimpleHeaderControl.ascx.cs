namespace HRSystemWeb
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Web.Security;
    using HRSystemServer.BusinessLayer;

    public partial class SimpleHeaderControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            /*<asp:textbox id="txtSearch" MaxLength=50 CssClass="LabelText" runat="server" Visible="False">plastic</asp:textbox>
            <asp:linkbutton id="lnkGo" runat="server" Width="40px" CssClass="standardMenuHeader" Font-Bold="True"
                CausesValidation="false" BorderColor="White" Visible="False">Go!</asp:linkbutton-->
            */
            //lblGreeting.Text  = SessionContext.SystemUserX;
            //lnkLogout.Visible =  SessionContext.SystemUser>=0;
            //lnkLogin.Visible  = !lnkLogout.Visible;
            if (!Page.IsPostBack)
            {
                //txtSearch.Text   = SessionContext.SearchHint;
                //WebUtility.SetDefaultButtonForControl(this.Page,  WebUtility.ControlTypes.TextBox, txtSearch,lnkGo);
            }
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
            //this.lnkHome.Click += new System.Web.UI.ImageClickEventHandler(this.lnkHome_Click);
            //this.lnkLogout.Click += new System.Web.UI.ImageClickEventHandler(this.lnkLogout_Click);
            //this.lnkLogin.Click += new System.Web.UI.ImageClickEventHandler(this.lnkLogin_Click);
            //this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            
            Response.Redirect(@"~/Login/Login.aspx");
        }
    }
}
