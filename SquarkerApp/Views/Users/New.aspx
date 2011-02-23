<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<SquarkerApp.Models.User>" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Signup</h1>
	
	<% using (Html.BeginForm("create", "Users", new { httpMethod = "POST" })) { %>
		<div class="field">
			<%= Html.LabelFor(model => model.Name) %><br />
			<%= Html.TextBoxFor(model => model.Name) %>
			<%= Html.ValidationMessageFor(model => model.Name) %>
		</div>
		<div class="field">
			<%= Html.LabelFor(model => model.Email) %><br />
			<%= Html.TextBoxFor(model => model.Email) %>
			<%= Html.ValidationMessageFor(model => model.Email) %>
		</div>
		<div class="actions">
			<input type="submit" value="Create" />
		</div>
	<% } %>
	
</asp:Content>