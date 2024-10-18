using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public enum LockOutState
    {
        Unknown,
        LockedOut,
        Ok
    }


    public class SystemUserBL : BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public SystemUserBL(int aSystemUser)
        {
            DataLayer = SystemUserDL.GetInstance();
            SystemUser = aSystemUser;
        }


        //****************************************************
        //****************************************************
        public virtual bool FetchForLogin(DataSet aDataSet, string aBaseURL, string aLoginEmailAddress, string aPassword)
        {
            return Execute(SqlAction.FetchForLogin, aDataSet, aBaseURL, aLoginEmailAddress, aPassword);
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForLoginEmailAddress(DataSet aDataSet, int aSite, string aLoginEmailAddress)
        {
            return Execute(SqlAction.FetchForLoginEmailAddress, aDataSet, aSite, aLoginEmailAddress);
        }

        public virtual bool FetchForNameInitial(DataSet aDataSet, string SearchInitial, int SiteId,int Role)
        {
            return Execute(SqlAction.FetchForNameInitial, aDataSet, SearchInitial, SiteId, Role);
        }

        /// <summary>
        /// Fetch User for the School....
        /// </summary>
        /// <param name="aDataSet"></param>
        /// <param name="aSchool"></param>
        /// <returns></returns>
        public virtual bool FetchForSchool(DataSet aDataSet, int aSchool)
        {
            return Execute(SqlAction.FetchForSchool, aDataSet, aSchool);
        }
        //****************************************************
        //****************************************************
        public virtual bool FetchForEmailAddress(DataSet aDataSet, int aSystemUser)
        {
            return Execute(SqlAction.FetchForEmailAddress, aDataSet, aSystemUser);
        }


        //****************************************************
        //****************************************************
        public virtual bool FetchForSearch(DataSet aDataSet, string aSearchHint)
        {
            return Execute(SqlAction.FetchForSearch, aDataSet, aSearchHint);
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForSystemUserAndSite(DataSet aDataSet, int aSystemUser, int aSite)
        {
            return Execute(SqlAction.FetchForSearch, aDataSet, aSystemUser, aSite);
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForSiteRoleType(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForSiteRoleType, aDataSet, aKey);
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForSite(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForSite, aDataSet, aKey);
        }

     

        //****************************************************
        //****************************************************
        public virtual bool FetchEmailAddressForSystemUser(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchEmailAddressForSystemUser, aDataSet, aKey);
        }

       
        //****************************************************
        //****************************************************
        public virtual bool FetchForSystemUserProfile(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForSystemUserProfile, aDataSet, aKey);
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForUserRole(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForUserRole, aDataSet, aKey);
        }
    

        //****************************************************
        //****************************************************
        public DataRow QuickAdd(int aSite, int aSystemUser)
        {
            DataRow result = null;
            SiteBL Sitebl = new SiteBL(this.SystemUser);
            DataRow SiteRow = Sitebl.GetRow(aSite);
            if (SiteRow != null)
            {
                DataSet ds = new DataSet();
                this.Fetch(ds, int.MinValue);
                DataRow newRow = ds.Tables[0].NewRow();
                ds.Tables[0].Rows.Add(newRow);
                newRow["SiteRoleType"] = SiteRow["DefaultSiteRoleType"];
                newRow["SystemUser"] = aSystemUser;
                newRow["IsActive"] = true;
                newRow["Site"] = aSite;
                if (this.Save(ds))
                    result = ds.Tables[0].Rows[0];
            }
            return result;
        }
        //****************************************************
        //****************************************************
        public virtual DataRow GetRow(int aSite, string aLoginEmailAddress)
        {
            DataRow result = null;
            try
            {
                DataSet ds = new DataSet();
                FetchForLoginEmailAddress(ds, aSite, aLoginEmailAddress);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = ds.Tables[0].Rows[0];
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        //****************************************************
        //****************************************************
        public virtual LockOutState GetLockOutState(int aSite, string aLoginEmailAddress)
        {
            LockOutState result = LockOutState.Unknown;
            DataRow uRow = GetRow(aSite, aLoginEmailAddress);
            if (uRow != null)
            {
                SiteBL SiteBL = new SiteBL(SystemUser);
                DataRow sRow = SiteBL.GetRow(aSite);
                if (sRow != null)
                {
                    int Max = (int)sRow["MaxFailedLoginCount"];
                    int Cur = (int)uRow["FailedLoginCount"];
                    if (Cur <= Max)
                        result = LockOutState.Ok;
                    else
                        result = LockOutState.LockedOut;
                }
            }
            return result;
        }

        //****************************************************
        //****************************************************
        public static string SystemUserX(int aKey)
        {
            SystemUserBL bl = new SystemUserBL(-1);
            DataRow r = bl.GetRow(aKey);
            if (r != null)
                return r["Alias"].ToString();
            else
                return "";
        }
    }
}
