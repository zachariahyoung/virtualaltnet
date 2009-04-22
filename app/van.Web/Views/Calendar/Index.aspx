<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
    Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ID="calendarFrame" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <iframe src="http://www.google.com/calendar/embed?src=9fgo89ah4shtm6pk7k5307aerg%40group.calendar.google.com&ctz=America/Chicago" style="border: 0" width="800" height="600" frameborder="0" scrolling="no"></iframe>
</asp:Content>
