<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<header>
	<img src="<%= Url.Content("/Content/images/logo.png") %>" alt="Squarker Logo" class="round" />
	<nav class="round">
		<ul>
			<li><%= Html.ActionLink("Home", "#") %></li>
			<li><%= Html.ActionLink("Help", "#") %></li>
			<li><%= Html.ActionLink("Sign in", "#") %></li>
		</ul>
	</nav>
</header>