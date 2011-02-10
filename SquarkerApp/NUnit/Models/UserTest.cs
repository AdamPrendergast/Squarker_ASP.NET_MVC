using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SquarkerApp.Models;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace SquarkerApp
{
	[TestFixture()]
	public class UserTest
	{	
		[Test()]
		public void User_model_Name_is_required()
		{
			// Arrange
			var propertyInfo = typeof(User).GetProperty("Name");
			
			// Act
			var attribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), true)
										.Cast<RequiredAttribute>()
										.FirstOrDefault();
			
			// Assert
			Assert.IsNotNull(attribute);
		}
		
		[Test()]
		public void User_model_Email_is_required()
		{
			// Arrange
			var propertyType = typeof(User).GetProperty("Email");
			
			// Act
			var attribute = propertyType.GetCustomAttributes(typeof(RequiredAttribute), true)
										.Cast<RequiredAttribute>()
										.FirstOrDefault();
			
			// Assert
			Assert.IsNotNull(attribute);
		}
	}
}

