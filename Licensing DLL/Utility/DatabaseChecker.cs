using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LicensingDLL
{
    class DatabaseChecker
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ProductKey"></param>
        ///// <param name="ApplicationCode"></param>
        ///// <param name="ClientName"></param>
        ///// <param name="Address"></param>
        ///// <param name="City"></param>
        ///// <param name="State"></param>
        ///// <param name="Zip"></param>
        ///// <param name="Country"></param>
        ///// <param name="PhoneNo"></param>
        ///// <param name="Email"></param>
        ///// <returns></returns>
        //public DataTable ProcessRegistration(string ProductKey)
        //{
        //    DataSet ds = new DataSet("Registration");
        //    DataRow newRow = null;

        //    string Query = "Select * from tbLicenseDetails Where ProductKey='" + ProductKey + "'";
        //    ds = FillDataSet(Query);
        //    ds.Tables[0].Columns.Add("IsValidProductKey", typeof(bool));
        //    ds.Tables[0].Columns.Add("Expired", typeof(bool));

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        int Copies = WinUtility.Cast(ds.Tables[0].Rows[0]["Copies"], 1);
        //        int CopiesUsed = WinUtility.Cast(ds.Tables[0].Rows[0]["CopiesUsed"], -1);


        //        if (CopiesUsed >= Copies)
        //        {



        //            ds.Tables[0].Rows[0]["IsValidProductKey"] = true;
        //            ds.Tables[0].Rows[0]["Expired"] = true;
        //        }
        //        else
        //        {
        //            Query = "Update tbLicenseDetails set CopiesUsed=isnull(CopiesUsed,0)+1  Where ProductKey='" + ProductKey + "'";
        //            ExecuteSQL(Query);
        //            ds.Tables[0].Rows[0]["IsValidProductKey"] = true;
        //            ds.Tables[0].Rows[0]["Expired"] = false;
        //        }


        //    }
        //    else
        //    {
        //        newRow = ds.Tables[0].NewRow();
        //        newRow["IsValidProductKey"] = false;
        //        newRow["Expired"] = false;
        //        ds.Tables[0].Rows.Add(newRow);
        //    }
        //    newRow = null;
        //    return ds.Tables[0];

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="SQL"></param>
        ///// <returns></returns>
        //private DataSet FillDataSet(string SQL)
        //{
        //    DataSet dt = new DataSet();
        //    SqlConnection con = new SqlConnection("server=ishtiaq99.db.2464223.hostedresource.com; Database=ishtiaq99; uid=ishtiaq99; pwd=GuruKul34;");
        //    SqlCommand cmd = new SqlCommand(SQL);
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    con.Close();
        //    con = null;
        //    cmd = null;
        //    da = null;
        //    return dt;
        //}

        //private void ExecuteSQL(string SQL)
        //{

        //    SqlConnection con = new SqlConnection("server=ishtiaq99.db.2464223.hostedresource.com; Database=ishtiaq99; uid=ishtiaq99; pwd=GuruKul34;");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(SQL, con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}



    }
}
