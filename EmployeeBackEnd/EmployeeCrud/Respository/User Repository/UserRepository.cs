using EmployeeCrud.Employee_Context;
using EmployeeCrud.Employee_Modal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeCrud.Respository
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeContext _dbContext;

        public UserRepository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user;
        }
    }
}
