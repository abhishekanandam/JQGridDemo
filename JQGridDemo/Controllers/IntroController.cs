using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQGridDemo.Controllers
{
    public class IntroController : Controller
    {

        public ActionResult InitialSetup()
        {
            var gridModel = new EmployeeJQGridModel();
            return View(gridModel);
        }

        public JsonResult OnEmployeeDataRequested()
        {
            var gridModel = new EmployeeJQGridModel();
            var repository = new GenericEmployeeRepository();
            var resultSet = repository.GetAll();
            return gridModel.EmployeeGrid.DataBind(resultSet.AsQueryable());
        }

        public ActionResult FirstGrid()
        {
            return View();
        }

        public ActionResult CaptionAndAutoHeight()
        {
            return View();
        }

        public ActionResult Paging()
        {
            return View();
        }

        public ActionResult Formatting()
        {
            return View();
        }

        public ActionResult Searching()
        {
            return View();
        }
    }
}
