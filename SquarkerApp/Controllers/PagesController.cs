using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
namespace SquarkerApp
{
	public class PagesController : Controller
	{
		public ActionResult Home()
		{
			return View();	
		}
		
		public ActionResult Contact()
		{
			return View();
		}
		
		public ActionResult About()
		{
			return View();
		}
		
	}
}

