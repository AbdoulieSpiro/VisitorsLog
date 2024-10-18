using System;
using System.Data;

namespace HRSystemServer.UPSLayer
{
	/// <summary>
	/// Summary description for CreditCardProcessing.
	/// </summary>
	/// 

    //public class ACHProcessing
    //{
    //    string _partner;
    //    string _vendor;
    //    string _password;
    //    string _server;
    //    string _user;


    //    string _result;
    //    string _pnref;
    //    string _respmsg;

			
    //    private const int PORT = 443;
    //    private const string TENDER = "A";
    //    private const string AUTHORIZATIONTYPE="WEB";

    //    public enum TransType
    //    {
    //        ttSale,
    //        ttCredit,
    //        ttInquiry,
    //        ttVoid
    //    }

    //    public ACHProcessing(int aSchool, int aSystemUser)
    //    {

    //        //Retrieve Verisign Data
    //        //Fetch Test Indicator
    //        BusinessLayer.SchoolBL sbl = new BusinessLayer.SchoolBL(aSystemUser);
    //        DataSet ds = new DataSet();

    //        sbl.Fetch(ds, aSchool);

    //        bool IsTest = Convert.ToBoolean(ds.Tables[sbl.SqlEntityX].Rows[0]["IsTestMode"]);


    //        BusinessLayer.PaymentGatewayBL gateway = new HRSystemServer.BusinessLayer.PaymentGatewayBL(aSystemUser);
            

    //        gateway.FetchForSchool(ds, aSchool);
    //        if (ds.Tables[gateway.SqlEntityX] != null && ds.Tables[gateway.SqlEntityX].Rows.Count > 0)
    //        {
    //            DataRow row = ds.Tables[gateway.SqlEntityX].Rows[0];
    //            _partner = row["Partner"].ToString();
    //            _vendor = row["Vendor"].ToString();
    //            _user = row["User"].ToString();
    //            _password = row["Password"].ToString();
    //            if (IsTest)
    //                _server = row["TestServer"].ToString();
    //            else
    //                _server = row["ProdServer"].ToString();

    //            row = null;
    //        }
    //        else
    //        {
    //            _partner = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignPartner");
    //            _vendor = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignVendor");
    //            _user = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignUser");
    //            _password = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignPassword");
    //            if (IsTest)
    //                _server = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignTestServer");
    //            else
    //                _server = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignProdServer");

    //        }
    //        ds = null;
    //        sbl = null;
    //        gateway = null;
			
    //    }

    //    public string Result
    //    {
    //        get{ return _result; }
    //    }
    //    public string PNRef
    //    {
    //        get{ return _pnref; }
    //    }
    //    public string ResponseMessage
    //    {
    //        get{ return _respmsg; }
    //    }
		 

    //    public bool Process(string aDesc,
    //                        TransType aTransType, 
    //                        string aAccount, 
    //                        string aAccountType,
    //                        string aABA,
    //                        string aAmount,  
    //                        string aName,
    //                        string aBillingAddress, 
    //                        string aBillingCity,
    //                        string aBillingState, 
    //                        string aBillingZip,
    //                        string aBillingCountry, 
    //                        string aShippingContact, 
    //                        string aShippingAddress, 
    //                        string aShippingCity, 
    //                        string aShippingState, 
    //                        string aShippingZip)
    //    {
		
    //        string TransactionType = "";
    //        switch (aTransType)
    //        {
    //            case TransType.ttSale:
    //                TransactionType = "S";
    //                break;
    //            case TransType.ttCredit:
    //                TransactionType = "C";
    //                break;
    //            case TransType.ttInquiry:
    //                TransactionType = "I";
    //                break;
    //            case TransType.ttVoid:
    //                TransactionType = "I";
    //                break;
    //        }

    //        aAmount		=	aAmount		=="0"	?	"$0.00"	:	"$"	+	aAmount;
 
    //        string sParmlist =	"DESC="             + aDesc+
    //                            "&TRXTYPE="         + TransactionType   +
    //                            "&TENDER="          + TENDER +
    //                            "&PARTNER="			+ _partner			+ 
    //                            "&USER="			+ _user				+ 
    //                            "&VENDOR="			+ _vendor			+
    //                            "&PWD="				+ _password			+ 
    //                            "&AMT="				+ aAmount			+ 
    //                            "&ACCT="			+ aAccount			+ 
    //                            "&STREET="			+ aBillingAddress	+
    //                            "&CITY="			+ aBillingCity		+
    //                            "&STATE="			+ aBillingState		+
    //                            "&ZIP="				+ aBillingZip		+
    //                            "&COUNTRY="			+ aBillingCountry	+
    //                            "&ABA="	            + aABA	            +
    //                            "&ACCTTYPE="	    + aAccountType	    +
    //                            "&NAME="	    	+ aName		        +
    //                            "&AUTHTYPE="		+ AUTHORIZATIONTYPE;

 

					 

    //        PFProCOMLib.PNComClass objPFPro = new PFProCOMLib.PNComClass();

    //        int iContext = objPFPro.CreateContext(_server, PORT, 30, "", 0, "", "");
    //        string tranResult = objPFPro.SubmitTransaction(iContext, sParmlist, sParmlist.Length);
 
