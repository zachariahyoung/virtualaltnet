<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<van.ApplicationServices.ViewModels.RecordingFormViewModel>" %>
<%@ Import Namespace="van.Core" %>
<%@ Import Namespace="van.Web.Controllers" %>
<div class="center-box">
    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null)
       { %>
    <p id="pageMessage" class="fade page-message">
        <%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>
    <%= Html.ValidationSummary() %>
 
        <% using (Html.BeginForm())
           { %>
        <%= Html.AntiForgeryToken() %>
        <%= Html.Hidden("Recording.Id", (ViewData.Model.Recording != null) ? ViewData.Model.Recording.Id : 0)%>
        <ul>
            <li>
                <label for="Recording_Title">Title:</label>
                <div>
                    <%= Html.TextBox("Recording.Title", 
					(ViewData.Model.Recording != null) ? ViewData.Model.Recording.Title : "")%>
                 </div>
                        <%= Html.ValidationMessage("Recording.Title")%>
                    </li>
            <li>
                <label for="Recording_Description">Description:</label>
                <div>
                    <%= Html.TextArea("Recording.Description", (ViewData.Model.Recording != null) ? ViewData.Model.Recording.Description : "", new { style = "width:1000px" })%>
                </div>    
                        <%= Html.ValidationMessage("Recording.Description")%>
                    
                </li>
            <li>
                <label for="Recording_Date">Date:</label>
                <div>
                    <%= Html.TextBox("Recording.Date", (ViewData.Model.Recording != null) ? ViewData.Model.Recording.Date.ToString() : "")%>
                    </div>
                        <%= Html.ValidationMessage("Recording.Date")%>
                    </li>
            <li>
                <label for="Recording_Speaker">Speaker</label>
                <div>
                    <%= this.Select("Recording.Speaker")
		                .FirstOption("0", "-- Select Speaker --")
                        .Options<Speaker>(ViewData.Model.Speakers, speaker => speaker.Id, speaker => speaker.Name)
				        .Selected(ViewData.Model.Recording != null && ViewData.Model.Recording.Speaker != null ? ViewData.Model.Recording.Speaker.Id : 0) %>
                    <%= Html.ActionLink<SpeakersController>(c => c.Create(), "Create New Speaker") %>
                </div>
                
                    <%= Html.ValidationMessage("Recording.Speaker")%>
                
            </li>
            <li>
                <label for="Recording_Group">Group</label>
                <div>
                    <%= this.Select("Recording.Group")
		                .FirstOption("0", "-- Select Group --")
                        .Options<van.Core.Group>(ViewData.Model.Groups, group => group.Id, group => group.ShortName)
				        .Selected(ViewData.Model.Recording != null && ViewData.Model.Recording.Group != null ? ViewData.Model.Recording.Group.Id : 0) %>
                </div>
                
                    <%= Html.ValidationMessage("Recording.Group")%>
                
            </li>
            <li>
                <label for="Recording_Url">Url</label>
                <div>
                    <%= Html.TextBox("Recording.Url",(ViewData.Model.Recording != null) ? ViewData.Model.Recording.Url : "http://www.viddler.com/explore/virtualaltnet/videos/", new { style = "width:500px" })%>
                </div>    
                        <%= Html.ValidationMessage("Recording.Url")%>
                    
                </li>
            <li>
                <label for="Recording_LiveMeetingUrl">Live Meeting Url</label>
                <div>
                    <%= Html.TextBox("Recording.LiveMeetingUrl", (ViewData.Model.Recording != null) ? ViewData.Model.Recording.LiveMeetingUrl : "https://www323.livemeeting.com/cc/usergroups/view?id=van-",new { style="width:500px" }) %>
                    </div>
                        <%= Html.ValidationMessage("Recording.LiveMeetingUrl")%>
                    
                </li>
            <li>
                <label for="Recording_Duration">Duration</label>
                <div>
                    <%= Html.TextBox("Recording.Duration", (ViewData.Model.Recording != null) ? ViewData.Model.Recording.Duration : "0")%>
                    </div>
                    
                        <%= Html.ValidationMessage("Recording.Duration")%>
                    </li>
            <li>
                <label for="Recording_Status">Status</label>
                <div>
                    <%= this.Select("Recording.Status")
                            .FirstOption("0", "-- Select Status --")
                            .Options<Status>(ViewData.Model.Statuses, status => status.Id, status => status.Name)
				            .Selected(ViewData.Model.Recording != null && ViewData.Model.Recording.Status != null ? ViewData.Model.Recording.Status.Id: 0) %>
                </div>
                
                    <%= Html.ValidationMessage("Recording.Status")%>
                
            </li>
            <li class="buttons">
                <%= Html.SubmitButton("btnSave", "Save Recording") %>
                <%= Html.Button("btnCancel", "Cancel", HtmlButtonType.Button, 
					"window.location.href = '" + Html.BuildUrlFromExpression<RecordingsController>(c => c.Index()) + "';") %>
            </li>
        </ul>
        <% } %>
</div>
