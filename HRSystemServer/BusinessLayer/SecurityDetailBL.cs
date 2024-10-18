using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class SecurityDetailBL: BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public SecurityDetailBL(int aSystemUser)
        {
            DataLayer = SecurityDetailDL.GetInstance();
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
		public virtual bool FetchForApplicationControlSecurity(DataSet aDataSet)
		{
			return Execute(SqlAction.FetchForApplicationControlSecurity, aDataSet);
		}

		//****************************************************
		//****************************************************
		public virtual bool FetchForPageMapping(DataSet aDataSet, int aSecurityProfile, int aPageMapping)
		{
			return Execute(SqlAction.FetchForPageMapping, aDataSet, aSecurityProfile, aPageMapping);
		}


		//****************************************************
		//****************************************************
		public virtual bool Upsert(int aSecurityDetail, int aControlMapping, int aSecurityProfile, string aControlState)
		{
			return Execute(SqlAction.Upsert, null, aSecurityDetail, aControlMapping, aSecurityProfile,aControlState);
		}


    }
}
