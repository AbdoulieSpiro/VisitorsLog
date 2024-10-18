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
using System.Text;
namespace HRSystemWeb
{
    public partial class RolePageMappingList : PageBase
    {

        protected override void Page_Load(object sender, System.EventArgs e)
        {
            RequireValidate = false;
            base.Page_Load(sender, e);
            PageCode = "PageMapping";
            PageName = "Page Mapping";
            if (!Page.IsPostBack)
            {
                lblPageName.Text = "Role Page Mapping Maintenance";
                RowId = URLMessage.GetParam("SecurityProfile", 0);
                FillGrid(SessionContext.GridPage);
            }
        }



        public void chkCheckall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridItem item in grdPage.Items)
            {
                if (item.FindControl("chkSelect") != null)
                {
                    ((HtmlInputCheckBox)item.FindControl("chkSelect")).Checked = ((CheckBox)sender).Checked;
                }
            }
        }


        protected void lnkEdit_Click(object sender, System.EventArgs e)
        {
            string id = URLMessage.GetParam("SecurityProfile", "0");
            if (!id.Equals("0"))
            {
                Response.Redirect("../SecurityProfile/SecurityProfileEdit.aspx?" + URLMessage.Encrypt("action=" + URLAction.update.ToString() + "&SecurityProfile=" + id));
            }
        }

        protected void lnkClone_Click(object sender, System.EventArgs e)
        {
            SecurityProfileBL bl = new SecurityProfileBL(SessionContext.SystemUser);
            if (bl.Clone(RowId))
            {
                Response.Redirect("../SecurityProfile/SecurityProfileList.aspx");
            }
        }

        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../SecurityProfile/SecurityProfileList.aspx");
        }

        private void FillGrid(int aPageNumber)
        {
            DataSet ds = new DataSet();
            RolePageMappingBL bl = new RolePageMappingBL(0);
            bl.FetchForRole(ds, RowId);

            ds.Tables[0].DefaultView.Sort = PageCode + "XX";
            ds.Tables[0].Columns.Add("JumpParam");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                item["JumpParam"] = "../Securityprofile/SecurityDetailEdit.aspx?" + URLMessage.Encrypt("action=update&PageMapping=" + item["PageMapping"] + "&SecurityProfile=" + RowId.ToString());
            }
            grdPage.DataSource = ds.Tables[0].DefaultView;
            grdPage.CurrentPageIndex = aPageNumber > grdPage.PageCount ? 0 : aPageNumber;
            grdPage.DataBind();
            SessionContext.GridPage = grdPage.CurrentPageIndex;
        }


        private void grdPage_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            FillGrid(e.NewPageIndex);
        }

        protected void lnkCreate_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=create"));
        }

        protected void lnkSave_Click(object sender, System.EventArgs e)
        {
            RolePageMappingBL bl = new RolePageMappingBL(0);
            bl.InsertUpdateMultiple(GenReateXml(), RowId);
            ApplicationContext.ReloadpageSecurity();
        }

        protected void grdPage_ItemCommand(object source, DataGridCommandEventArgs e)
        {

        }

        private string GenReateXml()
        {
           
            StringBuilder InvestorDetail;
            try
            {
                InvestorDetail = new StringBuilder();
                HtmlInputCheckBox DocID;
                InvestorDetail.Append("<ROOT>");
                foreach (DataGridItem grdRow in grdPage.Items)
                {
                    DocID = (HtmlInputCheckBox)grdRow.Cells[0].FindControl("chkSelect");
                    //if (DocID.Checked)
                    //{
                    InvestorDetail.Append("<Row Isselected=\"" + DocID.Checked + "\" Pagemapping= \"" + DocID.Value + "\" ");
                    InvestorDetail.Append("/>\n");
                    //}
                }
                return InvestorDetail.Append("</ROOT>").ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                InvestorDetail = null;
            }
        }

    }
}
