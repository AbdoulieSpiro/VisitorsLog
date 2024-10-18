using System;
using System.Data;
using System.Xml;

namespace HRSystemServer.UPSLayer
{
	/// <summary>
	/// Summary description for AddressValidationResponse.
	/// </summary>
	public class AddressValidationResponse
	{
		DataTable dt;
		string _responseCode = "";
		string _responseCodeX = "";
		string _responseXML = "";
	
		public string ResponseCode
		{
			get{ return _responseCode; }
			set{ _responseCode = value; }
		}

		public string ResponseCodeX
		{
			get{ return _responseCodeX; }
			set{ _responseCodeX = value; }
		}

		public AddressValidationResponse(string aResponseXML)
		{
			
			_responseXML = aResponseXML;
				
			//Create New Data Table
			dt = new DataTable();
			createResponseTable();

			//Populate Response Table
			updateResponseTable();

		}
		public DataTable DataTable()
		{
			return dt;
		}

		private void updateResponseTable()
		{

			object[] rowObjs;

			XmlDocument xDoc = new XmlDocument();
			xDoc.LoadXml(_responseXML);
			
			//Get Response Status Codes
			XmlNodeList errors = xDoc.SelectNodes("AddressValidationResponse/Response");
			ResponseCode = errors.Item(0).SelectSingleNode("ResponseStatusCode").InnerText;
			ResponseCodeX = errors.Item(0).SelectSingleNode("ResponseStatusDescription").InnerText;

			if (ResponseCode == "1") //Success
			{
				XmlNodeList locations = xDoc.SelectNodes("AddressValidationResponse/AddressValidationResult");
				foreach(XmlNode location in locations)
				{
					string rank = location.SelectSingleNode("Rank").InnerText;
					string quality = location.SelectSingleNode("Quality").InnerText;
					string city = location.SelectSingleNode("Address/City").InnerText;
					string state = location.SelectSingleNode("Address/StateProvinceCode").InnerText;
					string postalCodeLow = location.SelectSingleNode("PostalCodeLowEnd").InnerText;
					string postalCodeHigh = location.SelectSingleNode("PostalCodeHighEnd").InnerText;
					
					rowObjs = new object[] {Convert.ToInt16(rank), Convert.ToDouble(quality), city, state, postalCodeLow, postalCodeHigh};
					dt.Rows.Add(rowObjs);
					
				}
			}
		}

		private DataTable createResponseTable()
		{
			dt.Columns.Add("Rank", typeof(Int16));
			dt.Columns.Add("Quality", typeof(Double));
			dt.Columns.Add("City", typeof(string));
			dt.Columns.Add("State", typeof(string));
			dt.Columns.Add("PostalCodeLowEnd", typeof(string)); //typeof(Int32));
			dt.Columns.Add("PostalCodeHighEnd", typeof(string)); //typeof(Int32));

			return dt;
		}

	}
}
