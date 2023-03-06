
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeCrud.Employee_Context;
using EmployeeCrud.Employee_Modal;
using EmployeeCrud.IUserRespository;
using EmployeeCrud.UserRespository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.UserRespository
{

    public class UserRepository: IUserRepository
    {
        private readonly EmployeeContext  _employeecontext;

        public UserRepository(EmployeeContext employeecontext)
        {
            _employeecontext = employeecontext;
        }

        public async Task CreateUserAsync(User user, string password)
        {
            string hashedPassword = HashPassword(password);
            user.HashedPassword = hashedPassword;

            _employeecontext.Users.Add(user);
            await _employeecontext.SaveChangesAsync();
        }

        public async Task<bool> CheckUserCredentialsAsync(string username, string password)
        {
            User user = await _employeecontext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return false;
            }

            return VerifyHashedPassword(user.HashedPassword, password);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _employeecontext.Users.ToListAsync();
        }
        private string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes("my app-specific salt"),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes("my app-specific salt"),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8).SequenceEqual(Convert.FromBase64String(hashedPassword));
        }
    }
}


