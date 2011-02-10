using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace SquarkerApp
{
	public class DatabaseRepository
	{
		/// <summary>
		/// NHibernate ISession setup. 
		/// </summary>
		public static ISession OpenSession()
		{
			var c = new Configuration();
			c.Configure(); // NHibernate will look for nhibernate.cfg.xml
			c.AddAssembly(Assembly.GetCallingAssembly());
			ISessionFactory f = c.BuildSessionFactory();
			return f.OpenSession();
		}
		
	}
}

