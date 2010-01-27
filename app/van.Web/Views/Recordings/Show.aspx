<%@ Page Title="Recording Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Recording>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Recording Details</h1>

    <form class="wufoo">
		<ul>
				<li>
				<label class="desc">Date:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.Date) %>
				</span>
			</li>
				<li>
				<label class="desc">UploadedUrl:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.UploadedUrl) %>
				</span>
			</li>
				<li>
				<label class="desc">StartTime:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.StartTime) %>
				</span>
			</li>
				<li>
				<label class="desc">EndTime:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.EndTime) %>
				</span>
			</li>
				<li>
				<label class="desc">UpcomingEvent:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.UpcomingEvent) %>
				</span>
			</li>
				<li>
				<label class="desc">UserGroup:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.UserGroup) %>
				</span>
			</li>
				<li>
				<label class="desc">Category:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.Category) %>
				</span>
			</li>
		        <li class="buttons">
	            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                    "window.location.href = '" + Html.BuildUrlFromExpression<RecordingsController>(c => c.Index()) + "';") %>
            </li>
		</ul>
	</form>
</asp:Content>
