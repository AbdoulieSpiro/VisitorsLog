using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;
namespace HRSystemServer.BusinessLayer
{
public class PositionChangeBL : BusinessLayerBase
{
public PositionChangeBL(int aSystemUser)
{
  DataLayer = PositionChangeDL.GetInstance();
  SystemUser = aSystemUser;
}

        public virtual bool FetchForReport(DataSet aDataSet, int Branch, int Dept, int Unit, DateTime StartDate, DateTime EndDate)
        {
            return Execute(SqlAction.FetchForReport, aDataSet, Branch, Dept, Unit, StartDate, EndDate);
        }

        public virtual bool FetchForRegimentalNo(DataSet aDataSet, string Employee)
        {
            return Execute(SqlAction.FetchForRegimentalNo, aDataSet, Employee);
        }

        public virtual bool FetchForSearch(DataSet aDataSet, String Search)
        {
            return Execute(SqlAction.FetchForSearch, aDataSet, Search);
        }
    }
}