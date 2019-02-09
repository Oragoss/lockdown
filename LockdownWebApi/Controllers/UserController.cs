using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LockdownBusinessLogic.Managers;
using LockdownBusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockdownWebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IPasswordManager passwordManager;
        IUserManager userManager;

        public UserController(IPasswordManager passwordManager, IUserManager userManager)
        {
            this.passwordManager = passwordManager;
            this.userManager = userManager;
        }

        [Route("GetList/{id}")]
        public ActionResult GetList(int id)
        {
            var list = passwordManager.GetPasswordList(id);
            return Ok(list);
        }

        [Route("PostNewUser")]
        public ActionResult PostNewUser(User user)
        {
            userManager.MakeNewAccount(user.Username, user.Password);
            return Ok();
        }
    }
}