<%@ Page Title="Speaker Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Speaker>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>Speaker Details</h1>

    <ul>
		<li>
			<label for="Speaker_FirstName">FirstName:</label>
            <span id="Speaker_FirstName"><%= Server.HtmlEncode(ViewData.Model.FirstName.ToString()) %></span>
		</li>
		<li>
			<label for="Speaker_LastName">LastName:</label>
            <span id="Speaker_LastName"><%= Server.HtmlEncode(ViewData.Model.LastName.ToString()) %></span>
		</li>
		<li>
			<label for="Speaker_Email">Email:</label>
            <span id="Speaker_Email"><%= Server.HtmlEncode(ViewData.Model.Email.ToString()) %></span>
		</li>
		<li>
			<label for="Speaker_Website">Website:</label>
            <span id="Speaker_Website"><%= Server.HtmlEncode(ViewData.Model.Website.ToString()) %></span>
		</li>
		<li>
			<label for="Speaker_Presentation">Presentation:</label>
            <span id="Speaker_Presentation"><%= Server.HtmlEncode(ViewData.Model.Presentation.ToString()) %></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<SpeakersController>(c => c.Index()) + "';") %>
        </li>
	</ul>

</asp:Content>
