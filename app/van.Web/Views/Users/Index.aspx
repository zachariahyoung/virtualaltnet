<%@ Page Title="Users" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<UsersViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Users</h2>
    <div class="center-box">
    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>UserName</th>
			    <th>Password</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (User user in Model.Users) { %>
			<tr>
				<td><%= user.UserName %></td>
				<td><%= user.Password %></td>
				<td><%=Html.ActionLink<UsersController>( c => c.Show( user.Id ), "Details ") %></td>
				<td><%=Html.ActionLink<UsersController>( c => c.Edit( user.Id ), "Edit") %></td>
				<td>
    				<% using (Html.BeginForm<UsersController>(c => c.Delete(user.Id))) { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<UsersController>(c => c.Create(), "Create New User") %></p>
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />