<%@ Page Title="" Language="C#" 
MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true" 
Inherits="ViewPage<IEnumerable<Recording>>" %>
<%@ Import Namespace="van.Core"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<p>Matching Title:</p>

    <ul>
        <%
        foreach (var recording in ViewData.Model) { %>
    	    <li><%= recording.RecordingTitle %></li><%
        }
        %>
    </ul>
</asp:Content>
