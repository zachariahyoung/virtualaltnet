using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using van.Core;

namespace van.Web.Core
{
	public class BaseMaster : ViewMasterPage<BaseViewModel>
	{
		const string CSSFormat = "<link rel='stylesheet' type='text/css' href='{0}'>{1}";
		const string JavaScriptFormat = "<script src='{0}' type='text/javascript'></script>{1}";
		private const string HEADER = "ResourceFilesPlaceHolder";
		private Control _resourceControl;

		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
		protected override void OnLoad(EventArgs e)
		{
			if (Model == null)
				throw new NullReferenceException("Invalid model");

			_resourceControl = FindControl(HEADER);

			AddToHeader(Model.CSS, CSSFormat);
			AddToHeader(Model.JavaScript, JavaScriptFormat);

			base.OnLoad(e);
		}

		/// <summary>
		/// Adds the CSS to header.
		/// </summary>
		/// <param name="contentFiles">The CSS or JavaScript files.</param>
		/// <param name="format">The format.</param>
		private void AddToHeader(IEnumerable<IResource> contentFiles, string format)
		{
			if (contentFiles == null) return;
			if (_resourceControl == null) return;

			foreach (var file in contentFiles)
			{
				var url = file.GetWebResourceUrl();
				var paramIndex = url.IndexOf("?");

				if (paramIndex >= 0)
					url = VirtualPathUtility.ToAbsolute(url.Substring(0, paramIndex)) + url.Substring(paramIndex);
				else
					url = VirtualPathUtility.ToAbsolute(url);

				_resourceControl.Controls.Add(new LiteralControl(String.Format(format, url, Environment.NewLine)));
			}
		}
	}
}