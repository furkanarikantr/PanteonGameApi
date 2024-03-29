﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Dtos;
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

        public BuildController(IBuildService buildService, IUserService userService)
        {
            _buildService = buildService;
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

        [Authorize]
        [HttpDelete("build-delete")]
        public IActionResult DeleteBuild(BuildDeleteDto buildDeleteDto)
        {
            var result = _buildService.Delete(buildDeleteDto.BuildId);
            return Ok(result);
        }
    }
}
