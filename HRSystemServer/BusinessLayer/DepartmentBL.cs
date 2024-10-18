using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;
namespace HRSystemServer.BusinessLayer
{
public class DepartmentBL : BusinessLayerBase
{
public DepartmentBL(int aSystemUser)
{
  DataLayer = DepartmentDL.GetInstance();
  SystemUser = aSystemUser;
}

        //****************************************************
        public virtual bool FetchForDepartment(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.FetchForDepartment, aDataSet, aKey);
        }
        public static string DepartmentX(int aKey)
        {
            DepartmentBL bl = new DepartmentBL(-1);
            DataRow r = bl.GetRow(aKey);
            if (r != null)
                return r["DepartmentBLX"].ToString();
            else
                return "";
        }
    }
}