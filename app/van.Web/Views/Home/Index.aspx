<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Title="Virtual ALT.NET" Inherits="System.Web.Mvc.ViewPage<van.Web.Controllers.PostEventRecordViewModel>" %>
<%@ Import Namespace="van.Core.Dto"%>
<%@ Import Namespace="System.ServiceModel.Syndication"%>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
<meta name="description" content="Virtual ALT.NET (VAN) is the online gathering place of the ALT.NET community. " />
<meta name="keywords" content="Alt.Net, VAN, Virtual ALT.NET, Virtual ALT.NET Home" />
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>VAN Feeds</h2>
<div class="feed-content">

    <p>
        This is a format title! ( <a href="About.aspx">link</a> )<br /> 
        <strong>By:</strong> <a href="#asdfasdf">Jeremy Miller</a> - <strong>When:</strong> 1/2/2008
    </p><br /><br />

   <% 
       foreach (var item in ViewData.Model.Posts) {
           string URL = item.Url;
           string Title = item.Title;
           Response.Write(string.Format("<p style=\"margin-bottom: 9px;\"><a href=\"{0}\"  class=\"title\">{1}</a><p>", URL, Title));
       } %>
       <br />
          <% 
       foreach (var item in ViewData.Model.Events) {
           string URL = item.Url;
           string Title = item.Title;
           string When = item.Date;
           Response.Write(string.Format("<p><a href=\"{0}\"  class=\"title\">{1} {2}</a><p>", URL, Title, When));
       } %>


</div>

</asp:Content>
