using EmployeeCrud.Employee_Modal;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace EmployeeCrud.Employee_Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet <User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        }
    }

}
