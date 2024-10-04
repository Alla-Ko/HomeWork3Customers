using HomeWork3Customers.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MVCExample.Models;
using System.Globalization;
namespace HomeWork3Customers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Налаштування культури
            var defaultCulture = new CultureInfo("uk-UA"); // Українська культура
            var supportedCultures = new[]
            {
                new CultureInfo("uk-UA"), // Українська культура
                new CultureInfo("en-US")  // Англійська культура
            };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };


            builder.Services.AddDbContext<HomeWork3CustomersContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HomeWork3CustomersContext") ?? throw new InvalidOperationException("Connection string 'HomeWork3CustomersContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();


            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            SeedData.Initialize(services);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // Використовуємо налаштування культури
            app.UseRequestLocalization(localizationOptions);
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Customers}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
