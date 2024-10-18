using System;
using System.Data;
using System.Xml;
using System.IO;
using System.Web;
using System.Net;
using System.Text;


namespace HRSystemServer.UPSLayer
{
	/// <summary>
	/// Summary description for UPSAddressValidator.
	/// </summary>
	/// 
	public class UPSAddressValidator
	{
	
		public UPSAddressValidator()
		{
			
		}

		 public DataRow ValidateAddress(string aCity, string aState, string aZipCode)
		{
			DataRow result = null;
			
			//Create XML Access Request
			AccessRequest ar = new AccessRequest("ABDF39AE0C020A3C","frankurena1","access1");

			// Create XML Address request 
			AddressValidationRequest avr = new AddressValidationRequest(aCity, aState, aZipCode);

			// Request XML
			string sRequestXML = ar.ToXML() + avr.ToXML();

			// get byte array for sending
			ASCIIEncoding encodedData=new ASCIIEncoding();
			byte[]  byteArray=encodedData.GetBytes(sRequestXML);

			// open School
			HttpWebRequest wr = (HttpWebRequest) WebRequest.Create("https://wwwcie.ups.com/ups.app/xml/AV");
			wr.Method = "POST";
			wr.KeepAlive = false;
			wr.UserAgent = "ThomasDirect";
			wr.ContentType = "application/x-www-form-urlencoded";
			wr.ContentLength = sRequestXML.Length;

			// send xml data
			Stream SendStream=wr.GetRequestStream();
			SendStream.Write(byteArray,0,byteArray.Length);
			SendStream.Close();

			// get the response
			HttpWebResponse WebResp = null;
			try
			{
				WebResp = (HttpWebResponse) wr.GetResponse();
				string res = "";
				try
				{
					using (StreamReader sr = new StreamReader(WebResp.GetResponseStream()) )
					{
						res = sr.ReadToEnd();
						sr.Close();
					}
					AddressValidationResponse avresponse = new AddressValidationResponse(res.ToString());
					
					result = avresponse.DataTable().Rows[0];
					
				}
				catch (Exception exc)
				{
					result =null;
					Console.Write("Send failure: " + exc.ToString());
				}
			}
			finally
			{
				if  (WebResp!= null)
				{
					WebResp.Close();
				}
			}
			return result;
			


		} 

		 
	}
}
