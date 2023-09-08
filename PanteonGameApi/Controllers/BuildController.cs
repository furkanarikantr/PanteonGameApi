using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Extensions;
using Entity.Concrete.MongoDbEntities;
using FluentValidation.Results;
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
            var data = _buildService.GetBuildById(buildId);
            return Ok(data);
        }

        [Authorize]
        [HttpGet("build-list")]
        public IActionResult BuildList()
        {
            var data = _buildService.GetAll();
            return Ok(data);
        }

        [Authorize]
        [HttpPost("build-add")]
        public IActionResult AddBuild(Build build)
        {
            var result = _buildService.Add(build);
            return Ok(result);
        }
    }
}
