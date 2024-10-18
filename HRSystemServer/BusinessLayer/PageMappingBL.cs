using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class PageMappingBL: BusinessLayerBase
    {

        //****************************************************
        //****************************************************
        public PageMappingBL(int aSystemUser)
        {
            DataLayer = PageMappingDL.GetInstance();
            SystemUser = aSystemUser;
        }
    }
}
