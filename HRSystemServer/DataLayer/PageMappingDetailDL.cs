using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{

    public class PageMappingDetailDL : DataLayerBase, IDataLayer
    {
        private static PageMappingDetailDL _instance = null;


        //****************************************************
        //****************************************************
        private PageMappingDetailDL()
        {
            _sqlEntity = SqlEntity.tbPageMappingDetail;
        }


        //****************************************************
        //****************************************************
        public static PageMappingDetailDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PageMappingDetailDL();
            }
            return _instance;
        }





        //****************************************************
        //****************************************************
        protected override SqlCommand GetCommand(SqlConnection aSqlConnection, SqlAction aSqlAction)
        {
            SqlCommand result = null;
            string sqlProcName = "pr" + ShortSqlEntityX + aSqlAction.ToString();

            switch (aSqlAction)
            {
                case SqlAction.Insert:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PageMapping", SqlDbType.Int);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@PerformControlCheck", SqlDbType.Bit);
                    result.Parameters.Add("@DenyAccess", SqlDbType.Bit);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PageMappingDetail", SqlDbType.Int);
                    result.Parameters.Add("@PageMapping", SqlDbType.Int);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@PerformControlCheck", SqlDbType.Bit);
                    result.Parameters.Add("@DenyAccess", SqlDbType.Bit);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Upsert:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PageMappingDetail", SqlDbType.Int);
                    result.Parameters.Add("@PageMapping", SqlDbType.Int);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@PerformControlCheck", SqlDbType.Bit);
                    result.Parameters.Add("@DenyAccess", SqlDbType.Bit);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PageMappingDetail", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@PageMappingDetail", SqlDbType.Int);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchForPageSecurity:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@PageMappingX", SqlDbType.VarChar);
                    break;
                case SqlAction.FetchForPageMapping:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@PageMapping", SqlDbType.Int);
                    break;
                default:
                    throw new Exception("Could not GetCommand for " + aSqlAction.ToString() + ".  No such case item");
            }
            foreach (SqlParameter item in result.Parameters)
                item.SourceColumn = item.ParameterName.Substring(1);

            result.Connection = aSqlConnection;
            return result;
        }
    }
}
