<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.ApplicationServices.ViewModels.StatusFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Status.Id", (ViewData.Model.Status != null) ? ViewData.Model.Status.Id : 0)%>

    <ul>
		<li>
			<label for="Status_Name">Name:</label>
			<div>
				<%= Html.TextBox("Status.Name", 
					(ViewData.Model.Status != null) ? ViewData.Model.Status.Name.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Status.Name")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save Status") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<StatusesController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
