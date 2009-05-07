<%@ Page Title="Recording Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Recording>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Recording Details</h1>

    <form class="wufoo">
		<ul>
				<li>
				<label class="desc">RecordingTitle:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.RecordingTitle) %>
				</span>
			</li>
				<li>
				<label class="desc">RecordingUrl:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.RecordingUrl) %>
				</span>
			</li>
				<li>
				<label class="desc">RecordingDate:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.RecordingDate.ToString()) %>
				</span>
			</li>
				<li>
				<label class="desc">RecordingDuration:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.RecordingDuration) %>
				</span>
			</li>
		        <li class="buttons">
	            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                    "window.location.href = '" + Html.BuildUrlFromExpression<RecordingsController>(c => c.Index()) + "';") %>
            </li>
		</ul>
	</form>
</asp:Content>
