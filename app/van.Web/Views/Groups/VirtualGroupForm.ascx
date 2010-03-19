<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.Web.Controllers.VirtualGroupsController.VirtualGroupFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("group.Id", (ViewData.Model.VirtualGroup != null) ? ViewData.Model.VirtualGroup.Id : 0)%>

    <ul>
		<li>
			<label for="VirtualGroup_GroupName">GroupName:</label>
			<div>
				<%= Html.TextBox("group.GroupName", 
					(ViewData.Model.VirtualGroup != null) ? ViewData.Model.VirtualGroup.GroupName.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("group.GroupName")%>
		</li>
		<li>
			<label for="VirtualGroup_Website">Website:</label>
			<div>
				<%= Html.TextBox("group.Website", 
					(ViewData.Model.VirtualGroup != null) ? ViewData.Model.VirtualGroup.Website.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("group.Website")%>
		</li>
		<li>
			<label for="VirtualGroup_Manager">Manager:</label>
			<div>
				<%= Html.TextBox("group.Manager", 
					(ViewData.Model.VirtualGroup != null) ? ViewData.Model.VirtualGroup.Manager.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("group.Manager")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save group") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<VirtualGroupsController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
