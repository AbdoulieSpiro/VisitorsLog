using System;
using System.Xml;
using System.IO;

namespace HRSystemServer.UPSLayer
{
	/// <summary>
	/// Summary description for AccessRequest.
	/// </summary>
	public class AccessRequest
	{
		string _licenseNumber;
		string _userName;
		string _password;

		public AccessRequest(string licenseNumber, string userName, string password)
		{
			_licenseNumber = licenseNumber;
			_userName = userName;
			_password = password;
		}

		public string LicenseNumber
		{
			get{ return _licenseNumber; }
			set{ _licenseNumber = value; }
		}

		public string UserName
		{
			get{ return _userName; }
			set{_userName = value; }
		}

		public string Password
		{
			get{return _password;}
			set{_password = value;}
		}

		public string ToXML()
		{
			string result = "";

			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
			try
			{

				xmlWriter.Formatting= Formatting.Indented;

				//Generate AccessRequest Section
				xmlWriter.WriteStartDocument(false);
				xmlWriter.WriteStartElement("AccessRequest");

				xmlWriter.WriteStartElement("AccessLicenseNumber");
				xmlWriter.WriteString(LicenseNumber);
				xmlWriter.WriteEndElement();
		
				xmlWriter.WriteStartElement("UserId");
				xmlWriter.WriteString(UserName);
				xmlWriter.WriteEndElement();

				xmlWriter.WriteStartElement("Password");
				xmlWriter.WriteString(Password);
				xmlWriter.WriteEndElement();

				xmlWriter.WriteEndElement(); //End AccessRequest
			
				result = stringWriter.ToString().Replace("encoding=\"utf-8\"","");
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
