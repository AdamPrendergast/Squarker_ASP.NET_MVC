<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<SquarkerApp.Models.User>" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Test sign in submitted data.</h1>
	
	<p>Signed in: <%= Model.Name %> </p>

</asp:Content>