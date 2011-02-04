<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<h1>Squark your friends...</h1>
		<p>...let them know about the cool things your doing... and they're not!</p>
		<%= Html.ActionLink("Signup", "New", "Users", null, new { @class = "signup_button round" }) %>
	</div>
</asp:Content>