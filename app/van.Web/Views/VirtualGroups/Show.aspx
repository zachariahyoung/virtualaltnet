<%@ Page Title="VirtualGroup Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.VirtualGroup>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>VirtualGroup Details</h1>

    <ul>
		<li>
			<label for="VirtualGroup_GroupName">GroupName:</label>
            <span id="VirtualGroup_GroupName"><%= Server.HtmlEncode(ViewData.Model.GroupName.ToString()) %></span>
		</li>
		<li>
			<label for="VirtualGroup_Website">Website:</label>
            <span id="VirtualGroup_Website"><%= Server.HtmlEncode(ViewData.Model.Website.ToString()) %></span>
		</li>
		<li>
			<label for="VirtualGroup_Manager">Manager:</label>
            <span id="VirtualGroup_Manager"><%= Server.HtmlEncode(ViewData.Model.Manager.ToString()) %></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<VirtualGroupsController>(c => c.Index()) + "';") %>
        </li>
	</ul>

</asp:Content>
