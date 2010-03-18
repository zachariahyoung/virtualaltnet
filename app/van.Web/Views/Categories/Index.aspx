<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<CategoriesViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Categories</h2>
    <div class="center-box">

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>Description</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
            foreach (Category category in Model.Categories)
            { %>
			<tr>
				<td><%= category.Description %></td>
				<td><%=Html.ActionLink<CategoriesController>( c => c.Show( category.Id ), "Details ") %></td>
				<td><%=Html.ActionLink<CategoriesController>( c => c.Edit( category.Id ), "Edit") %></td>
				<td>
    				<% using (Html.BeginForm<CategoriesController>(c => c.Delete(category.Id))) { %>
                        <%= Html.AntiForgeryToken() %>
    				    <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
                    <% } %>
				</td>
			</tr>
		<%} %>
    </table>

    <p><%= Html.ActionLink<CategoriesController>(c => c.Create(), "Create New Category") %></p>
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />