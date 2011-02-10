using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SquarkerApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SquarkerApp.Controllers
{
	public class UsersController : Controller
	{
		/// <summary>
		/// Index
		/// </summary>
		public ActionResult Index()
		{
			ViewData["Title"] = "Users";
			var users = UserRepository.AllUsers();
			
			return View("Index", users);
		}
		
		
		/// <summary>
		/// New
		/// </summary>
		public ActionResult New()
		{
			ViewData["Title"] = "Signup";
			
			return View("New");
		}
		
		
		//[HttpPost]
		public ActionResult Create()
		{
			return View("Index");	
		}
		
		
		/// <summary>
		/// Show
		/// </summary>
		public ActionResult Show(int id)
		{
			try
			{
				ViewData["Title"] = "Show User";
				var user = UserRepository.FindUser(id);
			
				return View("Show", user);
			}
			catch
			{
				ViewData["Title"] = "Error";
				ViewData["Error"] = "Sorry. We could not find that user in our database.";
				
				return View("UserError");
			}
		}
		
	}
}

