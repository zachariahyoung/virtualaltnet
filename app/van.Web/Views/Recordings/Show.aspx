<%@ Page Title="Recording Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.RecordingFormViewModel>" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"/>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Recording Details</h2>

    <div class="center-box">
		<ul>
				<li>
				<label class="desc">Title:</label>
				<span>
					<a href="<%= Server.HtmlEncode(Model.Recording.Url) %>" target="_blank"><%= Server.HtmlEncode(Model.Recording.Title) %></a>
				</span>
			</li>
				
				<li>
				<label class="desc">Date:</label>
				<span>
					<%= Server.HtmlEncode(Model.Recording.Date.ToShortDateString()) %>
				</span>
			</li>
				<li>
				<label class="desc">Duration:</label>
				<span>
					<%= Server.HtmlEncode(Model.Recording.Duration) %>
				</span>
			</li>
							<li>
				<label class="desc">Speaker:</label>
				<span>
					<%= Server.HtmlEncode(Model.Recording.Speaker.Name) %>
				</span>
			</li>
										<li>
				<label class="desc">User Group:</label>
				<span>
					<%= Server.HtmlEncode(Model.Recording.Group.Name) %>
				</span>
			</li>
            <li>
                <label class="desc">
                    Live Meeting Url:</label>
                <span>
                    <%= Server.HtmlEncode(Model.Recording.LiveMeetingUrl) %>
                </span></li>
										<li>
				<label class="desc">Description:</label>
				<span>
					<%= Server.HtmlEncode(Model.Recording.Description) %>
				</span>
			</li>

		        <li class="buttons">
	            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                    "window.location.href = '" + Html.BuildUrlFromExpression<RecordingsController>(c => c.Index()) + "';") %>
            </li>
		</ul>
	</div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />