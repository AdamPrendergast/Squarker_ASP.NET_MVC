using System;
using System.Web.Routing;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;


namespace SquarkerApp.DependencyInjection
{
	
	/// <summary>
	/// Custom controller factory which uses Windsor to manage components the application.
	/// - Provides the MVC runtime with new instances of the controller type for each request.
	/// - Releases the controller at the end of each request.
	/// </summary>
	public class WindsorControllerFactory : DefaultControllerFactory
	{
		private readonly IKernel _kernel;
		
		
		public WindsorControllerFactory (IKernel kernel)
		{
			this._kernel = kernel;
		}
		
		
		public override void ReleaseController (IController controller)
		{
			_kernel.ReleaseComponent (controller);
		}
		
		
		protected override IController GetControllerInstance (RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
			{
				throw new HttpException (404, string.Format ("The controller for path '{0}' could not be found.",
				                                             requestContext.HttpContext.Request.Path));
			}
			
			return (IController)_kernel.Resolve (controllerType);
		}
	}
}
