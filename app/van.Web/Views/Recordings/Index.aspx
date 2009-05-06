<%@ Page Title="Recordings" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<IEnumerable<van.Core.Recording>>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
 

<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript">
        SharpJs.RecordingsData = <%= Newtonsoft.Json.JsonConvert.SerializeObject(ViewData.Model) %>;
    </script>

    <script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/ViewScripts/Recordings/ListRecordings.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Recordings</h1>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage" class="fade page-message"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <p id="dynamicMessage" class="page-message" style="display:none"></p>

    <div id="divRecordingsGrid"></div>
    <%= Html.AntiForgeryToken() %>
</asp:Content>
