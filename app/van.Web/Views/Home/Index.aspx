<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
    Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
       <script language="javascript" type="text/javascript">
           Ext.onReady(function() {
               var movie_form = new Ext.FormPanel({
                   url: 'movie-form-submit.php',
                   renderTo: document.body,
                   frame: true,
                   title: 'Movie Information Form',
                   width: 250,
                   items: [{
                       xtype: 'textfield',
                       fieldLabel: 'Title',
                       name: 'title'
                   }, {
                       xtype: 'textfield',
                       fieldLabel: 'Director',
                       name: 'director'
                   }, {
                       xtype: 'datefield',
                       fieldLabel: 'Released',
                       name: 'released'
}]
});
simple.render('mytraditionalform');

               });
       </script>
</asp:Content>


<asp:Content  ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1 class="first">Mission Statement</h1>    
    
    <div id='mytraditionalform' 
     style='width:200px;height:200px;'></div>
</asp:Content>
