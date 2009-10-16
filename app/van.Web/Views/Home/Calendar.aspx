<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Title="Virtual ALT.NET Calendar" 
 Inherits="System.Web.Mvc.ViewPage<van.Core.BaseViewModel>"
%>
 <asp:Content ID="Content3" ContentPlaceHolderID="ResourceFilesPlaceHolder" runat="server"></asp:Content>
 <asp:Content ID="Content1" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
<meta name="description" content="Virtual ALT.NET (VAN) is the online gathering place of the ALT.NET community.  This page contains the calendar." />
<meta name="keywords" content="Alt.Net, VAN, Virtual ALT.NET, Virtual ALT.NET Calendar" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<br />
    <table>
        <tr>
            <td>
                <a href="http://www.google.com/calendar/feeds/9fgo89ah4shtm6pk7k5307aerg@group.calendar.google.com/public/basic">
                    <img src="<%= ResolveUrl("~") %>Content/Images/xml.gif"  alt="Virtual Alt.Net Calendar XML"/></a>
            </td>
            <td>
                <a href="http://www.google.com/calendar/ical/9fgo89ah4shtm6pk7k5307aerg@group.calendar.google.com/public/basic.ics">
                    <img src="<%= ResolveUrl("~") %>Content/Images/ical.gif"  alt="Virtual Alt.Net Calendar XML"/></a>
            </td>
            <td>
                <a href="http://www.google.com/calendar/embed?src=9fgo89ah4shtm6pk7k5307aerg%40group.calendar.google.com&ctz=America/Chicago">
                    <img src="<%= ResolveUrl("~") %>Content/Images/html.gif"  alt="Virtual Alt.Net Calendar XML"/></a>
            </td>
        </tr>
    </table>
<br />
<iframe src="http://www.google.com/calendar/embed?src=9fgo89ah4shtm6pk7k5307aerg%40group.calendar.google.com&ctz=America/Chicago" 
style="border: 0" width="540" height="600" frameborder="0" scrolling="no" ></iframe>

</asp:Content>
