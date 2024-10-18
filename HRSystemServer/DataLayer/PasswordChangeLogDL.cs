using System;
using System.Data;
using System.Data.SqlClient;
namespace HRSystemServer.DataLayer
{
    public class PasswordChangeLogDL : DataLayerBase, IDataLayer
    {
        private static PasswordChangeLogDL _instance = null;
        private PasswordChangeLogDL()
        {
            _sqlEntity = SqlEntity.tbPasswordChangeLog;
        }
        public static PasswordChangeLogDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PasswordChangeLogDL();
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
                    result.Parameters.Add("@SystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@Password", SqlDbType.VarChar);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PasswordChangeLog", SqlDbType.BigInt);
                    result.Parameters.Add("@SystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@Password", SqlDbType.VarChar);
                    result.Parameters.Add("@ModifiedBySystemUser", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Upsert:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PasswordChangeLog", SqlDbType.BigInt);
                    result.Parameters.Add("@SystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@Password", SqlDbType.VarChar);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PasswordChangeLog", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PasswordChangeLog", SqlDbType.Int);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
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