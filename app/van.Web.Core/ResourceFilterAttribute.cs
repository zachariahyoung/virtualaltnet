using System.Web.Mvc;
using van.Core;
using van.Web.Core.Configuration;

namespace van.Web.Core
{
	public class ResourceFilterAttribute : ActionFilterAttribute
   {
		readonly int _resourceId;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResourceFilterAttribute"/> class.
		/// </summary>
		/// <param name="resourceId">The resource id.</param>
		public ResourceFilterAttribute(int resourceId)
		{
			_resourceId = resourceId;
		}

		public IContentFilesManager ContentFilesManager { get; set; }

		/// <summary>
		/// Called after the action method executes.
		/// </summary>
		/// <param name="filterContext">The filter context.</param>
      public override void OnActionExecuted(ActionExecutedContext filterContext)
      {
			if (ContentFilesManager == null)
				ContentFilesManager = new ContentFilesManager(new AppSettings());

         var viewResult = filterContext.Result as ViewResult;
			if (viewResult == null)
				return;

			var model = viewResult.ViewData.Model as BaseViewModel ?? new BaseViewModel();

			PopulateBaseViewModel(model);
      }

		/// <summary>
		/// Populates the base view model.
		/// </summary>
		/// <param name="model">The model.</param>
      private void PopulateBaseViewModel(BaseViewModel model)
      {
			model.JavaScript = ContentFilesManager.GetFiles(ContentFilesType.JavaScript, _resourceId);
			model.CSS = ContentFilesManager.GetFiles(ContentFilesType.CSS, _resourceId);
      }
   }
}