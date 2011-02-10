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
		
		[Required(ErrorMessage = "Username is required.")]
		[StringLength(50, ErrorMessage = "Username is too long")]
		// Unique
		public string Name  { get; set; }
		
		[Required(ErrorMessage = "A valid email is required.")]
		// Regex
		// Unique
		public string Email { get; set; }
		
		// Timestamps
		public DateTime CreatedAt { get; set;}
		public DateTime UpdatedAt { get; set;}
	}
}

