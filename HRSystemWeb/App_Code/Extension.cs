using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for Static
/// </summary>
namespace HRSystemWeb
{
    public static class MyExtensions
    {
        public static string HtmlEncode(this string str)
        {
            return System.Web.HttpUtility.HtmlEncode(str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static DataTable Sort(this  DataTable dt, string sort, string order)
        {
            DataView dv = new DataView(dt);
            dv.Sort = sort + " " + order;
            dt = dv.ToTable();
            return dt;
        }
        public static DataTable Sort(this  DataTable dt, string sort)
        {
            DataView dv = new DataView(dt);
            dv.Sort = sort;
            dt = dv.ToTable();
            return dt;
        }
        public static void HideColumn(this  GridView grd, string Column)
        {
            //  var Columns = new List<string> { "Paymentmode", "class" };
            string Header = "";
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                if (grd.Columns[i].HeaderText == Column)
                    grd.Columns[i].Visible = false;
            }
        }

        public static void HideColumns(this  GridView grd, List<string> Columns)
        {
            //  var Columns = new List<string> { "Paymentmode", "class" };
            string Header = "";
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                Header = grd.Columns[i].HeaderText;
                var results = (from w in Columns
                               where w.Contains(Header)
                               select w).ToList<string>().Count;
                if (results > 0)
                {
                    grd.Columns[i].Visible = false;
                }
                else
                    grd.Columns[i].Visible = true;

            }
        }
    }
}