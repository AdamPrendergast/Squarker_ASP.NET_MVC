using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;
using SquarkerApp.Models;

namespace SquarkerApp
{
	public class UserRepository
	{
		/// <summary>
		/// Returns all users from database.
		/// </summary>
		public static IList<User> AllUsers()
		{
			using (ISession session = DatabaseRepository.OpenSession())
			{
				IQuery query = session.CreateQuery("from User");
				
				IList<User> users = query.List<User>();
				
				return users;
			}
		}
		
		public static User FindUser(int id)
		{
			using (ISession session = DatabaseRepository.OpenSession())
			{	
				User user = session.Load<User>(id);
				return user;
			}
		}
	}
}

