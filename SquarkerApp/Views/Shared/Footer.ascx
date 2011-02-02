<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<footer>
  <nav class="round">
    <ul>
      <li><%= Html.ActionLink("About", "About", "Pages") %></li>
      <li><%= Html.ActionLink("Contact", "Contact", "Pages") %></li>
    </ul>
  </nav>
</footer>