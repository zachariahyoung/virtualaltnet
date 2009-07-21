
<%@ Import Namespace="Microsoft.Web.Mvc"%>
<%@ Import Namespace="van.Web.Controllers"%>
<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Menu.ascx.cs" 
    Inherits="van.Web.Views.Shared.Menu" %>
<%@ Import Namespace="van.Web.Extensions"%>

<ul>
	<li class="first <%=Html.CurrentAction("Index", "Home") %>">
		<%= Html.ActionLink<HomeController>(x=>x.Index(), "Home") %></li>
		
	<li class="first <%=Html.CurrentAction("Calendar", "Calendar") %>">
		<%= Html.ActionLink<HomeController>(x => x.Calendar(), "Calendar")%></li>
		
			<li class="first <%=Html.CurrentAction("About", "About") %>">
		<%= Html.ActionLink<HomeController>(x => x.About(), "About")%></li>
    <li class="third <%=Html.CurrentAction("Index", "Recording") %>">
        <%= Html.ActionLink<RecordingsController>(x=>x.Index(), "Recordings") %></li>
</ul>
