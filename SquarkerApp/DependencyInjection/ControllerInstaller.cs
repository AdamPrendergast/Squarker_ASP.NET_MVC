using System;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SquarkerApp.Controllers;

namespace SquarkerApp.DependencyInjection
{
	/* Windsor uses dedicated classes called 'Installers' to feed the container with
	   knowledge about our types. A process called registration.
	   
	   One of the components we'll register into the container are the controllers.
	   Our installer needs to tell Windsor two things:
	   		- How to find the controllers in the application.
	   		- How to configure them.
	*/ 
	
	public class ControllersInstaller : IWindsorInstaller
	{	
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly()
			                   .BasedOn<IController>()
			                   .If(Component.IsInNamespace("SquarkerApp.Controllers"))
			                   .If(t => t.Name.EndsWith("Controller"))
			                   .Configure(c => c.LifeStyle.Transient));
		}
	}
}


