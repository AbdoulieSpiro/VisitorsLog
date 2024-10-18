using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{

    public class PageMappingDL: DataLayerBase, IDataLayer
    {
        private static PageMappingDL _instance  = null;


        //****************************************************
        //****************************************************
        private PageMappingDL()
        {
            _sqlEntity = SqlEntity.tbPageMapping;
        }


        //****************************************************
        //****************************************************
        public static PageMappingDL GetInstance()
        {
            if (_instance==null)
            {
                _instance = new PageMappingDL();
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
                  result.Parameters.Add("@PageMappingX", SqlDbType.VarChar);
                  result.Parameters.Add("@PageMappingXX", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Update:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@PageMapping", SqlDbType.Int);
                  result.Parameters.Add("@PageMappingX", SqlDbType.VarChar);
                  result.Parameters.Add("@PageMappingXX", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Upsert:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@PageMapping", SqlDbType.Int);
                  result.Parameters.Add("@PageMappingX", SqlDbType.VarChar);
                  result.Parameters.Add("@PageMappingXX", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Delete:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@PageMapping", SqlDbType.Int);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Fetch:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@PageMapping", SqlDbType.Int);
                  break;
              case SqlAction.FetchAll:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  break;
              default:
                  throw new Exception("Could not GetCommand for " + aSqlAction.ToString() + ".  No such case item");
          }
          foreach(SqlParameter item in result.Parameters)
              item.SourceColumn = item.ParameterName.Substring(1);

          result.Connection = aSqlConnection;
          return result;
        }
    }
}
