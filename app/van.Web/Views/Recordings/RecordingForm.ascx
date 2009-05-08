<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<RecordingsController.RecordingFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage" class="fade page-message"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<span class="wufoo">
<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Recording.Id", (ViewData.Model.Recording != null) ? ViewData.Model.Recording.Id : 0)%>

    <ul>
		<li>
			<label class="desc">RecordingTitle</label>
			<span>
				<%= Html.TextBox("Recording.RecordingTitle", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.RecordingTitle : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.RecordingTitle")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">RecordingUrl</label>
			<span>
				<%= Html.TextBox("Recording.RecordingUrl", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.RecordingUrl.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.RecordingUrl")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">RecordingDate</label>
			<span>
				<%= Html.TextBox("Recording.RecordingDate", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.RecordingDate.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.RecordingDate")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">RecordingDuration</label>
			<span>
				<%= Html.TextBox("Recording.RecordingDuration", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.RecordingDuration : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.RecordingDuration")%>
			    </label>
			</span>
		</li>
	    <li class="buttons">
            <%= Html.SubmitButton("btnSave", "Save Recording") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
					"window.location.href = '" + Html.BuildUrlFromExpression<RecordingsController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
