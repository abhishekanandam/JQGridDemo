using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using JQGridDemo.Repositories;

namespace JQGridDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetCustomErrorMessage()
        {
            var js = new JavaScriptSerializer();
            return js.Serialize(Session["CustomErrorMessage"]);
        }
    }
}
