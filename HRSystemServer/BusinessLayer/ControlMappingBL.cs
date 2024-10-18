using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class ControlMappingBL : BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public ControlMappingBL(int aSystemUser)
        {
            DataLayer = ControlMappingDL.GetInstance();
            SystemUser = aSystemUser;
        }


        //****************************************************
        //****************************************************
        public virtual bool FetchForPageMapping(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForPageMapping, aDataSet, aKey);
        }  
        public virtual bool FetchControl(DataSet aDataSet, string PageCode,int Role )
        {
            return Execute(SqlAction.FetchControl, aDataSet, PageCode, Role);
        }
    }
}
