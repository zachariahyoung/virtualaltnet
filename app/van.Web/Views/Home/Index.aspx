<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Title="Virtual ALT.NET"
    Inherits="System.Web.Mvc.ViewPage<SyndicationFeed>" %>

<%@ Import Namespace="System.ServiceModel.Syndication"%>

<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
<meta name="description" content="Virtual ALT.NET (VAN) is the online gathering place of the ALT.NET community. " />
<meta name="keywords" content="Alt.Net, VAN, Virtual ALT.NET, Virtual ALT.NET Home" />
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div>
<% foreach (var item in ViewData.Model.Items)
{
string URL = item.Links[0].Uri.OriginalString;
string Title = item.Title.Text;
Response.Write(string.Format("<p><a href=\"{0}\"><b>{1}</b></a>", URL, Title));

} %>
</div>

</asp:Content>
