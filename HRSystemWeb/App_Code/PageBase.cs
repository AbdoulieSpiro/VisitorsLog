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
using HRSystemWeb;
namespace HRSystemWeb
{
    /// <summary>
    /// 
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// Local Variable Declarations section.........
        /// </summary>
        protected URLMessage URLMessage;
        public string _pageCode;
        protected string PageName;
        protected Cargo CargoBag;
        private bool _RequireAuthentication = true;
        private bool _RequireValidate = true;
        /// <summary>
        /// 
        /// </summary>
        public PageBase()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmptyGridText
        {
            get
            {
                return "No Data Available";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PageCode
        {
            set
            {
                _pageCode = value;
                SessionContext.PageCode = _pageCode;
            }
            get { return _pageCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void LoadTinyMCE()
        {
            LoadTinyMCE("textareas", "advanced");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>
        protected void DisableClick(Button ctrl)
        {
            ctrl.Attributes.Add("onclick", "this.disabled=true;document.body.className='pageBackground';" + ClientScript.GetPostBackEventReference(ctrl, "").ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>
        protected void DisableClick(LinkButton ctrl)
        {
            ctrl.Attributes.Add("onclick", "this.disabled=true;document.body.className='pageBackground';" + ClientScript.GetPostBackEventReference(ctrl, "").ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="theme"></param>
        protected virtual void LoadTinyMCE(string mode, string theme)
        {

            //Load tinyMCE
            HtmlGenericControl Include = new HtmlGenericControl("script");
            Include.Attributes.Add("type", "text/javascript");
            Include.Attributes.Add("src", "../JavaScript/tiny_mce/tiny_mce.js");
            this.Page.Header.Controls.Add(Include);


            //Config MCE

            String strTinyMCE = "\ntinyMCE.init({mode    :   \"" + mode + "\",\n";
            strTinyMCE = strTinyMCE + " theme   :   \"" + theme + "\",\n";
            strTinyMCE = strTinyMCE + " editor_selector :\"mceEditor\",\n";


            strTinyMCE = strTinyMCE + " plugins :  \"safari,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template\",\n";

            // Theme options
            strTinyMCE = strTinyMCE + " theme_advanced_buttons1 : \"bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect\",\n";
            strTinyMCE = strTinyMCE + " theme_advanced_buttons2 : \"cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,code,|,insertdate,inserttime,preview,|,forecolor,backcolor\",\n";
            strTinyMCE = strTinyMCE + " theme_advanced_buttons3 : \"tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen\",\n";
            strTinyMCE = strTinyMCE + " theme_advanced_buttons4 : \"insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak\",\n";
            strTinyMCE = strTinyMCE + " theme_advanced_toolbar_location : \"top\",\n";
            strTinyMCE = strTinyMCE + " theme_advanced_toolbar_align : \"left\",\n";
            strTinyMCE = strTinyMCE + " theme_advanced_statusbar_location : \"bottom\",\n";
            strTinyMCE = strTinyMCE + " theme_advanced_resizing : true,\n";

            // Example content CSS (should be your School CSS)
            strTinyMCE = strTinyMCE + " content_css : \"css/content.css\",\n";

            // Drop lists for link/image/media/template dialogs
            strTinyMCE = strTinyMCE + " template_external_list_url : \"lists/template_list.js\",\n";
            strTinyMCE = strTinyMCE + " external_link_list_url : \"lists/link_list.js\",\n";
            strTinyMCE = strTinyMCE + " external_image_list_url : \"lists/image_list.js\",\n";
            strTinyMCE = strTinyMCE + " media_external_list_url : \"lists/media_list.js\",\n";

            // Replace values for the template plugin
            strTinyMCE = strTinyMCE + " template_replace_values : {\n";
            strTinyMCE = strTinyMCE + "	username : \"Some User\",\n";
            strTinyMCE = strTinyMCE + "	staffid : \"991234\"\n";
            strTinyMCE = strTinyMCE + "}\n";
            strTinyMCE = strTinyMCE + "});\n";
            HtmlGenericControl Include2 = new HtmlGenericControl("script");
            Include2.Attributes.Add("type", "text/javascript");
            //Include2.InnerHtml = "tinyMCE.init({mode : 'textareas' , theme : 'advanced', theme_advanced_buttons1_add : 'fontselect,fontsizeselect', plugins : 'table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,zoom,media,searchreplace,print,contextmenu,paste,directionality,fullscreen',language : 'en',entity_encoding : 'raw'});";
            Include2.InnerHtml = strTinyMCE;

            this.Page.Header.Controls.Add(Include2);

        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string SchoolX
        {
            get { return SessionContext.SiteX; }
        }

        //**********************************************//
        //******* Enable Confirmation ******************//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLinkButton"></param>
        /// <param name="aMessage"></param>
        public void Confirm(System.Web.UI.WebControls.LinkButton aLinkButton, String aMessage)
        {
            aLinkButton.Attributes.Add("onClick", "javascript:return confirm('" + aMessage + "')");

        }
        //**********************************************//
        //******* Enable Confirmation ******************//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aButton"></param>
        /// <param name="aMessage"></param>
        public void Confirm(System.Web.UI.WebControls.Button aButton, String aMessage)
        {
            aButton.Attributes.Add("onClick", "javascript:return confirm('" + aMessage + "')");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLinkButton"></param>
        /// <param name="aMessage"></param>
        public void ConfirmMessage(System.Web.UI.WebControls.LinkButton aLinkButton, String aMessage)
        {
            aLinkButton.Attributes.Add("onClick", "javascript:return alert('" + aMessage + "')");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aImgButton"></param>
        /// <param name="aMessage"></param>
        public void ConfirmAlert(System.Web.UI.WebControls.ImageButton aImgButton, String aMessage)
        {
            aImgButton.Attributes.Add("onClick", "javascript:return alert('" + aMessage + "')");

        }
        //**********************************************//
        //******* Enable Page Printing ******************//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLinkButton"></param>
        /// <param name="aCaption"></param>
        public void Print(System.Web.UI.WebControls.LinkButton aLinkButton, String aCaption)
        {
            aLinkButton.Text = aCaption;
            aLinkButton.Attributes.Add("onClick", "javascript:window.print()");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLinkButton"></param>
        /// <param name="aMessage"></param>
        public void ConfirmMessage(System.Web.UI.WebControls.ImageButton aLinkButton, String aMessage)
        {
            aLinkButton.Attributes.Add("onClick", "javascript:return alert('" + aMessage + "')");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLinkButton"></param>
        /// <param name="aMessage"></param>
        public void Confirm(System.Web.UI.WebControls.ImageButton aLinkButton, String aMessage)
        {
            aLinkButton.Attributes.Add("onClick", "javascript:return confirm('" + aMessage + "')");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPage"></param>
        /// <returns></returns>
        public string TrackIt(string aPage)
        {
            string trackIt = "<script type=\"text/javascript\" src= \"http://" + SessionContext.BaseURL + "/TrackIt/ianalyzer.js\"></script><script type=\"text/javascript\"> trackit(\'" + SessionContext.SiteX + "\', '" + aPage + "'); </script>";
            return trackIt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Page_Load(object sender, System.EventArgs e)
        {

            // License.Validate();
            CargoBag = new Cargo(ViewState);
            Security.SchoolChanged();

            if (SessionContext.SystemUser == -1)
            //Response.Redirect("../Login/Login.aspx?ReturnURL=" + Request.Url.ToString());
            Response.Redirect("~/Login/Login.aspx?ReturnURL=" + Request.Url.ToString());


            //Authenticate User Access if not open to public
            if (User.Identity.IsAuthenticated == false && this.RequireAuthentication)
            {
                //Response.Redirect(@"../Login/Login.aspx?ReturnURL=" + Request.Url.ToString());
                Response.Redirect(@"~/Login/Login.aspx?ReturnURL=" + Request.Url.ToString());
            }

            //Secure Page


            //Secure Page Controls;
            if (!(BasicRoleType.SuperAdministrator == (BasicRoleType)SessionContext.SiteRoleType && this.RequireAuthentication))
            {
                if (Security.SecurePage(this))
                {
                    Response.Redirect(@"~/Issue/RestrictedSecurity.aspx");
                }
                Security.Secure(this);
            }


            URLMessage = new URLMessage();
            this.Title = SessionContext.SiteX + "..:::" + PageName + ":::..";
        }

        private void CheckSetUp()
        {

            switch (SessionContext.SetUpStep)
            {
                case 1:

                    Response.Redirect("..//school//SchoolEdit.aspx");
                    break;
                case 2:

                    Response.Redirect("..//Admin/Class.aspx");
                    break;
                case 3:

                    Response.Redirect("..//Admin/SubjectAddEdit.aspx");
                    break;
                case 4:

                    Response.Redirect("..//AddEditStream.aspx");
                    break;
            }



        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual bool RequireAuthentication
        {
            get { return _RequireAuthentication; }
            set { _RequireAuthentication = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int RowId
        {
            get
            {
                return CargoBag.GetValue("RowId", -1);
            }
            set
            {
                CargoBag.SetValue("RowId", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int ProductId
        {
            get
            {
                return CargoBag.GetValue("ProductId", -1);
            }
            set
            {
                CargoBag.SetValue("ProductId", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int ParentId
        {
            get
            {
                return CargoBag.GetValue("ParentId", -1);
            }
            set
            {
                CargoBag.SetValue("ParentId", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int _School
        {
            get
            {
                return CargoBag.GetValue("_School", -1);
            }
            set
            {
                CargoBag.SetValue("_School", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int FromSchool
        {
            get
            {
                return CargoBag.GetValue("_FromSchool", -1);
            }
            set
            {
                CargoBag.SetValue("_FromSchool", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected string _SearchHintCookie
        {
            get
            {
                return CargoBag.GetValue("_SearchHintCookie", "");
            }
            set
            {
                CargoBag.SetValue("_SearchHintCookie", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int Parent2Id
        {
            get
            {
                return CargoBag.GetValue("Parent2Id", -1);
            }
            set
            {
                CargoBag.SetValue("Parent2Id", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int Parent3Id
        {
            get
            {
                return CargoBag.GetValue("Parent3Id", -1);
            }
            set
            {
                CargoBag.SetValue("Parent3Id", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int Parent6Id
        {
            get
            {
                return CargoBag.GetValue("Parent6Id", -1);
            }
            set
            {
                CargoBag.SetValue("Parent6Id", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int Parent5Id
        {
            get
            {
                return CargoBag.GetValue("Parent5Id", -1);
            }
            set
            {
                CargoBag.SetValue("Parent5Id", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int Parent4Id
        {
            get
            {
                return CargoBag.GetValue("Parent4Id", -1);
            }
            set
            {
                CargoBag.SetValue("Parent4Id", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected int Parent7Id
        {
            get
            {
                return CargoBag.GetValue("Parent7Id", -1);
            }
            set
            {
                CargoBag.SetValue("Parent7Id", value);
            }
        }
        /** this is a special purpose function for handling AJAX actions
         * the action is stored in the Cargo bag for the
         * current page and reterieved when needed
         * */
        protected URLAction urlAction
        {
            get
            {
                string result = "undefined";
                URLAction retval = URLAction.undefined;
                result = CargoBag.GetValue("Action", "undefined");

                switch (result)
                {
                    case "undefined":
                        retval = URLAction.undefined;
                        break;
                    case "create":
                        retval = URLAction.create;
                        break;
                    case "update":
                        retval = URLAction.update;
                        break;
                    case "delete":
                        retval = URLAction.delete;
                        break;
                    case "list":
                        retval = URLAction.list;
                        break;
                }
                return retval;
            }
            set
            {
                string result = "undefined";
                switch (value)
                {
                    case URLAction.undefined:
                        result = "undefined";
                        break;
                    case URLAction.create:
                        result = "create";
                        break;
                    case URLAction.update:
                        result = "update";
                        break;
                    case URLAction.delete:
                        result = "delete";
                        break;
                    case URLAction.list:
                        result = "list";
                        break;
                }
                CargoBag.SetValue("Action", result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected bool EmailThis
        {
            get
            {
                return CargoBag.GetValue("EmailThis", false);
            }
            set
            {
                CargoBag.SetValue("EmailThis", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected String ReturnPage
        {
            get
            {
                return CargoBag.GetValue("ReturnPage", "");
            }
            set
            {
                CargoBag.SetValue("ReturnPage", value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Hashtable DataLog
        {
            get
            {
                if (ViewState["DataLog"] == null)
                {
                    ViewState["DataLog"] = new Hashtable();
                }
                return (Hashtable)ViewState["DataLog"];
            }
            set
            {
                ViewState["DataLog"] = value;
            }
        }
        //*****************************************************//
        // This method is used for exporting any grid to excel //
        // A run-time error occurs if the DataGrid contains any //
        // controls other than the LiteralControl. This means //
        // that enabling Sorting, Paging or adding Template Columnns //
        // or Button columns to the datagrid can cause an error. //
        // There are several approaches to workaround this limitation. //
        // We will remove all the non-Literal controls in the DataGrid //
        // and replace the controls with a text representation , 
        // where possible. To do so, we will make use of Reflection. //
        // instead of querying each type of control and working out //
        // a replacement.//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public void ClearControls(Control control)
        {
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                ClearControls(control.Controls[i]);
            }
            if (!(control is TableCell))
            {
                if (control.GetType().GetProperty("SelectedItem") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    try
                    {
                        literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                    }
                    catch
                    {
                    }
                    control.Parent.Controls.Remove(control);
                }
                else
                    if (control.GetType().GetProperty("Text") != null)
                    {
                        LiteralControl literal = new LiteralControl();
                        control.Parent.Controls.Add(literal);
                        literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                        control.Parent.Controls.Remove(control);
                    }
            }
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public void ExportToCSV(DataTable table)
        {

            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            foreach (DataColumn column in table.Columns)
            {
                context.Response.Write(column.ColumnName + ",");
            }
            context.Response.Write(Environment.NewLine);
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {

                    context.Response.Write((row[i].ToString().Replace(";", string.Empty)).Replace("\r\n", string.Empty) + ";");
                }
                context.Response.Write(Environment.NewLine);
            }
            table = null;
            context.Response.ContentType = "text/csv";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=export.csv");
            context.Response.End();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {

            try
            {
                base.OnPreInit(e);

                // Simply use the School theme
                //Page.Theme = SessionContext.Theme;

                //if (SessionContext.Theme.ToLower() == "hrgray")
                //{

                //    Page.MasterPageFile = "~/MasterPageGray.master";
                //}
                //else
                //{
                    Page.MasterPageFile = "~/MasterPage.master";
                //}

                this.Title = "..:::" + PageName + ":::..";

            }

            catch { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetBaseURL()
        {
            return HttpContext.Current.Request.Url.Authority.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual bool RequireValidate
        {
            get { return _RequireValidate; }
            set { _RequireValidate = value; }
        }


        protected void InsertSelect(DropDownList drp)
        {
            drp.Items.Insert(0, new ListItem("Select", "-1"));
        }

    }
}
