using Microsoft.AspNetCore.Identity;

namespace LockdownBusinessLogic
{
    public interface IPasswordChecker
    {
        PasswordStrength GetPasswordStrength();
        bool IsStrongPassword(string password, int length = 8);
        bool IsValidPassword(string password, PasswordOptions opts);
    }
}
