<%@ Page Title="Recording Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Recording>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Recording Details</h2>

    <ul>
		<li>
			<label for="Recording.RecordingTitle">Title:</label>
            <span id="Recording.RecordingTitle"><%= ViewData.Model.RecordingTitle %></span>
		</li>
		<li>
			<label for="Recording.RecordingUrl">Url:</label>
            <span id="Recording.RecordingUrl"><%= ViewData.Model.RecordingUrl %></span>
		</li>
		<li>
			<label for="Recording.RecordingDate"Date:</label>
            <span id="Recording.RecordingDate"><%= ViewData.Model.RecordingDate %></span>
		</li>
		<li>
			<label for="Recording.RecordingDuration">Duration:</label>
            <span id="Recording.RecordingDuration"><%= ViewData.Model.RecordingDuration %></span>
		</li>
	</ul>
</asp:Content>
