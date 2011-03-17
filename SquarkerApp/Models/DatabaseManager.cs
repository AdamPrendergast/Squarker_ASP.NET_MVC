using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace SquarkerApp
{
	public static class DatabaseManager
	{
		private static ISessionFactory _sessionFactory;
		
		private static void Init()
		{
			var config = new Configuration();
			config.Configure();
			config.AddAssembly(Assembly.GetCallingAssembly());
			_sessionFactory = config.BuildSessionFactory();
		}
		
		
		public static ISession OpenSession()
		{
			if (_sessionFactory == null)
				Init();
			
			return _sessionFactory.OpenSession();
		}
		
	}
}

