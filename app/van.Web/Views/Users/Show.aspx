<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<UsersViewModel>" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h2>User Details</h2>
    <div class="center-box">
    <ul>
		<li>
			<label for="User_UserName">UserName:</label>
            <span id="User_UserName"><%= Server.HtmlEncode(Model.SingleUser.UserName) %></span>
		</li>
		<li>
			<label for="User_Password">Password:</label>
            <span id="User_Password"><%= Server.HtmlEncode(Model.SingleUser.UserName)%></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<UsersController>(c => c.Index()) + "';") %>
        </li>
	</ul>
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />