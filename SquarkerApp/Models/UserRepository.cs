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
		/// Returns a User from the database given a valid UserId.
		/// </summary>
		public static User FindUser(int id)
		{
			using (ISession session = DatabaseRepository.OpenSession())
			{	
				var user = session.Load<User>(id);
				return user;
			}
		}
		
		
		/// <summary>
		/// Returns a User from the database given a valid Name
		/// </summary>
		public static User FindUserByName(string name)
		{
			using (ISession session = DatabaseRepository.OpenSession())
			{	
				IQuery query = session.CreateQuery("from User where Name = :name");
				query.SetParameter("name", name);
				
				var user = query.UniqueResult<User>();
				
				session.Close();
				
				return user;
			}	
		}
		
		
		public static User FindUserByEmail(string email)
		{
			using (ISession session = DatabaseRepository.OpenSession())
			{
				IQuery query = session.CreateQuery("from User where Email = :email");
				query.SetParameter("email", email);
				
				var user = query.UniqueResult<User>();
				
				session.Close();
				
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
				user.EncryptPassword();
				
				session.Save(user);
				
				try
				{
					transaction.Commit();
					session.Close();
				}
				
				catch
				{
					session.Close();
					// if exception is duplicate in database throw the below exception.
					throw new Exception("Sorry. That user is already taken.");
				}
			}
		} 
	}
}

