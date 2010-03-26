<%@ Page Title="Statuses" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.StatusFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Statuses</h2>
<div class="center-box">
    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>Name</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (Status status in Model.Statuses) { %>
			<tr>
				<td><%= status.Name %></td>
				<td><%=Html.ActionLink<StatusesController>( c => c.Show( status.Id ), "Details ") %></td>
				<td><%=Html.ActionLink<StatusesController>( c => c.Edit( status.Id ), "Edit") %></td>
				<td>
    				<% using (Html.BeginForm<StatusesController>(c => c.Delete(status.Id))) { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<StatusesController>(c => c.Create(), "Create New Status") %></p>
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />