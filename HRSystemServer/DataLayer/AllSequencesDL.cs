using System;
using System.Data;
using System.Data.SqlClient;
namespace HRSystemServer.DataLayer
{
    public class AllSequencesDL : DataLayerBase, IDataLayer
    {
        private static AllSequencesDL _instance = null;
        private AllSequencesDL()
        {
            _sqlEntity = SqlEntity.tbAllSequences;
        }
        public static AllSequencesDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AllSequencesDL();
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
                    result.Parameters.Add("@SeqName", SqlDbType.NVarChar);
                    result.Parameters.Add("@Seed", SqlDbType.Int);
                    result.Parameters.Add("@Incr", SqlDbType.Int);
                    result.Parameters.Add("@Currval", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@AllSequences", SqlDbType.Int);
                    result.Parameters.Add("@SeqName", SqlDbType.NVarChar);
                    result.Parameters.Add("@Seed", SqlDbType.Int);
                    result.Parameters.Add("@Incr", SqlDbType.Int);
                    result.Parameters.Add("@Currval", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@AllSequences", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@AllSequences", SqlDbType.Int);
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