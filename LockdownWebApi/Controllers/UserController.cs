using LockdownBusinessLogic.Managers;
using LockdownBusinessLogic.Models;
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

        [Route("GetList/{username}")]
        [HttpGet]
        public ActionResult GetList(string username)
        {
            var list = passwordManager.GetPasswordList(username);
            return Ok(list);
        }

        [Route("PostNewUser")]
        [HttpPost]
        public ActionResult PostNewUser(User user)
        {
            userManager.MakeNewAccount(user.Username, user.Password);
            return Ok();
        }
    }
}