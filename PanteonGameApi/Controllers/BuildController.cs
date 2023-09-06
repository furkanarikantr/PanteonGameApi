using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PanteonGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildController : Controller
    {
        private readonly IBuildService _buildService;

        public BuildController(IBuildService buildService)
        {
            _buildService = buildService;
        }

        [HttpGet("build-list")]
        public IActionResult BuildList()
        {
            var data = _buildService.GetAll();
            return Ok(data);
        }
    }
}
