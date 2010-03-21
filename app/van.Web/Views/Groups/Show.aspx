<%@ Page Title="Group Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.GroupFormViewModel>" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h2>Group Details</h2>
<div class="center-box">
    <ul>
		<li>
			<label for="Group_Name">Name:</label>
            <span id="Group_Name"><%= Server.HtmlEncode(Model.Group.Name.ToString())%></span>
		</li>
		<li>
			<label for="Group_ShortName">Short Name:</label>
            <span id="Group_ShortName"><%= Server.HtmlEncode(Model.Group.ShortName.ToString())%></span>
		</li>
		<li>
			<label for="Group_Blog">Blog:</label>
            <span id="Group_Blog"><%= Server.HtmlEncode(Model.Group.Blog.ToString())%></span>
		</li>
		<li>
			<label for="Group_Rss">Rss:</label>
            <span id="Group_Rss"><%= Server.HtmlEncode(Model.Group.Rss.ToString())%></span>
		</li>

		<li>
			<label for="Group_Manager">Manager:</label>
            <span id="Group_Manager"><%= Server.HtmlEncode(Model.Group.Manager.Name.ToString())%></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<GroupsController>(c => c.Index()) + "';") %>
        </li>
	</ul>
</div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />