using EmployeeCrud.Employee_Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCrud.IUserRespository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user, string password);
        Task<bool> CheckUserCredentialsAsync(string username, string password);
    }
}
