<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.RecordingFormViewModel>" %>
<%@ Import Namespace="van.Core.Dto"%>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Events</h2>
<div class="center-box">
    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>Title</th>
			    <th>Speaker</th>
			    <th>Date</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (RecordingDto recording in Model.Recordings) { %>
			<tr>
				<td><%= recording.Title%></td>
				<td><%= recording.Speaker %></td>
				<td><%= recording.Date %></td>
				<td><%=Html.ActionLink<RecordingsController>(c => c.Show(recording.Id), "Details ")%></td>
				<td><%=Html.ActionLink<RecordingsController>(c => c.Edit(recording.Id), "Edit")%></td>
				<td>
    				<% using (Html.BeginForm<RecordingsController>(c => c.Delete(recording.Id)))
           { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<RecordingsController>(c => c.Create(), "Create New Event") %></p>
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />
