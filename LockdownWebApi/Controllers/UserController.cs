using LockdownBusinessLogic.Managers;
using LockdownBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace LockdownWebApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserManager userManager;

        [Route("api/GetPasswordList/${id}")]
        [HttpGet]
        public ActionResult GetPasswordList(int id)
        {
            return Ok();
        }

        [HttpPost]
        public void Post(User user)
        {

        }

    }
}