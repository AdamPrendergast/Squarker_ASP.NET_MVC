using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
	
namespace SquarkerApp.Models
{	
	public class User
	{	
		
/// <summary>
/// Properties
/// </summary>
		
		public int UserId   { get; set; }
		
		[Required(ErrorMessage = "A username is required.")]
		[StringLength(50, ErrorMessage = "Username is too long")]
		public string Name  { get; set; }
		
		[Required(ErrorMessage = "An email address is required.")]
		//RegularExpressionAttribute not yet implemented by Mono.
		public string Email { get; set; }
		
		[Required(ErrorMessage = "A password is required")]
		public string Password { get; set; }
		
		[Required(ErrorMessage = "A password confirmation is required")]
		public string PasswordConfirmation { get; set; }
		
		public string Salt { get; set; } // make private
		public string EncryptedPassword { get; set; } // make private
		
		public DateTime CreatedAt { get; set;}
		public DateTime UpdatedAt { get; set;}
		
		
/// <summary>
/// Methods
/// </summary>
		
		public void EncryptPassword()
		{
			if (NewRecord() == true)
			{
				Salt = MakeSalt();
			}
			EncryptedPassword = Encrypt(Password);
		}
		
		
/// <summary>
/// Private Methods
/// </summary>
		
		private bool NewRecord()
		{
			User checkUser = UserRepository.FindUser(Name);
			
			if (checkUser != null)
			{
				return false;	
			}
			
			return true;
		}
		
		private string MakeSalt()
		{
			string ingredients = DateTime.Now.ToString() + Password;
			
			return SecureHash(ingredients);
		}
		
		private string Encrypt(string password)
		{
			string ingredients = Salt + password;
			
			return SecureHash(ingredients);
		}
		
		private string SecureHash(string ingredients)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			
			Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(ingredients);
			Byte[]  encodedBytes = md5.ComputeHash(originalBytes);
			
			return BitConverter.ToString(encodedBytes);
		}
		
	}
}

