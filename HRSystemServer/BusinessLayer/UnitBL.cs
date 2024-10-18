using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;
namespace HRSystemServer.BusinessLayer
{
public class UnitBL : BusinessLayerBase
{
public UnitBL(int aSystemUser)
{
  DataLayer = UnitDL.GetInstance();
  SystemUser = aSystemUser;
}

        //****************************************************
        public virtual bool FetchForUnit(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForUnit, aDataSet, aKey);
        }
        public static string UnitX(int aKey)
        {
            UnitBL bl = new UnitBL(-1);
            DataRow r = bl.GetRow(aKey);
            if (r != null)
                return r["UnitBLX"].ToString();
            else
                return "";
        }
    }
}