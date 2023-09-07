using Business.Abstract;
using Core.Extensions;
using Entity.Concrete.MongoDbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PanteonGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildController : Controller
    {
        private readonly IBuildService _buildService;
        private readonly IUserService _userService;

        public BuildController(IBuildService buildService, IUserService userService)
        {
            _buildService = buildService;
            _userService = userService;
        }

        [Authorize]
        [HttpGet("build")]
        public IActionResult GetBuildById(string buildId)
        {
            var userId = User.GetClaimValue(System.Security.Claims.ClaimTypes.NameIdentifier);

            var data = _buildService.GetBuildById(buildId,Convert.ToInt32(userId));
            return Ok(data);
        }

        [Authorize]
        [HttpGet("build-list")]
        public IActionResult BuildList()
        {
            var userId = User.GetClaimValue(System.Security.Claims.ClaimTypes.NameIdentifier);
            

            var data = _buildService.GetAll(Convert.ToInt32(userId));
            return Ok(data);
        }

        [Authorize]
        [HttpPost("build-add")]
        public IActionResult AddBuild(Build build)
        {
            var userId = User.GetClaimValue(System.Security.Claims.ClaimTypes.NameIdentifier);
            var user = _userService.GetUserById(Convert.ToInt32(userId));

            build.UserId = Convert.ToInt32(userId);
            var result = _buildService.Add(build);
            return Ok(result);
        }
    }
}
