using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.DataLayer
{

    public class TableColumnDL : DataLayerBase, IDataLayer
    {
        private static TableColumnDL _instance = null;

        //****************************************************
        //****************************************************
        private TableColumnDL()
        {
            _sqlEntity = SqlEntity.tbTableColumn;
        }

        //****************************************************
        //****************************************************
        public static TableColumnDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TableColumnDL();
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
                    AddReturnValueParameter(result.Parameters);
                    break;

                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    AddReturnValueParameter(result.Parameters);
                    break;

                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    AddReturnValueParameter(result.Parameters);
                    break;

                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    AddReturnValueParameter(result.Parameters);
                    break;

                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;

                case SqlAction.FetchForPage:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Page", SqlDbType.Int);
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
