<%@ Page Title="Speakers" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.SpeakerFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Speakers</h2>
    <div class="center-box">
    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <table>
        <thead>
            <tr>
			    <th>Name</th>			    
			    <th>Email</th>
			    <th>Website</th>
			    <th colspan="3">Action</th>
            </tr>
        </thead>

		<%
		foreach (Speaker speaker in Model.Speakers) { %>
			<tr>
				<td><%= speaker.Name %></td>
				<td><%= speaker.Email %></td>
				<td><%= speaker.Website %></td>

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
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />
