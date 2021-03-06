﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Title="Virtual ALT.NET" Inherits="System.Web.Mvc.ViewPage<van.ApplicationServices.ViewModels.EventNewsFormViewModel>" %>
<%@ Import Namespace="van.Core.Dto"%>
<%@ Import Namespace="System.ServiceModel.Syndication"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
<meta name="description" content="Virtual ALT.NET (VAN) is the online gathering place of the ALT.NET community. " />
<meta name="keywords" content="Alt.Net, VAN, Virtual ALT.NET, Virtual ALT.NET Home" />
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Aggregated VAN Groups News</h2>
<div class="center-box">  
<%--http://feeds2.feedburner.com/VirtualAltnet--%>
   <% 
       foreach (var item in ViewData.Model.News) {
           string url = item.Url;
           string title = item.Title;
           Response.Write(string.Format("<p><a href=\"{0}\"  class=\"title\">{1}</a><p>", url, title));
       } %>
</div>
<h2>VAN Events</h2>
<div class="center-box">
          <% 
       foreach (var item in ViewData.Model.Events) {
           string url = item.Url;
           string title = item.Title;
           string when = item.Date;
           Response.Write(string.Format("<p><a href=\"{0}\"  class=\"title\">{1} {2}</a><p>", url, title, when));
       } %>


</div>
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />