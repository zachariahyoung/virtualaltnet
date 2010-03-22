<%@ Page Title="Speaker Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.SpeakerFormViewModel>" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h2>Speaker Details</h2>
    <div class="center-box">
    <ul>
		<li>
			<label for="Speaker_Name">Name:</label>
            <span id="Speaker_Name"><%= Server.HtmlEncode(Model.Speaker.Name.ToString()) %></span>
		</li>
		<li>
			<label for="Speaker_Website">Website:</label>
            <span id="Speaker_Website"><%= Server.HtmlEncode(Model.Speaker.Website.ToString()) %></span>
		</li>
		<li>
			<label for="Speaker_Bio">Bio:</label>
            <span id="Speaker_Bio"><%= Server.HtmlEncode(Model.Speaker.Bio.ToString())%></span>
		</li>
	    <li class="buttons">
            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                "window.location.href = '" + Html.BuildUrlFromExpression<SpeakersController>(c => c.Index()) + "';") %>
        </li>
	</ul>
</div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />
