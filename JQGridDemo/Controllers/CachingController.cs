using JQGridDemo.ControllerDataHelpers;
using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Trirand.Web.Mvc;
using JQGridDemo.Filters;
using JQGridDemo.CustomExceptions;

namespace JQGridDemo.Controllers
{
    public class CachingController : Controller
    {
        public ActionResult MemoryCaching()
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

            // Caching
            var cache = MemoryCache.Default;
            var resultSet = cache[this.ToString()] as IQueryable<Employee>;
            if (resultSet == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                resultSet = repository.GetAll();
                cache.Set(this.ToString(), resultSet, policy);
            }

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
        [JQGridPostExceptionHandler]
        public ActionResult EditEmployeeData(string oper, int? EmployeeID, string LastName, string FirstName,
            string Title, string BirthDate, string HireDate, string Address, string City, string Region, 
            string PostalCode, string Country, string HomePhone, string Extension, string PhotoPath)
        {
            // Evict the cache for all edits
            var cache = MemoryCache.Default;
            cache.Remove(this.ToString());           

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

    }
}
