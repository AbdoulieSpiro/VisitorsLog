using System;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Data;
using System.Web.Security;
using HRSystemServer.BusinessLayer;


namespace HRSystemWeb
{
    public class ApplicationContext
    {

        public enum Module
        {
            HOME,
            NEWS,
            ARTICLES,
            FORUM,
            BLOGS,
            ALBUM,
            VIDEOS,
            JOBS,
            SHOP,
            SchoolADMIN,
            SYSTEMADMIN

        }

        private const string EntryName = "ApplicationContext";
        private DataSet _dataSet = new DataSet();

        //********************************************************
        private ApplicationContext()
        {
            ReloadSecurity();
        }

        private void ReloadSecurity()
        {
            SecurityDetailBL bl = new SecurityDetailBL(0);
            _dataSet.Clear();
            bl.FetchForApplicationControlSecurity(_dataSet);
        }


        //********************************************************
        public static DataTable GetApplicationControlSecurity()
        {
            return Instance()._dataSet.Tables["tbSecurityDetail"];
        }


        public static void ReloadControlSecurity()
        {
            Instance().ReloadSecurity();
        }



        //********************************************************
        public static HttpApplicationState CurrentApplication
        {
            get { return HttpContext.Current.Application; }
        }


        //********************************************************
        public static ApplicationContext Instance()
        {

            if (CurrentApplication[EntryName] == null)
                SetApplicationContext();

            return (ApplicationContext)CurrentApplication[EntryName];
        }

        //********************************************************
        public static void SetApplicationContext()
        {
            ApplicationContext buffer = null;
            if (CurrentApplication[EntryName] == null)
            {
                buffer = new ApplicationContext();
                CurrentApplication.Add(EntryName, buffer);
            }
            else
            {
                buffer = (ApplicationContext)CurrentApplication[EntryName];
            }
        }



        public static void ReloadpageSecurity()
        {
            CurrentApplication["PageSecurity"] = null;
            GetApplicationPageSecurity();
        }
        //********************************************************
        public static DataTable GetApplicationPageSecurity()
        {
            DataSet Ds = new DataSet();
            if (CurrentApplication["PageSecurity"] == null)
            {
                RolePageMappingBL bl = new RolePageMappingBL(0);
                bl.FetchForApplicationPageSecurity(Ds);
                CurrentApplication["PageSecurity"] = Ds.Tables["tbRolePageMapping"];
            }
            return ((DataTable)CurrentApplication["PageSecurity"]);
        }

    }
}
