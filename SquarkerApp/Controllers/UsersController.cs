using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using SquarkerApp.Models;
using SquarkerApp.Sessions;
	
namespace SquarkerApp.Controllers
{
	public class UsersController : RestfulController<User, int>
	{
		
		/// <summary>
		/// Index User Action
		/// </summary>
		public override ActionResult Index()
		{
			ViewData["Title"] = "Users";
			var users = UserRepository.AllUsers();
			
			return View("Index", users);
		}
		
		
		/// <summary>
		/// Show User Action
		/// </summary>
		public override ActionResult Show(int id)
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
		
		
		/// <summary>
		/// New User Action
		/// </summary>
		public override ActionResult New()
		{
			ViewData["Title"] = "Signup";
			
			return View("New");
		}
		
		
		/// <summary>
		/// Create User Action
		/// </summary>
		[ValidateAntiForgeryToken]
		public override ActionResult Create(User user)
		{
			if (!ModelState.IsValid)
			{
				return View("New");	 
				
			}else
			
			try
			{
				UserRepository.AddUserToDatabase(user);
			}
			catch (Exception e)  //Catch specific exception?
			{
				ViewData["Title"] = "Error";
				ViewData["Error"] = e.Message;
				
				return View("UserError");				
			}
			
			SessionManager.SignIn(user);
			return RedirectToAction("Show", new { id = user.UserId });
		}
		
		
		/// <summary>
		/// Edit User Action
		/// </summary>
		public override ActionResult Edit (int id)
		{
			return View();
		}			

		
		/// <summary>
		/// Update User Action
		/// </summary>
		public override ActionResult Update (User user)
		{
			return View();
		}
		
		
		/// <summary>
		/// Delete User Action
		/// </summary>
		public override ActionResult Delete (int id)
		{
			return View();
		}
	}
}

