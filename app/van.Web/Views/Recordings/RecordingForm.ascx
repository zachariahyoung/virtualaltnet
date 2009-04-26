<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.Core.Recording>" %>
<%@ Import Namespace="van.Core" %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("id", (ViewData.Model != null) ? ViewData.Model.Id : 0) %>

    <ul>
		<li>
			<label for="Recording_RecordingTitle">RecordingTitle:</label>
			<div>
				<%= Html.TextBox("Recording.RecordingTitle", 
					(ViewData.Model != null) ? ViewData.Model.RecordingTitle.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Recording.RecordingTitle")%>
		</li>
		<li>
			<label for="Recording_RecordingUrl">RecordingUrl:</label>
			<div>
				<%= Html.TextBox("Recording.RecordingUrl", 
					(ViewData.Model != null) ? ViewData.Model.RecordingUrl.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Recording.RecordingUrl")%>
		</li>
		<li>
			<label for="Recording_RecordingDate">RecordingDate:</label>
			<div>
				<%= Html.TextBox("Recording.RecordingDate", 
					(ViewData.Model != null) ? ViewData.Model.RecordingDate.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Recording.RecordingDate")%>
		</li>
		<li>
			<label for="Recording_RecordingDuration">RecordingDuration:</label>
			<div>
				<%= Html.TextBox("Recording.RecordingDuration", 
					(ViewData.Model != null) ? ViewData.Model.RecordingDuration.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Recording.RecordingDuration")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save Recording") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
	                        "window.location.href = '" + ResolveUrl("~") + "Recordings';") %>
        </li>
    </ul>
<% } %>
