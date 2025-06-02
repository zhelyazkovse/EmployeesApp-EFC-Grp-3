using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeesApp.Domain.Entities;
using System.Data;

namespace EmployeesApp.Infrastructure.Persistance
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)

    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType(SqlDbType.Money.ToString());

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Benke Benk", Email = "benk@bsons.com", Salary = 20000.00 },
                new Employee { Id = 2, Name = "Banke Bank", Email = "bank@bsons.com", Salary = 23000.00 },
                new Employee { Id = 3, Name = "Bonke Bonk", Email = "bonk@bsons.com", Salary = 19500.00 });
        }
    }
}
