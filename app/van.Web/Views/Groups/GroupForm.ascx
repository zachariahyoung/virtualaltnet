<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<GroupsController.GroupFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Group.Id", (ViewData.Model.Group != null) ? ViewData.Model.Group.Id : 0)%>

    <ul>
		<li>
			<label for="VirtualGroup_GroupName">GroupName:</label>
			<div>
				<%= Html.TextBox("Group.Name", 
					(ViewData.Model.Group != null) ? ViewData.Model.Group.Name.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.Name")%>
		</li>
		
				<li>
			<label for="VirtualGroup_ShortName">ShortName:</label>
			<div>
				<%= Html.TextBox("Group.ShortName",
               (ViewData.Model.Group != null) ? ViewData.Model.Group.ShortName.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.ShortName")%>
		</li>

		<li>
			<label for="VirtualGroup_Website">Website:</label>
			<div>
				<%= Html.TextBox("Group.Website", 
					(ViewData.Model.Group != null) ? ViewData.Model.Group.Website.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.Website")%>
		</li>
		<li>
			<label for="VirtualGroup_Manager">Manager:</label>
			<div>
				<%= this.Select("Group.Manager")
		                .FirstOption("0", "-- Select Product Category --")
                        .Options<User>(Model.Users, user => user.Id, user => user.UserName)
				        .Selected(
                          ViewData.Model.Group != null && ViewData.Model.Group.Manager != null
                                     ? ViewData.Model.Group.Manager.Id
				                : 0) %>
					
			</div>
			<%= Html.ValidationMessage("Group.Manager")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save Group") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<GroupsController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
