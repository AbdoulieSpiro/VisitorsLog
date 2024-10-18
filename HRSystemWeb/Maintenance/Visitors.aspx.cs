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
using DocumentFormat.OpenXml.Bibliography;

namespace HRSystemWeb
{
    public partial class Visitors : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        DataSet dsTransaction;
        DataSet dsDocument;
        public static bool isAddImg = true;
        public static int VisitorsID;
        string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

        SqlCommand scmd;

        public DataSet dstransaction = new DataSet();
        public static string FstName;

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "Visitors";
            PageName = "Visitors";
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
            ParentId = URLMessage.GetParam("VisitorsList", -1);

            DataSet ds1 = new DataSet();
            new DepartmentBL(SessionContext.SystemUser).FetchForDepartment(ds1, SessionContext.Department);
            WebUtility.FillDropDownList(drpDepartment, ds1.Tables[0], "DepartmentXX", "Department", -1);
            drpDepartment.Items.Insert(0, new ListItem("Select", "-1"));

            DataSet ds2 = new DataSet();
            new UnitBL(SessionContext.SystemUser).FetchForUnit(ds2, SessionContext.Department);
            WebUtility.FillDropDownList(drpUnit, ds2.Tables[0], "UnitXX", "Unit", -1);
            drpUnit.Items.Insert(0, new ListItem("Select", "-1"));

