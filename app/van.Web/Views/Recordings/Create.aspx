<%@ Page Title="Create Recording" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Recording>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<h2>Create Recording</h2>

	<% Html.RenderPartial("RecordingForm", ViewData); %>
</asp:Content>
