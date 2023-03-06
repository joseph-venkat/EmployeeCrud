using EmployeeCrud.Employee_Modal;
using System.Threading.Tasks;

namespace EmployeeCrud.Respository
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
    }
}
