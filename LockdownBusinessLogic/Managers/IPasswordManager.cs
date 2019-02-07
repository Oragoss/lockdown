using Microsoft.AspNetCore.Identity;

namespace LockdownBusinessLogic.Managers
{
    public interface IPasswordManager
    {
        string GenerateRandomPassword(PasswordOptions passwordOptions = null);
        string HashPassword(string password);
        bool VerifyPassword(string password);
    }
}
