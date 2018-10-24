using JQGridDemo.ControllerDataHelpers;
using JQGridDemo.Repositories;
using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQGridDemo.Controllers
{
    public class ServerSidePagingController : Controller
    {
        public ActionResult ServerSidePaging()
        {
            return View();
        }

        public JsonResult OnCustomerDataRequested(int page, int rows, string sidx, string sord)
        {
            int totalRecordsCount;
            var gridModel = new CustomerJQGridModel();
            var repository = new CustomerOrdersRepository();

            this.SetRequestQueryStringPageToOne();
            var resultSet = repository.GetPageOfCustomers(page, rows, sidx, sord, out totalRecordsCount);
            JsonResult jsonResult = gridModel.CustomerGrid.DataBind(resultSet.AsQueryable());
            this.ModifyJsonResultData(jsonResult.Data, page, rows, totalRecordsCount);

            return jsonResult;
        }
    }
}
