namespace HRSystemWeb
{
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
    using OboutInc.Flyout2;
    using OboutInc.EasyMenu_Pro;
    /// <summary>
    ///		Summary description for menucontrol.
    /// </summary>
    public partial class LoginMenu : System.Web.UI.UserControl
    {

        protected EasyMenu mainEM;
        protected EasyMenu em_1;
        protected EasyMenu em_2;
        protected EasyMenu em_4;
        protected EasyMenu em_5;
        protected EasyMenu em_6;
        private HRSystemServer.UPSLayer.Secure secure = new HRSystemServer.UPSLayer.Secure("^%&*()JUHtg43@!~$9lLKo)(", "(*&^y54$#EWEd3@!0(8Mk)(*");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    mainEM = new EasyMenu();
            //    // set the ID (must be unique)
            //    mainEM.ID = "MainEM";

            //    // add the menu to the placeholder on the page
            //    placeHolder1.Controls.Add(mainEM);

            //    // Create the submenus
            //    em_1 = new EasyMenu();
            //    em_1.ID = "Easymenu1";

            //    em_2 = new EasyMenu();
            //    em_2.ID = "Easymenu2";

            //    em_4 = new EasyMenu();
            //    em_4.ID = "Easymenu4";

            //    em_5 = new EasyMenu();
            //    em_5.ID = "Easymenu5";

            //    em_6 = new EasyMenu();
            //    em_6.ID = "Easymenu6";
            //    mainEM.StyleFolder = "styles/horizontal1";
            //    mainEM.Width = "60%";
            //    // show event is always so the menu is always visible
            //    // this menu doesn't require any AttachTo or Align properties set
            //    mainEM.ShowEvent = MenuShowEvent.Always;
            //    // display the menu horizontally
            //    mainEM.Position = MenuPosition.Horizontal;
            //    // the parent menu looks different so we need to set different
            //    // CSS classes names for its items and the menu itself
            //    // css classes names for the menu and the Itemcontainer
            //    mainEM.CSSMenu = "ParentMenu";
            //    mainEM.CSSMenuItemContainer = "ParentItemContainer";
            //    // css classes names for MenuItems
            //    CSSClasses MenuItemCssClasses = mainEM.CSSClassesCollection[mainEM.CSSClassesCollection.Add(new CSSClasses(typeof(OboutInc.EasyMenu_Pro.MenuItem)))];
            //    MenuItemCssClasses.ComponentSubMenuCellOver = "ParentItemSubMenuCellOver";
            //    MenuItemCssClasses.ComponentContentCell = "ParentItemContentCell";
            //    MenuItemCssClasses.Component = "ParentItem";
            //    MenuItemCssClasses.ComponentSubMenuCell = "ParentItemSubMenuCell";
            //    MenuItemCssClasses.ComponentIconCellOver = "ParentItemIconCellOver";
            //    MenuItemCssClasses.ComponentIconCell = "ParentItemIconCell";
            //    MenuItemCssClasses.ComponentOver = "ParentItemOver";
            //    MenuItemCssClasses.ComponentContentCellOver = "ParentItemContentCellOver";
            //    // add the classes names to the collection
            //    mainEM.CSSClassesCollection.Add(MenuItemCssClasses);
            //    // css classes names for MenuSeparators
            //    CSSClasses MenuSeparatorCssClasses = mainEM.CSSClassesCollection[mainEM.CSSClassesCollection.Add(new CSSClasses(typeof(OboutInc.EasyMenu_Pro.MenuSeparator)))];
            //    MenuSeparatorCssClasses.ComponentSubMenuCellOver = "ParentSeparatorSubMenuCellOver";
            //    MenuSeparatorCssClasses.ComponentContentCell = "ParentSeparatorContentCell";
            //    MenuSeparatorCssClasses.Component = "ParentSeparator";
            //    MenuSeparatorCssClasses.ComponentSubMenuCell = "ParentSeparatorSubMenuCell";
            //    MenuSeparatorCssClasses.ComponentIconCellOver = "ParentSeparatorIconCellOver";
            //    MenuSeparatorCssClasses.ComponentIconCell = "ParentSeparatorIconCell";
            //    MenuSeparatorCssClasses.ComponentOver = "ParentSeparatorOver";
            //    MenuSeparatorCssClasses.ComponentContentCellOver = "ParentSeparatorContentCellOver";
            //    // add the classes names to the collection
            //    mainEM.CSSClassesCollection.Add(MenuSeparatorCssClasses);
            //    // add the items for the menu
            //    mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Home", "Home", "~/Home/Home.aspx", "", "", "", true));
            //    mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Student", "Student", "", "", "", ""));
            //    mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("School", "School", "", "", "", ""));
            //    mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Security", "Security", "", "", "", ""));
            //    mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("ChangePassword", "Change Password", "", "", "", ""));
            //    placeHolder1.Controls.Add(mainEM);
            //    // Create the submenus
            //    // this will attach to the first Itemof the parent menu (id=item1)
            //    em_1.AttachTo = "Student";
            //    em_1.StyleFolder = "styles/horizontal1";
            //    em_1.Width = "140";
            //    // it will show on mouse over
            //    em_1.ShowEvent = MenuShowEvent.MouseOver;
            //    // and will align under the Itemto which it is attached
            //    em_1.Align = MenuAlign.Under;
            //    // here are this menu's items
            //    em_1.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Home", "Registration", "", "", ""));
            //    em_1.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Home", "Admission", "", "", ""));
            //    em_2.AttachTo = "School";
            //    em_2.StyleFolder = "styles/horizontal1";
            //    em_2.Width = "140";
            //    em_2.ShowEvent = MenuShowEvent.MouseOver;
            //    em_2.Align = MenuAlign.Under;
            //    em_2.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("SchoolList", "School List", "", "", ""));
            //    em_4.AttachTo = "Security";
            //    em_4.StyleFolder = "styles/horizontal1";
            //    em_4.Width = "140";
            //    em_4.ShowEvent = MenuShowEvent.MouseOver;
            //    em_4.Align = MenuAlign.Under;
            //    em_4.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("SystemUser", "System User", "", "", ""));
            //    em_4.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("PageMapping", "Page Mapping", "", "", ""));
            //    em_4.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("SystemRoleType", "System Role Type", "", "", ""));

