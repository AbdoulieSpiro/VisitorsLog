using System;
using System.Data;
using System.Data.SqlClient;
namespace HRSystemServer.DataLayer
{
    public class VisitorDL : DataLayerBase, IDataLayer
    {
        private static VisitorDL _instance = null;
        private VisitorDL()
        {
            _sqlEntity = SqlEntity.tbVisitor;
        }
        public static VisitorDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new VisitorDL();
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
                    result.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    result.Parameters.Add("@LastName", SqlDbType.VarChar);
                    result.Parameters.Add("@Address", SqlDbType.VarChar);
                    result.Parameters.Add("@Address2", SqlDbType.VarChar);
                    result.Parameters.Add("@Email", SqlDbType.VarChar);
                    result.Parameters.Add("@DOB", SqlDbType.DateTime);
                    result.Parameters.Add("@Gender", SqlDbType.VarChar);
                    result.Parameters.Add("@Photo", SqlDbType.VarChar);
                    result.Parameters.Add("@Nationality", SqlDbType.VarChar);
                    result.Parameters.Add("@Telephone", SqlDbType.VarChar);
                    result.Parameters.Add("@Mobile", SqlDbType.VarChar);
                    result.Parameters.Add("@CompanyFrom", SqlDbType.VarChar);
                    result.Parameters.Add("@Reason", SqlDbType.VarChar);
                    result.Parameters.Add("@ContactPerson", SqlDbType.VarChar);
                    result.Parameters.Add("@BranchCode", SqlDbType.BigInt);
                    result.Parameters.Add("@Branch", SqlDbType.VarChar);
                    result.Parameters.Add("@DepartmentCode", SqlDbType.BigInt);
                    result.Parameters.Add("@Department", SqlDbType.VarChar);
                    result.Parameters.Add("@UnitCode", SqlDbType.Int);
                    result.Parameters.Add("@Unit", SqlDbType.VarChar);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    result.Parameters.Add("@ModifiedBy", SqlDbType.BigInt);
                    result.Parameters.Add("@ModifiedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@DeletedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@DeletedOnDate", SqlDbType.NChar);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Visitor", SqlDbType.Int);
                    result.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    result.Parameters.Add("@LastName", SqlDbType.VarChar);
                    result.Parameters.Add("@Address", SqlDbType.VarChar);
                    result.Parameters.Add("@Address2", SqlDbType.VarChar);
                    result.Parameters.Add("@Email", SqlDbType.VarChar);
                    result.Parameters.Add("@DOB", SqlDbType.DateTime);
                    result.Parameters.Add("@Gender", SqlDbType.VarChar);
                    result.Parameters.Add("@Photo", SqlDbType.VarChar);
                    result.Parameters.Add("@Nationality", SqlDbType.VarChar);
                    result.Parameters.Add("@Telephone", SqlDbType.VarChar);
                    result.Parameters.Add("@Mobile", SqlDbType.VarChar);
                    result.Parameters.Add("@CompanyFrom", SqlDbType.VarChar);
                    result.Parameters.Add("@Reason", SqlDbType.VarChar);
                    result.Parameters.Add("@ContactPerson", SqlDbType.VarChar);
                    result.Parameters.Add("@BranchCode", SqlDbType.BigInt);
                    result.Parameters.Add("@Branch", SqlDbType.VarChar);
                    result.Parameters.Add("@DepartmentCode", SqlDbType.BigInt);
                    result.Parameters.Add("@Department", SqlDbType.VarChar);
                    result.Parameters.Add("@UnitCode", SqlDbType.Int);
                    result.Parameters.Add("@Unit", SqlDbType.VarChar);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    result.Parameters.Add("@ModifiedBy", SqlDbType.BigInt);
                    result.Parameters.Add("@ModifiedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@DeletedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@DeletedOnDate", SqlDbType.NChar);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Visitor", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Visitor", SqlDbType.Int);
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