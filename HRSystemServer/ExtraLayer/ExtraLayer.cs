using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.ExtraLayer
{
    public class ExtraLayer
    {
        public ExtraLayer()
        {
        }

        public static string GetAppSetting(string aKey)
        {
            return ConfigurationSettings.AppSettings[aKey];
        }

        public static string GetSQLConnection()
        {
            return GetAppSetting("ConnectionString");

        }

        public static DataSet RetriveDataSQL(string Query)
        {
            DataSet ds = new DataSet();
            string myConn = GetSQLConnection();

            SqlConnection myConnection = new SqlConnection(myConn);
            SqlCommand sqlCmd = new SqlCommand(Query);
            SqlDataAdapter Adapter = new SqlDataAdapter(Query, myConn);

            try
            {
                myConnection.Open();
                Adapter.Fill(ds);
            }
            catch
            {

            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    Adapter.SelectCommand.Connection.Close();
                    Adapter = null;
                }
            }
            return ds;


        }

        public static bool InsertDataSQL(string Query)
        {
            string myConn = GetSQLConnection();

            SqlConnection myConnection = new SqlConnection(myConn);
            myConnection.Open();
            SqlCommand sqlCmd = new SqlCommand(Query, myConnection);
            int rowUpd = sqlCmd.ExecuteNonQuery();
            if (rowUpd > 0)
            {
                myConnection.Close();
                myConnection.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
