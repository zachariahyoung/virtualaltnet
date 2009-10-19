<%@ Page Title="Create User" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.UsersController.UserFormViewModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Create User</h1>

	<% Html.RenderPartial("UserForm", ViewData); %>

</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />