using System;
using System.Data;
using System.Data.SqlClient;
namespace HRSystemServer.DataLayer
{
    public class PositionChangeDL : DataLayerBase, IDataLayer
    {
        private static PositionChangeDL _instance = null;
        private PositionChangeDL()
        {
            _sqlEntity = SqlEntity.tbPositionChange;
        }
        public static PositionChangeDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PositionChangeDL();
            }
            return _instance;
        }
   
        protected override SqlCommand GetCommand(SqlConnection aSqlConnection, SqlAction aSqlAction)
        {
            SqlCommand result = null;
            string sqlProcName = "pr" + ShortSqlEntityX + aSqlAction.ToString();
            switch (aSqlAction)
            {
                case SqlAction.Insert:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PositionX", SqlDbType.VarChar);
                    result.Parameters.Add("@PositionTo", SqlDbType.BigInt);
                    result.Parameters.Add("@Employee", SqlDbType.VarChar);
                    result.Parameters.Add("@Date", SqlDbType.DateTime);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PositionChange", SqlDbType.BigInt);
                    result.Parameters.Add("@PositionX", SqlDbType.VarChar);
                    result.Parameters.Add("@PositionFrom", SqlDbType.BigInt);
                    result.Parameters.Add("@PositionTo", SqlDbType.BigInt);
                    result.Parameters.Add("@Employee", SqlDbType.VarChar);
                    result.Parameters.Add("@Date", SqlDbType.DateTime);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PositionChange", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PositionChange", SqlDbType.Int);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchForReport:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Branch", SqlDbType.Int);
                    result.Parameters.Add("@Dept", SqlDbType.Int);
                    result.Parameters.Add("@Unit", SqlDbType.Int);
                    result.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    result.Parameters.Add("@EndDate", SqlDbType.DateTime);
                    break;
                case SqlAction.FetchForRegimentalNo:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@RegimentalNo", SqlDbType.VarChar);
                    break;
                case SqlAction.FetchForSearch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Search", SqlDbType.VarChar);
                    break;
                default:
                    throw new Exception("Could not GetCommand for " + aSqlAction.ToString() + ". No such case item");
            }
            foreach (SqlParameter item in result.Parameters)
                item.SourceColumn = item.ParameterName.Substring(1);
            result.Connection = aSqlConnection;
            return result;
        }
    }
}