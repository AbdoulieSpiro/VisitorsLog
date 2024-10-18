using HRSystemServer.BusinessLayer;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace HRSystemWeb
{
    public class SessionContext
    {

        public static DataSet dsReqItem = new DataSet();

        //********************************************************
        //********************************************************
        public new static string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<h3>DEBUG INFO</h3>");
            result.Append("SessionID: ");
            result.Append(CurrentSession.SessionID);
            result.Append("<br/>SystemUser: ");
            result.Append(SystemUser.ToString());
            result.Append("<br/>SystemUserX: ");
            result.Append(SystemUserX);
            result.Append("<br/>LoginID: ");
            result.Append(LoginName.ToString());
            result.Append("<br/>LastLogin: ");
            result.Append(LastLogin.ToString());
            result.Append("<br/>IsSiteUser: ");
            result.Append(IsSiteUser.ToString());
            result.Append("<br/>MembershipX: ");
            result.Append(MembershipTypeX);
            result.Append("<br/>Primary User: ");
            result.Append(IsPrimaryUser.ToString());
            result.Append("<br/>Is Account Locked: ");
            result.Append(IsAccountLocked.ToString());
            result.Append("<br/>All Access To All Companies: ");
            result.Append(AllowAccessToAllCompanies.ToString());
            result.Append("<br/>Site: ");
            result.Append(Site.ToString());
            result.Append("<br/>SiteX: ");
            result.Append(SiteX);
            result.Append("<br/>School Description: ");
            result.Append(SchoolDescription);
            result.Append("<br/>School Keywords: ");
            result.Append(SchoolKeywords);
            result.Append("<br/>IsClosed: ");
            result.Append(IsClosed.ToString());
            result.Append("<br/>OpenToPublic: ");
            result.Append(IsOpenToPublic.ToString());
            result.Append("<br/>Test Mode: ");
            result.Append(IsTestMode.ToString());
            result.Append("<br/>BaseURL: ");
            result.Append(BaseURL.ToString());
            result.Append("<br/>SecurityProfile: ");
            result.Append(SecurityProfile.ToString());
            result.Append("<br/>SiteRoleType: ");
            result.Append(SiteRoleType.ToString());

            result.Append("<br/>Allow Access To All Sites: ");
            result.Append(AllowAccessToAllSites ? "Yes" : "No");

            result.Append("<br/>Super Administrator: ");
            result.Append(SuperAdministrator ? "Yes" : "No");

            result.Append("<br/>Site Administrator: ");
            result.Append(SiteAdministrator ? "Yes" : "No");

            result.Append("<br/>SearchHint: ");
            result.Append(SearchHint);
            result.Append("<br/>Timestamp: ");
            result.Append(GetTimestamp().ToString());
            result.Append("<br/>SchoolTheme: ");
            result.Append(SchoolTheme);
            result.Append("<br/>SiteLogoFileName: ");
            result.Append(SiteLogoFileName);
            result.Append("<br/>Paid Membership: ");
            result.Append(PaidMembership.ToString());
            result.Append("<br/>Content Library: ");
            result.Append(ContentLibrary.ToString());
            result.Append("<br/>TabID: ");
            result.Append(TabID.ToString());
            return result.ToString();

        }
        //********************************************************
        public static string SiteStyleSheet
        {
            set
            {

                CurrentSession["SiteStyleSheet"] = "../styles/" + value;
                //else
                //	CurrentSession["SchoolStyleSheet"] = @"../styles/default.css";
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SiteStyleSheet"];
                }
                catch
                {
                    result = "../styles/default.css";
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static int CurrentSchoolSession
        {
            set
            {
                CurrentSession["CurrentSession"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["CurrentSession"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }


        /***** Store the CanUpload in the Session ******/
        public static bool CanUpload
        {
            set
            {
                CurrentSession["CanUpload"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanUpload"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }
        /***** Store the CanCreateFolder in the Session ******/
        public static bool CanCreateFolder
        {
            set
            {
                CurrentSession["CanCreateFolder"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanCreateFolder"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        /***** Store the CanDelete in the Session ******/
        public static bool CanDelete
        {
            set
            {
                CurrentSession["CanDelete"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanDelete"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        /***** Store the CanDownload in the Session ******/
        public static bool CanDownload
        {
            set
            {
                CurrentSession["CanDownload"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanDownload"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        /***** Store the CanShare in the Session ******/
        public static bool CanShare
        {
            set
            {
                CurrentSession["CanShare"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanShare"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }
        public static bool SharedBreadcrumb
        {
            set
            {
                CurrentSession["SharedBreadcrumb"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["SharedBreadcrumb"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }
        /***** Store the IsShared in the Session *****/
        public static bool IsShared
        {
            set
            {
                CurrentSession["IsShared"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["IsShared"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        /***** Store the CanCreateShareFolder in the Session *****/
        public static bool CanCreateShareFolder
        {
            set
            {
                CurrentSession["CanCreateShareFolder"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanCreateShareFolder"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        /***** Store the CanUploadShareFolderFiles in the Session *****/
        public static bool CanUploadShareFolderFiles
        {
            set
            {
                CurrentSession["CanUploadShareFolderFiles"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanUploadShareFolderFiles"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        /***** Store the CanShareOutside in the Session ******/
        public static bool CanShareOutside
        {
            set
            {
                CurrentSession["CanShareOutside"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["CanShareOutside"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string SiteLogoFileName
        {
            set
            {
                //string p = HttpContext.Current.Request.PhysicalApplicationPath + @"images\" + value;
                string p = "../Site/images/" + value;
                CurrentSession["SiteLogoFileName"] = value;
            }
            get
            {
                return (string)CurrentSession["SiteLogoFileName"];
            }
        }
        public static int AlbumID
        {
            set
            {
                CurrentSession["AlbumID"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["AlbumID"];
                }
                catch
                {
                    result = 0;
                }
                return result;
            }
        }
        public static string UploadFileName
        {
            set
            {
                //string p = HttpContext.Current.Request.PhysicalApplicationPath + @"images\" + value;
                string p = "../School/Documents/" + value;
                CurrentSession["UploadFileName"] = value;
            }
            get
            {
                return (string)CurrentSession["UploadFileName"];
            }
        }
        //********************************************************
        //********************************************************
        public static string Theme
        {
            set
            {

                CurrentSession["Theme"] = value;
            }
            get
            {
                return (string)CurrentSession["Theme"];
            }
        }


        //********************************************************
        //********************************************************
        public static string SchoolTheme
        {
            set
            {

                CurrentSession["SchoolTheme"] = value;

            }
            get
            {
                string result = "Default";
                try
                {
                    result = (string)CurrentSession["SchoolTheme"];
                }
                catch
                {
                    result = "Default";
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static int SiteRoleType
        {
            set
            {
                CurrentSession["SiteRoleType"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["SiteRoleType"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static int SystemRoleType
        {
            set
            {
                CurrentSession["SystemRoleType"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["SystemRoleType"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static int DefaultCompany
        {
            set
            {
                CurrentSession["DefaultCompany"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["DefaultCompany"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static int DefaultMembershipType
        {
            set
            {
                CurrentSession["DefaultMembershipType"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["DefaultMembershipType"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static DateTime DefaultExpirationDate
        {
            set
            {
                CurrentSession["DefaultExpirationDate"] = value;
            }
            get
            {
                DateTime result;
                try
                {
                    result = (DateTime)CurrentSession["DefaultExpirationDate"];
                }
                catch
                {
                    result = DateTime.Now;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static bool AllowAccessToAllSites
        {
            set
            {
                CurrentSession["AllowAccessToAllSites"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["AllowAccessToAllSites"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static bool AllowAccessToAllCompanies
        {
            set
            {
                CurrentSession["AllowAccessToAllCompanies"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["AllowAccessToAllCompanies"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static int MembershipType
        {
            set
            {
                CurrentSession["MembershipType"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["MembershipType"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static DateTime AccountExpirationDate
        {
            set
            {
                CurrentSession["AccountExpirationDate"] = value;
            }
            get
            {
                DateTime result;
                try
                {
                    result = (DateTime)CurrentSession["AccountExpirationDate"];
                }
                catch
                {
                    result = System.DateTime.Today;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string MembershipTypeX
        {
            set
            {
                CurrentSession["MembershipTypeX"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["MembershipTypeX"];
                }
                catch
                {
                    result = "";
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static bool PaidMembership
        {
            set
            {
                CurrentSession["PaidMembership"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["PaidMembership"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }
        //********************************************************
        //********************************************************
        public static ApplicationContext.Module Module
        {
            set
            {
                CurrentSession["Module"] = value;
            }
            get
            {
                ApplicationContext.Module result;
                try
                {
                    result = (ApplicationContext.Module)CurrentSession["Module"];
                }
                catch
                {
                    result = ApplicationContext.Module.HOME;
                }
                return result;
            }
        }



        //********************************************************
        //********************************************************
        public static bool ContentLibrary
        {
            set
            {
                CurrentSession["ContentLibrary"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["ContentLibrary"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }



        //********************************************************
        //********************************************************
        public static int GridPage
        {
            set
            {
                CurrentSession["GridPage"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["GridPage"];
                }
                catch
                {
                    result = 0;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static bool IsSiteUser
        {
            set
            {
                CurrentSession["SiteUser"] = value;


            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["SiteUser"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }



        //********************************************************
        //********************************************************
        public static bool IsPrimaryUser
        {
            set
            {
                CurrentSession["PrimaryUser"] = value;


            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["PrimaryUser"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static bool IsTrial
        {
            set
            {
                CurrentSession["IsTrial"] = value;


            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["IsTrial"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }


        public static int TrialDays
        {
            set
            {
                CurrentSession["TrialDays"] = value;


            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["TrialDays"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static string SystemUserUnique
        {
            set
            {
                CurrentSession["SystemUserUnique"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SystemUserUnique"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static int SystemUser
        {
            set
            {
                CurrentSession["SystemUser"] = value;
                SystemUserBL buffer = new SystemUserBL(value);
                DataSet ds = new DataSet();
                if (buffer.Fetch(ds, value))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SystemUserX = ds.Tables[0].Rows[0]["FirstName"] + " " + ds.Tables[0].Rows[0]["LastName"];
                    }
                }
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["SystemUser"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string SystemUserX
        {
            set
            {
                CurrentSession["SystemUserX"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SystemUserX"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static string LoginName
        {
            set
            {
                CurrentSession["LoginName"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["LoginName"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static bool SuperAdministrator
        {
            set
            {
                CurrentSession["SuperAdministrator"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["SuperAdministrator"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static bool SiteAdministrator
        {
            set
            {
                CurrentSession["SiteAdministrator"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["SiteAdministrator"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static string RenewalMessageX
        {
            set
            {
                CurrentSession["RenewalMessageX"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["RenewalMessageX"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static bool IsAccountLocked
        {
            set
            {
                CurrentSession["AccountLocked"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["AccountLocked"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string SearchHint
        {
            set
            {
                CurrentSession["SearchHint"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SearchHint"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string PageCode
        {
            set
            {
                CurrentSession["PageCode"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["PageCode"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static int SecurityProfile
        {
            set
            {
                CurrentSession["SecurityProfile"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["SecurityProfile"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static int Site
        {
            set
            {
                CurrentSession["Site"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["Site"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }

        //*********************************************NRC User Id*********************//
        public static int RowId1
        {
            set
            {
                CurrentSession["RowId1"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["RowId1"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }



        public static int RowId2
        {
            set
            {
                CurrentSession["RowId2"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["RowId2"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }



        public static int RowId3
        {
            set
            {
                CurrentSession["RowId3"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["RowId3"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }




        public static int RowId4
        {
            set
            {
                CurrentSession["RowId4"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["RowId4"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }



        public static int RowId5
        {
            set
            {
                CurrentSession["RowId5"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["RowId5"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }



        public static int RowId6
        {
            set
            {
                CurrentSession["RowId6"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["RowId6"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }




        public static int RowId7
        {
            set
            {
                CurrentSession["RowId7"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["RowId7"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }

        public static int ActiveTab
        {
            set
            {
                CurrentSession["ActiveTab"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["ActiveTab"];
                }
                catch
                {
                    result = 0;
                }
                return result;
            }
        }
        //***************************************************************************//
        //********************************************************



        //********************************************************
        public static string SiteX
        {
            set
            {
                CurrentSession["SiteX"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SiteX"];
                }
                catch
                {
                    result = "";
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static bool IsOpenToPublic
        {
            set
            {
                CurrentSession["IsOpenToPublic"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["IsOpenToPublic"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static bool IsClosed
        {
            set
            {
                CurrentSession["IsClosed"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["IsClosed"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static bool IsTestMode
        {
            set
            {
                CurrentSession["IsTestMode"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["IsTestMode"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string BaseURL
        {
            set
            {
                CurrentSession["BaseURL"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["BaseURL"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string SessionID
        {
            get
            {
                return CurrentSession.SessionID;
            }
        }



        //********************************************************
        //********************************************************
        public static Hashtable ReportParameters
        {
            set
            {
                CurrentSession["ReportParameters"] = value;
            }
            get
            {
                Hashtable result;
                try
                {
                    result = (Hashtable)CurrentSession["ReportParameters"];
                }
                catch
                {
                    result = null;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTimestamp()
        {
            DateTime result;
            try
            {
                result = (DateTime)CurrentSession["TimeStamp"];
            }
            catch
            {
                result = DateTime.MinValue;
            }
            return result;
        }


        //********************************************************
        //********************************************************
        /// <summary>
        /// 
        /// </summary>
        private static void SetTimeStamp()
        {
            CurrentSession["Timestamp"] = DateTime.Now;
        }


        //********************************************************
        //********************************************************
        /// <summary>
        /// 
        /// </summary>
        private SessionContext()
        {
            SecurityProfile = 5;
            SystemUser = -1;
            SystemUserX = string.Empty;
            GridPage = 0;
        }



        //********************************************************
        public static HttpSessionState CurrentSession
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }


        //********************************************************
        public static void Logout()
        {
            FormsAuthentication.SignOut();
            CurrentSession.Abandon();
        }


        //********************************************************
        //********************************************************
        public static DateTime LastLogin
        {
            set
            {
                CurrentSession["LastLogin"] = value;
            }
            get
            {
                DateTime result;
                try
                {
                    result = (DateTime)CurrentSession["LastLogin"];
                }
                catch
                {
                    result = DateTime.Now;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static string SchoolDescription
        {
            set
            {
                CurrentSession["SchoolDescription"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SchoolDescription"];
                }
                catch
                {
                    result = "";
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string SchoolKeywords
        {
            set
            {
                CurrentSession["SchoolKeywords"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SchoolKeywords"];
                }
                catch
                {
                    result = "";
                }
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsLicensinsed
        {
            set
            {
                try
                {
                    CurrentSession["IsLicensinsed"] = value;
                }
                catch
                {

                }

            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["IsLicensinsed"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }


        public static int SetUpStep
        {
            set
            {
                CurrentSession["SetUpStep"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["SetUpStep"];
                }
                catch
                {
                    result = 1;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************

        public static int EmployeeID
        {
            set
            {
                CurrentSession["EmployeeID"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["EmployeeID"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }
        //********************************************************
        //********************************************************
        public static string TabID
        {
            set
            {
                CurrentSession["TabID"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["TabID"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static string RegimentalNo
        {
            set
            {
                CurrentSession["RegimentalNo"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["RegimentalNo"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }

        public static string DocumentType
        {
            set
            {
                CurrentSession["DocumentType"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["DocumentType"];
                }
                catch
                {
                    result = "-1";
                }
                return result;
            }
        }



        //********************************************************
        //********************************************************
        public static string Branch
        {
            set
            {
                CurrentSession["BranchCode"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["BranchCode"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        //

        //********************************************************
        //********************************************************
        public static int UserOrderLevel
        {
            set
            {
                CurrentSession["UserOrderLevel"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["UserOrderLevel"];
                }
                catch
                {
                    result = result = -1;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************




       

        //public static DataSet AddRowitem(int Item, string ItemName, string Reason, double Quantity, int UserID)
        //public static DataSet AddRowitem(int Item ,string ItemIDFrom, string ItemCodeFrom, string ItemFrom, string ItemIDTo, string ItemCodeTo, string ItemTo, string BranchCodeFrom, string BranchFrom, string BranchCodeTo, string BranchTo, string Price, string Reason, double Quantity, int UserID)
        public static DataSet AddRowitem(int Item, int ItemIDFrom, string ItemCodeFrom, string ItemFrom, int ItemIDTo, string ItemCodeTo, string ItemTo, string BranchCodeFrom, string BranchFrom, string BranchCodeTo, string BranchTo, double FromPrice, double ToPrice, double FromAmount, double ToAmount, string Reason, double FromQuantity, double ToQuantity, int UserID, string UnitofMeasurement)
        {

            foreach (DataRow dr in dsReqItem.Tables[0].Rows)
            {
                if (Item.ToString() == dr.ItemArray[2].ToString() && dr.ItemArray[7].ToString() == UserID.ToString())
                {
                    SessionContext.MessageExistes = true;
                    return dsReqItem;
                }
            }
            DataRow NewRow = dsReqItem.Tables[0].NewRow();
            dsReqItem.Tables[0].Rows.Add(NewRow);
            NewRow["Item"] = Item;
            //NewRow["ItemName"] = ItemName;
            NewRow["ItemIDFrom"] = ItemIDFrom;
            NewRow["ItemCodeFrom"] = ItemCodeFrom;
            NewRow["ItemFrom"] = ItemFrom;
            NewRow["ItemIDTo"] = ItemIDTo;
            NewRow["ItemCodeTo"] = ItemCodeTo;
            NewRow["ItemTo"] = ItemTo;
            NewRow["BranchCodeFrom"] = BranchCodeFrom;
            NewRow["BranchFrom"] = BranchFrom.ToUpper();
            NewRow["BranchCodeTo"] = BranchCodeTo;
            NewRow["BranchTo"] = BranchTo.ToUpper();
            NewRow["FromPrice"] = FromPrice;
            NewRow["ToPrice"] = ToPrice;
            NewRow["FromAmount"] = FromAmount;
            NewRow["ToAmount"] = ToAmount;
            NewRow["Reason"] = Reason;
            NewRow["FromQuantity"] = FromQuantity;
            NewRow["ToQuantity"] = ToQuantity;
            NewRow["User"] = UserID;
            NewRow["UnitofMeasurement"] = UnitofMeasurement;
            return (dsReqItem);
        }


        public static DataSet DeleteRowitem(int Item, int UserId)
        {
            for (int RowCount = dsReqItem.Tables[0].Rows.Count; RowCount > 0; --RowCount)
            {
                if (dsReqItem.Tables[0].Rows[RowCount - 1].ItemArray[21].ToString() == UserId.ToString() && dsReqItem.Tables[0].Rows[RowCount - 1].ItemArray[2].ToString() == Item.ToString())
                {
                    dsReqItem.Tables[0].Rows[RowCount - 1].Delete();
                }
            }
            return (dsReqItem);
        }

        public static DataSet DeleteRowitem(int UserId)
        {
            for (int RowCount = dsReqItem.Tables[0].Rows.Count; RowCount > 0; --RowCount)
            {
                if (dsReqItem.Tables[0].Rows[RowCount - 1].ItemArray[7].ToString() == UserId.ToString())
                {
                    dsReqItem.Tables[0].Rows[RowCount - 1].Delete();
                }
            }
            return (dsReqItem);
        }

        //********************************************************



        //********************************************************
        //********************************************************
        public static bool MessageExistes
        {
            set
            {
                CurrentSession["MessageExistes"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["MessageExistes"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }
        //********************************************************
        //********************************************************


        //********************************************************
        //********************************************************
        public static int Department
        {
            set
            {
                CurrentSession["Department"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["Department"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
          //********************************************************
        //********************************************************
        public static int BranchID
        {
            set
            {
                CurrentSession["BranchID"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["BranchID"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************

    }
}
