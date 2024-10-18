using System;
using System.Data;
using System.Data.SqlClient;
namespace HRSystemServer.DataLayer
{
    public class BranchDL : DataLayerBase, IDataLayer
    {
        private static BranchDL _instance = null;
        private BranchDL()
        {
            _sqlEntity = SqlEntity.tbBranch;
        }
        public static BranchDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BranchDL();
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
                    result.Parameters.Add("@BranchX", SqlDbType.Int);
                    result.Parameters.Add("@BranchXX", SqlDbType.VarChar);
                    result.Parameters.Add("@Address", SqlDbType.VarChar);
                    result.Parameters.Add("@Telephone", SqlDbType.VarChar);
                    result.Parameters.Add("@Fax", SqlDbType.VarChar);
                    result.Parameters.Add("@Email", SqlDbType.VarChar);
                    result.Parameters.Add("@Company", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Branch", SqlDbType.Int);
                    result.Parameters.Add("@BranchX", SqlDbType.Int);
                    result.Parameters.Add("@BranchXX", SqlDbType.VarChar);
                    result.Parameters.Add("@Address", SqlDbType.VarChar);
                    result.Parameters.Add("@Telephone", SqlDbType.VarChar);
                    result.Parameters.Add("@Fax", SqlDbType.VarChar);
                    result.Parameters.Add("@Email", SqlDbType.VarChar);
                    result.Parameters.Add("@Company", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Branch", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Branch", SqlDbType.Int);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchForBranch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Branch", SqlDbType.Int);
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