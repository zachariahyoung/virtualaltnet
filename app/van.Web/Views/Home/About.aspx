<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"  Title="Virtual ALT.NET About" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
<meta name="description" content="Virtual ALT.NET (VAN) is the online gathering place of the ALT.NET community.  This page contains the about information." />
<meta name="keywords" content="Alt.Net, VAN, Virtual ALT.NET, Virtual ALT.NET About" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h2 class="first">About Virtual ALT.NET</h2>
<div class="center-box">  
<p>Virtual ALT.NET (VAN) is the online gathering place of the <a href="http://altnetpedia.com/">ALT.NET</a> community. Through conversations, presentations, pair programming and dojos, we strive to improve, explore, and challenge the way we create software. Using net conferencing technology such as Skype and LiveMeeting, we hold regular meetings, open to anyone, usually taking the form of a presentation or an <a href="http://en.wikipedia.org/wiki/Open_Space_Technology">Open Space Technology</a>-style conversation.</p>
<br />
<p>Please see the <a href="http://www.virtualaltnet.com/Home/Calendar">Calendar</a> to find a VAN group that meets at a time convenient to you, and feel welcome to <a href="<%= Url.Action("Index","Van")%>">join a meeting</a>. Past sessions can be found on the <a href="http://www.virtualaltnet.com/Recordings">Recording</a> page.</p>
<br />
<p>To stay informed about VAN activities, you can subscribe to the <a href="<%= Url.Action("GoogleGroup","Home")%>">Virtual ALT.NET Google Group</a> and follow the <a href="<%= Url.Action("Blog","Home")%>">Blog</a>.</p>
<br />
<p>For more information about the origins of VAN, see <a href="http://www.zachariahyoung.com/">Zachariah Young</a>'s <a href="http://www.zachariahyoung.com/zy/post/2009/01/15/Introduction-to-Virtual-ALTNET.aspx">Introduction to Virtual ALT.NET</a>.</p>
</div>

    </asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server" />