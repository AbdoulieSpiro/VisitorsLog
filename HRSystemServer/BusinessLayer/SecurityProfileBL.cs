using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class SecurityProfileBL: BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public SecurityProfileBL(int aSystemUser)
        {
            DataLayer = SecurityProfileDL.GetInstance();
            SystemUser = aSystemUser;
        }

		//****************************************************
		//****************************************************
        //public virtual bool FetchForSession(DataSet aDataSet, int aSchool, int aSystemUser)
        //{
        //    return Execute(SqlAction.FetchForSession, aDataSet, aSchool, aSystemUser);
        //}


		//****************************************************
		//****************************************************
		public virtual bool Clone(int aKey)
		{
			return Execute(SqlAction.Clone, aKey);
		}




    }
}
