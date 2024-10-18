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
    public partial class Transaction_Sale : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        DataSet dsTransaction;
        DocumentBL documentBL;
        DataSet dsDocument;


        string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

        SqlCommand scmd;

        Transaction1BL transactionBL = new Transaction1BL(0);
        public DataSet dstransaction = new DataSet();

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "ControlMapping";
            PageName = "Purchase ";
            //Confirm(lnkDelete, "Are you sure to delete selected mapping?");



            if (!Page.IsPostBack)
            {
                // ((MasterPage)(Page.Master)).PageTitle(SessionContext.SiteX + " - " + PageName);

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
                }

                LoadDropdown();


            }
        }





        protected void btnPost_Click(object sender, EventArgs e)
        {


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



        protected void grdItemList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectItem")
            {
                string itemX = e.CommandArgument.ToString();
                //Handle the selected itemX value here
                //For example, you could store it in a session variable, display it on the page, etc.
                //Response.Write("Selected ItemCode: " + itemX);

                loaddetails(itemX);

            }
        }


        //protected void lnkViewEmp_Click(object sender, EventArgs e)
        //{
        //    LinkButton btnDetails = sender as LinkButton;
        //    GridViewRow row = (GridViewRow)btnDetails.NamingContainer;
        //    string ItemX = this.grdItemList.DataKeys[row.RowIndex].Value.ToString();

        //    loaddetails(ItemX);
        //}


        private void PrepCreate()
        {
            //lnkDelete.Visible = false;
            RowId = int.MinValue;
            ParentId = URLMessage.GetParam("PageMapping", -1);

        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            txtAmount.Text = (WinUtility.Cast(txtSPrice.Text.Trim(), 0.0) * WinUtility.Cast(txtQuantity.Text.Trim(), 0.0)).ToString();
            //lblSaleQty.Text = txtQuantity.Text;
        }


        protected void txtSPrice_TextChanged(object sender, EventArgs e)
        {
            txtAmount.Text = (WinUtility.Cast(txtSPrice.Text.Trim(), 0.0) * WinUtility.Cast(txtQuantity.Text.Trim(), 0.0)).ToString();

        }


        private void LoadDropdown()
        {

            WebUtility.FillDropDownList(cmbTxn, new TxnBL(0), "TxnXX", "Txn");
            cmbTxn.Items.Insert(0, new ListItem("Select", "-1"));
            cmbTxn.SelectedValue = "3";
            cmbTxn.Enabled = false;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    string query = "SELECT GLACCTNO, LTRIM(RTRIM(GLACCTNO)) + ' - ' + LTRIM(RTRIM(GLNAME)) AS GLNAME FROM GL_DETAIL WHERE IsBankAccount = 'Y'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "GL_DETAIL");

                    DataRow newRow = ds.Tables[0].NewRow();
                    newRow["GLACCTNO"] = "-1";
                    newRow["GLNAME"] = "-Select-";
                    ds.Tables[0].Rows.InsertAt(newRow, 0); // Insert at the beginning

                    cmbDebitGl.DataSource = ds.Tables["GL_DETAIL"];
                    cmbDebitGl.DataTextField = "GLNAME";
                    cmbDebitGl.DataValueField = "GLACCTNO";
                    cmbDebitGl.DataBind();

                    // Optionally set the selected value to "-1" to select the "-Select-" item by default
                    cmbDebitGl.SelectedValue = "-1";
                }
                catch (Exception ex)
                {
                    // Log the exception and show an error message
                    // For example, use a logging framework or simply log to a file
                    // LogException(ex);
                    Response.Write("<script>alert('An error occurred while loading data.');</script>");
                }

            }
        }


        private void PrepUpdate()
        {
            RowId = URLMessage.GetParam(PageCode, 0);
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            bl.Fetch(ds, RowId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ParentId = (int)ds.Tables[0].Rows[0]["PageMapping"];
                this.DataBind();
            }
            //else
            // Error Handler	Issue.RaisePage.ItemNotFound(Request.RawUrl);
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




        private void ScreenScrape(DataRow aDataRow)
        {
            //aDataRow["ControlMappingX"] = txtControlMappingX.Text;
            //aDataRow["ControlMappingCode"] = txtControlMappingCode.Text;
        }

        private void DoCreate(ControlMappingBL bl)
        {
            bl.Fetch(ds, int.MinValue);
            DataRow newRow = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(newRow);
            ScreenScrape(newRow);
            newRow["PageMapping"] = URLMessage.GetParam("PageMapping", 0);
        }
        private void DoUpdate(ControlMappingBL bl)
        {
            bl.Fetch(ds, RowId);
            ScreenScrape(ds.Tables[0].Rows[0]);
        }

        private void DoDelete(ControlMappingBL bl)
        {
            bl.Fetch(ds, RowId);
            ds.Tables[0].Rows[0].Delete();
        }


        public void Save()
        {
            int i;
            string GLCode = "";
            int SRNO_ = 1;
            dsTransaction = new DataSet();
            transactionBL = new Transaction1BL(0);

            transactionBL.Fetch(dsTransaction, int.MinValue);

            // public DataSet GetResultsTable(String TransactionType, String GL, String GlName, String Branch, int Seq, int SRNO_, Double AmountUsed, Boolean Is_Stock)

            DataRow dr = dsTransaction.Tables[0].NewRow();

            dr["RequestID"] = "";
            dr["FromQuantity"] = txtQuantity.Text.Trim();
            dr["ToQuantity"] = txtQuantity.Text.Trim();
            dr["FromSalePrice"] = WinUtility.Cast(txtSPrice.Text.Trim(), 0.0);
            dr["ToSalePrice"] = WinUtility.Cast(txtSPrice.Text.Trim(), 0.0);
            dr["FromAmount"] = (WinUtility.Cast(txtAmount.Text, 0.0));
            dr["ToAmount"] = (WinUtility.Cast(txtAmount.Text, 0.0));
            dr["DiscountPercentage"] = 0;
            dr["DiscountAmount"] = 0;
            dr["Txn"] = cmbTxn.SelectedValue.ToString().Trim();
            //dr["Department"] = SessionContext.Branch;
            dr["Department"] = 1;
            dr["CreatedOnDate"] = DateTime.Now;
            dr["CreatedBySystemUser"] = SessionContext.SystemUser;
            dr["IsDeleted"] = false;
            dr["ItemCodeFrom"] = txtItemCode.Text;
            dr["ItemNameFrom"] = lblItemName.Text;
            dr["ItemCodeTo"] = txtItemCode.Text;
            dr["ItemNameTo"] = lblItemName.Text;
            dr["DocID"] = "";
            dr["Stage"] = 3;
            dr["Description"] = txtDescription.Text;
            dr["CostAmount"] = WinUtility.Cast(txtAmount.Text, 0.0);


            dsTransaction.Tables[0].Rows.Add(dr);

        }



        protected void lnkUpdate_Click(object sender, System.EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {

                if (WinUtility.Cast(lblQuantityNo.Text, 0.0) >= WinUtility.Cast(txtQuantity.Text, 0.0))
                {
                    if (validateQuantity() == true)
                    {

                        //Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));

                        Save();

                        if (dsTransaction.Tables[0].Rows.Count > 0)
                        {

                            if (transactionBL.Save(dsTransaction))
                            {
                                btnSave.Enabled = false;
                                ClearFields();
                                //EnabledDisabledFields(false, true);
                                btnSearch.Enabled = true;

                                lblMessage.Text = "Trsansaction Save Successufully";
                                lblMessage.ForeColor = Color.Green;
                                lblMessageHeader.Text = "Success";
                                lblMessageHeader.ForeColor = Color.Green;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                            }
                            else
                            {

                                btnSave.Enabled = true;

                                lblMessage.Text = "Trsansaction Failed to Save";
                                lblMessage.ForeColor = Color.Red;
                                lblMessageHeader.Text = "Error";
                                lblMessageHeader.ForeColor = Color.Red;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                            }
                        }
                    }
                }
                else
                {
                    lblMessageHeader.Text = "Error";
                    lblMessageHeader.ForeColor = Color.Red;
                    lblMessage.Text = "Quantity in Stock Less than Quantity Entered";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                }

            }

        }

        private void ClearFields()
        {
            //txtItemNo.Text = "";
            txtItemCode.Text = "";
            txtAmount.Text = "";
            txtQuantity.Text = "";
            txtSPrice.Text = "";
            txtSPrice.Text = "";
            txtIntermod.Text = "";
            txtAssetGL.Text = "";
            lblQuantityNo.Text = "";
            lblItemName.Text = "";
            lblQuantityNo.Text = "0.0";
            //lblBatchQuantity.Text = "0.0";
            //lblBatchQuantityUsed.Text = "0.0";
            txtBranch.Text = "";
            txtDescription.Text = "";
            WinUtility.ItemCode = "";
            cmbDebitGl.SelectedValue = "-1";
            txtIncomeGl.Text = "";
        }


        private Boolean validateQuantity()
        {
            Boolean value = true;
            int QuantityBalance = 0;
            int floatingQuantity = 0;


            if (cmbDebitGl.SelectedValue != "-1")
            {

            }
            else
            {
                lblMessageHeader.Text = "Error";
                lblMessageHeader.ForeColor = Color.Red;
                lblMessage.Text = "Please select Bank / Cash GL";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "initModal", "initModal();", true);

                value = false;
            }




            return value;

        }


        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
           // Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));
        }

        protected void lnkDelete_Click(object sender, System.EventArgs e)
        {
            ControlMappingBL bl = new ControlMappingBL(SessionContext.SystemUser);
            DoDelete(bl);
            if (bl.Save(ds))
                Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));
            
        }

        private void loaddetails(string ItemNo)
        {
            //if (txtItemNo.Enabled != false)
            //{

            //if (txtItemNo.Text != "")
            //{
            ItemBL ItemBL = new ItemBL(0);
            DataSet dsItem = new DataSet();
            ItemBL.FetchForItemCode(dsItem, ItemNo.Trim());
            //ItemBL.FetchForItemsByDepot(dsItem, ItemNo.Trim(), SessionContext.Branch);
            if (dsItem.Tables[0].Rows.Count > 0)
            {
                lblItemName.Text = dsItem.Tables[0].Rows[0]["ItemXX"].ToString();
                txtAssetGL.Text = dsItem.Tables[0].Rows[0]["AssetGL"].ToString();
                txtIntermod.Text = dsItem.Tables[0].Rows[0]["LiabilityGL"].ToString();
                //    txtAssetGL.Text = dsItem.Tables[0].Rows[0]["ExpenseGL"].ToString();
                txtIncomeGl.Text = dsItem.Tables[0].Rows[0]["IncomeGL"].ToString();
                txtBranch.Text = dsItem.Tables[0].Rows[0]["Branch"].ToString();
                txtSPrice.Text = dsItem.Tables[0].Rows[0]["SellingPrice"].ToString();
                //CostPrice = WinUtility.Cast(dsItem.Tables[0].Rows[0]["CurrentPrice"].ToString(), 0.0);
                //BRANCH = dsItem.Tables[0].Rows[0]["BranchCode"].ToString();


                //ITEM_CATEGORY = dsItem.Tables[0].Rows[0]["ItemCategory"].ToString();
                //ITEM_LOCATOR = dsItem.Tables[0].Rows[0]["ItemLocatorCode"].ToString();
                //ITEM_CODE = dsItem.Tables[0].Rows[0]["ItemX"].ToString();
                txtItemCode.Text = dsItem.Tables[0].Rows[0]["ItemX"].ToString();
                //ItemID = WinUtility.Cast(dsItem.Tables[0].Rows[0]["Item"], 0);
                //ICode = txtItemNo.Text.Trim();
                //WinUtility.ItemCode = ICode;
                lblQuantityNo.Text = dsItem.Tables[0].Rows[0]["Quantity"].ToString();


                txtDescription.Text = "SALE OF " + dsItem.Tables[0].Rows[0]["ItemXX"].ToString().ToUpper();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "closeModal", "closeModal();", true);


            }
           
            //EnabledDisabledFields(false, true);


        }



        protected void txtFetch_Click(object sender, EventArgs e)
        {
            BindItemDataGrid("", 0);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindItemDataGrid(txtSearch.Text.Trim(), 0);
        }


        protected void grdItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdItemList.PageIndex = e.NewPageIndex > grdItemList.PageCount ? 0 : e.NewPageIndex;
            BindItemDataGrid(txtSearch.Text.Trim(), e.NewPageIndex);
        }
       
        private void BindItemDataGrid(String Clause, int aPageNumber)
        {
            ItemBL ItemBL = new ItemBL(0);
            DataSet Item = new DataSet();
            //ItemBL.FetchForItems(Item, "%" + Clause + "%");
            ItemBL.FetchForItemsByDepot(Item, "%" + Clause + "%", SessionContext.Branch);





            grdItemList.DataSource = Item.Tables[0].DefaultView;
            grdItemList.DataBind();

            grdItemList.PageIndex = aPageNumber > grdItemList.PageCount ? 0 : aPageNumber;
            SessionContext.GridPage = grdItemList.PageIndex;
            ItemBL = null;
            Item = null;
        }


        private DataTable ImageTable
        {
            get
            {
                if (ViewState["ImageTable"] == null)
                {
                    ViewState["ImageTable"] = GetImageTable();
                }
                return (DataTable)ViewState["ImageTable"];
            }
            set
            {
                ViewState["ImageTable"] = value;
            }
        }


        private DataTable GetImageTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FilePath", typeof(string));
            return dt;
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            DataTable dt = GetImageTable();
            if (FileUpload1.HasFiles)
            {
                foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string filePath = "~/Img/" + fileName;
                    postedFile.SaveAs(Server.MapPath(filePath));

                    DataRow dr = dt.NewRow();
                    dr["FilePath"] = filePath;
                    dt.Rows.Add(dr);
                }
                ImageTable = dt; 
              grdImages.DataSource = dt;
                grdImages.DataBind();
            }
        }

        protected void grdImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectImage")
            {
                string imagePath = e.CommandArgument.ToString();
                SelectedImage.ImageUrl = imagePath;
                SelectedImage.Visible = true;
            }
        }

        //protected void btnDisplay_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload1.HasFiles)
        //    {
        //        imageContainer.Controls.Clear();
        //        foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
        //        {
        //            string fileName = Path.GetFileName(postedFile.FileName);
        //            string filePath = "~/Img/" + fileName;
        //            postedFile.SaveAs(Server.MapPath(filePath));

        //            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image(); // Use fully qualified name
        //            img.ImageUrl = filePath;
        //            img.CssClass = "image-preview";

        //            imageContainer.Controls.Add(img);
        //        }
        //    }
        //}

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload1.HasFiles)
        //    {
        //        foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
        //        {
        //            string fileName = Path.GetFileName(postedFile.FileName);
        //            string savePath = Server.MapPath("~/UploadedImages/") + fileName;
        //            postedFile.SaveAs(savePath);

        //            // Code to save image details to the database can go here, if needed.
        //        }

        //        // Optionally clear the imageContainer after saving
        //        imageContainer.Controls.Clear();
        //    }
        //}

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload1.HasFiles)
        //    {
        //        string savePath = Server.MapPath("~/Images/UploadedImages/");
        //        if (!Directory.Exists(savePath))
        //        {
        //            Directory.CreateDirectory(savePath);
        //        }

        //        foreach (HttpPostedFile file in FileUpload1.PostedFiles)
        //        {
        //            string filename = Path.GetFileName(file.FileName);
        //            string ext = Path.GetExtension(filename);
        //            string seqNo = Guid.NewGuid().ToString(); // Unique identifier for the file

        //            string savePaths = Server.MapPath("~/Images/") + filename;
        //            file.SaveAs(savePaths);

        //            //DataRow dr = dsDocument.Tables[0].NewRow();
        //            //dr["SEQNO"] = seqNo;
        //            //dr["DocumentName"] = filename;
        //            //dr["Path"] = savePaths;
        //            //dsDocument.Tables[0].Rows.Add(dr);
        //        }

        //        lblStatus.Text = "Files uploaded successfully.";
        //    }



        //    else
        //    {
        //        lblStatus.Text = "No files selected.";
        //    }
        //}

        private void SaveFileDetailsToDatabase(string fileName, string fileExtension, string filePath)
        {
            // Implement your database saving logic here
            // Example:
            // string query = "INSERT INTO FileDetails (FileName, FileExtension, FilePath) VALUES (@FileName, @FileExtension, @FilePath)";
            // Use your preferred method to execute the query and save details to the database
        }

        private void SaveImageDataset(string originalImagePath, PictureBox pictureBox)
        {
            // Create a dynamic name for the image
            //string dynamicName = $"Image_{imageCounter}.jpg";
            //imageCounter++;

            string remoteFolderPath = @"C:\\ImageFolder";


            //String SeqNo = "100";

            //DataRow drs = dsDocumnent.Tables[0].NewRow();

            //drs["SEQNO"] = SeqNo;
            //drs["DocumentName"] = Filename;
            //drs["SeqNo"] = SeqNo;
            //drs["Path"] = Path;

            ////drs["Images"] = ImageToByte(pictureBox.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

            //dsDocumnent.Tables[0].Rows.Add(drs);

        }

        private  void documentUpload()
        {

            //documentBL.Save(dsDocumnent);
        }

        //private void SaveFileDetailsToDatabase(string fileName, string fileExtension, string filePath)
        //{
        //    string connectionString = "your_connection_string_here";
        //    string query = "INSERT INTO FileDetails (FileName, FileExtension, FilePath) VALUES (@FileName, @FileExtension, @FilePath)";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@FileName", fileName);
        //            command.Parameters.AddWithValue("@FileExtension", fileExtension);
        //            command.Parameters.AddWithValue("@FilePath", filePath);

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            connection.Close();
        //        }
        //    }
        //}


    }
}





//private void LoadGroup()
//{


//    transactionBL.FetchForApproveDetails(dstransaction, "01917");

//    if (dstransaction.Tables[0].Rows.Count > 0)
//    {


//        grdPosting.DataSource = dstransaction.Tables[0];
//        grdPosting.DataBind();
//    }
//}

//protected void grdPosting_DataBound(object sender, EventArgs e)
//{
//    // Ensure only specified columns are visible
//    for (int i = grdPosting.Columns.Count - 1; i >= 0; i--)
//    {
//        // Check if the column should be visible
//        //bool isVisible = columnsToShow.Contains(grdPosting.Columns[i].SortExpression);
//        //grdPosting.Columns[i].Visible = isVisible;


//        grdPosting.Columns[i].Visible = false;
//    }


//}
