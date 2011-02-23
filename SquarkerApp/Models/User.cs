using System;
using System.ComponentModel.DataAnnotations;
	
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
		
		//[Required(ErrorMessage = "A password is required")]
		//public string Password { get; set; }
		
		//[Required(ErrorMessage = "A password confirmation is required")]
		//public string PasswordConfirmation { get; set; }
		
		//public string EncryptedPassword;
		
		public DateTime CreatedAt { get; set;}
		public DateTime UpdatedAt { get; set;}
		
		
		/// <summary>
		/// Methods
		/// </summary>
		
		public string EncryptPassword(string password)
		{
			// Encryption logic.
			
			return password;
		}
		

	}
}

