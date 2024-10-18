using System;
using System.Data;
//using PayPal.Payments.Common;
//using PayPal.Payments.Common.Utility;
//using PayPal.Payments.DataObjects;
//using PayPal.Payments.Transactions;
using System.Net;
using System.Collections;
using System.IO;
using HRSystemServer.BusinessLayer;
namespace HRSystemServer.UPSLayer
{
    /// <summary>
    /// Summary description for CreditCardProcessing.
    /// </summary>
    /// 

    public class CreditCardProcessing
    {
        string _partner;
        string _vendor;
        string _password;
        string _user;
        string AuthNetLoginID;
        string AuthNetTransKey;
        string _server;
        Exception _LastException;
        bool _response;
        string _result;
        string _pnref;
        string _respmsg;
        string _authcode;
        //UserInfo _userinfo;
       // PayflowConnectionData _connection;
        public int Donationcause { get; set; }
        public int PaymentGateway { get; set; }
        public CreditCardProcessing()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSchool"></param>
        /// <param name="aSystemUser"></param>
        public CreditCardProcessing(int aSchool, int aSystemUser)
        {
            _partner = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignPartner");
            _vendor = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignVendor");
            _user = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignUser");
            _password = BusinessLayer.BusinessLayerUtility.GetAppSetting("VerisignPassword");
            // Create the Data Objects.
            // Create the User data object with the required user details.
           // _userinfo = new UserInfo(_user, _vendor, _partner, _password);
           // _connection = new PayflowConnectionData();
            ////Fetch Test Indicator
            //DataSet ds = new DataSet();
            //BusinessLayer.SchoolBL sbl = new BusinessLayer.SchoolBL(aSystemUser);
            //sbl.Fetch(ds, aSchool);

        }

        //public CreditCardProcessing(int aSchool, int aSystemUser, int Cause)
        //{
        //    //Retrieve Verisign Data
        //    Donationcause = Cause;
        //    GetAccount();


        //    // Create the Data Objects.
        //    // Create the User data object with the required user details.
        //    //_userinfo = new UserInfo(_user, _vendor, _partner, _password);
        //    //_connection = new PayflowConnectionData();



        //    //Fetch Test Indicator
        //    //DataSet ds = new DataSet();
        //    //BusinessLayer.SchoolBL sbl = new BusinessLayer.SchoolBL(aSystemUser);
        //    //sbl.Fetch(ds, aSchool);

        //}

        /// <summary>
        /// Gets The Payment Gateway
        /// </summary>
        /// <param name="_PaymentGateway"></param>
        //public CreditCardProcessing(int _PaymentGateway)
        //{
        //    //Retrieve Verisign Data
        //    PaymentGateway = _PaymentGateway;
        //    GetPaymentAccount();


        //    // Create the Data Objects.
        //    // Create the User data object with the required user details.
        //    //_userinfo = new UserInfo(_user, _vendor, _partner, _password);
        //    //_connection = new PayflowConnectionData();