            btnSave.Visible = true;
            btnEdit.Visible = false;

        }



        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);

            txtLstName.Text = "";
            txtFstName.Text = "";
            txtGender.Text = "";
            imgPhotoView.AlternateText = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtMobile.Text = "";
            txtNational.Text = "";
            txtCompany.Text = "";
            txtReason.Text = "";
            txtContPerson.Text = "";
            drpDepartment.Text = "";
            drpUnit.Text = "";
            //cmbBranchTypr.SelectedIndex = -1;

            VisitorBL VisitorsBL = new VisitorBL(0);
            DataSet Visitors = new DataSet();
            VisitorsBL.Fetch(Visitors, RowId);

            txtFstName.Text = Visitors.Tables[0].Rows[0]["FirstName"].ToString();
            txtLstName.Text = Visitors.Tables[0].Rows[0]["LastName"].ToString();
            txtGender.Text = Visitors.Tables[0].Rows[0]["Gender"].ToString();
            imgPhotoView.AlternateText = Visitors.Tables[0].Rows[0]["Photo"].ToString();
            txtAddress.Text = Visitors.Tables[0].Rows[0]["Address"].ToString();
            txtAddress2.Text = Visitors.Tables[0].Rows[0]["Address2"].ToString();
            txtDOB.Text = Visitors.Tables[0].Rows[0]["DOB"].ToString();
            txtEmail.Text = Visitors.Tables[0].Rows[0]["Email"].ToString();
            txtTel.Text = Visitors.Tables[0].Rows[0]["Telephone"].ToString();
            txtMobile.Text = Visitors.Tables[0].Rows[0]["Mobile"].ToString();
            txtNational.Text = Visitors.Tables[0].Rows[0]["Nationality"].ToString();
            txtCompany.Text = Visitors.Tables[0].Rows[0]["CompanyFrom"].ToString();
            txtReason.Text = Visitors.Tables[0].Rows[0]["Reason"].ToString();
            txtContPerson.Text = Visitors.Tables[0].Rows[0]["ContactPerson"].ToString();
            drpDepartment.Text = Visitors.Tables[0].Rows[0]["Department"].ToString();
            drpUnit.Text = Visitors.Tables[0].Rows[0]["Unit"].ToString();
            // cmbBranchTypr.Text = Visitors.Tables[0].Rows[0]["BranchType"].ToString();

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = false;

            EnableFields(false);
            txtFstName.Enabled = true;
            txtLstName.Enabled = true;

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.DataBind();
                //txtFailedLoginCount.Enabled = true;

                DataSet ds1 = new DataSet();
                DepartmentBL DepartmentBL = new DepartmentBL(SessionContext.SystemUser);

                DataSet ds2 = new DataSet();
                UnitBL UnitBL = new UnitBL(SessionContext.SystemUser);


                DepartmentBL.FetchAll(ds1);
                WebUtility.FillDropDownList(drpDepartment, ds1.Tables[0], "DepartmrntX", "DepartmentXX", -1);
                drpDepartment.Items.Insert(0, new ListItem("Select", "-1"));
                WebUtility.SetDropDownListValue(drpDepartment, (int)ds.Tables[0].Rows[0]["DepartmentXX"]);

                UnitBL.FetchAll(ds2);
                WebUtility.FillDropDownList(drpUnit, ds1.Tables[0], "UnitX", "UnittXX", -1);
                drpUnit.Items.Insert(0, new ListItem("Select", "-1"));
                //          InsertSelect(drpBranch);
                //WebUtility.SetDropDownListValue(drpBranch,ds.Tables[0].Rows[0]["BranchID"]);
                WebUtility.SetDropDownListValue(drpUnit, ds.Tables[0].Rows[0]["UnitXX"].ToString());

            }

        }

        private void PrepView()
        {
            RowId = URLMessage.GetParam(PageCode, 0);

            txtLstName.Text = "";
            txtFstName.Text = "";
            txtGender.Text = "";
            imgPhotoView.AlternateText = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtMobile.Text = "";
            txtNational.Text = "";
            txtCompany.Text = "";
            txtReason.Text = "";
            txtContPerson.Text = "";
            drpDepartment.Text = "";
            drpUnit.Text = "";
            //cmbBranchTypr.SelectedIndex = -1;

            VisitorBL VisitorsBL = new VisitorBL(0);
            DataSet Visitors = new DataSet();
            VisitorsBL.Fetch(Visitors, RowId);

            txtFstName.Text = Visitors.Tables[0].Rows[0]["FirstName"].ToString();
            txtLstName.Text = Visitors.Tables[0].Rows[0]["LastName"].ToString();
            txtGender.Text = Visitors.Tables[0].Rows[0]["Gender"].ToString();
            imgPhotoView.AlternateText = Visitors.Tables[0].Rows[0]["Photo"].ToString();
            txtAddress.Text = Visitors.Tables[0].Rows[0]["Address"].ToString();
            txtAddress2.Text = Visitors.Tables[0].Rows[0]["Address2"].ToString();
            txtDOB.Text = Visitors.Tables[0].Rows[0]["DOB"].ToString();
            txtEmail.Text = Visitors.Tables[0].Rows[0]["Email"].ToString();
            txtTel.Text = Visitors.Tables[0].Rows[0]["Telephone"].ToString();
            txtMobile.Text = Visitors.Tables[0].Rows[0]["Mobile"].ToString();
            txtNational.Text = Visitors.Tables[0].Rows[0]["Nationality"].ToString();
            txtCompany.Text = Visitors.Tables[0].Rows[0]["CompanyFrom"].ToString();
            txtReason.Text = Visitors.Tables[0].Rows[0]["Reason"].ToString();
            txtContPerson.Text = Visitors.Tables[0].Rows[0]["ContactPerson"].ToString();
            drpDepartment.Text = Visitors.Tables[0].Rows[0]["Department"].ToString();
            drpUnit.Text = Visitors.Tables[0].Rows[0]["Unit"].ToString();

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
            Response.Redirect("~/Maintenance/VisitorsList.aspx");

        }
        protected void btnNew_Click(object sender, System.EventArgs e)
        {
            // In your code-behind file (.aspx.cs)
            Response.Redirect(Request.RawUrl);

        }

        private void Save(string Action)
        {
            Page.Validate();
            VisitorBL VisitorBL = new VisitorBL(0);
            DataSet DSVisitors = new DataSet();
            if (Page.IsValid)
            {
                switch (Action)
                {
                    case "Create":
                        DoCreate(VisitorBL, DSVisitors);
                        break;
                    case "Update":
                        DoUpdate(
                            VisitorBL,
                            DSVisitors);
                        break;
                }
                if (VisitorBL.Save(DSVisitors))
                {

                    lblMessage.Text = "Visitors Created Save Successufully";
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
                    lblMessage.Text = "Visitors Created Failed to Save";
                    lblMessage.ForeColor = Color.Red;
                    lblMessageHeader.Text = "Error";
                    lblMessageHeader.ForeColor = Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                }
            }
        }

        private void DoUpdate(VisitorBL visitorsBL, DataSet dSVisitors)
        {
            throw new NotImplementedException();
        }

        private void DoCreate(VisitorBL visitorsBL, DataSet dSVisitors)
        {
            visitorsBL.Fetch(dSVisitors, int.MinValue);
            DataRow NewRow = dSVisitors.Tables[0].NewRow();
            dSVisitors.Tables[0].Rows.Add(NewRow);
            ScreenScrape(NewRow, true);
        }

        private void EnableFields(Boolean value)
        {
            //cmbBranchTypr.Enabled = value;
            txtFstName.Enabled = value;
            txtLstName.Enabled = value;

        }


        private void ClearFields()
        {
            txtFstName.Text = "";
            txtLstName.Text = "";
            txtGender.Text = "";
            imgPhotoView.AlternateText = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtMobile.Text = "";
            txtNational.Text = "";
            txtCompany.Text = "";
            txtReason.Text = "";
            txtContPerson.Text = "";
            //drpDepartment.Text = "";
            //drpUnit.Text = "";

        }


        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            // Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));

            Response.Redirect("~/Maintenance/VisitorsList.aspx");

        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            DoDelete(bl);
            if (bl.Save(ds))
                Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));

        }

        #region "Update The Existing Row And Update The DataBase"
        public void DoUpdate(VisitorBL VisitorsBL, DataSet DSVisitors, int id)
        {
            VisitorsBL.Fetch(DSVisitors, VisitorsID);
            ScreenScrape(DSVisitors.Tables[0].Rows[0], false);
        }
        #endregion

        #region " SCREEN SCRAPE For CREATE AND UPDATE "
        private void ScreenScrape(DataRow aDataRow, bool IsCreate)
        {
            aDataRow["FirstName"] = txtFstName.Text.Trim();
            aDataRow["LastName"] = txtLstName.Text.Trim();
            aDataRow["Gender"] = txtGender.Text.Trim();
            aDataRow["Photo"] = imgPhotoView.AlternateText.Trim();
            aDataRow["Address"] = txtAddress.Text.Trim();
            aDataRow["Address2"] = txtAddress2.Text.Trim();
            aDataRow["DOB"] = txtDOB.Text.Trim();
            aDataRow["Email"] = txtEmail.Text.Trim();
            aDataRow["Telephone"] = txtTel.Text.Trim();
            aDataRow["Mobile"] = txtMobile.Text.Trim();
            aDataRow["Nationality"] = txtNational.Text.Trim();
            aDataRow["CompanyFrom"] = txtCompany.Text.Trim();
            aDataRow["Reason"] = txtReason.Text.Trim();
            aDataRow["ContactPerson"] = txtContPerson.Text.Trim();
            aDataRow["Department"] = drpDepartment.Text.Trim();
            aDataRow["Unit"] = drpUnit.Text.Trim();

            //aDataRow["BranchType"] = cmbBranchTypr.SelectedValue.ToString();
            if (IsCreate)
            {
                //aDataRow["FirstName"] = cmbBranchTypr.SelectedValue + "-" + GenerateTripID(2);

                aDataRow["CreatedBySystemUser"] = SessionContext.SystemUser;
                aDataRow["IsDeleted"] = false;
            }
            else
                aDataRow["UpdatedBySystemUser"] = SessionContext.SystemUser;

        }
        #endregion

        #region "DELETE The Existing Row And Update The DataBase"
        public void DoDelete(VisitorBL VisitorsBL, DataSet DSVisitors)
        {
            //DSVisitors.Tables[0].Rows[0].Delete();
            //if (VisitorsBL.Delete(DSVisitors, VisitorsID))
            //{
            //    MessageBox.Show("Deleted Successfully", "DELETE");
            //    //BindVisitorsDataGrid();
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



