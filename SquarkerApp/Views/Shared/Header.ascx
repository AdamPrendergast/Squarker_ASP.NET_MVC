<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<header>
	<a href="<%= Url.Action("Home", "Pages") %>">
		<img src="<%= Url.Content("/Content/images/logo.png") %>" alt="Squarker Logo" class="round" />
	</a>
	<nav class="round">
		<ul>
			<li><%= Html.ActionLink("Home", "Home", "Pages") %></li>
			<li><%= Html.ActionLink("Help", "Help", "Pages") %></li>
			<li><%= Html.ActionLink("Sign in", "#") %></li>
		</ul>
	</nav>
</header>