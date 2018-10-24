using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;

namespace JQGridDemo.Models
{
    public class InitialSetupJQGridModel
    {
        public JQGrid EmployeeGrid;
        public InitialSetupJQGridModel()
        {
            EmployeeGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn { DataField = "EmployeeID", PrimaryKey = true }, 
                    new JQGridColumn { DataField = "LastName" }, 
                    new JQGridColumn { DataField = "FirstName" }, 
                    new JQGridColumn { DataField = "Title" }, 
                }
            };
        }
    }
}