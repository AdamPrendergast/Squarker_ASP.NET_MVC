<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<footer>
  <nav class="round">
    <ul>
      <li><%= Html.ActionLink("About", "#") %></li>
      <li><%= Html.ActionLink("Contact", "#") %></li>
    </ul>
  </nav>
</footer>