using System.Web;
using System.Web.Mvc;
using JQGridDemo.Filters;

namespace JQGridDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Replacing the default HandleErrorAttribute
            // filters.Add(new HandleErrorAttribute()); 
            filters.Add(new ControllerExceptionHandlerAttribute());
        }
    }
}