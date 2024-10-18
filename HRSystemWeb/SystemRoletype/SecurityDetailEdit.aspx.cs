using System;
using System.Data;
//using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HRSystemWeb;
using HRSystemServer.BusinessLayer;

public partial class SecurityDetail_SecurityDetailEdit : PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        PageCode = "SystemRoleType";
        PageName = "System Role Type";
        base.Page_Load(sender, e);
        if (!Page.IsPostBack)
        {
            switch (URLMessage.URLAction)
            {
                case URLAction.update:
                    PrepUpdate(SessionContext.GridPage);
                    break;
            }
        }
    }

    private void PrepUpdate(int aPageIndex)
    {
        lblPageName.Text = "Update " + PageName;

        DataSet ds = new DataSet();

        SecurityDetailBL bl = new SecurityDetailBL(SessionContext.SystemUser);
        PageMappingDetailBL pmdbl = new PageMappingDetailBL(0);
        RowId = URLMessage.GetParam("PageMapping", -1);
        ParentId = URLMessage.GetParam("SystemRoletype", -1);

        pmdbl.FetchForPageMapping(ds, ParentId, RowId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            panDeyAcces.Visible = (ds.Tables[0].Rows[0]["PageMappingX"].ToString().ToUpper().IndexOf(".ASPX") > -1);
            lblPageMappingX.Text = ds.Tables[0].Rows[0]["PageMappingX"].ToString();
            lblSystemRoletypeX.Text = ds.Tables[0].Rows[0]["SystemRoletypeX"].ToString();
            chkDeyAccess.Checked = WebUtility.Cast(ds.Tables[0].Rows[0]["DenyAccess"], false);
            chkPerformControlCheck.Checked = (WebUtility.Cast(ds.Tables[0].Rows[0]["PerformControlCheck"], false) && chkDeyAccess.Checked == false);

        }
        ds = new DataSet();
        bl.FetchForPageMapping(ds, ParentId, RowId);
        grdSecurityDetail.DataSource = ds.Tables[0];
        grdSecurityDetail.CurrentPageIndex = aPageIndex > grdSecurityDetail.PageCount ? 0 : aPageIndex;
        SessionContext.GridPage = grdSecurityDetail.CurrentPageIndex;
        DataBind();
        panSecurityDetail.Enabled = (chkPerformControlCheck.Checked == true && chkDeyAccess.Checked == false);
        bl = null;
        ds = null;
        pmdbl = null;


    }

    private void DoUpdate()
    {
        SecurityDetailBL secDetail = new SecurityDetailBL(SessionContext.SystemUser);
        DataTable buffer = GridToTable();
        foreach (DataRow item in buffer.Rows)
        {
            secDetail.Upsert(WebUtility.Cast(item["SecurityDetail"], -1),
                              WebUtility.Cast(item["ControlMapping"], -1),
                                URLMessage.GetParam("SystemRoletype", 0),
                              item["ControlState"].ToString());
        }
        ApplicationContext.ReloadControlSecurity();
    }



    private DataTable GridToTable()
    {
        DataTable result = new DataTable();
        DataRow newRow;
        int i;
        DataGridItem dgi;

        result.Columns.Add("SecurityDetail");
        result.Columns.Add("ControlMapping");
        result.Columns.Add("SystemRoletype");
        result.Columns.Add("ControlState");

        for (i = 0; i < grdSecurityDetail.Items.Count; i++)
        {
            dgi = grdSecurityDetail.Items[i];
            if (dgi.ItemType == ListItemType.AlternatingItem || dgi.ItemType == ListItemType.Item)
            {
                newRow = result.NewRow();
                newRow["SecurityDetail"] = ((Label)dgi.FindControl("lblSecurityDetail")).Text;
                newRow["ControlMapping"] = ((Label)dgi.FindControl("lblControlMapping")).Text;
                newRow["SystemRoletype"] = ((Label)dgi.FindControl("lblSystemRoleType")).Text;
                newRow["ControlState"] = ((RadioButtonList)dgi.FindControl("optControlState")).SelectedValue;
                result.Rows.Add(newRow);
            }
        }
        return result;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {

            switch (URLMessage.URLAction)
            {
                case URLAction.update:
                    DoUpdate();
                    break;
            }
            PageMappingDetailBL pmdbl = new PageMappingDetailBL(0);
            pmdbl.Upsert(-1, RowId, ParentId, chkPerformControlCheck.Checked, chkDeyAccess.Checked);
            pmdbl = null;

            Response.Redirect("SystemRoletypeView.aspx?" + URLMessage.Encrypt("action=view&SystemRoletype=" + URLMessage.GetParam("SystemRoletype", "0")));
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SystemRoletypeView.aspx?" + URLMessage.Encrypt("action=view&SystemRoletype=" + URLMessage.GetParam("SystemRoletype", "0")));

    }
    protected void chkPerformControlCheck_CheckedChanged(object sender, EventArgs e)
    {
        panSecurityDetail.Enabled = (chkPerformControlCheck.Checked == true && chkDeyAccess.Checked == false);
    }
    protected void chkDeyAccess_CheckedChanged(object sender, EventArgs e)
    {
        panPerformControlCheck.Enabled = (chkDeyAccess.Checked == false);
        panSecurityDetail.Enabled = (chkPerformControlCheck.Checked == true && chkDeyAccess.Checked == false);
    }
   
    protected void grdSecurityDetail_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        PrepUpdate(e.NewPageIndex);
    }
}

