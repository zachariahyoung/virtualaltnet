<%@ Page Title="Denied" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="van.Web.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h1>Access is Denied</h1>
    <% if( ViewData["ErrorMessage"] != null ){ %>
    <p>
        <% =ViewData["ErrorMessage"] %></p>
    <% } %>
</asp:Content>
