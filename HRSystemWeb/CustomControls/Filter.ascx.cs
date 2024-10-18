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
namespace HRSystemWeb
{
    public partial class Filter : ControlBase
    {
        public delegate void FilterCondition(object sender, string e);
        public event FilterCondition Click;

        public int PageID
        {
            get
            {

                return CargoBag.GetValue("PageID", 0);
            }
            set
            {
                Cargo CargoBag2 = new Cargo(ViewState);
                CargoBag2.SetValue("PageID", value);
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                BindFilterGrid();

            }
        }

        public void RemoveFilter()
        {

            ArrayList ArFilter = new ArrayList();
            ArFilter.Add(new FilterSearchProperties("", "", "", ""));
            grvFilter.DataSource = ArFilter;
            grvFilter.DataBind();
        }

        private void BindFilterCriteriaDropDown(Datatype type, DropDownList drp)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            switch (type)
            {
                case Datatype.String:
                    FillTextFilterCriteria(dt);
                    break;
                case Datatype.Date:
                    FillDateFilterCriteria(dt);

                    break;
                case Datatype.Int:
                    FillNumberFilterCriteria(dt);
                    break;
                case Datatype.Bool:
                    FillBoolFilterCriteria(dt);
                    break;
            }
            WebUtility.FillDropDownList(drp, dt, "Text", "Value");

        }

        private void FillDropDown(DropDownList drp)
        {
            DataSet DSFilter = new DataSet();
            new TableColumnBL(SessionContext.SystemUser).FetchForPage(DSFilter, PageID);
            WebUtility.FillDropDownList(drp, DSFilter.Tables[0], "ColumnX", "ColumnDataType");

        }

        private void FillNumberFilterCriteria(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["Text"] = "Is Less Than";
            dr["Value"] = "<{0}";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "Is Equal To";
            dr["Value"] = "={0}";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "Is Greater Than";
            dr["Value"] = ">{0}";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "Is Not Equal To";
            dr["Value"] = "<>{0}";
            dt.Rows.Add(dr);
        }

        private void FillDateFilterCriteria(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["Text"] = "Is Between";
            dr["Value"] = "Between convert(varchar,'{0}',103) and convert(varchar,'{1}',103)";
            dt.Rows.Add(dr);

        }

        private void FillTextFilterCriteria(DataTable dt)
        {

            DataRow dr;
            dr = dt.NewRow();
            dr["Text"] = "Contains";
            dr["Value"] = "like '%{0}%'";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Text"] = "Does Not Contain";
            dr["Value"] = "not like'%{0}%'";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Text"] = "Is Empty";
            dr["Value"] = "is null";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Text"] = "Is Exactly";
            dr["Value"] = "='{0}'";
            dt.Rows.Add(dr);

        }

