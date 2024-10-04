using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeWork3Customers.Models;

namespace HomeWork3Customers.Data
{
    public class HomeWork3CustomersContext : DbContext
    {
        public HomeWork3CustomersContext (DbContextOptions<HomeWork3CustomersContext> options)
            : base(options)
        {
        }

        public DbSet<HomeWork3Customers.Models.Customer> Customer { get; set; } = default!;
    }
}
