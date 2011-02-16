<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Signup</h1>
	
	<% using (Html.BeginForm("create", "Users", new { httpMethod = "POST" })) { %>
		<div class="field">
			Name<br />
			<%= Html.TextBox("name") %>
		</div>
		<div class="field">
			Email<br />
			<%= Html.TextBox("email") %>
		</div>
		<div class="actions">
			<input type="submit" value="Create" />
		</div>
	<% } %>
	
</asp:Content>