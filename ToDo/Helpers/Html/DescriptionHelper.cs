using System.Web.Mvc;

namespace ToDo.Helpers.Html
{
    public static class DescriptionHelper
    {
        public static MvcHtmlString DisplayDescription(this HtmlHelper helper, string text)
        {
            return text != null ? new MvcHtmlString(text.Replace("\n", "<br/>")) : new MvcHtmlString("");
        }
    }
}