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
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using HRSystemServer.DataLayer;
using System.ServiceModel.Activities;
using System.IO;
using Irony;

namespace HRSystemWeb
{
    public partial class Unit : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        DataSet dsTransaction;
        DataSet dsDocument;
        public static bool isAddImg = true;
        public static int UnitID;
        string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

        SqlCommand scmd;

        public DataSet dstransaction = new DataSet();
        public static string UnitCode;

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "Unit";
            PageName = "Unit";
            //Confirm(lnkDelete, "Are you sure to delete selected mapping?");



            if (!Page.IsPostBack)
            {
                switch (URLMessage.URLAction)
                {
                    case URLAction.create:
                        PrepCreate();
                        break;
                    case URLAction.update:
                        PrepUpdate();
                        break;
                    case URLAction.delete:
                        break;
                    case URLAction.view:
                        PrepView();
                        break;
                    default:
                        PrepCreate();
                        break;
                }

                //BindUnitType();

            }
        }

        protected void grdPosting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = e.Row.Cells.Count - 1; i >= 0; i--)
                {
                    // Check if the column should be visible
                    //bool isVisible = columnsToShow.Contains(grdPosting.Columns[i].SortExpression);
                    //if (!isVisible)
                    //{
                    //    e.Row.Cells[i].Visible = false;
                    //}

                    e.Row.Cells[i].Visible = false;
                    e.Row.Cells[1].Visible = true;
                    e.Row.Cells[2].Visible = true;

                }
            }
        }


        private void PrepCreate()
        {
            //lnkDelete.Visible = false;
            RowId = int.MinValue;
            ParentId = URLMessage.GetParam("UnitList", -1);

            btnSave.Visible = true;
            btnEdit.Visible = false;

        }



        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);




            txtUnitName.Text = "";
            txtUnitCode.Text = "";
            //cmbUnitTypr.SelectedIndex = -1;

            UnitBL UnitBL = new UnitBL(0);
            DataSet Unit = new DataSet();
            UnitBL.Fetch(Unit, RowId);

            txtUnitCode.Text = Unit.Tables[0].Rows[0]["UnitX"].ToString();
            txtUnitName.Text = Unit.Tables[0].Rows[0]["UnitXX"].ToString();
            // cmbUnitTypr.Text = Unit.Tables[0].Rows[0]["UnitType"].ToString();

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = false;

            EnableFields(false);
            txtUnitName.Enabled = true;

        }

        private void PrepView()
        {
            RowId = URLMessage.GetParam(PageCode, 0);

            txtUnitName.Text = "";
            txtUnitCode.Text = "";
            //cmbUnitTypr.SelectedIndex = -1;

            UnitBL UnitBL = new UnitBL(0);
            DataSet Unit = new DataSet();
            UnitBL.Fetch(Unit, RowId);

            txtUnitCode.Text = Unit.Tables[0].Rows[0]["UnitX"].ToString();
            txtUnitName.Text = Unit.Tables[0].Rows[0]["UnitXX"].ToString();
            // cmbUnitTypr.Text = Unit.Tables[0].Rows[0]["UnitType"].ToString();

            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = false;
            EnableFields(false);

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


        private void DoDelete(ControlMappingBL bl)
        {
            bl.Fetch(ds, RowId);
            ds.Tables[0].Rows[0].Delete();
        }


        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            Save("Update");
        }
        protected void lnkUpdate_Click(object sender, System.EventArgs e)
        {
            Save("Create");
        }
        protected void btnList_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/Maintenance/UnitList.aspx");

        }
        protected void btnNew_Click(object sender, System.EventArgs e)
        {
            // In your code-behind file (.aspx.cs)
            Response.Redirect(Request.RawUrl);

        }

        private void Save(string Action)
        {
            Page.Validate();
            UnitBL UnitBL = new UnitBL(0);
            DataSet DSUnit = new DataSet();
            if (Page.IsValid)
            {
                switch (Action)
                {
                    case "Create":
                        DoCreate(UnitBL, DSUnit);
                        break;
                    case "Update":
                        DoUpdate(UnitBL, DSUnit);
                        break;
                }
                if (UnitBL.Save(DSUnit))
                {

                    lblMessage.Text = "Unit Created Save Successufully";
                    btnSave.Enabled = false;
                    ClearFields();
                    EnableFields(false);
                    lblMessage.ForeColor = Color.Green;
                    lblMessageHeader.Text = "Success";
                    lblMessageHeader.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                }
                else
                {
                    btnSave.Enabled = true;
                    lblMessage.Text = "Unit Created Failed to Save";
                    lblMessage.ForeColor = Color.Red;
                    lblMessageHeader.Text = "Error";
                    lblMessageHeader.ForeColor = Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                }
            }
        }



        private void EnableFields(Boolean value)
        {
            //cmbUnitTypr.Enabled = value;
            txtUnitCode.Enabled = value;
            txtUnitName.Enabled = value;

        }


        private void ClearFields()
        {
            txtUnitName.Text = "";
            txtUnitCode.Text = "";

        }


        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            // Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));

            Response.Redirect("~/Maintenance/UnitList.aspx");

        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            DoDelete(bl);
            if (bl.Save(ds))
                Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));

        }

        #region "Create A New Row And Add It To The DataSet"
        public void DoCreate(UnitBL UnitBL, DataSet DSUnit)
        {
            UnitBL.Fetch(DSUnit, int.MinValue);
            DataRow NewRow = DSUnit.Tables[0].NewRow();
            DSUnit.Tables[0].Rows.Add(NewRow);
            ScreenScrape(NewRow, true);
        }
        #endregion

        #region "Update The Existing Row And Update The DataBase"
        public void DoUpdate(UnitBL UnitBL, DataSet DSUnit)
        {
            UnitBL.Fetch(DSUnit, UnitID);
            ScreenScrape(DSUnit.Tables[0].Rows[0], false);
        }
        #endregion

        #region " SCREEN SCRAPE For CREATE AND UPDATE "
        private void ScreenScrape(DataRow aDataRow, bool IsCreate)
        {
            aDataRow["UnitX"] = txtUnitCode.Text.Trim();
            aDataRow["UnitXX"] = txtUnitName.Text.Trim();
            //aDataRow["UnitType"] = cmbUnitTypr.SelectedValue.ToString();
            if (IsCreate)
            {
                //aDataRow["UnitX"] = cmbUnitTypr.SelectedValue + "-" + GenerateTripID(2);

                //aDataRow["CreatedBySystemUser"] = SessionContext.SystemUser;
                aDataRow["IsDeleted"] = false;
            }
            else
                aDataRow["UpdatedBySystemUser"] = SessionContext.SystemUser;

        }
        #endregion

        #region "DELETE The Existing Row And Update The DataBase"
        public void DoDelete(UnitBL UnitBL, DataSet DSUnit)
        {
            //DSUnit.Tables[0].Rows[0].Delete();
            //if (UnitBL.Delete(DSUnit, UnitID))
            //{
            //    MessageBox.Show("Deleted Successfully", "DELETE");
            //    //BindUnitDataGrid();
            //    //DisableFields();
            //    //EnableActions(true);
            //}
            //else
            //{
            //    MessageBox.Show("Cannot Deleted Because of Records Avaiable", "DELETE");
            //}
        }
        #endregion


    }
}



