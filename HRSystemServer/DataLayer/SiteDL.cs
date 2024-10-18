using System;
using System.Data;
using System.Data.SqlClient;
namespace HRSystemServer.DataLayer
{
    public class SiteDL : DataLayerBase, IDataLayer
    {
        private static SiteDL _instance = null;
        private SiteDL()
        {
            _sqlEntity = SqlEntity.tbSite;
        }
        public static SiteDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SiteDL();
            }
            return _instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSqlConnection"></param>
        /// <param name="aSqlAction"></param>
        /// <returns></returns>
        protected override SqlCommand GetCommand(SqlConnection aSqlConnection, SqlAction aSqlAction)
        {
            SqlCommand result = null;
            string sqlProcName = "pr" + ShortSqlEntityX + aSqlAction.ToString();
            switch (aSqlAction)
            {
                case SqlAction.Insert:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@BaseURL", SqlDbType.VarChar);
                    result.Parameters.Add("@Theme", SqlDbType.VarChar);
                    result.Parameters.Add("@SiteX", SqlDbType.VarChar);
                    result.Parameters.Add("@LogoFileName1", SqlDbType.VarChar);
                    result.Parameters.Add("@IsOpenToPublic", SqlDbType.Bit);
                    result.Parameters.Add("@IsTestMode", SqlDbType.Bit);
                    result.Parameters.Add("@IsClosed", SqlDbType.Bit);
                    result.Parameters.Add("@IsTrial", SqlDbType.Bit);
                    result.Parameters.Add("@TrialDays", SqlDbType.Int);
                    result.Parameters.Add("@MaxFailedLoginCount", SqlDbType.Int);
                    result.Parameters.Add("@DefaultSiteRoleType", SqlDbType.BigInt);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;

                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Site", SqlDbType.BigInt);
                    result.Parameters.Add("@BaseURL", SqlDbType.VarChar);
                    result.Parameters.Add("@Theme", SqlDbType.VarChar);
                    result.Parameters.Add("@SiteX", SqlDbType.VarChar);
                    result.Parameters.Add("@LogoFileName1", SqlDbType.VarChar);
                    result.Parameters.Add("@IsOpenToPublic", SqlDbType.Bit);
                    result.Parameters.Add("@IsTestMode", SqlDbType.Bit);
                    result.Parameters.Add("@IsClosed", SqlDbType.Bit);
                    result.Parameters.Add("@MaxFailedLoginCount", SqlDbType.Int);
                    result.Parameters.Add("@DefaultSiteRoleType", SqlDbType.BigInt);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Site", SqlDbType.BigInt);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Site", SqlDbType.Int);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchForBaseURL:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@BaseURL", SqlDbType.VarChar);
                    break;
                case SqlAction.FetchForSchool:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Site", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
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