using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HRSystemServer.DataLayer;
using System.Collections;
using System.Collections.Specialized;

namespace HRSystemServer.BusinessLayer
{
	public class BusinessLayerUtility
	{
		public BusinessLayerUtility()
		{
		}

		private static void ClaimConnection(SqlConnection aConnection, int aSystemUser)
		{
			SqlParameter newParam;
			SqlCommand cmd       = DataLayerUtility.NewStoredProcCommand("prConnectionOwnerClaim");
			cmd.Connection       = aConnection;
			newParam             = cmd.Parameters.Add("@SystemUser",SqlDbType.Int);
			newParam             = cmd.Parameters.Add("@retval",SqlDbType.Int);
			newParam.Direction   = ParameterDirection.ReturnValue;
			cmd.Parameters["@SystemUser"].Value = aSystemUser;
			if (aConnection.State!=ConnectionState.Open)
				aConnection.Open();
			cmd.ExecuteNonQuery();
		}

		public static string GetAppSetting(string aKey)
		{
			return ConfigurationSettings.AppSettings[aKey];
		}

		public static SqlConnection GetConnection(int aSystemUser)
		{
			SqlConnection result = new SqlConnection(GetAppSetting("connectionString"));
			ClaimConnection(result,aSystemUser);
			return result;
		}

		public static string Duplicate(string aString, int aCount)
		{
			string result = "";
			for (int i=0;i<aCount;i++)
			{
				result = result + aString;
			}
			return result;
		}

 

		public static bool ValidateCardNumber( string cardNumber )
		{
			try 
			{
				// Array to contain individual numbers
				System.Collections.ArrayList CheckNumbers = new ArrayList();
				// So, get length of card
				int CardLength = cardNumber.Length;
    
				// Double the value of alternate digits, starting with the second digit
				// from the right, i.e. back to front.
				// Loop through starting at the end
				for (int i = CardLength-2; i >= 0; i = i - 2)
				{
					// Now read the contents at each index, this
					// can then be stored as an array of integers

					// Double the number returned
					CheckNumbers.Add( Int32.Parse(cardNumber[i].ToString())*2 );
				}

				int CheckSum = 0;    // Will hold the total sum of all checksum digits
            
				// Second stage, add separate digits of all products
				for (int iCount = 0; iCount <= CheckNumbers.Count-1; iCount++)
				{
					int _count = 0;    // will hold the sum of the digits

					// determine if current number has more than one digit
					if ((int)CheckNumbers[iCount] > 9)
					{
						int _numLength = ((int)CheckNumbers[iCount]).ToString().Length;
						// add count to each digit
						for (int x = 0; x < _numLength; x++)
						{
							_count = _count + Int32.Parse( 
								((int)CheckNumbers[iCount]).ToString()[x].ToString() );
						}
					}
					else
					{
						// single digit, just add it by itself
						_count = (int)CheckNumbers[iCount];   
					}
					CheckSum = CheckSum + _count;    // add sum to the total sum
				}
				// Stage 3, add the unaffected digits
				// Add all the digits that we didn't double still starting from the
				// right but this time we'll start from the rightmost number with 
				// alternating digits
				int OriginalSum = 0;
				for (int y = CardLength-1; y >= 0; y = y - 2)
				{
					OriginalSum = OriginalSum + Int32.Parse(cardNumber[y].ToString());
				}

				// Perform the final calculation, if the sum Mod 10 results in 0 then
				// it's valid, otherwise its false.
				return (((OriginalSum+CheckSum)%10)==0);
			}
			catch
			{
				return false;
			}
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
				result = ((bool)aValue)?true:false;
			}
			catch
			{
				result = aOnError;
			}
			return result;
		}



	}
}
