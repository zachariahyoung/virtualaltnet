using System.Text;
using System.Web;
using System.Web.Mvc;


namespace van.Web.Extensions
{
    public static class HtmlExtensions
    {
        public static string IncludeMsJs(this HtmlHelper self, params string[] scripts) {
            var sb = new StringBuilder();
            foreach (var script in scripts) {
                var pathToScript = VirtualPathUtility.ToAbsolute("~/Scripts/" + script + ".js");
                sb.AppendFormat("<script src='{0}'></script>", pathToScript);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static string IncludeExtAdapterJs(this HtmlHelper self, params string[] scripts)
        {
            var sb = new StringBuilder();
            foreach (var script in scripts)
            {
                var pathToScript = VirtualPathUtility.ToAbsolute("~/Scripts/ext-3.0-rc1.1/adapter/jquery/" + script + ".js");
                sb.AppendFormat("<script src='{0}'></script>", pathToScript);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static string IncludeExtAllJs(this HtmlHelper self, params string[] scripts)
        {
            var sb = new StringBuilder();
            foreach (var script in scripts)
            {
                var pathToScript = VirtualPathUtility.ToAbsolute("~/Scripts/ext-3.0-rc1.1/" + script + ".js");
                sb.AppendFormat("<script src='{0}'></script>", pathToScript);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static string IncludeExtGridJs(this HtmlHelper self, params string[] scripts)
        {
            var sb = new StringBuilder();
            foreach (var script in scripts)
            {
                var pathToScript = VirtualPathUtility.ToAbsolute("~/Scripts/Model/Ext.ux/" + script + ".js");
                sb.AppendFormat("<script src='{0}'></script>", pathToScript);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static string IncludeExtViewListingJs(this HtmlHelper self, params string[] scripts)
        {
            var sb = new StringBuilder();
            foreach (var script in scripts)
            {
                var pathToScript = VirtualPathUtility.ToAbsolute("~/Scripts/ViewScripts/Recordings/" + script + ".js");
                sb.AppendFormat("<script src='{0}'></script>", pathToScript);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static string IncludeCss(this HtmlHelper self, params string[] styles) {
            var sb = new StringBuilder();
            foreach (var style in styles) {
                var pathToStyle = VirtualPathUtility.ToAbsolute("~/Content/" + style + ".css");
                sb.AppendFormat("<link href='{0}' rel='stylesheet' type='text/css' />", pathToStyle);
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}