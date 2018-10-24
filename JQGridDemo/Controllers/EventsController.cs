using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace JQGridDemo.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult HarnessingEvents()
        {
            Session["EventsCountry"] = "0";
            var gridModel = new EmployeeJQGridModel();
            return View(gridModel);
        }

        public string OnSelectedCountryChanged(string country)
        {
            Session["EventsCountry"] = country;
            var js = new JavaScriptSerializer();
            return js.Serialize(new object());
        }

        public JsonResult OnEmployeeDataRequested()
        {
            var country = Session["EventsCountry"].ToString();
            var gridModel = new EmployeeJQGridModel();
            var repository = new GenericEmployeeRepository();
            IQueryable<Employee> resultSet;
            if (country == "0")
            {
                resultSet = repository.GetAll();
            }
            else
            { 
                resultSet = repository.SearchFor(e => e.Country == country);
            }
            return gridModel.EmployeeGrid.DataBind(resultSet.AsQueryable());
        }
    }
}
