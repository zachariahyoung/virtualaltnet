<%@ Page Title="Recordings" Language="C#" 
MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true" 
Inherits="ViewPage<IEnumerable<Recording>>" %>
<%@ Import Namespace="System.Globalization"%>
<%@ Import Namespace="van.Core"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h2>Recordings</h2>

    <% if (ViewContext.TempData["message"] != null){ %>
        <p><%= ViewContext.TempData["message"]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>Subject</th>
			    <th>Date</th>
			    <th>Duration</th>
            </tr>
        </thead>

		<%
		foreach (Recording recordings in ViewData.Model) { %>
			<tr>
				<td> <a href="<%= recordings.RecordingUrl %>"><%= recordings.RecordingUrl %></a>
				</td>
				<td><%= recordings.RecordingDate.ToString("dd, MM", CultureInfo.InvariantCulture)%></td>
				<td><%= recordings.RecordingDuration %></td>
			</tr>
		<%} %>
    </table>


</asp:Content>
