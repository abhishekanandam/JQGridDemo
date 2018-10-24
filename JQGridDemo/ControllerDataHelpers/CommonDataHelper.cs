using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQGridDemo.Repositories;

namespace JQGridDemo.ControllerDataHelpers
{
    public class CommonDataHelper
    {
        public string GetSelectHtmlOfCountriesThatWeServe()
        {
            var repository = new GenericCustomerRepository();
            var customers = repository.GetAll();

            var hashset = new HashSet<string>();
            foreach(var customer in customers)
            {
                hashset.Add(customer.Country.Trim());
            }
            var countries = hashset.ToList();
            countries.Sort();

            var sb = new StringBuilder();
            sb.Append("<select>");
            foreach (var country in countries)
            {
                sb.Append("<option value='").Append(country).Append("'>");
                sb.Append(country).Append("</option>");
            }
            sb.Append("</select>");

            return sb.ToString();
        }
    }
}