using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;

namespace JQGridDemo.Models
{
    public class DropdownDemoJQGridModel
    {
        public JQGrid DropdownDemoGrid;
        public DropdownDemoJQGridModel()
        {
            DropdownDemoGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn { DataField = "Id", PrimaryKey = true },
                    new JQGridColumn { DataField = "Name" },
                    new JQGridColumn { DataField = "BirthPlace" },
                    new JQGridColumn { DataField = "DeathPlace" },
                }
            };
        }
    }
}