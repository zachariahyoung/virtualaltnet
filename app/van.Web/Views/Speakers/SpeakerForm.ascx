<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.ApplicationServices.ViewModels.SpeakerFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<div class="center-box">
<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Speaker.Id", (ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Id : 0)%>

    <ul>
		<li>
			<label for="Speaker_Name">Name:</label>
			<div>
				<%= Html.TextBox("Speaker.Name", 
					(ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Name.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.Name")%>
		</li>
		<li>
			<label for="Speaker_Email">Email:</label>
			<div>
				<%= Html.TextBox("Speaker.Email", 
					(ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Email.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.Email")%>
		</li>
		<li>
			<label for="Speaker_Bio">Bio:</label>
			<div>
				<%= Html.TextBox("Speaker.Bio",
                    (ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Bio.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.Bio")%>
		</li>
		<li>
			<label for="Speaker_Website">Website:</label>
			<div>
				<%= Html.TextBox("Speaker.Website", 
					(ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Website.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.Website")%>
		</li>

	    <li>
            <%= Html.SubmitButton("btnSave", "Save Speaker") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<SpeakersController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
</div>