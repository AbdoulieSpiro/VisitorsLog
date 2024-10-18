using System;
using System.Xml;
using System.IO;

namespace HRSystemServer.UPSLayer
{
	/// <summary>
	/// Summary description for AddressValidationRequest.
	/// </summary>
	public class AddressValidationRequest
	{
		string _city;
		string _state;
		string _postalCode;

		public AddressValidationRequest(string aCity, string aState, string aPostalCode)
		{
			_city = aCity;
			_state = aState;
			_postalCode = aPostalCode;
		}

		public string City
		{
			get{ return _city; }
			set{ _city = value; }
		}

		public string State
		{
			get{ return _state; }
			set{_state = value; }
		}

		public string PostalCode
		{
			get{ return _postalCode; }
			set{_postalCode = value; }
		}

		public string ToXML()
		{
			string result = "";

			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
			try
			{
				//Generate AddressValidationRequest
				xmlWriter.WriteStartDocument(false);

				xmlWriter.WriteStartElement("AddressValidationRequest"); 

				xmlWriter.WriteStartElement("Request");
	
				xmlWriter.WriteStartElement("TransactionReference");
			
				xmlWriter.WriteStartElement("CustomerContext");
				xmlWriter.WriteString("Maryam Dennis-Customer Data");
				xmlWriter.WriteEndElement();
						
				xmlWriter.WriteStartElement("XpciVersion");
				xmlWriter.WriteString("1.0001");
				xmlWriter.WriteEndElement();
			
				xmlWriter.WriteEndElement(); //End TransactionReference

				xmlWriter.WriteStartElement("RequestAction");
				xmlWriter.WriteString("AV");
				xmlWriter.WriteEndElement();

				xmlWriter.WriteEndElement(); //End Request
			
				xmlWriter.WriteStartElement("Address");
				xmlWriter.WriteStartElement("City");
				xmlWriter.WriteString(City);
				xmlWriter.WriteEndElement();
				xmlWriter.WriteStartElement("StateProvinceCode");
				xmlWriter.WriteString(State);
				xmlWriter.WriteEndElement();
				xmlWriter.WriteStartElement("PostalCode");
				xmlWriter.WriteString(PostalCode);
				xmlWriter.WriteEndElement();

				xmlWriter.WriteEndElement(); //End Address

				xmlWriter.WriteEndElement(); //End AddressValidationRequest

				result = stringWriter.ToString().Replace("encoding=\"utf-16\"","");

			}
			finally
			{
				xmlWriter.Close();
				stringWriter.Close();
			}
			return result;
		}
	}
}
