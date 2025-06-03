using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
    {
        //public void Add(Employee employee)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task AddAsync(Employee employee)
        {

            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        public Employee[] GetAll()
        {
            throw new NotImplementedException();
        }

        //Classic C# syntax for GetAll()
        public async Task<Employee[]> GetAllAsync()
        {
            return await context.Employees.ToArrayAsync();
        }

        //public Employee? GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await context.Employees.FindAsync(id);
        }
    }
}