using Business.Abstract;
using Entity.Concrete.MySqlEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PanteonGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.AddUser(user);
            return Ok(result);
        }
    }
}
