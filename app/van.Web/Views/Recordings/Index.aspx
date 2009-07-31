<%@ Page  Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Title="Virtual ALT.NET Recordings"
	Inherits="System.Web.Mvc.ViewPage<IEnumerable<Recording>>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
<%@ Import Namespace="van.Web.Extensions"%>

<asp:Content ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
<meta name="description" content="Virtual ALT.NET (VAN) is the online gathering place of the ALT.NET community.  This page contains the recordings." />
<meta name="keywords" content="Alt.Net, VAN, Virtual ALT.NET, Virtual ALT.NET Recordings" />

    <script language="javascript" type="text/javascript">
        SharpJs.RecordingsData = <%= Newtonsoft.Json.JsonConvert.SerializeObject(ViewData.Model) %>;
    </script>
<%= Html.IncludeExtViewListingJs("ListRecordings") %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Recordings</h1>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage" class="fade page-message"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <p id="dynamicMessage" class="page-message" style="display:none"></p>

    <div id="divRecordingsGrid"></div>
   
</asp:Content>
