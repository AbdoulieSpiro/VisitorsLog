using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;
namespace HRSystemServer.BusinessLayer
{
    public class SiteBL : BusinessLayerBase
    {
        public SiteBL(int aSystemUser)
        {
            DataLayer = SiteDL.GetInstance();
            SystemUser = aSystemUser;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDataset"></param>
        /// <param name="aBaseURL"></param>
        /// <returns></returns>
        public virtual bool FetchForBaseURL(DataSet aDataset, string aBaseURL)
        {
            return Execute(SqlAction.FetchForBaseURL, aDataset, aBaseURL);
        }

        public virtual bool FetchForSite(DataSet aDataset, int Site)
        {
            return Execute(SqlAction.FetchForSite, aDataset, Site);
        }
    }
}