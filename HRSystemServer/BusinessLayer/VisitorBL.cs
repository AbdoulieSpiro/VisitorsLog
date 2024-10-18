using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;
namespace HRSystemServer.BusinessLayer
{
public class VisitorBL : BusinessLayerBase
{
public VisitorBL(int aSystemUser)
{
  DataLayer = VisitorDL.GetInstance();
  SystemUser = aSystemUser;
}
}
}