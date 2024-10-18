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
using HRSystemWeb;
using HRSystemWeb.Issue;
using HRSystemServer.BusinessLayer;

public partial class SecurityProfile_SecurityProfileView : PageBase
{
    protected DataSet ds = new DataSet();
    protected override void Page_Load(object sender, EventArgs e)
    {
        PageCode = "SystemRoleType";
        PageName = "System Role Type";
        base.Page_Load(sender, e);

        if (!Page.IsPostBack)
        {
            PrepView();
        }
    }


    private void PrepView()
    {
        lblPageName.Text = "View " + PageName;
        RowId = URLMessage.GetParam(PageCode, 0);
        SystemRoleTypeBL bl = new SystemRoleTypeBL(SessionContext.SystemUser);
        bl.Fetch(ds, RowId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            PageMappingBL bl2 = new PageMappingBL(SessionContext.SystemUser);
            bl2.FetchAll(ds);

            grdPageMapping.DataSource = ds.Tables[1].DefaultView;
            grdPageMapping.DataBind();
            this.DataBind();
        }
        else
            RaisePage.ItemNotFound(Request.RawUrl);
    }




    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(PageCode + "List.aspx");
    }
    protected void grdPageMapping_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {

        grdPageMapping.CurrentPageIndex = e.NewPageIndex;
        PrepView();

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void grdPageMapping_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Response.Redirect("SecurityDetailEdit.aspx?" + URLMessage.Encrypt("action=update&PageMapping=" + e.CommandArgument.ToString() + "&SystemRoleType=" + URLMessage.GetParam("SystemRoleType", "")));

        }
    }
}


