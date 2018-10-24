using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JQGridDemo.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace JQGridDemo.Repositories
{
    public class CustomerOrdersRepository
    {
        public List<CustomerModel> GetAllCustomers()
        {
            var context = new NorthwindEntities();
            var customers = context.Set<Customer>();
            var orders = context.Set<Order>();
            var query = from c in customers
                        select new CustomerModel
                        {
                            CustomerID = c.CustomerID,
                            CompanyName = c.CompanyName,
                            ContactName = c.ContactName,
                            ContactTitle = c.ContactTitle,
                            Address = c.Address,
                            City = c.City,
                            Region = c.Region,
                            PostalCode = c.PostalCode,
                            Country = c.Country,
                            Phone = c.Phone,
                            Fax = c.Fax
                        };
            var customerList = query.ToList();
            foreach (var c in customerList)
            {
                if (orders.Any(o => o.CustomerID == c.CustomerID))
                {
                    c.HasOrders = "+";
                }
                else c.HasOrders = "";
            }
            return customerList;
        }

     
        public List<OrderModel> GetOrders(string customerID)
        {
            var context = new NorthwindEntities();
            var customers = context.Set<Customer>();
            var employees = context.Set<Employee>();
            var orders = context.Set<Order>();
            var query = from o in orders
                        join e in employees on o.Employee equals e into OE
                        from oe in OE.DefaultIfEmpty()
                        where o.CustomerID == customerID
                        select new OrderModel
                        {
                            OrderID = o.OrderID,
                            CustomerID = o.CustomerID,
                            EmployeeID = o.EmployeeID,
                            EmployeeName = oe == null ? null : oe.FirstName + " " + oe.LastName,
                            OrderDate = o.OrderDate,
                            RequiredDate = o.RequiredDate,
                            ShippedDate = o.ShippedDate,
                            ShipVia = o.ShipVia,
                            Freight = o.Freight,
                            ShipName = o.ShipName,
                            ShipAddress = o.ShipAddress,
                            ShipCity = o.ShipCity,
                            ShipRegion = o.ShipRegion,
                            ShipPostalCode = o.ShipPostalCode,
                            ShipCountry = o.ShipCountry,
                        };
            return query.ToList();
        }

        public List<CustomerModel> GetPageOfCustomers(int pageNumber, int rowsPerPage, string sidx, string sord, out int totalRecordsCount)
        {
            // page number is one-based

            var context = new NorthwindEntities();
            var customers = context.Set<Customer>();
            var orders = context.Set<Order>();

            totalRecordsCount = context.Customers.Count();

            var query = from c in customers
                        orderby c.CompanyName
                        select new CustomerModel
                        {
                            CustomerID = c.CustomerID,
                            CompanyName = c.CompanyName,
                            ContactName = c.ContactName,
                            ContactTitle = c.ContactTitle,
                            Address = c.Address,
                            City = c.City,
                            Region = c.Region,
                            PostalCode = c.PostalCode,
                            Country = c.Country,
                            Phone = c.Phone,
                            Fax = c.Fax
                        };

            if (sord == "asc")
            {
                switch (sidx)
                {
                    case "Address": query = query.OrderBy(_ => _.Address); break;
                    case "City": query = query.OrderBy(_ => _.City); break;
                    case "CompanyName": query = query.OrderBy(_ => _.CompanyName); break;
                    case "ContactName": query = query.OrderBy(_ => _.ContactName); break;
                    case "ContactTitle": query = query.OrderBy(_ => _.ContactTitle); break;
                    case "Country": query = query.OrderBy(_ => _.Country); break;
                    case "CustomerID": query = query.OrderBy(_ => _.CustomerID); break;
                    case "Fax": query = query.OrderBy(_ => _.Fax); break;
                    case "Phone": query = query.OrderBy(_ => _.Phone); break;
                    case "PostalCode": query = query.OrderBy(_ => _.PostalCode); break;
                    case "Region": query = query.OrderBy(_ => _.Region); break;
                    default: break;
                }
            }
            else
            {
                switch (sidx)
                {
                    case "Address": query = query.OrderByDescending(_ => _.Address); break;
                    case "City": query = query.OrderByDescending(_ => _.City); break;
                    case "CompanyName": query = query.OrderByDescending(_ => _.CompanyName); break;
                    case "ContactName": query = query.OrderByDescending(_ => _.ContactName); break;
                    case "ContactTitle": query = query.OrderByDescending(_ => _.ContactTitle); break;
                    case "Country": query = query.OrderByDescending(_ => _.Country); break;
                    case "CustomerID": query = query.OrderByDescending(_ => _.CustomerID); break;
                    case "Fax": query = query.OrderByDescending(_ => _.Fax); break;
                    case "Phone": query = query.OrderByDescending(_ => _.Phone); break;
                    case "PostalCode": query = query.OrderByDescending(_ => _.PostalCode); break;
                    case "Region": query = query.OrderByDescending(_ => _.Region); break;
                    default: break;
                }
            }

            var pagedQueryResult = query.Skip((pageNumber - 1) * rowsPerPage).Take(rowsPerPage);
            var customerList = pagedQueryResult.ToList();

            foreach (var c in customerList)
            {
                if (orders.Any(o => o.CustomerID == c.CustomerID))
                {
                    c.HasOrders = "+";
                }
                else c.HasOrders = "";
            }
            return customerList;
        }
    }
}