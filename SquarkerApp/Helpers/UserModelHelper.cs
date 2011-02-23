using System;
using System.ComponentModel.DataAnnotations;

namespace SquarkerApp.Helpers
{
	
	/// <summary>
	/// Validates correct email format.
	/// </summary>
	public class EmailAttribute : RegularExpressionAttribute
	{
		public EmailAttribute()
			: base("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$") {}
	}
}

