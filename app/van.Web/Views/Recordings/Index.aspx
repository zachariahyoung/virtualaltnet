<%@ Page  Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Title="Virtual ALT.NET Recordings"
	Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.RecordingFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
<%@ Import Namespace="van.Web.Extensions"%>

<asp:Content ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
	<meta name="description" content="Virtual ALT.NET (VAN) is the online gathering place of the ALT.NET community.  This page contains the recordings." />
	<meta name="keywords" content="Alt.Net, VAN, Virtual ALT.NET, Virtual ALT.NET Recordings" />
	
	
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Recordings</h2>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage" class="fade page-message"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <p id="dynamicMessage" class="page-message" style="display:none"></p>
    <div class="center-box" id="divRecordingsGrid"></div>
    <%= Html.AntiForgeryToken() %>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
	<script type="text/javascript">
			<!-- Create a generic ns to be used by custom JavaScript objects and variables -->
			Ext.namespace('SharpJs');
			SharpJs.RootUrl = '<%= ResolveUrl("~") %>';
			Ext.BLANK_IMAGE_URL = SharpJs.RootUrl + 'Scripts/ext-3.0-rc1.1/resources/images/default/s.gif';
			Ext.GRID_WIDTH = 680;
			Ext.GRID_HEIGHT = 600;
			
			SharpJs.RecordingsData = <%= Newtonsoft.Json.JsonConvert.SerializeObject(Model.Recordings) %>;
	</script>
</asp:Content>