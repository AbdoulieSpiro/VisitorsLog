using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.IO;
using Microsoft.Win32;

public enum ValidationResult
{
    UnKnown,
    Success,
    Failed 
 }
public class WinUtility
{

    private static String _UserName, _SystemRoleTypeName, _ItemCode, _CodeSearch, _BatchNo, _BranchCode;

    #region Casting Functions



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
    public static Int32 Cast(Int32 aOnError, Object aValue)
    {
        Int32 result;
        try
        {
            result = Int32.Parse(aValue.ToString());
        }
        catch
        {
            result = aOnError;
        }
        return result;
    }
    public static Int32 CastInt32(Object aValue, Int32 aOnError)
    {
        Int32 result;
        try
        {
            result = Int32.Parse(aValue.ToString());
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
            result = (string)aValue;
        }
        catch
        {
            result = aOnError;
        }
        return result;
    }
    public static Guid Cast(Object aValue, Guid aOnError)
    {
        Guid result;
        try
        {
            result = new Guid(aValue.ToString());
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

    public static float Cast(Object aValue, float aOnError)
    {
        float result;
        try
        {
            result = float.Parse(aValue.ToString());
        }
        catch
        {
            result = aOnError;
        }
        return result;
    }


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

    public static bool Cast(Object aValue, bool aOnError)
    {
        bool result;
        try
        {
            if (aValue.ToString().ToUpper().Trim() == "TRUE")
            {
                return true;
            }
            if (aValue.ToString().ToUpper().Trim() == "FALSE")
            {
                return false;
            }
            result = ((bool)aValue) ? true : false;
        }
        catch
        {
            result = aOnError;
        }
        return result;
    }
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

    #endregion

    #region Utility Methods

    static string SMSProductName = "SMS";
    /// <summary>
    /// GetThe Value for a key from app config
    /// </summary>
    /// <param name="aKey"></param>
    /// <returns></returns>
    public static string GetAppSetting(string aKey)
    {
        System.Configuration.AppSettingsReader Settings = new System.Configuration.AppSettingsReader();
        return Settings.GetValue(aKey, aKey.GetType()).ToString();

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static bool IsTime(object Value)
    {
        try
        {
            DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy") + " " + Value);
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// Check  the givenn value is date or not
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static bool IsDate(object Value)
    {
        DateTime Dt;
        try
        {
            Dt = DateTime.Parse(Value.ToString());

            return true;
        }
        catch
        {
            return false;
        }

    }
    /// <summary>
    /// Checks wheather a values is a date or not
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    /// 

    public static bool IsNumber(object Value)
    {
        double Result;

        try
        {
            Result = double.Parse(Value.ToString());
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
    /// <param name="aDefault"></param>
    /// <returns></returns>
    public static object IsNull(object Value, object aDefault)
    {


        try
        {
            if (Value.ToString().Trim() == "" || Value == DBNull.Value)
            {
                return aDefault;
            }
            else
            {
                return Value.ToString();
            }
        }
        catch
        {
            return aDefault;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public static string Right(string Value, int Count)
    {
        if (Value.Length < Count || Value.Length == 0)
        {
            return Value;
        }
        return Value.Substring(Value.Length - Count, Count);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public static string Left(string Value, int Count)
    {

        if (Value.Length < Count || Value.Length == 0)
        {
            return "";
        }
        return Value.Substring(0, Count);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static string ToWordCase(string Value)
    {
        char[] Data = (" " + Value.ToLower().TrimStart()).ToCharArray();
        char c = char.MinValue;
        for (int i = 0; i < Data.Length; i++)
        {
            c = Data[i];
            if (i < Data.Length)
            {
                if ((c == ' ') || (c == ';') || (c == ':') || (c == '!') || (c == '?') || (c == ',') || (c == '.') || (c == '_'))
                {
                    ++i;
                    Data[i] = Data[i].ToString().ToUpper().ToCharArray()[0];
                }
            }
        }
        return new string(Data).TrimStart();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="Start"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public static string Mid(string Value, int Start, int Count)
    {
        try
        {
            return Value.Substring(Start, Count);
        }
        catch
        {
            return "";
        }
    }



    static string _ApplicationPath = "";

    public static string ApplicationPath
    {
        get
        {
            return _ApplicationPath;
        }
        set
        {
            _ApplicationPath = value;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="msg"></param>
    public static string ReadTextFile(string FileName)
    {
        return System.IO.File.ReadAllText(FileName);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FileName"></param>
    /// <returns></returns>
    public static string ReadFile(string FileName)
    {
        string Result = "";
        FileInfo fi = null;
        StreamReader sr = null;

        string line;
        fi = new FileInfo(FileName);
        sr = new StreamReader(fi.OpenRead());
        while ((line = sr.ReadLine()) != null)
        {
            Result = Result + line + Environment.NewLine;
        }


        sr.Close();
        fi = null;
        sr = null;

        return Result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FileName"></param>
    /// <returns></returns>
    public static bool CreateFile(string FileName, string Contents)
    {
        StreamWriter sr = null;
        bool Result = false;

        sr = new StreamWriter(FileName);
        try
        {
            sr.Write(Contents);
            sr.Close();
            Result = true;
        }
        catch
        {

            sr = null;
            Result = false;
        }

        return Result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FileName"></param>
    /// <param name="Contents"></param>
    /// <returns></returns>
    public static bool CreateFile(string FileName, byte[] Contents)
    {
        FileStream outFile = null;
        bool Result = false;
        try
        {
            outFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            outFile.Write(Contents, 0, Contents.Length);
            outFile.Close();
            Result = true;
        }
        catch
        {
            Result = false;
        }
        outFile.Close();
        return Result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="HL7Message"></param>
    /// <param name="HL7Delemeters"></param>
    /// <returns></returns>
    public static string[] GetFields(string HL7SegmentLine, string HL7FieldDelemeters)
    {

        return HL7SegmentLine.Split(HL7FieldDelemeters.ToCharArray());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ParentFolder"></param>
    /// <param name="ChildFolder"></param>
    public static void CheckFolder(string ParentFolder, string ChildFolder)
    {
        try
        {
            Directory.CreateDirectory(ParentFolder + "\\" + ChildFolder);
        }
        catch
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Path"></param>
    public static bool IsValidPath(string Path, bool IsFolder)
    {
        bool Result = false;

        if (IsFolder)
        {
            if (Directory.Exists(Path))
            {
                Result = true;
            }
        }
        else
        {
            if (File.Exists(Path))
            {
                Result = true;
            }
        }
        return Result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FileName"></param>
    /// <param name="Contents"></param>
    /// <returns></returns>
    public static bool AddToFile(string FileName, string Contents)
    {
        bool Result = false;
        StreamWriter sr = null;

        try
        {
            sr = new StreamWriter(FileName, true);
            sr.Write(Contents);
            sr.Close();
            sr = null;
            Result = true;
        }
        catch
        {
            sr = null;
            Result = false;
        }

        return Result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ConnectionString"></param>
    /// <returns></returns>
    public static bool TestDSN(string ConnectionString)
    {
        System.Data.Odbc.OdbcConnection con = new System.Data.Odbc.OdbcConnection(ConnectionString);
        try
        {
            con.Open();
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
    /// <param name="DateString"></param>
    /// <returns></returns>
    public static string ParseDate(string DateString)
    {

        string Temp = DateString;
        try
        {
            if (DateString.Length >= 8 && WinUtility.IsDate(DateString) == false)
            {
                DateString = Temp.Substring(0, 4) + "/";
                Temp = Temp.Substring(4, Temp.Length - 4);
                DateString = DateString + Temp.Substring(0, 2) + "/";
                Temp = Temp.Substring(2, Temp.Length - 2);
                DateString = DateString + Temp;

            }
            if (!WinUtility.IsDate(DateString))
            {
                DateString = "";
            }
            else
            {
                DateString = DateTime.Parse(DateString).ToString("MM/dd/yyyy");

            }
        }
        catch
        {
            DateString = "";
        }
        return DateString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Path"></param>
    public static void ClearFolder(string Path)
    {
        string[] Files = System.IO.Directory.GetFiles(Path);

        foreach (string File in Files)
        {
            try
            {
                System.IO.File.Delete(File);
            }
            catch
            {

            }
        }
    }





    public static object IFF(bool Condition, object TrueValue, object FalseValue)
    {
        if (Condition)
        {
            return TrueValue;
        }
        else
        {
            return FalseValue;
        }
    }





    /// <summary>
    /// 
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public static string ReadRegistryKey(string KeyName)
    {
        string subKey = "SOFTWARE\\" + SMSProductName;
        RegistryKey baseRegistryKey = Registry.LocalMachine;
        // Opening the registry key

        RegistryKey rk = baseRegistryKey;
        // Open a subKey as read-only

        RegistryKey sk1 = rk.OpenSubKey(subKey);
        // If the RegistrySubKey doesn't exist -> (null)

        if (sk1 == null)
        {
            return "";
        }
        else
        {
            try
            {
                return (string)sk1.GetValue(KeyName.ToUpper());
            }
            catch
            {

                return "";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="KeyName"></param>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static bool WriteRegistryKey(string KeyName, object Value)
    {
        string subKey = "SOFTWARE\\" + SMSProductName;
        RegistryKey baseRegistryKey = Registry.LocalMachine;
        try
        {
            // Setting

            RegistryKey rk = baseRegistryKey;
            // I have to use CreateSubKey 

            // (create or open it if already exits), 

            // 'cause OpenSubKey open a subKey as read-only

            RegistryKey sk1 = rk.CreateSubKey(subKey);
            // Save the value

            sk1.SetValue(KeyName.ToUpper(), Value);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public static String ItemCode
    {
        get
        {
            return _ItemCode;
        }
        set
        {
            _ItemCode = value;
        }
    }
    public static String BatchNo
    {
        get
        {
            return _BatchNo;
        }
        set
        {
            _BatchNo = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public static bool DeleteRegistryKey(string KeyName)
    {
        string subKey = "SOFTWARE\\" + SMSProductName;
        RegistryKey baseRegistryKey = Registry.LocalMachine;

        try
        {
            // Setting

            RegistryKey rk = baseRegistryKey;
            RegistryKey sk1 = rk.CreateSubKey(subKey);
            // If the RegistrySubKey doesn't exists -> (true)

            if (sk1 == null)
                return true;
            else
                sk1.DeleteValue(KeyName);

            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion
}


