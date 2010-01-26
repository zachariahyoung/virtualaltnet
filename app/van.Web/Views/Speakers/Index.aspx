<%@ Page Title="Speakers" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<IEnumerable<van.Core.Speaker>>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Speakers</h1>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>FirstName</th>
			    <th>LastName</th>
			    <th>Email</th>
			    <th>Website</th>
			    <th>Presentation</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (Speaker speaker in ViewData.Model) { %>
			<tr>
				<td><%= speaker.FirstName %></td>
				<td><%= speaker.LastName %></td>
				<td><%= speaker.Email %></td>
				<td><%= speaker.Website %></td>
				<td><%= speaker.Presentation %></td>
				<td><%=Html.ActionLink<SpeakersController>( c => c.Show( speaker.Id ), "Details ") %></td>
				<td><%=Html.ActionLink<SpeakersController>( c => c.Edit( speaker.Id ), "Edit") %></td>
				<td>
    				<% using (Html.BeginForm<SpeakersController>(c => c.Delete(speaker.Id))) { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<SpeakersController>(c => c.Create(), "Create New Speaker") %></p>
</asp:Content>
