<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.ApplicationServices.ViewModels.RecordingFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<div class="center-box">
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
         <li>
            <label class="desc">Speaker</label>
			<div>
				<%= this.Select("Recording.Speaker")
		                .FirstOption("0", "-- Select Speaker --")
                        .Options<Speaker>(ViewData.Model.Speakers, speaker => speaker.Id, speaker => speaker.Name)
				        .Selected(
                             ViewData.Model.Recording != null && ViewData.Model.Recording.Speaker != null
                                                    ? ViewData.Model.Recording.Speaker.Id
				                : 0) %>
			</div>
			<%= Html.ValidationMessage("Recording.Speaker")%>        </li>


                     <li>
            <label class="desc">Group</label>
			<div>
				<%= this.Select("Recording.Group")
		                .FirstOption("0", "-- Select Group --")
                        .Options<van.Core.Group>(ViewData.Model.Groups, group => group.Id, group => group.ShortName)
				        .Selected(
                           ViewData.Model.Recording != null && ViewData.Model.Recording.Group != null
                               ? ViewData.Model.Recording.Group.Id
				               : 0) %>
			</div>
			<%= Html.ValidationMessage("Recording.Group")%>        </li>

        <li>
            <label class="desc"> Live Meeting Url</label>
            <span>
                <%= Html.TextBox("Recording.LiveMeetingUrl",
                                        (ViewData.Model.Recording != null) ? ViewData.Model.Recording.LiveMeetingUrl : "")%>
                <label>
                    <%= Html.ValidationMessage("Recording.LiveMeetingUrl")%>
                </label>
            </span></li>
        <li>
            <label class="desc">Description</label>
            <span>
                <%= Html.TextArea("Recording.Description",
                                                            (ViewData.Model.Recording != null) ? ViewData.Model.Recording.Description : "")%>
                <label>
                    <%= Html.ValidationMessage("Recording.Description")%>
                </label>
            </span></li>
	    <li class="buttons">
            <%= Html.SubmitButton("btnSave", "Save Recording") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
					"window.location.href = '" + Html.BuildUrlFromExpression<RecordingsController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
</div>