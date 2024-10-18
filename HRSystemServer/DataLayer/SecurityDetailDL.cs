using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{

    public class SecurityDetailDL: DataLayerBase, IDataLayer
    {
        private static SecurityDetailDL _instance  = null;


        //****************************************************
        //****************************************************
        private SecurityDetailDL()
        {
            _sqlEntity = SqlEntity.tbSecurityDetail;
        }


        //****************************************************
        //****************************************************
        public static SecurityDetailDL GetInstance()
        {
            if (_instance==null)
            {
                _instance = new SecurityDetailDL();
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
                    base.Execute(aMessage);
                    break;
                case SqlAction.FetchForSecurityProfile:
                    FetchForSecurityProfile(aMessage);
                    break;
				case SqlAction.FetchForApplicationControlSecurity:
					FetchForApplicationControlSecurity(aMessage);
					break;
				case SqlAction.FetchForPageMapping:
					FetchForPageMapping(aMessage);
					break;
				case SqlAction.Upsert:
					Upsert(aMessage);
					break;
                default:
                    throw new Exception("Could not execute " + SqlActionX( aMessage.SqlAction ) + ". No such case item");
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
                  result.Parameters.Add("@ControlMapping", SqlDbType.Int);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  result.Parameters.Add("@ControlState", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Update:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityDetail", SqlDbType.Int);
                  result.Parameters.Add("@ControlMapping", SqlDbType.Int);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  result.Parameters.Add("@ControlState", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Upsert:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityDetail", SqlDbType.Int);
                  result.Parameters.Add("@ControlMapping", SqlDbType.Int);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  result.Parameters.Add("@ControlState", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Delete:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityDetail", SqlDbType.Int);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Fetch:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityDetail", SqlDbType.Int);
                  break;
              case SqlAction.FetchAll:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  break;
              case SqlAction.FetchForSecurityProfile:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  break;
			  case SqlAction.FetchForApplicationControlSecurity:
				  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
				  break;
			  case SqlAction.FetchForPageMapping:
				  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
				  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
				  result.Parameters.Add("@PageMapping",SqlDbType.Int);
				  break;
              default:
                  throw new Exception("Could not GetCommand for " + aSqlAction.ToString() + ".  No such case item");
          }
          foreach(SqlParameter item in result.Parameters)
              item.SourceColumn = item.ParameterName.Substring(1);

          result.Connection = aSqlConnection;
          return result;
        }


        //****************************************************
        //****************************************************
        public void FetchForSecurityProfile(DataLayerMessage aMessage)
        {
            SqlDataAdapter da           = GetDataAdapter(aMessage.SqlConnection);
            da.SelectCommand            = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
            aMessage.ApplyParams(da.SelectCommand.Parameters);
            da.Fill(aMessage.DataSet, SqlEntityX );
        }
	
		public void FetchForApplicationControlSecurity(DataLayerMessage aMessage)
		{
			SqlDataAdapter da           = GetDataAdapter(aMessage.SqlConnection);
			da.SelectCommand            = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
			//aMessage.ApplyParams(da.SelectCommand.Parameters);
			da.Fill(aMessage.DataSet, SqlEntityX );
		}

		public void FetchForPageMapping(DataLayerMessage aMessage)
		{
			SqlDataAdapter da           = GetDataAdapter(aMessage.SqlConnection);
			da.SelectCommand            = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
			aMessage.ApplyParams(da.SelectCommand.Parameters);
			da.Fill(aMessage.DataSet, SqlEntityX );
		}

		public void Upsert(DataLayerMessage aMessage)
		{
			SqlCommand com = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
			com.Connection = aMessage.SqlConnection;
			aMessage.ApplyParams(com.Parameters);
			com.ExecuteNonQuery();
			aMessage.Key = (int)com.Parameters[ReturnValueParamName].Value;
		}



	}
}
