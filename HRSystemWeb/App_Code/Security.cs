using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Reflection;
using System.Web.Security;
using HRSystemServer.BusinessLayer;

namespace HRSystemWeb
{

    // This class is reposible for  security of the application
    // Created By Shameem Shah
    // Modified By Ashraf Ganie
    // To support Security in .net 2005 I have made some changes in code.
    /// <summary>
    /// 
    /// </summary>

    public class Security
    {
        //****************************************************
        //****************************************************
        private Security()
        {
        }
        //****************************************************
        //****************************************************
        public static string GetBaseURL()
        {
            return HttpContext.Current.Request.Url.Authority.ToString();
        }
        //****************************************************
        //****************************************************
        public static void Logout(Page aPage)
        {
            SessionContext.Logout();
        }

        //****************************************************
        //****************************************************
        public static void Login(string ReturnURL)
        {
            HttpContext.Current.Response.Redirect(@"../Login/Login.aspx?ReturnURL=" + ReturnURL);
        }
        //****************************************************
        //****************************************************
        /// <summary>
        /// 
        /// </summary>
        public static void SchoolChanged()
        {
            string baseURL = GetBaseURL();
            if (SessionContext.BaseURL == baseURL)
            {
                return;
            }
            DataSet ds = new DataSet();
            SiteBL bl = new SiteBL(0);
            bl.FetchForBaseURL(ds, baseURL);
            if (ds.Tables[0].Rows.Count > 0)
            {

                SessionContext.SiteRoleType = int.Parse(ds.Tables[0].Rows[0]["DefaultSiteRoleType"].ToString());
                SessionContext.SecurityProfile = int.Parse(ds.Tables[0].Rows[0]["DefaultSiteRoleType"].ToString());
                SessionContext.Site = int.Parse(ds.Tables[0].Rows[0]["Site"].ToString());
                SessionContext.BaseURL = ds.Tables[0].Rows[0]["BaseURL"].ToString();
                SessionContext.SiteLogoFileName = ds.Tables[0].Rows[0]["LogoFileName1"].ToString();
                SessionContext.Theme = ds.Tables[0].Rows[0]["Theme"].ToString();
                SessionContext.SiteX = ds.Tables[0].Rows[0]["SiteX"].ToString();
                
                SessionContext.IsOpenToPublic = false;
            }
        }
        //****************************************************
        //****************************************************
        //Secure Page For Security Profile and Page Name for current School

        public static void Secure(Page aPage)
        {
            //Get PageName From Current URL		
            //For Menu items the control name should look like pageMenu.controlname
            //For Form items the control name should look like Content.controlname. 

            string securePageName = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            string PageSecurityName = securePageName.Substring(securePageName.LastIndexOf("/") + 1);
            string ParentControl = String.Empty;
            string ChildControl = String.Empty;
            Control rawControl = null;
            string setToState;
            string ControlName = String.Empty;
            int ColumnID = 0;
            string[] ControlNames;

            DataTable dtSecurityControl = ApplicationContext.GetApplicationControlSecurity();
            string Clause = "SecurityProfile=" + SessionContext.SecurityProfile.ToString() + " and (PageMappingX='" + PageSecurityName.Trim().ToString() + "')";
            DataRow[] dr = dtSecurityControl.Select(Clause);
            foreach (DataRow row in dr)
            {
                ControlName = row["ControlMappingCode"].ToString();
                ParentControl = "MainContent";
                ControlNames = ControlName.Split("_".ToCharArray());
                ChildControl = ControlNames[0];
                if (ControlNames.Length > 1)
                {
                    ColumnID = Convert.ToInt16(ControlNames[1]);
                }
                try
                {
                    rawControl = aPage.Master.FindControl(ParentControl).FindControl(ChildControl);
                }

                catch
                {
                    try
                    {
                        rawControl = aPage.FindControl(ChildControl);
                    }
                    catch
                    {


                    }
                    //do nothing - Control name is in the database but is missing on the page.
                }

                if (rawControl != null)
                {
                    setToState = row["ControlState"].ToString();

                    if (rawControl is WebControl)
                    {
                        if (rawControl is GridView)
                        {
                            if (setToState.Equals("H"))
                                ((GridView)rawControl).Columns[ColumnID].Visible = false;

                            else if (setToState.Equals("D"))
                                ((GridView)rawControl).Columns[ColumnID].Visible = false;

                        }
                        else if (rawControl is DataGrid)
                        {
                            if (setToState.Equals("H"))
                                ((DataGrid)rawControl).Columns[ColumnID].Visible = false;

                            else if (setToState.Equals("D"))
                                ((DataGrid)rawControl).Columns[ColumnID].Visible = false;
                        }
                        else
                        {

                            if (setToState.Equals("H"))
                                ((WebControl)rawControl).Visible = false;

                            else if (setToState.Equals("D"))
                                ((WebControl)rawControl).Enabled = false;
                        }
                    }
                    if (rawControl is HtmlControl)
                    {
                        if (setToState.Equals("H"))
                            ((HtmlControl)rawControl).Visible = false;

                        else if (setToState.Equals("D"))                    // Enabled=false; no such property
                            ((HtmlControl)rawControl).Visible = false;
                    }
                }
            }

        }

