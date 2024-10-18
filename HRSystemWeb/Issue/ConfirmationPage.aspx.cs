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

namespace HRSystemWeb.Issue
{
    public partial class ConfirmationPage : System.Web.UI.Page
    {
        protected URLMessage URLMessage;

        protected void Page_Load(object sender, System.EventArgs e)
        {
          
            URLMessage = new URLMessage();
            try
            {              
                lblSection.Text = Server.HtmlDecode(Request.Params["message"]);
            }
            catch
            {
                lblSection.Text = "";
            }

        }

     
        //		public virtual string SiteX
        //		{
        public string SiteX
        {
            get { return SessionContext.SiteX; }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();

        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lnkHome.Click += new System.EventHandler(this.lnkHome_Click);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        protected void lnkHome_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(@"..\Home\Home.aspx");
        }

    }
}
