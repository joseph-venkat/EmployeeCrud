using EmployeeCrud.Employee_Context;
using EmployeeCrud.Employee_Modal;
using EmployeeCrud.EmployeeIRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrud.Employee_Repository
{
    public class EmployeeRepository : IEmployeeRepositoryClass
    {
        private readonly EmployeeContext _dbContext;

        public EmployeeRepository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Age = employee.Age;
                existingEmployee.MobileNumber = employee.MobileNumber;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.DateOfJoining = employee.DateOfJoining;
                await _dbContext.SaveChangesAsync();
            }
            return existingEmployee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEmployee != null)
            {
                _dbContext.Employees.Remove(existingEmployee);
                await _dbContext.SaveChangesAsync();
            }
            return existingEmployee;
        }
        public async Task<Employee> PatchEmployee(Employee employee)
        {
            var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                // Only update the properties that are not null
                if (employee.Name != null)
                {
                    existingEmployee.Name = employee.Name;
                }
                if (employee.Age != null)
                {
                    existingEmployee.Age = employee.Age;
                }
                if (employee.MobileNumber != null)
                {
                    existingEmployee.MobileNumber = employee.MobileNumber;
                }
                if (employee.Salary != null)
                {
                    existingEmployee.Salary = employee.Salary;
                }
                if (employee.DateOfJoining != null)
                {
                    existingEmployee.DateOfJoining = employee.DateOfJoining;
                }
                await _dbContext.SaveChangesAsync();
            }
            return existingEmployee;
        }

    }


}
