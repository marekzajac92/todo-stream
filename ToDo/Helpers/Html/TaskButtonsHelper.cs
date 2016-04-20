using System.Web.Mvc;
using ToDo.Controllers;

namespace ToDo.Helpers.Html
{
    public static class TaskButtonsHelper
    {
        public static MvcHtmlString RemoveButton(this HtmlHelper helper, int id)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            return new MvcHtmlString("<a href = \"" + urlHelper.Action("Remove", "Task", new {id = id})
                + "\" class=\"btn btn-danger small-btn\"><span class=\"glyphicon glyphicon-remove\" aria-hidden=\"true\"></span></a>");
        }

        public static MvcHtmlString DoneButton(this HtmlHelper helper, int id)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            return new MvcHtmlString("<a href = \"" + urlHelper.Action("Done", "Task", new { id = id })
                + "\" class=\"btn btn-success small-btn\"><span class=\"glyphicon glyphicon-ok\" aria-hidden=\"true\"></span></a>");
        }
    }
}
