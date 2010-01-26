<%@ Page Title="Category Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Category>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>Category Details</h1>

    <ul>
		<li>
			<label for="Category_Description">Description:</label>
            <span id="Category_Description"><%= Server.HtmlEncode(ViewData.Model.Description.ToString()) %></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<CategoriesController>(c => c.Index()) + "';") %>
        </li>
	</ul>

</asp:Content>
