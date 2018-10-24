using JQGridDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JQGridDemo.Repositories
{
    public class GenericEmployeeRepository : GenericRepository<Employee> { }

    public class GenericCustomerRepository : GenericRepository<Customer> { }

    public class GenericOrderRepository : GenericRepository<Order> { }

    public class GenericOrderDetailRepository : GenericRepository<Order_Detail> { }
}
