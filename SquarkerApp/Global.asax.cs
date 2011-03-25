using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SquarkerApp.Controllers;
using SquarkerApp.DependencyInjection;
using SquarkerCore;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SquarkerApp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		
		private static IWindsorContainer _container;
		
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

		protected void Application_Start()
		{
			RegisterRoutes (RouteTable.Routes);
			
			BootStrapContainer();
		}
		
		
		protected void Application_End()
		{
			_container.Dispose();	
		}
		
		
		private static void BootStrapContainer()
		{
			_container = new WindsorContainer().Install(FromAssembly.This());
			
			var controllerFactory = new WindsorControllerFactory(_container.Kernel);
			
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
		}
	}
	
}

