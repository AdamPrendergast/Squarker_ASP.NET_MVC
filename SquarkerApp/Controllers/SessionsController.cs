using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using SquarkerApp.Models;
using SquarkerApp.Sessions;
	
namespace SquarkerApp.Controllers
{
	/// <summary>
	/// New, Create, and Destroy actions to persist a user session to a cookie.
	/// </summary>
	public class SessionsController : Controller
	{
		public User CurrentUser;
		
		public ActionResult New()
		{
			return View();
		}
		
		
		public ActionResult Create(string email, string password)
		{
			// HttpContext.Page.User exists
			var signinUser = Models.User.Authenticate(email, password);
			
			if (signinUser == null)
			{
				// Flash signin error
				return RedirectToAction("New");	
			}
			else
			{
				SessionManager.SignIn(signinUser);
				return RedirectToAction("Show", "Users", new { id = signinUser.UserId });
			}
		}
		
		
		public ActionResult Destroy()
		{
			SessionManager.SignOut();
			
			return RedirectToAction("Home", "Pages");
		}	
	}
}
