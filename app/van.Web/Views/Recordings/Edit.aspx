<%@ Page Title="Edit Recording" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Recording>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<h2>Edit Recording</h2>

	<% Html.RenderPartial("RecordingForm", ViewData.Model, ViewData); %>
</asp:Content>
