<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.User>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>User Details</h1>

    <ul>
		<li>
			<label for="User_UserName">UserName:</label>
            <span id="User_UserName"><%= Server.HtmlEncode(ViewData.Model.UserName.ToString()) %></span>
		</li>
		<li>
			<label for="User_Password">Password:</label>
            <span id="User_Password"><%= Server.HtmlEncode(ViewData.Model.Password.ToString()) %></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<UsersController>(c => c.Index()) + "';") %>
        </li>
	</ul>

</asp:Content>
