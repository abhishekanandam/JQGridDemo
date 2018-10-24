using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQGridDemo.Repositories;

namespace JQGridDemo.Filters
{
    // For MVC controllers
    public class ControllerExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                // TODO: Log the exception, appending the log reference number
                // to the message that will be shown on the redirect screen
                string message = filterContext.Exception.Message;
                string stackTrace = filterContext.Exception.StackTrace;

                HttpContext.Current.Session["CustomErrorMessage"] = message;
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<string>(message)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}