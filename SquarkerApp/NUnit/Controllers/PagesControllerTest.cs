using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NUnit.Framework;

namespace SquarkerApp
{
	[TestFixture()]
	public class PagesControllerTest
	{
		const string title = "Squarker - ";
		
		
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
			string pageTitle = title + "Home";
			var pagesController = new PagesController();
			
			var result = pagesController.Home() as ViewResult;
			
			Assert.AreEqual(pageTitle, result.ViewData["Title"], "Home page title was incorrect");
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
			string pageTitle = title + "Contact";
			var pagesController = new PagesController();
			
			var result = pagesController.Contact() as ViewResult;
			
			Assert.AreEqual(pageTitle, result.ViewData["Title"], "Contact page title was incorrect");
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
			string pageTitle = title + "About";
			var pagesController = new PagesController();
			
			var result = pagesController.About() as ViewResult;
			
			Assert.AreEqual(pageTitle, result.ViewData["Title"], "About page title was incorrect");
		}
	}
}

