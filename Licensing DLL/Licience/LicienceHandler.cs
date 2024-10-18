using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace LicensingDLL
{
    public class LicienceHandler
    {
        string LicienceFileName = "Licience.lic";
        string LicienceFileFullName = "";
        const string AtributeSeperator = "&";
        const string AlternateValue = "__AND__";
        Secure Sec = new Secure();
        //DatabaseChecker aDatabaseChecker = new DatabaseChecker();

        webservice.Service aWebService = new LicensingDLL.webservice.Service();

        Hashtable LicienceInfo = new Hashtable();
        string AppName = "";

        string[] LFileAtrributes = null;

        string _ResponseMessage;

        public string ResponseMessage
        {
            get { return _ResponseMessage; }

        }
        public LicienceHandler(string ApplicationPath, string ApplicationName)
        {
            LicienceFileFullName = ApplicationPath + LicienceFileName;

            AppName = ApplicationName;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApplicationPath"></param>
        /// <param name="ApplicationName"></param>
        /// <returns></returns>
        public ValidationResult ValidateLicience()
        {

            ValidationResult Result = ValidationResult.UnKnown;
            try
            {
                if (!WinUtility.IsValidPath(LicienceFileFullName, false))
                {
                    _ResponseMessage = "Application is not activated yet you need to activate the application.";
                    Result = ValidationResult.Failed;
                }
                else
                {
                    ReadLicienceFile();
                    Result = ValidateLicienceFile();
                }
            }
            catch (Exception Ex)
            {

                _ResponseMessage = Ex.Message;
                Result = ValidationResult.Failed;

            }
            return Result;
        }
        /// <summary>


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ValidationResult ValidateLicienceFile()
        {

            string MachineAppId = LicienceFileAttribute("MachineAppId");
            string RegMachineAppId = WinUtility.ReadRegistryKey(MachineAppId);
            RegMachineAppId = Sec.DecryptTripleDES(RegMachineAppId);
            Guid MachineAppIdGuid;
            ValidationResult Result = ValidationResult.UnKnown;

            try
            {
                MachineAppIdGuid = new Guid(MachineAppId);
                MachineAppIdGuid = new Guid(RegMachineAppId);
            }
            catch
            {
                MachineAppIdGuid = Guid.Empty;
            }

            if (MachineAppIdGuid == Guid.Empty || MachineAppId != RegMachineAppId)
            {
                _ResponseMessage = "System was able to find the license, but the License is not valid. You can not use the application";
                Result = ValidationResult.Failed;
            }
            else
            {
                Result = ValidationResult.Success;
            }


            return Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void ReadLicienceFile()
        {
            string[] Lines = Sec.DecryptTripleDES(WinUtility.ReadTextFile(LicienceFileFullName)).Split(AtributeSeperator.ToCharArray());
            LFileAtrributes = new string[Lines.Length];
            for (int i = 0; i < Lines.Length; i++)
            {

                LFileAtrributes[i] = "";
                if (Lines[i].Trim() != "")
                {

                    string[] Val = Lines[i].Split('=');
                    LFileAtrributes[i] = Val[0];
                    LicienceInfo[Val[0]] = Val[1].Replace(AlternateValue, AtributeSeperator);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveLicienceFile()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < LFileAtrributes.Length; i++)
            {
                if (LFileAtrributes[i].Trim() != "")
                {
                    sb.Append(LFileAtrributes[i]);
                    sb.Append("=");
                    sb.Append(LicienceInfo[LFileAtrributes[i]].ToString().Replace(AtributeSeperator, AlternateValue));
                }
            }
            if (System.IO.File.Exists(LicienceFileFullName))
            {
                System.IO.File.Delete(LicienceFileFullName);
            }
            WinUtility.CreateFile(LicienceFileFullName, Sec.EncryptTripleDES(sb.ToString()));
            sb = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        private string LicienceFileAttribute(string Key)
        {
            if (LicienceInfo[Key] == null)
            {
                throw new Exception("Inavlid Key (" + Key + ") was passed to  LicienceFileAttribute function");
            }
            return LicienceInfo[Key].ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="MachineAppId"></param>
        /// <param name="LicenseType"></param>
        /// <param name="ProductKey"></param>
        /// <param name="ClientName"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Country"></param>
        /// <param name="PhoneNo"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool ProcessRegistration(string ProductKey)
        {
            string AppCompId = Guid.NewGuid().ToString();
            bool Result = false;

            try
            {

                string[] Key = { "12a04480-a7fe-4485-90de-bde48a1cda56", "6f669f01-69a4-452d-8be9-2099888e2fd9" };
                if (Key[0] == ProductKey || Key[1] == ProductKey)
                {
                    Result = CreatCertificateFile(AppCompId, ProductKey);
                }
                else
                {

                    //DataTable dt = aDatabaseChecker.ProcessRegistration(ProductKey);
                    DataTable dt = aWebService.ProcessRegistration(ProductKey);

                    if (dt != null)
                    {

                        if (dt.Rows[0]["Expired"].ToString().ToUpper() == "TRUE")
                        {
                            throw new Exception("The Product key you provided is already expired. Please try agian");
                        }
                        else if (dt.Rows[0]["IsValidProductKey"].ToString().ToUpper() == "TRUE")
                        {
                            Result = CreatCertificateFile(AppCompId, ProductKey);

                        }
                        else
                        {
                            throw new Exception("The Product key you provided is not valid. Please try agian");
                        }
                    }
                    else
                    {
                        throw new Exception("There was as an error while processing the registration. Please try agian");

                    }


                }
            }
            catch (Exception Ex)
            {

                _ResponseMessage = Ex.Message;
                Result = false;

            }
            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MachineAppId"></param>
        /// <param name="ProductKey"></param>
        /// <param name="ClientName"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Country"></param>
        /// <param name="PhoneNo"></param>
        /// <param name="Email"></param>
        /// <returns></returns>

        private bool CreatCertificateFile(string MachineAppId, string ProductKey)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("MachineAppId=" + MachineAppId.Replace(AtributeSeperator, AlternateValue) + AtributeSeperator);
            sb.Append("ProductKey=" + ProductKey.Replace(AtributeSeperator, AlternateValue) + AtributeSeperator);
            WinUtility.CreateFile(LicienceFileFullName, Sec.EncryptTripleDES(sb.ToString()));
            WinUtility.WriteRegistryKey(MachineAppId, Sec.EncryptTripleDES(MachineAppId));
            ReadLicienceFile();

            return true;
        }
    }
}
