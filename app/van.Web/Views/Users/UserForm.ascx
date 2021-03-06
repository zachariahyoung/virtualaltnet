<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.ApplicationServices.ViewModels.UserFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 
<div class="center-box">
<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("User.Id", (ViewData.Model.User != null) ? ViewData.Model.User.Id : 0)%>

    <ul>
  		<li>
			<label for="User_Name">Name:</label>
			<div>
				<%= Html.TextBox("User.Name", 
					(ViewData.Model.User != null) ? ViewData.Model.User.Name.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("User.Name")%>
		</li>

  		<li>
			<label for="User_Email">Email:</label>
			<div>
				<%= Html.TextBox("User.Email", 
					(ViewData.Model.User != null) ? ViewData.Model.User.Email.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("User.Email")%>
		</li>

		<li>
			<label for="User_UserName">UserName:</label>
			<div>
				<%= Html.TextBox("User.UserName", 
					(ViewData.Model.User != null) ? ViewData.Model.User.UserName.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("User.UserName")%>
		</li>
		<li>
			<label for="User_Password">Password:</label>
			<div>
				<%= Html.TextBox("User.Password", 
					(ViewData.Model.User != null) ? ViewData.Model.User.Password.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("User.Password")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save User") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<UsersController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
</div>