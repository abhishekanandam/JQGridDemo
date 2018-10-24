using JQGridDemo.ControllerDataHelpers;
using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Trirand.Web.Mvc;

namespace JQGridDemo.Controllers
{
    public class EditingController : Controller
    {
        public ActionResult AddEditDelete()
        {
            var gridModel = new EmployeeJQGridModel();
            SetupEmployeeJQGrid(gridModel.EmployeeGrid);
            return View(gridModel);
        }

        public ActionResult Validation()
        {
            var gridModel = new EmployeeJQGridModel();
            SetupEmployeeJQGrid(gridModel.EmployeeGrid);
            return View(gridModel);
        }

        public ActionResult InlineEditing()
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

        public string CountriesSelectList()
        {
            var helper = new CommonDataHelper();
            return helper.GetSelectHtmlOfCountriesThatWeServe();
        }

        public void SetupEmployeeJQGrid(JQGrid employeeGrid)
        {
            JQGridColumn lastNameColumn = employeeGrid.Columns.Find(c => c.DataField == "LastName");
            lastNameColumn.DataType = typeof(string);

            JQGridColumn firstNameColumn = employeeGrid.Columns.Find(c => c.DataField == "FirstName");
            firstNameColumn.DataType = typeof(string);

            JQGridColumn titleColumn = employeeGrid.Columns.Find(c => c.DataField == "Title");
            titleColumn.DataType = typeof(string);
        }

        [HttpPost]
        public ActionResult EditEmployeeData(string oper, int? EmployeeID, string LastName, string FirstName,
            string Title, string BirthDate, string HireDate, string Address, string City, string Region, 
            string PostalCode, string Country, string HomePhone, string Extension, string PhotoPath)
        {
            var repository = new GenericEmployeeRepository();
            if (oper == "add")
            {
                var employee = new Employee()
                {
                    LastName = LastName,
                    FirstName = FirstName,
                    Title = Title,
                    BirthDate = DateTime.Parse(BirthDate),
                    HireDate = DateTime.Parse(HireDate),
                    Address = Address,
                    City = City,
                    Region = Region,
                    PostalCode = PostalCode,
                    Country = Country,
                    HomePhone = HomePhone,
                    Extension = Extension,
                    PhotoPath = PhotoPath,
                };
                repository.Insert(employee);
                return Content("true");
            }
            else if (oper == "del")
            {
                var employee = repository.GetById((int)EmployeeID);
                repository.Delete(employee);
                return Content("true");
            }
            else if (oper == "edit")
            {
                var employee = repository.GetById((int)EmployeeID);
                employee.LastName = LastName;
                employee.FirstName = FirstName;
                employee.Title = Title;
                employee.HireDate = DateTime.Parse(HireDate);
                employee.Address = Address;
                employee.City = City;
                employee.Region = Region;
                employee.PostalCode = PostalCode;
                employee.Country = Country;
                employee.HomePhone = HomePhone;
                employee.Extension = Extension;
                employee.PhotoPath = PhotoPath;
                repository.Update(employee);
                return Content("true");
            }
            return Content("false");
        }

        static List<DropdownDemoModel> localModel = new List<DropdownDemoModel>() 
        {
            new DropdownDemoModel { Id = 1, Name = "George Washington", BirthPlace = "10", DeathPlace="10" },
            new DropdownDemoModel { Id = 2, Name = "John Adams", BirthPlace = "6", DeathPlace="6" },
            new DropdownDemoModel { Id = 3, Name = "Thomas Jefferson", BirthPlace = "10", DeathPlace="10" }
        };

        public JsonResult OnFoundingFatherDataRequested()
        {
            var gridModel = new DropdownDemoJQGridModel();
            return gridModel.DropdownDemoGrid.DataBind(localModel.AsQueryable());
        }

        [HttpPost]
        public ActionResult EditFoundingFather(string oper, int? Id, string Name, string BirthPlace, string DeathPlace)
        {
            if (oper == "edit")
            {
                foreach (var row in localModel)
                {
                    if (Id == row.Id)
                    {
                        row.Name = Name;
                        row.BirthPlace = BirthPlace;
                        row.DeathPlace = DeathPlace;
                        return Content("true");
                    }
                }
            }
            else if (oper == "add")
            {
                localModel.Sort((x, y) => y.Id.CompareTo(x.Id));
                var maxId = localModel[0].Id;
                var row = new DropdownDemoModel
                {
                    Id = maxId + 1,
                    Name = Name,
                    BirthPlace = BirthPlace,
                    DeathPlace = DeathPlace
                };
                localModel.Add(row);
                return Content("true");
            }
            else if (oper == "del")
            {
                var row = localModel.Where(x => x.Id == Id).FirstOrDefault();
                localModel.Remove(row);
                return Content("true");
            }
            return Content("false");
        }
    }
}
