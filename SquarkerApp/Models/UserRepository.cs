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
			using (ISession session = DatabaseManager.OpenSession())
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
			using (ISession session = DatabaseManager.OpenSession())
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
			using (ISession session = DatabaseManager.OpenSession())
			{	
				IQuery query = session.CreateQuery("from User where Name = :name");
				query.SetParameter("name", name);
				
				var user = query.UniqueResult<User>();
				
				session.Close();
				
				return user;
			}	
		}
		
		
		/// <summary>
		/// Returns a User from the database given a valid Email
		/// </summary>
		public static User FindUserByEmail(string email)
		{
			using (ISession session = DatabaseManager.OpenSession())
			{
				IQuery query = session.CreateQuery("from User where Email = :email");
				query.SetParameter("email", email);
				
				try
				{
					var user = query.UniqueResult<User>();
					return user;
				}
				catch
				{
					return null;	
				}
				finally
				{
					session.Close();		
				}					
			}
		}
		
		
		/// <summary>
		/// Returns a User from the database given a valid RememberToken
		/// </summary>
		public static User FindUserByRememberToken(string token)
		{
			using (ISession session = DatabaseManager.OpenSession())
			{
				IQuery query = session.CreateQuery("from User where RememberToken = :token");
				query.SetParameter("token", token);
				
				try
				{
					var user = query.UniqueResult<User>();
					return user;
				}
				catch
				{
					return null;	
				}
				finally
				{
					session.Close();
				}
			}
		}
		
		
		/// <summary>
		/// Adds a new user to the database.
		/// </summary>
		public static void AddUserToDatabase(User user)
		{
			using (ISession session = DatabaseManager.OpenSession())
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
		
		
		/// <summary>
		/// Updates the user RememberToken in the database with a new given value
		/// </summary>
		public static void UpdateUserRememberToken(User user, string RememberToken)
		{
			// Find user in database
			// update RememberToken
			using (ISession session = DatabaseManager.OpenSession()) 
			{
                ITransaction transaction = session.BeginTransaction();
				
                IQuery query = session.CreateQuery("from User where UserId = :id");
				query.SetParameter("id", user.UserId); //ToString()?
				
                User userToUpdate = query.List<User>()[0];
                userToUpdate.RememberToken = RememberToken;
                transaction.Commit();

            }
		}
	}
}