        //}
        public Exception LastException
        {
            get { return _LastException; }
        }
        public string Result
        {
            get { return _result; }
        }
        public string PNRef
        {
            get { return _pnref; }
        }
        public string ResponseMessage
        {
            get { return _respmsg; }
        }
        public string AuthorizationCode
        {
            get { return _authcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aAccount"></param>
        /// <param name="aExpDate"></param>
        /// <param name="aAmount"></param>
        /// <param name="aTax"></param>
        /// <param name="aShipping"></param>
        /// <param name="aComment"></param>
        /// <param name="aBillingContact"></param>
        /// <param name="aBillingAddress"></param>
        /// <param name="aBillingCity"></param>
        /// <param name="aBillingState"></param>
        /// <param name="aBillingZip"></param>
        /// <param name="aBillingCountry"></param>
        /// <param name="aShippingContact"></param>
        /// <param name="aShippingAddress"></param>
        /// <param name="aShippingCity"></param>
        /// <param name="aShippingState"></param>
        /// <param name="aShippingZip"></param>
        /// <returns></returns>
        //public bool Process(string aAccount,
        //                    string aExpDate,
        //                    string aAmount,
        //                    string aTax,
        //                    string aShipping,
        //                    string aComment,
        //                    string aBillingContact,
        //                    string aBillingAddress,
        //                    string aBillingCity,
        //                    string aBillingState,
        //                    string aBillingZip,
        //                    string aBillingCountry,
        //                    string aShippingContact,
        //                    string aShippingAddress,
        //                    string aShippingCity,
        //                    string aShippingState,
        //                    string aShippingZip)
        //{
        //    _response = false;
        //    // Create a new Invoice data object with the Amount, Billing Address etc. details.
        //    //Invoice Inv = new Invoice();
        //    // Set Amount.
        //    //Currency Amt = new Currency(Decimal.Parse(aAmount));
        //    //Inv.Amt = Amt;
        //    //Inv.TaxAmt = new Currency(Decimal.Parse(aTax));
        //    //Inv.ShippingAmt = new Currency(Decimal.Parse(aShipping));
        //    //Inv.Comment1 = aComment;
        //    //// Set the Billing Address details.
        //    //BillTo Bill = new BillTo();
        //    Bill.Street = aBillingAddress;
        //    Bill.City = aBillingCity;
        //    Bill.State = aBillingState;
        //    Bill.Zip = aBillingZip;
        //    Bill.BillToCountry = aBillingCountry;
        //    Bill.CompanyName = aBillingContact;
        //    // Set the Shipping Address details.
        //    ShipTo Ship = new ShipTo();
        //    Ship.ShipToStreet = aShippingAddress;
        //    Ship.ShipToCity = aShippingCity;
        //    Ship.ShipToZip = aShippingZip;
        //    Ship.ShipToState = aShippingState;
        //    Ship.ShipToFirstName = aShippingContact;
        //    Inv.BillTo = Bill;
        //    Inv.ShipTo = Ship;
        //    // Create a new Payment Device - Credit Card data object.
        //    // The input parameters are Credit Card Number and Expiration Date of the Credit Card.
        //    CreditCard CC = new CreditCard(aAccount, aExpDate);
        //    // Create a new Tender - Card Tender data object.
        //    CardTender Card = new CardTender(CC);
        //    ///////////////////////////////////////////////////////////////////

        //    // Create a new Sale Transaction.
        //    SaleTransaction Trans = new SaleTransaction(
        //        _userinfo, _connection, Inv, Card, PayflowUtility.RequestId);


        //    // Submit the Transaction
        //    Response Resp = Trans.SubmitTransaction();

        //    // Display the transaction response parameters.
        //    if (Resp != null)
        //    {
        //        // Get the Transaction Response parameters.
        //        TransactionResponse TrxnResponse = Resp.TransactionResponse;

        //        if (TrxnResponse != null)
        //        {
        //            _result = TrxnResponse.Result.ToString();
        //            _pnref = TrxnResponse.Pnref;
        //            _respmsg = TrxnResponse.RespMsg;
        //            _authcode = TrxnResponse.AuthCode;

        //        }
        //        if (_authcode != null)
        //        {
        //            _response = true;
        //        }
        //    }
        //    /** Cleanup**/
        //    _userinfo = null;
        //    _connection = null;
        //    Inv = null;
        //    Bill = null;
        //    Ship = null;
        //    CC = null;
        //    Card = null;


        //    return _response;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aAccount"></param>
        /// <param name="aExpDate"></param>
        /// <param name="aSecurityCode"></param>
        /// <param name="aAmount"></param>
        /// <param name="aBillingAddress1"></param>
        /// <param name="aBillingAddress2"></param>
        /// <param name="aBillingCity"></param>
        /// <param name="aBillingState"></param>
        /// <param name="aBillingZip"></param>
        /// <param name="aBillingCountry"></param>
        /// <param name="aBillingPhone"></param>
        /// <param name="aAccountHolder"></param>
        /// <returns></returns>
        //public bool ProcessFee(
        //    string aAccount,
        //    string aExpDate,
        //    string aSecurityCode,
        //    string aAmount,
        //    string aBillingAddress1,
        //    string aBillingAddress2,
        //    string aBillingCity,
        //    string aBillingState,
        //    string aBillingZip,
        //    string aBillingCountry,
        //    string aBillingPhone,
        //    string aAccountHolder)
        //{
        //    _response = false;
        //    Invoice Inv = new Invoice();
        //    // Set Amount.
        //    Currency Amt = new Currency(Decimal.Parse(aAmount));
        //    Inv.Amt = Amt;
        //    // Set the Billing Address details.
        //    BillTo Bill = new BillTo();
        //    Bill.Street = aBillingAddress1;
        //    Bill.City = aBillingCity;
        //    Bill.State = aBillingState;
        //    Bill.Zip = aBillingZip;
        //    Bill.BillToCountry = aBillingCountry;
        //    Bill.CompanyName = aBillingPhone;
        //    // Create a new Payment Device - Credit Card data object.
        //    // The input parameters are Credit Card Number and Expiration Date of the Credit Card.
        //    CreditCard CC = new CreditCard(aAccount, aExpDate);
        //    // Create a new Tender - Card Tender data object.
        //    CardTender Card = new CardTender(CC);
        //    ///////////////////////////////////////////////////////////////////

        //    // Create a new Sale Transaction.
        //    SaleTransaction Trans = new SaleTransaction(
        //       _userinfo, _connection, Inv, Card, PayflowUtility.RequestId);
        //    // Submit the Transaction
        //    Response Resp = Trans.SubmitTransaction();

        //    // Display the transaction response parameters.
        //    if (Resp != null)
        //    {
        //        // Get the Transaction Response parameters.
        //        TransactionResponse TrxnResponse = Resp.TransactionResponse;

        //        if (TrxnResponse != null)
        //        {
        //            _result = TrxnResponse.Result.ToString();
        //            _pnref = TrxnResponse.Pnref;
        //            _respmsg = TrxnResponse.RespMsg;
        //            _authcode = TrxnResponse.AuthCode;

        //        }
        //        if (_authcode != null)
        //        {
        //            _response = true;
        //        }

        //    }

        //    /** Cleanup**/
        //    _userinfo = null;
        //    _connection = null;
        //    //Inv = null;
        //    Bill = null;
        //    //  Ship = null;
        //    CC = null;
        //    Card = null;
        //    return _response;
        //}
        /// <summary>
        /// 
        /// </summary>
        //private void GetAccount()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        PaymentGatewayBL PaymentGatewayBL = new PaymentGatewayBL(0);
        //        PaymentGatewayBL.FetchForCause(ds, Donationcause);
        //        _partner = ds.Tables[0].Rows[0]["Partner"].ToString();
        //        _vendor = ds.Tables[0].Rows[0]["Vendor"].ToString();
        //        _password = ds.Tables[0].Rows[0]["Password"].ToString();
        //        _user = ds.Tables[0].Rows[0]["User"].ToString();
        //        AuthNetLoginID = ds.Tables[0].Rows[0]["User"].ToString();
        //        AuthNetTransKey = ds.Tables[0].Rows[0]["TransactionKey"].ToString();
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        //private void GetPaymentAccount()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        PaymentGatewayBL PaymentGatewayBL = new PaymentGatewayBL(0);
        //        PaymentGatewayBL.Fetch(ds, PaymentGateway);
        //        _partner = ds.Tables[0].Rows[0]["Partner"].ToString();
        //        _vendor = ds.Tables[0].Rows[0]["Vendor"].ToString();
        //        _password = ds.Tables[0].Rows[0]["Password"].ToString();
        //        _user = ds.Tables[0].Rows[0]["User"].ToString();
        //        AuthNetLoginID = ds.Tables[0].Rows[0]["User"].ToString();
        //        AuthNetTransKey = ds.Tables[0].Rows[0]["TransactionKey"].ToString();
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //    }
        //}
        /** Advance Integration Method **/
        //public bool AuthorizePayment(string aDescription, string aAccount, string aSecurityCode, string aExpDate, string Amount, string aFirstName, string aLastName, string Address, string City, string State, string ZIP, string Country)
        //{
        //    // By default, this sample code is designed to post to our test server for
        //    // developer accounts: https://test.authorize.net/gateway/transact.dll
        //    // for real accounts (even in test mode), please make sure that you are
        //    // posting to: https://secure.authorize.net/gateway/transact.dll
        //    String post_url = BusinessLayer.BusinessLayerUtility.GetAppSetting("AuthorizeURL");
        //    //String post_url = "https://secure.authorize.net/gateway/transact.dll";
        //    _response = false;
        //    _authcode = string.Empty;
        //    _pnref = string.Empty;
        //    _result = string.Empty;
        //    if (Donationcause > 0)
        //    {
        //        GetAccount();
        //    }
        //    else if (PaymentGateway > 0)
        //    {
        //        GetPaymentAccount();
        //    }
        //    else
        //    {
        //        AuthNetLoginID = BusinessLayer.BusinessLayerUtility.GetAppSetting("AuthNetLoginID");
        //        AuthNetTransKey = BusinessLayer.BusinessLayerUtility.GetAppSetting("AuthNetTransKey");
        //    }
        //    Hashtable post_values = new Hashtable();
        //    //the API Login ID and Transaction Key must be replaced with valid values
        //    post_values.Add("x_login", AuthNetLoginID);
        //    post_values.Add("x_tran_key", AuthNetTransKey);
        //    post_values.Add("x_delim_data", "TRUE");
        //    post_values.Add("x_delim_char", '|');
        //    post_values.Add("x_relay_response", "FALSE");
        //    post_values.Add("x_type", "AUTH_CAPTURE");
        //    post_values.Add("x_method", "CC");
        //    post_values.Add("x_card_num", aAccount);
        //    post_values.Add("x_card_code", aSecurityCode);
        //    post_values.Add("x_exp_date", aExpDate);
        //    post_values.Add("x_amount", Amount.ToString());
        //    post_values.Add("x_currency_code", "USD");
        //    post_values.Add("x_description", aDescription);
        //    post_values.Add("x_first_name", aFirstName);
        //    post_values.Add("x_last_name", aLastName);
        //    post_values.Add("x_address", Address);
        //    post_values.Add("x_state", State);
        //    post_values.Add("x_zip", ZIP);
        //    post_values.Add("x_country", Country);
        //    // Additional fields can be added here as outlined in the AIM integration
        //    // guide at: http://developer.authorize.net

        //    // This section takes the input fields and converts them to the proper format
        //    // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
        //    String post_string = "";
        //    foreach (DictionaryEntry field in post_values)
        //    {
        //        post_string += field.Key + "=" + field.Value + "&";
        //    }
        //    post_string = post_string.TrimEnd('&');
        //    // create an HttpWebRequest object to communicate with Authorize.net
        //    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
        //    objRequest.Method = "POST";
        //    objRequest.ContentLength = post_string.Length;
        //    objRequest.ContentType = "application/x-www-form-urlencoded";
        //    // post data is sent as a stream
        //    StreamWriter myWriter = null;
        //    myWriter = new StreamWriter(objRequest.GetRequestStream());
        //    myWriter.Write(post_string);
        //    myWriter.Close();
        //    // returned values are returned as a stream, then read into a string
        //    String post_response;
        //    HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //    using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
        //    {
        //        post_response = responseStream.ReadToEnd();
        //        responseStream.Close();
        //    }
        //    // the response string is broken into an array
        //    // The split character specified here must match the delimiting character specified above
        //    Array response_array = post_response.Split('|');
        //    _respmsg = response_array.GetValue(3).ToString();
        //    switch (response_array.GetValue(0).ToString().Trim())
        //    {
        //        case "1":
        //            _response = true;
        //            _authcode = response_array.GetValue(4).ToString();
        //            _pnref = response_array.GetValue(6).ToString();
        //            _result = "Approved";
        //            break;
        //        case "2":
        //            _result = "Declined: ";
        //            break;

        //        case "3":
        //            _result = "Error: ";
        //            break;

        //        case "4":
        //            _result = "Held for Review: ";
        //            break;
        //    }
        //    if (!_response)
        //    {
        //        switch (response_array.GetValue(5).ToString().Trim())
        //        {
        //            case "A":
        //                _result += " the zip code entered does not match " + "the billing address.";
        //                break;
        //            case "B":
        //                _result += " no information was provided for the AVS check.";
        //                break;
        //            case "E":
        //                _result += " a general error occurred in the AVS system.";
        //                break;
        //            case "G":
        //                _result += " the credit card was issued by a non-US bank.";
        //                break;
        //            case "N":
        //                _result += " neither the entered street address nor zip " +
        //                "code matches the billing address.";
        //                break;
        //            case "P":
        //                _result += " AVS is not applicable for this transaction.";
        //                break;
        //            case "R":
        //                _result += " please retry the transaction; the AVS system " + "was unavailable or timed out.";
        //                break;
        //            case "S":
        //                _result += " the AVS service is not supported by your " + "credit card issuer.";
        //                break;
        //            case "U":
        //                _result += " address information is unavailable for the " + "credit card.";
        //                break;
        //            case "W":
        //                _result += " the 9 digit zip code matches, but the " + "street address does not.";
        //                break;
        //            case "Z":
        //                _result += " the zip code matches, but the address does not.";
        //                break;
        //        }
        //    }
        //    _respmsg = Result + " " + _respmsg;


        //    return _response;

        //}

        //public bool AuthorizeCheckPayment(string aDescription, string BankCode, string AccountNumber, string AccountType, string BankName, string BankAccountName, string eCheckType, string BankCheckNumber, string Amount, string Address, string City, string State, string ZIP, string Country)
        //{

        //    // By default, this sample code is designed to post to our test server for
        //    // developer accounts: https://test.authorize.net/gateway/transact.dll
        //    // for real accounts (even in test mode), please make sure that you are
        //    // posting to: https://secure.authorize.net/gateway/transact.dll
        //    //String post_url = "https://test.authorize.net/gateway/transact.dll";
        //    String post_url = "https://secure.authorize.net/gateway/transact.dll";
        //    _response = false;
        //    _authcode = string.Empty;
        //    _pnref = string.Empty;
        //    _result = string.Empty;
        //    //string AuthNetLoginID = BusinessLayer.BusinessLayerUtility.GetAppSetting("AuthNetLoginID");
        //    //string AuthNetTransKey = BusinessLayer.BusinessLayerUtility.GetAppSetting("AuthNetTransKey");
        //    if (Donationcause > 0)
        //    {
        //        GetAccount();
        //    }
        //    else if (PaymentGateway > 0)
        //    {
        //        GetPaymentAccount();
        //    }
        //    else
        //    {
        //        AuthNetLoginID = BusinessLayer.BusinessLayerUtility.GetAppSetting("AuthNetLoginID");
        //        AuthNetTransKey = BusinessLayer.BusinessLayerUtility.GetAppSetting("AuthNetTransKey");
        //    }


        //    Hashtable post_values = new Hashtable();

        //    //the API Login ID and Transaction Key must be replaced with valid values
        //    post_values.Add("x_login", AuthNetLoginID);
        //    post_values.Add("x_tran_key", AuthNetTransKey);

        //    post_values.Add("x_delim_data", "TRUE");
        //    post_values.Add("x_delim_char", '|');
        //    post_values.Add("x_relay_response", "FALSE");

        //    post_values.Add("x_type", "AUTH_CAPTURE");
        //    post_values.Add("x_method", "ECHECK");
        //    post_values.Add("x_bank_aba_code", BankCode);
        //    post_values.Add("x_bank_acct_num", AccountNumber);
        //    post_values.Add("x_bank_acct_type", AccountType);
        //    post_values.Add("x_bank_name", BankName);
        //    post_values.Add("x_bank_acct_name", BankAccountName);
        //    post_values.Add("x_echeck_type", eCheckType);
        //    post_values.Add("x_bank_check_number ", BankCheckNumber);

        //    post_values.Add("x_amount", Amount.ToString());
        //    post_values.Add("x_currency_code", "USD");
        //    post_values.Add("x_description", aDescription);


        //    post_values.Add("x_address", Address);
        //    post_values.Add("x_city", City);
        //    post_values.Add("x_state", State);
        //    post_values.Add("x_zip", ZIP);
        //    post_values.Add("x_country", Country);
        //    // Additional fields can be added here as outlined in the AIM integration
        //    // guide at: http://developer.authorize.net

        //    // This section takes the input fields and converts them to the proper format
        //    // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
        //    String post_string = "";
        //    foreach (DictionaryEntry field in post_values)
        //    {
        //        post_string += field.Key + "=" + field.Value + "&";
        //    }
        //    post_string = post_string.TrimEnd('&');

        //    // create an HttpWebRequest object to communicate with Authorize.net
        //    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
        //    objRequest.Method = "POST";
        //    objRequest.ContentLength = post_string.Length;
        //    objRequest.ContentType = "application/x-www-form-urlencoded";

        //    // post data is sent as a stream
        //    StreamWriter myWriter = null;
        //    myWriter = new StreamWriter(objRequest.GetRequestStream());
        //    myWriter.Write(post_string);
        //    myWriter.Close();

        //    // returned values are returned as a stream, then read into a string
        //    String post_response;
        //    HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //    using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
        //    {
        //        post_response = responseStream.ReadToEnd();
        //        responseStream.Close();
        //    }

        //    // the response string is broken into an array
        //    // The split character specified here must match the delimiting character specified above
        //    Array response_array = post_response.Split('|');
        //    _respmsg = response_array.GetValue(3).ToString();


        //    switch (response_array.GetValue(0).ToString().Trim())
        //    {
        //        case "1":
        //            _result = "Approved";
        //            _authcode = response_array.GetValue(4).ToString();
        //            _pnref = response_array.GetValue(6).ToString();
        //            _response = true;
        //            break;
        //        case "2":
        //            _result = "Declined";
        //            break;

        //        case "3":
        //            _result = "Error";
        //            break;

        //        case "4":
        //            _result = "Held for Review";
        //            break;

        //    }

        //    if (!_response)
        //    {

        //        switch (response_array.GetValue(5).ToString().Trim())
        //        {
        //            case "A":
        //                _result += " the zip code entered does not match " + "the billing address.";
        //                break;
        //            case "B":
        //                _result += " no information was provided for the AVS check.";
        //                break;
        //            case "E":
        //                _result += " a general error occurred in the AVS system.";
        //                break;
        //            case "G":
        //                _result += " the credit card was issued by a non-US bank.";
        //                break;
        //            case "N":
        //                _result += " neither the entered street address nor zip " +
        //                "code matches the billing address.";
        //                break;
        //            case "P":
        //                _result += " AVS is not applicable for this transaction.";
        //                break;
        //            case "R":
        //                _result += " please retry the transaction; the AVS system " + "was unavailable or timed out.";
        //                break;
        //            case "S":
        //                _result += " the AVS service is not supported by your " + "credit card issuer.";
        //                break;
        //            case "U":
        //                _result += " address information is unavailable for the " + "credit card.";
        //                break;
        //            case "W":
        //                _result += " the 9 digit zip code matches, but the " + "street address does not.";
        //                break;
        //            case "Z":
        //                _result += " the zip code matches, but the address does not.";
        //                break;
        //        }
        //    }
        //    _respmsg = Result + " " + _respmsg;
        //    return _response;


        //}

    }
}

