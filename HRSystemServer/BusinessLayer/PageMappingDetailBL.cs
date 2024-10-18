using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class PageMappingDetailBL : BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public PageMappingDetailBL(int aSystemUser)
        {
            DataLayer = PageMappingDetailDL.GetInstance();
            SystemUser = aSystemUser;
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForSystemRoleType(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForSystemRoleType, aDataSet, aKey);
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForPageSecurity(DataSet aDataSet, int SystemRoleType, string PageMappingX)
        {
            return Execute(SqlAction.FetchForPageSecurity, aDataSet, SystemRoleType, PageMappingX);
        }

        //****************************************************
        //****************************************************
        public virtual bool FetchForPageMapping(DataSet aDataSet, int SystemRoleType, int aPageMapping)
        {
            return Execute(SqlAction.FetchForPageMapping, aDataSet, SystemRoleType, aPageMapping);
        }


        //****************************************************
        //****************************************************
        public virtual bool Upsert(int aPageMappingDetail, int aPageMapping, int aSecurityProfile, bool PerformControlCheck, bool DenyAcces)
        {
            return Execute(SqlAction.Upsert, null, aPageMappingDetail, aPageMapping, aSecurityProfile, PerformControlCheck, DenyAcces);
        }
    }
}
