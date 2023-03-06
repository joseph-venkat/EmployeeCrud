using EmployeeCrud.Employee_Modal;
using EmployeeCrud.Employee_Repository;
using EmployeeCrud.EmployeeIRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCrud.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepositoryClass _employeeRepository;

        public EmployeesController(IEmployeeRepositoryClass employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var existingEmployee = await _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            await _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteEmployee(id);
            return employee;
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployeePatch(int id, [FromBody] Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name ?? existingEmployee.Name;
            existingEmployee.Age = employee.Age != 0 ? employee.Age : existingEmployee.Age;
            existingEmployee.MobileNumber = employee.MobileNumber ?? existingEmployee.MobileNumber;
            existingEmployee.Salary = employee.Salary != 0 ? employee.Salary : existingEmployee.Salary;
            existingEmployee.DateOfJoining = employee.DateOfJoining != null ? employee.DateOfJoining : existingEmployee.DateOfJoining;
            var updatedEmployee = await _employeeRepository.UpdateEmployee(existingEmployee);
            return updatedEmployee;
        }
    }
}
