<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="SquarkerApp.Sessions" %>
<header>
	
	<a href="<%= Url.Action("Home", "Pages") %>">
		<img src="<%= Url.Content("/Content/images/logo.png") %>" alt="Squarker Logo" class="round" />
	</a>
	
	<nav class="round">
		
		<% if (SessionManager.SignedIn() == true) { %>
			
			<ul>
				<li><%= Html.ActionLink("Home", "Show", "Users",
					new { id = SessionManager.GetCurrentUserId() }, null) %></li>
				<li><%= Html.ActionLink("People", "Index", "Users") %></li>
				<li><%= Html.ActionLink("Help", "Help", "Pages") %></li>
				<li><%= Html.ActionLink("Sign out", "Destroy", "Sessions") %></li>
			</ul>
		
		<% } else { %>
		
			<ul>
				<li><%= Html.ActionLink("Home", "Home", "Pages") %></li>
				<li><%= Html.ActionLink("Help", "Help", "Pages") %></li>
				<li><%= Html.ActionLink("Sign in", "New", "Sessions") %></li>
			</ul>
			
		<% } %>
	</nav>
</header>