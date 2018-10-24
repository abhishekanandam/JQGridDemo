using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trirand.Web.Mvc;

namespace JQGridDemo.Controllers
{
    public class OtherFeaturesController : Controller
    {
        public ActionResult Exporting()
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

        public void ExportEmployeesToExcel()
        {
            var gridModel = new EmployeeJQGridModel();
            var repository = new GenericEmployeeRepository();
            var resultSet = repository.GetAll();

            gridModel.EmployeeGrid.ExportSettings.ExportDataRange = ExportDataRange.All;
            gridModel.EmployeeGrid.ExportToExcel(resultSet.AsQueryable(), "employees_export.xls");
        }

    }
}
