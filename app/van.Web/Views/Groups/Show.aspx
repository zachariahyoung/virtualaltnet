<%@ Page Title="VirtualGroup Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<GroupsViewModel>" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h2>Group Details</h2>
<div class="center-box">
    <ul>
		<li>
			<label for="VirtualGroup_Name">Name:</label>
            <span id="VirtualGroup_GroupName"><%= Server.HtmlEncode(Model.SingleGroup.Name.ToString())%></span>
		</li>
				<li>
			<label for="VirtualGroup_GroupName">Short Name:</label>
            <span id="Span1"><%= Server.HtmlEncode(Model.SingleGroup.ShortName.ToString())%></span>
		</li>

		<li>
			<label for="VirtualGroup_Website">Website:</label>
            <span id="VirtualGroup_Website"><%= Server.HtmlEncode(Model.SingleGroup.Website.ToString())%></span>
		</li>
		<li>
			<label for="VirtualGroup_Manager">Manager:</label>
            <span id="VirtualGroup_Manager"><%= Server.HtmlEncode(Model.SingleGroup.Manager.UserName.ToString())%></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<GroupsController>(c => c.Index()) + "';") %>
        </li>
	</ul>
</div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />