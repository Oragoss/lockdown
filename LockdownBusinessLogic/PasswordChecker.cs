using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockdownBusinessLogic
{
    public enum PasswordStrength
    {
        /// <summary>
        /// Blank password (empty and/or space characters only).
        /// </summary>
        Blank,
        /// <summary>
        /// Either too short (less than 5 characters), one-case letters only or digits only.
        /// </summary>
        VeryWeak,
        /// <summary>
        /// At least 5 characters, one strong condition met (>= 8 characters with 1 or more uppercase letters, lowercase letters, digits & special characters).
        /// </summary>
        Weak,
        /// <summary>
        /// At least 5 characters, two strong conditions met (>= 8 characters with 1 or more uppercase letters, lowercase letters, digits & special characters).
        /// </summary>
        Medium,
        /// <summary>
        /// At least 5 characters, three strong conditions met (>= 8 characters with 1 or more uppercase letters, lowercase letters, digits & special characters).
        /// </summary>
        Strong,
        /// <summary>
        /// All conditions met
        /// </summary>
        VeryStrong
    }

    public class PasswordChecker
    {      
        /// <summary>
        /// Generic method for determining the strength of the user's password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public PasswordStrength GetPasswordStrength(string password)
        {
            int score = 0;
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password.Trim())) return PasswordStrength.Blank;
            if (!HasMinimumLength(password, 5)) return PasswordStrength.VeryWeak;
            if (HasMinimumLength(password, 5)) score++;
            if (HasUpperCaseLetter(password) && HasLowerCaseLetter(password)) score++;
            if (HasDigit(password)) score++;
            if (HasSpecialCharacter(password)) score++;

            return (PasswordStrength)score;
        }

        /// <summary>
        /// Simple method for determining if the password is strong
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsStrongPassword(string password, int length = 8)
        {
            return HasMinimumLength(password, length)
                && HasUpperCaseLetter(password)
                && HasLowerCaseLetter(password)
                && (HasDigit(password) || HasSpecialCharacter(password));
        }
        
        /// <summary>
        /// More powerful method for dermining password strength using PasswordOptions
        /// </summary>
        /// <param name="password"></param>
        /// <param name="opts"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password, PasswordOptions opts)
        {
            if (!HasMinimumLength(password, opts.RequiredLength)) return false;
            if (!HasMinimumUniqueCharacters(password, opts.RequiredUniqueChars)) return false;
            if (opts.RequireNonAlphanumeric && !HasSpecialCharacter(password)) return false;
            if (opts.RequireLowercase && !HasLowerCaseLetter(password)) return false;
            if (opts.RequireUppercase && !HasUpperCaseLetter(password)) return false;
            if (opts.RequireDigit && !HasDigit(password)) return false;

            return true;
        }


        #region Helper Methods

        private bool HasSpecialCharacter(string password)
        {
            return password.IndexOfAny("!@#$%^&*()_-+=".ToCharArray()) != -1;
        }

        private bool HasMinimumUniqueCharacters(string password, int minUniqueChars)
        {
            return password.Distinct().Count() >= minUniqueChars;
        }

        private bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }

        private bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }

        private bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }

        private bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }
        #endregion
    }
}
