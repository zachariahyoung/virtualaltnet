<%@ Page Title="Create Recording" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
    AutoEventWireup="true" 
    Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.RecordingsController.RecordingFormViewModel>" 
%>
<asp:Content ID="Content2" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
    <script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/ViewScripts/Recordings/RecordingForm.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Create Recording</h1>

	<% Html.RenderPartial("RecordingForm", ViewData); %>

</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />