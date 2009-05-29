<%@ Page Title="Recording Details" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<van.Core.Recording>" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Recording Details</h1>

    <form class="wufoo">
		<ul>
				<li>
				<label class="desc">Title:</label>
				<span>
					<a href="<%= Server.HtmlEncode(ViewData.Model.Url) %>" target="_blank"><%= Server.HtmlEncode(ViewData.Model.Title) %></a>
				</span>
			</li>
				<li>
				<label class="desc">Url:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.Url) %>
				</span>
			</li>
				<li>
				<label class="desc">Date:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.Date.ToShortDateString()) %>
				</span>
			</li>
				<li>
				<label class="desc">Duration:</label>
				<span>
					<%= Server.HtmlEncode(ViewData.Model.Duration) %>
				</span>
			</li>
		        <li class="buttons">
	            <%= Html.Button("btnBack", "Back", HtmlButtonType.Button, 
                    "window.location.href = '" + Html.BuildUrlFromExpression<RecordingsController>(c => c.Index()) + "';") %>
            </li>
		</ul>
	</form>
</asp:Content>
