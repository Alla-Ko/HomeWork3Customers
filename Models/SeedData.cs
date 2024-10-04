using HomeWork3Customers.Data;
using HomeWork3Customers.Models;
using Microsoft.EntityFrameworkCore;


namespace MVCExample.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new HomeWork3CustomersContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<HomeWork3CustomersContext>>()))
        {
            // Look for any movies.
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }
            context.Customer.AddRange(
                new Customer
                {
                    FirstName = "Alla",
                    LastName = "Kokhaniuk",
                    Email = "alla.kokkhaniuk@example.com"

                },
                new Customer
                {
                    FirstName = "Anna",
                    LastName = "Kokhaniuk",
                    Email = "anna.kokkhaniuk@example.com"
                },
                new Customer
                {
                    FirstName = "Natalia",
                    LastName = "Kokhaniuk",
                    Email = "nata.kokkhaniuk@example.com"
                },
                new Customer
                {
                    FirstName = "Julia",
                    LastName = "Diachuk",
                    Email = "julia.diachuk@example.com"
                }
            );
            context.SaveChanges();
        }
    }
}
