using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQGridDemo.CustomExceptions
{
    public class FailedToRetrieveStatesException : Exception
    {
        public FailedToRetrieveStatesException(string message)
            : base(message)
        {
        }
    }
}