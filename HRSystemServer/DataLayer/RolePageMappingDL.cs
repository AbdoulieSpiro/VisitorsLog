using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{

    public class RolePageMappingDL : DataLayerBase, IDataLayer
    {
        private static RolePageMappingDL _instance = null;



        //****************************************************
        //****************************************************
        private RolePageMappingDL()
        {
            _sqlEntity = SqlEntity.tbRolePageMapping;
        }


        //****************************************************
        //****************************************************
        public static RolePageMappingDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RolePageMappingDL();
            }
            return _instance;
        }


        //****************************************************
        //****************************************************
        public new void Execute(DataLayerMessage aMessage)
        {
            switch (aMessage.SqlAction)
            {
                case SqlAction.Save:
                case SqlAction.Fetch:
                case SqlAction.FetchAll:
                case SqlAction.FetchForRole:
                case SqlAction.FetchForApplicationPageSecurity:
                    base.Execute(aMessage);
                    break;
                case SqlAction.InsertUpdateMultiple:
                    base.ExecuteNonQuery(aMessage);
                    break;

                default:
                    throw new Exception("Could not execute " + SqlActionX(aMessage.SqlAction) + ". No such case item");
            }
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
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Upsert:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchForRole:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Role", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.FetchForApplicationPageSecurity:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.InsertUpdateMultiple:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@doc", SqlDbType.NText);
                    result.Parameters.Add("@Role", SqlDbType.Int);
                    result.Parameters.Add("@error", SqlDbType.NVarChar, 4000);
                    result.Parameters["@error"].Direction = ParameterDirection.Output;
                    AddReturnValueParameter(result.Parameters);
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
