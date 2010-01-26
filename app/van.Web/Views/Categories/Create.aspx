<%@ Page Title="Create Category" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.CategoriesController.CategoryFormViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Create Category</h1>

	<% Html.RenderPartial("CategoryForm", ViewData); %>

</asp:Content>
