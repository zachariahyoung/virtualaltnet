<%@ Page Title="UpcomingEvent Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.UpcomingEvent>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>UpcomingEvent Details</h1>

    <ul>
		<li>
			<label for="UpcomingEvent_Title">Title:</label>
            <span id="UpcomingEvent_Title"><%= Server.HtmlEncode(ViewData.Model.Title.ToString()) %></span>
		</li>
		<li>
			<label for="UpcomingEvent_EventDate">EventDate:</label>
            <span id="UpcomingEvent_EventDate"><%= Server.HtmlEncode(ViewData.Model.EventDate.ToString()) %></span>
		</li>
		<li>
			<label for="UpcomingEvent_FullDescription">FullDescription:</label>
            <span id="UpcomingEvent_FullDescription"><%= Server.HtmlEncode(ViewData.Model.FullDescription.ToString()) %></span>
		</li>
		<li>
			<label for="UpcomingEvent_ShortDescription">ShortDescription:</label>
            <span id="UpcomingEvent_ShortDescription"><%= Server.HtmlEncode(ViewData.Model.ShortDescription.ToString()) %></span>
		</li>
		<li>
			<label for="UpcomingEvent_Presenter">Presenter:</label>
            <span id="UpcomingEvent_Presenter"><%= Server.HtmlEncode(ViewData.Model.Presenter.ToString()) %></span>
		</li>
		<li>
			<label for="UpcomingEvent_Approved">Approved:</label>
            <span id="UpcomingEvent_Approved"><%= Server.HtmlEncode(ViewData.Model.Approved.ToString()) %></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<UpcomingEventsController>(c => c.Index()) + "';") %>
        </li>
	</ul>

</asp:Content>
