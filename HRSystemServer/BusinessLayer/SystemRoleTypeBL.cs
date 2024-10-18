using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class SystemRoleTypeBL : BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public SystemRoleTypeBL(int aSystemUser)
        {
            DataLayer = SystemRoleTypeDL.GetInstance();
            SystemUser = aSystemUser;
        }


        //****************************************************
        //****************************************************
        public virtual bool FetchForSecurityProfile(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForSecurityProfile, aDataSet, aKey);
        }
        //****************************************************
        //****************************************************
        public virtual bool FetchForRole(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForRole, aDataSet, aKey);
        }
        //****************************************************
        public virtual bool FetchForSystemRoleType(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForSystemRoleType, aDataSet, aKey);
        }
        public static string SystemRoleTypeX(int aKey)
        {
            SystemRoleTypeBL bl = new SystemRoleTypeBL(-1);
            DataRow r = bl.GetRow(aKey);
            if (r != null)
                return r["SystemRoleTypeBLX"].ToString();
            else
                return "";
        }
    }
}
