using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{

    public class ControlMappingDL: DataLayerBase, IDataLayer
    {
        private static ControlMappingDL _instance  = null;


        //****************************************************
        //****************************************************
        private ControlMappingDL()
        {
            _sqlEntity = SqlEntity.tbControlMapping;
        }


        //****************************************************
        //****************************************************
        public static ControlMappingDL GetInstance()
        {
            if (_instance==null)
            {
                _instance = new ControlMappingDL();
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
                  result.Parameters.Add("@ControlMappingX", SqlDbType.VarChar);
				  result.Parameters.Add("@ControlMappingCode", SqlDbType.VarChar);
				  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Update:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@ControlMapping", SqlDbType.Int);
                  result.Parameters.Add("@PageMapping", SqlDbType.Int);
                  result.Parameters.Add("@ControlMappingX", SqlDbType.VarChar);
				  result.Parameters.Add("@ControlMappingCode", SqlDbType.VarChar);
				  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Upsert:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@ControlMapping", SqlDbType.Int);
                  result.Parameters.Add("@PageMapping", SqlDbType.Int);
                  result.Parameters.Add("@ControlMappingX", SqlDbType.VarChar);
				  result.Parameters.Add("@ControlMappingCode", SqlDbType.VarChar);
				  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Delete:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@ControlMapping", SqlDbType.Int);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Fetch:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@ControlMapping", SqlDbType.Int);
                  break;
              case SqlAction.FetchAll:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  break;
              case SqlAction.FetchForPageMapping:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@PageMapping", SqlDbType.Int);
                  break; 
                case SqlAction.FetchControl:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@PageCode", SqlDbType.VarChar);
                  result.Parameters.Add("@Role", SqlDbType.Int);
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
