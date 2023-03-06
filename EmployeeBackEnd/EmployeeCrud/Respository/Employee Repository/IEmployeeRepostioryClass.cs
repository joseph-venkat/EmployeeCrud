using EmployeeCrud.Employee_Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCrud.EmployeeIRepository
{
    public interface IEmployeeRepositoryClass
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
        Task<Employee> PatchEmployee(Employee employee);
    }
}
