using LockdownData.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace LockdownBusinessLogic.Managers
{
    public interface IPasswordManager
    {
        string GenerateRandomPassword(PasswordOptions passwordOptions = null);
        string HashPassword(string password);
        bool VerifyPassword(string password);
        IQueryable<GeneratedPassword> GetPasswordList(string username);
    }
}
