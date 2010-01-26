<%@ Page Title="Edit UpcomingEvent" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.UpcomingEventsController.UpcomingEventFormViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Edit UpcomingEvent</h1>

	<% Html.RenderPartial("UpcomingEventForm", ViewData); %>

</asp:Content>
