<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<SquarkerApp.Models.User>" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">

	<table>
		<tr>
			<td class="main">
				<h1 class="user_name">
					<%= Model.Name %>
				</h1>
			</td>
			<td class="sidebar round">
				<strong>Name</strong> <%= Model.Name %><br />
				<strong>URL</strong>  <%= Html.ActionLink(Url.Action("show", "Users", new { id = Model.UserId }),
										  "show", "Users", new { id = Model.UserId }, null) %>
			</td>
		</tr>
	</table>

</asp:Content>
