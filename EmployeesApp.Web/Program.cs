using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Web.Models;
using Microsoft.EntityFrameworkCore;
using EmployeesApp.Infrastructure.Persistance;
using System.Globalization;



namespace EmployeesApp.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var cultureInfo = new CultureInfo("en-US");

        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connString));

        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<MyLogServiceFilterAttribute>();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}