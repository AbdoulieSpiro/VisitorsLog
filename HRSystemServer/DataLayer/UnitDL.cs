using System;
using System.Data;
using System.Data.SqlClient;
namespace HRSystemServer.DataLayer
{
    public class UnitDL : DataLayerBase, IDataLayer
    {
        private static UnitDL _instance = null;
        private UnitDL()
        {
            _sqlEntity = SqlEntity.tbUnit;
        }
        public static UnitDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UnitDL();
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
                    result.Parameters.Add("@UnitX", SqlDbType.Int);
                    result.Parameters.Add("@UnitXX", SqlDbType.VarChar);
                    result.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Unit", SqlDbType.Int);
                    result.Parameters.Add("@UnitX", SqlDbType.Int);
                    result.Parameters.Add("@UnitXX", SqlDbType.VarChar);
                    result.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Unit", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Unit", SqlDbType.Int);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchForUnit:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Unit", SqlDbType.Int);
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