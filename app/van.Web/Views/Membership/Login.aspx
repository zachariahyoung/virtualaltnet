<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2> Login</h2>
    <div class="center-box">
    <% if( ViewData["ErrorMessage"] != null ){ %>
    <p>
        <% =ViewData["ErrorMessage"] %></p>
    <% } %>
    <% using( Html.BeginForm("Authenticate", "Membership" )){ %>
    <fieldset>
        <legend>Login</legend>
        <div>
            <label for="userName">
                User Name:</label>
            <% =Html.TextBox( "userName" ) %></div>
        <div>
            <label for="password">
                Password:</label>
            <% =Html.Password( "password" ) %></div>
        <div>
            <label for="rememberMe">
                Remember Me:</label>
            <input type="checkbox" id="rememberMe" name="rememberMe" checked="checked" value="checked" /></div>
        <div>
            <% =Html.SubmitButton() %></div>
        <% =Html.Hidden( "returnUrl", Request.QueryString["ReturnUrl"] ) %>
    </fieldset>
    <% } %>
    </div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />