<%@ Page Title="Edit Speaker" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.SpeakersController.SpeakerFormViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

	<h1>Edit Speaker</h1>

	<% Html.RenderPartial("SpeakerForm", ViewData); %>

</asp:Content>
