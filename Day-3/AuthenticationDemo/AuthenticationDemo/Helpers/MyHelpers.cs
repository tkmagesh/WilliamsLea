using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationDemo.Helpers
{
    public static class MyHelpers
    {
        public static System.Web.Mvc.MvcHtmlString DisplayCurrentTime(this HtmlHelper helper)
        {
            return new MvcHtmlString("<div>" + DateTime.Now.ToLongTimeString() + "</div>");
        }
    }
}