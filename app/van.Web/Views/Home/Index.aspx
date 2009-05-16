<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
    Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <!-- start feedwind code -->
<script type="text/javascript">
<!--
rssmikle_url="http://feeds2.feedburner.com/VirtualAltnet";
rssmikle_frame_width="750";
rssmikle_frame_height="500";
rssmikle_target="_blank";
rssmikle_font_size="16";
rssmikle_border="off";
rssmikle_css_url="";
rssmikle_title="off";
rssmikle_title_bgcolor="#0066FF";
rssmikle_title_color="#FFFFFF";
rssmikle_title_bgimage="http://";
rssmikle_item_bgcolor="#FFFFFF";
rssmikle_item_bgimage="http://";
rssmikle_item_title_length="1000";
rssmikle_item_title_color="#666666";
rssmikle_item_border_bottom="on";
rssmikle_item_description="on";
rssmikle_item_description_length="1000";
rssmikle_item_description_color="#666666";
rssmikle_item_description_tag="off";
rssmikle_item_podcast="icon";
//-->
</script>
<script type="text/javascript" src="http://feed.mikle.com/js/rssmikle.js"></script>
<div style="font-size:10px; text-align:right;">
<a href="http://feed.mikle.com/en/" target="_blank" style="color:#CCCCCC;">FeedWind</a>
<!--Please display the above link in your web page according to Terms of Service.-->
</div>
<!-- end feedwind code -->

</asp:Content>
