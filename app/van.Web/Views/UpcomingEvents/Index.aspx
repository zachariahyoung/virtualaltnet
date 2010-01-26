<%@ Page Title="UpcomingEvents" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<IEnumerable<van.Core.UpcomingEvent>>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>UpcomingEvents</h1>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>Title</th>
			    <th>EventDate</th>
			    <th>FullDescription</th>
			    <th>ShortDescription</th>
			    <th>Presenter</th>
			    <th>Approved</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (UpcomingEvent upcomingEvent in ViewData.Model) { %>
			<tr>
				<td><%= upcomingEvent.Title %></td>
				<td><%= upcomingEvent.EventDate %></td>
				<td><%= upcomingEvent.FullDescription %></td>
				<td><%= upcomingEvent.ShortDescription %></td>
				<td><%= upcomingEvent.Presenter %></td>
				<td><%= upcomingEvent.Approved %></td>
				<td><%=Html.ActionLink<UpcomingEventsController>( c => c.Show( upcomingEvent.Id ), "Details ") %></td>
				<td><%=Html.ActionLink<UpcomingEventsController>( c => c.Edit( upcomingEvent.Id ), "Edit") %></td>
				<td>
    				<% using (Html.BeginForm<UpcomingEventsController>(c => c.Delete(upcomingEvent.Id))) { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<UpcomingEventsController>(c => c.Create(), "Create New UpcomingEvent") %></p>
</asp:Content>
