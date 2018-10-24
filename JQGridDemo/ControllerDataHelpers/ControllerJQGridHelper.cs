using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace JQGridDemo.ControllerDataHelpers
{
    public static class ControllerJQGridHelper
    {
        public static void SetRequestQueryStringPageToOne(this Controller c)
        {
            var type = c.Request.QueryString.GetType();

            // find the read-only property
            PropertyInfo prop = type.GetProperty("IsReadOnly",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // set the read-only property to false and set page to 1
            prop.SetValue(c.Request.QueryString, false, null);
            c.Request.QueryString.Set("page", "1");

            // set the read-only property back to true
            prop.SetValue(c.Request.QueryString, true, null);
        }

        public static void ModifyJsonResultData(this Controller c, Object jsonResponse, 
            int currentPage, int rowsPerPage, int totalRecordsCount)
        {
            var type = jsonResponse.GetType();
            if (type.Name != "JsonResponse") return;

            PropertyInfo pageProperty = type.GetProperty("page");
            pageProperty.SetValue(jsonResponse, currentPage, null);

            PropertyInfo recordsProperty = type.GetProperty("records");
            recordsProperty.SetValue(jsonResponse, totalRecordsCount, null);

            PropertyInfo totalProperty = type.GetProperty("total");
            int totalpages = (totalRecordsCount + rowsPerPage - 1) / rowsPerPage;
            totalProperty.SetValue(jsonResponse, totalpages, null);
        }
    }
}