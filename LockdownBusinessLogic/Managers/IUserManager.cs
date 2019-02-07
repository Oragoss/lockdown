using System;
using System.Collections.Generic;
using System.Text;

namespace LockdownBusinessLogic.Managers
{
    public interface IUserManager
    {
        void MakeNewAccount(string username, string password);
    }
}