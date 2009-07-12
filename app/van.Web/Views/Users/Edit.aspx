<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.UsersController.UserFormViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Edit User</h1>

	<% Html.RenderPartial("UserForm", ViewData); %>

</asp:Content>
