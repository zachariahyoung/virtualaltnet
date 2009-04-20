<%@ Page Title="" Language="C#" 
MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true" 
Inherits="ViewPage<IEnumerable<Recording>>" %>
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
			    <th>RecordingTitle</th>
			    <th>RecordingURL</th>
            </tr>
        </thead>

		<%
		foreach (Recording recordings in ViewData.Model) { %>
			<tr>
				<td><%= recordings.RecordingTitle %></td>
				<td><%= recordings.RecordingUrl %></td>
			</tr>
		<%} %>
    </table>


</asp:Content>
