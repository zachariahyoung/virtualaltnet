<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="van.Web.Controllers" %>
<%@ Import Namespace="van.Web.Extensions" %>
<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Menu.ascx.cs" 
    Inherits="van.Web.Views.Shared.Menu" %>


<ul>
	<li class="first <%=Html.CurrentAction("Index", "Home") %>">
		<%= Html.ActionLink<HomeController>(x=>x.Index(), "Home") %></li>
		
	<li class="second <%=Html.CurrentAction("Calendar", "Calendar") %>">
		<%= Html.ActionLink<HomeController>(x => x.Calendar(), "Calendar")%></li>
		
			<li class="third <%=Html.CurrentAction("About", "About") %>">
		<%= Html.ActionLink<HomeController>(x => x.About(), "About")%></li>
    <li class="fourth <%=Html.CurrentAction("Index", "Recording") %>">
        <%= Html.ActionLink<RecordingsController>(x=>x.Index(), "Recordings") %></li>
        
    <li class="fifth"><a href="<%= Url.Action("Blog","Home")%>" target="_blank">Blog</a></li>
</ul>
