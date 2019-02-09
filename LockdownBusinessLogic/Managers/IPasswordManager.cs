using LockdownData.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LockdownBusinessLogic.Managers
{
    public interface IPasswordManager
    {
        string GenerateRandomPassword(PasswordOptions passwordOptions = null);
        string HashPassword(string password);
        bool VerifyPassword(string password);
        IEnumerable<GeneratedPassword> GetPasswordList(int userId);
    }
}
