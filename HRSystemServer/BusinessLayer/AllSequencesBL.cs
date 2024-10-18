using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;
namespace HRSystemServer.BusinessLayer
{
public class AllSequencesBL : BusinessLayerBase
{
public AllSequencesBL(int aSystemUser)
{
  DataLayer = AllSequencesDL.GetInstance();
  SystemUser = aSystemUser;
}
}
}