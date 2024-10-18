using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using HRSystemServer.BusinessLayer;
using HRSystemServer.DataLayer;
using System.Text;
using AjaxControlToolkit;

namespace HRSystemWeb
{
    public partial class Pagger : ControlBase
    {
        public delegate void PaggerClick(object sender, PaggerClickEventArgs e);
        public event PaggerClick Click;


        Cargo CargoBag1;

        public int PageCount
        {
            get
            {
                return CargoBag.GetValue("Pages", 0);
            }
            set
            {
                Cargo CargoBag1 = new Cargo(ViewState);
                CargoBag1.SetValue("Pages", value);
            }
        }

        public int PageID
        {
            get
            {

                return CargoBag.GetValue("PageID", 0);
            }
            set
            {
                Cargo CargoBag1 = new Cargo(ViewState);
                CargoBag1.SetValue("PageID", value);
            }
        }

        public string Search
        {
            get
            {
                return CargoBag.GetValue("Search", "");
            }
            set
            {
                CargoBag.SetValue("Search", value);
            }

        }

        public string Columns
        {
            get
            {
                return GetColumns(false);
            }
        }

        public int PageSize
        {
            get
            {
                return CargoBag.GetValue("PageSize", 100);
            }
            set
            {
                CargoBag.SetValue("PageSize", value);
            }
        }
        public int CurrentPageIndex
        {
            get
            {
                return CargoBag.GetValue("CurrentPageIndex", 0);
            }
            set
            {
                CargoBag.SetValue("CurrentPageIndex", value);
            }
        }

        public bool FilterButtonClicked
        {
            get
            {
                return CargoBag.GetValue("FilterButtonClicked", false);
            }
            set
            {
                CargoBag.SetValue("FilterButtonClicked", value);
            }
        }


        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                FillDropDown();
                lblPages.Text = string.Format("Page {0} Of {1}", "1", PageCount.ToString());
                BindRepeater();
                VisibleButton();
            }

        }


        private void BindRepeater()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Page");
            dt.Columns.Add("PageX");
            DataRow dr;
            for (int i = 1; i <= PageCount; i++)
            {
                dr = dt.NewRow();
                dr["PageX"] = "Page " + i.ToString();
                dr["Page"] = i.ToString();
                dt.Rows.Add(dr);
            }
            rptPages.DataSource = dt;
            rptPages.DataBind();
        }


        private void FillDropDown()
        {
            DataSet DSFilter = new DataSet();
            new TableColumnBL(SessionContext.SystemUser).FetchForPage(DSFilter, PageID);
            grdColumns.DataSource = DSFilter;
            grdColumns.DataBind();
        }


        public string GetColumns(bool isForWhereCondition)
        {
            StringBuilder sb = new StringBuilder();
            string strCol = "";
            foreach (GridViewRow GR in grdColumns.Rows)
            {

                if (((CheckBox)GR.FindControl("chk")).Checked)
                {
                    if (sb.ToString() != "")
                    {
                        sb.Append(" , ");
                    }

                    if (isForWhereCondition)
                    {
                        strCol = ((Label)GR.FindControl("lblColumn")).Text.ToUpper();
                        sb.Append(strCol.Substring(0, strCol.IndexOf("AS ") > -1 ? strCol.IndexOf("AS ") - 1 : strCol.Length));
                    }
                    else
                    {
                        if (((Label)GR.FindControl("lblType")).Text =="2") 
                        {
                            sb.Append("convert(varchar," + ((Label)GR.FindControl("lblColumn")).Text + ",103) AS " + ((Label)GR.FindControl("lblColumnX")).Text);
                        }
                        else
                        {
                            sb.Append(((Label)GR.FindControl("lblColumn")).Text);
                        }
                    }
                }
            }
            return sb.ToString();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //lblPages.Text = string.Format("Page {0} Of {1}", "1", PageCount.ToString());
           // VisibleButton();
            FireEvent();
        }

        protected void btnAddFilter_Click(object sender, EventArgs e)
        {
            if (btnAddFilter.CommandName == "add")
            {
                btnAddFilter.CommandName = "remove";
                btnAddFilter.Text = "Remove Filter";
                FilterButtonClicked = true;
            }
            else
            {
                btnAddFilter.CommandName = "add";
                btnAddFilter.Text = "Add Filter";
                FilterButtonClicked = false;
            }
            FireEvent();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Search = txtSearch.Text.Trim();
            FireEvent();
        }

        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "pageclick")
                CurrentPageIndex = Convert.ToInt32(e.CommandArgument) - 1;
            VisibleButton();

            lblPages.Text = string.Format("Page {0} Of {1}", CurrentPageIndex + 1, PageCount.ToString());
            FireEvent();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            PageSize = Convert.ToInt32(lnk.Text);
            FireEvent();
        }

        private void FireEvent()
        {
            Click(this, new PaggerClickEventArgs(Search, Columns, PageSize, CurrentPageIndex, FilterButtonClicked));
        }

        protected void imgPre_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = CurrentPageIndex - 1;
            lblPages.Text = string.Format("Page {0} Of {1}", CurrentPageIndex + 1, PageCount.ToString());
            VisibleButton();
            FireEvent();
        }

        protected void imgnext_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = CurrentPageIndex + 1;
            lblPages.Text = string.Format("Page {0} Of {1}", CurrentPageIndex + 1, PageCount.ToString());
            VisibleButton();
            FireEvent();
        }

        private void VisibleButton()
        {
            if (PageCount == 1)
            {
                imgPre.Enabled = false;
                imgnext.Enabled = false;
            }
            else if (CurrentPageIndex == 0)
            {
                imgPre.Enabled = false;
                imgnext.Enabled = true;
            }
            else if (CurrentPageIndex + 1 == PageCount)
            {
                imgnext.Enabled = false;
                imgPre.Enabled = true;
            }
            else
            {
                imgnext.Enabled = true;
                imgPre.Enabled = true;
            }
        }
    }

    public class PaggerClickEventArgs : System.EventArgs
    {
        public string Search { get; set; }
        public string Columns { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageIndex { get; set; }
        public bool FilterButtonClicked { get; set; }

        public PaggerClickEventArgs()
        {
        }
        public PaggerClickEventArgs(string _Search, string _Columns, int _PageSize, int _CurrentPageIndex, bool _FilterButtonClicked)
        {
            Search = _Search;
            Columns = _Columns;
            PageSize = _PageSize;
            CurrentPageIndex = _CurrentPageIndex;
            FilterButtonClicked = _FilterButtonClicked;
        }
    }
}