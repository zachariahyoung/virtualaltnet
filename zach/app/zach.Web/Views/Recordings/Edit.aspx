<%@ Page Title="Edit Recording" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<zach.Web.Controllers.RecordingsController.RecordingFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/ViewScripts/Recordings/RecordingForm.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Edit Recording</h1>

	<% Html.RenderPartial("RecordingForm", ViewData); %>

</asp:Content>
