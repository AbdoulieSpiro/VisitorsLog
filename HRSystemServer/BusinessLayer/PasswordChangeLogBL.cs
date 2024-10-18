using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;
namespace HRSystemServer.BusinessLayer
{
    public class PasswordChangeLogBL : BusinessLayerBase
    {
        public PasswordChangeLogBL(int aSystemUser)
        {
            DataLayer = PasswordChangeLogDL.GetInstance();
            SystemUser = aSystemUser;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PasswordChangeLog"></param>
        /// <param name="SystemUser"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool Upsert(int PasswordChangeLog, int SystemUser, string Password)
        {
            return Execute(SqlAction.Upsert, PasswordChangeLog, SystemUser, Password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="SystemUser"></param>
        /// <returns></returns>
        public bool FetchForSystemUser(DataSet ds, int SystemUser)
        {
            return Execute(SqlAction.FetchForSystemUser, ds, SystemUser);
        }
    }
}