using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQGridDemo.CustomExceptions;
using JQGridDemo.Repositories;

namespace JQGridDemo.Filters
{
    // For jqGrid [HttpPost] handler
    public class JQGridPostExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string message = filterContext.Exception.Message;
                if (filterContext.Exception is ValidationException)
                {
                    // Do nothing
                }
                else
                {
                    string stackTrace = filterContext.Exception.StackTrace;
                    // TODO: log the exception, appending the log reference number
                    // to the message that will be shown on the alert()
                }

                HttpContext.Current.Session["CustomErrorMessage"] = message;
                throw filterContext.Exception;
            }
        }
    }
}

