using System;
using System.Web;
using System.Web.Mvc;
using SquarkerApp.Models;
using SquarkerApp.Controllers;

namespace SquarkerApp.Sessions
{
	public class SessionManager
	{	
		
		/// <summary>
		/// Signs in a user and creates a remember token cookie on the user browser. 
		/// The instance variable CurrentUser is set to the signed in User.
		/// </summary>
		public static void SignIn(User signInUser)
		{
			HttpCookie rememberToken = new HttpCookie("RememberToken");
			rememberToken.Value = signInUser.RememberMe();
			rememberToken.Expires = DateTime.Now.AddMinutes(15);
			
			HttpContext.Current.Response.Cookies.Add(rememberToken);
		}
		
		
		/// <summary>
		/// Signs out the current user by removing the RememberToken cookie
		/// </summary>
		public static void SignOut()
		{
			HttpCookie rememberToken = new HttpCookie("RememberToken");
			
			rememberToken.Expires = DateTime.Now.AddDays(-1);
			
			HttpContext.Current.Response.Cookies.Set(rememberToken);
		}
		
		
		/// <summary>
		/// Get current signed in user based on the value stored in the RememberToken cookie
		/// </summary>
		public static int GetCurrentUserId()
		{
			string token = HttpContext.Current.Request.Cookies.Get("RememberToken").Value;
			
			User CurrentUser = UserRepository.FindUserByRememberToken(token);
			
			return CurrentUser.UserId;
		}
		
		
		/// <summary>
		/// Checks to see if the user has a valid RememberToken cookie
		/// </summary>
		public static bool SignedIn()
		{
			try
			{
				HttpCookie token = HttpContext.Current.Request.Cookies.Get("RememberToken");
				
				if (token == null)
					return false;
				else
					return true;			
			}
			catch
			{
				return false;
			}
		}
	}
}

