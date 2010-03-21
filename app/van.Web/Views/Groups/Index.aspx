<%@ Page Title="Groups" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.GroupFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Groups</h2>
<div class="center-box">
    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>Name</th>
			    <th>Manager</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (van.Core.Group group in Model.Groups) { %>
			<tr>
				<td><%= group.Name%></td>
				<td><%= group.Manager.Name %></td>
				<td><%=Html.ActionLink<GroupsController>(c => c.Show(group.Id), "Details ")%></td>
				<td><%=Html.ActionLink<GroupsController>(c => c.Edit(group.Id), "Edit")%></td>
				<td>
    				<% using (Html.BeginForm<GroupsController>(c => c.Delete(group.Id)))
           { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<GroupsController>(c => c.Create(), "Create New Group") %></p>
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />
