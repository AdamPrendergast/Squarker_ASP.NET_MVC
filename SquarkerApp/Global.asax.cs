using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SquarkerApp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
			
			routes.MapRoute (null, "Contact", new { controller = "Pages", action = "Contact" });
			routes.MapRoute (null, "About", new { controller = "Pages", action = "About" });
			routes.MapRoute (null, "Help", new { controller = "Pages", action = "Help" });
			
			routes.MapRoute ("Default", "{controller}/{action}/{id}", new { controller = "Pages", action = "Home", id = "" });
			
		}

		protected void Application_Start ()
		{
			RegisterRoutes (RouteTable.Routes);
		}
	}
}

