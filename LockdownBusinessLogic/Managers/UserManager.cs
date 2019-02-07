using LockdownBusinessLogic.Models;
using LockdownData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LockdownBusinessLogic.Managers
{
    public class UserManager : IUserManager
    {
        IUserManager userManager;
        IPasswordManager passwordManager;
        IPasswordChecker passwordChecker;

        public UserManager(IUserManager userManager, IPasswordManager passwordManager, IPasswordChecker passwordChecker)
        {
            this.userManager = userManager;
            this.passwordManager = passwordManager;
            this.passwordChecker = passwordChecker;
        }

        public void MakeNewAccount(string username, string password)
        {
            var hashPassword = passwordManager.HashPassword(password);

            using (var db = new LockdownContext())
            {
                db.Users.Add(new User
                {
                    Username = username,
                    Password = hashPassword,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });

                db.SaveChanges();
            }
        }
    }
}
