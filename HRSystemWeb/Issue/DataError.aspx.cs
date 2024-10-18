using System;

namespace HRSystemWeb.Issue
{
    public partial class DataError : PageBase
    {
        protected URLMessage URLMessage;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            URLMessage = new URLMessage();
            try
            {
                lblSection.Text = Request.Params["message"];
            }
            catch
            {
                lblSection.Text = "";
            }
        }
        public string SchoolStyleSheet
        {
            get { return SessionContext.SiteStyleSheet; }
        }
        public string SchoolX
        {
            get { return SessionContext.SiteX; }
        }
    }
}
