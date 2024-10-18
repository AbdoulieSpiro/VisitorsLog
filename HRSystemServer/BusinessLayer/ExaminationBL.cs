using System;
using System.Data;
using System.Data.SqlClient;
using SMSServer.DataLayer;
namespace SMSServer.BusinessLayer
{
public class ExaminationBL : BusinessLayerBase
{
public ExaminationBL(int aSystemUser)
{
  DataLayer = ExaminationDL.GetInstance();
  SystemUser = aSystemUser;
}
}
}