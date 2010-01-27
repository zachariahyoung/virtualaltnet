<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.Web.Controllers.RecordingsController.RecordingFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllersEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage" class="fade page-message"><%= ViewContext.TempData[ControllersEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<span class="wufoo">
<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Recording.Id", (ViewData.Model.Recording != null) ? ViewData.Model.Recording.Id : 0)%>

    <ul>
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
			<label class="desc">UploadedUrl</label>
			<span>
				<%= Html.TextBox("Recording.UploadedUrl", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.UploadedUrl.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.UploadedUrl")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">StartTime</label>
			<span>
				<%= Html.TextBox("Recording.StartTime", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.StartTime.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.StartTime")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">EndTime</label>
			<span>
				<%= Html.TextBox("Recording.EndTime", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.EndTime.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.EndTime")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">UpcomingEvent</label>
			<span>
				<%= Html.TextBox("Recording.UpcomingEvent", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.UpcomingEvent.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.UpcomingEvent")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">UserGroup</label>
			<span>
				<%= Html.TextBox("Recording.UserGroup", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.UserGroup.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.UserGroup")%>
			    </label>
			</span>
		</li>
		<li>
			<label class="desc">Category</label>
			<span>
				<%= Html.TextBox("Recording.Category", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.Category.ToString() : "")%>
			    <label>
			        <%= Html.ValidationMessage("Recording.Category")%>
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
