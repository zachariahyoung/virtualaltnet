<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.Web.Controllers.UpcomingEventsController.UpcomingEventFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("UpcomingEvent.Id", (ViewData.Model.UpcomingEvent != null) ? ViewData.Model.UpcomingEvent.Id : 0)%>

    <ul>
		<li>
			<label for="UpcomingEvent_Title">Title:</label>
			<div>
				<%= Html.TextBox("UpcomingEvent.Title", 
					(ViewData.Model.UpcomingEvent != null) ? ViewData.Model.UpcomingEvent.Title.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("UpcomingEvent.Title")%>
		</li>
		<li>
			<label for="UpcomingEvent_EventDate">EventDate:</label>
			<div>
				<%= Html.TextBox("UpcomingEvent.EventDate", 
					(ViewData.Model.UpcomingEvent != null) ? ViewData.Model.UpcomingEvent.EventDate.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("UpcomingEvent.EventDate")%>
		</li>
		<li>
			<label for="UpcomingEvent_FullDescription">FullDescription:</label>
			<div>
				<%= Html.TextBox("UpcomingEvent.FullDescription", 
					(ViewData.Model.UpcomingEvent != null) ? ViewData.Model.UpcomingEvent.FullDescription.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("UpcomingEvent.FullDescription")%>
		</li>
		<li>
			<label for="UpcomingEvent_ShortDescription">ShortDescription:</label>
			<div>
				<%= Html.TextBox("UpcomingEvent.ShortDescription", 
					(ViewData.Model.UpcomingEvent != null) ? ViewData.Model.UpcomingEvent.ShortDescription.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("UpcomingEvent.ShortDescription")%>
		</li>
		<li>
			<label for="UpcomingEvent_Presenter">Presenter:</label>
			<div>
				<%= Html.TextBox("UpcomingEvent.Presenter", 
					(ViewData.Model.UpcomingEvent != null) ? ViewData.Model.UpcomingEvent.Presenter.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("UpcomingEvent.Presenter")%>
		</li>
		<li>
			<label for="UpcomingEvent_Approved">Approved:</label>
			<div>
				<%= Html.TextBox("UpcomingEvent.Approved", 
					(ViewData.Model.UpcomingEvent != null) ? ViewData.Model.UpcomingEvent.Approved.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("UpcomingEvent.Approved")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save UpcomingEvent") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<UpcomingEventsController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
