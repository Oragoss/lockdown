using Microsoft.AspNetCore.Identity;

namespace LockdownBusinessLogic
{
    public interface IPasswordChecker
    {
        PasswordStrength GetPasswordStrength(string password, int minLength = 5);
        bool IsStrongPassword(string password, int length = 8);
        bool IsValidPassword(string password, PasswordOptions opts);
    }
}