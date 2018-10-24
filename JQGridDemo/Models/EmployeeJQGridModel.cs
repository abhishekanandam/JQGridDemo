using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;

namespace JQGridDemo.Models
{
    public class EmployeeJQGridModel
    {
        public JQGrid EmployeeGrid;
        public EmployeeJQGridModel()
        {
            EmployeeGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn { DataField = "EmployeeID", PrimaryKey = true }, 
                    new JQGridColumn { DataField = "LastName" }, 
                    new JQGridColumn { DataField = "FirstName" }, 
                    new JQGridColumn { DataField = "Title" }, 
                    new JQGridColumn { DataField = "BirthDate" }, 
                    new JQGridColumn { DataField = "HireDate" }, 
                    new JQGridColumn { DataField = "Address" }, 
                    new JQGridColumn { DataField = "City" }, 
                    new JQGridColumn { DataField = "Region" }, 
                    new JQGridColumn { DataField = "PostalCode" }, 
                    new JQGridColumn { DataField = "Country" }, 
                    new JQGridColumn { DataField = "HomePhone" }, 
                    new JQGridColumn { DataField = "Extension" }, 
                    new JQGridColumn { DataField = "PhotoPath" } 
                }
            };
        }
    }
}
