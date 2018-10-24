using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using JQGridDemo.CustomExceptions;

namespace JQGridDemo.Repositories
{
    // This repository should NEVER be deployed to production!!!
    public class DebugErrorMessageRepository
    {
        static string sMessage;
        public void SetErrorMessage(string errorMessage)
        {
            sMessage = errorMessage;
        }

        public string GetErrorMessage()
        {
            return sMessage;
        }
    }
}