            //    // and so on for every submenu

            //    placeHolder1.Controls.Add(em_1);
            //    placeHolder1.Controls.Add(em_2);
            //    placeHolder1.Controls.Add(em_4);

            //}
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
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {




            this.PreRender += new System.EventHandler(this.MenuControl_PreRender);





        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public virtual string SchoolStyleSheet
        {
            get { return SessionContext.SiteStyleSheet; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MenuControl_PreRender(object sender, System.EventArgs e)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializeMenu()
        {

        }
        //    URLMessage URLMessage = new URLMessage();
        //    // create the Parent EasyMenu
        //    EasyMenu mainEM = new EasyMenu();
        //    // set the ID (must be unique)
        //    mainEM.ID = "MainEM";
        //    // set the style for this menu
        //    mainEM.StyleFolder = "styles/horizontal1";

        //    if (SessionContext.SuperAdministrator)
        //    {
        //        mainEM.Width = "100%";
        //        // mainEM.Width = (mainEM.Components.Count * 100)+"20px";
        //    }
        //    else
        //    {
        //        mainEM.Width = "90%";
        //        // mainEM.Width = (mainEM.Components.Count * 100)+"20px";
        //    }

        //    // show event is always so the menu is always visible
        //    // this menu doesn't require any AttachTo or Align properties set
        //    mainEM.ShowEvent = MenuShowEvent.Always;
        //    // display the menu horizontally
        //    mainEM.Position = MenuPosition.Horizontal;

        //    // the parent menu looks different so we need to set different
        //    // CSS classes names for its items and the menu itself

        //    // css classes names for the menu and the Itemcontainer
        //    mainEM.CSSMenu = "ParentMenu";
        //    mainEM.CSSMenuItemContainer = "ParentItemContainer";
        //    // css classes names for MenuItems
        //    CSSClasses MenuItemCssClasses = mainEM.CSSClassesCollection[mainEM.CSSClassesCollection.Add(new CSSClasses(typeof(OboutInc.EasyMenu_Pro.MenuItem)))];
        //    MenuItemCssClasses.ComponentSubMenuCellOver = "ParentItemSubMenuCellOver";
        //    MenuItemCssClasses.ComponentContentCell = "ParentItemContentCell";
        //    MenuItemCssClasses.Component = "ParentItem";
        //    MenuItemCssClasses.ComponentSubMenuCell = "ParentItemSubMenuCell";
        //    MenuItemCssClasses.ComponentIconCellOver = "ParentItemIconCellOver";
        //    MenuItemCssClasses.ComponentIconCell = "ParentItemIconCell";
        //    MenuItemCssClasses.ComponentOver = "ParentItemOver";
        //    MenuItemCssClasses.ComponentContentCellOver = "ParentItemContentCellOver";
        //    // add the classes names to the collection
        //    mainEM.CSSClassesCollection.Add(MenuItemCssClasses);
        //    // css classes names for MenuSeparators
        //    CSSClasses MenuSeparatorCssClasses = mainEM.CSSClassesCollection[mainEM.CSSClassesCollection.Add(new CSSClasses(typeof(MenuSeparator)))];
        //    MenuSeparatorCssClasses.ComponentSubMenuCellOver = "ParentSeparatorSubMenuCellOver";
        //    MenuSeparatorCssClasses.ComponentContentCell = "ParentSeparatorContentCell";
        //    MenuSeparatorCssClasses.Component = "ParentSeparator";
        //    MenuSeparatorCssClasses.ComponentSubMenuCell = "ParentSeparatorSubMenuCell";
        //    MenuSeparatorCssClasses.ComponentIconCellOver = "ParentSeparatorIconCellOver";
        //    MenuSeparatorCssClasses.ComponentIconCell = "ParentSeparatorIconCell";
        //    MenuSeparatorCssClasses.ComponentOver = "ParentSeparatorOver";
        //    MenuSeparatorCssClasses.ComponentContentCellOver = "ParentSeparatorContentCellOver";
        //    // add the classes names to the collection
        //    mainEM.CSSClassesCollection.Add(MenuSeparatorCssClasses);
        //    // add the items for the menu
        //    //MenuBL bl = new MenuBL(SessionContext.SystemUser);
        //    //DataSet ds = new DataSet();
        //    //MenuItemBL menuitems = new MenuItemBL(SessionContext.SystemUser);
        //    //DataSet menuds;
        //    //// Button btn;
        //    //int i = 0;
        //    //int j = 0;
        //    //bl.FetchPublishedForSchool(ds, SessionContext.Site);
        //   EasyMenu em;
        //    //mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("home", "Home", "", "~/Home/Home.aspx"));
        //    //foreach (DataRow dr in ds.Tables[0].Rows)
        //    //{
        //    //    i = i + 1;
        //    //    mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("item" + i, dr["MenuX"].ToString(), "", "", "", ""));
        //    //    menuds = new DataSet();
        //    //    if (Page.User.Identity.IsAuthenticated)
        //    //    {
        //    //        menuitems.FetchPublishedForMenu(menuds, int.Parse(dr["Menu"].ToString()));
        //    //    }
        //    //    else
        //    //    {
        //    //        menuitems.FetchPublicForMenu(menuds, (int)dr["Menu"]);
        //    //    }
        //    //    j = 0;
        //    //    if (menuds.Tables[0] != null)
        //    //    {
        //    //        em = new EasyMenu();
        //    //        em.ID = "em" + i + j;
        //    //        em.AttachTo = "item" + i;
        //    //        em.StyleFolder = "styles/horizontal1";
        //    //        em.Width = "160";
        //    //        // it will show on mouse over
        //    //        em.ShowEvent = MenuShowEvent.MouseOver;
        //    //        // and will align under the Itemto which it is attached
        //    //        em.Align = MenuAlign.Under;
        //    //        foreach (DataRow items in menuds.Tables[0].Rows)
        //    //        {
        //    //            j = j + 1;
        //    //            // Display Web Page Link
        //    //            if (WebUtility.Cast(items["IsInternalLink"], false))
        //    //            {
        //    //                string aLink = "~/School/InternalLinkView.aspx?" + secure.EncryptTripleDES("action=view&InternalLink=" + items["InternalLink"]);
        //    //                em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", aLink, "", ""));
        //    //            }
        //    //            // Display External Page Link
        //    //            //else if (WebUtility.Cast(items["IsExternalLink"], false))
        //    //            //{
        //    //            //    ExternalLinkBL external_bl = new ExternalLinkBL(SessionContext.SystemUser);
        //    //            //    DataSet external_ds = new DataSet();
        //    //            //    external_bl.Fetch(external_ds, (int)items["ExternalLink"]);
        //    //            //    if (external_ds != null && external_ds.Tables[0].Rows.Count > 0)
        //    //            //    {
        //    //            //        string aLink = external_ds.Tables[0].Rows[0]["URL"].ToString();
        //    //            //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", aLink, "_blank", ""));
        //    //            //    }
        //    //            //}
        //    //            /** Module **/
        //    //            else if (WebUtility.Cast(items["IsModule"], false))
        //    //            {
        //    //                switch (items["Module"].ToString())
        //    //                {
        //    //                    case "Blogs":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Blog/BlogSearch.aspx", "", ""));
        //    //                        break;
        //    //                    case "Catalog":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Catalog/CatalogHome.aspx", "", ""));
        //    //                        break;
        //    //                    case "Content Library":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Content/ContentSearch.aspx", "", ""));
        //    //                        break;
        //    //                    case "Donation":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Donation/DonorDetails.aspx?" + URLMessage.Encrypt("action=Create&DonationDrive=13&DonationCause=19"), "", ""));
        //    //                        break;
        //    //                    case "Events":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Conference/ConferenceList.aspx", "", ""));
        //    //                        break;
        //    //                    case "Feedback":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Feedback/FeedbackEdit.aspx", "", ""));
        //    //                        break;
        //    //                    case "Forum":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Forum/ForumList.aspx", "", ""));
        //    //                        break;
        //    //                    case "Job Bank":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Job/JobList.aspx", "", ""));
        //    //                        break;
        //    //                    case "Photo Gallery":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Album/AlbumDisplay.aspx", "", ""));
        //    //                        break;
        //    //                    case "Member Registration":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/Membership/MembershipIndividual.aspx?" + URLMessage.Encrypt("action=create&MembershipType=1"), "", ""));
        //    //                        break;
        //    //                    case "Member Search":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/SystemUser/SchoolUserPublicSearch.aspx", "", ""));
        //    //                        break;
        //    //                    case "News":
        //    //                        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", "~/News/NewsSearch.aspx", "", ""));
        //    //                        break;
        //    //                }
        //    //            }
        //    /*** Section ***/
        //    //else if (WebUtility.Cast(items["IsSection"], false))
        //    //{
        //    //    SectionBL sectionbl = new SectionBL(SessionContext.SystemUser);
        //    //    DataSet sectionds = new DataSet();
        //    //    SectionCategoryBL categorybl = new SectionCategoryBL(SessionContext.SystemUser);
        //    //    DataSet categoryds;
        //    //    sectionbl.Fetch(sectionds, WebUtility.Cast(items["Section"], 0));
        //    //    if (sectionds != null && sectionds.Tables[0].Rows.Count > 0)
        //    //    {
        //    //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("section" + i + j, items["MenuItemX"].ToString(), "", "", "", ""));
        //    //        int k = 0;
        //    //        categoryds = new DataSet();
        //    //        categorybl.FetchForSection(categoryds, WebUtility.Cast(items["Section"], 0));
        //    //        if (categoryds != null && categoryds.Tables[0].Rows.Count > 0)
        //    //        {
        //    //            EasyMenu em_category = new EasyMenu();
        //    //            em_category.ID = "category" + i + j + k;
        //    //            em_category.AttachTo = "section" + i + j;
        //    //            em_category.StyleFolder = "styles/horizontal1";
        //    //            em_category.Width = "160";
        //    //            em_category.ShowEvent = MenuShowEvent.MouseOver;
        //    //            em_category.Align = MenuAlign.Right;
        //    //            foreach (DataRow categoryItemin categoryds.Tables[0].Rows)
        //    //            {
        //    //                k = k + 1;
        //    //                em_category.AddSeparator("category_sep" + i + j + k, "<b>" + categoryitem["SectionCategoryX"].ToString() + "</b>");
        //    //                InternalLinkBL linkbl = new InternalLinkBL(SessionContext.SystemUser);
        //    //                DataSet linkds = new DataSet();
        //    //                linkbl.FetchForCategory(linkds, WebUtility.Cast(categoryitem["SectionCategory"], 0));
        //    //                int l = 0;
        //    //                if (linkds != null && linkds.Tables[0].Rows.Count > 0)
        //    //                {
        //    //                    foreach (DataRow link in linkds.Tables[0].Rows)
        //    //                    {
        //    //                        l = l + 1;
        //    //                        string aLink = "~/School/InternalLinkView.aspx?" + secure.EncryptTripleDES("action=view&InternalLink=" + link["InternalLink"]);
        //    //                        string aTarget = (bool)link["OpenInNewWindow"] ? "_blank" : "";
        //    //                        em_category.AddMenuItem("category_link" + i + j + k + l, link["InternalLinkX"].ToString(), "", aLink, aTarget, "");
        //    //                    }
        //    //                    linkbl = null;
        //    //                    linkds = null;
        //    //                }
        //    //            }
        //    //            categoryds = null;
        //    //            categorybl = null;
        //    //            placeHolder1.Controls.Add(em_category);
        //    //        }
        //    //    }
        //    //    sectionds = null;
        //    //    sectionbl = null;
        //    //} /*** Section Category ***/
        //    //else if (WebUtility.Cast(items["IsCategory"], false))
        //    //{
        //    //    em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("category" + i + j, items["MenuItemX"].ToString(), "", "", "", ""));
        //    //    InternalLinkBL linkbl = new InternalLinkBL(SessionContext.SystemUser);
        //    //    DataSet linkds = new DataSet();
        //    //    linkbl.FetchForCategory(linkds, WebUtility.Cast(items["Category"], 0));
        //    //    int k = 0;
        //    //    if (linkds != null && linkds.Tables[0].Rows.Count > 0)
        //    //    {
        //    //        EasyMenu em_category = new EasyMenu();
        //    //        em_category.ID = "category" + i + j + k;
        //    //        em_category.AttachTo = "category" + i + j;
        //    //        em_category.StyleFolder = "styles/horizontal1";
        //    //        em_category.Width = "160";
        //    //        em_category.ShowEvent = MenuShowEvent.MouseOver;
        //    //        em_category.Align = MenuAlign.Right;
        //    //        foreach (DataRow link in linkds.Tables[0].Rows)
        //    //        {
        //    //            k = k + 1;
        //    //            string aLink = "~/School/InternalLinkView.aspx?" + secure.EncryptTripleDES("action=view&InternalLink=" + link["InternalLink"]);
        //    //            string aTarget = (bool)link["OpenInNewWindow"] ? "_blank" : "";
        //    //            em_category.AddMenuItem("category_link" + i + j + k, link["InternalLinkX"].ToString(), "", aLink, aTarget, "");
        //    //        }
        //    //        linkbl = null;
        //    //        linkds = null;
        //    //        placeHolder1.Controls.Add(em_category);
        //    //    }
        //    //}
        //    //    else
        //    //    {
        //    //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("menuItem" + i + j, items["MenuItemX"].ToString(), "", items["Link"].ToString(), "", ""));
        //    //    }
        //    //}
        //    //placeHolder1.Controls.Add(em);
        //    //}
        //    if (SessionContext.SiteAdministrator)
        //    {
        //        mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Schooladmin", "School Admin.", "", "", "", ""));
        //        em = new EasyMenu();
        //        em.ID = "em_Schooladmin";
        //        em.AttachTo = "Schooladmin";
        //        em.StyleFolder = "styles/horizontal1";
        //        em.Width = "140";
        //        // it will show on mouse over
        //        em.ShowEvent = MenuShowEvent.MouseOver;
        //        // and will align under the Itemto which it is attached
        //        em.Align = MenuAlign.Under;
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("School", "Manage School", "", "~/School/SchoolList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("reports", "Reports", "", "~/Report/ReportList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("massemail", "Mass Email", "", "~/SMTP/SMTPList.aspx", "", ""));
        //        placeHolder1.Controls.Add(em);
        //    }
        //    if (SessionContext.SuperAdministrator)
        //    {
        //        mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("superadmin", "Super Admin.", "", "", "", ""));
        //        em = new EasyMenu();
        //        em.ID = "em_superadmin";
        //        em.AttachTo = "superadmin";
        //        em.StyleFolder = "styles/horizontal1";
        //        em.Width = "160";
        //        // it will show on mouse over
        //        em.ShowEvent = MenuShowEvent.MouseOver;
        //        // and will align under the Itemto which it is attached
        //        em.Align = MenuAlign.Under;
        //        em.AddSeparator("superadmin_sep1", "<b>System Maangement</b>");
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("association", "Clients", "", "~/Association/AssociationList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("industry", "Industry", "", "~/Industry/IndustryList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("country", "Country", "", "~/Country/CountryList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("state", "States", "", "~/State/StateList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("zip", "Zip Code", "", "~/ZipCode/ZipCodeList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("taxcategory", "TAX Category", "", "~/TaxCategory/TaxCategoryList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("statetaxrate", "State Tax Rate", "", "~/StateTaxRate/StateTaxRateList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("paymenttype", "Payment Type", "", "~/PaymentType/PaymentTypeList.aspx", "", ""));
        //        em.AddSeparator("superadmin_sep2", "<b>Security Mangement</b>");
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Rolepagemapping", "Role", "", "~/PageMapping/RolePageMappingList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("pagemapping", "Page Mapping", "", "~/PageMapping/PageMappingList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("securityprofile", "Security Profile", "", "~/SecurityProfile/SecurityProfileList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("systemroletype", "System Roletype", "", "~/SystemRoleType/SystemRoleTypeList.aspx", "", ""));
        //        em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("systemuser", "System User", "", "~/SystemUser/SystemUserList.aspx", "", ""));
        //        placeHolder1.Controls.Add(em);
        //    }
        //    //if (SessionContext.IsAuthor || SessionContext.IsPublisher)
        //    //{
        //    //    mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("Schooladmin", "DashBoard", "", "", "", ""));

        //    //    em = new EasyMenu();
        //    //    em.ID = "em_Schooladash";
        //    //    em.AttachTo = "Schooladmin";
        //    //    em.StyleFolder = "styles/horizontal1";
        //    //    em.Width = "140";
        //    //    // it will show on mouse over
        //    //    em.ShowEvent = MenuShowEvent.MouseOver;
        //    //    // and will align under the Itemto which it is attached
        //    //    em.Align = MenuAlign.Under;

        //    //    em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("School", "DashBoard", "", "~/School/SchoolDashBoard.aspx", "", ""));
        //    //    //em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("reports", "Reports", "", "~/Report/ReportList.aspx", "", ""));
        //    //    //em.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("massemail", "Mass Email", "", "~/SMTP/SMTPList.aspx", "", ""));
        //    //    placeHolder1.Controls.Add(em);
        //    //}

        //    /** Add LOGIN/LOGOUT Button **/
        //    if (Page.User.Identity.IsAuthenticated)
        //    {
        //        if (SessionContext.IsPrimaryUser)
        //        {
        //            URLMessage = new URLMessage();
        //            mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("myAccount", "My Account", "", "~/SystemUser/SystemUserView.aspx?" + URLMessage.Encrypt("SystemUser=" + SessionContext.SystemUser)));
        //            URLMessage = null;
        //        }
        //        mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("SignOut", "Sign-Out", "", "~/Login/Logout.aspx", "", ""));
        //        lblGreeting.Text = SessionContext.SystemUserX;
        //    }
        //    else
        //    {
        //        mainEM.AddItem(new OboutInc.EasyMenu_Pro.MenuItem("SignIn", "Sign-In", "", "~/Login/Login.aspx", "", ""));
        //    }
        //    placeHolder1.Controls.Add(mainEM);
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }

        protected void lnkThemeChange_Click(object sender, EventArgs e)
        {

            SessionContext.Theme = "SMS";
            Response.Redirect(Request.RawUrl);
        }
    }
}
