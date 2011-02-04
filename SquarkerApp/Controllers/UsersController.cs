using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
namespace SquarkerApp
{
	public class UsersController : Controller
	{
		public ActionResult New()
		{
			ViewData["Title"] = "Signup";
			return View("New");
		}
	}
}