        public static void Secure1(Page aPage)
        {


            //Get PageName From Current URL			
            string securePageName = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            string PageSecurityName = securePageName.Substring(securePageName.LastIndexOf("/") + 1);
            DataTable dtPageSecurity = ApplicationContext.GetApplicationControlSecurity();
            dtPageSecurity.DefaultView.RowFilter = "SecurityProfile=" + SessionContext.SecurityProfile.ToString() + " and (PageMappingX='" + PageSecurityName + "')";
            dtPageSecurity = dtPageSecurity.DefaultView.ToTable();
            // Code added by Ashraf
            // Exit If there are not any records in security details for page
            if (dtPageSecurity.Rows.Count == 0)
            {
                return;
            }
            // Set State for each of the controls
            for (int i = 0; i < aPage.Form.Controls.Count; i++)
            {
                // Set State of current control
                SecureControl(aPage.Form.Controls[i], dtPageSecurity);
            }
            dtPageSecurity = null;
        }


        //****************************************************
        //****************************************************
        //Secure Page For Security Profile and Page Name for current Site
        public static bool SecurePage(Page aPage)
        {

            //Get PageName From Current URL			
            string securePageName = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            string PageSecurityName = securePageName.Substring(securePageName.LastIndexOf("/") + 1);
            DataTable dtPageSecurity = ApplicationContext.GetApplicationPageSecurity();
            dtPageSecurity.DefaultView.RowFilter = "Role=" + SessionContext.SecurityProfile.ToString() + " and (PageMappingX='" + PageSecurityName + "')";
            dtPageSecurity = dtPageSecurity.DefaultView.ToTable();

            // Code added by Ashraf
            // Exit If there are not any records in security details for page
            if (dtPageSecurity.Rows.Count == 0)
            {
                return true;
            }

            dtPageSecurity = null;
            return false;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="aMenu"></param>
        public static void SecureMenuControl(Menu aMenu)
        {

            string PageSecurityName = "MenuControl";
            DataTable dtPageSecurity = ApplicationContext.GetApplicationControlSecurity();
            dtPageSecurity.DefaultView.RowFilter = "SecurityProfile=" + SessionContext.SecurityProfile.ToString() + " and (PageMappingX='" + PageSecurityName + "')";
            dtPageSecurity = dtPageSecurity.DefaultView.ToTable();
            //Exit If there are not any records in security details for page
            if (dtPageSecurity.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < aMenu.Items.Count; i++)
            {
                SecureMenuItem(aMenu.Items[i], dtPageSecurity);
            }

            for (int i = 0; i < aMenu.Items.Count; i++)
            {
                if (aMenu.Items[i].Value == "_H_")
                {
                    aMenu.Items.Remove(aMenu.Items[i]);
                    i = 0;
                }
                else
                {

                    for (int j = 0; j < aMenu.Items[i].ChildItems.Count; j++)
                    {
                        if (aMenu.Items[i].ChildItems[j].Value == "_H_")
                        {
                            aMenu.Items[i].ChildItems.Remove(aMenu.Items[i].ChildItems[j]);
                            j = 0;
                        }
                    }

                }
            }
        }
        /// <param name="aMenu">
        /// 
        /// </param>
        private static void SecureMenuItem(MenuItem aMenuItem, DataTable SecurityDetails)
        {
            string setToState = GetControlState(aMenuItem.Value, SecurityDetails);

            if (setToState == "H")
            {
                aMenuItem.Value = "_H_";
            }
            else if (setToState == "D")
            {
                aMenuItem.Enabled = false;
            }
            for (int i = 0; i < aMenuItem.ChildItems.Count; i++)
            {
                SetMenuItemStatus(aMenuItem.ChildItems[i], SecurityDetails);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static void SetMenuItemStatus(MenuItem aMenuItem, DataTable SecurityDetails)
        {
            string setToState = GetControlState(aMenuItem.Value, SecurityDetails);

            if (setToState == "H")
            {
                aMenuItem.Value = "_H_";
            }
            else if (setToState == "D")
            {
                aMenuItem.Enabled = false;
            }
        }
        // Code Added By Ashraf
        /// <summary>
        /// Method Takes Web User Control as a paremeter and sets the states of the its
        /// controls as per the security details.
        /// </summary>
        /// <param name="aUserControl"></param>
        /// 

        //****************************************************
        //****************************************************
        //Secure Page For Security Profile and Page Name for current Site
        public static void Secure(UserControl UserControl)
        {
            //Get PageName From Current URL		
            //For Menu items the control name should look like pageMenu.controlname
            //For Form items the control name should look like Content.controlname. 


            string securePageName = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            string PageSecurityName = securePageName.Substring(securePageName.LastIndexOf("/") + 1);
            string ParentControl = String.Empty;
            string ChildControl = String.Empty;
            Control rawControl = null;
            string setToState;
            string ControlName = String.Empty;
            string[] ControlNames;
            int ColumnID = 0;
            DataTable dtSecurityControl = ApplicationContext.GetApplicationControlSecurity();
            string Clause = "SecurityProfile=" + SessionContext.SecurityProfile.ToString() + " and (PageMappingX='" + PageSecurityName.Trim().ToString() + "')";
            DataRow[] dr = dtSecurityControl.Select(Clause);
            foreach (DataRow row in dr)
            {
                //pageMenu_mnuAccountingCompany

                ControlName = row["ControlMappingCode"].ToString();
                ParentControl = "MainContent";
                ControlNames = ControlName.Split("_".ToCharArray());
                ChildControl = ControlNames[0];
                if (ControlNames.Length > 1)
                {
                    ColumnID = Convert.ToInt16(ControlNames[1]);
                }
                try
                {
                    rawControl = UserControl.FindControl(ChildControl);
                }
                catch
                {

                }

                if (rawControl != null)
                {
                    setToState = row["ControlState"].ToString();

                    if (rawControl is WebControl)
                    {
                        if (rawControl is GridView)
                        {
                            if (setToState.Equals("H"))
                                ((GridView)rawControl).Columns[ColumnID].Visible = false;

                            //else if (setToState.Equals("D"))
                            //    ((GridView)rawControl).Columns[ColumnID].e = false;

                        }
                        else if (rawControl is DataGrid)
                        {
                            if (setToState.Equals("H"))
                                ((DataGrid)rawControl).Columns[ColumnID].Visible = false;

                            //else if (setToState.Equals("D"))
                            //    ((DataGrid)rawControl).Columns[ColumnID].Enabled = false;
                        }
                        if (ColumnID == 0)
                        {
                            if (setToState.Equals("H"))
                                ((WebControl)rawControl).Visible = false;

                            else if (setToState.Equals("D"))
                                ((WebControl)rawControl).Enabled = false;
                        }
                        else
                        {
                            ColumnID = 0;
                        }
                    }
                    if (rawControl is HtmlControl)
                    {
                        if (setToState.Equals("H"))
                            ((HtmlControl)rawControl).Visible = false;

                        else if (setToState.Equals("D"))                    // Enabled=false; no such property
                            ((HtmlControl)rawControl).Visible = false;
                    }
                }
            }

        }

        public static void Secure1(UserControl aUserControl)
        {
            string AspFileName = aUserControl.AppRelativeVirtualPath;
            AspFileName = AspFileName.Substring(AspFileName.LastIndexOf("/") + 1);
            DataTable dtControlSecurity = ApplicationContext.GetApplicationControlSecurity();
            dtControlSecurity.DefaultView.RowFilter = "SecurityProfile=" + SessionContext.SecurityProfile.ToString() + " and (PageMappingX='" + AspFileName + "')";
            dtControlSecurity = dtControlSecurity.DefaultView.ToTable();
            // Exit if there is no record for this user control
            if (dtControlSecurity.Rows.Count == 0)
            {
                return;
            }
            //Go through each of the controls of User Control.
            for (int i = 0; i < aUserControl.Controls.Count; i++)
            {
                SecureControl(aUserControl.Controls[i], dtControlSecurity);
            }
            dtControlSecurity = null;
        }
        /// <summary>
        /// Common method that secures all the controls of a page or user control.
        /// 
        /// </summary>
        /// <param name="rawControl"></param>
        private static void SecureControl(Control rawControl, DataTable SecurityDetails)
        {
            // Not a valid control 
            if (rawControl == null)
            {
                return;
            }
            // No Need to set any State
            if (rawControl.ID == null)
            {
                return;
            }
            //Get the State to set for control from the security details
            string setToState = GetControlState(rawControl.ID, SecurityDetails);
            if (rawControl is WebControl)
            {
                if (setToState == "H")
                {
                    ((WebControl)rawControl).Visible = false;
                }
                else if (setToState == "D")
                {
                    ((WebControl)rawControl).Enabled = false;
                }
            }
            else if (rawControl is HtmlControl)
            {
                if (setToState == "H" || setToState == "D")
                {
                    ((HtmlControl)rawControl).Visible = (setToState == "N");
                }
            }
            // Check if there are any child Controls in control
            // Avoid Child Controls  if parent control is disabled or hidden already.
            if (setToState == "N" && rawControl.Controls.Count > 0)
            {
                for (int i = 0; i < rawControl.Controls.Count; i++)
                {
                    SecureControl(rawControl.Controls[i], SecurityDetails);
                }
            }
        }
        /// <summary>
        /// Function returns the state of the control based on id of the control
        /// If There is no state defined for the control 'Normal' will be returned by default.
        /// </summary>
        /// <param name="ControlName"></param>
        /// <param name="SecurityDetails"></param>
        private static string GetControlState(string ControlMappingCode, DataTable SecurityDetails)
        {
            DataRow[] dr = SecurityDetails.Select("ControlMappingCode='" + ControlMappingCode + "'");
            if (dr != null && dr.Length > 0)
            {
                return dr[0]["ControlState"].ToString();
            }
            else
            {
                return "N";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ControlName"></param>
        /// <param name="SecurityDetails"></param>
        public static void GetLabelText(Page aPage)
        {
            DataSet ds = new DataSet();
            string securePageName = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            string PageSecurityName = securePageName.Substring(securePageName.LastIndexOf("/") + 1);
            ds.ReadXml(WebUtility.GetAppSetting("XMLFileFolder") + "SchoolModuleLabels.XML");
            DataRow[] dr = ds.Tables[0].Select("Value=" + SessionContext.Site.ToString());
            string SchoolID = "";
            string ModuleID = "";
            DataTable dt = new DataTable();
            if (dr != null && dr.Length > 0)
            {
                SchoolID = dr[0]["School_ID"].ToString();
                dr = ds.Tables[1].Select("School_ID=" + SchoolID + " and ModuleName='" + PageSecurityName + "'");
                if (dr != null && dr.Length > 0)
                {
                    ModuleID = dr[0]["Module_ID"].ToString();
                    ds.Tables[2].DefaultView.RowFilter = "Module_ID=" + ModuleID;
                    dt = ds.Tables[2].DefaultView.ToTable();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (Control ct1 in aPage.Form.Controls)
                        {
                            SetControlText(ct1, dt);
                        }
                    }
                }
            }
            ds = null;
        }

        /// <summary>
        /// Common method that secures all the controls of a page or user control.
        /// 
        /// </summary>
        /// <param name="rawControl"></param>
        private static void SetControlText(Control rawControl, DataTable SecurityDetails)
        {
            // Not a valid control 
            if (rawControl == null)
            {
                return;
            }
            //No Need to set any State
            if (rawControl.ID == null)
            {
                return;
            }
            //Get the State to set for control from the security details
            string SetText = GetControlText(rawControl.ID, SecurityDetails);

            if (rawControl is System.Web.UI.WebControls.Label)
            {
                //    if (setToState == "H")
                //    {
                ((Label)rawControl).Text = SetText;
                //    }
                //    else if (setToState == "D")
                //    {
                //        ((WebControl)rawControl).Enabled = false;
                //    }
                //}
                //else if (rawControl is HtmlControl)
                //{
                //    if (setToState == "H" || setToState == "D")
                //    {
                //        ((HtmlControl)rawControl).Visible = (setToState == "N");
                //    }
                //}
                //// Check if there are any child Controls in control
                //// Avoid Child Controls  if parent control is disabled or hidden already.
            }
            if (rawControl.Controls.Count > 0)
            {
                for (int i = 0; i < rawControl.Controls.Count; i++)
                {
                    SetControlText(rawControl.Controls[i], SecurityDetails);
                }
            }
        }
        /// <summary>
        /// Function returns the state of the control based on id of the control
        /// If There is no state defined for the control 'Normal' will be returned by default.
        /// </summary>
        /// <param name="ControlName"></param>
        /// <param name="SecurityDetails"></param>
        private static string GetControlText(string ControlMappingCode, DataTable SecurityDetails)
        {
            DataRow[] dr = SecurityDetails.Select("ID='" + ControlMappingCode + "'");
            if (dr != null && dr.Length > 0)
            {
                return dr[0]["Value"].ToString();
            }
            else
            {
                return "N";
            }
        }
    }
}
