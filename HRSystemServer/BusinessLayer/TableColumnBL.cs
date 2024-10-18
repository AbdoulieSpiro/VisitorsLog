using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class TableColumnBL : BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public TableColumnBL(int aSystemUser)
        {
            DataLayer = TableColumnDL.GetInstance();
            SystemUser = aSystemUser;
        }

        public bool FetchForPage(DataSet ds, int Page)
        {
            return Execute(SqlAction.FetchForPage, ds, Page);
        }

    }
}
