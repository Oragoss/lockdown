using LockdownData;
using LockdownData.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace LockdownBusinessLogic.Managers
{
    public class PasswordManager : IPasswordManager
    {
        IPasswordManager passwordManager;

        public PasswordManager(IPasswordManager passwordManager)
        {
            this.passwordManager = passwordManager;
        }

        public string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null)
            {
                opts = new PasswordOptions();

                opts.RequiredLength = 8;
                opts.RequiredUniqueChars = 2;
                opts.RequireDigit = true;
                opts.RequireLowercase = true;
                opts.RequireNonAlphanumeric = true;
                opts.RequireUppercase = true;
            }

            var randomCharacters = new[]
             {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "abcdefghijklmnopqrstuvwxyz",
                "0123456789",
                "!@#$%^&*()_-+="
            };

            var characterList = new List<char>();
            Random random = new Random(Guid.NewGuid().GetHashCode());

            if (opts.RequireUppercase)
                characterList.Insert(random.Next(0, characterList.Count), randomCharacters[0][random.Next(0, randomCharacters[0].Length)]);

            if (opts.RequireUppercase)
                characterList.Insert(random.Next(1, characterList.Count), randomCharacters[1][random.Next(0, randomCharacters[1].Length)]);

            if (opts.RequireDigit)
                characterList.Insert(random.Next(2, characterList.Count), randomCharacters[2][random.Next(0, randomCharacters[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                characterList.Insert(random.Next(3, characterList.Count), randomCharacters[3][random.Next(0, randomCharacters[3].Length)]);

            for (int i = 0; i < opts.RequiredLength || characterList.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string randomCharacterString = randomCharacters[random.Next(0, randomCharacters.Length)];
                characterList.Insert(random.Next(0, characterList.Count), randomCharacterString[random.Next(0, randomCharacterString.Length)]);
            }

            return HashPassword(new string(characterList.ToArray()));
        }

        public string HashPassword(string password)
        {
            var encryptedPassword = Crypto.Hash(password, "sha256");
            var salt = Crypto.GenerateSalt();   //default bytes is 16, good enough

            var hashPassword = Crypto.HashPassword(encryptedPassword + salt);

            return hashPassword;
        }

        public bool VerifyPassword(string password)
        {
            //TODO: Get the hashed password from the db
            var hashedPassword = "";

            if (Crypto.VerifyHashedPassword(hashedPassword, password))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<GeneratedPassword> GetPasswordList(int userId)
        {
            IQueryable<GeneratedPassword> passwords;

            using (var db = new LockdownContext())
            {
                passwords = db.Passwords.Where(x => x.UserId == userId);
            }

            return passwords;
        }
    }
}
