using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;

namespace JQGridDemo.Models
{
    public class OrderJQGridModel
    {
        public JQGrid OrderGrid;

        public OrderJQGridModel()
        {
            OrderGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
            {
                new JQGridColumn { DataField = "OrderID", PrimaryKey = true },
                new JQGridColumn { DataField = "CustomerID" }, 
                new JQGridColumn { DataField = "EmployeeID" }, 
                new JQGridColumn { DataField = "EmployeeName" }, 
                new JQGridColumn { DataField = "OrderDate" }, 
                new JQGridColumn { DataField = "RequiredDate" }, 
                new JQGridColumn { DataField = "ShippedDate" }, 
                new JQGridColumn { DataField = "ShipVia" }, 
                new JQGridColumn { DataField = "Freight" }, 
                new JQGridColumn { DataField = "ShipName" }, 
                new JQGridColumn { DataField = "ShipAddress" },
                new JQGridColumn { DataField = "ShipCity" },
                new JQGridColumn { DataField = "ShipRegion" }, 
                new JQGridColumn { DataField = "ShipPostalCode" }, 
                new JQGridColumn { DataField = "ShipCountry" }, 
            }
            };
        }
    }
}
