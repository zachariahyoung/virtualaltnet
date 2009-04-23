<%@ Page Title="Recordings" Language="C#" 
MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true" 
Inherits="ViewPage<IEnumerable<Recording>>" %>
<%@ Import Namespace="van.Web.Controllers"%>
<%@ Import Namespace="System.Globalization"%>
<%@ Import Namespace="van.Core"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h2>Recordings</h2>

    <% if (ViewContext.TempData["message"] != null){ %>
        <p><%= ViewContext.TempData["message"]%></p>
    <% } %>
 

</asp:Content>
