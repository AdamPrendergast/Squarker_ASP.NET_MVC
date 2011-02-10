<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<SquarkerApp.Models.User>" %>
<asp:Content ID="MainContentContent" ContentPlaceHolderID="MainContent" runat="server">

<h1>User model test</h1>

<p><%= Model.Name %> <%= Model.Email %></p>

</asp:Content>
