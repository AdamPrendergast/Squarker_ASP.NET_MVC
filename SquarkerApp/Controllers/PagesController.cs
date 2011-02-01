using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace SquarkerApp
{
	public class PagesController : Controller
	{
		public ActionResult Home()
		{
			ViewData["Title"] = "Home";
			return View("Home");	
		}
		
		public ActionResult Contact()
		{
			ViewData["Title"] = "Contact";
			return View("Contact");
		}
		
		public ActionResult About()
		{
			ViewData["Title"] = "About";
			return View("About");
		}
		
	}
}

