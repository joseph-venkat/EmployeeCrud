using EmployeeCrud.Employee_Modal;
using System.Collections.Generic;

namespace EmployeeCrud.Respository.UserRepository
{
    public interface IUserRepository
    {
        void AddUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(int id);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
    }
}
