using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
    {
       

        public void Add(Employee employee)
        {
            
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        //Classic C# syntax for GetAll()
        public Employee[] GetAll()
        {
            return [.. context.Employees];
        }

        public Employee? GetById(int id) => context.Employees
            .Find(id);
    }
}