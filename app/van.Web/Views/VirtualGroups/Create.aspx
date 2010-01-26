<%@ Page Title="Create VirtualGroup" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.VirtualGroupsController.VirtualGroupFormViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Create VirtualGroup</h1>

	<% Html.RenderPartial("VirtualGroupForm", ViewData); %>

</asp:Content>
