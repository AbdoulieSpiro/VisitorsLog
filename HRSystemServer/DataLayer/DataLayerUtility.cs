using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HRSystemServer.DataLayer
{
    public class DataLayerUtility
    {
        public DataLayerUtility()
        {
        }

        public static SqlDataAdapter NewDataAdapter()
        {
            return new SqlDataAdapter();
        }
        public static SqlCommand NewSqlCommand()
        {
            return new SqlCommand();
        }
        public static SqlCommand NewSqlStatmentCommand(string aStoredProc)
        {
            SqlCommand result = new SqlCommand(aStoredProc);
            result.CommandType = CommandType.Text;
            return result;
        }

        public static SqlCommand NewStoredProcCommand(string aStoredProc)
        {
            SqlCommand result = new SqlCommand(aStoredProc);
            result.CommandType = CommandType.StoredProcedure;
            return result;
        }


    }
}
