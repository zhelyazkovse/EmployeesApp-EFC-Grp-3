using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using EmployeesApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Terminal;
internal class Program
{
    static EmployeeService employeeService;

    static void Main(string[] args)
    {
        DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmployeesAppDB;Trusted_Connection=True;");
        employeeService = new(new EmployeeRepository(new AppDbContext(builder.Options)));

        ListAllEmployees();

        while (true)
        {
            Console.Write("ID to look up: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            ListEmployee(id);
        }
    }
    
    private static void ListAllEmployees()
    {
        foreach (var item in employeeService.GetAll())
            Console.WriteLine($"Name: {item.Name}, Id: {item.Id}");

        Console.WriteLine("------------------------------");
    }

    private static void ListEmployee(int employeeID)
    {
        Employee? employee;

        try
        {
            employee = employeeService.GetById(employeeID);
            Console.WriteLine($"{employee?.Name}: {employee?.Email}");
            Console.WriteLine("------------------------------");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"EXCEPTION: {e.Message}");
        }
    }
}
