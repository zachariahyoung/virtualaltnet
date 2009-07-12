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
			<label class="desc">Title</label>
			<span>
				<%= Html.TextBox("Recording.Title", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.Title : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.Title")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">Url</label>
			<span>
				<%= Html.TextBox("Recording.Url", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.Url : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.Url")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">Date</label>
			<span>
				<%= Html.TextBox("Recording.Date", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.Date.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.Date")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">Duration</label>
			<span>
				<%= Html.TextBox("Recording.Duration", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.Duration : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.Duration")%>
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
