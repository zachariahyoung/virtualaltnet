
<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.ApplicationServices.ViewModels.GroupFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<div class="center-box">
<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Group.Id", (ViewData.Model.Group != null) ? ViewData.Model.Group.Id : 0)%>

    <ul>
		<li>
			<label for="Group_Name">Name:</label>
			<div>
				<%= Html.TextBox("Group.Name", 
					(ViewData.Model.Group != null) ? ViewData.Model.Group.Name.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.Name")%>
		</li>
		
		<li>
			<label for="Group_ShortName">Short Name:</label>
			<div>
				<%= Html.TextBox("Group.ShortName",
               (ViewData.Model.Group != null) ? ViewData.Model.Group.ShortName.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.ShortName")%>
		</li>
		<li>
			<label for="Group_Blog">Blog:</label>
			<div>
				<%= Html.TextBox("Group.Blog", 
					(ViewData.Model.Group != null) ? ViewData.Model.Group.Blog.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.Blog")%>
		</li>
		
    	<li>
			<label for="Group_Rss">Rss:</label>
			<div>
				<%= Html.TextBox("Group.Rss",
               (ViewData.Model.Group != null) ? ViewData.Model.Group.Rss.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.Rss")%>
		</li>

		<li>
			<label for="Group_Manager">Manager:</label>
			<div>
				<%= this.Select("Group.Manager")
		                .FirstOption("0", "-- Select Manager Category --")
                        .Options<User>(Model.Users, user => user.Id, user => user.Name)
				        .Selected(
                          ViewData.Model.Group != null && ViewData.Model.Group.Manager != null
                                     ? ViewData.Model.Group.Manager.Id
				                : 0) %>
					
			</div>
			<%= Html.ValidationMessage("Group.Manager")%>
		</li>
				<li>
			<label for="Group_Name">Description:</label>
			<div>
				<%= Html.TextBox("Group.Description",
                                        (ViewData.Model.Group != null) ? ViewData.Model.Group.Description.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.Description")%>
		</li>
				<li>
			<label for="Group_Name">Start Time:</label>
			<div>
				<%= Html.TextBox("Group.StartTime",
                                        (ViewData.Model.Group != null) ? ViewData.Model.Group.StartTime.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.StartTime")%>
		</li>
				<li>
			<label for="Group_Name">End Time:</label>
			<div>
				<%= Html.TextBox("Group.EndTime",
                                        (ViewData.Model.Group != null) ? ViewData.Model.Group.EndTime.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.EndTime")%>
		</li>
						<li>
			<label for="Group_Name">Time Zone:</label>
			<div>
				<%= Html.TextBox("Group.TimeZone",
                                       (ViewData.Model.Group != null) ? ViewData.Model.Group.TimeZone.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Group.TimeZone")%>
		</li>



	    <li>
            <%= Html.SubmitButton("btnSave", "Save Group") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<GroupsController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
</div>