    //        //Process Results
    //        //RESULT=0&PNREF=V53A0BB55A36&RESPMSG=Approved
    //        string[] results = tranResult.Split('&');
    //        foreach (string s in results) 
    //        {
    //            string result = s.Substring(0,s.IndexOf("="));	
    //            switch(result)
    //            {
    //                case "RESULT":
    //                    _result = s.Substring(s.IndexOf("=")+1);	
    //                    break;
    //                case "PNREF":
    //                    _pnref = s.Substring(s.IndexOf("=")+1);	
    //                    break;
    //                case "RESPMSG":
    //                    _respmsg = s.Substring(s.IndexOf("=")+1);	
    //                    break;
					 
    //            }
    //        }

    //        objPFPro.DestroyContext (iContext); 
    //        if (_result == "0")
    //            return true;
    //        else
    //            return false;
    //    }

		
    //    public bool Credit(TransType aTransType,string aOrigId )
    //    {
		
    //        string TransactionType = "";
    //        switch (aTransType)
    //        {
    //            case TransType.ttSale:
    //                TransactionType = "S";
    //                break;
    //            case TransType.ttCredit:
    //                TransactionType = "C";
    //                break;
    //            case TransType.ttInquiry:
    //                TransactionType = "I";
    //                break;
    //            case TransType.ttVoid:
    //                TransactionType = "I";
    //                break;
    //        }
 		
 


    //        string sParmlist =	"PARTNER="			+ _partner			+ 
    //                            "&USER="			+ _user				+ 
    //                            "&VENDOR="			+ _vendor			+
    //                            "&PWD="				+ _password			+ 
    //                            "&TRXTYPE="			+ TransactionType	+ 
    //                            "&ORIGID="			+ aOrigId; 
								 

    //        PFProCOMLib.PNComClass objPFPro = new PFProCOMLib.PNComClass();

    //        int iContext = objPFPro.CreateContext(_server, PORT, 30, "", 0, "", "");
    //        string tranResult = objPFPro.SubmitTransaction(iContext, sParmlist, sParmlist.Length);
 
    //        //Process Results
    //        //RESULT=0&PNREF=V53A0BB55A36&RESPMSG=Approved 
    //        string[] results = tranResult.Split('&');
    //        foreach (string s in results) 
    //        {
    //            string result = s.Substring(0,s.IndexOf("="));	
    //            switch(result)
    //            {
    //                case "RESULT":
    //                    _result = s.Substring(s.IndexOf("=")+1);	
    //                    break;
    //                case "PNREF":
    //                    _pnref = s.Substring(s.IndexOf("=")+1);	
    //                    break;
    //                case "RESPMSG":
    //                    _respmsg = s.Substring(s.IndexOf("=")+1);	
    //                    break;
					 
    //            }
    //        }

    //        objPFPro.DestroyContext (iContext); 
    //        if (_result == "0")
    //            return true;
    //        else
    //            return false;

    //    }

    //    public bool Void(  TransType aTransType,
    //                        string aOrigId,
    //                        string aAccount,
    //                        string aAccountType,
    //                        string aABA)
    //    {

    //        string TransactionType = "";
    //        switch (aTransType)
    //        {
    //            case TransType.ttSale:
    //                TransactionType = "S";
    //                break;
    //            case TransType.ttCredit:
    //                TransactionType = "C";
    //                break;
    //            case TransType.ttInquiry:
    //                TransactionType = "I";
    //                break;
    //            case TransType.ttVoid:
    //                TransactionType = "I";
    //                break;
    //        }

 
    //        string sParmlist = "TRXTYPE=" + TransactionType +
    //                            "&TENDER=" + TENDER +
    //                            "&PARTNER=" + _partner +
    //                            "&USER=" + _user +
    //                            "&VENDOR=" + _vendor +
    //                            "&PWD=" + _password +
    //                            "&ACCT=" + aAccount +
    //                            "&ACCTTYPE=" + aAccountType +
    //                            "&ABA=" + aABA +
    //                            "&ORIGID=" + aOrigId;





    //        PFProCOMLib.PNComClass objPFPro = new PFProCOMLib.PNComClass();

    //        int iContext = objPFPro.CreateContext(_server, PORT, 30, "", 0, "", "");
    //        string tranResult = objPFPro.SubmitTransaction(iContext, sParmlist, sParmlist.Length);

    //        //Process Results
    //        //RESULT=0&PNREF=V53A0BB55A36&RESPMSG=Approved
    //        string[] results = tranResult.Split('&');
    //        foreach (string s in results)
    //        {
    //            string result = s.Substring(0, s.IndexOf("="));
    //            switch (result)
    //            {
    //                case "RESULT":
    //                    _result = s.Substring(s.IndexOf("=") + 1);
    //                    break;
    //                case "PNREF":
    //                    _pnref = s.Substring(s.IndexOf("=") + 1);
    //                    break;
    //                case "RESPMSG":
    //                    _respmsg = s.Substring(s.IndexOf("=") + 1);
    //                    break;

    //            }
    //        }

    //        objPFPro.DestroyContext(iContext);
    //        if (_result == "0")
    //            return true;
    //        else
    //            return false;
    //    }
        

    //}
}
