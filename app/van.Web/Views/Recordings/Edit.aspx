<%@ Page Title="Edit Recording" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.RecordingFormViewModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
    <script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/ViewScripts/Recordings/RecordingForm.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<h2>Edit Recording</h2>
	

	<% Html.RenderPartial("RecordingForm", ViewData); %>

</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />