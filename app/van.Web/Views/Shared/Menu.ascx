﻿<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="van.Web.Controllers" %>
<%@ Import Namespace="van.Web.Extensions" %>
<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Menu.ascx.cs" 
    Inherits="van.Web.Views.Shared.Menu" %>

<ul>
    <li class="first <%=Html.CurrentAction("Index", "Home") %>">
		<%= Html.ActionLink<HomeController>(x => x.Index(), "Virtual Alt.Net", new { id = "homeLink" })%></li>
		
	<li class="second <%=Html.CurrentAction("Calendar", "Calendar") %>">
		<%= Html.ActionLink<HomeController>(x => x.Calendar(), "Calendar")%></li>
		
    <li class="third <%=Html.CurrentAction("About", "About") %>">
		<%= Html.ActionLink<HomeController>(x => x.About(), "About")%></li>
		
    <li class="fourth <%=Html.CurrentAction("Index", "Recording") %>">
        <%= Html.ActionLink<RecordingsController>(x=>x.Index(), "Recordings") %></li>    
</ul>

<div id="menuIcons">
    <a href="http://twitter.com/virtualaltnet" alt="Follow Us On Twitter">
        <img src="<%= ResolveUrl("~") %>Content/Images/TwitterIcon.png" />
    </a>
        <a href="http://feeds2.feedburner.com/VirtualAltnet" alt="Feed me! Feed me!">
        <img src="<%= ResolveUrl("~") %>Content/Images/RssIcon.png" />
    </a>
</div>
