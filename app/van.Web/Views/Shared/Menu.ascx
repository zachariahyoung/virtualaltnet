
<%@ Import Namespace="Microsoft.Web.Mvc"%>
<%@ Import Namespace="van.Web.Helpers"%>
<%@ Import Namespace="van.Web.Controllers"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="van.Web.Views.Shared.Menu" %>

<ul>
	<li class="first <%=Html.CurrentAction("Index", "Home") %>">
		<%= Html.ActionLink<HomeController>(x=>x.Index(), "Home") %></li>
	<li class="second <%=Html.CurrentAction("Index", "Calendar") %>">
		<%= Html.ActionLink<CalendarController>(x=>x.Index(), "Calendar") %></li>
    <li class="third <%=Html.CurrentAction("Index", "Recording") %>">
        <%= Html.ActionLink<RecordingsController>(x=>x.Index(), "Recording") %></li>
</ul>
