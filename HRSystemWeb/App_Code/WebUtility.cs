using System;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HRSystemServer.BusinessLayer;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using HRSystemWeb;
using System.Web.Caching;
using System.Text;
using NetSpell.SpellChecker.Dictionary;
using System.Net;


namespace HRSystemWeb
{
    public interface ISupportSave
    {

        void Save();

    }
    public enum BasicRoleType
    {
        SuperAdministrator = 1,
        Administrator = 2,
        User = 3,
    }

    public enum Datatype
    {
        String = 1,
        Date = 2,
        Int = 3,
        Bool = 4,
    }
    /// <summary>
    /// 
    /// </summary>
    /// 
    public class WebUtility
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ControlTypes
        {
            None = 0,
            TextBox = 1,
            DropDownList = 2,
            CheckBox = 3,
            ListBox = 4
        }
        /// <summary>
        /// 
        /// </summary>
        public enum EventType
        {
            undefined = 1,
            request = 2,
            dataerror = 3,
            pageerror = 4
        }

        public enum DateFormat
        {
            WithCurrentTime = 0,
            WithOutTime = 1,
            WithBeginingOfTheDay = 2,
            WithEndOfTheDay = 3
        }


        /// <summary>
        /// 
        /// </summary>
        private WebUtility()
        {
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="aKey"></param>
        ///// <param name="aDefault"></param>
        ///// <returns></returns>
        //public static string GetPaymentCode(int aKey, string aDefault)
        //{
        //    string result;
        //    PaymentTypeBL bl = new PaymentTypeBL(SessionContext.SystemUser);
        //    DataSet ds = new DataSet();
        //    bl.Fetch(ds, aKey);

        //    try
        //    {
        //        result = ds.Tables[0].Rows[0]["PaymentTypeCode"].ToString();
        //    }
        //    catch
        //    {
        //        result = aDefault;
        //    }
        //    bl = null;
        //    ds = null;
        //    return result;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="aPaymentCode"></param>
        ///// <param name="aDefault"></param>
        ///// <returns></returns>
        //public static int GetPaymentId(string aPaymentCode, int aDefault)
        //{
        //    int result;
        //    PaymentTypeBL bl = new PaymentTypeBL(SessionContext.SystemUser);
        //    DataSet ds = new DataSet();
        //    bl.FetchForPaymentCode(ds, aPaymentCode);

        //    try
        //    {
        //        result = (int)ds.Tables[0].Rows[0]["PaymentType"];
        //    }
        //    catch
        //    {
        //        result = aDefault;
        //    }
        //    bl = null;
        //    ds = null;
        //    return result;
        //}

        /// <param name="aSchool"></param>
        /// <param name="aInputControl"></param>
        /// <param name="aFileName"></param>
        /// <param name="aRemove"></param>
        /// <returns></returns>
        public static string SaveUploadVideoFile(int aSchool, HtmlInputFile aInputControl, object aFileName, bool aRemove)
        {
            return SaveUploadVideo(aInputControl, aFileName, GetSchoolFileFolder(aSchool) + "\\video\\", aRemove);
        }

        public static string SaveUploadVideoThumb(int aSchool, HtmlInputFile aInputControl, object aFileName, bool aRemove)
        {
            return SaveUploadVideo(aInputControl, aFileName, GetSchoolFileFolder(aSchool), aRemove);
        }
        #region "GET SMALL IMAGE RELATED TO UPLOADED DOCUMENT SHARED"
        public static string GetSmallImagePathShared(string strFileName, string Type, string Theme)
        {

            string strExtension;
            try
            {
                if (Type == "False")
                {
                    strExtension = new System.IO.FileInfo(strFileName).Extension;
                    switch (strExtension.ToLower())
                    {
                        case ".doc":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallDoc_shared.gif";
                        case ".pdf":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallPDF_shared.gif";
                        case ".xls":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallXLS_shared.gif";
                        case ".css":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallCSS_shared.gif";
                        case ".ppt":
                        case ".pps":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallPPT_shared.gif";
                        case ".jpg":
                        case ".gif":
                        case ".png":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallJPG_shared.gif";
                        case ".zip":
                        case ".rar":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallZip_shared.gif";
                        default:
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallDefault_shared.gif";
                    }
                }
                else
                {
                    return "~/App_Themes/" + Theme + "/TPCImages/SmallFolder_shared.gif";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "GET SMALL IMAGE RELATED TO UPLOADED DOCUMENT"
        public static string GetImagePathSmallIcon(string strFileName, string Type, string Theme)
        {

            string strExtension;
            try
            {
                if (Type == "False")
                {
                    strExtension = new System.IO.FileInfo(strFileName).Extension;
                    switch (strExtension.ToLower())
                    {
                        case ".doc":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallDoc.gif";
                        case ".pdf":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallPDF.gif";
                        case ".xls":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallXLS.gif";
                        case ".css":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallCSS.gif";
                        case ".ppt":
                        case ".pps":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallPPT.gif";
                        case ".jpg":
                        case ".gif":
                        case ".png":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallJPG.gif";
                        case ".zip":
                        case ".rar":
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallZip.gif";
                        default:
                            return "~/App_Themes/" + Theme + "/TPCImages/SmallDefault.gif";
                    }
                }
                else
                {
                    return "~/App_Themes/" + Theme + "/TPCImages/SmallFolder.gif";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "GET MEDIUM IMAGE RELATED TO UPLOADED DOCUMENT"
        public static string GetImagePathMediumIcon(string strFileName, string Theme)
        {

            string strExtension;
            try
            {

                strExtension = new System.IO.FileInfo(strFileName).Extension;
                switch (strExtension.ToLower())
                {
                    case ".doc":
                    case ".docx":
                        return "~/App_Themes/" + Theme + "/images/MediumDoc.gif";
                    case ".pdf":
                        return "~/App_Themes/" + Theme + "/images/MediumPDF.gif";
                    case ".xls":
                    case ".xlsx":
                        return "~/App_Themes/" + Theme + "/images/MediumXLS.gif";
                    case ".css":
                        return "~/App_Themes/" + Theme + "/images/MediumCSS.gif";
                    case ".ppt":
                    case ".pps":
                        return "~/App_Themes/" + Theme + "/images/MediumPPT.gif";
                    case ".zip":
                    case ".rar":
                        return "~/App_Themes/" + Theme + "/images/MediumZip.gif";
                    case ".png":
                    case ".jpg":
                    case ".gif":
                    case ".bmp":
                        return "~/App_Themes/" + Theme + "/images/MediumJPG.png";
                    default:
                        return "~/App_Themes/" + Theme + "/images/MediumDefault.gif";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "GET LARGE IMAGE RELATED TO UPLOADED DOCUMENT"
        public static string GetImagePathLargeIcon(string strFileName, string Theme)
        {

            string strExtension;
            try
            {

                strExtension = new System.IO.FileInfo(strFileName).Extension;
                switch (strExtension.ToLower())
                {
                    case ".doc":
                    case ".docx":
                        return "~/App_Themes/" + Theme + "/images/LargeDoc.gif";
                    case ".pdf":
                        return "~/App_Themes/" + Theme + "/images/LargePDF.gif";
                    case ".xls":
                    case ".xlsx":
                        return "~/App_Themes/" + Theme + "/images/LargeXLS.gif";
                    case ".css":
                        return "~/App_Themes/" + Theme + "/images/LargeCSS.gif";
                    case ".ppt":
                    case ".pps":
                        return "~/App_Themes/" + Theme + "/images/LargePPT.gif";
                    case ".zip":
                    case ".rar":
                        return "~/App_Themes/" + Theme + "/images/LargeZip.gif";
                    case ".png":
                    case ".jpg":
                    case ".gif":
                    case ".bmp":
                        return "~/App_Themes/" + Theme + "/images/LargeJPG.png";
                    default:
                        return "~/App_Themes/" + Theme + "/images/LargeDefault.gif";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public static string SaveUploadedDoc(FileUpload file, string EMP)
        {

            string NewFileName = GetUniqueFileName(Path.GetExtension(file.FileName));
            string NewFilePath = GetSiteFileFolder(EMP) + "\\" + NewFileName;

            if (file.PostedFile != null && file.FileName != "")
            {
                file.SaveAs(NewFilePath);
            }
            return NewFileName;
        }

        public static string SaveUploadedDoc(FileUpload file, string EMP, string NewFileName)
        {
            //string NewFileName = GetUniqueFileName(Path.GetExtension(file.FileName));
            string NewFilePath = GetSiteFileFolder(EMP) + "\\" + NewFileName;

            if (file.PostedFile != null && file.FileName != "")
            {
                file.SaveAs(NewFilePath);
            }
            return NewFileName;
        }

        public static string GetSiteFileFolder(string Emp)
        {
            string result = "";
            result = BusinessLayerUtility.GetAppSetting("siteFileFolder") + Emp.ToString();
            if (!System.IO.Directory.Exists(result))
            {
                System.IO.Directory.CreateDirectory(result);
            }
            return result;
        }

        public static bool CheckSpelling(string stringToCheck)
        {
            NetSpell.SpellChecker.Spelling SpellChecker;
            NetSpell.SpellChecker.Dictionary.WordDictionary WordDictionary;
            string folderName = "dic";

            HttpRequest request = new HttpRequest("new", "http://localhost/", "new");
            // get dictionary from cache
            WordDictionary = (WordDictionary)HttpContext.Current.Cache["WordDictionary"];
            if (WordDictionary == null)
            {

                WordDictionary = new NetSpell.SpellChecker.Dictionary.WordDictionary();
                WordDictionary.EnableUserFile = false;

                folderName = HttpContext.Current.Server.MapPath(Path.Combine(request.ApplicationPath, folderName));
                WordDictionary.DictionaryFolder = folderName;

                // Store the Dictionary in cache
                HttpContext.Current.Cache.Insert("WordDictionary", WordDictionary, new CacheDependency(Path.Combine(folderName, WordDictionary.DictionaryFile)));
            }
            SpellChecker = new NetSpell.SpellChecker.Spelling();
            SpellChecker.ShowDialog = false;
            SpellChecker.Dictionary = WordDictionary;
            if (!SpellChecker.SpellCheck(stringToCheck))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string RightSubstring(string aValue, int aBytes)
        {
            return aValue.Substring(aValue.Length - aBytes, aBytes);
        }
        // integer conversion

        public static object ValueToSQLInteger(object aValue)
        {
            return ValueToSQLInteger(aValue, DBNull.Value);
        }

        public static int Cast(Object aValue, int aOnError)
        {
            int result;
            try
            {
                result = int.Parse(aValue.ToString());
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }

        public static string Cast(Object aValue, string aOnError)
        {
            string result;
            try
            {
                result = Convert.ToString(aValue);
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }

        public static double Cast(Object aValue, double aOnError)
        {
            double result;
            try
            {
                result = double.Parse(aValue.ToString());
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static decimal Cast(Object aValue, decimal aOnError)
        {
            decimal result;
            try
            {
                result = decimal.Parse(aValue.ToString());
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static DateTime Cast(Object aValue, DateTime aOnError)
        {
            DateTime result;
            try
            {
                result = DateTime.Parse(aValue.ToString());
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static DateTime EndOfTheYear(Object aValue, DateTime aOnError)
        {
            DateTime result;
            try
            {
                result = DateTime.Parse("12/31" + DateTime.Parse(aValue.ToString()).Year);
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static bool Cast(Object aValue, bool aOnError)
        {
            bool result;
            try
            {
                result = ((bool)aValue) ? true : false;
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static object ValueToSQLInteger(object aValue, object aOnError)
        {
            object result;
            try
            {
                string buffer;
                buffer = aValue.ToString().Trim();
                result = int.Parse(buffer);
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        // Date conversion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static object ValueToSQLDate(object aValue)
        {
            return ValueToSQLDate(aValue, DBNull.Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static object ValueToSQLDate(object aValue, object aOnError)
        {
            object result;
            try
            {
                string buffer;
                buffer = aValue.ToString().Trim();
                result = DateTime.Parse(buffer);
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        // Decimal conversion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static object ValueToSQLDecimal(object aValue)
        {

            return ValueToSQLDecimal(aValue, DBNull.Value);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static object ValueToSQLDecimal(object aValue, object aOnError)
        {
            object result;
            try
            {
                string buffer;
                buffer = aValue.ToString().Trim();
                result = Decimal.Parse(buffer);
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        // Money conversion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static object ValueToSQLMoney(object aValue)
        {
            return ValueToSQLMoney(aValue, DBNull.Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static object ValueToSQLMoney(object aValue, object aOnError)
        {
            object result;
            try
            {
                string buffer;
                buffer = aValue.ToString().Trim();
                result = Decimal.Parse(buffer);
            }
            catch
            {
                result = aOnError;
            }
            return result;
        }
        // ** Value to URL
        public static object ValueToURL(object aValue)
        {
            object result;
            try
            {
                if (!aValue.ToString().StartsWith("http"))
                    result = "http:\\\\" + aValue.ToString();
                else
                    result = aValue;
            }
            catch
            {
                result = "";
            }

            return result;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static string ValueToHTML(object aValue)
        {

            string result;
            try
            {
                result = aValue.ToString().Replace("[MORE]", String.Empty).Replace("[CODE]", "<code>").Replace("[/CODE]", "</code>");
            }
            catch
            {
                result = "";
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aBusinessLayer"></param>
        public static void FillDropDownList(DropDownList aDropDownList, BusinessLayerBase aBusinessLayer)
        {
            FillDropDownList(aDropDownList, aBusinessLayer, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aBusinessLayer"></param>
        /// <param name="aDefaultValue"></param>
        public static void FillDropDownList(DropDownList aDropDownList, BusinessLayerBase aBusinessLayer, Object aDefaultValue)
        {
            FillDropDownList(aDropDownList, aBusinessLayer, aBusinessLayer.ShortSqlEntityX + "X", aBusinessLayer.ShortSqlEntityX, aDefaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aBusinessLayer"></param>
        /// <param name="aDisplayFieldName"></param>
        /// <param name="aDefaultValue"></param>
        public static void FillDropDownList(DropDownList aDropDownList, BusinessLayerBase aBusinessLayer, string aDisplayFieldName, Object aDefaultValue)
        {
            FillDropDownList(aDropDownList, aBusinessLayer, aDisplayFieldName, aBusinessLayer.ShortSqlEntityX, aDefaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aBusinessLayer"></param>
        /// <param name="aDisplayFieldName"></param>
        /// <param name="aValueFieldName"></param>
        /// <param name="aDefaultValue"></param>
        public static void FillDropDownList(DropDownList aDropDownList, BusinessLayerBase aBusinessLayer, string aDisplayFieldName, string aValueFieldName, Object aDefaultValue)
        {
            DataSet buffer = new DataSet();
            aBusinessLayer.FetchAll(buffer);
            FillDropDownList(aDropDownList, buffer.Tables[0], aDisplayFieldName, aValueFieldName, aDefaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static DateTime FromIndianDate(object aValue)
        {
            //string[] dat = aValue.ToString().Replace(".", "-").Replace("/", "-").Split('-');

            return WebUtility.Cast(aValue.ToString(), System.DateTime.Now);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aDataTable"></param>
        /// <param name="aDisplayFieldName"></param>
        /// <param name="aValueFieldName"></param>
        public static void FillDropDownList(DropDownList aDropDownList, DataTable aDataTable, string aDisplayFieldName, string aValueFieldName)
        {
            FillDropDownList(aDropDownList, aDataTable, aDisplayFieldName, aValueFieldName, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aDataTable"></param>
        /// <param name="aDisplayFieldName"></param>
        /// <param name="aValueFieldName"></param>
        /// <param name="aDefaultValue"></param>
        public static void FillDropDownList(DropDownList aDropDownList, DataTable aDataTable, string aDisplayFieldName, string aValueFieldName, Object aDefaultValue)
        {
            aDropDownList.Items.Clear();
            if (aDataTable.Columns.Contains(aDisplayFieldName) && aDataTable.Columns.Contains(aValueFieldName))
            {
                foreach (DataRow item in aDataTable.Rows)
                    aDropDownList.Items.Add(new ListItem(item[aDisplayFieldName].ToString(), item[aValueFieldName].ToString()));

                SetDropDownListValue(aDropDownList, aDefaultValue);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aValue"></param>
        /// <param name="aDefaultValue"></param>
        public static void FillDropDownList(DropDownList aDropDownList, String[] aValue, String aDefaultValue)
        {
            int i;
            for (i = 0; i <= aValue.GetUpperBound(0); i++)
            {
                aDropDownList.Items.Add(new ListItem(aValue[i].ToString(), aValue[i].ToString()));
            }
            WebUtility.SetDropDownListValue(aDropDownList, aDefaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aValue"></param>
        public static void SetDropDownListValue(DropDownList aDropDownList, object aValue)
        {
            if (aValue != null)
            {
                if (aValue != DBNull.Value)
                {
                    try
                    {
                        string s;
                        s = aValue.ToString();
                        SetDropDownListValue(aDropDownList, s, false);
                    }
                    catch { }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aValue"></param>
        public static void SetDropDownListValue(DropDownList aDropDownList, string aValue)
        {
            SetDropDownListValue(aDropDownList, aValue, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aValue"></param>
        /// <param name="aAddIfNotFound"></param>
        public static void SetDropDownListValue(DropDownList aDropDownList, string aValue, bool aAddIfNotFound)
        {
            aDropDownList.SelectedIndex = -1;
            try
            {
                aDropDownList.SelectedValue = aValue;
            }
            catch
            {
                if (aAddIfNotFound)
                {
                    aDropDownList.Items.Add(new ListItem(aValue, aValue));
                    aDropDownList.SelectedValue = aValue;
                }
                else
                    aDropDownList.SelectedIndex = -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <returns></returns>
        public static object GetDropDownListValue(DropDownList aDropDownList)
        {
            return GetDropDownListValue(aDropDownList, DBNull.Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aDefault"></param>
        /// <returns></returns>
        public static object GetDropDownListValue(DropDownList aDropDownList, object aDefault)
        {
            object result;
            try
            {
                result = int.Parse(aDropDownList.SelectedValue);
            }
            catch
            {
                result = aDefault;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aDefault"></param>
        /// <returns></returns>
        public static int GetDropDownListValue(DropDownList aDropDownList, int aDefault)
        {
            int result;
            try
            {
                result = int.Parse(aDropDownList.SelectedValue);
            }
            catch
            {
                result = aDefault;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDropDownList"></param>
        /// <param name="aDefault"></param>
        /// <returns></returns>
        public static string GetDropDownListValue(DropDownList aDropDownList, string aDefault)
        {
            string result;
            try
            {
                result = aDropDownList.SelectedValue;
            }
            catch
            {
                result = aDefault;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCustomValidator"></param>
        /// <param name="aArgs"></param>
        public static void ValidateDate(object aCustomValidator, ServerValidateEventArgs aArgs)
        {
            ValidateDate(aCustomValidator, aArgs, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCustomValidator"></param>
        /// <param name="aArgs"></param>
        /// <param name="aMessage"></param>
        public static void ValidateDate(object aCustomValidator, ServerValidateEventArgs aArgs, string aMessage)
        {
            try
            {
                DateTime.Parse(aArgs.Value);
                aArgs.IsValid = true;
            }
            catch
            {
                aArgs.IsValid = false;
                if (!aMessage.Equals(""))
                    ((CustomValidator)aCustomValidator).ErrorMessage = aMessage;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCustomValidator"></param>
        /// <param name="aArgs"></param>
        public static void ValidateCurrency(object aCustomValidator, ServerValidateEventArgs aArgs)
        {
            ValidateCurrency(aCustomValidator, aArgs, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCustomValidator"></param>
        /// <param name="aArgs"></param>
        /// <param name="aMessage"></param>
        public static void ValidateCurrency(object aCustomValidator, ServerValidateEventArgs aArgs, string aMessage)
        {
            try
            {
                Decimal.Parse(aArgs.Value);
                aArgs.IsValid = true;
            }
            catch
            {
                aArgs.IsValid = false;
                if (!aMessage.Equals(""))
                    ((CustomValidator)aCustomValidator).ErrorMessage = aMessage;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSchool"></param>
        /// <returns></returns>
        public static string GetImageURL(int aSite)
        {
            string result = "";
            result = BusinessLayerUtility.GetAppSetting("ImageURL") + aSite.ToString();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSchool"></param>
        /// <returns></returns>
        public static string GetSchoolFileFolder(int aSchool)
        {
            string result = "";
            result = BusinessLayerUtility.GetAppSetting("SchoolFileFolder") + aSchool.ToString();
            return result;
        }

        public static string GetFileURL(string Emp)
        {
            string result = "";
            result = BusinessLayerUtility.GetAppSetting("FileURL") + Emp;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSchool"></param>
        /// <param name="aFileName"></param>
        /// <returns></returns>
        public static string GetImageFileURL(int aSite, object aFileName)
        {
            string result = "";
            if (aFileName != null && aFileName != DBNull.Value && !aFileName.ToString().Equals(""))
            {
                result = GetImageURL(aSite) + "/" + aFileName.ToString();

            }
            return result;
        }


        public static bool SetImageURL(int aSchool, Image aImageControl, object aFileName)
        {
            bool result = false;
            string f = GetImageFileURL(aSchool, aFileName);
            if (f.Length > 0)
            {
                result = true;
                aImageControl.ImageUrl = f;
            }
            return result;
        }

        public static string HomePage(Page aPage)
        {
            string[] a = aPage.Request.Path.Split("/".ToCharArray());
            return @"/" + a[0] + a[1];
        }

        public static void SetCookie(HttpResponse aResponse, string aName, string aValue)
        {
            SetCookie(aResponse, aName, aValue, false);
        }

        public static void SetCookie(HttpResponse aResponse, string aName, string aValue, bool aNeverExpire)
        {
            aResponse.Cookies[aName].Value = aValue;
            if (aNeverExpire)
                aResponse.Cookies[aName].Expires = DateTime.MaxValue;
        }

        public static string GetCookie(HttpRequest aRequest, string aName, string aDefault)
        {
            string result;
            try
            {
                result = aRequest.Cookies[aName].Value;
            }
            catch
            {
                result = aDefault;
            }
            return result;
        }

        public static void SetCompoundImage(HyperLink aControl1, HyperLink aControl2, object aSmallFileName, object aLargeFileName, string aTitle)
        {

            if (aSmallFileName != null && aSmallFileName != DBNull.Value && !aSmallFileName.ToString().Equals(""))
            {
                aControl1.ImageUrl = GetImageFileURL(SessionContext.Site, aSmallFileName);  //GetImageURL(BusinessLayerUtility.GetAppSetting("SchoolFileURL") + aSmallFileName.ToString();
                if (aLargeFileName != null && aLargeFileName != DBNull.Value && !aLargeFileName.ToString().Equals(""))
                {
                    aControl1.ToolTip = aTitle;
                    aControl1.Attributes.Add("title", aTitle);
                    aControl1.Attributes.Add("href", GetImageFileURL(SessionContext.Site, aLargeFileName));
                    aControl1.Attributes.Add("rel", "lightbox");
                    aControl2.ToolTip = aTitle;
                    aControl2.Attributes.Add("title", aTitle);
                    aControl2.ImageUrl = BusinessLayerUtility.GetAppSetting("SchoolFileURL") + "view_large_image_icon.jpg";
                    aControl2.Attributes.Add("href", GetImageFileURL(SessionContext.Site, aLargeFileName));
                    aControl2.Attributes.Add("rel", "lightbox");
                }
            }
            else
            {
                aControl1.Visible = false;
                aControl2.Visible = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static string BoolToString(bool aValue)
        {
            return aValue ? "Yes" : "No";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aExtension"></param>
        /// <returns></returns>
        public static string GetUniqueFileName(string aExtension)
        {
            return Guid.NewGuid().ToString().Substring(0, 18) + aExtension;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aInputControl"></param>
        /// <param name="aFileName"></param>
        /// <param name="aPath"></param>
        /// <param name="aRemove"></param>
        /// <returns></returns>
        public static string SaveUploadFile(HtmlInputFile aInputControl, object aFileName, string aPath, bool aRemove)
        {
            string result = "";
            string FullPath = "";
            if (!aRemove)
            {
                if (aFileName != null && aFileName != DBNull.Value)
                    if (!aFileName.ToString().Equals(""))
                    {
                        FullPath = aFileName.ToString();
                        result = FullPath;
                    }
                if (aInputControl.PostedFile != null && !aInputControl.Value.Equals(""))
                {
                    if (!FullPath.Equals(""))
                    {
                        FullPath = aPath + SessionContext.Site + "/" + FullPath;
                        result = FullPath;
                        if (File.Exists(FullPath))
                            File.Delete(FullPath);
                    }
                    string NewFileName = GetUniqueFileName(Path.GetExtension(aInputControl.Value));
                    string NewFilePath = aPath + SessionContext.Site + "/" + NewFileName;
                    HttpPostedFile myFile = aInputControl.PostedFile;
                    int nFileLength = myFile.ContentLength;
                    byte[] myData = new byte[nFileLength];
                    myFile.InputStream.Read(myData, 0, nFileLength);
                    FileStream newFile = new FileStream(NewFilePath, FileMode.Create);
                    try
                    {
                        newFile.Write(myData, 0, myData.Length);
                        result = NewFileName;
                    }
                    catch
                    {
                        result = "";
                    }
                    finally
                    {
                        newFile.Close();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aInputControl"></param>
        /// <param name="aFileName"></param>
        /// <param name="aPath"></param>
        /// <param name="aRemove"></param>
        /// <returns></returns>
        public static string SaveUploadVideo(HtmlInputFile aInputControl, object aFileName, string aPath, bool aRemove)
        {
            string result = "";
            string FullPath = "";
            if (!aRemove)
            {
                if (aFileName != null && aFileName != DBNull.Value)
                    if (!aFileName.ToString().Equals(""))
                    {
                        FullPath = aFileName.ToString();
                        result = FullPath;
                    }
                if (aInputControl.PostedFile != null && !aInputControl.Value.Equals(""))
                {
                    if (!FullPath.Equals(""))
                    {
                        FullPath = aPath + "/" + FullPath;
                        result = FullPath;
                        if (File.Exists(FullPath))
                            File.Delete(FullPath);
                    }
                    string NewFileName = GetUniqueFileName(Path.GetExtension(aInputControl.Value));
                    string NewFilePath = aPath + "/" + NewFileName;
                    HttpPostedFile myFile = aInputControl.PostedFile;
                    int nFileLength = myFile.ContentLength;
                    byte[] myData = new byte[nFileLength];
                    myFile.InputStream.Read(myData, 0, nFileLength);
                    FileStream newFile = new FileStream(NewFilePath, FileMode.Create);
                    try
                    {
                        newFile.Write(myData, 0, myData.Length);
                        result = NewFileName;
                    }
                    catch
                    {
                        result = "";
                    }
                    finally
                    {
                        newFile.Close();
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSchool"></param>
        /// <param name="aInputControl"></param>
        /// <param name="aFileName"></param>
        /// <param name="aRemove"></param>
        /// <returns></returns>
        public static string SaveUploadFile(int aSchool, HtmlInputFile aInputControl, object aFileName, bool aRemove)
        {
            return SaveUploadFile(aInputControl, aFileName, GetSchoolFileFolder(aSchool) + "\\", aRemove);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSchool"></param>
        /// <param name="aInputControl"></param>
        /// <param name="aFileName"></param>
        /// <param name="aRemove"></param>
        /// <returns></returns>
        public static string SaveUploadContentFile(int aSchool, HtmlInputFile aInputControl, object aFileName, bool aRemove)
        {
            return SaveUploadFile(aInputControl, aFileName, GetSchoolFileFolder(aSchool) + "\\content\\", aRemove);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSchool"></param>
        /// <param name="aAlbum"></param>
        /// <param name="aInputControl"></param>
        /// <param name="aFileName"></param>
        /// <param name="aRemove"></param>
        /// <returns></returns>
        public static string SaveUploadAlbumPhotoFile(int aSchool, int aAlbum, HtmlInputFile aInputControl, object aFileName, bool aRemove)
        {
            return SaveUploadFile(aInputControl, aFileName, GetSchoolFileFolder(aSchool) + "\\album\\" + aAlbum.ToString() + "\\", aRemove);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDateTime"></param>
        /// <returns></returns>
        public static string HowLongAgo(DateTime aDateTime)
        {

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = aDateTime;

            TimeSpan ts = dt1.Subtract(dt2);

            string mytimeago = String.Empty;
            if (Convert.ToInt32(ts.TotalDays) != 0)
                mytimeago = "" + Math.Abs(Convert.ToInt32(ts.TotalDays)) + " Days ago";
            else
            {
                if ((Convert.ToInt32(ts.TotalMinutes) < 5) && (Convert.ToInt32(ts.TotalHours) == 0))
                {
                    mytimeago = "Just Posted";
                }
                else if ((Convert.ToInt32(ts.TotalMinutes) > 5) && (Convert.ToInt32(ts.TotalHours) == 0))
                {
                    mytimeago = Convert.ToInt32(ts.TotalMinutes) % 60 + " Mins ago";
                }
                else if (Convert.ToInt32(ts.TotalHours) != 0)
                {
                    mytimeago = "" + Convert.ToInt32(ts.TotalHours) + " Hours " + Convert.ToInt32(ts.TotalMinutes) % 60 + " Mins ago";
                }
                else
                {
                    mytimeago = Convert.ToInt32(ts.TotalMinutes) % 60 + " Mins ago";
                }


            }
            return mytimeago;

        }
        /****************************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string MaxUploadFileSizeX()
        {
            return string.Format("Make sure your file is under {0:0.#} MB.", MaxUploadFileSize());
        }
        /**
         *  This method will llok into the web.config file to see what the Max Upload File size is allowd for this School
         *  Following section is used to set the file upload size 
         *  <location path="Upload">
         *   <system.web>
         *       <httpRuntime executionTimeout="110" maxRequestLength="20000" />
         *   </system.web>
         *  </location>
         * 
         * It is important to assign the location, to prevent the denial of access attack.
         * */
        public static double MaxUploadFileSize()
        {

            double retval = 0.00;
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                System.Web.Configuration.HttpRuntimeSection section = config.GetSection("system.web/httpRuntime") as System.Web.Configuration.HttpRuntimeSection;
                retval = Math.Round(section.MaxRequestLength / 1024.0, 1);
            }
            catch { }

            return retval;
        }
        #region Default Button for a control
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="intControlType"></param>
        /// <param name="objControl"></param>
        /// <param name="objButton"></param>
        public static void SetDefaultButtonForControl(System.Web.UI.Page objPage, ControlTypes intControlType, object objControl, System.Web.UI.WebControls.WebControl objButton)
        {
            string strScript = @"<SCRIPT language=""javascript"">
			<!--
			function catchKeyDown(btn, event)
			{
			if (document.all)
			{
				if (event.keyCode == 13)
				{
				event.returnValue=false;
				event.cancel = true;
				btn.click();
				}
			}
			else if (document.getElementById)
			{
				if (event.which == 13)
				{
				event.returnValue=false;
				event.cancel = true;
				btn.click();
				}
			}
			else if(document.layers)
			{
				if(event.which == 13)
				{
				event.returnValue=false;
				event.cancel = true;
				btn.click();
				}
			}
			}
			// -->
			</SCRIPT>";
            objPage.RegisterStartupScript("DefaultButtonForControl", strScript);

            //Register with the control
            switch (intControlType)
            {
                case ControlTypes.TextBox:
                    {
                        System.Web.UI.WebControls.TextBox objTextBox = objControl as System.Web.UI.WebControls.TextBox;
                        objTextBox.Attributes.Add("onkeydown", "catchKeyDown(" + objButton.ClientID + ",event)");
                        break;
                    }

                case ControlTypes.DropDownList:
                    {
                        System.Web.UI.WebControls.DropDownList objDropDownList = objControl as System.Web.UI.WebControls.DropDownList;
                        objDropDownList.Attributes.Add("onkeydown", "catchKeyDown(" + objButton.ClientID + ",event)");
                        break;
                    }

                case ControlTypes.ListBox:
                    {
                        ListBox objListBox = objControl as System.Web.UI.WebControls.ListBox;
                        objListBox.Attributes.Add("onkeydown", "catchKeyDown(" + objButton.ClientID + ",event)");
                        break;
                    }

                case ControlTypes.CheckBox:
                    {
                        CheckBox objCheckBox = objControl as CheckBox;
                        objCheckBox.Attributes.Add("onkeydown", "catchKeyDown(" + objButton.ClientID + ",event)");
                        break;
                    }
            }
        }
        #endregion
        //////////////////********Code from Manzooor*////////////////////////////////////////////////
        /// <summary>
        /// This method with make the date in any format compatible with the SQL Server format
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="IsFeild"></param>
        /// <returns></returns>
        public static string ConvertToSQLOneNotTwoDateFormat(object aValue, bool IsFeild)
        {
            DateTime Dt;
            string Temp;
            if (IsFeild)
            {
                Temp = "Convert(Varchar,Cast(" + aValue + " as Datetime),102)";
            }
            else
            {
                try
                {
                    Dt = DateTime.Parse(aValue.ToString());
                    aValue = Dt.ToString("yyyy/MM/dd");
                }
                catch
                {
                    // do nothing
                }
                Temp = "Convert(Varchar,Cast('" + aValue + "'" + " as Datetime),102)";
            }

            return Temp;
        }
        ////////////////////// Export to Excel from Grid///////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GrdView"></param>
        /// <param name="ReportName"></param>
        public static void GetGridFieldsDataForExcel(GridView GrdView, string ReportName)
        {
            GrdView.AllowPaging = false;
            DataSet grdds = new DataSet();
            grdds.Tables.Add("GrdTable");
            for (int j = 0; j < GrdView.Columns.Count; j++)
            {
                if (GrdView.HeaderRow.Cells[j].Text.ToString().Trim() == "&nbsp;" || GrdView.HeaderRow.Cells[j].Text.ToString().Trim() == "")
                {

                }
                else
                {
                    grdds.Tables["GrdTable"].Columns.Add(GrdView.HeaderRow.Cells[j].Text.ToString());
                }
            }
            for (int p = 0; p < GrdView.PageCount; p++)
            {
                for (int i = 0; i < GrdView.Rows.Count; i++)
                {
                    DataRow dr = grdds.Tables["GrdTable"].NewRow();
                    int c = 0;
                    for (int j = 0; j < GrdView.Columns.Count; j++)
                    {

                        if (GrdView.Columns[j].GetType().ToString() == "System.Web.UI.WebControls.TemplateField" || GrdView.Columns[j].Visible == false)
                        {

                        }
                        else
                        {
                            dr[c] = GrdView.Rows[i].Cells[j].Text.ToString();
                            c++;
                        }
                    }
                    grdds.Tables["GrdTable"].Rows.Add(dr);
                    dr = null;
                }
            }
            GenrateExcel(grdds, ReportName);
        }

        public static void GetGridCellsDataForExcel(GridView GrdView, string ReportName)
        {
            GrdView.AllowPaging = false;
            DataSet grdds = new DataSet();
            grdds.Tables.Add("GrdTable");
            for (int j = 0; j < GrdView.HeaderRow.Cells.Count; j++)
            {
                if (GrdView.HeaderRow.Cells[j].Text.ToString().Trim() == "&nbsp;" || GrdView.HeaderRow.Cells[j].Text.ToString().Trim() == "")
                {

                }
                else
                {
                    grdds.Tables["GrdTable"].Columns.Add(GrdView.HeaderRow.Cells[j].Text.ToString());
                }
            }
            for (int p = 0; p < GrdView.PageCount; p++)
            {
                for (int i = 0; i < GrdView.Rows.Count; i++)
                {
                    DataRow dr = grdds.Tables["GrdTable"].NewRow();
                    int c = 0;
                    for (int j = 0; j < GrdView.HeaderRow.Cells.Count; j++)
                    {
                        dr[c] = GrdView.Rows[i].Cells[j].Text.ToString();
                        c++;

                    }
                    grdds.Tables["GrdTable"].Rows.Add(dr);
                    dr = null;
                }
            }
            GenrateExcel(grdds, ReportName);
        }
        /// <summary>
        /// Generate Excel file and launch it
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="IsFeild"></param>
        /// <returns></returns>
        public static void GenrateExcel(DataSet ds, string FileName)
        {

            ReplcateColumnSpace(ds);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.Charset = "";
            XmlDataDocument xdd = new XmlDataDocument(ds);
            XslTransform xt = new XslTransform();
            xt.Load(HttpContext.Current.Server.MapPath("~/ExcelTemplate/XSLTFile.xsl"));
            xt.Transform(xdd, null, HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls");
            HttpContext.Current.Response.End();


        }
        /// <summary>
        /// Replace special Characters from data column names
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="IsFeild"></param>
        /// <returns></returns>
        private static void ReplcateColumnSpace(DataSet ds)
        {
            try
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    dc.ColumnName = dc.ColumnName.ToString().Replace(" ", "-").Replace("%", "_");
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IsDate(object Value)
        {
            try
            {
                DateTime.Parse(Value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static object IsNull(object Value, object Default)
        {
            try
            {
                if (Value == null || Value.ToString().Trim() == "")
                {
                    return Default;
                }
                return Value;
            }
            catch
            {
                return Default;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static string ToUSPhoneFormat(string Value, string Default)
        {
            string Result = "";
            try
            {
                if (Value.Length >= 10)
                {
                    Result = "(" + Value.Substring(0, 3) + ")" + Value.Substring(3, 3) + "-" + Value.Substring(6, 4);
                }
                else
                {
                    Result = Default;
                }
            }
            catch (Exception ex)
            {
                Result = Default;
            }
            return Result;
        }
        /// <summary>
        /// Return true if object value is date else return false
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static bool Cast(Object aValue)
        {
            DateTime result;

            try
            {
                result = DateTime.Parse(aValue.ToString());
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        static string[] _IdArray;
        /// <summary>
        /// 
        /// </summary>
        public static string[] IdArray
        {
            set
            {
                _IdArray = value;
                //SessionContext.PageCode = _pageCode;
            }
            get { return _IdArray; }
        }
        /// <summary>
        /// 
        /// </summary>
        static string[] _nameArray;
        /// <summary>
        /// 
        /// </summary>
        public static string[] nameArray
        {
            set
            {
                _nameArray = value;
                //SessionContext.PageCode = _pageCode;
            }
            get { return _nameArray; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <param name="contextKey"></param>
        /// <returns></returns>
        public static string[] GetSearchList(DataSet ds, string prefixText, int count, string contextKey)
        {
            string Res = "All,";

            string value = string.Empty;
            string[] arr = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow Item in ds.Tables[0].Rows)
            {
                Res += Item[contextKey].ToString() + ",";

                //arr.SetValue(Item[contextKey].ToString(), Convert.ToInt32(Item["Organization"]));
                arr.SetValue(Item[contextKey].ToString(), i);
                value += Item["Organization"].ToString() + ",";  //pk
                i++;
            }

            //Res = Res.Remove(Res.Length - 1, 1);
            IdArray = value.Split(',');
            nameArray = arr;
            //return Res.Split(',');
            return arr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SMTP GetSMTPObject()
        {

            SMTP Result = new SMTP(WebUtility.GetAppSetting("SMTPHost")
                                    , WebUtility.Cast(WebUtility.GetAppSetting("Port"), 0)
                                    , WebUtility.GetAppSetting("UserName"), WebUtility.GetAppSetting("Password")
                                    , WebUtility.GetAppSetting("UseSSL").ToUpper() == "TRUE"
                                    , WebUtility.GetAppSetting("AuthenticationRequired").ToUpper() == "TRUE");
            return Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public static string GetAppSetting(string aKey)
        {
            return System.Configuration.ConfigurationManager.AppSettings[aKey];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aFormat"></param>
        /// <param name="aOnError"></param>
        /// <returns></returns>
        public static object ValueToSQLDate(object aValue, DateFormat aFormat, object aOnError)
        {
            object result;
            try
            {
                string buffer;
                buffer = aValue.ToString().Trim();
                result = DateTime.Parse(buffer).ToShortDateString();
            }
            catch
            {
                result = aOnError;
            }
            switch (aFormat)
            {
                case DateFormat.WithOutTime:
                    break;
                case DateFormat.WithCurrentTime:
                    result = result + " " + DateTime.Now.ToShortTimeString(); //System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond;
                    break;
                case DateFormat.WithBeginingOfTheDay:
                    result = result + " 00:00:00:000";
                    break;
                case DateFormat.WithEndOfTheDay:
                    result = result + " 23:59:59:000";
                    break;
            }
            return result;
        }
        /// <summary>
        /// Genreates Xml Query from datagrid
        /// </summary>
        /// <returns></returns>
        public static string GenrateXml(DataTable aDataTable)
        {
            StringBuilder InvestorDetail;
            //InvestorDetail.Append("");
            try
            {
                InvestorDetail = new StringBuilder();
                InvestorDetail.Append("<Root>");
                foreach (DataRow dr in aDataTable.Rows)
                {
                    InvestorDetail.Append("<Row ");
                    foreach (DataColumn dc in aDataTable.Columns)
                    {
                        InvestorDetail.Append(dc.ColumnName + "=\"");
                        InvestorDetail.Append(dr[dc]);
                        InvestorDetail.Append("\" ");
                    }
                    InvestorDetail.Append("/>\n");
                }
                InvestorDetail.Append("</Root>");
                return InvestorDetail.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string GenrateListXml(ListBox lst)
        {
            StringBuilder InvestorDetail;

            try
            {
                InvestorDetail = new StringBuilder();
                InvestorDetail.Append("<Root>");
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    //if (lst.Items[i].Selected == true)
                    //{
                    InvestorDetail.Append("<Row ");
                    InvestorDetail.Append("Section=\"");
                    InvestorDetail.Append(lst.Items[i].Value);
                    InvestorDetail.Append("\" ");
                    InvestorDetail.Append("/>\n");
                    //}

                }

                InvestorDetail.Append("</Root>");
                return InvestorDetail.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public static string SendSMS(string mobileNo, string message)
        {

            String SMSURL = " http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser&password=1071271847&sendername=DM&mobileno={0}&message={1}";
            //String SMSURL = BusinessLayerUtility.GetAppSetting("SMSUrl");
            String SMSURLWithInput = string.Format(SMSURL, mobileNo, message);
            System.Net.WebRequest request = System.Net.WebRequest.Create(SMSURLWithInput);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            return reader.ReadToEnd(); // This will contain the status of message e.g. failed, ok etc

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string ReplaceText(string val)
        {
            return val.Trim().Replace("'", "''").Replace("/", "//");
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="drpReport"></param>
        ///// <param name="drpReportName"></param>
        ///// <param name="txtReportname"></param>
        ///// <param name="grdReportColumn"></param>
        ///// <param name="lblMsg"></param>
        ///// <param name="rpt"></param>
        //public void BulkInsertReportFilds(DropDownList drpReport, DropDownList drpReportName, TextBox txtReportname, GridView grdReportColumn, Label lblMsg, ReportName rpt)
        //{
        //    ReportCustomizeBL ReportCustomizeBL;
        //    string CustomizeReportName;
        //    try
        //    {
        //        ReportCustomizeBL = new ReportCustomizeBL(0);
        //        if (drpReport.SelectedValue == "-1")
        //        {
        //            CustomizeReportName = txtReportname.Text.Trim();
        //        }
        //        else
        //        {
        //            CustomizeReportName = drpReport.SelectedItem.Text.Trim();
        //        }
        //        if (ReportCustomizeBL.UpsertCustomizeReport(GenrateXmlFromGrid(grdReportColumn), CustomizeReportName, Convert.ToInt32(rpt)))
        //        {
        //            lblMsg.Text = "&nbsp;";
        //            //WebUtility.FillDropDownList(drpReportName, GetCustomizeReportName(rpt), "ReportCustomizeX", "ReportCustomize", null);

        //            if (drpReport.SelectedValue == "-1")
        //            {
        //                WebUtility.FillDropDownList(drpReport, GetCustomizeReportName(rpt), "ReportCustomizeX", "ReportCustomize", null);
        //                WebUtility.FillDropDownList(drpReportName, GetCustomizeReportName(rpt), "ReportCustomizeX", "ReportCustomize", null);
        //                drpReportName.SelectedValue = drpReportName.Items.FindByText(txtReportname.Text.Trim()).Value;
        //                drpReport.SelectedValue = drpReport.Items.FindByText(txtReportname.Text.Trim()).Value;
        //                txtReportname.Enabled = false;
        //            }
        //            else
        //            {
        //                drpReportName.SelectedValue = drpReport.SelectedValue;
        //            }
        //        }
        //        else
        //        {

        //            lblMsg.Text = "";
        //            throw ReportCustomizeBL.LastException;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        ReportCustomizeBL = null;
        //        CustomizeReportName = null;
        //    }
        //}
        /// <summary>
        /// Read Values of XML File for form Labels......
        /// </summary>
        /// <param name="strSchool"></param>
        /// <param name="strMessageId"></param>
        /// <returns></returns>
        public static string GetXmlValue(string strSchool, string strModuleId, string strControlId)
        {

            //XmlDocument xDoc = new XmlDocument();
            //string path = HttpContext.Current.Request.MapPath("~\\DynamicMessages");
            //xDoc.Load(path + "\\DynamicMessages.xml");
            //XmlNode xNode = xDoc.SelectSingleNode("WEB");
            //string strReturnMsg = "PLEASE CHECK MESSAGE FILE for :" + strMessageId;
            //XmlNodeList xPageNode;
            //try
            //{
            //    foreach (XmlNode rootChild in xNode.ChildNodes)
            //    {
            //        xPageNode = rootChild.SelectNodes("//page[@SchoolName='" + strSchool + "']");
            //        if (xPageNode != null)
            //        {
            //            bool bFound = false;
            //            for (int i = 0; i <= xPageNode.Count - 1; i++)
            //            {
            //                if (bFound)
            //                {
            //                    break;
            //                }
            //                XmlNode xPgNode = (XmlNode)xPageNode[i];
            //                foreach (XmlNode xMsgNode in xPgNode.ChildNodes)
            //                {
            //                    if (xMsgNode.Attributes["id"].Value == strMessageId)
            //                    {
            //                        strReturnMsg = xMsgNode.Attributes["value"].Value;
            //                    }
            //                }
            //            }
            //            if (bFound)
            //            {
            //                break;
            //            }
            //        }
            //        xPageNode = null;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    strReturnMsg = "Error Occurred in processing message from XML <br>" + ex.Message;
            //}
            //finally
            //{
            //    xPageNode = null;
            //    xNode = null;
            //    xDoc = null;
            //}

            return "";

        }
        #region "ENCRYPT PASSWORD"
        public static byte[] EncryptPassword(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            return hashedDataBytes;
        }
        public enum SortBy
        {
            Name,
            Date,
            Size,
            Default
        }
        #endregion

        public enum SystemRoleType
        {
            Administrator = 1,
            External = 3,
            GEEmployee = 5,
            Internal = 6,
            GEContractor = 7,
            SuperAdministrator = 8,
        }

        #region "XML TO GET CUSTOM MESSAGES"
        public static string GetXmlValue(string strSchool, string strMessageId)
        {
            XmlDocument xDoc = new XmlDocument();
            string path = HttpContext.Current.Request.MapPath("~\\DynamicMessages");
            xDoc.Load(path + "\\DynamicMessages.xml");
            XmlNode xNode = xDoc.SelectSingleNode("WEB");

            string strReturnMsg = "PLEASE CHECK MESSAGE FILE for :" + strMessageId;

            XmlNodeList xPageNode;

            try
            {
                foreach (XmlNode rootChild in xNode.ChildNodes)
                {
                    xPageNode = rootChild.SelectNodes("//page[@SchoolName='" + strSchool + "']");
                    if (xPageNode != null)
                    {
                        bool bFound = false;
                        for (int i = 0; i <= xPageNode.Count - 1; i++)
                        {
                            if (bFound)
                            {
                                break;
                            }
                            XmlNode xPgNode = (XmlNode)xPageNode[i];
                            foreach (XmlNode xMsgNode in xPgNode.ChildNodes)
                            {
                                if (xMsgNode.Attributes["id"].Value == strMessageId)
                                {
                                    strReturnMsg = xMsgNode.Attributes["value"].Value;
                                }
                            }
                        }
                        if (bFound)
                        {
                            break;
                        }
                    }
                    xPageNode = null;
                }
            }
            catch (Exception ex)
            {
                strReturnMsg = "Error Occurred in processing message from XML <br>" + ex.Message;
            }
            finally
            {
                xPageNode = null;
                xNode = null;
                xDoc = null;
            }

            return strReturnMsg;

        }
        #endregion

        #region " REMOVE COLUMNS FROM DATASET "

        public static DataSet FormatGird(DataSet ds, ArrayList aParam)
        {

            foreach (string p in aParam)
            {
                ds.Tables[0].Columns.Remove(p);
            }
            return ds;
        }

        #endregion

        public static String DisplayName(string RegNo)
        {
            DataSet ds = new DataSet();
            //EmployeeBL EBL = new EmployeeBL(SessionContext.SystemUser);
            //EBL.FetchForRegimentalNo(ds, RegNo);
            return ds.Tables[0].Rows[0]["EmployeeX"].ToString();
        }

    }
}

