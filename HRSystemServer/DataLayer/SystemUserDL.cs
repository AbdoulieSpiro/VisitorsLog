using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{

    public class SystemUserDL : DataLayerBase, IDataLayer
    {
        private static SystemUserDL _instance = null;


        //****************************************************
        //****************************************************
        private SystemUserDL()
        {
            _sqlEntity = SqlEntity.tbSystemUser;
        }
        //****************************************************
        //****************************************************
        public static SystemUserDL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SystemUserDL();
            }
            return _instance;
        }


        //****************************************************
        //****************************************************
        //public new void Execute(DataLayerMessage aMessage)
        //{
        //    switch (aMessage.SqlAction)
        //    {
        //        case SqlAction.Save:
        //        case SqlAction.Fetch:
        //        case SqlAction.FetchAll:
        //            base.Execute(aMessage);
        //            break;
        //        case SqlAction.FetchForLogin:
        //        case SqlAction.FetchForLoginEmailAddress:
        //        case SqlAction.FetchForEmailAddress:
        //        case SqlAction.FetchForSearch:
        //        case SqlAction.FetchForSiteRoleType:
        //        case SqlAction.FetchForSite:
        //        case SqlAction.FetchForSystemUserSite:
        //        case SqlAction.FetchForSiteNotforProject:
        //        case SqlAction.FetchForSiteNotforGroup:
        //        case SqlAction.FetchForSiteNotforGroupAndProject:
        //        case SqlAction.FetchSystemUserForTaskAndSite:
        //        case SqlAction.FetchEmailAddressForSystemUser:
        //        case SqlAction.FetchUnAssignedUsersForProject:
        //        case SqlAction.FetchSystemUserGroupForSite:
        //        case SqlAction.FetchForSiteAndActive:
        //        case SqlAction.FetchForUserRole:
        //        case SqlAction.FetchForApprover:
        //        case SqlAction.FetchForSiteCompany:
        //        case SqlAction.FetchByResourceForSite:
        //        case SqlAction.FetchOverDueStatsForSystemUserSite:
        //        case SqlAction.FetchForOverDueStatsSystemUser:
        //        case SqlAction.FetchForSystemUserProfile:
        //        case SqlAction.FetchForNameInitial:
        //        case SqlAction.FetchForPreviousDSRDays:
        //        case SqlAction.FetchAllUsersForProject:
        //        case SqlAction.FetchForWeeklyActionAndAccomplishments:
        //            ExecuteFetchForAll(aMessage);
        //            break;
        //        default:
        //            throw new Exception("Could not execute " + SqlActionX(aMessage.SqlAction) + ". No such case item");
        //    }
        //}


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
                    result.Parameters.Add("@Site", SqlDbType.Int);
                    result.Parameters.Add("@IsActive", SqlDbType.Bit);
                    result.Parameters.Add("@IsLocked", SqlDbType.Bit);
                    result.Parameters.Add("@FailedLoginCount", SqlDbType.Int);
                    result.Parameters.Add("@LastLogin", SqlDbType.DateTime);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@LoginName", SqlDbType.VarChar);
                    result.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    result.Parameters.Add("@Password", SqlDbType.VarChar);
                    result.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    result.Parameters.Add("@LastName", SqlDbType.VarChar);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.Int);
                    result.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@UpdatedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    result.Parameters.Add("@DeletedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@DeletedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@ReasonForDeletion", SqlDbType.NVarChar);
                    result.Parameters.Add("@Department", SqlDbType.BigInt);
                    result.Parameters.Add("@ChangePassword", SqlDbType.Bit);
                    result.Parameters.Add("@SystemuserX", SqlDbType.VarChar);
                    result.Parameters.Add("@BranchID", SqlDbType.BigInt);
                    result.Parameters.Add("@BranchCode", SqlDbType.VarChar);
                    result.Parameters.Add("@UserOrderLevel", SqlDbType.BigInt);
                    result.Parameters.Add("@InvalidLogin", SqlDbType.Int);
                    result.Parameters.Add("@Status", SqlDbType.Char);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Update:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@Site", SqlDbType.Int);
                    result.Parameters.Add("@IsActive", SqlDbType.Bit);
                    result.Parameters.Add("@IsLocked", SqlDbType.Bit);
                    result.Parameters.Add("@FailedLoginCount", SqlDbType.Int);
                    result.Parameters.Add("@LastLogin", SqlDbType.DateTime);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@LoginName", SqlDbType.VarChar);
                    result.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    result.Parameters.Add("@Password", SqlDbType.VarChar);
                    result.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    result.Parameters.Add("@LastName", SqlDbType.VarChar);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.Int);
                    result.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@UpdatedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    result.Parameters.Add("@DeletedOnDate", SqlDbType.DateTime);
                    result.Parameters.Add("@DeletedBySystemUser", SqlDbType.BigInt);
                    result.Parameters.Add("@ReasonForDeletion", SqlDbType.NVarChar);
                    result.Parameters.Add("@Department", SqlDbType.BigInt);
                    result.Parameters.Add("@ChangePassword", SqlDbType.Bit);
                    result.Parameters.Add("@SystemuserX", SqlDbType.VarChar);
                    result.Parameters.Add("@BranchID", SqlDbType.BigInt);
                    result.Parameters.Add("@BranchCode", SqlDbType.VarChar);
                    result.Parameters.Add("@UserOrderLevel", SqlDbType.BigInt);
                    result.Parameters.Add("@InvalidLogin", SqlDbType.Int);
                    result.Parameters.Add("@Status", SqlDbType.Char);
                    AddReturnValueParameter(result.Parameters);
                    break;


                case SqlAction.Upsert:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.Int);
                    result.Parameters.Add("@Site", SqlDbType.Int);
                    result.Parameters.Add("@IsActive", SqlDbType.Bit);
                    result.Parameters.Add("@FailedLoginCount", SqlDbType.Int);

                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
                    result.Parameters.Add("@LoginEmailAddress", SqlDbType.VarChar);
                    result.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    result.Parameters.Add("@Password", SqlDbType.Binary);
                    result.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    result.Parameters.Add("@LastName", SqlDbType.VarChar);
                    result.Parameters.Add("@Phone", SqlDbType.VarChar);

                    result.Parameters.Add("@Department", SqlDbType.VarChar);
                    result.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);
                    result.Parameters.Add("@DateOfJoining", SqlDbType.DateTime);
                    result.Parameters.Add("@PermanentAddress", SqlDbType.VarChar);
                    result.Parameters.Add("@CorrespondanceAddress", SqlDbType.VarChar);
                    result.Parameters.Add("@EducationQaulification", SqlDbType.VarChar);
                    result.Parameters.Add("@Designation", SqlDbType.VarChar);
                    result.Parameters.Add("@CreatedBySystemUser", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Delete:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.Int);
                    AddReturnValueParameter(result.Parameters);
                    break;
                case SqlAction.Fetch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.Int);
                    break;
                case SqlAction.FetchAll:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    break;
                case SqlAction.FetchForLogin:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@BaseURL", SqlDbType.VarChar);
                    result.Parameters.Add("@LoginEmailAddress", SqlDbType.VarChar);
                    result.Parameters.Add("@Password", SqlDbType.VarChar);
                    break;
                case SqlAction.FetchForLoginEmailAddress:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@School", SqlDbType.Int);
                    result.Parameters.Add("@LoginEmailAddress", SqlDbType.VarChar);
                    break;
                case SqlAction.FetchForSchool:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@School", SqlDbType.Int);
                    break;
                case SqlAction.FetchForEmailAddress:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.Int);
                    break;
                case SqlAction.FetchForSearch:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SearchHint", SqlDbType.VarChar);
                    break;

                case SqlAction.FetchForSiteRoleType:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SiteRoleType", SqlDbType.Int);
                    break;

                case SqlAction.FetchForSite:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@Site", SqlDbType.Int);
                    break;
                case SqlAction.FetchEmailAddressForSystemUser:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.Int);
                    break;
                case SqlAction.FetchForUserRole:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.Int);
                    break;
                case SqlAction.FetchForSystemUserProfile:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@SystemUser", SqlDbType.Int);
                    break;
                case SqlAction.FetchForNameInitial:
                    result = DataLayerUtility.NewStoredProcCommand(sqlProcName);
                    result.Parameters.Add("@StartsWith", SqlDbType.VarChar);
                    result.Parameters.Add("@SiteId", SqlDbType.Int);
                    result.Parameters.Add("@SystemRoleType", SqlDbType.Int);
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

