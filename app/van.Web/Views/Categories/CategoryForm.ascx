<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<van.Web.Controllers.CategoriesController.CategoryFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken() %>
    <%= Html.Hidden("Category.Id", (ViewData.Model.Category != null) ? ViewData.Model.Category.Id : 0)%>

    <ul>
		<li>
			<label for="Category_Description">Description:</label>
			<div>
				<%= Html.TextBox("Category.Description", 
					(ViewData.Model.Category != null) ? ViewData.Model.Category.Description.ToString() : "")%>
			</div>
			<%= Html.ValidationMessage("Category.Description")%>
		</li>
	    <li>
            <%= Html.SubmitButton("btnSave", "Save Category") %>
	        <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
				    "window.location.href = '" + Html.BuildUrlFromExpression<CategoriesController>(c => c.Index()) + "';") %>
        </li>
    </ul>
<% } %>
