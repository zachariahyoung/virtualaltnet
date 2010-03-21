<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.Web.Controllers.SpeakersController.SpeakerFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Speaker.Id", (ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Id : 0)%>

    <ul>
		<li>
			<label for="Speaker_FirstName">FirstName:</label>
			<div>
				<%= Html.TextBox("Speaker.FirstName", 
					(ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.FirstName.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.FirstName")%>
		</li>
		<li>
			<label for="Speaker_LastName">LastName:</label>
			<div>
				<%= Html.TextBox("Speaker.LastName", 
					(ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.LastName.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.LastName")%>
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
			<label for="Speaker_Website">Website:</label>
			<div>
				<%= Html.TextBox("Speaker.Blog", 
					(ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Website.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.Blog")%>
		</li>
		<li>
			<label for="Speaker_Presentation">Presentation:</label>
			<div>
				<%= Html.TextBox("Speaker.Presentation", 
					(ViewData.Model.Speaker != null) ? ViewData.Model.Speaker.Presentation.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Speaker.Presentation")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save Speaker") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<SpeakersController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
