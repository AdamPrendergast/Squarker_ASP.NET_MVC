using System;
using System.Collections.Generic;

namespace SquarkerApp.Helpers
{
	public class ApplicationHelper
	{
		/// <summary>
		/// Renders the page title in the view.
		/// </summary>
		public static string RenderTitle(IDictionary<string, object> title)
		{
			if (title.ContainsKey("Title"))
			{
				string fullTitle = "Squarker | " + title["Title"];
				return fullTitle;
			} else
			{
				string fullTitle = "Squarker";
				return fullTitle;
			}
		}
		
	}
}

