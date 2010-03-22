<%@ Page Title="Edit Group" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.GroupFormViewModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h2>Edit Group</h2>

	<% Html.RenderPartial("GroupForm", ViewData); %>

</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />
