<%@ Page Title="Recording Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<RecordingViewModel>" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server"/>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Recording Details</h1>

    <div class="center-box">
		<ul>
				<li>
				<label class="desc">Title:</label>
				<span>
					<a href="<%= Server.HtmlEncode(Model.SingleRecording.Url) %>" target="_blank"><%= Server.HtmlEncode(Model.SingleRecording.Title) %></a>
				</span>
			</li>
				
				<li>
				<label class="desc">Date:</label>
				<span>
					<%= Server.HtmlEncode(Model.SingleRecording.Date.ToShortDateString()) %>
				</span>
			</li>
				<li>
				<label class="desc">Duration:</label>
				<span>
					<%= Server.HtmlEncode(Model.SingleRecording.Duration) %>
				</span>
			</li>
							<li>
				<label class="desc">Speaker:</label>
				<span>
					<%= Server.HtmlEncode(Model.SingleRecording.Speaker) %>
				</span>
			</li>
										<li>
				<label class="desc">User Group:</label>
				<span>
					<%= Server.HtmlEncode(Model.SingleRecording.UserGroup) %>
				</span>
			</li>
            <li>
                <label class="desc">
                    Live Meeting Url:</label>
                <span>
                    <%= Server.HtmlEncode(Model.SingleRecording.LiveMeetingUrl) %>
                </span></li>
										<li>
				<label class="desc">Description:</label>
				<span>
					<%= Server.HtmlEncode(Model.SingleRecording.Description) %>
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