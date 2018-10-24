using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace JQGridDemo.Controllers
{
    public class MasterDetailController : Controller
    {
        public ActionResult MasterDetailGrids()
        {
            return View();
        }

        public JsonResult OnCustomerDataRequested()
        {
            var gridModel = new CustomerJQGridModel();
            var repository = new CustomerOrdersRepository();
            var resultSet = repository.GetAllCustomers();
            var jsonResult = gridModel.CustomerGrid.DataBind(resultSet.AsQueryable());
            return jsonResult;
        }

        public JsonResult OnOrderDataRequested(string id)
        {
            var gridModel = new OrderJQGridModel();
            var repository = new CustomerOrdersRepository();
            var resultSet = repository.GetOrders(id);
            return gridModel.OrderGrid.DataBind(resultSet.AsQueryable());
        }


    }
}
