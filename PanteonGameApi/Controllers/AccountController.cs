using Business.Abstract;
using Core.Dtos;
using Entity.Concrete.MySqlEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PanteonGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("user-list")]
        public IActionResult UserList()
        {
            return Ok(_userService.GetList());
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLoginDto model)
        {
            var token = _userService.Authenticate(model.Username, model.Password);
            return Ok(token);
        }
    }
}
