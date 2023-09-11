using Business.Abstract;
using Entity.Concrete.MongoDbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PanteonGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildTypeController : Controller
    {
        IBuildTypeService _buildTypeService;
        IBuildService _buildService;

        public BuildTypeController(IBuildTypeService buildTypeService, IBuildService buildService)
        {
            _buildTypeService = buildTypeService;
            _buildService = buildService;
        }

        [Authorize]
        [HttpGet("build-type-list")]
        public IActionResult BuildTypeList()
        {
            var addedBuild = _buildService.GetAll().Data;
            var data = _buildTypeService.GetAll().Data;

            var addedBuildTypes = addedBuild.Select(build => build.BuildType).ToList();
            var filteredData = data.Where(buildType => !addedBuildTypes.Contains(buildType.BuildTypes)).ToList();

            return Ok(filteredData);
        }

        [Authorize]
        [HttpPost("build-type-add")]
        public IActionResult AddBuild(BuildType buildType)
        {
            var result = _buildTypeService.Add(buildType);
            return Ok(result);
        }
    }
}
