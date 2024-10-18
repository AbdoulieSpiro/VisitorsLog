using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{

    public class SecurityProfileDL: DataLayerBase, IDataLayer
    {
        private static SecurityProfileDL _instance  = null;


        //****************************************************
        //****************************************************
        private SecurityProfileDL()
        {
            _sqlEntity = SqlEntity.tbSecurityProfile;
        }


        //****************************************************
        //****************************************************
        public static SecurityProfileDL GetInstance()
        {
            if (_instance==null)
            {
                _instance = new SecurityProfileDL();
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
				case SqlAction.Clone:
					Clone(aMessage);
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
                  result.Parameters.Add("@SecurityProfileX", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Update:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  result.Parameters.Add("@SecurityProfileX", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Upsert:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  result.Parameters.Add("@SecurityProfileX", SqlDbType.VarChar);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Delete:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  AddReturnValueParameter(result.Parameters);
                  break;
              case SqlAction.Fetch:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                  break;
              case SqlAction.FetchAll:
                  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                  break;
			  case SqlAction.Clone:
				  result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
				  result.Parameters.Add("@SecurityProfile", SqlDbType.Int);
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
		public void FetchForSession(DataLayerMessage aMessage)
		{
			SqlDataAdapter da           = GetDataAdapter(aMessage.SqlConnection);
			da.SelectCommand            = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
			aMessage.ApplyParams(da.SelectCommand.Parameters);
			da.Fill(aMessage.DataSet, SqlEntityX );
		}


		//****************************************************
		//****************************************************
		public void Clone(DataLayerMessage aMessage)
		{
			SqlCommand cmd = GetCommand(aMessage.SqlConnection,aMessage.SqlAction);
			aMessage.ApplyParams(cmd.Parameters);
			cmd.ExecuteNonQuery();
		}


    }
}
