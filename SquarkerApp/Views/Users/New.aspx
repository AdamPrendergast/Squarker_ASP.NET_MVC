<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<SquarkerApp.Models.User>" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Signup</h1>
	
	<% using (Html.BeginForm()) { %>
	
		<fieldset>
			<p>
				Name:  <%= Html.TextBox("name") %>
			</p>
			<p>
				Email: <%= Html.TextBox("email") %>
			</p>
			<p>
				<input type="submit" value="Create" />
			</p>
		</fieldset>
	<% } %>
	
</asp:Content>
