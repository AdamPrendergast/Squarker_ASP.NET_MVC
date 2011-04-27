using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
	
namespace SquarkerApp.Models
{	
	[PropertiesMustMatch("Password", "PasswordConfirmation", ErrorMessage = "The password confirmation does not match.")]
	public class User
	{	
		
	/// <summary>
	/// Properties
	/// </summary>
		
		public int UserId   { get; set; }
		
		[Required(ErrorMessage = "A username is required.")]
		[StringLength(50, ErrorMessage = "Username is too long")]
		public string Name  { get; set;}
		
		[Required(ErrorMessage = "An email address is required.")]
		//RegularExpressionAttribute not yet implemented by Mono.
		public string Email { get; set; }
		
		[Required(ErrorMessage = "A password is required")]
		public string Password { get; set; }
		
		[Required(ErrorMessage = "A password confirmation is required")]
		public string PasswordConfirmation { get; set; }
		
		private string Salt { get; set; }
		private string EncryptedPassword { get; set; }
		
		public string RememberToken { get; set; }
		
		public DateTime CreatedAt { get; set;}
		public DateTime UpdatedAt { get; set;}
		
		
	// METHODS
	
		/// <summary>
		/// Sets the RememberToken when a user signs in.
		/// </summary>
		public string RememberMe()
		{
			RememberToken = Encrypt(UserId + DateTime.UtcNow.ToString());
			
			UserRepository.UpdateUserRememberToken(this, RememberToken);
			
			return RememberToken;
		}
		
		///<summary>
		/// Verifies the encryption of a submitted password
		/// </summary>
		public bool HasPassword(string submittedPassword)
		{
			if (EncryptedPassword != Encrypt(submittedPassword))
			    return false;
			 return true;
		}
		
		
		/// <summary>
		/// Encrypts the Password property of the user instance.
		/// </summary>
		public void EncryptPassword()
		{
			if (NewRecord() == true)
				Salt = MakeSalt();
			
			EncryptedPassword = Encrypt(Password);
		}
		
		
		/// <summary>
		/// Authenticates submitted email and password attributes.
		/// </summary>
		public static User Authenticate(string email, string submittedPassword)
		{
			User userToAuthenticate = UserRepository.FindUserByEmail(email);
			
			if (userToAuthenticate == null)
			{
				return null;
			}
			else
			{
				if (userToAuthenticate.HasPassword(submittedPassword) == true)
				{
					return userToAuthenticate;
				}
				else
				{
					return null;	
				}
			}
		}
			
		
	// PRIVATE METHODS
		
		
		/// <summary>
		/// Checks if this user instance has already been saved
		/// </summary>
		private bool NewRecord()
		{
			User checkUser = UserRepository.FindUserByName(Name);
			
			if (checkUser != null)
				return false;	
			return true;
		}
		
		
		/// <summary>
		/// Creates Salt for use with password encryption
		/// </summary>
		private string MakeSalt()
		{
			string ingredients = DateTime.Now.ToString() + Password;
			
			return SecureHash(ingredients);
		}
		
		
		/// <summary>
		/// Encrypts a given striung with User.Salt
		/// </summary>
		private string Encrypt(string s)
		{
			string ingredients = Salt + s;
			
			return SecureHash(ingredients);
		}
		
		
		/// <summary>
		/// Encrypts the password and salt
		/// </summary>
		private string SecureHash(string ingredients)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			
			Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(ingredients);
			Byte[]  encodedBytes = md5.ComputeHash(originalBytes);
			
			return BitConverter.ToString(encodedBytes);
		}
		
	}
}

