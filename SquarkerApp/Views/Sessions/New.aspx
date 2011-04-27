<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Sign in</h1>
	
	<% using (Html.BeginForm("Create", "Sessions", new { httpMethod = "POST" })) { %>
		<%= Html.AntiForgeryToken() %>
		
		<div class="field">
			<%= Html.Label("Email") %><br />
			<%= Html.TextBox("Email") %>
			<% // sessions model for validation perhaps %>	
		</div>
		
		<div class="field">
			<%= Html.Label("Password") %><br />
			<%= Html.Password("Password") %>
			<% // sessions model for validation perhaps %>	
		</div>
		
		<div class="actions">
			<input type="submit" value="Sign in" />
		</div>

	<% } %>

</asp:Content>
