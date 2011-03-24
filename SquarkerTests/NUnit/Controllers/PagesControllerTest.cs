using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NUnit.Framework;
using SquarkerApp.Helpers;

namespace SquarkerApp
{
	[TestFixture()]
	public class PagesControllerTest
	{
		/// <summary>
		/// Home Action
		/// </summary>
		[Test()]
		public void Home_Action_Should_Return_Home_View()
		{
			//Arrange
			var pagesController = new PagesController();
			
			//Act
			var result = pagesController.Home() as ViewResult;
			
			//Assert
			Assert.IsNotNull(result, "Should have returned a ViewResult");
			Assert.AreEqual("Home", result.ViewName, "View should have been Home");
		}
		
		[Test()]
		public void Home_ViewResult_Should_Have_The_Right_Title ()
		{
			string intendedTitle = "Squarker | Home";
			
			var pagesController = new PagesController();
			
			var result = pagesController.Home() as ViewResult;
			
			string actualTitle = ApplicationHelper.RenderTitle(result.ViewData);
			
			Assert.AreEqual(intendedTitle, actualTitle, "Home page title was incorrect");
		}
		
		
		/// <summary>
		/// Contact Action
		/// </summary>
		[Test()]
		public void Contact_Action_Should_Return_Contact_View()
		{
			//Arrange
			var pagesController = new PagesController();
			
			//Act
			var result = pagesController.Contact() as ViewResult;
			
			//Assert
			Assert.IsNotNull(result, "Should have returned a ViewResult");
			Assert.AreEqual("Contact", result.ViewName, "View should have been Contact");
		}
		
		[Test()]
		public void Contact_ViewResult_Should_Have_The_Right_Title ()
		{
			string intendedTitle = "Squarker | Contact";
			var pagesController = new PagesController();
			
			var result = pagesController.Contact() as ViewResult;
			
			string actualTitle = ApplicationHelper.RenderTitle(result.ViewData);
			
			Assert.AreEqual(intendedTitle, actualTitle, "Contact page title was incorrect");
		}
		
		
		/// <summary>
		/// About Action
		/// </summary>
		[Test()]
		public void About_Action_Should_Return_About_View()
		{
			//Arrange
			var pagesController = new PagesController();
			
			//Act
			var result = pagesController.About() as ViewResult;
			
			//Assert
			Assert.IsNotNull(result, "Should have returned a ViewResult");
			Assert.AreEqual("About", result.ViewName, "View should have been About");
		}
		
		[Test()]
		public void About_ViewResult_Should_Have_The_Right_Title ()
		{
			string intendedTitle = "Squarker | About";
			var pagesController = new PagesController();
			
			var result = pagesController.About() as ViewResult;
			
			string actualTitle = ApplicationHelper.RenderTitle(result.ViewData);
			
			Assert.AreEqual(intendedTitle, actualTitle, "About page title was incorrect");
		}
	}
}

