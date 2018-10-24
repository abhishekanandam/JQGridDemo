using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQGridDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Employees()
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
    }
}
