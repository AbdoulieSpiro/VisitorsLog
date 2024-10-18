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

namespace HRSystemWeb
{
    public partial class Department : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        DataSet dsTransaction;
        DataSet dsDocument;
        public static bool isAddImg = true;
        public static int DepartmentID;
        string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

        SqlCommand scmd;

        public DataSet dstransaction = new DataSet();
        public static string DepartmentCode;

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "Department";
            PageName = "Department";
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

                //BindBranchType();

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
            ParentId = URLMessage.GetParam("DepartmentList", -1);

            btnSave.Visible = true;
            btnEdit.Visible = false;

        }



        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);




            txtDepartmentName.Text = "";
            txtDepartmentCode.Text = "";
            

            DepartmentBL DepartmentBL = new DepartmentBL(0);
            DataSet Department = new DataSet();
            DepartmentBL.Fetch(Department, RowId);

            txtDepartmentCode.Text = Department.Tables[0].Rows[0]["DepartmentX"].ToString();
            txtDepartmentName.Text = Department.Tables[0].Rows[0]["DepartmentXX"].ToString();

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = false;

            EnableFields(false);
            txtDepartmentName.Enabled = true;

        }

        private void PrepView()
        {
            RowId = URLMessage.GetParam(PageCode, 0);

            txtDepartmentName.Text = "";
            txtDepartmentCode.Text = "";
            

            DepartmentBL DepartmentBL = new DepartmentBL(0);
            DataSet Department = new DataSet();
            DepartmentBL.Fetch(Department, RowId);

            txtDepartmentCode.Text = Department.Tables[0].Rows[0]["DepartmentX"].ToString();
            txtDepartmentName.Text = Department.Tables[0].Rows[0]["DepartmentXX"].ToString();
           

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
            Response.Redirect("~/Maintenance/DepartmentList.aspx");

        }
        protected void btnNew_Click(object sender, System.EventArgs e)
        {
            // In your code-behind file (.aspx.cs)
            Response.Redirect(Request.RawUrl);

        }

        private void Save(string Action)
        {
            Page.Validate();
            DepartmentBL DepartmentBL = new DepartmentBL(0);
            DataSet DSDepartment = new DataSet();
            if (Page.IsValid)
            {
                switch (Action)
                {
                    case "Create":
                        DoCreate(DepartmentBL, DSDepartment);
                        break;
                    case "Update":
                        DoUpdate(DepartmentBL, DSDepartment);
                        break;
                }
                if (DepartmentBL.Save(DSDepartment))
                {

                    lblMessage.Text = "Department Created Save Successufully";
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
                    lblMessage.Text = "Department Created Failed to Save";
                    lblMessage.ForeColor = Color.Red;
                    lblMessageHeader.Text = "Error";
                    lblMessageHeader.ForeColor = Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                }
            }
        }



        private void EnableFields(Boolean value)
        {
            //cmbBranchTypr.Enabled = value;
            txtDepartmentCode.Enabled = value;
            txtDepartmentName.Enabled = value;

        }


        private void ClearFields()
        {
            txtDepartmentName.Text = "";
            txtDepartmentCode.Text = "";

        }


        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            // Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));

            Response.Redirect("~/Maintenance/DepartmentList.aspx");

        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            DoDelete(bl);
            if (bl.Save(ds))
                Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));

        }

        #region "Create A New Row And Add It To The DataSet"
        public void DoCreate(DepartmentBL DepartmentBL, DataSet DSDepartment)
        {
            DepartmentBL.Fetch(DSDepartment, int.MinValue);
            DataRow NewRow = DSDepartment.Tables[0].NewRow();
            DSDepartment.Tables[0].Rows.Add(NewRow);
            ScreenScrape(NewRow, true);
        }
        #endregion

        #region "Update The Existing Row And Update The DataBase"
        public void DoUpdate(DepartmentBL DepartmentBL, DataSet DSDepartment)
        {
            DepartmentBL.Fetch(DSDepartment, DepartmentID);
            ScreenScrape(DSDepartment.Tables[0].Rows[0], false);
        }
        #endregion

        #region " SCREEN SCRAPE For CREATE AND UPDATE "
        private void ScreenScrape(DataRow aDataRow, bool IsCreate)
        {
            aDataRow["DepartmentX"] = txtDepartmentCode.Text.Trim();
            aDataRow["DepartmentXX"] = txtDepartmentName.Text.Trim();
            //aDataRow["BranchType"] = cmbBranchTypr.SelectedValue.ToString();
            if (IsCreate)
            {
                //aDataRow["DepartmentX"] = cmbBranchTypr.SelectedValue + "-" + GenerateTripID(2);

                //aDataRow["CreatedBySystemUser"] = SessionContext.SystemUser;
                aDataRow["IsDeleted"] = false;
            }
            else
                aDataRow["UpdatedBySystemUser"] = SessionContext.SystemUser;

        }
        #endregion

        #region "DELETE The Existing Row And Update The DataBase"
        public void DoDelete(DepartmentBL DepartmentBL, DataSet DSDepartment)
        {
            //DSDepartment.Tables[0].Rows[0].Delete();
            //if (DepartmentBL.Delete(DSDepartment, DepartmentID))
            //{
            //    MessageBox.Show("Deleted Successfully", "DELETE");
            //    //BindDepartmentDataGrid();
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