        private void FillBoolFilterCriteria(DataTable dt)
        {

            DataRow dr;
            dr = dt.NewRow();
            dr["Text"] = "Yes";
            dr["Value"] = "= 1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Text"] = "No";
            dr["Value"] = "=0";
            dt.Rows.Add(dr);

        }

        public void BindFilterGrid()
        {

            ArrayList ArFilter = new ArrayList();
            FillArraylist(ArFilter);

            ArFilter.Add(new FilterSearchProperties("", "", "", ""));

            grvFilter.DataSource = ArFilter;
            grvFilter.DataBind();
        }

        public void FillArraylist(ArrayList ArFilter)
        {

            foreach (GridViewRow gr in grvFilter.Rows)
            {

                ArFilter.Add(new FilterSearchProperties(((DropDownList)gr.FindControl("ddlColumnName")).SelectedValue,
                   ((DropDownList)gr.FindControl("ddlTextFilterCriteria")).SelectedValue,
                   ((TextBox)gr.FindControl("tbFirstBoxValue")).Text.Trim(),
                   ((TextBox)gr.FindControl("tbSecondBoxValue")).Text.Trim()));
            }
        }

        public string GetWherecondition()
        {
            StringBuilder sbFilterCondition = new StringBuilder();
            string strCol = "";
            foreach (GridViewRow gr in grvFilter.Rows)
            {
                if (sbFilterCondition.ToString() != "")
                {
                    sbFilterCondition.AppendFormat(" and ");
                }
                strCol = (((DropDownList)gr.FindControl("ddlColumnName")).SelectedValue.Replace("1~", "").Replace("2~", "").Replace("3~", "").Replace("4~", "") + " ").ToUpper();
                sbFilterCondition.AppendFormat((strCol.Substring(0, strCol.IndexOf("AS ") > -1 ? strCol.IndexOf("AS ") - 1 : strCol.Length)) + " ");
                sbFilterCondition.AppendFormat(((DropDownList)gr.FindControl("ddlTextFilterCriteria")).SelectedValue, ((TextBox)gr.FindControl("tbFirstBoxValue")).Text.Trim().Replace("'", "''"), ((TextBox)gr.FindControl("tbSecondBoxValue")).Text.Trim().Replace("'", "''"));

            }
            WhereCondition = sbFilterCondition.ToString();
            return sbFilterCondition.ToString();
        }

        public string WhereCondition
        {
            get
            {
                return CargoBag.GetValue("WhereCondition", "");
            }
            set
            {
                CargoBag.SetValue("WhereCondition", value);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindFilterGrid();
        }

        protected void lblApplyFilter_Click(object sender, EventArgs e)
        {
            Click(this, GetWherecondition());
        }

        protected void grvFilter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList drp = (DropDownList)e.Row.FindControl("ddlColumnName");
            if (drp != null)
            {
                FillDropDown(drp);
                WebUtility.SetDropDownListValue(drp, ((Label)e.Row.FindControl("lblColumnName")).Text);
                ddlColumnName_SelectedIndexChanged(drp, null);
            }

        }

        protected void grvFilter_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ArrayList ArFilter = new ArrayList();
            FillArraylist(ArFilter);
            ArFilter.RemoveAt(e.RowIndex);
            grvFilter.DataSource = ArFilter;
            grvFilter.DataBind();

        }

        protected void ddlColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drp = sender as DropDownList;
            String[] value = drp.SelectedValue.Split('~');

                        GridViewRow gr = (GridViewRow)drp.NamingContainer;
            DropDownList ddlTextFilterCriteria = (DropDownList)gr.FindControl("ddlTextFilterCriteria");
            TextBox tbFirstBoxValue = (TextBox)gr.FindControl("tbFirstBoxValue");
            TextBox tbSecondBoxValue = (TextBox)gr.FindControl("tbSecondBoxValue");


            CompareValidator compFirstBoxValue = (CompareValidator)gr.FindControl("compFirstBoxValue");
            CompareValidator compSecondBoxValue = (CompareValidator)gr.FindControl("compSecondBoxValue");
            AjaxControlToolkit.CalendarExtender calstart = (AjaxControlToolkit.CalendarExtender)gr.FindControl("calStartDate");
            
            BindFilterCriteriaDropDown((Datatype)Convert.ToInt16(value[0]), ddlTextFilterCriteria);
            WebUtility.SetDropDownListValue(ddlTextFilterCriteria, ((Label)gr.FindControl("lblFilterCriteria")).Text);


            //tbFirstBoxValue.Text = string.Empty;
            // tbSecondBoxValue.Text = string.Empty;


            tbFirstBoxValue.Visible = true;
            tbSecondBoxValue.Visible = false;
            tbFirstBoxValue.Width = Unit.Pixel(218);

            switch ((Datatype)Convert.ToInt16(value[0]))
            {
                case Datatype.String:
                    compFirstBoxValue.Visible = false;
                    compSecondBoxValue.Visible = false;
                    calstart.Enabled = false;
                    break;
                case Datatype.Date:
                    compFirstBoxValue.Visible = true;
                    compSecondBoxValue.Visible = true;
                    //compFirstBoxValue.Type = ValidationDataType.Date;
                    //compSecondBoxValue.Type = ValidationDataType.Date;
                    //compFirstBoxValue.Text = "<br/>Invalid Date";
                    //compSecondBoxValue.Text = "<br/>Invalid Date";
                    
                    tbFirstBoxValue.Visible = true;
                    tbSecondBoxValue.Visible = true;
                    tbFirstBoxValue.Width = Unit.Pixel(102);
                    tbSecondBoxValue.Width = Unit.Pixel(102);
                    calstart.Enabled = true;
                    break;
                case Datatype.Int:
                    compFirstBoxValue.Type = ValidationDataType.Double;
                    compFirstBoxValue.ControlToValidate = "tbFirstBoxValue";
                    //  compFirstBoxValue.Operator = ValidationCompareOperator.DataTypeCheck;
                    compFirstBoxValue.Text = "<br/>Invalid Value";
                    compFirstBoxValue.Visible = true;
                    compSecondBoxValue.Visible = false;
                    calstart.Enabled = false;
                    break;
                case Datatype.Bool:
                    compFirstBoxValue.Visible = false;
                    compSecondBoxValue.Visible = false;
                    tbFirstBoxValue.Visible = false;
                    calstart.Enabled = false;
                    break;
            }
        }
    }

    public class FilterSearchProperties
    {
        public string ColumnName { get; set; }
        public string FilterCriteria { get; set; }
        public string TextBox1 { get; set; }
        public string TextBox2 { get; set; }

        public FilterSearchProperties()
        {
        }

        public FilterSearchProperties(string _ColumnName, string _FilterCriteria, string _TextBox1, string _TextBox2)
        {

            ColumnName = _ColumnName;
            FilterCriteria = _FilterCriteria;
            TextBox1 = _TextBox1;
            TextBox2 = _TextBox2;

        }

    }
}