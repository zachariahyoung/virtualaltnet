<%@ Page Title="Recordings" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<IEnumerable<Recording>>" %>
<%@ Import Namespace="van.Core.DataInterfaces"%>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Recordings</h2>

    <% if (ViewContext.TempData["message"] != null){ %>
        <p><%= ViewContext.TempData["message"]%></p>
    <% } %>
    
	<div>
        <% 
        Html.Grid(ViewData.Model)
            .Columns(
                column => {
                              
                    column.For(c => c.RecordingTitle).Named("Title");              
				    column.For(c => c.RecordingUrl).Named("Url");                
					column.For(c => c.RecordingDate).Format("{0:d}").Named("Date");                
					column.For(c => c.RecordingDuration).Named("Duration");                
					column.For("Actions").Action(recording => { %>
		                <td>
							<table>
								<tr>
									<td><%=Html.ActionLink<RecordingsController>( controller => controller.Show( recording.Id ), "Details ") %></td>
									<td><%=Html.ActionLink<RecordingsController>( controller => controller.Edit( recording.Id ), "Edit") %></td>
									<td>
										<% using (Html.BeginForm<RecordingsController>(controller => controller.Delete(recording.Id))) { %>
											<%= Html.AntiForgeryToken() %>
											<input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
										<% } %>
									</td>
								</tr>
							</table>
		                </td>
	                <%});                                        
                })
            .Empty("There are no recordings.")
            .Attributes(style => "width: 100%")
            .Render();					
        %>		
	</div>
    <p><%= Html.ActionLink<RecordingsController>(c => c.Create(), "Add New") %></p>
    
</asp:Content>
