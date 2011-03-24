using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SquarkerApp.Controllers;
using SquarkerCore;

namespace SquarkerApp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
			
			routes.MapRoute (null, "signup", new { controller = "Users", action = "New" });
			routes.MapRoute (null, "contact", new { controller = "Pages", action = "Contact" });
			routes.MapRoute (null, "about", new { controller = "Pages", action = "About" });
			routes.MapRoute (null, "help", new { controller = "Pages", action = "Help" });
			
			routes.MapResource<UsersController>("users");
			
			routes.MapRoute ("Default", "{controller}/{action}/{id}", new { controller = "Pages", action = "Home", id = "" });
			
		}

		protected void Application_Start ()
		{
			RegisterRoutes (RouteTable.Routes);
		}

	}
	
}

