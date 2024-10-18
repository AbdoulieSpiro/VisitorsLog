using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class BranchBL : BusinessLayerBase
    {
        // Constructor to initialize the DataLayer and SystemUser
        public BranchBL(int aSystemUser)
        {
            DataLayer = BranchDL.GetInstance();
            SystemUser = aSystemUser;
        }


        //****************************************************
        public virtual bool FetchForBranch(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForBranch, aDataSet, aKey);
        }
        public static string BranchX(int aKey)
        {
            BranchBL bl = new BranchBL(-1);
            DataRow r = bl.GetRow(aKey);
            if (r != null)
                return r["BranchBLX"].ToString();
            else
                return "";
        }
    }
}