using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class RolePageMappingBL : BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public RolePageMappingBL(int aSystemUser)
        {
            DataLayer = RolePageMappingDL.GetInstance();
            SystemUser = aSystemUser;
        }
        public virtual bool FetchForRole(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForRole, aDataSet, aKey);
        }
        public virtual bool InsertUpdateMultiple(string xml, int aKey)
        {
            return Execute(SqlAction.InsertUpdateMultiple, xml, aKey);
        }
        public virtual bool FetchForApplicationPageSecurity(DataSet ds)
        {
            return Execute(SqlAction.FetchForApplicationPageSecurity, ds);
        }
    }
}
