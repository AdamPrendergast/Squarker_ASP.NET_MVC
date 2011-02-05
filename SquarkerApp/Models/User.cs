using System;
using System.ComponentModel.DataAnnotations;
	
namespace SquarkerApp.Models
{	
	public class User
	{
		public int UserId   { get; set; }
		
		public string Name  { get; set; }
		
		public string Email { get; set; }
	}
}
