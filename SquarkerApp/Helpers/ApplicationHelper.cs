using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SquarkerApp.Helpers
{
	public class ApplicationHelper
	{
		/// <summary>
		/// Renders the page title in the view.
		/// </summary>
		public static string RenderTitle(IDictionary<string, object> title)
		{
			if (title.ContainsKey("Title"))
			{
				string fullTitle = "Squarker | " + title["Title"];
				return fullTitle;
			} else
			{
				string fullTitle = "Squarker";
				return fullTitle;
			}
		}
		
		
		/// <summary>
		/// Returns Gravatar image url.
		/// </summary>
		public static string Gravatar(string email, int size)
		{
			return (string.Format("http://www.gravatar.com/avatar/{0}?s={1}&r=PG",
        	EncryptMD5(email), size));
			
		}
			                      
		
		public static string EncryptMD5(string input)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			
			byte[] valueArray = Encoding.ASCII.GetBytes(input);
			valueArray = md5.ComputeHash(valueArray);
			
			string encrypted = "";
			
            for (int i = 0; i < valueArray.Length; i++)
                encrypted += valueArray[i].ToString("x2").ToLower();
            return encrypted;
			
		}
			                      
		
	}
}

