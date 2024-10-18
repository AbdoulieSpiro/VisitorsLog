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
using HRSystemServer.DataLayer;
using System.Data.SqlClient;

namespace HRSystemWeb.SecurityProfile
{
    public partial class SecurityDetailEdit : PageBase
    {
        protected DataSet ds = new DataSet();


        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "SecurityProfile";
            PageName = "Security Profile";
            if (!Page.IsPostBack)
            {
                switch (URLMessage.URLAction)
                {
                    case URLAction.update:
                        PrepUpdate();
                        break;
                }
            }
        }

        private void PrepUpdate()
        {
            DataSet ds = new DataSet();
            SecurityDetailBL bl = new SecurityDetailBL(SessionContext.SystemUser);
            bl.FetchForPageMapping(ds, URLMessage.GetParam("SecurityProfile", -1), URLMessage.GetParam("PageMapping", -1));
            grdSecurityDetail.DataSource = ds.Tables[0];
            DataBind();
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion



        private void DoUpdate(SecurityProfileBL bl)
        {
            SecurityDetailBL secDetail = new SecurityDetailBL(SessionContext.SystemUser);
            DataTable buffer = GridToTable();
            foreach (DataRow item in buffer.Rows)
            {
                secDetail.Upsert(WebUtility.Cast(item["SecurityDetail"], -1),
                                  WebUtility.Cast(item["ControlMapping"], -1),
                                  WebUtility.Cast(item["SecurityProfile"], -1),
                                  item["ControlState"].ToString());
            }
            ApplicationContext.ReloadControlSecurity();
        }


        protected void lnkUpdate_Click(object sender, System.EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                SecurityProfileBL bl = new SecurityProfileBL(SessionContext.SystemUser);
                switch (URLMessage.URLAction)
                {
                    case URLAction.update:
                        DoUpdate(bl);
                        break;
                }

                Response.Redirect("../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("action=view&SecurityProfile=" + URLMessage.GetParam("SecurityProfile", "0")));
            }

        }

        private DataTable GridToTable()
        {
            DataTable result = new DataTable();
            DataRow newRow;
            int i;
            DataGridItem dgi;

            result.Columns.Add("SecurityDetail");
            result.Columns.Add("ControlMapping");
            result.Columns.Add("SecurityProfile");
            result.Columns.Add("ControlState");

            for (i = 0; i < grdSecurityDetail.Items.Count; i++)
            {
                dgi = grdSecurityDetail.Items[i];
                if (dgi.ItemType == ListItemType.AlternatingItem || dgi.ItemType == ListItemType.Item)
                {
                    newRow = result.NewRow();
                    newRow["SecurityDetail"] = ((Label)dgi.FindControl("lblSecurityDetail")).Text;
                    newRow["ControlMapping"] = ((Label)dgi.FindControl("lblControlMapping")).Text;
                    newRow["SecurityProfile"] = ((Label)dgi.FindControl("lblSecurityProfile")).Text;
                    newRow["ControlState"] = ((RadioButtonList)dgi.FindControl("optControlState")).SelectedValue;
                    result.Rows.Add(newRow);
                }
            }
            return result;
        }

        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("action=view&SecurityProfile=" + URLMessage.GetParam("SecurityProfile", "0")));
        }
    }
}
