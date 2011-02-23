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
		
		
		/// <summary>
		/// Returns a user from the database given a valid user id.
		/// </summary>
		public static User FindUser(int id)
		{
			using (ISession session = DatabaseRepository.OpenSession())
			{	
				User user = session.Load<User>(id);
				return user;
			}
		}
		
		
		/// <summary>
		/// Adds a new user to the database.
		/// </summary>
		public static void AddUserToDatabase(User user)
		{
			using (ISession session = DatabaseRepository.OpenSession())
			{
				ITransaction transaction = session.BeginTransaction();
				
				user.CreatedAt = DateTime.Now;
				user.UpdatedAt = DateTime.Now;
				
				//user.EncryptedPassword = user.EncryptPassword(user.Password);

				session.Save(user);
				
				try
				{
					transaction.Commit();
					session.Close();
				}
				
				catch
				{
					session.Close();
					throw new Exception("Sorry. That user is already taken.");
				}
			}
		}
	}
}

