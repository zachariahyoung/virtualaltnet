<%@ Page Title="VirtualGroups" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<IEnumerable<van.Core.VirtualGroup>>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>VirtualGroups</h1>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>GroupName</th>
			    <th>Website</th>
			    <th>Manager</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (VirtualGroup virtualGroup in ViewData.Model) { %>
			<tr>
				<td><%= virtualGroup.GroupName %></td>
				<td><%= virtualGroup.Website %></td>
				<td><%= virtualGroup.Manager %></td>
				<td><%=Html.ActionLink<VirtualGroupsController>( c => c.Show( virtualGroup.Id ), "Details ") %></td>
				<td><%=Html.ActionLink<VirtualGroupsController>( c => c.Edit( virtualGroup.Id ), "Edit") %></td>
				<td>
    				<% using (Html.BeginForm<VirtualGroupsController>(c => c.Delete(virtualGroup.Id))) { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<VirtualGroupsController>(c => c.Create(), "Create New group") %></p>
</asp:Content>
