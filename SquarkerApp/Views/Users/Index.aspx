<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IList<SquarkerApp.Models.User>>" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">

	<% foreach (var user in Model) { %>
		<li>
			<%= user.Name %>
		</li>
	<% } %>
	
</asp:Content>
