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
    public class SearchingController : Controller
    {
        public ActionResult SearchingRevisited()
        {
            var gridModel = new EmployeeJQGridModel();
            SetupEmployeeJQGrid(gridModel.EmployeeGrid);
            return View(gridModel);
        }

        public JsonResult OnEmployeeDataRequested()
        {
            var gridModel = new EmployeeJQGridModel();
            var repository = new GenericEmployeeRepository();
            SetupEmployeeJQGrid(gridModel.EmployeeGrid);
            var resultSet = repository.GetAll();
            return gridModel.EmployeeGrid.DataBind(resultSet.AsQueryable());
        }

        public void SetupEmployeeJQGrid(JQGrid employeeGrid)
        {
            // To avoid 
            // "DataTypeNotSetException: JQGridColumn.DataType must be set in order to perform search operations."

            JQGridColumn lastNameColumn = employeeGrid.Columns.Find(c => c.DataField == "LastName");
            lastNameColumn.DataType = typeof(string);

            JQGridColumn firstNameColumn = employeeGrid.Columns.Find(c => c.DataField == "FirstName");
            firstNameColumn.DataType = typeof(string);

            JQGridColumn titleColumn = employeeGrid.Columns.Find(c => c.DataField == "Title");
            titleColumn.DataType = typeof(string);
        }
    }
}
