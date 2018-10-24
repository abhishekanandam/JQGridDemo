using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;

namespace JQGridDemo.Models
{
    public class CustomerJQGridModel
    {
        public JQGrid CustomerGrid;

        public CustomerJQGridModel()
        {
             CustomerGrid = new JQGrid
             {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn { DataField = "HasOrders" },
                    new JQGridColumn { DataField = "CustomerID", PrimaryKey = true }, 
                    new JQGridColumn { DataField = "CompanyName" }, 
                    new JQGridColumn { DataField = "ContactName" }, 
                    new JQGridColumn { DataField = "ContactTitle" }, 
                    new JQGridColumn { DataField = "Address" }, 
                    new JQGridColumn { DataField = "City" }, 
                    new JQGridColumn { DataField = "Region" }, 
                    new JQGridColumn { DataField = "PostalCode" }, 
                    new JQGridColumn { DataField = "Country" }, 
                    new JQGridColumn { DataField = "Phone" }, 
                    new JQGridColumn { DataField = "Fax" }, 
                }
             };
        }       
    }
}